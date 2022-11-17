using Restaurant_Demonstration.Command;
using Restaurant_Demonstration.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Restaurant_Demonstration.Model;


namespace Restaurant_Demonstration.ViewModel
{
    //public class TablesViewModel : ViewModelBase
    //{

    //    private readonly ITablesDataProvider _TableDataProvider;
    //    private TablesItemsViewModel? _selectedTable;
    //    public TablesViewModel(ITablesDataProvider TablesDataProvider)
    //    {
    //        _TableDataProvider = TablesDataProvider;
    //        TableAddCommand = new DelegateCommand(AddTable);
    //        TableDeleteCommand = new DelegateCommand(DeleteTable, CanDeleteTable);
    //    }
    //    public ObservableCollection<TablesItemsViewModel> Table { get; } = new();
    //    public TablesItemsViewModel? SelectedTable
    //    {
    //        get => _selectedTable;
    //        set
    //        {
    //            _selectedTable = value;
    //            RaisePropertyChanged();
    //            RaisePropertyChanged(nameof(IsTableSelected));
    //            TableDeleteCommand.RaiseCanExecuteChanged();
    //        }
    //    }
    //    public bool IsTableSelected => SelectedTable is not null;
    //    public DelegateCommand TableAddCommand { get; }
    //    public DelegateCommand TableDeleteCommand { get; }
    //    public override async Task LoadAsync()
    //    {
    //        if (Table.Any())
    //        {
    //            return;
    //        }
    //        var Tables = await _TableDataProvider.GetAllAsync();
    //        if (Tables is not null)
    //        {
    //            foreach (var Table in Tables)
    //            {
    //                this.Table.Add(new TablesItemsViewModel(Table));
    //            }
    //        }
    //    }
    //    private void AddTable(object? parameter)
    //    {
    //        var Table = new Table { TableName = "New Table" };
    //        var TableViewModel = new TablesItemsViewModel(Table);  //note shure if its section or sections
    //        this.Table.Add(TableViewModel);
    //        SelectedTable = TableViewModel;
    //    }
    //    private void DeleteTable(object? parameter)
    //    {
    //        if (SelectedTable is null) return;
    //        Table.Remove(SelectedTable);
    //        SelectedTable = null;
    //    }
    //    private bool CanDeleteTable(object? parameter) => SelectedTable is not null;

    //}

}
