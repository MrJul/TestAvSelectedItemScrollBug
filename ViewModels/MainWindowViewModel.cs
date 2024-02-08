using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestAvSelectedItemScrollBug.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string? _selectedItem;
    [ObservableProperty] private bool _isReady = true;

    public ObservableCollection<string> Items { get; } = new();

    [RelayCommand(CanExecute = nameof(IsReady))]
    public async Task LoadAsync()
    {
        IsReady = false;

        await Task.Delay(TimeSpan.FromSeconds(2.0));

        Items.Clear();
        for (int i = 1; i <= 100; ++i)
        {
            Items.Add(i.ToString());
        }

        SelectedItem = "50";
        IsReady = true;
    }

    [RelayCommand(CanExecute = nameof(IsReady))]
    public void Clear()
    {
        IsReady = false;
        SelectedItem = null;
        Items.Clear();
        IsReady = true;
    }
}
