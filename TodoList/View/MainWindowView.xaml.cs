using System.Windows;
using System.Windows.Controls;
using Model;
using ViewModel;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void ShowActiveGrid(GroupBox nameOfGroupBox)
        {
            NewTaskGroupBox.Visibility = Visibility.Hidden;
            SelectedTaskGroupBox.Visibility = Visibility.Hidden;
            NewGroupGroupBox.Visibility = Visibility.Hidden;
            nameOfGroupBox.Visibility = Visibility.Visible;
        }

        private void ClearControls()
        {
            NewNameTask.Text = null;
            NewDescriptionTask.Text = null;
            NewGroupTask.Text = null;
            NewDueDateTask.SelectedDate = null;
            NewNameGroup.Text = null;
        }

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // ((MainWindowViewModel)DataContext).SelectedTask = 
            var task = e.NewValue as UserTask;
            ShowActiveGrid(SelectedTaskGroupBox);
        }

        private void AddNewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewDueDateTask.SelectedDate != null && NewNameTask.Text != null && NewGroupTask.Text != null)
            {
                ((MainWindowViewModel) DataContext).AddNewTask(NewNameTask.Text, NewDescriptionTask.Text,
                    NewGroupTask.Text, NewDueDateTask.SelectedDate.Value);
                ClearControls();
                ShowActiveGrid(SelectedTaskGroupBox);
            }
        }

        private void CreateTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            ClearControls();
            ShowActiveGrid(NewTaskGroupBox);
        }

        private void AddNewGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewNameGroup.Text != null)
            {
                ((MainWindowViewModel) DataContext).Groups.Add(NewNameGroup.Text);
                ClearControls();
                ShowActiveGrid(SelectedTaskGroupBox);
            }
        }

        private void CreateGroupButton(object sender, RoutedEventArgs e)
        {
            ClearControls();
            ShowActiveGrid(NewGroupGroupBox);
        }

        private void CancelCreation(object sender, RoutedEventArgs e)
        {
            ShowActiveGrid(SelectedTaskGroupBox);
            ClearControls();
        }
    }
}
