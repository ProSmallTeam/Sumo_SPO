using System.Globalization;
using System.Windows;
using DevExpress.Xpf.Grid;
using System.Collections.ObjectModel;

namespace VisualSumoWPF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataBase;

    using DevExpress.Utils;
    using DevExpress.XtraRichEdit.Import.Html;

    using MongoDB.Bson;

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private DataBase _database;

        private static readonly string[] FirstNames = new string[] {"Firstbook", "Secondbook", "Thirdbook"};
        static readonly string[] LastNames = new string[] {"Dodsworth", "Smith", "Miller"};
        
        static readonly ObservableCollection<DynamicDictionary> ObservableCollection = new ObservableCollection<DynamicDictionary>();
        
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Hide();

            var addForm = new DirectoryAdding();
            addForm.ShowDialog();

            for (var i = 0; i < 3; i++)
            {

                var dictionary = new DynamicDictionary();
                dictionary.SetValue("Name", FirstNames[i]);
                dictionary.SetValue("Year", i.ToString(CultureInfo.InvariantCulture));
                dictionary.SetValue("Author", LastNames[i]);
                ObservableCollection.Add(dictionary);
            }
            webBrouser.Navigate("http://www.ozon.ru/?context=search&text=978-5-17-079349-5&group=div_book");
       
            double _height =  SystemParameters.PrimaryScreenHeight;
            double _width = SystemParameters.PrimaryScreenWidth;         
            mainWindow.Width = _width;
            mainWindow.Height = _height;

            _database = new DataBase("mongodb://localhost/?safe=true");
            //GridBook.ItemsSource = _database.GetBooksByAttrId(new List<int> { 69 });
            
            //Изменить на IQureryable.
            GridBook.ItemsSource = ObservableCollection;
            this.InitDrives();

            Show();                      
        }


        public void InitDrives()
        {
            TreeListControl.BeginDataUpdate();
            try
            {
                
                var collection = _database.GetBooksByAttrId(new List<int> { 69 });
                MessageBox.Show(collection.Count().ToString());
                int i = 0;
                var node1 = new TreeListNode();
                TreeVeiw.Nodes.Add(node1);
                foreach (Book book in collection)
                {
                    //TreeListNode stage21 = new TreeListNode(new StageObject() { NameValue = "Information Gathering", Executor = GetRandomEmployee() });
                    //stage21.Nodes.Add(new TreeListNode(new TaskObject() 
                    //{ NameValue = "Market research", Executor = GetRandomEmployee(), StartDate = new DateTime(2011, 10, 1), 
                    //    EndDate = new DateTime(2011, 10, 5), State = States.DataSource[2] }) { Image = TaskObject.Image });
            
                    var node = new TreeListNode { Content = book };

                    node1.Nodes.Add(node);
                    node.IsExpandButtonVisible = DefaultBoolean.True;
                    node.Tag = false;
                }
            }
            catch { }
            TreeListControl.EndDataUpdate();
        }

        //MongoDB.Driver. Выборки произвожу так:
        public IQueryable<Book> Find()//(Func<Book, bool> predicate)
        {
            var items = (IQueryable<Book>)_database.Database.GetCollection<BsonDocument>("Books"); //Collections.Users.FindAllAs<Book>();//.Where();
            return items;
        }


        private void AddDirectoriesClick(object sender, RoutedEventArgs e)
        {
            
            Hide();
            var dictionary = new DynamicDictionary();
            dictionary.SetValue("Name", "Andrew");
            dictionary.SetValue("Year", "2003");
            dictionary.SetValue("Author", "McCormic");
            ObservableCollection.Add(dictionary);

            var addForm = new DirectoryAdding();
            addForm.ShowDialog();
            Show();
        }

        private void GridBook_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            var focusedRow = GridBook.GetFocusedRow();
            var dynamicDictionary = (DynamicDictionary)focusedRow;          
        }       
    }
}