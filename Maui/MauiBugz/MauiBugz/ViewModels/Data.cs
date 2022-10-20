using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBugz.ViewModels
{
    public class Data
    {
        private readonly char _id;
        private object _data;

        public Data( char id )
        {
            this._id = id;
        }

        public char Id
        {
            get { return this._id; }
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
            return $"{nameof(Data)}_{this._id}";
        }

#endregion
    }
}
