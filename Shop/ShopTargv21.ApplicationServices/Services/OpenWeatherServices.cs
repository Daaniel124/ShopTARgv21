using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Nancy.Json;
using ShopTARgv21.Core.Dto.OpenWeather;
using ShopTARgv21.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        public async Task<OpenWeatherResultDto> WeatherDetail(OpenWeatherResultDto dto)
        {
            string apiKey = "5d37d58ab198b65f22dcaefe480181f0";
            var url2 = $"https://api.openweathermap.org/data/3.0/onecall?lat=59.4372155&lon=24.7453688&exclude=hourly,minutely,daily&units=metric&appid={apiKey}";
            var url = $"https://api.openweathermap.org/data/3.0/onecall?lat=59.4372155&lon=24.7453688&exclude=hourly,minutely,daily&units=metric&appid=5d37d58ab198b65f22dcaefe480181f0";

            using (WebClient client = new WebClient())
            {

                string json = client.DownloadString(url);
                //ainult ühe classi saab deserialiseerida korraga 
                Root weatherInfo = (new JavaScriptSerializer()).Deserialize<Root>(json);

                dto.temp = weatherInfo.current.temp;
                dto.feels_like = weatherInfo.current.feels_like;
                dto.pressure = weatherInfo.current.pressure;
                dto.humidity = weatherInfo.current.humidity;

                dto.main = weatherInfo.current.weather[0].main;


                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }

            return dto;
        }
    }
}
