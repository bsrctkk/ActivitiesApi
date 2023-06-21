namespace ActivitiesApi.DTOs.Image
{
    public class CreateImageRequestDTO
    {
        public string? ImageUrl { get; set; }

        public int ActivityId { get; set; }
    }
}
