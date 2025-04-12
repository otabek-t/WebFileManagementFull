
using WebFileManagement.StorageBroker.Services;

namespace WebFileManagement.Service.Services;

public class StorageService : IStorageService
{
    private readonly IStorageBrokerService _storageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
        await _storageBrokerService.CreateDirectoryAsync(directoryPath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        await _storageBrokerService.DeleteDirectoryAsync(directoryPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
        await _storageBrokerService.DeleteFileAsync(filePath); 
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        return await _storageBrokerService.DownloadFileAsync(filePath);
    }

    public async Task<Stream> DownloadFolderAsZipAsync(string directoryPath)
    {
        return await _storageBrokerService.DownloadFolderAsZipAsync(directoryPath);
    }

    public async Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath)
    {
        var filesAndDirectories = await _storageBrokerService.GetAllFilesAndDirectoriesAsync(directoryPath);

        return filesAndDirectories;
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        await _storageBrokerService.UploadFileAsync(filePath, stream);
    }

    
}
