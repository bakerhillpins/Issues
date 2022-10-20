using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBugz.ViewModels
{
    public class ConvertedData
    {
        private readonly char _id;
        private object _data;

        public ConvertedData( Data data )
        {
            this._id = data.Id;
        }

        public object Property
        {
            get
            {
                Console.WriteLine( $"{this} Get Property" );

                return this._data ??= new Data( Issue10806ViewModel.NextChar );
            }
        }

#region Overrides of Object

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(ConvertedData)}_{this._id}";
        }

#endregion
    }
}
