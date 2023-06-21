namespace ActivitiesApi.DTOs.Ticket
{
    public class GetTicketByIdResponseDTO
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int TicketCategoryId { get; set; }
    }
}
