using TaskChallenge.Communication.Enums;

namespace TaskChallenge.Communication.Requests;

public class RequestTaskJson
{
    public string Name {get;set;} = string.Empty;
    public string Description {get;set;} = string.Empty;
    public Priority Priority {get;set;}
    public DateTime DueDate {get;set;}
    public Status Status {get;set;}
}