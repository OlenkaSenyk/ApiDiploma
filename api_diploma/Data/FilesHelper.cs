using System.Drawing;
using System.Drawing.Imaging;

namespace api_diploma.Data
{
    public class FilesHelper
    {
        public static byte[] GetImageBytes(string path)
        {
            Image img = Image.FromFile(path);
            MemoryStream tmpStream = new MemoryStream();
            img.Save(tmpStream, ImageFormat.Jpeg);
            tmpStream.Seek(0, SeekOrigin.Begin);
            byte[] imgBytes = new byte[tmpStream.Length];
            tmpStream.Read(imgBytes, 0, imgBytes.Length);
            return imgBytes;
        }
    }
}
