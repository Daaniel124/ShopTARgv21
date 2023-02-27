using Nancy.Json;
using ShopTARgv21.Core.Dto.Weather;
using ShopTARgv21.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            string apiKey = "Q5vG25cIHxh5Gj9crebXpcavu5CG4ulM";
            var url2 = $"http://dataservice.accuweather.com/currentconditions/v1/127964?apikey={apiKey}&language=en-us&details=false";
            var url = $"http://dataservice.accuweather.com/currentconditions/v1/127964?apikey=Q5vG25cIHxh5Gj9crebXpcavu5CG4ulM&language=en-us&details=false";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                //ainult ühe classi saab deserialiseerida korraga 
                Root weatherInfo = (new JavaScriptSerializer()).Deserialize<Root>(json);

                dto.LocalObservationDateTime = weatherInfo.DailyForecasts[0].LocalObservationDateTime;
                dto.EpochTime = weatherInfo.DailyForecasts[0].EpochTime;
                dto.WeatherText = weatherInfo.DailyForecasts[0].WeatherText;
                dto.WeatherIcon = weatherInfo.DailyForecasts[0].WeatherIcon;
                dto.HasPrecipitation = weatherInfo.DailyForecasts[0].HasPrecipitation;
                dto.PrecipitationType = weatherInfo.DailyForecasts[0].PrecipitationType;
                dto.IsDayTime = weatherInfo.DailyForecasts[0].IsDayTime;
                //dto.Temperature = weatherInfo.DailyForecasts[0].Temperature;
                dto.MobileLink = weatherInfo.DailyForecasts[0].MobileLink;
                dto.Link = weatherInfo.DailyForecasts[0].Link;

                dto.TempMetricValue = weatherInfo.DailyForecasts[0].Temperature.Metric.Value;
                dto.TempMetricUnit = weatherInfo.DailyForecasts[0].Temperature.Metric.Unit;
                dto.TempMetricUnitType = weatherInfo.DailyForecasts[0].Temperature.Metric.UnitType;

                dto.TempImperialValue = weatherInfo.DailyForecasts[0].Temperature.Imperial.Value;
                dto.TempImperialUnit = weatherInfo.DailyForecasts[0].Temperature.Imperial.Unit;
                dto.TempImperialUnitType = weatherInfo.DailyForecasts[0].Temperature.Imperial.UnitType;


                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }

            return dto;
        }
    }
}
