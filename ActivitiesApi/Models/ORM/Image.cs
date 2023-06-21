namespace ActivitiesApi.Models.ORM
{
    public class Image
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }

        public int ActivityId { get; set; } 

        public virtual Activity Activity { get; set;}

    }
}
