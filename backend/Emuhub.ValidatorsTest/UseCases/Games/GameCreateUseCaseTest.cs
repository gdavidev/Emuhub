using Emuhub.Application.UseCases.Games;
using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.TestingUtilities.Data;
using Emuhub.TestingUtilities.Infrastructure.Repositories;
using Emuhub.TestingUtilities.Infrastructure.Services;

namespace Emuhub.ApplicationTest.UseCases.Games
{
    public class GameCreateUseCaseTest
    {
        [Fact]
        public async Task Execute_ReturnsGameId_ValidRequest()
        {
            var (game, gameRequest) = CreateGameData();
            var (
                useCase,
                gameRepositoryMock,
                emulatorRepositoryMock,
                categoryRepositoryMock,
                storageServiceMock
            ) = CreateResources(game, gameRequest);

            var result = await useCase.Execute(gameRequest);

            gameRepositoryMock.Verify(x => x.Add(game), Moq.Times.Once());
            emulatorRepositoryMock.Verify(x => x.Exists(gameRequest.EmulatorId), Moq.Times.Once());
            categoryRepositoryMock.Verify(x => x.Exists(gameRequest.CategoryId), Moq.Times.Once());
            //storageServiceMock.Verify(x => x.UploadAsync(gameRequest.Image), Moq.Times.Once());
            //storageServiceMock.Verify(x => x.UploadAsync(gameRequest.File), Moq.Times.Once());

            Assert.True(result > 0);
        }

        private static (Game, GameCreateRequest) CreateGameData()
        {
            var gameRequest = new GameCreateRequest()
            {
                Name = "Mario Kart 64",
                Description = "Greatest kart game",
                Image = new FormFileMock("image.jpg", 1024 * 4).Object,
                File = new FormFileMock("file.zip", 1024 * 4).Object,
                CategoryId = 3,
                EmulatorId = 3,
            };
            var game = new Game()
            {
                Name = gameRequest.Name,
                Description = gameRequest.Description,
                ImageName = "games/" + gameRequest.Image.Name,
                FileName = "games/" + gameRequest.File.Name,
                CategoryId = gameRequest.CategoryId,
                EmulatorId = gameRequest.EmulatorId,
            };

            return (game, gameRequest);
        }

        private static (
            GameCreateUseCase,
            GameRepositoryMock,
            EmulatorRepositoryMock,
            GameCategoriesRepositoryMock,
            FileStorageServiceMock)
            CreateResources(Game game, GameCreateRequest request)
        {
            var gameRepositoryMock = new GameRepositoryMock();
            gameRepositoryMock.MockAdd(game);

            var emulatorRepositoryMock = new EmulatorRepositoryMock();
            emulatorRepositoryMock.MockExists(game.EmulatorId);

            var categoryRepositoryMock = new GameCategoriesRepositoryMock();
            categoryRepositoryMock.MockExists(game.CategoryId);

            var storageServiceMock = new FileStorageServiceMock();
            storageServiceMock.MockUploadAsync(request.Image);
            storageServiceMock.MockUploadAsync(request.File);

            var validator = new GameCreateRequestValidator(emulatorRepositoryMock.Object, categoryRepositoryMock.Object);

            var useCase = new GameCreateUseCase(gameRepositoryMock.Object, validator, storageServiceMock.Object);

            return 
            (
                useCase,
                gameRepositoryMock,
                emulatorRepositoryMock,
                categoryRepositoryMock,
                storageServiceMock
            );
        }
    }
}
