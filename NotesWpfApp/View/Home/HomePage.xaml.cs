using NotesProcessor;
using System.Windows.Controls;
using System.Windows;
using Contracts;

namespace NotesWpfApp.View.Home
{
    public partial class HomePage : UserControl
    {
        private readonly INotesConverter _homeNotesConverter;

        public HomePage(INotesConverter notesConverter)
        {
            InitializeComponent();
            _homeNotesConverter = notesConverter;
        }

        private void AddNotetoDb_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note
            {
                Name = RecordName.BoundText,
                Value = Value.BoundText,
                Priority = int.Parse(Priority.BoundText)
            };

            _homeNotesConverter.AddNote(note);
        }
    }
}