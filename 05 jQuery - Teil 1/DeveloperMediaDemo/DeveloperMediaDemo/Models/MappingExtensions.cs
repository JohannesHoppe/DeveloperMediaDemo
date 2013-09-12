using System.Globalization;
using System.Linq;

namespace DeveloperMediaDemo.Models
{
    public static class MappingExtensions
    {
        public static DateTableResponse ToDateTableResponse(this PagedList<Note> notes, string sEcho)
        {
            string[][] aaData = (from a in notes.Items
                                 select new[]
                                     {
                                         a.Id.ToString(CultureInfo.InvariantCulture), 
                                         a.Title,
                                         a.Message,
                                         a.Added.ToString(CultureInfo.InvariantCulture),
                                         string.Join(",", a.Categories.ToArray())
                                     }).ToArray();

            return new DateTableResponse
                {
                    sEcho = sEcho,
                    iTotalRecords = notes.TotalRecords,
                    iTotalDisplayRecords = notes.TotalRecords,
                    aaData = aaData
                };            
        }
    }
}