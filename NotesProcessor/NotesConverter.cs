using Contracts;
using DAL;

namespace NotesProcessor
{
    public class NotesConverter : INotesConverter
    {
        private readonly INoteRepository _repository;

        public NotesConverter(INoteRepository repository)
        {
            _repository = repository;
        }

        public void AddNote(Note note)
        {
            _repository.AddNote(note);
        }

        public void DeleteNote(Guid id)
        {
            _repository.DeleteNote(id);
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _repository.GetAllNotes();
        }
    }
}
