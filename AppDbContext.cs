using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace SQLiteDemo
{
    public class AppDbContext : DbContext
    {
        // Declare a property which will represent our collection from the persisted datastore
        public DbSet<Person> People { get; set; }
        public DbSet<Department> Departments { get; set; }

        // Configures EF Core Sqlite to use/put the file in the same directory as the .cs files
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Gets relative path for dbPeople.db
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../dbPeople.db");

            // Gets the full path for dbPeople.db (eg. /home/$USER/Documents/code/SQLiteDemo/dbPeople.db)
            dbPath = Path.GetFullPath(dbPath);

            // Tell SQLite to use this file
            options.UseSqlite($"Data Source={dbPath}");
        }

        // Describe to the application how to declare the tables in the SQLite database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.Mark).IsRequired();

                // You can add validation to you properties within the modeling as well as your validation in your entity class.
                entity.ToTable(v => v.HasCheckConstraint("CK_Person_Age_Between_0_120", "[Age] >= 0 and [Age] <= 120"));
                entity.ToTable(v => v.HasCheckConstraint("CK_Person_Mark_Between_0_100", "[Mark] >= 0 and [Mark] <= 100"));
            });
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Code).IsUnique();
                entity.Property(e => e.DepartmentName).IsRequired();

                // HasMany means each Department in the Departments table can have reference multiple Person classes
                entity.HasMany(e => e.People);
            }
            );
        }
    }
}