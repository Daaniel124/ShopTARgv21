using ShopTARgv21.Core.Dto.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}
