using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeveloperMediaDemo.Models;

namespace DeveloperMediaDemo.Controllers
{
    public class NoteController : ApiController
    {
        public IEnumerable<Note> GetAll()
        {
            return NoteRepository.ReadAll();
        }

        public Note Get(int id)
        {
            return NoteRepository.Read(id);
        }

        /// <summary>
        /// Searches within the title
        /// </summary>
        [HttpGet("note/search/{titlePart}")]
        public Note GetSearch(string titlePart)
        {
            return NoteRepository.ReadAll().FirstOrDefault(x => x.Title.Contains(titlePart));
        }

        public HttpResponseMessage Post()
        {
            var newNote = new Note();
            NoteRepository.Create(newNote);
            return Request.CreateResponse(HttpStatusCode.Created, newNote.Id);
        }

        public HttpResponseMessage Put(Note note)
        {
            if (ModelState.IsValid)
            {
                NoteRepository.Update(note);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        public void Delete(int id)
        {
            NoteRepository.Delete(id);
        }
    }
}