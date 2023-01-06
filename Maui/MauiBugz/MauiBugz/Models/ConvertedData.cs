using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBugz.ViewModels;

namespace MauiBugz.Models
{
    public class ConvertedData
    {
        private readonly char _id;
        private object _data;

        public ConvertedData(Data data)
        {
            _id = data.Id;
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
            return $"{nameof(ConvertedData)}_{_id}";
        }

        #endregion
    }
}
