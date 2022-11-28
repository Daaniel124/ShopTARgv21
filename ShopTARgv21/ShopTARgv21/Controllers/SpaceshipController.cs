using Microsoft.AspNetCore.Mvc;
using ShopTARgv21.Data;
using ShopTARgv21.Models.Spaceship;

namespace ShopTARgv21.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly ShopDbContext _context;

        public SpaceshipController
            (
                ShopDbContext context
            )
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Spaceship
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipListViewModel
                {
                    Name = x.Name,
                    ModelType = x.ModelType,
                    BuildOfDate = x.BuildOfDate,
                    LaunchDate = x.LaunchDate
                });

            return View();
        }
    }
}
