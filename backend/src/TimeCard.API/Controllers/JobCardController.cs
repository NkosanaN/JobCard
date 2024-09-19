using Microsoft.AspNetCore.Mvc;
using System.Net;
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

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<JobCard>))]
    public async Task<List<JobCard>> GetJobCardsAsync()
    {
        var jobCard = await _jobCardRepository.GetJobCardsAsync();

        _logger.LogInformation("GetJobCardsAsync");

        return jobCard;
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<JobCard>))]
    public async Task<JobCard> GetJobCardAsync(int id)
    {
        var jobCard = await _jobCardRepository.GetJobCardAsync(id);

        _logger.LogInformation("GetJobCardAsync");

        return jobCard;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(JobCard))]
    public async Task<ActionResult> CreateJobCardAsync([FromBody]JobCard jobCard)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _jobCardRepository.CreateJobCardAsync(jobCard);

        _logger.LogInformation("CreateJobCardAsync");

        return Ok();
    }
}
