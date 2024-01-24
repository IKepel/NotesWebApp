using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesProcessor
{
    public interface INotesConverter
    {
        IQueryable<Note> GetAllNotes();

        void AddNote(Note note);

        void DeleteNote(Guid id);
    }
}
