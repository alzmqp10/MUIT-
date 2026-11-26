using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp2.ViewModel;

[QueryProperty(nameof(Text), "text")]
public partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    private string text = string.Empty;

    [RelayCommand]
    private async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
