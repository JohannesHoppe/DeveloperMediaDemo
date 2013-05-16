using System.Collections.Generic;
using System.Web.Http;
using WebNoteSinglePage.Models;

namespace WebNoteSinglePage.Controllers
{
    public class NotesController : ApiController
    {
        public INoteRepository NotesRepository { private get; set; }

        // GET: Reading
        public IEnumerable<NoteWithCategories> GetAllNotes()
        {
            return NotesRepository.ReadAll();
        }

        // GET: Reading
        public NoteWithCategories GetNote(string id)
        {
            return NotesRepository.Read(id);
        }

        // POST: Creating
        public void PostNote(NoteWithRawCategories noteToAdd)
        {
            var categories = NotesRepository.GetAllCategories(noteToAdd.Categories);
            NotesRepository.Create(noteToAdd, categories);
        }

        // PUT: Updating 
        public void PutNote(Note noteToEdit, string[] newCategories)
        {
            var categories = NotesRepository.GetAllCategories(newCategories);
            NotesRepository.Update(noteToEdit, categories);
        }

        // DELETE: Deleting
        public void DeleteNote(string id)
        {
            NotesRepository.Delete(id);
        }
    }
}
