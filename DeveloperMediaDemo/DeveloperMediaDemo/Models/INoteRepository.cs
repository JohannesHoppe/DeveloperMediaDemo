using System.Collections.Generic;

namespace WebNoteSinglePage.Models
{
    /// <summary>
    /// CRUD interface for all respositories
    /// </summary>
    public interface INoteRepository
    {
        /// <summary>
        /// Creates a new note and adds relations to the categories
        /// </summary>
        void Create(Note noteToAdd, IEnumerable<Category> newCategories);

        /// <summary>
        /// Gets one note and its categories
        /// </summary>
        NoteWithCategories Read(string id);

        /// <summary>
        /// Gets all notes with category.
        /// </summary>
        IEnumerable<NoteWithCategories> ReadAll();

        /// <summary>
        /// Update a note and its categories
        /// </summary>
        void Update(Note noteToEdit, IEnumerable<Category> newCategories);

        /// <summary>
        /// Deletes one Note (and the relations to the categories)
        /// </summary>
        void Delete(string id);

        /// <summary>
        /// Gets all available categories.
        /// </summary>
        IEnumerable<Category> GetAllCategories();

        /// <summary>
        /// Gets all categories for the given numbers.
        /// </summary>
        IEnumerable<Category> GetAllCategories(string[] categoryIds);
    }
}