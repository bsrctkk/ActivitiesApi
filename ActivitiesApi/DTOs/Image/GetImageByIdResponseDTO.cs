namespace ActivitiesApi.DTOs.Image
{
    public class GetImageByIdResponseDTO
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }

        public int ActivityId { get; set; }
    }
}
