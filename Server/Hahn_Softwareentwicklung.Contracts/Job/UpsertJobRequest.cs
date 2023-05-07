namespace Hahn_Softwareentwicklung.Contracts.Job;

public record UpsertJobRequest(
    string Name,
    string Description,
    string TaskLocation,
    string TaskLink,
    string TaskGroup,
    DateTime RegisterDateTime,
    DateTime TaskDateTime
);