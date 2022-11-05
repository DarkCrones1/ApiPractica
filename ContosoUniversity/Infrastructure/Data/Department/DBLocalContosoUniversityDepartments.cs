using System.Text.Json;
using ContosoUniversity.Domain.Entities;

namespace ContosoUniversity.Infrastructure.Data;
public class DBLocalContosoUniversityDepartment
{
    private const string fileName = "dbContosoUniversityDepartments.json";
    private const string dataPath = "Infrastructure\\Data\\Department";
    private List<Department> _departments;

    private void LoadData()
    {
        var filePath = Path.Combine(Environment.CurrentDirectory, dataPath, fileName);

        if(File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            _departments = JsonSerializer.Deserialize<List<Department>>(jsonString)!;
        }
    }

    public IEnumerable<Department> Departments => _departments;

    public DBLocalContosoUniversityDepartment()
    {
        _departments = new List<Department>();
        LoadData();
    }
}