using Contracts;
using NotesProcessor;
using NotesWpfApp.View.Home;
using NotesWpfApp.View.UserControls;
using System.Windows;
using System.Windows.Controls;

namespace NotesWpfApp
{
    public partial class MainWindow : Window
    {
        private readonly INotesConverter _notesConverter;

        public MainWindow(INotesConverter notesConverter)
        {
            InitializeComponent();

            var startHomePage = new HomePage(notesConverter);
            grid1.Children.Add(startHomePage);
            Grid.SetRow(startHomePage, 1);

            navBar.OnNavBarClicked += NavBar_Clicked;
            _notesConverter = notesConverter;
        }
        
        private void NavBar_Clicked(object sender, RoutedEventArgs e)
        {
            if (e.Source == navBar.NoteList)
            {
                var homePage = new HomePage(_notesConverter);
                HandleNavBarButtonClick(homePage);
            }
            else
            {
                var allMyNotes = new AllMyNotes(_notesConverter);
                HandleNavBarButtonClick(allMyNotes);
            }
        }

        private void HandleNavBarButtonClick(UserControl content)
        {
            grid1.Children.RemoveAt(1);
            grid1.Children.Add(content);
            Grid.SetRow(content, 1);
        }
    }
}