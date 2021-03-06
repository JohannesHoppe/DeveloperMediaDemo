﻿using System.Collections.Generic;
using System.Linq;
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

        public Note Get(int id)
        {
            return NoteRepository.Read(id);
        }

        /// <summary>
        /// Searches for a the answer to life, universe and everything
        /// </summary>
        [HttpGet("api/Note/search/{what:regex(^answer$)}", RouteOrder = 1)]
        public int GetSearchFor42(string what)
        {
            return 42;
        }
        /// <summary>
        /// Searches within the title (only alpha-characters "^[A-Za-z]*$")
        /// </summary>
        [HttpGet("api/Note/search/{titlePart:alpha}", RouteOrder = 2)]
        public IEnumerable<Note> GetSearch(string titlePart)
        {
            return NoteRepository.ReadAll().Where(x => x.Title.Contains(titlePart));
        }

        /// <summary>
        /// Searches for a year
        /// </summary>
        [HttpGet("api/Note/search/{year:int}")]
        public IEnumerable<Note> GetSearch(int year)
        {
            return NoteRepository.ReadAll().Where(x => x.Added.Year == year);
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