using System.ComponentModel;
using System.Windows.Input;
using TakeHomeAssessment.Views;

namespace TakeHomeAssessment.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// The amount of times the main button has been clicked.
    /// </summary>
    int count = 0;

    /// <summary>
    /// The current main button text.
    /// </summary>
    private string _buttonText = "Click me!";

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
    /// Gets and sets the main button text.
    /// </summary>
    public string ButtonText
    {
        get => this._buttonText;
        set
        {
            this._buttonText = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ButtonText)));
        }
    }

    /// <summary>
    /// Handle button event clicks by incrementing the count and updating the button text.
    /// </summary>
    private void ButtonClickedEventHandler()
    {
        this.count++;

        if (count == 1)
            this.ButtonText = $"Clicked {count} time";
        else
            this.ButtonText = $"Clicked {count} times";
    }

    /// <summary>
    /// This is the navigation to the quotes page. 
    /// </summary>
    private async Task NavigateToQuotes()
    {
        await Shell.Current.GoToAsync(nameof(QuotesPage));
    }
}
