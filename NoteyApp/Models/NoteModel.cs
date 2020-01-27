using System;
using System.ComponentModel.DataAnnotations;

namespace NoteyApp.Models
{
    public class NoteModel
    {
        public Guid NoteId { get; set; }
        [Required(ErrorMessage = "Please Enter The Subject")]
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
