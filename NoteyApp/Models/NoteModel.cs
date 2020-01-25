using System;

namespace NoteyApp.Models
{
    public class NoteModel
    {
        public Guid NoteId { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
