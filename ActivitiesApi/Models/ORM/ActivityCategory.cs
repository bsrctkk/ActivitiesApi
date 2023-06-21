namespace ActivitiesApi.Models.ORM
{
    public class ActivityCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ActivityDetail> ActivityDetails { get; set; }


    }
}
