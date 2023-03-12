using ShopTARgv21.Core.Dto.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.Dto.OpenWeather
{
    public class OpenWeatherResponseDto
    {

    }
    public class Cur
    {
        public List<Root> Roots { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("current")]
        public Current current { get; set; }
    }

    public class Current
    {
        [JsonPropertyName("Root.Current.temp")]
        public double temp { get; set; }

        [JsonPropertyName("Root.Current.feels_like")]
        public double feels_like { get; set; }

        [JsonPropertyName("Root.Current.pressure")]
        public int pressure { get; set; }

        [JsonPropertyName("Root.Current.humidity")]
        public int humidity { get; set; }

        [JsonPropertyName("Root.Current.weather")]
        public List<Weather> weather { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("Root.Current.Weather.main")]
        public string main { get; set; }
    }
}
