using System.Globalization;
using MauiBugz.Models;

namespace MauiBugz.Converters
{
    public class CountingConverter : IValueConverter
    {
        public static IValueConverter Instance
        {
            get
            {
                // Create a new each time so they count independently. 
                return new CountingConverter();
            }
        }

        private int _count = 0;

#region Implementation of IValueConverter

        /// <inheritdoc />
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            this._count++;

            Console.WriteLine( $"{parameter as string} converter has been executed {this._count} times. Value: {value ?? "null"}");

            return new ConvertedData( value as Data);
        }

        /// <inheritdoc />
        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotSupportedException( $"{nameof(CountingConverter)}.{nameof(this.ConvertBack)}" );
        }

#endregion
    }
}
