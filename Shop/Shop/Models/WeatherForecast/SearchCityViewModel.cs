using System.ComponentModel.DataAnnotations;

namespace Shop.Models.WeatherForecast
{
    public class SearchCityViewModel
    {
        [Required(ErrorMessage = "You must enter a city name")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed")]
        [Display(Name = "City name ")]
        public string CityName { get; set; }
    }
}
