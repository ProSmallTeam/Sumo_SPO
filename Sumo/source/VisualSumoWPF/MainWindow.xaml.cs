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

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            if (IsFirstLaunch())
            {
                var addForm = new DirectoryAdding(true);
                addForm.ShowDialog();
                if (addForm.DialogResult != true) Close();
            }
            InitializeComponent();
        }

        private DataBase _database;

        private static readonly string[] FirstNames = new string[] {"Firstbook", "Secondbook", "Thirdbook"};
        static readonly string[] LastNames = new string[] {"Dodsworth", "Smith", "Miller"};
        
        static ObservableCollection<DynamicDictionary> ObservableCollection1 = new ObservableCollection<DynamicDictionary>();
        static ObservableCollection<DynamicDictionary> ObservableCollection2 = new ObservableCollection<DynamicDictionary>();

        private bool IsFirstLaunch()
        {
            return true;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            webBrouser.Navigate("http://www.ozon.ru/?context=search&text=978-5-17-079349-5&group=div_book");


            InitGrid();
            //InitGridDatabase();

            this.InitDrives();
            GridBook.ItemsSource = ObservableCollection1;
            Show();                                   
        }

        private void InitGridDatabase()
        {
            _database = new DataBase("mongodb://localhost/?safe=true");
            string str = "s";
            if (_database.GetBooksByAttrId(new List<int> { 69 }) != null)
            {
                foreach (var book in _database.GetBooksByAttrId(new List<int> { 69 }))
                {
                    var dictionary = new DynamicDictionary();
                    dictionary.SetValue("Name", book.Name);
                    dictionary.SetValue("Year", book.Name);//добавить поля для работы с бд.
                    dictionary.SetValue("Author", book.Name);//добавить поля для работы с бд.
                    ObservableCollection1.Add(dictionary);
                }
            }

        }

        private static void InitGrid()
        {
            for (var i = 0; i < 3; i++)
            {

                var dictionary = new DynamicDictionary();
                dictionary.SetValue("Name", FirstNames[i]);
                dictionary.SetValue("Year", i.ToString(CultureInfo.InvariantCulture));
                dictionary.SetValue("Author", LastNames[i]);
                ObservableCollection1.Add(dictionary);
            }

            for (var i = 0; i < 3; i++)
            {

                var dictionary = new DynamicDictionary();
                dictionary.SetValue("Name", FirstNames[0]);
                dictionary.SetValue("Year", i.ToString(CultureInfo.InvariantCulture));
                dictionary.SetValue("Author", LastNames[0]);
                ObservableCollection2.Add(dictionary);
            }
        }


        public void SetNode(TreeListNode nodeParent, List<TreeStatistic> list)
        {
            if (!list.Any(c => true))
            {
                return;
            }
            foreach (var statistic in list)
            {
                var node = new TreeListNode { Content = statistic, IsExpandButtonVisible = DefaultBoolean.True, Tag = false };
                nodeParent.Nodes.Add(node);
                
                if (statistic.list != null)
                {
                    this.SetNode(node, statistic.list);    
                }
            }
        }

        public void InitDrives()
        {
            TreeListControl.BeginDataUpdate();
            
            var treeList = this.GetTreeStatistic();
            try
            {
                foreach (var list in treeList)
                {
                    var node = new TreeListNode { Content = list, IsExpandButtonVisible = DefaultBoolean.True, Tag = false };

                    if (list.list != null)
                    {
                        this.SetNode(node, list.list);
                    }
                    TreeVeiw.Nodes.Add(node);
                }
            }
            catch (Exception aException)
            {
                MessageBox.Show(aException.Message);
            }
            TreeListControl.EndDataUpdate();
        }

        public List<TreeStatistic> GetTreeStatistic()
        {

            var treeStatisticAuthors1 = new TreeStatistic("Дмитрий Макарский", 10);
            var treeStatisticAuthors2 = new TreeStatistic("М. Ховард", 12);
            var treeStatisticAuthors3 = new TreeStatistic(" М. Леви", 11);
            var treeStatisticAuthors = new List<TreeStatistic> { treeStatisticAuthors1, treeStatisticAuthors2, treeStatisticAuthors3 };

            var treeStatistic1 = new TreeStatistic(treeStatisticAuthors, "Authors", 33);


            var treeStatisticGenre1 = new TreeStatistic("C", 30);
            var treeStatisticGenre2 = new TreeStatistic("C++", 40);
            var treeStatisticGenre3 = new TreeStatistic("Java", 50);
            var treeStatisticGenre = new List<TreeStatistic> { treeStatisticGenre1, treeStatisticGenre2, treeStatisticGenre3 };

            var treeStatistic2 = new TreeStatistic(treeStatisticGenre, "Genre", 120);

            var treeStatistic = new List<TreeStatistic> { treeStatistic1, treeStatistic2 };

            return treeStatistic;
            //{

            //   "Дмитрий Макарский", "М. Ховард", " М. Леви", "Р. Вэймир", "Г. Шмерлинг", "Трев Уилкинс", "В. А. Жарков", "Йен Маклин", "Орин Томас",
            //   "Джон Гудсон", "Бен Харвелл", "Бен Харвелл", "Том Уайт", "Евгения Пастернак", "Марина Виннер", "Майкл Фриман", "Кристиан Уэнц",
            //   "Мэтью Мак-Дональд", "Д. Н. Колисниченко", "Андрей Грачев"

            //}


            //var nameBook = new[]
            //                   {
            //                       "C", "C++", "C#", "Java", "PHP", "JavaScript", "Assembler", "AutoCAD Civil 3D 2013. Официальный учебный курс", "25 этюдов о шифрах",
            //                       "Яндекс Воложа. История создания компании мечты", "Изучаем HTML, XHTML", " Самоучитель работы на ПК для всех",
            //                       "Журнал CHIP, сентябрь №9/2013", "Интернет-программирование на Java", "Компьютер для женщин"
            //                   };



        }



        private void AddDirectoriesClick(object sender, RoutedEventArgs e)
        {
            
            Hide();
            var dictionary = new DynamicDictionary();
            dictionary.SetValue("Name", "Andrew");
            dictionary.SetValue("Year", "2003");
            dictionary.SetValue("Author", "McCormic");
            ObservableCollection1.Add(dictionary);
            ObservableCollection2.Add(dictionary);
            var addForm = new DirectoryAdding(false);
            addForm.ShowDialog();
            Show();
            if (addForm.DialogResult != true) Close();
        }

        private void GridBook_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            var focusedRow = GridBook.GetFocusedRow();
            var dynamicDictionary = (DynamicDictionary)focusedRow;          
        }

        private void MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var focusedNode = TreeVeiw.FocusedNode;
            if (TreeVeiw.FocusedNode.Level == 0)
            {
                return;
            }

            var parentName = ((TreeStatistic)focusedNode.ParentNode.Content).Name;
            var name = ((TreeStatistic)focusedNode.Content).Name;

            var str = parentName + " = \"" + name + "\", ";
            //ищем подстроку.
            //if ()
            //{
                
            //}
            textEditor.Text += str;          
        }

        private void SelectedItemChange(object sender, SelectedItemChangedEventArgs e)
        {
            this.GridBook.ItemsSource = this.GridBook.ItemsSource == ObservableCollection1 ? ObservableCollection2 : ObservableCollection1;
        }
    }
}