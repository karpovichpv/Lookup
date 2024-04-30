// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using System;
using System.Windows.Input;

namespace Lookup.Commands
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExectute)
        {
            _execute = execute;
            _canExecute = canExectute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            bool b = _canExecute == null ? true : _canExecute(parameter);

            return b;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

    }
}
