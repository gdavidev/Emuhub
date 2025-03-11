﻿using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Infrastructure.Repositories;

namespace Emuhub.Application.UseCases.Games
{
    public class GameGetUseCase(GameRepository games)
    {
        public async Task<List<GameResponse>> Execute(int page)
        {
            Validate(page);

            List<Game> gameList = await games.GetAll(page);
            List<GameResponse> response = gameList.Select(g => g.AsResponse()).ToList();

            return response;
        }

        private static void Validate(int page)
        {
            if (page < 0)
                throw new ValidationErrorException() { Errors = [ExceptionMessagesResource.NEGATIVE_PAGE_NUMBER] };
        }
    }
}
