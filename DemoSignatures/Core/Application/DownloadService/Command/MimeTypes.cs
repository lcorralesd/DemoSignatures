namespace DemoSignatures.Core.Application.DownloadService.Command;

public partial class SaveFileToDownloadCommandHandler
{
    public static class MimeTypes
    {
        public static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".pdf", "application/pdf" }
            };
        }
    }
}
