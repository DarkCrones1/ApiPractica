namespace ContosoUniversity.Domain.Entities;

public class Person
{
    public int Id {get;set;}
    public string FirstName {get;set;} = string.Empty;
    public string LastName {get;set;} = string.Empty;
    public DateTime HireDAte {get;set;}
    public DateTime? EnrollmentDate {get;set;}
    public string Addres {get;set;} = string.Empty;
    public bool? HasParkingLot {get;set;}   
}