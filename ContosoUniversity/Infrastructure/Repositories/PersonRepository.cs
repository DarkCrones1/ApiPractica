using ContosoUniversity.Infrastructure.Data;
using ContosoUniversity.Domain.Entities;

namespace ContosoUniversity.Reposotories.PersonRepository;
public class PersonRepository
{
    private DBLocalContosoUniversity _dbcontext;

    public PersonRepository()
    {
        _dbcontext = new DBLocalContosoUniversity();
    }

    public IEnumerable<Person> Get()
    {
        return _dbcontext.Persons;
    }

    public Person Get(int id)
    {
        return _dbcontext.Persons.Single(x => x.Id == id) ?? new Person();
    }

    public IEnumerable<Person> Get(Person person)
    {
        var query = _dbcontext.Persons.Select(p => p);

        if (person.Id > 0)
        {
            query = query.Where(p => p.Id == person.Id);
        }
        if (!string.IsNullOrEmpty(person.FirstName))
        {
            query = query.Where(p => p.LastName.Contains(person.LastName));
        }
        if (!string.IsNullOrEmpty(person.FirstName))
        {
            query = query.Where(p => p.FirstName.Contains(person.FirstName));
        }
        if (!string.IsNullOrEmpty(person.Addres))
        {
            query = query.Where(p => p.Addres!=null && p.Addres.Contains(person.Addres));
        }
        if (person.EnrollmentDate.HasValue)
        {
            query = query.Where(p => p.EnrollmentDate == person.EnrollmentDate.Value);
        }
        if (person.HasParkingLot.HasValue)
        {
            query = query.Where(p => p.HasParkingLot == person.HasParkingLot.Value);
        }
        return query.ToList();
    }
}