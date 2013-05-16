using System;
using System.ComponentModel.DataAnnotations;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebNoteSinglePage.Models
{
    /// <summary>
    /// An Entity (in DDD speak)
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Note
    {
        public Note()
        {
            Title = String.Empty;
            Message = String.Empty;
            Added = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the "Primary Key" for EF (SQL), MongoDB and RavenDB
        /// </summary>
        /// <remarks>
        /// BsonId: When you inserting a document this generates a new unique value
        /// BsonRepresentation: The serializer will convert the ObjectId to a string when reading data and
        /// will convert the string back to an ObjectId when writing data to the database
        /// </remarks>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]   
        public string Id { get; set; }

        [Required] // ASP.NET DataAnnotation
        public string Title { get; set; }

        [Required] // ASP.NET DataAnnotation
        public string Message { get; set; }

        public DateTime Added { get; set; }
    }
}