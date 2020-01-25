using NoteyApp.Models;
using System;
using System.Collections.Generic;

namespace NoteyApp.Repositories
{
    public interface INoteRepository
    {
        NoteModel FindNoteById(Guid id);
        IEnumerable<NoteModel> GetAllNotes();
        void SaveNote(NoteModel noteModel);
        void DeleteNote(NoteModel noteModel);
    }
}