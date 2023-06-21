namespace ActivitiesApi.DTOs.Ticket
{
    public class UpdateTicketRequestDTO
    {
        public decimal Price { get; set; }

        public int TicketCategoryId { get; set; }
    }
}
