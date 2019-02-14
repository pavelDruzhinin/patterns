using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            var currentConditionDisplay = new CurrentConditionDisplay(weatherData);

            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.SetMeasurements(79, 53, 30.4f);
            weatherData.SetMeasurements(56, 23, 40.4f);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class WeatherData : ISubject
    {
        private List<IObserver> _observers;
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public WeatherData()
        {
            _observers = new List<IObserver>();
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            _observers.ForEach(el => el.Update(_temperature, _humidity, _pressure));
        }

        ///<summary>
        ///Тестовый метод для вызова наблюдателей
        ///</summary>
        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            MeasurementsChanged();
        }
    }

    public class CurrentConditionDisplay : IObserver, IDisplayElement
    {
        private ISubject _subject;
        private float _temperature;
        private float _humidity;

        public CurrentConditionDisplay(ISubject subject)
        {
            _subject = subject;
            _subject.RegisterObserver(this);
        }
        public void Display()
        {
            Console.WriteLine($"Current conditions: {_temperature}F degrees and {_humidity}% humidity");
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            Display();
        }
    }

    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        public void Display()
        {
            throw new NotImplementedException();
        }

        public void Update(float temperature, float humidity, float pressure)
        {


        }
    }

    public class ForecastDisplay : IObserver, IDisplayElement
    {
        public void Display()
        {
            throw new NotImplementedException();
        }

        public void Update(float temperature, float humidity, float pressure)
        {


        }
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();

    }

    public interface IObserver
    {
        void Update(float temperature, float humidity, float pressure);
    }

    public interface IDisplayElement
    {
        void Display();
    }
}
