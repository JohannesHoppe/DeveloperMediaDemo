using System.Collections.Generic;
using System.Web.Http;
using WebNoteSinglePage.Models;

namespace WebNoteSinglePage.Controllers
{
    public class CategoriesController : ApiController
    {
        public INoteRepository NotesRepository { private get; set; }

        public IEnumerable<Category> GetAllCategories()
        {
            return NotesRepository.GetAllCategories();
        }
    }
}
