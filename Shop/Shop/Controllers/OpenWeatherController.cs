using Microsoft.AspNetCore.Mvc;
using Shop.Models.OpenWeather;
using Shop.Models.RealEstate;
using Shop.Models.WeatherForecast;
using ShopTARgv21.Core.Dto.OpenWeather;
using ShopTARgv21.Core.Dto.Weather;
using ShopTARgv21.Core.ServiceInterface;

namespace Shop.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeatherServices _weatherServices;

        public OpenWeatherController
            (
             IOpenWeatherServices weatherServices
            )
        {
            _weatherServices = weatherServices;
        }


        [HttpGet]
        public IActionResult SearchCity()
        {
            SearchViewModel vm = new();

            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(SearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeather", new { city = vm.CityNameTallinn });
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Back()
        {
            //return View("Views/Home/Index.cshtml");
            return View("Views/OpenWeather/Index.cshtml");
        }

        public IActionResult City(string city)
        {
            OpenWeatherResultDto dto = new OpenWeatherResultDto();

            _weatherServices.WeatherDetail(dto);

            Models.OpenWeather.CityViewModel vm = new();

            vm.temp = dto.temp;
            vm.feels_like = dto.feels_like;
            vm.pressure = dto.pressure;
            vm.humidity = dto.humidity;
            vm.wind_speed = dto.wind_speed;
            vm.main = dto.main;

            return View(vm);
        }
    }
}
