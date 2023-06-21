namespace ActivitiesApi.DTOs.Image
{
    public class GetAllImageResponseDTO
    {
        public int Id { get; set; } 
        public string? ImageUrl { get; set; }

        public int ActivityId { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
