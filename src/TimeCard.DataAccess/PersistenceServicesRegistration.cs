using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeCard.DataAccess;
using Microsoft.EntityFrameworkCore;
using TimeCard.Persistence.Repositories.Interface;
using TimeCard.Persistence.Repositories;
using TimeCard.DataAccess.Interface;

namespace TimeCard.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceService(this IServiceCollection srv, IConfiguration config)
    {
        srv.AddDbContext<DataContext>(opt =>
               opt.UseSqlServer(config.GetConnectionString("DefaultConnection"))
           );

        srv.AddScoped<IJobCardRepository, JobCardRepository>();
        srv.AddScoped<IJobRepository, JobRepository>();

        return srv;
    }
}
