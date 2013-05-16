using System.Collections.Generic;

using MongoDB.Bson.Serialization.Attributes;

namespace WebNoteSinglePage.Models
{
    [BsonIgnoreExtraElements]
    public class NoteWithCategories : Note
    {
        public NoteWithCategories()
        {
            Categories = new List<Category>();
        }

        public IEnumerable<Category> Categories { get; set; }

        public static NoteWithCategories Convert(Note note, IEnumerable<Category> categories)
        {
            return new NoteWithCategories
                {
                    Id = note.Id,
                    Title = note.Title,
                    Message = note.Message,
                    Added = note.Added,
                    Categories = categories
                };
        }
    }
}