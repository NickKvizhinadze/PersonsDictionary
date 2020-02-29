using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDictionary.Common.Helpers
{
    public class ImageManager
    {
        private const string ContentFolder = "/wwwroot/images/";
        #region Fields
        private static List<string> _forbidden = new List<string> { " ", "!", "*", "'", "(", ")", ";", ":", "@", "&", "=", "+", "$", ",", "/", "?", "%", "#", "[", "]" };
        #endregion

        public static async Task<string> UploadImageAsync(IFormFile file, string webRoot, string dir)
        {
            try
            {

                string imageUrl = "";

                if (file?.Length > 0 &&
                    (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/gif"))
                {
                    var fileName = GenerateFileName(file);
                    var (path, image) = GeneratePath(webRoot, fileName, dir);
                    imageUrl = image;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                return imageUrl;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void DeleteImage(string webRoot, string image, string dir)
        {
            if (!string.IsNullOrWhiteSpace(image))
            {
                var fileName = image.Split('/').Last();
                var path = Path.Combine(webRoot + ContentFolder + dir + "/", fileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        #region Private

        private static string GenerateFileName(IFormFile file)
        {
            string fileName = Path.GetFileName(file.FileName);

            foreach (string item in _forbidden)
            {
                fileName = fileName.Replace(item, string.Empty);
            }

            return fileName;
        }

        private static (string path, string imageUrl) GeneratePath(string webRoot, string fileName, string dir)
        {
            var random = DateTime.Now.ToString("yyyyMMddTHHmmss") + "-" + fileName;

            string dirPath = webRoot + ContentFolder + dir + " /";
            CheckOrCreateDirectory(dirPath);

            var path = Path.Combine(dirPath, random);
            var imageUrl = "/images/" + dir + "/" + random;
            return (path, imageUrl);
        }


        private static void CheckOrCreateDirectory(string dir)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }
        #endregion

    }
}
