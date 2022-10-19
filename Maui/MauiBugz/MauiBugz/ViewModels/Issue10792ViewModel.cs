using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBugz.ViewModels
{
    public class Issue10792ViewModel : ViewModelBase, IQueryAttributable
    {
        private readonly string _property1;
        private readonly string _property2;

        public Issue10792ViewModel()
        {
            this._property1 = nameof(this.Property1);

            this._property2 = nameof(this.Property2);
        }

#region Implementation of IQueryAttributable

        /// <inheritdoc />
        public void ApplyQueryAttributes( IDictionary<string, object> query )
        {
        }

#endregion

        public string Property1
        {
            get
            {
                Console.WriteLine( $"{nameof(this.Property1)} Get Accessor" );
                return this._property1;
            }
        }

        public string Property2
        {
            get
            {
                Console.WriteLine( $"{nameof(this.Property2)} Get Accessor" );
                return this._property2;
            }
        }
    }
}
