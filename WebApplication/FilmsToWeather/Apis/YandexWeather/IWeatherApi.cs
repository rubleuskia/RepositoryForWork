﻿using System.Threading.Tasks;
using DatabaseAccess.Entities;
using FilmsToWeather.Apis.YandexWeather.Entities;
using FilmsToWeather.Common.Entities;

namespace FilmsToWeather.Apis.YandexWeather
{
    public interface IWeatherApi
    {
        Task<WeatherCityInfo> GetWeather(string _lat, string _lon);
    }
}
