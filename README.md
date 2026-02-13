# SQLiteDemo

A demonstration project for learning Entity Framework Core (EF Core) with SQLite. This console application showcases basic CRUD operations, entity relationships, and database configuration using EF Core.

## Features

- **Entity Framework Core Integration**: Demonstrates setting up a DbContext with SQLite as the database provider.
- **Entity Models**: Includes `Person` and `Department` entities with a many-to-many relationship.
- **Database Operations**: Creates, reads, and displays data from an SQLite database.
- **Data Validation**: Shows how to add constraints and validations in EF Core models.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later

## Getting Started

1. **Clone the repository**:
   ```bash
   git clone https://github.com/AceCJM/EfCore-SQLiteDemo
   cd SQLiteDemo
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

The application will:
- Create an SQLite database file (`dbPeople.db`) in the project directory.
- Populate it with sample departments and people.
- Display the data grouped by departments.

## Project Structure

- `AppDbContext.cs`: Defines the EF Core DbContext and database configuration.
- `Person.cs`: Entity model for Person with properties like Name, Age, Mark, and navigational properties.
- `Department.cs`: Entity model for Department with Code, DepartmentName, and navigational properties.
- `Program.cs`: Main entry point that demonstrates database operations.

## Key Concepts Demonstrated

- Configuring EF Core with SQLite
- Defining entity relationships (many-to-many between Person and Department)
- Using navigational properties
- Database migrations and seeding
- Querying with LINQ and eager loading (`Include`)
- Displaying related data

## Dependencies

- Microsoft.EntityFrameworkCore (10.0.3)
- Microsoft.EntityFrameworkCore.Sqlite (10.0.3)
- Microsoft.EntityFrameworkCore.Tools (10.0.3)

## License

This project is for educational purposes. Feel free to modify and use it for learning EF Core and SQLite.