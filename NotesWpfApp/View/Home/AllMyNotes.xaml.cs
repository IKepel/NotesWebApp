using Contracts;
using NotesProcessor;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace NotesWpfApp.View.Home
{
    public partial class AllMyNotes : UserControl
    {
        private readonly INotesConverter _allMyNotesConverter;

        public ObservableCollection<Note> NotesCollection { get; set; }

        public AllMyNotes(INotesConverter notesConverter)
        {
            InitializeComponent();
            _allMyNotesConverter = notesConverter;
            NotesCollection = new ObservableCollection<Note>();
            GetAllMyNotes();
        }

        private void GetAllMyNotes()
        {
            var allMyNotes = _allMyNotesConverter.GetAllNotes();
            foreach (var note in allMyNotes)
            {
                NotesCollection.Add(note);
            }
            dataGrid.ItemsSource = NotesCollection;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            if (button != null)
            {
                var note = button.DataContext as Note;
                if (note != null)
                {
                    _allMyNotesConverter.DeleteNote(note.Id);
                    NotesCollection.Remove(note); 
                }
            }
        }
    }
}