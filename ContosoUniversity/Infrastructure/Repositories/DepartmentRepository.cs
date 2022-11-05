using ContosoUniversity.Infrastructure.Data;
using ContosoUniversity.Domain.Entities;

namespace ContosoUniversity.Reposotories.DepartmentRepository;
public class DepartmentRepository
{
    private DBLocalContosoUniversityDepartment _dbcontext;

    public DepartmentRepository()
    {
        _dbcontext = new DBLocalContosoUniversityDepartment();
    }

    public IEnumerable<Department> Get()
    {
        return _dbcontext.Departments;
    }

    public Department Get(int id)
    {
        return _dbcontext.Departments.Single(x => x.Id == id) ?? new Department();
    }

    public IEnumerable<Department> Get(Department department)
    {
        var query = _dbcontext.Departments.Select(d => d);

        if(department.Id > 0)
        {
            query = query.Where(d => d.Id == department.Id);
        }
        if (department.Budget > 0)
        {
            query = query.Where(d => d.Budget == department.Budget);
        }
        if (department.InstructorId > 0)
        {
            query = query.Where(d => d.InstructorId == department.InstructorId);
        }
        if (!string.IsNullOrEmpty(department.Name))
        {
            query = query.Where(d => d.Name.Contains(department.Name));
        }
        if (department.StartDate.HasValue)
        {
            query = query.Where(d => d.StartDate == department.StartDate);
        }
        return query.ToList();
    }
}