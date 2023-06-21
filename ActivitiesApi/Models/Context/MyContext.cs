using ActivitiesApi.Models.ORM;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesApi.Models.Context
{
    public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=ActivitiesDb; Trusted_Connection=True");
        }

        public virtual DbSet<Activity> Activities { get; set; }

        public virtual DbSet<ActivityCategory> ActivityCategories { get; set; }
        public virtual DbSet<ActivityDetail> ActivityDetails { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<TicketCategory> TicketCategories { get; set; }
    }
}
