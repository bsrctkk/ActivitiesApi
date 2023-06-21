using ActivitiesApi.DTOs.ActivityCategory;
using ActivitiesApi.DTOs.ActivityDetail;
using ActivitiesApi.Models.Context;
using ActivitiesApi.Models.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityDetailController : ControllerBase
    {
        MyContext context;
        public ActivityDetailController()
        {
            context = new MyContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllActivityDetailResponseDTO> response = context.ActivityDetails.Include("ActivityCategory").Include("Activity").Include("Place").Include("Ticket").Select(c => new GetAllActivityDetailResponseDTO
            {
                Id = c.Id,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Description = c.Description,
                ActivityCategoryId = c.ActivityCategoryId,
                ActivityCategoryName=c.ActivityCategory.Name,
                ActivityTitle=c.Activity.Title,
                ActivityDescription=c.Activity.Description,
                ActivityId = c.ActivityId,
                PlaceId = c.PlaceId,
                PlaceName=c.Place.Name,
                PlaceAddress=c.Place.Address,
                PlaceCity=c.Place.City,
                PlaceDistrict=c.Place.District,
                PlaceMapUrl=c.Place.MapUrl,
                TicketId = c.TicketId,
                TicketPrice=c.Ticket.Price,
                TicketCategoryId=c.Ticket.TicketCategoryId

            }).ToList();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ActivityDetail activityDetail = context.ActivityDetails.FirstOrDefault(c => c.Id == id);
            if (activityDetail == null)
            {
                return NotFound(id + "id not found");
            }
            else
            {
                GetActivityDetailByIdResponseDTO response = new GetActivityDetailByIdResponseDTO();
                response.Id = activityDetail.Id;
                response.StartDate = activityDetail.StartDate;
                response.EndDate = activityDetail.EndDate;
                response.Description = activityDetail.Description;
                response.ActivityCategoryId= activityDetail.ActivityCategoryId;
                response.ActivityId= activityDetail.ActivityId;
                response.PlaceId= activityDetail.PlaceId;
                response.TicketId= activityDetail.TicketId;
                return Ok(response);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateActivityDetailRequestDTO request)
        {
            ActivityDetail activityDetail = new ActivityDetail();
            activityDetail.StartDate = request.StartDate;
            activityDetail.EndDate = request.EndDate;
            activityDetail.Description = request.Description;
            activityDetail.ActivityCategoryId = request.ActivityCategoryId;
            activityDetail.ActivityId=request.ActivityId;
            activityDetail.PlaceId = request.PlaceId;
            activityDetail.TicketId = request.TicketId;
            context.ActivityDetails.Add(activityDetail);
            context.SaveChanges();

            List<GetAllActivityDetailResponseDTO> response = context.ActivityDetails.Include("ActivityCategory").Include("Activity").Include("Place").Include("Ticket").Select(c => new GetAllActivityDetailResponseDTO
            {
                Id = c.Id,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Description = c.Description,
                ActivityCategoryId = c.ActivityCategoryId,
                ActivityCategoryName = c.ActivityCategory.Name,
                ActivityTitle = c.Activity.Title,
                ActivityDescription = c.Activity.Description,
                ActivityId = c.ActivityId,
                PlaceId = c.PlaceId,
                PlaceName = c.Place.Name,
                PlaceAddress = c.Place.Address,
                PlaceCity = c.Place.City,
                PlaceDistrict = c.Place.District,
                PlaceMapUrl = c.Place.MapUrl,
                TicketId = c.TicketId,
                TicketPrice = c.Ticket.Price,
                TicketCategoryId = c.Ticket.TicketCategoryId

            }).ToList();
            return Ok(response);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateActivityDetailRequestDTO requestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not A valid data");
            }
            var existingActivityDetail = context.ActivityDetails.Where(p => p.Id == id).FirstOrDefault<ActivityDetail>();
            if (existingActivityDetail != null)
            {
                existingActivityDetail.StartDate = requestDTO.StartDate;
                existingActivityDetail.EndDate = requestDTO.EndDate;
                existingActivityDetail.Description = requestDTO.Description;
                existingActivityDetail.ActivityCategoryId = requestDTO.ActivityCategoryId;
                existingActivityDetail.ActivityId = requestDTO.ActivityId;
                existingActivityDetail.PlaceId = requestDTO.PlaceId;
                existingActivityDetail.TicketId = requestDTO.TicketId;
                context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllActivityDetailResponseDTO> response = context.ActivityDetails.Include("ActivityCategory").Include("Activity").Include("Place").Include("Ticket").Select(c => new GetAllActivityDetailResponseDTO
            {
                Id = c.Id,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Description = c.Description,
                ActivityCategoryId = c.ActivityCategoryId,
                ActivityCategoryName = c.ActivityCategory.Name,
                ActivityTitle = c.Activity.Title,
                ActivityDescription = c.Activity.Description,
                ActivityId = c.ActivityId,
                PlaceId = c.PlaceId,
                PlaceName = c.Place.Name,
                PlaceAddress = c.Place.Address,
                PlaceCity = c.Place.City,
                PlaceDistrict = c.Place.District,
                PlaceMapUrl = c.Place.MapUrl,
                TicketId = c.TicketId,
                TicketPrice = c.Ticket.Price,
                TicketCategoryId = c.Ticket.TicketCategoryId

            }).ToList();
            return Ok(response);

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ActivityDetail activityDetail = context.ActivityDetails.FirstOrDefault(x => x.Id == id);
            if (activityDetail != null)
            {
                context.ActivityDetails.Remove(activityDetail);
                context.SaveChanges();
                return Ok("Deleted");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
