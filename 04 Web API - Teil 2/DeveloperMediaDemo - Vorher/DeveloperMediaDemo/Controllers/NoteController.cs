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
        /// Searches within the title (only alpha-characters "^[A-Za-z]*$")
        /// </summary>
        [HttpGet("api/Note/search/{titlePart:alpha}", RouteOrder = 2)]
        public IEnumerable<Note> GetSearch(string titlePart)
        {
            return NoteRepository.ReadAll().Where(x => x.Title.Contains(titlePart));
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