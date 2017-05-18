using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _001
{
    /// <summary>
    /// Interaction logic for Shelf.xaml
    /// </summary>
    public partial class Shelf : Window
    {
        public EF.User CurrentUser { get; set; }

        public List<EF.Book> BooksList { get; set; }
        public EF.Book SelectedBook { get; set; }
        public string Text { get; set; }

        public Shelf(EF.User u)
        {
            CurrentUser = u;
            InitializeComponent();
            BooksList = new List<EF.Book>();
            SelectedBook = new EF.Book();
            LoadComboboxItems();
        }

        private void LoadComboboxItems()
        {
            using (var db = new EF.Context())
            {
                BooksList = db.Books.ToList();
            }
            booksComboBox.ItemsSource = BooksList;
            booksComboBox.DisplayMemberPath = "Name";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedBook.Name))
            {
                Read read = new Read(CurrentUser, Text);
                read.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Change c = new Change();
            if (c.ShowDialog() == true)
            {
                MainWindow changed = new MainWindow();
                changed.Show();
                this.Close();
            }

            //c.Show();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedBook = booksComboBox.SelectedItem as EF.Book;
            SelectedBook = selectedBook;
            var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/images/" + SelectedBook.Cover + ".jpg");
            ImageSource imageSource = new BitmapImage(new Uri(imagePath));
            bookImage.Source = imageSource;
            var textPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/books/" + SelectedBook.Text + ".txt");
            Text = File.ReadAllText(textPath, Encoding.GetEncoding(1252));
            var description = SelectedBook.Author + "\n" + SelectedBook.Name + "\n" + Text;
            bookDescription.Text = description;

        }
    }
}
