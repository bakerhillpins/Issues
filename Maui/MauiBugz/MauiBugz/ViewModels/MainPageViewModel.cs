using System.Windows.Input;

namespace MauiBugz.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            this.BugCommand = new Command(this.OnBugPressed);
        }

        public ICommand BugCommand { get; }

        private async void OnBugPressed( object nameOfView )
        {
            await Shell.Current.GoToAsync( $"{nameOfView}View" );
        }
    }
}
