using System.ComponentModel.DataAnnotations.Schema;

namespace ActivitiesApi.Models.ORM
{
    public class ActivityDetail
    {
       public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }


        public int ActivityCategoryId { get; set; }
        public virtual ActivityCategory ActivityCategory { get; set; }


        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }

       
        public int TicketId { get; set; } 
        public virtual Ticket Ticket { get; set; } 

    }
}
