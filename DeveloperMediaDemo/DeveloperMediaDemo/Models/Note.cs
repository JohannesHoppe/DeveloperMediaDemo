using System;
using System.Collections.Generic;

namespace DeveloperMediaDemo.Models
{
    public class Note
    {
        public Note()
        {
            Title = String.Empty;
            Message = String.Empty;
            Added = DateTime.Now;
            Categories = new List<string>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Added { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}