using Framework.Application.FileManagement.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Framework.Application.FileManagement.Services;

public class FtpFileService : IFtpFileService
{
    private readonly string _ftpServer = "ftp://130.185.79.155/public_html";
    private readonly string _ftpUser = "pz16162";
    private readonly string _ftpPassword = "G9xna4oN";

    private NetworkCredential CreateNetworkCredential() =>
        new(_ftpUser, _ftpPassword);

    public async Task SaveFile(IFormFile file, string directoryPath)
    {
        string filePath = await PrepareDirectoryAndGetFullPath(directoryPath, file.FileName);
        await using var stream = file.OpenReadStream();
        byte[] bytes = await ReadAllBytesAsync(stream);
        await UploadBytesAsync(filePath, bytes);
    }

    public async Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath)
    {
        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        string filePath = await PrepareDirectoryAndGetFullPath(directoryPath, fileName);
        await using var stream = file.OpenReadStream();
        byte[] bytes = await ReadAllBytesAsync(stream);
        await UploadBytesAsync(filePath, bytes);
        return fileName;
    }

    public async Task SaveFile(Stream stream, string directoryPath, string fileName)
    {
        string filePath = await PrepareDirectoryAndGetFullPath(directoryPath, fileName);
        byte[] bytes = await ReadAllBytesAsync(stream);
        await UploadBytesAsync(filePath, bytes);
    }

    public async Task DeleteFile(string path, string fileName)
    {
        string filePath = $"{_ftpServer}{path.RemoveWwwRoot()}/{fileName}";
        await DeleteFileInternal(filePath);
    }

    public async Task DeleteFile(string filePath)
    {
        string fullPath = $"{_ftpServer}{filePath.RemoveWwwRoot()}";
        await DeleteFileInternal(fullPath);
    }

    public async Task DeleteDirectory(string directoryPath)
    {
        string fullPath = $"{_ftpServer}{directoryPath.RemoveWwwRoot()}";
        var request = (FtpWebRequest)WebRequest.Create(new Uri(fullPath));
        request.Method = WebRequestMethods.Ftp.RemoveDirectory;
        request.Credentials = CreateNetworkCredential();
        using var response = await request.GetResponseAsync();
    }

    // ----------------------------

    private async Task DeleteFileInternal(string filePath)
    {
        var request = (FtpWebRequest)WebRequest.Create(new Uri(filePath));
        request.Method = WebRequestMethods.Ftp.DeleteFile;
        request.Credentials = CreateNetworkCredential();
        using var response = await request.GetResponseAsync();
    }

    private async Task<string> PrepareDirectoryAndGetFullPath(string relativePath, string fileName)
    {
        string currentDir = _ftpServer;
        string[] subDirs = relativePath.RemoveWwwRoot().Split('/', StringSplitOptions.RemoveEmptyEntries);

        foreach (var subDir in subDirs)
        {
            currentDir = $"{currentDir}/{subDir}";
            await CreateDirectoryIfNotExists(currentDir);
        }

        return $"{currentDir}/{fileName}";
    }

    private async Task UploadBytesAsync(string fullPath, byte[] data)
    {
        using WebClient client = new WebClient();
        client.Credentials = CreateNetworkCredential();
        await client.UploadDataTaskAsync(new Uri(fullPath), data);
    }

    private async Task<byte[]> ReadAllBytesAsync(Stream stream)
    {
        using var memory = new MemoryStream();
        await stream.CopyToAsync(memory);
        return memory.ToArray();
    }

    private async Task CreateDirectoryIfNotExists(string directoryPath)
    {
        try
        {
            var request = (FtpWebRequest)WebRequest.Create(directoryPath);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.UseBinary = true;
            request.Credentials = CreateNetworkCredential();
            using var response = (FtpWebResponse)await request.GetResponseAsync();
        }
        catch (WebException ex)
        {
            if (ex.Response is FtpWebResponse ftpResponse &&
                ftpResponse.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
            {
                // directory already exists → do nothing
            }
            else
            {
                throw;
            }
        }
    }
}