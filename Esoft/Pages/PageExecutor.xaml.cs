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
    /// Логика взаимодействия для PageExecutor.xaml
    /// </summary>
    public partial class PageExecutor : Page
    {
        public PageExecutor()
        {
            InitializeComponent();
            var allTypes = z4_train_SokolovEntities2.GetContext().TaskStatus.ToList();
            allTypes.Insert(0, new AppDataFile.TaskStatus
            {
                Status = "Все типы"
            });
            ComboType.ItemsSource = allTypes;

            ComboType.SelectedIndex = 0;

            var currentTask = z4_train_SokolovEntities2.GetContext().Task.ToList();
            LViewExecutor.ItemsSource = currentTask;
        }

        private void UpdateExecutor()
        {
            var currentExecutor = z4_train_SokolovEntities2.GetContext().TaskStatus.ToList();

            //if (ComboType.SelectedIndex > 0)
            //    currentExecutor = currentExecutor.Where(p => p.Status.Contains(ComboType.SelectedItem as StatusTask)).ToList();

            currentExecutor = currentExecutor.Where(p => p.Status.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            LViewExecutor.ItemsSource = currentExecutor.OrderBy(p => p.Status).ToList();

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            HelpManager.MainFrame.GoBack();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateExecutor();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateExecutor();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var agentForRemoving = LViewExecutor.SelectedItems.Cast<Task>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {agentForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    z4_train_SokolovEntities2.GetContext().Task.RemoveRange(agentForRemoving);
                    z4_train_SokolovEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    LViewExecutor.ItemsSource = z4_train_SokolovEntities2.GetContext().Task.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            HelpManager.MainFrame.Navigate(new PageAddExecutor((sender as Button).DataContext as Task));
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Страница находится в разработке!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
