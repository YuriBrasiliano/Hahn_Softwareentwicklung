using Hahn_Softwareentwicklung.Application.Common.Interfaces.Services;
using Hahn_Softwareentwicklung.Contracts.Job;
using Hahn_Softwareentwicklung.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hahn_Softwareentwicklung.Api.Controllers;


[Route("[controller]")]
public class JobsController : ApiController
{

    private readonly IJobService _jobService;

    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpPost]
    public IActionResult CreateJob(CreateJobRequest request)
    {
        var job = new Job(
            Guid.NewGuid(),
            request.UserId,
            request.Name,
            request.Description,
            request.TaskLocation,
            request.TaskLink,
            request.TaskGroup,
            DateTime.UtcNow,
            request.TaskDateTime
        );

        _jobService.CreateJob(job);

        var response = new JobResponse(
            job.Id,
            job.UserId,
            job.Name,
            job.Description,
            job.TaskLocation,
            job.TaskLink,
            job.TaskGroup,
            job.RegisterDateTime,
            job.TaskDateTime
        );
        return CreatedAtAction(
            actionName: nameof(GetJob),
            routeValues: new {id = job.Id},
            value: response);
    }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetJob(Guid id)
        {
            Job job = await Task.Run(() => _jobService.GetJob(id));
            var response = new JobResponse(
                job.Id,
                job.UserId,
                job.Name,
                job.Description,
                job.TaskLocation,
                job.TaskLink,
                job.TaskGroup,
                job.RegisterDateTime,
                job.TaskDateTime
            );
            return Ok(response);
        }
    [HttpPut("{id:guid}")]
    public IActionResult UpsertJob(Guid id, UpsertJobRequest request)
    {
        var job = new Job(
            id,
            request.UserId,
            request.Name,
            request.Description,
            request.TaskLocation,
            request.TaskLink,
            request.TaskGroup,
            DateTime.UtcNow,
            request.TaskDateTime
        );
         _jobService.UpsertJob(job);

        return NoContent();
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteJob(Guid id)
    {
        _jobService.DeleteJob(id);
        return NoContent();
    }
    
    [HttpGet("usertasks/{UserId}")]
    public IActionResult GetUserJobs(string UserId)
    {
    List<Job> jobs = _jobService.GetUserJobs(UserId);
    List<JobResponse> jobResponses = jobs.Select(job => new JobResponse(
        job.Id,
        job.UserId,
        job.Name,
        job.Description,
        job.TaskLocation,
        job.TaskLink,
        job.TaskGroup,
        job.RegisterDateTime,
        job.TaskDateTime
    )).ToList();
    return Ok(jobResponses);
}
    }
