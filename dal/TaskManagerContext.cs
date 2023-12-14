using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Linq;
using Task = models.Task;

namespace dal
{
    public class TaskManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure SQLite database
            optionsBuilder.UseSqlite("Data Source=TaskManager.db");

            // Ensure the database is created
            optionsBuilder.UseSqlite("Data Source=TaskManager.db")
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine);

        }

        public void SeedData()
        {
            using (var context = new TaskManagerContext())
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Check if data already exists
                if (!context.Users.Any() && !context.Tasks.Any())
                {
                    // Seed users
                    context.Users.AddRange(
                        new User { Id = 1, Username = "user1", Password = "password1" },
                        new User { Id = 2, Username = "user2", Password = "password2" },
                        new User { Id = 3, Username = "user3", Password = "password3" },
                        new User { Id = 4, Username = "user4", Password = "password4" }
                    );

                   

                    // Seed tasks
                    context.Tasks.AddRange(
                        new Task { Id = 1, Name = "Task 1", Description = "Description for Task 1", State="open", CreatedAt = DateTime.Now.AddHours(-1), Deadline = DateTime.Now.AddHours(1), UserId = 1 },
                        new Task { Id = 2, Name = "Task 2", Description = "Description for Task 2", State = "open", CreatedAt = DateTime.Now.AddHours(-2), Deadline = DateTime.Now.AddHours(2), UserId = 2 }
                        // ... add other tasks ...
                    );

                    // Save changes to the database
                    context.SaveChanges();

                    Console.WriteLine("Data seeding completed successfully.");
                }
                else
                {
                    Console.WriteLine("Data already exists. No need to seed.");
                }
            }
        }
    }
}
