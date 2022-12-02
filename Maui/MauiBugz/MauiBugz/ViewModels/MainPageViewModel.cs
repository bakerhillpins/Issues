using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiBugz.Models;

namespace MauiBugz.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public static readonly IList<Issue> IssuesCollection = 
            new ObservableCollection<Issue>()
            {
            };

        public MainPageViewModel()
        {
            this.BugCommand = new Command(this.OnBugPressed);
        }

        public ICommand BugCommand { get; }

        public IEnumerable<Issue> Issues
        {
            get { return IssuesCollection; }
        }

        private async void OnBugPressed( object nameOfView )
        {
            await Shell.Current.GoToAsync( $"{nameOfView}View" );
        }
    }
}
