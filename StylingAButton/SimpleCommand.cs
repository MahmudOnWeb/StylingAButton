using System;
using System.Windows.Input;

namespace StylingAButton
{
    public class SimpleCommand : ICommand
    {
        private readonly Action<object> e;
        private readonly Func<object, bool> ce;

        public SimpleCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute", "Action argument cannot be null");
            }

            e = execute;
            ce = canExecute;
        }

        public SimpleCommand(Action<object> execute) : this(execute, null) { }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (ce == null)
            {
                return true;
            }

            return ce(parameter);
        }

        public void Execute(object parameter)
        {
            e(parameter);
        }
    }
}