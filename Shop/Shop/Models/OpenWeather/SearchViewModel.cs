using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Shop.Models.OpenWeather
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "You must enter a city name")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed")]
        [Display(Name = "City name ")]
        public string CityNameTallinn { get; set; }
    }
}
