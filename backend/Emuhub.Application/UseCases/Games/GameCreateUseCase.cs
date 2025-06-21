using Emuhub.Application.Validation.Games;
using Emuhub.Communication.Data.Games;
using Emuhub.Domain.Entities.Games;
using Emuhub.Infrastructure.Repositories.Abstractions;
using Emuhub.Infrastructure.Services.Storage;
using Emuhub.Library.Transformation;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Emuhub.Application.UseCases.Games;

public class GameCreateUseCase(
    IGameRepository games,
    GameCreateRequestValidator validator,
    IFileStorageService storage) 
{
    public async Task<Guid> Execute(GameCreateRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var newGuid = Guid.NewGuid();
        var imageName = $"{newGuid}{Path.GetExtension(request.Image.Name)}";
        var fileName = $"{newGuid}{Path.GetExtension(request.File.Name)}";
            
        try
        {
            var game = new Game()
            {
                Id = newGuid,
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                EmulatorId = request.EmulatorId,
                ImageName = imageName,
                FileName = fileName,
            };

            await UploadFileAsync(request.File, "files/", fileName);
            await UploadFileAsync(request.Image, "thumbs/", imageName);
            await games.Add(game);
            
            return newGuid;
        }
        catch
        {
            await RollbackFiles(imageName, fileName);
            throw;
        }
    }

    private async Task UploadFileAsync(IFormFile file, string location, string fileName) =>
        await storage.UploadAsync(
            "games",
            file.OpenReadStream(),
            location + fileName,
            file.ContentType
        );

    private async Task RollbackFiles(string imagePath, string filePath)
    {
        await storage.DeleteAsync("games", "thumb/" + imagePath);
        await storage.DeleteAsync("games", "files/" + filePath);
    }
}