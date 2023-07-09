namespace ActivitiesApi.DTOs.Ticket
{
    public class GetAllTicketResponseDTO
    {
        public int Id { get; set; } 
        public decimal Price { get; set; }
        public string TypeName { get; set; }

        public int TicketCategoryId { get; set; }

        public string TicketName { get; set; }
    }
}
