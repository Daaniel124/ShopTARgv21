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
    }
}