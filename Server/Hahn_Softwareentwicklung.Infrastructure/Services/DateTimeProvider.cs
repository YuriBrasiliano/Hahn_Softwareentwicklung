namespace Hahn_Softwareentwicklung.Infrastructure.Services;
using Hahn_Softwareentwicklung.Application.Common.Interfaces.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}