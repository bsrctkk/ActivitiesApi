namespace ActivitiesApi.Models.ORM
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? Address { get; set; } 

        public string MapUrl { get; set; }

       public ICollection<ActivityDetail> ActivityDetails { get; set; }  

       
    }
}
