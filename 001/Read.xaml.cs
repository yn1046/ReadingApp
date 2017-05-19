using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;


namespace _001
{
    /// <summary>
    /// Interaction logic for Read.xaml
    /// </summary>
    public partial class Read : Window
    {
        public EF.User CurrentUser { get; set; }
        public EF.Book CurrentBook { get; set; }

        public Read(EF.User u, EF.Book book, string text)
        {
            InitializeComponent();
            CurrentUser = u;
            CurrentBook = book;
            FlowDocument doc = new FlowDocument(new Paragraph(new Run(text)));
            AddRead();
            Rtb.Document = doc;

        }

        private void AddRead()
        {
            using (var db = new EF.Context())
            {
                if (!db.Reads.Any(r => r.IdUser == CurrentUser.Id && r.IdBook == CurrentBook.Id))
                {
                    var read = new EF.Read()
                    {
                        IdBook = CurrentBook.Id,
                        IdUser = CurrentUser.Id,
                        Date = DateTime.Now
                    };
                    db.Reads.Add(read);                    
                }
                else
                {
                    var read = db.Reads.FirstOrDefault(r => r.IdUser == CurrentUser.Id && r.IdBook == CurrentBook.Id);
                    read.Date = DateTime.Now;
                }
                db.SaveChanges();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Shelf shelf2 = new Shelf(CurrentUser);
            shelf2.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Bookmark bookmark = new Bookmark(CurrentUser, CurrentBook);
            bookmark.Show();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Rtb.FontSize = 12;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Rtb.FontSize = 14;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Rtb.FontSize = 16;
        }
        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            Rtb.FontSize = 18;
        }
        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            Rtb.FontSize = 20;
        }

        private void RadioButton_Checked_9(object sender, RoutedEventArgs e)
        {
            Rtb.FontFamily = new FontFamily("Arial");
        }

        private void RadioButton_Checked_10(object sender, RoutedEventArgs e)
        {
            Rtb.FontFamily = new FontFamily("Times New Roman");
        }

        private void RadioButton_Checked_11(object sender, RoutedEventArgs e)
        {
            Rtb.FontFamily = new FontFamily("Century");
        }
        private void RadioButton_Checked_12(object sender, RoutedEventArgs e)
        {
            Rtb.FontFamily = new FontFamily("Segoe UI");
        }

        private void RadioButton_Checked_13(object sender, RoutedEventArgs e) //светлый
        {
            Rtb.Foreground = Brushes.Black;
            Rtb.Background = Brushes.White;
        }
        private void RadioButton_Checked_14(object sender, RoutedEventArgs e) //темный
        {
            Rtb.Foreground = Brushes.White;
            Rtb.Background = Brushes.DarkGray;
        }
    }
}
