using NotesProcessor;
using System.Windows;
using System.Windows.Controls;

namespace NotesWpfApp.View.Home
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        //public event RoutedEventHandler OnAddNotetoDb;
        private readonly INotesConverter _notesConverter;

        public HomePage(INotesConverter notesConverter)
        {
            _notesConverter = notesConverter;
            InitializeComponent();
        }

        private void AddNotetoDb_Click(object sender, RoutedEventArgs e)
        {
            //OnAddNotetoDb?.Invoke(this, e);
        }
    }
}
