using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Задание_Wpf6
{
    enum Precipitation
    {
        sun = 0,
        clouds = 1,
        rain = 2,
        snow = 3
    }
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string windDirection;
        private int windSpeed;
        private Precipitation precipitation;
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public WeatherControl(string windDirection, int windSpeed, Precipitation precipitation)
        {
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
            this.precipitation = precipitation;
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }
        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }
        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return "Error";
        }
    }
}
