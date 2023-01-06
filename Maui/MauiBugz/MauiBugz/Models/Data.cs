using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBugz.ViewModels;

namespace MauiBugz.Models
{
    public class Data
    {
        private readonly char _id;
        private object _data;

        public Data(char id)
        {
            _id = id;
        }

        public char Id
        {
            get { return _id; }
        }

        public object Property
        {
            get
            {
                Debug.WriteLine($"{this} Get Property");

                return _data ??= new Data(Issue10806ViewModel.NextChar);
            }
        }

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(Data)}_{_id}";
        }

        #endregion
    }
}
