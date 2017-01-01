namespace WpfAttachedProperty
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;

public class ThresholdRuleConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        //define base colors
        SolidColorBrush invalidBrush = new SolidColorBrush(Colors.Red);
        SolidColorBrush equalBrush = new SolidColorBrush(Colors.Yellow);
        SolidColorBrush validBrush = new SolidColorBrush(Colors.Green);

        if (parameter != null)
        {
            string[] definedColors = parameter.ToString().Split(',');
            BrushConverter converter = new BrushConverter();
            if (definedColors.Length > 0)
            {
                invalidBrush = converter.ConvertFromString(definedColors[0]) as SolidColorBrush;
                if (definedColors.Length > 1)
                    equalBrush = converter.ConvertFromString(definedColors[1]) as SolidColorBrush;
                if (definedColors.Length > 2)
                    validBrush = converter.ConvertFromString(definedColors[2]) as SolidColorBrush;
            }
        }
        if (values.Length < 3)
            return invalidBrush;

        try
        {
            if (values[0] != DependencyProperty.UnsetValue && values[1] != DependencyProperty.UnsetValue
                && values[2] != DependencyProperty.UnsetValue)
            {
                int oldValue = System.Convert.ToInt32(values[0]);
                int thresholdValue = System.Convert.ToInt32(values[1]);
                int newValue = System.Convert.ToInt32(values[2]);

                if (newValue > oldValue && (newValue - oldValue) <= thresholdValue)
                    return validBrush;
                else if (newValue == oldValue)
                    return equalBrush;
                else
                    return invalidBrush;
            }
            return invalidBrush;
        }
        catch (Exception)
        {
            return invalidBrush;
        }
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
}
