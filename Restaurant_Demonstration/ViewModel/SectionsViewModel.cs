using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Restaurant_Demonstration.Command;
using Restaurant_Demonstration.Data;
using Restaurant_Demonstration.Model;

namespace Restaurant_Demonstration.ViewModel
{
    public class SectionsViewModel : ViewModelBase
    {
        private readonly ISectionsDataProvider _SectionsDataProvider;
        private SectionsItemsViewModel? _selectedSection;
        public SectionsViewModel(ISectionsDataProvider sectionsDataProvider)
        {
            _SectionsDataProvider = sectionsDataProvider;
            SectionAddCommand = new DelegateCommand(AddSection);
            SectionDeleteCommand = new DelegateCommand(DeleteSection, CanDeleteSection);
        }
        public ObservableCollection<SectionsItemsViewModel> Section { get; } = new();
        public SectionsItemsViewModel? SelectedSection
        {
            get => _selectedSection;
            set
            {
                _selectedSection = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsSectionSelected));
                SectionDeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public bool IsSectionSelected => SelectedSection is not null;
        public DelegateCommand SectionAddCommand { get; }
        public DelegateCommand SectionDeleteCommand { get; }
        public override async Task LoadAsync()
        {
            if (Section.Any())
            {
                return;
            }
            var Sections = await _SectionsDataProvider.GetAllAsync();
            if (Sections is not null)
            {
                foreach (var Section in Sections)
                {
                    this.Section.Add(new SectionsItemsViewModel(Section));
                }
            }
        }
        private void AddSection(object? parameter)
        {
            var Section = new Section { SectionName = "New Section" };
            var SectionViewModel = new SectionsItemsViewModel(Section);  
            this.Section.Add(SectionViewModel);
            SelectedSection = SectionViewModel;
        }
        private void DeleteSection(object? parameter)
        {
            if (SelectedSection is null) return;
            Section.Remove(SelectedSection);
            SelectedSection = null;
        }
        private bool CanDeleteSection(object? parameter) => SelectedSection is not null;
    }
}
