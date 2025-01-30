using EmployeeManagementSystem.Application;
using EmployeeManagementSystem.Application.Services;
using EmployeeManagementSystem.Domain.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using wpfEmployeeManagmentSystem.Presentation.ViewModels;

namespace EmployeeManagementSystem.Presentation.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        
        private readonly IGenericService<Employee> _employeeService;

       
        public MainWindowViewModel(IGenericService<Employee> employeeService)
        {
            _employeeService = employeeService;
            // Load employees on initialization
            //LoadEmployees();
        }

        private ObservableCollection<EmployeeViewModel> _employees;
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        private EmployeeViewModel _selectedEmployee;
        public EmployeeViewModel SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddEmployeeCommand => new RelayCommand(AddEmployee);

        //private void LoadEmployees()
        //{
        //    var employeeList = _employeeService.ListAllAsync(); // Fetch from Application Layer
        //    Employees = new ObservableCollection<EmployeeViewModel>(
        //        employeeList.Select(e => new EmployeeViewModel(e)));
        //}

        private void AddEmployee()
        {
            // Add new employee logic
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Simple RelayCommand implementation for ICommand
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object parameter) => _execute();

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
