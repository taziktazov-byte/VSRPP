using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Lab06.Models;

namespace Lab06
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Person? _selectedPerson;

        public ObservableCollection<Person> People { get; } = new()
        {
            new Person { Name = "Артём Соколов", Age = 15, IsActive = true },
            new Person { Name = "Мария Иванова", Age = 24, IsActive = true },
            new Person { Name = "Дмитрий Петров", Age = 42, IsActive = false },
            new Person { Name = "Елена Смирнова", Age = 67, IsActive = true }
        };

        public Person? SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            SelectedPerson = People[0];
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
