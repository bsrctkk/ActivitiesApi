using ActivitiesApi.DTOs.Ticket;
using ActivitiesApi.DTOs.TicketCategory;
using ActivitiesApi.Models.Context;
using ActivitiesApi.Models.ORM;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActivitiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCategoryController : ControllerBase
    {
        MyContext context;

        public TicketCategoryController()
        {
            context = new MyContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllTicketCategoryResponseDTO> response = context.TicketCategories.Select(x => new GetAllTicketCategoryResponseDTO
            {
                Id = x.Id,  
                Name = x.Name
            }).ToList();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TicketCategory ticketCategory = context.TicketCategories.FirstOrDefault(x => x.Id == id);
            if (ticketCategory == null)
            {
                return NotFound(id + " id not found");
            }
            else
            {
                GetTicketCategoryByIdResponseDTO response = new GetTicketCategoryByIdResponseDTO();
                response.Id = ticketCategory.Id;
                response.Name = ticketCategory.Name;
                return Ok(response);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTicketCategoryRequestDTO request)
        {
            TicketCategory ticketCategory = new TicketCategory();
            ticketCategory.Name = request.Name;
            context.TicketCategories.Add(ticketCategory);
            context.SaveChanges();
            List<GetAllTicketCategoryResponseDTO> response = context.TicketCategories.Select(x => new GetAllTicketCategoryResponseDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTicketCategoryRequestDTO TicketCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not A valid data");
            }
            var existingTicketCategory = context.TicketCategories.Where(p => p.Id == id).FirstOrDefault<TicketCategory>();
            if (existingTicketCategory != null)
            {
                existingTicketCategory.Name = TicketCategory.Name;
                context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllTicketCategoryResponseDTO> response = context.TicketCategories.Select(x => new GetAllTicketCategoryResponseDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TicketCategory TicketCategory = context.TicketCategories.FirstOrDefault(x => x.Id == id);
            if (TicketCategory != null)
            {
                context.TicketCategories.Remove(TicketCategory);
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

