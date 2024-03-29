﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace NotesWpfApp.View.UserControls
{
    public partial class ClearableTextBox : UserControl, INotifyPropertyChanged
    {
        private string _placeholder;

        private string _boundText;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Placeholder
        {
            //get { return _placeholder; }
            set
            {
                _placeholder = value;
                tbPlaceholder.Text = _placeholder;
            }
        }

        public string BoundText
        {
            get { return _boundText; }
            set
            {
                _boundText = value;
                OnPropertyChanged();
            }
        }

        public ClearableTextBox()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
                tbPlaceholder.Visibility = Visibility.Visible;
            else tbPlaceholder.Visibility = Visibility.Hidden;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}