using System.Text.Json;
using ContosoUniversity.Domain.Entities;

namespace ContosoUniversity.Infrastructure.Data;
public class DBLocalContosoUniversity
{
    private const string fileName = "dbContosoUniversity.json";
    private const string dataPath = "Infrastructure\\Data\\Person";
    private List<Person> _persons;

    private void LoadData()
    {
        var filePath = Path.Combine(Environment.CurrentDirectory, dataPath, fileName);

        if(File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            _persons = JsonSerializer.Deserialize<List<Person>>(jsonString)!;
        }
    }

    public IEnumerable<Person> Persons => _persons;

    public DBLocalContosoUniversity()
    {
        _persons = new List<Person>();
        LoadData();
    }
}