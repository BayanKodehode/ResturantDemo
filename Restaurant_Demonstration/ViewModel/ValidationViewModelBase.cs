using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Demonstration.ViewModel
{
    public class ValidationViewModelBase : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errorsBasePropertyName = new();
        public bool HasErrors => _errorsBasePropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return propertyName is not null && _errorsBasePropertyName.ContainsKey(propertyName)
                ? _errorsBasePropertyName[propertyName]
                : Enumerable.Empty<string>();
        }

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        protected void AddError(string error,
            [CallerMemberName] string? propertyName = null)
        {
            if (propertyName is null)
            {
                return;
            }
            if (!_errorsBasePropertyName.ContainsKey(propertyName))
            {
                _errorsBasePropertyName[propertyName] = new List<string>();
            }

            if (_errorsBasePropertyName[propertyName].Contains(error)) return;
            _errorsBasePropertyName[propertyName].Add(error);
            OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
            RaisePropertyChanged(nameof(HasErrors));
        }

        protected void ClearErrors([CallerMemberName] string? propertyName = null)
        {
            if (propertyName is null)
            {
                return;
            }

            if (!_errorsBasePropertyName.ContainsKey(propertyName)) return;
            _errorsBasePropertyName.Remove(propertyName);
            OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
            RaisePropertyChanged(nameof(HasErrors));
        }
    }
}
