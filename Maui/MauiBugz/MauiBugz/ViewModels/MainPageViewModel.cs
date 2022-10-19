using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBugz.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IEnumerable<Issue> _issues = 
            new ObservableCollection<Issue>()
            {
                new Issue() { Name = "Issue 10792" }
            };

        public MainPageViewModel()
        {
            this.BugCommand = new Command(this.OnBugPressed);
        }

        public ICommand BugCommand { get; }

        public IEnumerable<Issue> Issues
        {
            get { return this._issues; }
        }

        private async void OnBugPressed( object nameOfView )
        {
            await Shell.Current.GoToAsync( $"{nameOfView}View" );
        }
    }

    public class Issue
    {
        public string Name { get; init; }
    }
}
