#region Additional Namespaces
using SQLiteDemo;
#endregion

#region Program

// Create db context class
using AppDbContext db = new AppDbContext();

// Loads/Deletes the Database file
//db.Database.EnsureDeleted();
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