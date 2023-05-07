namespace Hahn_Softwareentwicklung.Contracts.Job;

public record CreateJobRequest(
    Guid Id,
    string Name,
    string Description,
    string TaskLocation,
    string TaskLink,
    string TaskGroup,
    DateTime RegisterDateTime,
    DateTime TaskDateTime
);