using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Model;
using ViewModel.Annotations;

namespace ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private UserTask _selectedTask;

        public ObservableCollection<UserTask> UserTasks { get; set; } = new ObservableCollection<UserTask>
        {
            new UserTask
            {
                Name = "Встретить Новый Год",
                Description = "Новый год - это самое важное, что может быть в жизни. Как говорится: \"Как Новый Год встретишь, так его и проведёшь!\"",
                DueDate = new DateTime(2016, 1, 1)
            },
            new UserTask
            {
                Name = "Сдать экзамен",
                DueDate = new DateTime(2016, 2, 16)
            },
            new UserTask
            {
                Name = "Посмотреть Deadpool",
                Description = "1. Выбрать формат.\n2. Выбрать кинотеатр.\n3. Наслаждаться.",
                DueDate = new DateTime(2016, 2, 11)
            },
            new UserTask
            {
                Name = "Написать бакалаврскую работу",
                Status = TaskStatus.InProgress,
                DueDate = new DateTime(2016, 6, 20)
            },
            new UserTask
            {
                Name = "Проверить домашки MITA",
                DueDate = new DateTime(2016, 2, 5)
            },
            new UserTask
            {
                Name = "Научиться кататься на сноуборде",
                Description = "Когда достаточно тепло и есть свободное време, то: \"Почему бы и нет?\"",
                DueDate = new DateTime(2016, 1, 20)
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


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
