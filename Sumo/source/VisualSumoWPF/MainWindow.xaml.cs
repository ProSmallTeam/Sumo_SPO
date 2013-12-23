using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DevExpress.Utils;
using DevExpress.Xpf.Grid;
using Sumo.API;

namespace VisualSumoWPF
{
    public partial class MainWindow : Window
    {
        private static readonly ObservableCollection<DynamicDictionary> ObservableCollection =
            new ObservableCollection<DynamicDictionary>();

        private readonly MakeMeHappy _makeMeHappy = new MakeMeHappy();

        /// <summary>
        ///     Конструктор окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Действия при загрузке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            InitDrives();

            GridBook.ItemsSource = ObservableCollection;
        }


        /// <summary>
        ///     Действия при нажатии кнопки добавления аудиторий
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


        public void InitDrives()
        {
            TreeListControl.BeginDataUpdate();

            CategoriesMultiList tree = _makeMeHappy.GetTreeStatistic();
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

            string parentName = focusedNode.ParentNode.Content.ToString();
            string name = focusedNode.Content.ToString();

            string str = parentName + " = \"" + name + "\", ";
            textEditor.Text += str;
        }


        private void GridBook_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            object focusedRow = GridBook.GetFocusedRow();
        }

        private void SelectedItemChange(object sender, SelectedItemChangedEventArgs e)
        {
            //todo
            //GridBook.ItemsSource
            ObservableCollection.Clear();
            List<Sumo.API.Book> books = _makeMeHappy.GetBooks();

            foreach (Sumo.API.Book book in books)
            {
                DynamicDictionary dictionary = _3dfxConverts.ToDynamicDictionary(book);
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