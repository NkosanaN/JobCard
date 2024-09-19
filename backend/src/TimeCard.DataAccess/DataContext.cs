using Microsoft.EntityFrameworkCore;
using TimeCard.Domain;

namespace TimeCard.DataAccess;

public class DataContext : DbContext
{
    //check how does it pass to base

    public DataContext(DbContextOptions<DataContext> options) 
        : base(options)
    {
    }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobCard> JobCards { get; set; }
    public DbSet<Employee> Employees { get; set; }

}
