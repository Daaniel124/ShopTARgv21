using Microsoft.AspNetCore.Mvc;
using Shop.Models.WeatherForecast;
using ShopTARgv21.ApplicationServices.Services;
using ShopTARgv21.Core.ServiceInterface;

namespace Shop.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherForecastController
            (
             IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }

        [HttpGet]
        public IActionResult SearchCity()
        {
            SearchCityViewModel vm = new();

            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCityViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecast", new { city = vm.CityName });
            }

            return View(vm);
        }
    }
}
