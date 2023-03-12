using ShopTARgv21.Core.Dto.OpenWeather;

namespace Shop.Models.OpenWeather
{
    public class CityViewModel
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
