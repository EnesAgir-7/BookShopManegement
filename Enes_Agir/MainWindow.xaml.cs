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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace Enes_Agir
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool RecordSelecting = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LBx_books.ItemsSource = App._books;
            CBx_categor.ItemsSource = new List<string> { "Celtic studies", "Classical studies", "Greek History", "Early Mediterranean", };
            CB_Category.ItemsSource = new List<string> { "Celtic studies", "Classical studies", "Greek History", "Early Mediterranean", };
            CB_Gender.ItemsSource = new List<string> { "Female", "Male" };
        }


        private void Record_Changed(object sender, RoutedEventArgs e)
        {
            if (RecordSelecting)
                return;
            int result = 0;
            if (Int32.TryParse(price.Text, out result) == false)
            {
                MessageBox.Show("Please enter a valid value for price");
                return;
            }
            Book book = (Book)LBx_books.SelectedItem;
            book.title = title.Text;
            book.description = description.Text;
            book.sellername= sellername.Text;
            book.sellerno= Convert.ToInt32(sellerphone.Text);
            book.street=Street.Text;
            book.city= city.Text;
            book.housenumber= Convert.ToInt32(Housenum.Text);
            book.zipcode= Convert.ToInt32(zipcode.Text);
            book.price = Convert.ToInt32(price.Text);
            book.gender = CB_Gender.SelectedItem.ToString() == "Female" ? 0 : 1;
            book.edition = CBx_categor.SelectedIndex;
            

            LBx_books.ScrollIntoView(LBx_books.SelectedItem);
            LBx_books.Items.Refresh();

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var itm = LBx_books.SelectedItem as Book;
            if (itm == null)
            {
                MessageBox.Show("Please select a book to be deleted.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var response = MessageBox.Show($"Do you really want to delete\n {itm.title} {itm.author}?", "Confirm", MessageBoxButton.OKCancel);
            if (response == MessageBoxResult.OK)
            {
                App._books.Remove(itm);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // this.NavigationService.Navigate(new Uri('mypage.xaml', UriKind.Relative));
            SellBook s = new SellBook();
            s.Show();
            this.Close();
        }

        private void T_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = T_filter.Text.ToLower();
            if(filter == "")
            {
                LBx_books.ItemsSource = App._books;
            }
            else
            {
                var lst = (from b in App._books where b.title.StartsWith(filter) select b).ToList();
                var lst2 = (from m in App._books where m.title.ToLower().Contains(filter) select m).ToList();
                lst.AddRange(lst2);
                LBx_books.ItemsSource = lst.Distinct();
            }
        }


        private void LBx_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBx_books.SelectedItem == null)
            {
                title.Text = "";
                author.Text = "";
                price.Text = "";
                description.Text = "";
                sellername.Text = "";
                sellerphone.Text = "";
                CBx_categor.SelectedIndex = 0;
                CB_Gender.SelectedIndex = 0;
                Street.Text = "";
                city.Text = "";
                Housenum.Text = "";
                zipcode.Text = "";
                return;
            }
            RecordSelecting = true;
            Book book = (Book)LBx_books.SelectedItem;
            title.Text = book.title;
            author.Text = book.author;
            price.Text = Convert.ToString(book.price);
            description.Text = book.description;
            sellername.Text = book.sellername;
            sellerphone.Text = Convert.ToString(book.sellerno);
            CBx_categor.SelectedIndex = book.edition;
            CB_Gender.SelectedIndex = book.gender;
            Street.Text = book.street;
            city.Text = book.city;
            Housenum.Text = Convert.ToString(book.housenumber);
            zipcode.Text = Convert.ToString(book.zipcode);
            RecordSelecting = false;

        }

        private void Btn_Edit_click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {

            Book mem = new Book
            {
                title = "[New Record]",
                gender = 0,
                price = 0,
                edition = 0
            };
            App._books.Add(mem);
            LBx_books.Items.Refresh();
            LBx_books.SelectedItem = mem;
            LBx_books.ScrollIntoView(LBx_books.SelectedItem);
        }
        private void CB_Category_filter(object sender, SelectionChangedEventArgs e)
        {
            var lst = (from b in App._books where b.edition == CBx_categor.SelectedIndex select b).ToList();
            LBx_books.ItemsSource = lst;
        }

        //private void CB_SelectionChange(object sender, SelectionChangedEventArgs e)
        //{
        //    if (cmb.SelectedIndex == 0)
        //        Properties.Settings.Default.languageCode = "en-US";
        //    else
        //        Properties.Settings.Default.languageCode = "tr-TR";
        //    Properties.Settings.Default.Save();
        //    InvalidateVisual();
        //}
    }
}
