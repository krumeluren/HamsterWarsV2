
using Core.Contracts.Service.Contracts;

namespace Services.Implementation;
public class ImageHandler : IFileHandler
{
    public string FilePath()
    {
        var currentDir = Directory.GetCurrentDirectory();
        var wwwroot = currentDir + "\\wwwroot\\images\\hamsters";
        return wwwroot;
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

    public async Task Upload(string fileData, string fileName)
    {
        Byte[] fileAsBytes = Convert.FromBase64String(fileData);

        Stream stream = new MemoryStream(fileAsBytes);
        var path = Path.Combine(FilePath(), fileName);
        FileStream fileStream = new FileStream(path, FileMode.CreateNew);
        stream.CopyTo(fileStream);
        fileStream.Close();
        stream.Close();
    }
}
