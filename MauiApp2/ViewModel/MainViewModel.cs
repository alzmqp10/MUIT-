using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking;

namespace MauiApp2.ViewModel;

public partial class MainViewModel : ObservableObject
{
    private readonly IConnectivity connectivity;

    public MainViewModel(IConnectivity connectivity)
    {
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    private string text = string.Empty;

    [ObservableProperty]
    private ObservableCollection<string> items = new();

    [RelayCommand]
    private async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlertAsync("No Internet", "You are not connected to the internet", "OK");
            return;
        }

        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    private void Delete(string s)
    {
        if (Items.Contains(s))
            Items.Remove(s);
    }

    [RelayCommand]
    private async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?text={Uri.EscapeDataString(s)}");
    }
}
