namespace Core.Contracts.Service.Contracts;
public interface IFileHandler
{
    /// <summary>
    /// Upload file
    /// </summary>
    /// <param name="fileData">File as Base64 string to be uploaded</param>
    /// <param name="fileName">File name</param>
    void Upload(string fileData, string fileName);

    /// <summary>
    /// Get a file from the implemented FilePath
    /// </summary>
    string? GetFile(string fileName);

    /// <summary>
    /// The path for the file to be uploaded
    /// </summary>
    string FilePath();


}
