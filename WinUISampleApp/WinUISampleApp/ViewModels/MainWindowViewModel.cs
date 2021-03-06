using WinUISampleApp.Models;

namespace WinUISampleApp.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private Counter _counter = new(0);

        public MainWindowViewModel()
        {
            IncrementCommand = new ActionCommand(Increment);
            DecrementCommand = new ActionCommand(Decrement, CanDecrement);
        }

        public ActionCommand IncrementCommand { get; set; }

        public ActionCommand DecrementCommand { get; set; }

        public int Count
        {
            get => _counter.Count;
            set
            {
                if (_counter.Count == value) return;
                var oldValue = _counter.Count;
                SetProperty(ref _counter, new Counter(value));
                if (oldValue == 0 || value == 0) DecrementCommand.RaiseCanExecuteChanged();
            }
        }

        public void Increment(object _) => ++Count;

        public void Decrement(object _) => --Count;

        public bool CanDecrement(object _) => Count > 0;
    }
}
