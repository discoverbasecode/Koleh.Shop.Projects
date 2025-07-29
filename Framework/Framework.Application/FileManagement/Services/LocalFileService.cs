using Framework.Application.FileManagement.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Framework.Application.FileManagement.Services;

public class LocalFileService : ILocalFileService
{
    private readonly string _basePath;

    public LocalFileService(string basePath = "")
    {
        _basePath = string.IsNullOrWhiteSpace(basePath)
            ? Directory.GetCurrentDirectory()
            : basePath;
    }

    public void DeleteDirectory(string directoryPath)
    {
        var path = GetFullPath(directoryPath);
        if (Directory.Exists(path))
            Directory.Delete(path, recursive: true);
    }

    public void DeleteFile(string path, string fileName)
    {
        var filePath = Path.Combine(GetFullPath(path), fileName);
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    public void DeleteFile(string filePath)
    {
        var fullPath = GetFullPath(filePath);
        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }

    public async Task SaveFile(IFormFile file, string directoryPath)
    {
        await SaveFile(file, directoryPath, file.FileName);
    }

    public async Task SaveFile(IFormFile file, string directoryPath, string fileName)
    {
        if (file == null)
            throw new InvalidDataException("File is null");

        var folderPath = GetFullPath(directoryPath);
        Directory.CreateDirectory(folderPath);

        var filePath = Path.Combine(folderPath, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);
    }

    public async Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath)
    {
        if (file == null)
            throw new InvalidDataException("File is null");

        var uniqueFileName = GenerateUniqueFileName(Path.GetExtension(file.FileName));
        await SaveFile(file, directoryPath, uniqueFileName);
        return uniqueFileName;
    }

    // ------------------------------

    private string GetFullPath(string relativePath)
    {
        return Path.Combine(_basePath, relativePath);
    }

    private string GenerateUniqueFileName(string extension)
    {
        return $"{Guid.NewGuid():N}_{DateTime.Now:yyyyMMddHHmmssfff}{extension}";
    }
}
