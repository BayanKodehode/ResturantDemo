using Restaurant_Demonstration.Command;
using Restaurant_Demonstration.Data;
using Restaurant_Demonstration.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Restaurant_Demonstration.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly ICustomersDataProvider _customersDataProvider;
        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomerViewModel(ICustomersDataProvider customersDataProvider)
        {
            _customersDataProvider = customersDataProvider;
            CustomerAddCommand = new DelegateCommand(AddCustomer);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            CustomerDeleteCommand = new DelegateCommand(DeleteCustomer, CanDeleteCustomer);
        }
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsCustomerSelected));
                CustomerDeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public bool IsCustomerSelected => SelectedCustomer is not null;
        public NavigationSide NavigationSide
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand CustomerAddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand CustomerDeleteCommand { get; }
        public override async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }
            var customers = await _customersDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }
        private void AddCustomer(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }
        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSide.Left
                ? NavigationSide.Right
                : NavigationSide.Left;
        }
        private void DeleteCustomer(object? parameter)
        {
            if (SelectedCustomer is null) return;
            Customers.Remove(SelectedCustomer);
            SelectedCustomer = null;
        }
        private bool CanDeleteCustomer(object? parameter) => SelectedCustomer is not null;
    }
    public enum NavigationSide
    {
        Left,
        Right,
    }
}
