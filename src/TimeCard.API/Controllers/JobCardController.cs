using Microsoft.AspNetCore.Mvc;
using TimeCard.Domain;
using TimeCard.Persistence.Repositories.Interface;

namespace TimeCard.API.Controllers;

[ApiController]
[Route("[controller]")]
public class JobCardController : ControllerBase
{
    private readonly ILogger<JobCardController> _logger;

    private readonly IJobCardRepository _jobCardRepository;

    public JobCardController(ILogger<JobCardController> logger, IJobCardRepository jobCardRepository)
    {
        _logger = logger;
        _jobCardRepository = jobCardRepository;
    }

    // must include Dto
    //[HttpGet(Name = "GetJobCard")]
    [HttpGet]
    public async Task<ActionResult<JobCard>> GetJobCard()
    {
        var jobCard = await _jobCardRepository.GetJobCardsAsync();

        _logger.LogInformation("GetJobCard");

        return Ok(jobCard);
    }
}
