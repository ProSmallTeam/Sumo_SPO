using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DevExpress.Utils;
using DevExpress.Xpf.Grid;
using Sumo.Api;

namespace SumoViewer
{
    public partial class MainWindow : Window
    {
        private static readonly ObservableCollection<DynamicDictionary> ObservableCollection =
            new ObservableCollection<DynamicDictionary>();

        private readonly MetaManagerFacade _metaManagerFacade;

        /// <summary>
        ///     Конструктор окна
        /// </summary>
        public MainWindow(MetaManagerFacade metaManagerFacade)
        {
            _metaManagerFacade = metaManagerFacade;
            InitializeComponent();
        }

        /// <summary>
        ///     Действия при загрузке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
          //  SelectedItemChange(this, (SelectedItemChangedEventArgs)new object());
            
            InitDrives();

            GridBook.ItemsSource = ObservableCollection;
        }

        private void GetNewBooks()
        {
            ObservableCollection.Clear();
            List<Sumo.Api.Book> books = _metaManagerFacade.GetBooks();

            foreach (Sumo.Api.Book book in books)
            {
                DynamicDictionary dictionary = _3dfxConverts.ToDynamicDictionary(book);
                ObservableCollection.Add(dictionary);
            }
            GridBook.ItemsSource = ObservableCollection;
        }


        private void AddDirectoriesClick(object sender, RoutedEventArgs e)
        {
            Hide();
            var addForm = new DirectoryAdding(false);
            addForm.ShowDialog();
            Show();
            if (addForm.DialogResult != true) Close();
        }


        public void InitDrives()
        {
            TreeListControl.BeginDataUpdate();

            TreeVeiw.Nodes.Clear();
            CategoriesMultiList tree = _metaManagerFacade.GetTreeStatistic();
            try
            {
                var node = new TreeListNode
                {
                    Content = _3dfxConverts.ToContent(tree.Node),
                    IsExpandButtonVisible = DefaultBoolean.True,
                    Tag = false
                };

                if (tree.Childs != null && tree.Childs.Count > 0)
                {
                    SetNode(node, tree.Childs);
                }
                TreeVeiw.Nodes.Add(node);
            }
            catch (Exception aException)
            {
                MessageBox.Show(aException.Message);
            }
            TreeListControl.EndDataUpdate();
            WebBrowser.NavigateToString(BookToHtml(null));
        }

        private string BookToHtml(Book book)
        {
            var result = "<html><head>" +
                        "<meta http-equiv=\"Content-Type\"  content=\"text/html; charset=utf-8\" />" +
                         "<style type=\"text/css\"> " +
                         ".title{ font-weight: bold;} " +
                         ".text{ float:right }" +
                         ".image{ float: left; margin-right: 10px; margin-bottom: 20px; width 180px}" +
                         ".main_info{ width: 400px}.text{ word-wrap: break-word }" +
                         "</style></head>";
            result += "<body width=\"600px\"><h1>"
                //+ book.Name
                      + "Имя книги:" +
                      "<br/>  the interest book";
            // + "</h1><div ><div class=\"image\"><img src=\"" +
            //      "http://my-poker-life.ucoz.ru/asdasda.jpg\"></div>";

            var content = "";
            //if (book.SecondaryFields.ContainsKey("Содержание"))
            //{
            //    var contentList = book.SecondaryFields["Содержание"];
            //    content = contentList.Aggregate(content, (current, s) => current + s + "<br/><br/>");
            //    book.SecondaryFields.Remove("Содержание");
            //}
            //else content = "Отсутствует";

            result += "<div class=\"main_info\">";

            //foreach (var tag in book.SecondaryFields)
            //{
            //    result += "<span class=\"title\">" + tag.Key + ": </span><br/>";
            //    foreach (var value in tag.Value)
            //    {
            //        result += "<span class=\"text\">" + value + "</span><br/>";
            //    }
            //}


            result += "</div>";
            result += "</div><div class=\"content\" style=\"clear: both\"><h2>Описание</h2><span>" +
                //content + 
                      "</span></div >";

            result += "</div></body></html>";


            return result;
        } 

        public void SetNode(TreeListNode nodeParent, List<CategoriesMultiList> list)
        {
            if (!list.Any(c => true))
            {
                return;
            }

            foreach (CategoriesMultiList multiList in list)
            {
                var node = new TreeListNode
                {
                    Content = _3dfxConverts.ToContent(multiList.Node),
                    IsExpandButtonVisible = DefaultBoolean.True,
                    Tag = false
                };
                nodeParent.Nodes.Add(node);

                if (multiList.Childs != null)
                {
                    SetNode(node, multiList.Childs);
                }
            }
        }


        private new void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeListNode focusedNode = TreeVeiw.FocusedNode;
            if (TreeVeiw.FocusedNode.Level == 0)
            {
                return;
            }

            //string parentName = focusedNode.ParentNode.Content.ToString();
            //string name = focusedNode.Content.ToString();

            var q = (_3dfxConverts._3dfxContent) focusedNode.Content;
            string s = q.Node.Name;

            //string str = parentName + " = \"" + name + "\", ";

            if (!String.IsNullOrEmpty(textEditor.Text))
            {
                textEditor.Text +=", ";
            }

            textEditor.Text += s;

        }


        private void GridBook_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
        }

        private void SelectedItemChange(object sender, SelectedItemChangedEventArgs e)
        {
            GetNewBooks();
        }

        private void GridBook_OnSelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _metaManagerFacade.SetQuery(textEditor.Text);
            
            GetNewBooks();
            InitDrives();
        }

        private void AddBookClick(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dlg = new Microsoft.Win32.OpenFileDialog();

            // Show open file dialog box
            var result = dlg.ShowDialog();

            string filename = string.Empty;
            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
            }

            Trace.WriteLine(filename);

        }
    }
}