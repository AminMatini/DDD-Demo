using System;
using System.Windows.Input;

namespace DDD.UI.Common
{
    public class Command<T> : ICommand
    {
        #region Constructor

        public Command(Action<T> execute) : this(_ => true, execute) { }

        public Command(Func<T, bool> canExecute, Action<T> execute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region Properties

        private readonly Func<T, bool> canExecute;

        private readonly Action<T> execute;

        #endregion

        #region Method

        public bool CanExecute(object? parameter)
        {
            if (parameter == null && typeof(T).IsValueType) return false;

            return canExecute((T)parameter); 
        }

        public void Execute(object? parameter)
        {
            execute((T)parameter);
        }

        #endregion

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }        
    }

    public class Command : Command<object>
    {
        public Command(Func<bool> canExcecute , Action execute) : 
            base(canExecute : _ => canExcecute() , execute: _ => execute() ){}

        public Command(Action execute) : this(() => true , execute){}
    }
}


