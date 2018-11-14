using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class WeatherData
    {
        private CurrentConditionDisplay _currentConditionDisplay;
        private StatisticsDisplay _statisticsDisplay;
        private ForecastDisplay _forecastDisplay;

        private float GetTemperature()
        {
            return 1;
        }

        private float GetHumidity()
        {
            return 1;
        }

        private float GetPressure()
        {
            return 1;
        }

        public void MeasurementsChanged()
        {
            var temperature = GetTemperature();
            var humidity = GetHumidity();
            var pressure = GetPressure();

            _currentConditionDisplay.Update(temperature, humidity, pressure);
            _statisticsDisplay.Update(temperature, humidity, pressure);
            _forecastDisplay.Update(temperature, humidity, pressure);
        }
    }

    public class CurrentConditionDisplay
    {
        public void Update(float temperature, float humidity, float pressure)
        {

        }
    }

    public class StatisticsDisplay
    {
        public void Update(float temperature, float humidity, float pressure)
        {


        }
    }

    public class ForecastDisplay
    {
        public void Update(float temperature, float humidity, float pressure)
        {


        }
    }
}
