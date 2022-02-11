using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Enes_Agir
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Book> _books;
        protected override void OnStartup(StartupEventArgs e)
        {
            //var langCode = Enes_Agir.Properties.Settings.Default.languageCode;
            
            base.OnStartup(e);
            if (System.IO.File.Exists("Books.xml"))
                _books = MyStorage.ReadXml<ObservableCollection<Book>>("Books.xml");
            if (_books == null)
                _books = new ObservableCollection<Book>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            MyStorage.WriteXml<ObservableCollection<Book>>(_books, "Books.xml");
        }
    }
}
