using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace WebNoteSinglePage.Models
{
    public class MongoDbNoteRepository : INoteRepository
    {
        [Dependency]
        public MongoDatabase Database { private get; set; }

        public const string CollectionNotes = "Notes";
        public const string CollectionCategories = "Categories";

        private MongoCollection<BsonDocument> Notes { get { return Database.GetCollection(CollectionNotes); } }
        private MongoCollection<BsonDocument> Categories { get { return Database.GetCollection(CollectionCategories); } }

        public void Create(Note noteToAdd, IEnumerable<Category> newCategories)
        {
            NoteWithCategories note = NoteWithCategories.Convert(noteToAdd, newCategories);
            Notes.Insert(note);
        }

        public NoteWithCategories Read(string id)
        {
            var query = Query.EQ("_id", ObjectId.Parse(id));
            return Notes.FindOneAs<NoteWithCategories>(query);
        }

        public IEnumerable<NoteWithCategories> ReadAll()
        {
            var sortBy = SortBy.Descending("_id");
            return Notes.FindAllAs<NoteWithCategories>().SetSortOrder(sortBy).ToList();
        }

        public void Update(Note noteToEdit, IEnumerable<Category> newCategories)
        {
            NoteWithCategories note = Read(noteToEdit.Id);

            note.Title = noteToEdit.Title;
            note.Message = noteToEdit.Message;
            note.Categories = newCategories;

            var query = Query.EQ("_id", ObjectId.Parse(noteToEdit.Id));
            Notes.Update(query, MongoDB.Driver.Builders.Update.Replace(note));
        }

        public void Delete(string id)
        {
            Notes.Remove(Query.EQ("_id", ObjectId.Parse(id)));
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return Categories.FindAllAs<Category>().ToList();
        }

        public IEnumerable<Category> GetAllCategories(string[] categoryColors)
        { 
            var colorArray = new BsonArray(categoryColors);
            var query = Query.In("Color", colorArray);

            return Categories.FindAs<Category>(query).ToList();
        }
    }
}