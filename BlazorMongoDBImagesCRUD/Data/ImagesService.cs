using BlazorMongoDBImagesCRUD.Repositories;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMongoDBImagesCRUD.Data
{
    public class ImagesService : IImageService
    {

        internal ImagesRepository _repository;

        public ImagesService() 
        {

            _repository = new ImagesRepository();
        
        }
        
        
        public  async Task DeleteImage(ObjectId id)
        {
            _repository.DeleteImage(id);
        }

        public async Task<List<StorableImage>> GetAllImages()
        {
            var images = await  _repository.GetAllImages();
            var format = "image/png";

         foreach (var item in images) 
            {

                item.Content = await GetImageContent(item.Id);
                item.Url = $"data:{format};base64,{Convert.ToBase64String(item.Content)}";
            
            }

            return images;
        }

        public async Task<byte[]> GetImageContent(ObjectId id)
        {
            return await _repository.GetImageContent(id);
        }

        public Task<bool> SaveImage(StorableImage image)
        {
            return _repository.SaveImage(image);
        }
    }
}
