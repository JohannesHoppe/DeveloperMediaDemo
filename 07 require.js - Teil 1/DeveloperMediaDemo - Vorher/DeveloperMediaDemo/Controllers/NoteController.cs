using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeveloperMediaDemo.Code;
using DeveloperMediaDemo.Models;

namespace DeveloperMediaDemo.Controllers
{
    public class NoteController : ApiController
    {
        private readonly INoteRepository _repository;

        public NoteController()
        {
            _repository = new NoteRepository();
        }

        public NoteController(INoteRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Note> GetAll()
        {
            return _repository.ReadAll();
        }

        public Note Get(int id)
        {
            return _repository.Read(id);
        }

        public HttpResponseMessage Post()
        {
            var newNote = new Note();
            _repository.Create(newNote);
            return Request.CreateResponse(HttpStatusCode.Created, newNote.Id);
        }

        [ValidateModel]
        public HttpResponseMessage Put(Note note)
        {
            _repository.Update(note);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}