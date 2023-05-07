using Hahn_Softwareentwicklung.Domain.Entities;

namespace Hahn_Softwareentwicklung.Application.Common.Interfaces.Services;

public class JobService : IJobService
{
    private static readonly Dictionary<Guid, Job> _job = new();
    public void CreateJob(Job job)
    {
        _job.Add(job.Id, job);
    }

    Job IJobService.GetJob(Guid id)
    {
        return _job[id];
    }
}