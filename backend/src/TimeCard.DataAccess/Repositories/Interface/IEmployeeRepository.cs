using TimeCard.Domain;

namespace TimeCard.DataAccess.Interface;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployeeAsync();
    Task<Employee> GetJobCardAsync(int empId);
    Task<bool> CreateEmployeeAsync(Employee job);
}
