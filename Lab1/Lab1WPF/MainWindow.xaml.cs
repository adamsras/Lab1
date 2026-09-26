using System;
using System.Linq;
using System.Windows;
using Lab1Library;

namespace Lab1WPF
{
    public partial class MainWindow : Window
    {
        private StudentsData students = new StudentsData();

        public MainWindow()
        {
            InitializeComponent();
            InvalidateList();
        }

        private void InvalidateList()
        {
            lstStudents.ItemsSource = students.Students.ToList();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                students.Add(new Student(txtName.Text, txtSurname.Text, txtId.Text,
                                         txtGroup.Text, txtEmail.Text));
                InvalidateList();
                txtName.Clear();
                txtSurname.Clear();
                txtId.Clear();
                txtGroup.Clear();
                txtEmail.Clear();
                txtName.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Kļūda", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try { students.Save(StudentsData.DefaultFilename); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Saglabāšanas kļūda", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var loaded = new StudentsData();
                loaded.Load(StudentsData.DefaultFilename);
                students = loaded;
                InvalidateList();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ielādes kļūda", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
