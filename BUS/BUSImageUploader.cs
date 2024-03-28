using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ImgbbUploader
    {
        private readonly string apiKey;

        public ImgbbUploader()
        {
            this.apiKey = "fe914c5bf5d6784ffb21c53ad548239d";
        }

        public async Task<string> UploadImageAsync(string imagePath)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    byte[] imageData = File.ReadAllBytes(imagePath);
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(apiKey), "key"); 
                    content.Add(new ByteArrayContent(imageData), "image", Path.GetFileName(imagePath)); // Image file
                    var response = await httpClient.PostAsync("https://api.imgbb.com/1/upload", content);
                    response.EnsureSuccessStatusCode();
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);
                    if (responseObject.success == true)
                    {
                        string imageUrl = responseObject.data.url;
                        return imageUrl;
                    }
                    else
                    {
                        string errorMessage = responseObject.error.message;
                        throw new Exception($"Image upload failed: {errorMessage}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while uploading the image: {ex.Message}");
                }
            }
        }
    }
}
