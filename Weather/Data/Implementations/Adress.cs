using System;
using Weather.Data.Interfaces;

namespace Weather.Data.Implementations
{
    public class Adress : IAdress
    {
        private string apiKey;
        public Adress(string apiKey)
        {
            this.apiKey = apiKey;
        }
        public string Now(string city, string country)
        {
            if (String.IsNullOrEmpty(country))
                return $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&lang=ru&appid={apiKey}";
            else
                return $"https://api.openweathermap.org/data/2.5/weather?q={city},{country}&units=metric&lang=ru&appid={apiKey}";
        }
        public string FewDays(string city, string country)
        {
            if (String.IsNullOrEmpty(country))
                return $"https://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&lang=ru&appid={apiKey}";
            else
                return $"https://api.openweathermap.org/data/2.5/forecast?q={city},{country}&units=metric&lang=ru&appid={apiKey}";
        }
    }
}
