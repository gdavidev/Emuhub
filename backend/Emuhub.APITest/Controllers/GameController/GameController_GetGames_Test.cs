using Emuhub.API.Controllers;
using Emuhub.Application.UseCases.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.TestingUtilities.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Emuhub.APITest.Controllers.GameController
{
    public class GameController_GetGames_Test
    {
        [Fact]
        public void GetGames_ReturnsOk_ValidPagination()
        {
            var page = 1;
            var gamesRepository = new GameRepositoryMock();
            gamesRepository.MockGetAll(page);

            var gamesUseCase = new GameGetUseCase(gamesRepository.Object);

            var controller = new GamesController();
            var result = controller.GetGames(gamesUseCase, page);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var game = Assert.IsType<GameResponse>(okResult.Value);
        }
    }
}