using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMongoDBImagesCRUD.Data
{
    public  interface IImageService
    {

        Task<bool> SaveImage(StorableImage image);
        Task<List<StorableImage>> GetAllImages();
        Task<byte[]> GetImageContent(ObjectId id);
        Task DeleteImage(ObjectId id);
    }
}
