using Restaurant_Demonstration.Model;

namespace Restaurant_Demonstration.ViewModel
{
    public class CustomerItemViewModel : ValidationViewModelBase
    {
        private readonly Customer _customerModel;

        public CustomerItemViewModel(Customer model)
        {
            _customerModel = model;
        }

        public int Id => _customerModel.CustomerId;

        public string? FirstName
        {
            get => _customerModel.FirstName;
            set
            {
                _customerModel.FirstName = value;
                RaisePropertyChanged();
                if (string.IsNullOrEmpty(_customerModel.FirstName))
                {
                    AddError("Firstname is required");
                }
                else
                {
                    ClearErrors();
                }
            }
        }
        public string? LastName
        {
            get => _customerModel.LastName;
            set
            {
                _customerModel.LastName = value;
                RaisePropertyChanged();
            }
        }
        public bool Ordered
        {
            get => _customerModel.Ordered;
            set
            {
                _customerModel.Ordered = value;
                RaisePropertyChanged();
            }
        }
    }
}
