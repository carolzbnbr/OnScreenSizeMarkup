using System.Globalization;

namespace Samples.Converters;

public class OnPlatformToDoubleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var platform = DeviceInfo.Platform.ToString();

        if (value is OnPlatform<double> onPlatform)
        {
            var platformValue = onPlatform.Platforms.FirstOrDefault(p => p.Platform.Contains(platform));
            return platformValue?.Value ?? value;
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}