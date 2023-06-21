using ActivitiesApi.DTOs.Place;
using ActivitiesApi.DTOs.Ticket;
using ActivitiesApi.Models.Context;
using ActivitiesApi.Models.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace ActivitiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        MyContext context;

        public TicketController() 
        {
            context = new MyContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllTicketResponseDTO> response = context.Tickets.Include("TicketCategory").Select(x => new GetAllTicketResponseDTO
            {
                Id = x.Id,
                Price = x.Price,
                TicketCategoryId = x.TicketCategoryId,
                TicketName=x.TicketCategory.Name
            }).ToList();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Ticket ticket = context.Tickets.FirstOrDefault(x => x.Id == id);
            if (ticket == null)
            {
                return NotFound(id + " id not found");
            }
            else
            {
                GetTicketByIdResponseDTO response = new GetTicketByIdResponseDTO();
                response.Id = ticket.Id;
                response.Price = ticket.Price;
                response.TicketCategoryId = ticket.TicketCategoryId;
                return Ok(response);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTicketRequestDTO request)
        {
            Ticket ticket = new Ticket();
            ticket.Price = request.Price;
            ticket.TicketCategoryId = request.TicketCategoryId;
            context.Tickets.Add(ticket);
            context.SaveChanges();
            List<GetAllTicketResponseDTO> response = context.Tickets.Include("TicketCategory").Select(x => new GetAllTicketResponseDTO
            {   
                Id = x.Id,
                Price = x.Price,
                TicketCategoryId = x.TicketCategoryId,
                TicketName = x.TicketCategory.Name
            }).ToList();
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTicketRequestDTO Ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not A valid data");
            }
            var existingTicket = context.Tickets.Where(p => p.Id == id).FirstOrDefault<Ticket>();
            if (existingTicket != null)
            {
                existingTicket.Price = Ticket.Price;
                existingTicket.TicketCategoryId = Ticket.TicketCategoryId;
                context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllTicketResponseDTO> response = context.Tickets.Include("TicketCategory").Select(x => new GetAllTicketResponseDTO
            {
                Id = x.Id,
                Price = x.Price,
                TicketCategoryId = x.TicketCategoryId,
                TicketName = x.TicketCategory.Name
            }).ToList();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           Ticket Ticket = context.Tickets.FirstOrDefault(x => x.Id == id);
            if (Ticket != null)
            {
                context.Tickets.Remove(Ticket);
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
