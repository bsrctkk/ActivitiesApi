using ActivitiesApi.DTOs.Image;
using ActivitiesApi.DTOs.Place;
using ActivitiesApi.Models.Context;
using ActivitiesApi.Models.ORM;
using Microsoft.AspNetCore.Mvc;



namespace ActivitiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        MyContext context;

        public PlaceController()
        {
            context = new MyContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllPlaceResponseDTO> response = context.Places.Select(x => new GetAllPlaceResponseDTO
            {
                Id = x.Id,
                Name=x.Name,
                City=x.City,
                District=x.District,
                Address=x.Address,
                MapUrl=x.MapUrl,
            }).ToList();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Place place = context.Places.FirstOrDefault(x => x.Id == id);
            if (place == null)
            {
                return NotFound(id + " id not found");
            }
            else
            {
                GetPlaceByIdResponseDTO response = new GetPlaceByIdResponseDTO();
                response.Id = place.Id;
                response.Name = place.Name;
                response.City = place.City;
                response.District = place.District;
                response.Address = place.Address;
                response.MapUrl = place.MapUrl;
                return Ok(response);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreatePlaceRequestDTO request)
        {
            Place place = new Place();
            place.Name = request.Name;
            place.City = request.City;
            place.District = request.District;
            place.Address = request.Address;
            place.MapUrl = request.MapUrl;
            context.Places.Add(place);
            context.SaveChanges();
            List<GetAllPlaceResponseDTO> response = context.Places.Select(x => new GetAllPlaceResponseDTO
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                District = x.District,
                Address = x.Address,
                MapUrl = x.MapUrl,
            }).ToList();
            return Ok(response);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePlaceRequestDTO Place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not A valid data");
            }
            var existingPlace = context.Places.Where(p => p.Id == id).FirstOrDefault<Place>();
            if (existingPlace != null)
            {
                existingPlace.Name =Place.Name;
                existingPlace.City =Place.City;
                existingPlace.District =Place.District;
                existingPlace.Address =Place.Address;
                existingPlace.MapUrl = Place.MapUrl;
                context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            List<GetAllPlaceResponseDTO> response = context.Places.Select(x => new GetAllPlaceResponseDTO
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                District = x.District,
                Address = x.Address,
                MapUrl = x.MapUrl,
            }).ToList();
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           Place Place = context.Places.FirstOrDefault(x => x.Id == id);
            if (Place != null)
            {
                context.Places.Remove(Place);
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

