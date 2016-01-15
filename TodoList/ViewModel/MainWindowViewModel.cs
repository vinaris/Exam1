using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Data;
using Model;
using ViewModel.Annotations;

namespace ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private UserTask _selectedTask;

        public ObservableCollection<string> Groups { get; set; } = new ObservableCollection<string>
        {
            "Просроченные", "Скоро истекают"
        };

        public MainWindowViewModel()
        {
            TreeUserTasks = CollectionViewSource.GetDefaultView(UserTasks);
        }

        public static ObservableCollection<UserTask> UserTasks { get; set; } = new ObservableCollection<UserTask>
        {
            new UserTask
            {
                Name = "Встретить Новый Год",
                Description = "Новый год - это самое важное, что может быть в жизни. Как говорится: \"Как Новый Год встретишь, так его и проведёшь!\"",
                DueDate = new DateTime(2016, 1, 1),
                Group = "General",
                Status = TaskStatus.Complited
            },
            new UserTask
            {
                Name = "Сдать экзамен",
                DueDate = new DateTime(2016, 2, 16),
                Group = "University",
                Status = TaskStatus.New
            },
            new UserTask
            {
                Name = "Посмотреть Deadpool",
                Description = "1. Выбрать формат.\n2. Выбрать кинотеатр.\n3. Наслаждаться.",
                DueDate = new DateTime(2016, 2, 11),
                Group = "MyOwn",
                Status = TaskStatus.New
            },
            new UserTask
            {
                Name = "Написать бакалаврскую работу",
                Status = TaskStatus.InProgress,
                DueDate = new DateTime(2016, 6, 20),
                Group = "University"
            },
            new UserTask
            {
                Name = "Проверить домашки MITA",
                DueDate = new DateTime(2016, 2, 5),
                Group = "University",
                Status = TaskStatus.InProgress
            },
            new UserTask
            {
                Name = "Научиться кататься на сноуборде",
                Description = "Когда достаточно тепло и есть свободное време, то: \"Почему бы и нет?\"",
                DueDate = new DateTime(2016, 1, 20),
                Group = "MyOwn",
                Status = TaskStatus.Canceled
            }
        };

        public UserTask SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                if (Equals(value, _selectedTask)) return;
                _selectedTask = value;
                OnPropertyChanged();
            }
        }

        private bool _isCanceled;
        public bool IsCanceled
        {
            get { return _isCanceled; }
            set
            {
                if (value == _isCanceled) return;
                _isCanceled = value;
                OnPropertyChanged();
            }
        }
        private bool _isComplited;
        private ICollectionView _treeUserTasks;

        public bool IsComplited
        {
            get { return _isComplited; }
            set
            {
                if (value == _isComplited) return;
                _isComplited = value;
                OnPropertyChanged();
            }
        }

        //private bool TasksFilter(object obj)
        //{
        //    UserTask task = obj as UserTask;
        //    if (((MainWindowViewModel)DataContext).IsCanceled)
        //        return task != null && task.Status != TaskStatus.Complited;
        //}

        public ICollectionView TreeUserTasks    
        {
            get { return _treeUserTasks; }
            set
            {
                if (Equals(value, _treeUserTasks)) return;
                _treeUserTasks = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
