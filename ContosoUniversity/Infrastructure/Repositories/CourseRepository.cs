using ContosoUniversity.Infrastructure.Data;
using ContosoUniversity.Domain.Entities;

namespace ContosoUniversity.Reposotories.CourseRepository;
public class CourseRepository
{
    private DBLocalContosoUniversityCourse _dbcontext;

    public CourseRepository()
    {
        _dbcontext = new DBLocalContosoUniversityCourse();
    }

    public IEnumerable<Course> Get()
    {
        return _dbcontext.Courses;
    }

    public Course Get(int id)
    {
        return _dbcontext.Courses.Single(x => x.Id == id) ?? new Course()   ;
    }

    public IEnumerable<Course> Get(Course course)
    {
        var query = _dbcontext.Courses.Select(c => c);

        if (course.Id > 0)
        {
            query = query.Where(c => c.Id == course.Id);
        }
        if (course.Credits > 0)
        {
            query = query.Where(c => c.Credits == course.Credits);
        }
        if (!string.IsNullOrEmpty(course.Name))
        {
            query = query.Where(c => c.Name.Contains(course.Name));
        }

        return query.ToList();
    }
}