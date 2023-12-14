using dal;
using models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task = models.Task;

namespace wpf.Viewmodels
{
    public class NewTaskViewmodel : BaseViewmodel
    {
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; NotifyPropertyChanged(); }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(); }
        }
        private string _stats;

        public string State
        {
            get { return _stats; }
            set { _stats = value; NotifyPropertyChanged(); }
        }
        private DateTime _deadline;

        public DateTime Deadline
        {
            get { return _deadline; }
            set { _deadline = value; NotifyPropertyChanged(); }
        }

        public NewTaskViewmodel(int userId)
        {
            UserId = userId;

            // Set the Deadline to the current date and time
            Deadline = DateTime.Now;

            // Reset the time part to midnight (irrelevant time)
            Deadline = new DateTime(Deadline.Year, Deadline.Month, Deadline.Day, 0, 0, 0, DateTimeKind.Local);
        }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrEmpty(Name))
                            return "Name is required.";
                        break;
                    case nameof(Description):
                        if (string.IsNullOrEmpty(Description))
                            return "Description is required.";
                        break;
                        // Add additional validation for other properties if needed
                }
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TaskToevoegen":
                    return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Description); // Enable only when Name and Description are not empty

                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TaskToevoegen": CreateTask(); break;
            }
        }

        private void CreateTask()
        {
            // Perform the logic to create a new task
            var newTask = new Task
            {
                Name = Name,
                Description = Description,
                Deadline = Deadline,
                UserId = UserId,
                CreatedAt = DateTime.Now,
                State = "open"
            };

            // Add the logic to save the new task to the database
            var dbOperation = new DatabaseOperation();
            dbOperation.AddTask(newTask);

            // Optionally, reset the input fields after creating the task
            Name = string.Empty;
            Description = string.Empty;
            Deadline = DateTime.Now;

            CloseWindow();
            ReloadTasks();

            MessageBox.Show("Task created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }

        private void ReloadTasks()
        {
           
        }



    }
}
