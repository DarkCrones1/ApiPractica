namespace ContosoUniversity.Domain.Entities;

public class Department
{
    public int Id {get;set;}
    public double Budget {get;set;}
    public int InstructorId {get;set;}
    public string Name {get;set;} = string.Empty;
    public DateTime? StartDate {get;set;}
}