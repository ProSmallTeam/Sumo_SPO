using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FolderPickerLib;

namespace SumoViewer
{
    /// <summary>
    /// Interaction logic for DirectoryAdding.xaml
    /// </summary>
    public partial class DirectoryAdding
    {
        public DirectoryAdding(bool isFirstLaunch)
        {
            InitializeComponent();
            if (isFirstLaunch) AddLabelTitle.Content = "Добро пожаловать в SUMO - лучший поисковик информации о ваших книгах!";
            DirectoriesList.Items.Add("Выберите директории, где лежат ваши книги");
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dirDialog = new FolderPickerDialog();
            if (dirDialog.ShowDialog() != true) return;

            
            if (DirectoriesList.Items.Cast<object>().Any(item => item.ToString() == dirDialog.SelectedPath))
            {
                return;
            }

            if (DirectoriesList.Items.Count == 1 && DirectoriesList.Items.Contains("Выберите директории, где лежат ваши книги"))
                DirectoriesList.Items.Remove("Выберите директории, где лежат ваши книги");
            DirectoriesList.Items.Add(dirDialog.SelectedPath);
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DirectoriesList.SelectedItems.Count == 0) return;
            DirectoriesList.Items.Remove(DirectoriesList.SelectedItem);
            if (DirectoriesList.Items.Count == 0) DirectoriesList.Items.Add("Выберите директории, где лежат ваши книги");
        }

    }
}
