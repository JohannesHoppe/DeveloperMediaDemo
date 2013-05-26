﻿using System.Collections.Generic;
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

        public void Put(Note note)
        {
            NoteRepository.Update(note);
        }

        public void Delete(int id)
        {
            NoteRepository.Delete(id);
        }
    }
}