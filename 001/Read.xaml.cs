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
        public string Text { get; set; }

        public Read(EF.User u, string text)
        {
            InitializeComponent();
            CurrentUser = u;
            Text = text;
            FlowDocument doc = new FlowDocument(new Paragraph(new Run(Text)));

            Rtb.Document = doc;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Shelf shelf2 = new Shelf();
            //shelf2.Show();
            //this.Close();
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Bookmark bookmark = new Bookmark();
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

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            RtbParagraph.TextAlignment = TextAlignment.Left;
            Rtb.UpdateLayout();
        }
        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            RtbParagraph.TextAlignment = TextAlignment.Center;
            Rtb.UpdateLayout();
        }
        private void RadioButton_Checked_7(object sender, RoutedEventArgs e)
        {
            RtbParagraph.TextAlignment = TextAlignment.Right;
            Rtb.UpdateLayout();
        }
        private void RadioButton_Checked_8(object sender, RoutedEventArgs e)
        {
            RtbParagraph.TextAlignment = TextAlignment.Justify;
            Rtb.UpdateLayout();
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
