
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpf.Viewmodels
{
    public class NewTaskViewmodel : BaseViewmodel
    {
       
        public NewTaskViewmodel()
        {
        }

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
               

                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
            }
        }
       
    }
    }
