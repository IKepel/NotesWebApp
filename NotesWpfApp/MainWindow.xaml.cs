using NotesWpfApp.View.Home;
using NotesWpfApp.View.UserControls;
using System.Windows;

namespace NotesWpfApp
{
    public partial class MainWindow : Window
    {
        private readonly NavBar navBar = new();

        public MainWindow()
        {
            InitializeComponent();
            grid1.Children.Add(navBar);
            navBar.OnNavBarClicked += NavBar_Clicked;
        }

        private void NavBar_Clicked(object sender, RoutedEventArgs e)
        {
            if (e.Source == navBar.NoteList)
            {
                Adder.Visibility = Visibility.Visible;
                AllMyNotes.Visibility = Visibility.Hidden;
            }
            else
            {
                Adder.Visibility = Visibility.Hidden;
                AllMyNotes.Visibility = Visibility.Visible;
            }
        }
    }
}