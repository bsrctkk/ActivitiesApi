namespace ActivitiesApi.DTOs.ActivityDetail
{
    public class GetAllActivityDetailResponseDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public int ActivityCategoryId { get; set; }
        public int ActivityId { get; set; }

        public int PlaceId { get; set; }
        public int TicketId { get; set; }

        public string? ActivityTitle { get; set; }
        public string? ActivityDescription { get; set; }

        public string? ActivityCategoryName { get; set; }

        public string PlaceName { get; set; }
        public string PlaceCity { get; set; }
        public string PlaceDistrict { get; set; }
        public string? PlaceAddress { get; set; }

        public string PlaceMapUrl { get; set; }
        public decimal TicketPrice { get; set; }
        public int TicketCategoryId { get; set; }
    }
}
