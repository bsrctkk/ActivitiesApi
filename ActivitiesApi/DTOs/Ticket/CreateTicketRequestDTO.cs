namespace ActivitiesApi.DTOs.Ticket
{
    public class CreateTicketRequestDTO
    {
        public decimal Price { get; set; }

        public int TicketCategoryId { get; set; }

        public string TypeName { get; set; }
    }
}
