using System;
using System.Windows.Input;

#nullable enable
namespace WinUISampleApp.ViewModels
{
    public class ActionCommand : ICommand
    {
        private readonly Action<object?> _action;
        private readonly Predicate<object?>? _canExecute;

        public ActionCommand(Action<object?> action, Predicate<object?>? canExecute = null)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object? parameter) => _action(parameter);

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
