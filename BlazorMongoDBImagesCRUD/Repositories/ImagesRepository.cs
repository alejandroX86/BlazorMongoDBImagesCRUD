using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMongoDBImagesCRUD.Data;
using MongoDB.Bson;

namespace BlazorMongoDBImagesCRUD.Repositories
{
    public class ImagesRepository : IImageService
    {

        internal IGridFSBucket buket;
        internal MongoDBepository _repo = new MongoDBepository();
        public IMongoCollection<StorableImage> Collection;
    
        public ImagesRepository()
        {
            _repo = new MongoDBepository();

            buket = new GridFSBucket(_repo.db);

            this.Collection = _repo.db.GetCollection<StorableImage>("fs.files");//fs chunks 
        
        }

        public async Task<bool> SaveImage(StorableImage image)
        {

           await buket.UploadFromBytesAsync(image.Name, image.Content);

            return true;
        }

        public async Task<List<StorableImage>> GetAllImages()
        {
            var query = await this.Collection

               .Find(new BsonDocument())
               .ToListAsync();

            return query;
        }

        public async Task DeleteImage(ObjectId id)
        {
            await buket.DeleteAsync(id);
        }

        public  async Task<byte[]> GetImageContent(ObjectId id)
        {
            return await buket.DownloadAsBytesAsync(id);
        }
    }
}
