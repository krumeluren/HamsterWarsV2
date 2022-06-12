namespace Core.Contracts.Service.Contracts;
public interface IFileHandler
{
    /// <summary>
    /// Upload file
    /// </summary>
    /// <param name="fileData">File as Base64 string to be uploaded</param>
    /// <param name="fileName">File name</param>
    /// <returns></returns>
    Task Upload(string fileData, string fileName);

    /// <summary>
    /// Get a file from the implemented path
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    string? GetFile(string fileName);

    /// <summary>
    /// The path to the file to be uploaded
    /// </summary>
    /// <returns></returns>
    string FilePath();


}
