// Generic Repository Interface
public interface IRepository<T> where T : class
{
    List<T> GetAll();
}

// Generic Repository Implementation
public class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly SqlConnection _connection;
    private readonly string _tableName;

    public GenericRepository(SqlConnection connection, string tableName)
    {
        _connection = connection;
        _tableName = tableName;
    }

    public List<T> GetAll()
    {
        var items = new List<T>();
        var command = new SqlCommand($"SELECT * FROM {_tableName}", _connection);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var item = Activator.CreateInstance<T>();
            typeof(T).GetProperty("Id")?.SetValue(item, reader.GetInt32(0));
            typeof(T).GetProperty("Name")?.SetValue(item, reader.GetString(1));
            items.Add(item);
        }

        return items;
    }
}

// Entity Classes
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// Dependency Injection Setup (e.g., in Program.cs)
class Program
{
    static void Main(string[] args)
    {
        var connection = new SqlConnection("your_connection_string");

        // Manual DI for simplicity
        IRepository<Student> studentRepo = new GenericRepository<Student>(connection, "Students");
        IRepository<Teacher> teacherRepo = new GenericRepository<Teacher>(connection, "Teachers");

        var students = studentRepo.GetAll();
        var teachers = teacherRepo.GetAll();
    }
}