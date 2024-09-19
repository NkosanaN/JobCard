using TimeCard.DataAccess;
using TimeCard.Domain;

namespace TimeCard.Persistence.DbInitializer;

public class DbInitializer : IDbInitializer
{
    private readonly DataContext _db;
    public DbInitializer(DataContext db)
    {
        _db = db;
    }
    public void Initialize()
    {
        try
        {
            var dbExists = _db.Database.CanConnect();

            if (!dbExists)
            {
                var createDB = _db.Database.EnsureCreated();

                if (createDB)
                {
                    Seed(_db);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return;
    }
    public static void Seed(DataContext context)
    {
        if (!context.Jobs.Any())
        {
            context.Jobs.AddRange(
                new Job { JobId = "R00001", JobType = "Repair", DateCreated = DateTime.Now, ClientName = "Company A", ClientPhone = "1234567890", ClientContactName = "John Doe" },
                new Job { JobId = "S00001", JobType = "Support", DateCreated = DateTime.Now, ClientName = "Company B", ClientPhone = "0987654321", ClientContactName = "Jane Smith" }
            );

            context.SaveChanges();
        }

        if (!context.Employees.Any())
        {
            context.Employees.AddRange(
                new Employee { FirstName = "Jane", LastName = "Johnson", Phone = "456-789-0123", Email = "jane.smith@example.com" },
                new Employee { FirstName = "Michael", LastName = "Johnson", Phone = "567-890-1234", Email = "michael.johnson@example.com" },
                new Employee { FirstName = "Emily", LastName = "Davis", Phone = "456-789-0123", Email = "emily.davis@example.com" },
                new Employee { FirstName = "William", LastName = "Brown", Phone = "567-890-1234", Email = "william.brown@example.com" }
            );

            context.SaveChanges();
        }


        if (!context.JobCards.Any())
        {
            context.JobCards.AddRange(
                new JobCard { EmployeeId = 1, JobId = "R00001", DateWorked = DateTime.Now, HoursWorked = 4 },
                new JobCard { EmployeeId = 2, JobId = "S00001", DateWorked = DateTime.Now, HoursWorked = 5 }
            );

            context.SaveChanges();
        }
    }
}
