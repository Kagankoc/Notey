using NoteyApp.Models;
using System;
using System.Collections.Generic;

namespace NoteyApp.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly List<NoteModel> _notes;

        public NoteRepository()
        {
            _notes = new List<NoteModel>();
        }

        public NoteModel FindNoteById(Guid id)
        {
            return _notes.Find(n => n.NoteId == id);
        }

        public IEnumerable<NoteModel> GetAllNotes()
        {
            return _notes;
        }

        public void SaveNote(NoteModel noteModel)
        {
            _notes.Add(noteModel);
        }

        public void DeleteNote(NoteModel noteModel)
        {
            _notes.Remove(noteModel);
        }
    }
}
