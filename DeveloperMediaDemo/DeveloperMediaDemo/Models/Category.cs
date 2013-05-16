using MongoDB.Bson.Serialization.Attributes;

namespace WebNoteSinglePage.Models
{
    [BsonIgnoreExtraElements]
    public class Category
    {
        public Category()
        {
            Name = string.Empty;
            Color = string.Empty;
        }

        public string Name { get; set; }

        public string Color { get; set; }
    }
}