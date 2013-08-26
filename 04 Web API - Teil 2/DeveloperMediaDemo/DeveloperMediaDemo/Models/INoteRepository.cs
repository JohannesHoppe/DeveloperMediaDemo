using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperMediaDemo.Models
{
    public interface INoteRepository
    {
        void Create(Note item);

        Note Read(int id);

        IEnumerable<Note> ReadAll();

        Task<IEnumerable<Note>> ReadAllAsync();

        PagedList<Note> ReadAll(int skip, int take);

        void Update(Note item);

        void Delete(int id);
    }
}