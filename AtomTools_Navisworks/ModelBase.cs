using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AtomTools_Navisworks
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged == null)
                return;
            propertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class RelayCommandWithoutParameter : ICommand
    {
        private readonly Action _execute;
        private readonly Func<object, bool> _canExecute;
        public string CommandName { get; }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public RelayCommandWithoutParameter(Action execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public RelayCommandWithoutParameter(Action execute,string commandName,Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            CommandName = commandName;
        }
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object parameter) => _execute();
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<object, bool> _canExecute;
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public RelayCommand(Action<T> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => _canExecute == null || this._canExecute(parameter);
        public void Execute(object parameter) => _execute((T) parameter);
    }








    //public class RelayCommand : ICommand
    //{
    //    readonly Action<object> _execute;
    //    readonly Predicate<object> _canExecute;

    //    public bool CanExecute(object parameter)
    //    {
    //        return _canExecute == null ? true : _canExecute(parameter);
    //    }

    //    public void Execute(object parameter)
    //    {
    //        _execute(parameter);
    //    }

    //    public event EventHandler CanExecuteChanged
    //    {

    //        add => CommandManager.RequerySuggested += value;
    //        remove => CommandManager.RequerySuggested -= value;
    //    }
    //    public RelayCommand(Action<object> execute)
    //        : this(execute, null)
    //    {

    //    }

    //    private RelayCommand([CanBeNull] Action<object> execute, Predicate<object> canExecute)
    //    {
    //        if (execute == null)
    //        {
    //            throw new System.ArgumentNullException("execute//выполнить");
    //        }

    //        _execute = execute;
    //        _canExecute = canExecute;
    //    }

    //}
}
