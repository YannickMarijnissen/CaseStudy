using dal;
using models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace wpf.Viewmodels
{
    public class EditTaskViewmodel : BaseViewmodel
    {
        private Task _task;

        private ObservableCollection<string> _comboBoxItems = new ObservableCollection<string>
        {
            "Open",
            "In-Progress",
            "Postponed",
            "Finished"
        };

        public ObservableCollection<string> ComboBoxItems
        {
            get { return _comboBoxItems; }
            set
            {
                _comboBoxItems = value;
                NotifyPropertyChanged();
            }
        }
        private DateTime _deadline;

        public DateTime Deadline
        {
            get { return _deadline; }
            set { _deadline = value; NotifyPropertyChanged(); }
        }
        public Task Task
        {
            get { return _task; }
            set
            {
                _task = value;

                // Ensure that Task.State is a valid value in the ComboBox
                if (Task != null && Task.State is string selectedState)
                {
                    // Check if the selectedState exists in the ComboBox items
                    if (ComboBoxItems.Contains(selectedState))
                    {
                        Task.State = selectedState;
                    }
                    else
                    {
                        // If the selectedState is not in ComboBox items, add it
                        ComboBoxItems.Add(selectedState);

                        // Optionally, sort the ComboBox items
                        ComboBoxItems = new ObservableCollection<string>(ComboBoxItems.OrderBy(item => item));

                        // Notify that ComboBoxItems has changed
                        NotifyPropertyChanged(nameof(ComboBoxItems));
                    }
                }

                NotifyPropertyChanged();
            }
        }

        public EditTaskViewmodel(Task selectedTask)
        {
            Task = selectedTask;
            Deadline = new DateTime(Deadline.Year, Deadline.Month, Deadline.Day, 0, 0, 0, DateTimeKind.Local);
            // Debugging line to check the updated value of Task.State
            Console.WriteLine($"Task.State after adjustment: {Task.State}");
        }

        public override string this[string columnName]
        {
            get
            {
                // Add your validation logic if needed
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TaskAanpassen":
                    return Task != null; // Enable only when a task is selected

                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "TaskAanpassen": SaveTask(); break;
            }
        }

        private void SaveTask()
        {
            // Perform the logic to update the selected task
            if (Task != null)
            {
                var dbOperation = new DatabaseOperation();
                dbOperation.UpdateTask(Task);

                MessageBox.Show("Task updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Close the window or perform other actions as needed
                CloseWindow();
            }
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
    }
}
