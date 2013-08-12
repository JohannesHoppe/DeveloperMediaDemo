using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeveloperMediaDemo.Models
{
    public class Note
    {
        public Note()
        {
            Categories = new List<string>();
        }

        public int Id { get; set; }
        
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Don't be lazy!")]
        public string Message { get; set; }

        public DateTime Added { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}