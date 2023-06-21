namespace ActivitiesApi.DTOs.Place
{
    public class UpdatePlaceRequestDTO
    {
        
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? Address { get; set; }

        public string MapUrl { get; set; }
    }
}
