using System.Globalization;
using System.Windows;
using System.Windows.Forms;
using DevExpress.Xpf.Grid;
using System.Collections.ObjectModel;

using MessageBox = System.Windows.MessageBox;
using HtmlAgilityPack;
using Application = System.Windows.Forms.Application;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

using Sumo.API;

namespace VisualSumoWPF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataBase;

    using DevExpress.Utils;

    public partial class MainWindow : Window
    {
        private MakeMeHappy _makeMeHappy = new MakeMeHappy();

        /// <summary>
        /// Конструктор окна
        /// </summary>
        public MainWindow()
        {
            //if (IsFirstLaunch())
            //{
            //    var addForm = new DirectoryAdding(true);
            //    addForm.ShowDialog();
            //    if (addForm.DialogResult != true) Close();
            //}
            InitializeComponent();
        }

        /// <summary>
        /// Действия при загрузке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //InitGrid();
            InitDrives();

            GridBook.ItemsSource = ObservableCollection;

            //WebBrowser.NavigateToString(BookToHtml(GetBook()));
            
        }

        /// <summary>
        /// Получить книгу по названию
        /// </summary>
        /// <returns></returns>
        //private Book GetBook()
        //{
            
        //    return myBook;
        //}

        private string BookToHtml(Book book)
        {
            var result = "<html><head>" +
                        "<meta http-equiv=\"Content-Type\"  content=\"text/html; charset=utf-8\" />"+
                         "<style type=\"text/css\"> " +
                         ".title{ font-weight: bold;} " +
                         ".text{ float:right }"+
                         ".image{ float: left; margin-right: 10px; margin-bottom: 20px; width 180px}" +
                         ".main_info{ width: 400px}.text{ word-wrap: break-word }" +
                         "</style></head>";
            result += "<body width=\"600px\"><h1>" + book.Name + "</h1><div ><div class=\"image\"><img src=\"" +
                       "http://my-poker-life.ucoz.ru/asdasda.jpg\"></div>";

            var content = "";
            if (book.SecondaryFields.ContainsKey("Содержание"))
            {
                var contentList = book.SecondaryFields["Содержание"];
                content = contentList.Aggregate(content, (current, s) => current + s + "<br/><br/>");
                book.SecondaryFields.Remove("Содержание");
            }
            else content = "Отсутствует";

            result +="<div class=\"main_info\">";

            foreach (var tag in book.SecondaryFields)
            {
                result += "<span class=\"title\">" + tag.Key + ": </span><br/>";
                foreach (var value in tag.Value)
                {
                    result += "<span class=\"text\">" + value  +"</span><br/>";
                }
            }
            
            
            result += "</div>";
            result += "</div><div class=\"content\" style=\"clear: both\"><h2>Описание</h2><span>" +
                      content +"</span></div >";

            result += "</div></body></html>";

            
            return result;
        } 

        /// <summary>
        /// Действия при нажатии кнопки добавления аудиторий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDirectoriesClick(object sender, RoutedEventArgs e)
        {

            Hide();
            var addForm = new DirectoryAdding(false);
            addForm.ShowDialog();
            Show();
            if (addForm.DialogResult != true) Close();
        }

        /// <summary>
        /// Проверка превый ли раз запущено окно
        /// </summary>
        /// <returns></returns>
        private bool IsFirstLaunch()
        {
            return true;
        }

        private static readonly string[] FirstNames = new string[] { "Firstbook", "Secondbook", "Thirdbook" };
        static readonly string[] LastNames = new string[] { "Dodsworth", "Smith", "Miller" };

        static ObservableCollection<DynamicDictionary> ObservableCollection = new ObservableCollection<DynamicDictionary>();

        //private void InitGridDatabase()
        //{
        //    _database = new DataBase("mongodb://localhost/?safe=true");
        //    string str = "s";
        //    if (_database.GetBooks("") != null)
        //    {
        //        foreach (var book in _database.GetBooks(""))
        //        {
        //            var dictionary = new DynamicDictionary();
        //            dictionary.SetValue("Name", book.Name);
        //            dictionary.SetValue("Year", book.Name);//добавить поля для работы с бд.
        //            dictionary.SetValue("Author", book.Name);//добавить поля для работы с бд.
        //            ObservableCollection.Add(dictionary);
        //        }
        //    }

        //}

        //todo

        private void InitGrid()
        {
            

            //for (var i = 0; i < 3; i++)
            //{

            //    var dictionary = new DynamicDictionary();
            //    dictionary.SetValue("Name", FirstNames[0]);
            //    dictionary.SetValue("Year", i.ToString(CultureInfo.InvariantCulture));
            //    dictionary.SetValue("Author", LastNames[0]);
            //    ObservableCollection2.Add(dictionary);
            //}
        }

        public void InitDrives()
        {
            TreeListControl.BeginDataUpdate();

            var tree = _makeMeHappy.GetTreeStatistic();
            try
            {
                var node = new TreeListNode { Content = VoodooConverts.ToContent(tree.Node), IsExpandButtonVisible = DefaultBoolean.True, Tag = false };
                if (tree.Childs != null && tree.Childs.Count > 0)
                {
                    this.SetNode(node, tree.Childs);
                }
                TreeVeiw.Nodes.Add(node);
            }
            catch (Exception aException)
            {
                MessageBox.Show(aException.Message);
            }
            TreeListControl.EndDataUpdate();
        }

        public void SetNode(TreeListNode nodeParent, List<CategoriesMultiList> list)
        {
            if (!list.Any(c => true))
            {
                return;
            }

            foreach (var multiList in list)
            {
                var node = new TreeListNode { Content = VoodooConverts.ToContent(multiList.Node), IsExpandButtonVisible = DefaultBoolean.True, Tag = false };
                nodeParent.Nodes.Add(node);
                
                if (multiList.Childs != null)
                {
                   this.SetNode(node, multiList.Childs);    
                }
            }
        }


        

        //public List<TreeStatistic> GetTreeStatistic()
        //{

        //    var treeStatisticAuthors1 = new TreeStatistic("Дмитрий Макарский", 10);
        //    var treeStatisticAuthors2 = new TreeStatistic("М. Ховард", 12);
        //    var treeStatisticAuthors3 = new TreeStatistic(" М. Леви", 11);
        //    var treeStatisticAuthors = new List<TreeStatistic> { treeStatisticAuthors1, treeStatisticAuthors2, treeStatisticAuthors3 };

        //    var treeStatistic1 = new TreeStatistic(treeStatisticAuthors, "Authors", 33);


        //    var treeStatisticGenre1 = new TreeStatistic("C", 30);
        //    var treeStatisticGenre2 = new TreeStatistic("C++", 40);
        //    var treeStatisticGenre3 = new TreeStatistic("Java", 50);
        //    var treeStatisticGenre = new List<TreeStatistic> { treeStatisticGenre1, treeStatisticGenre2, treeStatisticGenre3 };

        //    var treeStatistic2 = new TreeStatistic(treeStatisticGenre, "Genre", 120);

        //    var treeStatistic = new List<TreeStatistic> { treeStatistic1, treeStatistic2 };

        //    return treeStatistic;
        //}

        private new void MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var focusedNode = TreeVeiw.FocusedNode;
            if (TreeVeiw.FocusedNode.Level == 0)
            {
                return;
            }

            var parentName = focusedNode.ParentNode.Content.ToString();
            var name = focusedNode.Content.ToString();

            var str = parentName + " = \"" + name + "\", ";
            textEditor.Text += str;
        }


        private void GridBook_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            var focusedRow = GridBook.GetFocusedRow();
            var dynamicDictionary = (DynamicDictionary)focusedRow;          
        }

        private void SelectedItemChange(object sender, SelectedItemChangedEventArgs e)
        {
            //todo
            //GridBook.ItemsSource
            ObservableCollection.Clear();
            var books = _makeMeHappy.GetBooks();

            foreach (var book in books)
            {
                DynamicDictionary dictionary = VoodooConverts.ToDynamicDictionary(book);
                ObservableCollection.Add(dictionary);
            }
            GridBook.ItemsSource = ObservableCollection;
            
        }

        private void GridBook_OnSelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        
    }
}