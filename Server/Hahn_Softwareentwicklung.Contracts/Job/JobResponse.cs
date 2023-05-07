namespace Hahn_Softwareentwicklung.Contracts.Job;

public record JobResponse(
    Guid Id,
    string Name,
    string Description,
    string TaskLocation,
    string TaskLink,
    string TaskGroup,
    DateTime RegisterDateTime,
    DateTime TaskDateTime
);