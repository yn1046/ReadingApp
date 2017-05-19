using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Interaction logic for Bookmark.xaml
    /// </summary>
    public partial class Bookmark : Window
    {
        public List<EF.Bookmark> BookmarksList { get; set; }
        public EF.User CurrentUser { get; set; }
        public EF.Book CurrentBook { get; set; }
        public EF.Context db { get; set; }

        public Bookmark(EF.User user, EF.Book book)
        {
            CurrentUser = user;
            CurrentBook = book;
            DataContext = this;
            db = new EF.Context();
            InitializeComponent();
            BookmarksList = new List<EF.Bookmark>();
            LoadBookmarks();
        }

        private void LoadBookmarks()
        {
            BookmarksList = db.Bookmarks.Where(b => b.IdBook == CurrentBook.Id).ToList();
            allBookmarks.ItemsSource = BookmarksList;
            if (db.Bookmarks.Any(b => b.IdUser == CurrentUser.Id && b.IdBook == CurrentBook.Id))
            {
                var userBookmark = db.Bookmarks.FirstOrDefault(b => b.IdUser == CurrentUser.Id && b.IdBook == CurrentBook.Id);
                bookmarkText.Text = userBookmark.Text;
            }
        }

        private void SaveBookmarks()
        {
            try
            {
                if (bookmarkText.Text.Length > 500) throw new Exception("Текст не может превышать 500 символов");

                if (!db.Bookmarks.Any(b => b.IdUser == CurrentUser.Id && b.IdBook == CurrentBook.Id))
                {
                    var newBookmark = new EF.Bookmark()
                    {
                        IdBook = CurrentBook.Id,
                        IdUser = CurrentUser.Id,
                        Text = bookmarkText.Text
                    };
                    db.Bookmarks.Add(newBookmark);
                    db.SaveChanges();
                }
                else
                {
                    var bookmark = db.Bookmarks.FirstOrDefault(b => b.IdUser == CurrentUser.Id && b.IdBook == CurrentBook.Id);
                    bookmark.Text = bookmarkText.Text;
                    db.SaveChanges();
                }
                LoadBookmarks();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveBookmarks();
        }
    }
}
