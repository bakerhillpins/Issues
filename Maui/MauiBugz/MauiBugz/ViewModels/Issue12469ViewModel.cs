using System.Collections.ObjectModel;
using MauiBugz.Models;

namespace MauiBugz.ViewModels
{
    public class Issue12469ViewModel :  ViewModelBase
    {
        const int RefreshDuration = 2;

        int _itemNumber = 1;
        readonly Random _random;
        bool _isRefreshing;

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
        }

        public ObservableCollection<RefreshItem> Items { get; private set; }

        public Command RefreshCommand => new Command(async () => await RefreshItemsAsync(), () => !IsRefreshing);

        public Issue12469ViewModel()
        {
            _random = new Random();
            Items = new ObservableCollection<RefreshItem>();
            AddItems();
        }

        void AddItems()
        {
            for (int i = 0; i < 2; i++)
            {
                Items.Add(new RefreshItem
                          {
                              Color = Color.FromRgb(_random.NextDouble(), _random.NextDouble(), _random.NextDouble()),
                              Name = $"Item {_itemNumber++}"
                          });
            }
        }

        async Task RefreshItemsAsync()
        {
            _isRefreshing = true;
            this.OnPropertyChanged(nameof(IsRefreshing));
            this.OnPropertyChanged(nameof(RefreshText));
            RefreshCommand.ChangeCanExecute();
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            AddItems();
            _isRefreshing = false;
            this.OnPropertyChanged(nameof(IsRefreshing));
            this.OnPropertyChanged(nameof(RefreshText));
            RefreshCommand.ChangeCanExecute();
        }

        public string RefreshText => $"Is Refreshing: {IsRefreshing}";

    }
}
