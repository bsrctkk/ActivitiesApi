namespace ActivitiesApi.Models.ORM
{
    public class TicketCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set;}
    }
}
