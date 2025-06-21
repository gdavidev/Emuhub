using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Emuhub.Infrastructure.Services.Storage;
using Emuhub.Library.Transformation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Emuhub.Application.UseCases.Games;

public class GameUpdateUseCase(
    IGameRepository games,
    GameUpdateRequestValidator validator,
    IFileStorageService storage)
{
    public async Task Execute(GameUpdateRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var oldGame = (await games.Get(request.Id))!;
        
        try
        {
            if (request.Image is not null)
            {
                var imageName = $"{oldGame.Id}{Path.GetExtension(request.Image.FileName)}";
                await SaveFile(request.Image, $"thumbs/{imageName}");
                
                oldGame.ImageName = imageName;
            }
            if (request.File is not null)
            {
                var fileName = $"{oldGame.Id}{Path.GetExtension(request.File.FileName)}";
                await SaveFile(request.File, $"files/{fileName}");
                
                oldGame.FileName = fileName;
            }
            if (!string.IsNullOrWhiteSpace(request.Name))
                oldGame.Name = request.Name;
            if (!string.IsNullOrWhiteSpace(request.Description))
                oldGame.Description = request.Description;
            if (request.CategoryId > 0)
                oldGame.CategoryId = request.CategoryId;
            if (request.EmulatorId > 0)
                oldGame.EmulatorId = request.EmulatorId;
            
            await games.Update(oldGame);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await games.Exists(request.Id))
            {
                throw new ValidationErrorException(
                    new ValidationErrorItem(
                        "Game",
                        ExceptionMessagesResource.GAME_NOT_FOUND));
            }
            throw new ValidationErrorException(
                new ValidationErrorItem(
                    "RaceCondition",
                    ExceptionMessagesResource.UNKNOWN_ERROR));
        }
    }

    private async Task SaveFile(IFormFile file, string path)
    {
        await storage.UploadAsync(
            "games",
            file.OpenReadStream(),
            path,
            file.ContentType);
    }
}