

using Microsoft.AspNetCore.Mvc;

namespace ShopTARgv21.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "asd";
            spaceship.ModelType = "test";
            spaceship.SpaceshipBuilder = "nasa";
            spaceship.PlaceOfBuild = "test";
            spaceship.EnginePower = 45;
            spaceship.LiftUpToSpaceByTonn = 4;
            spaceship.Crew = 4;
            spaceship.Passengers = "5";
            spaceship.LaunchDate = DateTime.Now;
            spaceship.BuildOfDate = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceShipServices>().Create(spaceship);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceShip_WhenReturnsResultAsync()
        {
            Guid guid = Guid.Parse("9307f724-4639-4a70-844d-9a5254da4cad");

            Guid guid1 = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<ISpaceShipServices>().GetAsync(guid);
            Assert.NotEqual(guid1, guid);
        }

        [Fact]
        public async Task Should_GetByIdSpaceShip_WhenReturnsEqual()
        {
            Guid guid = Guid.Parse("9307f724-4639-4a70-844d-9a5254da4cad");

            Guid guid1 = Guid.Parse("9307f724-4639-4a70-844d-9a5254da4cad");

            await Svc<ISpaceShipServices>().GetAsync(guid);

            Assert.Equal(guid1, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            //Arrange
            Guid guid = Guid.Parse("9307f724-4639-4a70-844d-9a5254da4cad");
            Guid guid1 = Guid.Parse("9307f724-4639-4a70-844d-9a5254da4cad");


            //Act
            var result = await Svc<ISpaceShipServices>().Delete(guid);


            //Assert
            var serviceActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(serviceActionResult.ControllerName);
            Assert.Equal("Read", serviceActionResult.ActionName);
        }
    }
}