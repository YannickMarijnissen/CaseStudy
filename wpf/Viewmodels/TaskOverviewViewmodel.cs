using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf.Views;

namespace wpf.Viewmodels
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Deadline { get; set; }
    }
    public class TaskOverviewViewmodel : BaseViewmodel
    {
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
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenNewTaskWindow":
                case "OpenCalendarWindow":
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
                case "OpenNewTaskWindow":OpenNewTaskWindow(); break;
                case "OpenEditTaskWindow": OpenEditTaskWindow(); break;
                case "OpenDetailTaskWindow": OpenDetailTaskWindow(); break;
                case "OpenCalendarWindow": OpenCalendarWindow(); break;
                case "DeleteTask": DeleteTask(); break;
            }
            
        }
        private void OpenNewTaskWindow()
        {
            var vm = new NewTaskViewmodel();
            var view = new NewTaskView();
            view.DataContext = vm;
            view.Show();
        }
        private void OpenCalendarWindow()
        {
            var vm = new CalendarViewmodel();
            var view = new CalendarView();
            view.DataContext = vm;
            view.Show();
        }
        private void OpenEditTaskWindow()
        {
            var vm = new EditTaskViewmodel();
            var view = new EditTaskView();
            view.DataContext = vm;
            view.Show();
        }
        private void DeleteTask()
        {
            
        }
        private void OpenDetailTaskWindow()
        {
            var vm = new TaskDetailViewmodel();
            var view = new TaskDetailsView();
            view.DataContext = vm;
            view.Show();
        }
        public TaskOverviewViewmodel()
        {
            Tasks = GenerateDummyTasks();
        }
        private ObservableCollection<Task> GenerateDummyTasks()
        {
            var tasks = new ObservableCollection<Task>();

            // Generate some dummy tasks
            for (int i = 1; i <= 10; i++)
            {
                tasks.Add(new Task
                {
                    Id = i,
                    Name = $"Task {i}",
                    Description = $"Description for Task {i}",
                    State = i % 2 == 0 ? "open" : "in-Progress",
                    CreatedAt = DateTime.Now.AddHours(-i),
                    Deadline = DateTime.Now.AddHours(i) // Set a deadline for the tasks
                });
            }

            return tasks;
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
