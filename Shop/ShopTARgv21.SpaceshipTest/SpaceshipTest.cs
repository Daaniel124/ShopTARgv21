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
            SpaceshipDto spaceship = CreateValidSpaceship();
            var createdSpaceship = await Svc<ISpaceShipServices>().Create(spaceship);


            //Act
            var result = await Svc<ISpaceShipServices>().Delete((Guid)createdSpaceship.Id);


            //Assert
            Assert.Equal(createdSpaceship, result);
        }
        [Fact]
        public async Task Should_UpdateByIdSpaceship_WhenUpdateSpaceship()
        {
            Spaceship spaceship = new();
            spaceship.Id = new Guid("9307f724-4639-4a70-844d-9a5254da4cad");
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

            var spaceshipId = new Guid("9307f724-4639-4a70-844d-9a5254da4cad");
            var spaceshipToUpdate = new SpaceshipDto()
            {
                Name = "assssd123",
                EnginePower = 456,
                ModelType = "test2",
                Passengers = "6",
                PlaceOfBuild = "nasa",
                SpaceshipBuilder = "te"
            };

            await Svc<ISpaceShipServices>().Update(spaceshipToUpdate);

            Assert.Equal(spaceship.Id, spaceshipId);
            Assert.DoesNotMatch(spaceship.Name, spaceshipToUpdate.Name);
            Assert.NotSame(spaceship.Passengers, spaceshipToUpdate.Passengers);
        }

        [Fact]
        public async Task ShoulUpdate_Spaceship_WhenUpdatedData()
        {
            SpaceshipDto spaceship = CreateValidSpaceship();
            var create = await Svc<ISpaceShipServices>().Create(spaceship);

            SpaceshipDto updateSpaceship = UpdateValidSpaceship();
            var update = await Svc<ISpaceShipServices>().Update(updateSpaceship);

            Assert.Equal(update.Name, create.Name);
            Assert.Equal(update.ModelType, create.ModelType);
            Assert.Equal(update.SpaceshipBuilder, create.SpaceshipBuilder);
            Assert.Equal(update.PlaceOfBuild, create.PlaceOfBuild);
            Assert.Equal(update.EnginePower, create.EnginePower);
            Assert.Equal(update.LiftUpToSpaceByTonn, create.LiftUpToSpaceByTonn);
            Assert.Equal(update.Crew, create.Crew);
            Assert.Equal(update.Passengers, create.Passengers);

            Assert.NotEqual(update.CreatedAt, create.CreatedAt);
            Assert.NotEqual(update.ModifiedAt, create.ModifiedAt);
        }

        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto spaceship = CreateValidSpaceship();
            var create = await Svc<ISpaceShipServices>().Create(spaceship);

            SpaceshipDto nullUpdate = NullSpaceship();
            var update = await Svc<ISpaceShipServices>().Update(nullUpdate);
            Assert.NotNull(update.Id);
            Assert.NotNull(update.Name);
        }

        private SpaceshipDto CreateValidSpaceship()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "asd",
                ModelType = "test",
                SpaceshipBuilder = "nasa",
                PlaceOfBuild = "test",
                EnginePower = 45,
                LiftUpToSpaceByTonn = 4,
                Crew = 4,
                Passengers = "5",
                LaunchDate = DateTime.Now,
                BuildOfDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            return spaceship;
        }

        private SpaceshipDto UpdateValidSpaceship()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "asd",
                ModelType = "test",
                SpaceshipBuilder = "nasa",
                PlaceOfBuild = "test",
                EnginePower = 45,
                LiftUpToSpaceByTonn = 4,
                Crew = 4,
                Passengers = "5",
                LaunchDate = DateTime.Now,
                BuildOfDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            return spaceship; 
        }

        private SpaceshipDto NullSpaceship()
        {
            SpaceshipDto spaceship = new()
            {
                Id = null,
                Name = "asd",
                ModelType = "test",
                SpaceshipBuilder = "nasa",
                PlaceOfBuild = "test",
                EnginePower = 45,
                LiftUpToSpaceByTonn = 4,
                Crew = 4,
                Passengers = "5",
                LaunchDate = DateTime.Now,
                BuildOfDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            return spaceship;
        }
    }
}