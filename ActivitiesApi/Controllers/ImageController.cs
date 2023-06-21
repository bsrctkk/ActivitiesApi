using ActivitiesApi.DTOs.Activity;
using ActivitiesApi.DTOs.Image;
using ActivitiesApi.Models.Context;
using ActivitiesApi.Models.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        MyContext context;

        public ImageController()
        {
            context = new MyContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllImageResponseDTO> response = context.Images.Include("Activity").Select(x => new GetAllImageResponseDTO
            {
                Id = x.Id,
               ImageUrl = x.ImageUrl,
               ActivityId = x.ActivityId,
               Title=x.Activity.Title,
               Description=x.Activity.Description,
            }).ToList();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Image ımage = context.Images.FirstOrDefault(x => x.Id == id);
            if (ımage == null)
            {
                return NotFound(id + " id not found");
            }
            else
            {
                GetImageByIdResponseDTO response = new GetImageByIdResponseDTO();
                response.Id = ımage.Id;
                response.ImageUrl = ımage.ImageUrl;
                response.ActivityId=ımage.ActivityId;
                return Ok(response);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateImageRequestDTO request)
        {
            Image ımage = new Image();
            ımage.ImageUrl = request.ImageUrl;
            ımage.ActivityId = request.ActivityId;
            context.Images.Add(ımage);
            context.SaveChanges();
            List<GetAllImageResponseDTO> response = context.Images.Include("Activity").Select(x => new GetAllImageResponseDTO
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                ActivityId = x.ActivityId,
                Title = x.Activity.Title,
                Description = x.Activity.Description,
            }).ToList();
            return Ok(response);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateImageRequestDTO Image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not A valid data");
            }
            var existingImage = context.Images.Where(p => p.Id == id).FirstOrDefault<Image>();
            if (existingImage != null)
            {
                existingImage.ImageUrl = Image.ImageUrl;
                existingImage.ActivityId = Image.ActivityId;
                context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllImageResponseDTO> response = context.Images.Include("Activity").Select(x => new GetAllImageResponseDTO
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                ActivityId = x.ActivityId,
                Title = x.Activity.Title,
                Description = x.Activity.Description,
            }).ToList();
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Image Image = context.Images.FirstOrDefault(x => x.Id == id);
            if (Image != null)
            {
                context.Images.Remove(Image);
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
