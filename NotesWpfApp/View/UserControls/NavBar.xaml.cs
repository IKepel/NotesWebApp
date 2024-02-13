using System.Windows;
using System.Windows.Controls;

namespace NotesWpfApp.View.UserControls
{
    public partial class NavBar : UserControl
    {
        public event RoutedEventHandler? OnNavBarClicked;

        public NavBar()
        {
            InitializeComponent();
        }

        private void NoteList_Click(object sender, RoutedEventArgs e)
        {
            OnNavBarClicked?.Invoke(this, e);
        }

        private void AllmyNotes_Click(object sender, RoutedEventArgs e)
        {
            OnNavBarClicked?.Invoke(this, e);
        }

        //private void Test_Click(object sender, RoutedEventArgs e)
        //{
        //    OnNavBarClicked?.Invoke(this, e);
        //}
    }
}