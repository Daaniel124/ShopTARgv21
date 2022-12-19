﻿using Microsoft.AspNetCore.Mvc;
using Shop.Models.Spaceship;
using ShopTARgv21.Data;
using ShopTARgv21.Core.Dto;
using ShopTARgv21.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Shop.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly ISpaceShipServices _spaceshipServices;
        
        public SpaceshipController
            (
                ShopDbContext context,
                ISpaceShipServices spaceshipServices
            )
        {
            _context = context;
           _spaceshipServices = spaceshipServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Spaceship
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ModelType = x.ModelType,
                    Passengers = x.Passengers,
                    BuildOfDate = x.BuildOfDate,
                    LaunchDate = x.LaunchDate
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SpaceshipEditViewModel spaceship = new SpaceshipEditViewModel();

            return View("CreateUpdate", spaceship);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                ModelType = vm.ModelType,
                SpaceshipBuilder = vm.SpaceshipBuilder,
                EnginePower = vm.EnginePower,
                LiftUpToSpaceByTonn = vm.LiftUpToSpaceByTonn,
                PlaceOfBuild = vm.PlaceOfBuild,
                Crew = vm.Crew,
                Passengers = vm.Passengers,
                LaunchDate = vm.LaunchDate,
                BuildOfDate = vm.BuildOfDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto

                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId = x.SpaceshipId
                }).ToArray()
            };

            var result = await _spaceshipServices.Create(dto);

            if (result is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _spaceshipServices.GetAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipEditViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                ModelType = spaceship.ModelType,
                SpaceshipBuilder = spaceship.SpaceshipBuilder,
                EnginePower = spaceship.EnginePower,
                LiftUpToSpaceByTonn = spaceship.LiftUpToSpaceByTonn,
                PlaceOfBuild = spaceship.PlaceOfBuild,
                Crew = spaceship.Crew,
                Passengers = spaceship.Passengers,
                LaunchDate = spaceship.LaunchDate,
                BuildOfDate = spaceship.BuildOfDate,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt,
            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipEditViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id=vm.Id,
                Name=vm.Name,
                ModelType=vm.ModelType,
                SpaceshipBuilder=vm.SpaceshipBuilder,
                PlaceOfBuild=vm.PlaceOfBuild,
                EnginePower=vm.EnginePower,
                LiftUpToSpaceByTonn=vm.LiftUpToSpaceByTonn,
                Crew = vm.Crew,
                Passengers=vm.Passengers,
                LaunchDate=vm.LaunchDate,
                BuildOfDate=vm.BuildOfDate,
                CreatedAt=vm.CreatedAt,
                ModifiedAt=vm.ModifiedAt
            };

            var result = await _spaceshipServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipServices.GetAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                ModelType = spaceship.ModelType,
                SpaceshipBuilder = spaceship.SpaceshipBuilder,
                PlaceOfBuild = spaceship.PlaceOfBuild,
                EnginePower = spaceship.EnginePower,
                LiftUpToSpaceByTonn = spaceship.LiftUpToSpaceByTonn,
                Crew = spaceship.Crew,
                Passengers = spaceship.Passengers,
                LaunchDate = spaceship.LaunchDate,
                BuildOfDate = spaceship.BuildOfDate,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var product = await _spaceshipServices.Delete(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}