using NotesProcessor;
using System.Windows.Controls;
using System.Windows;
using Contracts;
using NotesWpfApp.View.UserControls;

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
            if (string.IsNullOrWhiteSpace(RecordName.BoundText) ||
                string.IsNullOrWhiteSpace(Value.BoundText) ||
                string.IsNullOrWhiteSpace(Priority.BoundText))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(Priority.BoundText, out int priority))
            {
                MessageBox.Show("Priority must be a valid integer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            Note note = new Note
            {
                Name = RecordName.BoundText,
                Value = Value.BoundText,
                Priority = int.Parse(Priority.BoundText)
            };

            _homeNotesConverter.AddNote(note);
            
            RecordName.BoundText = String.Empty;
            Value.BoundText = String.Empty;
            Priority.BoundText = String.Empty;
        }
    }
}