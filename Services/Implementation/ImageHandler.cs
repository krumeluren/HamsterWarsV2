
using Core.Contracts.Repo.Contracts;
using Core.Contracts.Service.Contracts;

namespace Services.Implementation;
public class ImageHandler : IFileHandler
{

    private readonly ILoggerManager _logger;

    public ImageHandler(ILoggerManager logger)
    {
        _logger = logger;
    }

    public string FilePath()
    {
        var currentDir = Directory.GetCurrentDirectory();
        var hamsterFolder = currentDir + "\\wwwroot\\images\\hamsters";
        return hamsterFolder;
    }

    public string? GetFile(string fileName)
    {
        var path = FilePath() + "\\" + fileName;

        if (File.Exists(path))
        {
            var image = File.ReadAllBytes(path);
            var base64 = Convert.ToBase64String(image);
            return base64;
        }
        return null;
    }

    public void Upload(string fileData, string fileName)
    {
        try
        {
            Byte[] fileAsBytes = Convert.FromBase64String(fileData);
            Stream stream = new MemoryStream(fileAsBytes);
            var path = Path.Combine(FilePath(), fileName);
            FileStream fileStream = new FileStream(path, FileMode.CreateNew);
            stream.CopyTo(fileStream);
            fileStream.Close();
            stream.Close();
        }
        catch (FormatException ex)
        {
            throw new FormatException("Image data invalid. " + ex.Message);
        }
        return;
    }
}