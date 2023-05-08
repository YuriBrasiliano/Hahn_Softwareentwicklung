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
    public IActionResult GetJob(Guid id)
    {
        Job job = _jobService.GetJob(id);
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
        return Ok(request);
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteJob(Guid id)
    {
        return Ok(id);
    }
    [HttpGet("alltasks")]
    public IActionResult GetAllJobs()
    {
        return Ok();
    }
    
    [HttpGet("usertasks")]
    public IActionResult GetUserJobs(GetUserJobRequest request)
    {
    List<Job> jobs = _jobService.GetUserJobs(request.UserId);
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
