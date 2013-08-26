using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMediaDemo.Models
{
    /// <summary>
    /// This is a simple demo repository with no real database connection
    /// </summary>
    public class NoteRepository : INoteRepository
    {
        public NoteRepository()
        {
            currentData = InitialData;
        }

        public void Create(Note item)
        {
            int highestId = 0;

            if (currentData.Any()) {
                highestId = currentData.OrderByDescending(i => i.Id).First().Id;
            }

            item.Id = highestId + 1;
            currentData.Add(item);
        }

        public Note Read(int id)
        {
            return currentData.First(c => c.Id == id);
        }

        public IEnumerable<Note> ReadAll()
        {
            return currentData;
        }

        public async Task<IEnumerable<Note>> ReadAllAsync()
        {
            // Prefer Task.Run over TaskFactory.StartNew!
            var result = await Task.Run(async () =>
            {
                await Task.Delay(0);
                return currentData;
            });

            return result;
        }

        public PagedList<Note> ReadAll(int skip, int take)
        {
            IEnumerable<Note> pagedData = currentData.Skip(skip).Take(take);

            return new PagedList<Note>
                {
                    Items = pagedData,
                    TotalRecords = InitialData.Count(),
                };
        }

        public void Update(Note item)
        {
            var itemToUpdate = Read(item.Id);

            itemToUpdate.Id = item.Id;
            itemToUpdate.Title = item.Title;
            itemToUpdate.Message = item.Message;
            itemToUpdate.Added = item.Added;
            itemToUpdate.Categories = item.Categories;
        }

        public void Delete(int id)
        {
            var itemToDelete = Read(id);
            currentData.Remove(itemToDelete);
        }

        #region inital data

        private readonly List<Note> currentData;

        private List<Note> InitialData
        {
            get
            {
                return new List<Note>
                    {
                        new Note { Id = 1, Title = "Ein PostIt", Message = "Hello World", Added = new DateTime(2013, 08, 13, 16, 15, 22), Categories = new[] { "important" }},
                        new Note { Id = 2, Title = "Zweites Beispiel", Message = "Alles mit Bindings", Added = new DateTime(2013, 08, 13, 16, 30, 23), Categories = new[] { "private" } },
                        new Note { Id = 3, Title = "Drittes Beispiel", Message = "Geladen über die ASP.NET Web API", Added = new DateTime(2013, 08, 13, 16, 45, 24), Categories = new[] { "hobby", "private" } }
                    };
            }
        }
        #endregion
    }
}