using System;
using System.Windows;
using models;
using dal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using DatabaseOperation = dal.DatabaseOperation;
using Task = models.Task;
using System.Threading.Tasks;
using System.Linq;

namespace wpf.Viewmodels
{
    public class TaskDetailViewmodel : BaseViewmodel
    {
      
        public Task Task { get; set; }

       

      

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
               
                case "BackToOverview":
                    return true;
                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "BackToOverview": CloseWindow(); break;
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




        public TaskDetailViewmodel(int id)
        {
            Task = DatabaseOperation.ReturnTaskById(id).SingleOrDefault();
        }
    }
}
