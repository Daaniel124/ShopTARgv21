﻿using ShopTARgv21.Core.Dto.Weather;

namespace Shop.Models.WeatherForecast
{
    public class CityViewModel
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public object PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }

        public double TempMetricValue { get; set; }
        public string TempMetricUnit { get; set; }
        public int TempMetricUnitType { get; set; }

        public double TempImperialValue { get; set; }
        public string TempImperialUnit { get; set; }
        public int TempImperialUnitType { get; set; }
    }
}
