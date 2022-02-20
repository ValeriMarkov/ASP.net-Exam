namespace ParkingExam.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using ParkingExam.Data;


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}