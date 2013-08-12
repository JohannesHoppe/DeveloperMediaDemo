using System.Collections.Generic;
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

        [HttpGet("notes/{noteId}/testtest")]
        public Note Get(int noteId)
        {
            return NoteRepository.Read(noteId);
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