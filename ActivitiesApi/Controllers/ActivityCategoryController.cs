using ActivitiesApi.DTOs.ActivityCategory;
using ActivitiesApi.Models.Context;
using ActivitiesApi.Models.ORM;
using Microsoft.AspNetCore.Mvc;


namespace ActivitiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityCategoryController : ControllerBase
    {

        MyContext my;
        public ActivityCategoryController() 
        {
            my = new MyContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllActivityCategoryResponseDTO> response=my.ActivityCategories.Select(c => new GetAllActivityCategoryResponseDTO 
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return Ok(response);
        }

       
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ActivityCategory activityCategory = my.ActivityCategories.FirstOrDefault(c => c.Id == id);
            if (activityCategory == null) 
            {
                return NotFound(id + "id not found");
            }
            else
            {
                GetActivityCategoryByIdResponseDTO response = new GetActivityCategoryByIdResponseDTO();
                response.Id = activityCategory.Id;
                response.Name = activityCategory.Name;
                return Ok(response);
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] CreateActivityCategoryRequestDTO request)
        {
            ActivityCategory activityCategory=new ActivityCategory();
            activityCategory.Name = request.Name;
            my.ActivityCategories.Add(activityCategory);
            my.SaveChanges();

            List<GetAllActivityCategoryResponseDTO> response = my.ActivityCategories.Select(c => new GetAllActivityCategoryResponseDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return Ok(response);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateActivityCategoryRequestDTO requestDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Not A valid data");
            }
            var existingActivityCategory = my.ActivityCategories.Where(p => p.Id == id).FirstOrDefault<ActivityCategory>();
            if (existingActivityCategory != null) 
            {
                existingActivityCategory.Name = requestDTO.Name;
                my.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllActivityCategoryResponseDTO> response = my.ActivityCategories.Select(c => new GetAllActivityCategoryResponseDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return Ok(response);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ActivityCategory activityCategory = my.ActivityCategories.FirstOrDefault(x => x.Id == id);
            if (activityCategory != null)
            {
                my.ActivityCategories.Remove(activityCategory);
                my.SaveChanges();
                return Ok("Deleted");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
