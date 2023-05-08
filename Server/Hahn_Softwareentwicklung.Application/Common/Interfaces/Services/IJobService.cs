using Hahn_Softwareentwicklung.Domain.Entities;

namespace Hahn_Softwareentwicklung.Application.Common.Interfaces.Services;


public interface IJobService
{
    void CreateJob(Job job);

    List<Job> GetAllJobs();
    List<Job> GetUserJobs(string UserId);

    Job GetJob (Guid id);
}