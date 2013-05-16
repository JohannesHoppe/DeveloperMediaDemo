using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebNoteSinglePage.Models;

namespace WebNoteSinglePage.Controllers
{
    public class NoteWithRawCategories : Note
    {
        public string[] Categories { get; set; }
    }
}