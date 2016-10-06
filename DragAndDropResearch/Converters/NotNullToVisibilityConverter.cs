using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace DragAndDropResearch.Converters
{
    internal class NotNullToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public Visibility NullValue
        {
            get;
            set;
        } = Visibility.Collapsed;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? Visibility.Visible : NullValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
