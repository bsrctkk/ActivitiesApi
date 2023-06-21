namespace ActivitiesApi.DTOs.ActivityDetail
{
    public class UpdateActivityDetailRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public int ActivityCategoryId { get; set; }
        public int ActivityId { get; set; }

        public int PlaceId { get; set; }
        public int TicketId { get; set; }
    }
}
