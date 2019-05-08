using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ItemDB.Presentation.Commands
{
    public class SimpleCommand<TPredicateObj,TActionObj> : ICommand
    {
        public Predicate<TPredicateObj> CanExecutePredicate { get; set; }
        public Action<TActionObj> Action { get; set; }


        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return CanExecutePredicate?.Invoke((TPredicateObj)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            Action((TActionObj)parameter);
        }
    }
    public class SimpleCommand<TObj> : ICommand
    {
        public Predicate<TObj> CanExecutePredicate { get; set; }
        public Action<TObj> Action { get; set; }


        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return CanExecutePredicate?.Invoke((TObj)parameter)??true;
        }

        public void Execute(object parameter)
        {
            Action((TObj)parameter);
        }
    }
    public class SimpleCommand : ICommand
    {
        public Func<bool> CanExecuteFunc { get; set; }
        public Action Action { get; set; }


        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            Action();
        }
    }
    public class SimplerCommand<TObj> : ICommand
    {
        public Action<TObj> Action { get; set; }

#pragma warning disable
        public event EventHandler CanExecuteChanged;
#pragma warning enable
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action((TObj)parameter);
        }
    }
    public class SimplerCommand : ICommand
    {
        public Action Action { get; set; }

        #pragma warning disable
        public event EventHandler CanExecuteChanged;
        #pragma warning enable
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action();
        }
    }
}
