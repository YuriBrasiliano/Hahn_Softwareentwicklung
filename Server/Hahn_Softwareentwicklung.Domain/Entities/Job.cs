namespace Hahn_Softwareentwicklung.Domain.Entities;

public class Job
{   public Guid Id { get;}
    public string Name {get;}
    public string Description {get;} 
    public string TaskLocation {get;} 
    public string TaskLink {get; }
    public string TaskGroup {get;}
    public DateTime RegisterDateTime {get;}
    public DateTime TaskDateTime {get;}


public Job(Guid id,
           string name,
           string description,
           string taskLocation,
           string taskLink,
           string taskGroup,
           DateTime registeredDateTime,
           DateTime taskDateTime
           )
{
    Id = id;
    Name = name;
    Description = description;
    TaskLocation = taskLocation;
    TaskLink = taskLink;
    TaskGroup = taskGroup;
    RegisterDateTime = registeredDateTime;
    TaskDateTime = taskDateTime;
    

}
}