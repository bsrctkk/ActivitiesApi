using System.ComponentModel.DataAnnotations.Schema;

namespace ActivitiesApi.Models.ORM
{
    public class Activity
    {
        public int Id { get; set; } 
        public string? Title { get; set; }    
        public string? Description { get; set; } 

        public ICollection<Image> Images { get; set; }
        public ICollection<ActivityDetail> ActivityDetails { get; set;}
    }
}
