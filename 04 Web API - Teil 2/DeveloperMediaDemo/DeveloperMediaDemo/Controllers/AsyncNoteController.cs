using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DeveloperMediaDemo.Models;

namespace DeveloperMediaDemo.Controllers
{
    public class AsyncNoteController : ApiController
    {
        private readonly INoteRepository _repository;

        public AsyncNoteController(INoteRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Calling an own awaitable method
        /// </summary>
        [HttpGet("async/note/")]
        public async Task<IEnumerable<Note>> GetAll()
        {
            return await _repository.ReadAllAsync();
        }

        /// <summary>
        /// Calling an awaitable framework method
        /// </summary>
        [HttpGet("async/note/webinar")]
        public async Task<IEnumerable<Note>> GetAllWebinar()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://johanneshoppe.github.io/DeveloperMediaSlides/webinar.json");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IEnumerable<Note>>();
        }
    }
}