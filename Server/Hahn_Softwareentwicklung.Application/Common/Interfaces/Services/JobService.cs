using Hahn_Softwareentwicklung.Domain.Entities;

namespace Hahn_Softwareentwicklung.Application.Common.Interfaces.Services;

public class JobService : IJobService
{
    private static readonly List<Job> _job = new();
    public void CreateJob(Job job)
    {
        _job.Add(job);
    }

    public List<Job> GetUserJobs(string UserId){
        return _job.FindAll(job => job.UserId == UserId);
    }

    public void DeleteJob(Guid id)
    {
        _job.RemoveAll(u => u.Id == id);
    }

    public Job GetJob(Guid id)
    {
        return _job.Single(u => u.Id == id);
    }

    public void UpsertJob(Job job)
    {
        int index = _job.FindIndex(j => j.Id == job.Id);
        if (index != -1)
        {
            _job[index] = job;
        }
        else
        {
            _job.Add(job);
        }
    }
}