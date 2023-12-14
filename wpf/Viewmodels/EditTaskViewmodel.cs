using dal;
using models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace wpf.Viewmodels
{
    public class EditTaskViewmodel : BaseViewmodel
    {
        private Task _task;

        // Replace YourComboBoxItems with your actual collection of ComboBox items
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
                        // Handle the case when the selectedState is not in ComboBox items
                        Console.WriteLine($"Invalid selected state: {selectedState}");
                    }
                }

                NotifyPropertyChanged();
            }
        }

        public EditTaskViewmodel(Task selectedTask)
        {
            Task = selectedTask;

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
