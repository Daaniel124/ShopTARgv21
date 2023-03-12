using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.Dto.OpenWeather
{
    public class OpenWeatherResultDto
    {
        public Current current { get; set; }

        public double temp { get; set; }
        public double feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double wind_speed { get; set; }
        public List<Weather> weather { get; set; }

        public string main { get; set; }
    }
}
