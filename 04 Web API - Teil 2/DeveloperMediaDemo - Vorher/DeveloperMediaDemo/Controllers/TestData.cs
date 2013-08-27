using System.Collections.Generic;
using DeveloperMediaDemo.Models;

namespace DeveloperMediaDemo.Controllers
{
    public static class TestData
    {
        public static List<Note> Notes
        { 
            get
            {
                return new List<Note>
                           {
                               new Note {Title = "PostIt 1"},
                               new Note {Title = "PostIt 2"},
                               new Note {Title = "PostIt 3"}
                           };
            }
        }

    }
}