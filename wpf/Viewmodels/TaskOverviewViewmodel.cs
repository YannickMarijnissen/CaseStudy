using dal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpf.Views;
using DatabaseOperation = dal.DatabaseOperation;
using Task = models.Task;

namespace wpf.Viewmodels
{

    public class TaskOverviewViewmodel : BaseViewmodel
    {
        private string _zoekfilter = "";
        public string Zoekfilter { get { return _zoekfilter; } set { _zoekfilter = value; NotifyPropertyChanged(); } }
        private string _foutmelding;
        public string Foutmelding { get { return _foutmelding; } set { _foutmelding = value; NotifyPropertyChanged(); } }
        private ObservableCollection<Task> _tasks;
        private Task _geselecteerdeTask;
        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; NotifyPropertyChanged(); }
        }
        public Task GeselecteerdeTask
        {
            get { return _geselecteerdeTask; }
            set
            {
                _geselecteerdeTask = value;
                NotifyPropertyChanged();

            }
        }
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; NotifyPropertyChanged(); }
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenNewTaskWindow":
                case "Zoeken":
                    return true; // Always enable "New Task" command

                case "OpenEditTaskWindow":
                case "DeleteTask":
                case "OpenDetailTaskWindow":
                    return GeselecteerdeTask != null;
            }

            return false;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenNewTaskWindow": OpenNewTaskWindow(); break;
                case "OpenEditTaskWindow": OpenEditTaskWindow(); break;
                case "OpenDetailTaskWindow": OpenDetailTaskWindow(); break;
                case "Zoeken": Zoeken(); break;
                case "DeleteTask": DeleteTask(); break;
            }

        }
        private void OpenNewTaskWindow()
        {
            var vm = new NewTaskViewmodel(UserId);
            var view = new NewTaskView();
            view.DataContext = vm;
            view.Show();
        }
     
        private void OpenEditTaskWindow()
        {
            var vm = new EditTaskViewmodel(GeselecteerdeTask);
            var view = new EditTaskView();
            view.DataContext = vm;
            view.Show();
        }
        private void DeleteTask()
        {
            if (GeselecteerdeTask != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this task?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    var dbOperation = new DatabaseOperation();
                    dbOperation.RemoveTask(GeselecteerdeTask);

                    // Refresh the task list after deletion
                    List<Task> LijstTaken = dbOperation.GetTasksForUser(UserId);
                    Tasks = new ObservableCollection<Task>(LijstTaken);
                }
            }
            else
            {
                MessageBox.Show("Please select a task to delete.", "No Task Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void OpenDetailTaskWindow()
        {
            var vm = new TaskDetailViewmodel(GeselecteerdeTask.Id);
            var view = new TaskDetailsView();
            view.DataContext = vm;
            view.Show();
        }
        public TaskOverviewViewmodel(int userId)
        {
            UserId = userId;
           
         
            LoadTasks();
        }

        public void LoadTasks()
        {
            var dbOperation = new DatabaseOperation();

            // Get tasks for the logged-in user
            List<Task> LijstTaken = dbOperation.GetTasksForUser(UserId);

            Tasks = new ObservableCollection<Task>(LijstTaken);
        }
        private void Zoeken()
        {
            // Clear previous error message
            Foutmelding = "";

            if (string.IsNullOrWhiteSpace(Zoekfilter))
            {
                Foutmelding += "Please enter a filter!";
            }

            if (string.IsNullOrWhiteSpace(Foutmelding))
            {
                List<Task> lijstTasks = DatabaseOperation.ReturnTaskByName(Zoekfilter);
                Tasks = new ObservableCollection<Task>(lijstTasks);
            }
            else
            {
                // If there's an error, reset Tasks to the original list
                LoadTasks();
            }
        }


        public override string this[string columnName]
        {
            get
            {

                return "";
            }
        }
    }
}
