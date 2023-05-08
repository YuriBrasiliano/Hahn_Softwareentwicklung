using Hahn_Softwareentwicklung.Domain.Entities;

namespace Hahn_Softwareentwicklung.Application.Common.Interfaces.Services;

public class JobService : IJobService
{
    private static readonly List<Job> _job = new();
    public void CreateJob(Job job)
    {
        _job.Add(job);
    }

    public List<Job> GetAllJobs(){
        return _job;
    }

    public List<Job> GetUserJobs(string UserId){
        return _job.FindAll(job => job.UserId == UserId);
    }

    Job IJobService.GetJob(Guid id)
    {
        return _job.Single(u => u.Id == id);
    }
}