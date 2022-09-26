using MauiBugz.Views;
using System.Diagnostics;
using System.Windows.Input;

namespace MauiBugz.ViewModels
{
    public class Issue10294ViewModel : ViewModelBase, IQueryAttributable
    {
        private int depth;

        public Issue10294ViewModel()
        {
            this.BackCommand = new Command(this.OnBackPressed);

            this.ForwardCommand = new Command(this.OnForwardPressed);

            this.Depth = 0;
        }

        public int Depth
        {
            get
            {
                return depth;
            }
            private set
            {
                this.SetProperty( ref this.depth, value );

                this.Title = $"Depth is {this.Depth}";
            }
        }

        public ICommand BackCommand { get; }

        public ICommand ForwardCommand { get; }

        private async void OnBackPressed()
        {
            await Shell.Current.GoToAsync("..",
                new Dictionary<string, object>
                {
                    { nameof(Issue10294ViewModel.BackCommand), $"Back Depth {this.Depth}" }
                });
        }

        private async void OnForwardPressed()
        {
            await Shell.Current.GoToAsync(
                nameof(Issue10294View),
                new Dictionary<string, object>
                {
                    { nameof(Issue10294ViewModel.Depth), this.Depth + 1 },
                });
        }

        #region Implementation of IQueryAttributable

        /// <inheritdoc />
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            try
            {
                if (query.TryGetValue(nameof(Issue10294ViewModel.Depth), out object val))
                {
                    this.Depth = (int)val;
                }

                foreach (KeyValuePair<string, object> keyValuePair in query)
                {
                    Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}");
                }

                /// WORKAROUND is to clear the query object.
                ///Comment out to clear. 
                //query.Clear();
            }
            catch (Exception e)
            {
                /// Should we push up some "error" view just in case?
                Debugger.Break();
            }
        }

        #endregion
    }
}
