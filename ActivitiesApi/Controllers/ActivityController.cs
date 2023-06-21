using ActivitiesApi.DTOs.Activity;
using ActivitiesApi.Models.Context;
using ActivitiesApi.Models.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace ActivitiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        MyContext context;

        public ActivityController()
        {
            context = new MyContext();
        }
       
        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllActivityResponseDTO> response = context.Activities.Select(x => new GetAllActivityResponseDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToList();
            return Ok(response);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            Activity activity = context.Activities.FirstOrDefault(x => x.Id == id);
            if(activity == null)
            {
                return NotFound(id + " id not found");
            }
            else
            {
                GetActivityByIdResponseDTO response = new GetActivityByIdResponseDTO();
                response.Id = activity.Id;
                response.Title = activity.Title;
                response.Description = activity.Description;
                return Ok(response);
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] CreateActivityRequestDTO request)
        {
            Activity activity=new Activity();
            activity.Title = request.Title;
            activity.Description = request.Description;
            context.Activities.Add(activity);
            context.SaveChanges();
            List<GetAllActivityResponseDTO> response = context.Activities.Select(x => new GetAllActivityResponseDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToList();
            return Ok(response);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateActivityRequestDTO Activity)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Not A valid data");
            }
            var existingActivity=context.Activities.Where(p => p.Id == id).FirstOrDefault<Activity>();
            if(existingActivity != null)
            {
                existingActivity.Title=Activity.Title;
                existingActivity.Description=Activity.Description;
                context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllActivityResponseDTO> response = context.Activities.Select(x => new GetAllActivityResponseDTO
            {
                Id=x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToList();
            return Ok(response);
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Activity activity=context.Activities.FirstOrDefault(x => x.Id == id);
            if(activity != null) 
            {
                context.Activities.Remove(activity);
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
