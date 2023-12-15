using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using Task = models.Task;

namespace dal
{
    public class DatabaseOperation
    {
        private readonly TaskManagerContext _context;

        public DatabaseOperation()
        {
            _context = new TaskManagerContext();
            _context.Database.EnsureCreated();
        }

        // Get all users from the database
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        // Get all tasks from the database
        public List<Task> GetAllTasks()
        {
            return _context.Tasks.Include(t => t.User).ToList();
        }
        public List<Task> GetTasksForUser(int userId)
        {

            // Assuming your Task model has a UserId property
            return _context.Tasks.Where(t => t.UserId == userId).ToList();

        }

        // Add a new user to the database
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Add a new task to the database
        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        // Update an existing task in the database
        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        // Remove a task from the database
        public void RemoveTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
        // ...

        public static List<Task> ReturnTaskById(int taskId)
        {
            using (TaskManagerContext ctx = new TaskManagerContext())
            {
                return ctx.Tasks
                    .Where(x => x.Id == taskId)
                    .ToList();
            }
        }
      

        public static List<Task> ReturnTaskByName(string name)
        {
            using (TaskManagerContext ctx = new TaskManagerContext())
            {
                return ctx.Tasks
                    .Where(x => x.Name.Contains(name))
                    .ToList();
            }
        }


    }
}
