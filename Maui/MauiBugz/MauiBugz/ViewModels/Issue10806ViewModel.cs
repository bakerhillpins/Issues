using System.Diagnostics;
using MauiBugz.Models;

namespace MauiBugz.ViewModels
{
    public class Issue10806ViewModel : ViewModelBase, IQueryAttributable
    {
        private static char _next = 'A';
        private object _data;

        public static char NextChar
        {
            get { return _next++; }
        }

        public Issue10806ViewModel()
        {
        }
        
#region Implementation of IQueryAttributable

        /// <inheritdoc />
        public void ApplyQueryAttributes( IDictionary<string, object> query )
        {
        }

#endregion

        public object Property
        {
            get
            {
                Debug.WriteLine( $"{this} Get Property" );

                return this._data ??= new Data( Issue10806ViewModel.NextChar );
            }
        }

#region Overrides of Object

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(Issue10806ViewModel)}";
        }

#endregion
    }
}
