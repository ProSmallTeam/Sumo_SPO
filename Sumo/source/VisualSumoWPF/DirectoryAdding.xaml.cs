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
using FolderPickerLib;

namespace VisualSumoWPF
{
    /// <summary>
    /// Interaction logic for DirectoryAdding.xaml
    /// </summary>
    public partial class DirectoryAdding : Window
    {
        public DirectoryAdding()
        {
            InitializeComponent();
            DirectoriesList.Items.Add("Вы ничего не выбрали");
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dirDialog = new FolderPickerDialog();
            if (dirDialog.ShowDialog() != true) return;
            if (DirectoriesList.Items.Count == 1 && DirectoriesList.Items.Contains("Вы ничего не выбрали"))
                DirectoriesList.Items.Remove("Вы ничего не выбрали");
            DirectoriesList.Items.Add(dirDialog.SelectedPath);
        }

        private void MouseDouble_Click(object sender, MouseEventArgs e)
        {
            DirectoriesList.Items.Remove(DirectoriesList.SelectedItem);
            if (DirectoriesList.Items.Count == 0) DirectoriesList.Items.Add("Вы ничего не выбрали");
            
        }

    }
}
