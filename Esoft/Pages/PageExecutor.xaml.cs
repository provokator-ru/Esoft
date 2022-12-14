using Esoft.AppDataFile;
using Esoft.Helper;
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

namespace Esoft.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageExecutor.xaml
    /// </summary>
    public partial class PageExecutor : Page
    {
        public PageExecutor()
        {
            InitializeComponent();
            var currentTask = z4_train_SokolovEntities1.GetContext().Task.ToList();
            LViewExecutor.ItemsSource = currentTask;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            HelpManager.MainFrame.GoBack();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
