using Hahn_Softwareentwicklung.Domain.Entities;

namespace Hahn_Softwareentwicklung.Application.Common.Interfaces.Services;


public interface IJobService
{
    void CreateJob(Job job);

    Job GetJob (Guid id);
}