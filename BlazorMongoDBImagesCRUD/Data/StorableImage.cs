using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMongoDBImagesCRUD.Data
{
    public class StorableImage
    {

       public ObjectId Id { get; set; }

        public byte[] Content;
   
        [BsonElement("filename")]
        
        public string Name { get; set; }
        [BsonElement("length")]
        public int Length { get; set; }
        [BsonElement("chunkSize")]

        public int ChunkSize { get; set; }
        [BsonElement("uploadDate")]
        public DateTime UploadDate { get; set; }
        [BsonElement("md5" +
            "")]
        public string Md5 { get; set; }
   
        public string Url { get; set; }    

    }
}
