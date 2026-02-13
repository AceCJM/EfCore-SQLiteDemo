#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using SQLiteDemo;
#endregion

#region Program

#region Create db instance && Add items to db
// Create db context class
using AppDbContext db = new AppDbContext();

// Loads/Deletes the Database file
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

// Create The Departments
Department dep1 = new Department { Code = "A1", DepartmentName = "Department A1" };
Department dep2 = new Department { Code = "B2", DepartmentName = "Department B2" };
Department dep3 = new Department { Code = "C3", DepartmentName = "Department C3" };
db.Departments.AddRange(dep1, dep2, dep3);

// Create The People
db.People.AddRange( // AddRange lets you add multiple things in one statement
    new Person { Name = "Alice", Age = 20, Mark = 90, Department = /* The {} extends the department list within the Person instance */ { dep1 } },
    new Person { Name = "Bob", Age = 19, Mark = 25, Department = { dep2 } },
    new Person { Name = "Gary", Age = 39, Mark = 91, Department = { dep3 } },
    new Person { Name = "Jerry", Age = 42, Mark = 84, Department = { dep1, dep2 } },
    new Person { Name = "Wilson", Age = 70, Mark = 12, Department = { dep1, dep2, dep3 } }
);

// Persist the data to the db file
db.SaveChanges();
#endregion

#region Read data from the db
// Create Lists to store data loaded from the db
List<Department> departments = new();
List<Person> people = new();

// Read data from db
departments = db.Departments
                .Include(i => i.People) // References the People table for the Navigational Property to work
                .OrderBy(d => d.DepartmentName)
                .ToList();

// Display the data retreived from the db
foreach (Department department in departments) // Iterates through the Departments
{
    Console.WriteLine($"\nDepartment Name: {department.DepartmentName}, Code: {department.Code}\nPeople:");
    foreach (Person person in department.People) // Iterates through the list of People created by the .Include statement
    {
        Console.WriteLine($"\tName: {person.Name}, Age: {person.Age}, Mark: {person.Mark}, Departments: {string.Join(", ", person.Department.Select(d => d.DepartmentName)) /* Uses LINQ to create a list of departmend names, string.join to join the list with ', ' as a separator */}");
    }
}

#endregion
#endregion