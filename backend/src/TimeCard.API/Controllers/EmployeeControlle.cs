using Microsoft.AspNetCore.Mvc;
using System.Net;
using TimeCard.DataAccess.Interface;
using TimeCard.Domain;

namespace TimeCard.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;

    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
    {
        _logger = logger;
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Employee>))]
    public async Task<List<Employee>> GetEmployeesAsync()
    {
        var jobCard = await _employeeRepository.GetEmployeeAsync();

        _logger.LogInformation("GetEmployeesAsync");

        return jobCard;
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Employee))]
    public async Task<ActionResult> GetEmployeeAsync(int id)
    {
        var employee = await _employeeRepository.GetJobCardAsync(id);

        if (employee is null) 
        {
            return BadRequest($"employee with {id} does not exist");
        }

        _logger.LogInformation("GetEmployeeAsync");

        return Ok(employee);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Employee))]
    public async Task<ActionResult> CreateEmployeeAsync([FromBody] Employee employee)
    {

        if(!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        await _employeeRepository.CreateEmployeeAsync(employee);

        _logger.LogInformation("CreateEmployeeAsync");

        return Ok();
    }
}
