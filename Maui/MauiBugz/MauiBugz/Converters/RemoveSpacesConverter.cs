using System.Globalization;

namespace MauiBugz.Converters
{
    public class RemoveSpacesConverter : IValueConverter
    {
        public static readonly IValueConverter Instance =
            new Lazy<RemoveSpacesConverter>( () => new RemoveSpacesConverter() ).Value;

#region Implementation of IValueConverter

        /// <inheritdoc />
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            return value is string str ? str.Replace( " ", string.Empty ) : null;
        }

        /// <inheritdoc />
        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotSupportedException( $"{nameof(RemoveSpacesConverter)}.{nameof(this.ConvertBack)}" );
        }

#endregion
    }
}
