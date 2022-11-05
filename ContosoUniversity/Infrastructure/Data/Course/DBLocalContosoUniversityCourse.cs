using System.Text.Json;
using ContosoUniversity.Domain.Entities;

namespace ContosoUniversity.Infrastructure.Data;
public class DBLocalContosoUniversityCourse
{
    private const string fileName = "dbContosoUniversityCourses.json";
    private const string dataPath = "Infrastructure\\Data\\Course";
    private List<Course> _courses;

    private void LoadData()
    {
        var filePath = Path.Combine(Environment.CurrentDirectory, dataPath, fileName);

        if(File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            _courses = JsonSerializer.Deserialize<List<Course>>(jsonString)!;
        }
    }

    public IEnumerable<Course> Courses => _courses;

    public DBLocalContosoUniversityCourse()
    {
        _courses = new List<Course>();
        LoadData();
    }
}