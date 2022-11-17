using Restaurant_Demonstration.Model;

namespace Restaurant_Demonstration.ViewModel
{
    public class SectionsItemsViewModel : ValidationViewModelBase
    {
        private readonly Section _sectionModel;

        public SectionsItemsViewModel(Section model)
        {
            _sectionModel = model;
        }

        public int SectionId => _sectionModel.SectionId;

        public string? SectionName
        {
            get => _sectionModel.SectionName;
            set
            {
                _sectionModel.SectionName = value;
                RaisePropertyChanged();
                if (string.IsNullOrEmpty(_sectionModel.SectionName))
                {
                    AddError("Section name is required");
                }
                else
                {
                    ClearErrors();
                }
            }
        }
        public bool SectionAvaliblity
        {
            get => _sectionModel.Avaliblity;
            set
            {
                _sectionModel.Avaliblity = value;
                RaisePropertyChanged();
            }
        }
    }
}
