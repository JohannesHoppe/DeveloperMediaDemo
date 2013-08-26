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

        public NoteController(INoteRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// CRUD: Read All
        /// </summary>
        public IEnumerable<Note> GetAll()
        {
            return _repository.ReadAll();
        }

        /// <summary>
        /// CRUD: Read One
        /// </summary>
        public Note Get(int id)
        {
            return _repository.Read(id);
        }

        /// <summary>
        /// Searches within the title (only alpha-characters "^[A-Za-z]*$")
        /// </summary>
        [HttpGet("api/Note/search/{titlePart:alpha}")]
        public IEnumerable<Note> GetSearch(string titlePart)
        {
            return _repository.ReadAll().Where(x => x.Title.Contains(titlePart));
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
        [ValidateModel]
        public HttpResponseMessage Put(Note note)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(note);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
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