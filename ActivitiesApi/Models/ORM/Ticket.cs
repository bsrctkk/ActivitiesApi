namespace ActivitiesApi.Models.ORM
{
    public class Ticket
    {
        public int Id { get; set; }

        public string TypeName { get; set; }    

        public decimal Price { get; set; }
 

        public int TicketCategoryId { get; set; }

        public virtual TicketCategory TicketCategory { get; set; }
        public ICollection<ActivityDetail> ActivityDetails { get; set; } 
        
    }
}
