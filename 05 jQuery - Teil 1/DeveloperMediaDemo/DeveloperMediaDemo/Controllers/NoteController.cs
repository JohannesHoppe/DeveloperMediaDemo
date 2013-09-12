using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        /*
        /// <summary>
        /// CRUD: Read All
        /// </summary>
        public IEnumerable<Note> GetAll()
        {
            return _repository.ReadAll();
        }
        */

        public DateTableResponse Get(string secho, int iDisplayStart, int iDisplayLength)
        {
            return _repository.ReadAll(iDisplayStart, iDisplayLength).ToDateTableResponse(secho);
        }

        /// <summary>
        /// CRUD: Read One
        /// </summary>
        public Note Get(int id)
        {
            return _repository.Read(id);
        }

        /// <summary>
        /// CRUD: Create New
        /// </summary>
        public HttpResponseMessage Post()
        {
            var newNote = new Note();
            _repository.Create(newNote);
            return Request.CreateResponse(HttpStatusCode.Created, newNote.Id);
        }

        /// <summary>
        /// CRUD: Modify existing
        /// </summary>
        public HttpResponseMessage Put(Note note)
        {
            _repository.Update(note);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// CRUD: Delete one
        /// </summary>
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}