using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;

        //public NoteRepository(AppDbContext context)
        //{
        //    _context = context;
        //}

        public NoteRepository()
        {
            _context = new AppDbContext();
        }

        public void AddNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void DeleteNote(Guid id)
        {
            var noteToDelete = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (noteToDelete is not null) 
            {
                _context.Notes.Remove(noteToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _context.Notes.AsEnumerable();
        }
    }
}
