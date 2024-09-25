using System.ComponentModel;
using System.Windows.Input;
using TakeHomeAssessment.Views;

namespace TakeHomeAssessment.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    public MainPageViewModel()
    {
        this.ButtonClickedCommand = new Command(this.ButtonClickedEventHandler);
    }

    /// <inheritdoc/>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Gets the command handler for the main button click.
    /// </summary>
    public ICommand ButtonClickedCommand { get; init; }

    /// <summary>
    /// Handle button event clicks by incrementing the count and updating the button text.
    /// </summary>
    private async void ButtonClickedEventHandler()
    {
        await this.NavigateToQuotes();
    }

    /// <summary>
    /// This is the navigation to the quotes page. 
    /// </summary>
    private async Task NavigateToQuotes()
    {
        await Shell.Current.GoToAsync(nameof(QuotesPage));
    }
}
