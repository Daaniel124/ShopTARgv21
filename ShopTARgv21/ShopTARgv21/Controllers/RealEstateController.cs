using Microsoft.AspNetCore.Mvc;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using ShopTARgv21.Data;
using ShopTARgv21.Models.RealEstate;
using System.Diagnostics.Metrics;

namespace ShopTARgv21.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IRealEstateServices _realEstate;
        public RealEstateController
            (
                ShopDbContext context,
                IRealEstateServices realEstate
            )
        {
            _context = context;
            _realEstate = realEstate;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstate
                .OrderByDescending(x => x.Id)
                .Select(x => new RealEstateListViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Contact = x.Contact,
                    Size = x.Size,
                    Price = x.Price,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType,
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel realEstate = new RealEstateCreateUpdateViewModel();
            return View("CreateUpdate", realEstate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                Contact = vm.Contact,
                Size = vm.Size,
                Price = vm.Price,
                BuildingType = vm.BuildingType,
                County = vm.County,
                RoomNumber = vm.RoomNumber,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _realEstate.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var real = await _realEstate.GetAsync(id);

            if (real == null)
            {
                return NotFound();
            }

            var vm = new RealEstateCreateUpdateViewModel()
            {
                Id = real.Id,
                Address = real.Address,
                City = real.City,
                County = real.County,
                BuildingType= real.BuildingType,
                Size = real.Size,
                RoomNumber= real.RoomNumber,
                Price = real.Price,
                Contact = real.Contact,
                ModifiedAt= real.ModifiedAt,
                CreatedAt = real.CreatedAt,
            };

            return View(vm);

        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var product = await _realEstate.Delete(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var real = await _realEstate.GetAsync(id);

            if (real == null)
            {
                return NotFound();
            }

            var vm = new RealEstateCreateUpdateViewModel();


            vm.Id = real.Id;
            vm.Address = real.Address;
            vm.City = real.City;
            vm.County = real.County;
            vm.BuildingType = real.BuildingType;
            vm.Size = real.Size;
            vm.RoomNumber = real.RoomNumber;
            vm.Price = real.Price;
            vm.Contact = real.Contact;
            vm.ModifiedAt = real.ModifiedAt;
            vm.CreatedAt = real.CreatedAt;


            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                City = vm.City,
                County = vm.County,
                BuildingType = vm.BuildingType,
                Size = vm.Size,
                RoomNumber = vm.RoomNumber,
                Price = vm.Price,
                Contact = vm.Contact,
                ModifiedAt = vm.ModifiedAt,
                CreatedAt = vm.CreatedAt,
            };

            var result = await _realEstate.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
    }
}
