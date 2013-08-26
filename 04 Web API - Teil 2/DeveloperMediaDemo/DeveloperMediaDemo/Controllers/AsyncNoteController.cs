using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DeveloperMediaDemo.Models;

namespace DeveloperMediaDemo.Controllers
{
    public class AsyncNoteController : ApiController
    {
        /// <summary>
        /// Calling an own awaitable method
        /// </summary>
        public async Task<IEnumerable<Note>> GetAllExample()
        {
            return await NoteRepository.ReadAllAsync();
        }
        
        /// <summary>
        /// Calling an awaitable framework method
        /// </summary>
        public async Task<IEnumerable<Note>> GetAll()
        {
            const string address = "https://raw.github.com/JohannesHoppe/DeveloperMediaDemo/master/04%20Web%20API%20-%20Teil%202/DeveloperMediaDemo/DeveloperMediaDemo/Content/webinar.json";
            
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(address);
            response.EnsureSuccessStatusCode();

            IEnumerable<Note> notes = await response.Content.ReadAsAsync<IEnumerable<Note>>();
            return notes;
        }
    }
}
