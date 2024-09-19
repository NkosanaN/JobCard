using Microsoft.EntityFrameworkCore;
using TimeCard.DataAccess;
using TimeCard.DataAccess.Interface;
using TimeCard.Domain;

namespace TimeCard.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _dataAccess;
    public EmployeeRepository(DataContext dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<List<Employee>> GetEmployeeAsync()
    {
        return await _dataAccess.Employees.ToListAsync();
    }

    public async Task<bool> CreateEmployeeAsync(Employee emp)
    {
        bool result;

        await _dataAccess.Employees.AddAsync(emp);

        result = await _dataAccess.SaveChangesAsync() > 0;

        if (result)
        {
            return result;
        }

        return result;
    }

    public async Task<Employee> GetJobCardAsync(int empId)
    {
        var result = await _dataAccess.Employees.FindAsync(empId);
        
        return result;
    }

}
