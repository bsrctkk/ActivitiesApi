namespace ActivitiesApi.DTOs.Ticket
{
    public class UpdateTicketRequestDTO
    {
        public decimal Price { get; set; }

        public string TypeName { get; set; }

        public int TicketCategoryId { get; set; }
    }
}
