using System.Collections.Generic;

namespace DeveloperMediaDemo.Models
{
    public class PagedList<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalRecords { get; set; }
    }
}