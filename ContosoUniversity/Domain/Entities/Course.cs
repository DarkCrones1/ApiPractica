namespace ContosoUniversity.Domain.Entities;

public class Course
{
    public int Id {get;set;}
    public int Credits {get;set;}
    public string Name {get;set;} = string.Empty;
}