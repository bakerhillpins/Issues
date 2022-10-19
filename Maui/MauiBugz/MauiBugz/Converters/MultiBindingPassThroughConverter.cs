using System.Globalization;

namespace MauiBugz.Converters
{
    public class MultiBindingPassThroughConverter : IMultiValueConverter
    {
        public static readonly IMultiValueConverter Instance =
            new Lazy<MultiBindingPassThroughConverter>( () => new MultiBindingPassThroughConverter() ).Value;

#region Implementation of IMultiValueConverter

        /// <inheritdoc />
        public object Convert( object[] values, Type targetType, object parameter, CultureInfo culture )
        {
            // strip all NULLs from values list.
            var noNullValues = values.Where( o => o != null ).ToArray();

            // <see cref="https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/multibinding#define-a-imultivalueconverter"/>
            // If empty DoNothing (fallBack value).
            // If one value then return just that value.
            // If multiple values then Join all the strings into one.
            return noNullValues.Length == 0 ?
                BindableProperty.UnsetValue :
                noNullValues.Length == 1 ?
                    values[ 0 ] : string.Join( " and ", noNullValues );
        }

        /// <inheritdoc />
        public object[] ConvertBack( object value, Type[] targetTypes, object parameter, CultureInfo culture )
        {
            throw new NotSupportedException( $"{nameof(MultiBindingPassThroughConverter)}.{nameof(this.ConvertBack)}" );
        }

#endregion
    }
}
