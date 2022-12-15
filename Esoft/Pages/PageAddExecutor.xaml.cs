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
using Task = Esoft.AppDataFile.Task;

namespace Esoft.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddExecutor.xaml
    /// </summary>
    public partial class PageAddExecutor : Page
    {
        private Task _currentTask = new Task();

        public PageAddExecutor(Task selectedTask)
        {
            InitializeComponent();

            if (selectedTask != null)
                _currentTask = selectedTask;

            DataContext = _currentTask;
            ComboStatus.ItemsSource = z4_train_SokolovEntities2.GetContext().TaskStatus.ToList();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentTask.Title))
                errors.AppendLine("Укажите название задания");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentTask.ID == 0)
                z4_train_SokolovEntities2.GetContext().Task.Add(_currentTask);


            try
            {
                z4_train_SokolovEntities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                HelpManager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            HelpManager.MainFrame.GoBack();
        }

       
    }
}
