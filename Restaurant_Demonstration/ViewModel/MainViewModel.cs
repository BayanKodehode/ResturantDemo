using Restaurant_Demonstration.Command;
using System.Threading.Tasks;
using Restaurant_Demonstration.Model;
using Restaurant_Demonstration.Repositories;
using System;
using System.Windows;
using System.Threading;
using FontAwesome.Sharp;
using System.Windows.Input;
using Restaurant_Demonstration.View;

namespace Restaurant_Demonstration.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

        //Properties
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowProductsViewCommand { get; }
        public ICommand ShowSectionsTablesViewCommand { get; }


        public ViewModelBase? _selectedViewModel;
        public CustomerViewModel CustomerViewModel { get; }
        public ProductsViewModel ProductsViewModel { get; }
        public DelegateCommand SelectViewModelCommand { get; }

        public MainViewModel(CustomerViewModel customerViewModel,
            ProductsViewModel productsViewModel)
        {
            CustomerViewModel = customerViewModel;
            ProductsViewModel = productsViewModel;

            SelectedViewModel = CustomerViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);

            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }
        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged();
            }
        }
        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            //CurrentChildView = new CustomerViewModel();
            Caption = "Customers";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeViewCommand(object? obj)
        {
            //CurrentChildView = new mainView();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }
        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                //Hide child views.
            }
        }
    }
}
