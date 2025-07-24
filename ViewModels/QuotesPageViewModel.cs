using System.ComponentModel;
using System.Text.Json;
using System.Windows.Input;
using TakeHomeAssessment.Models;

namespace TakeHomeAssessment.ViewModels;

public class QuotesPageViewModel : INotifyPropertyChanged
{
    private readonly HttpClient _httpClient = new();

    private string _quoteText;
    public string QuoteText
    {
        get => _quoteText;
        set
        {
            if (_quoteText != value)
            {
                _quoteText = value;
                OnPropertyChanged(nameof(QuoteText));
            }
        }
    }

    private string _quoteAuthor;
    public string QuoteAuthor
    {
        get => _quoteAuthor;
        set
        {
            if (_quoteAuthor != value)
            {
                _quoteAuthor = value;
                OnPropertyChanged(nameof(QuoteAuthor));
            }
        }
    }

    private FontAttributes _quoteFontAttributes = FontAttributes.None;
    public FontAttributes QuoteFontAttributes
    {
        get => _quoteFontAttributes;
        set
        {
            if (_quoteFontAttributes != value)
            {
                _quoteFontAttributes = value;
                OnPropertyChanged(nameof(QuoteFontAttributes));
            }
        }
    }

    private TextDecorations _quoteTextDecorations = TextDecorations.None;
    public TextDecorations QuoteTextDecorations
    {
        get => _quoteTextDecorations;
        set
        {
            if (_quoteTextDecorations != value)
            {
                _quoteTextDecorations = value;
                OnPropertyChanged(nameof(QuoteTextDecorations));
            }
        }
    }

    private Color _quoteTextColor = Colors.Black;
    public Color QuoteTextColor
    {
        get => _quoteTextColor;
        set
        {
            if (_quoteTextColor != value)
            {
                _quoteTextColor = value;
                OnPropertyChanged(nameof(QuoteTextColor));
            }
        }
    }

    private Color _backgroundColour = Colors.White;
    public Color BackgroundColour
    {
        get => _backgroundColour;
        set
        {
            if (_backgroundColour != value)
            {
                _backgroundColour = value;
                OnPropertyChanged(nameof(BackgroundColour));
            }
        }
    }

    public ICommand GetQuoteCommand { get; }

    public QuotesPageViewModel()
    {
        GetQuoteCommand = new Command(async () => await GetQuoteAsync(CancellationToken.None));
    }

    public async Task GetQuoteAsync(CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.GetStringAsync("https://zenquotes.io/api/random", cancellationToken);
            var quotes = JsonSerializer.Deserialize<List<QuoteDTO>>(response);
            var quote = quotes?.FirstOrDefault();

            QuoteText = quote.Content;
            
            int length = quote.Content.Length;
            ApplyFontStyling(length);
            ApplyTextColours(length);
            ApplyAuthorModifications(quote.Author);

        }
        catch (HttpRequestException ex)
        {
            QuoteText = $"Network error: {ex.Message}";
        }
        catch (TaskCanceledException ex)
        {
            QuoteText = $"The request timed out. Please try again. {ex.Message}";
        }
        catch (JsonException ex)
        {
            QuoteText = $"Error parsing quote data: {ex.Message}";
        }
        catch (OperationCanceledException ex)
        {
            QuoteText = $"Quote fetching was canceled. {ex.Message}";
        }
        catch (Exception ex)
        {
            QuoteText = $"An unexpected error occurred: {ex.Message}";
        }
    }

    public void ApplyFontStyling(int length)
    {
        QuoteTextDecorations = TextDecorations.None;

        //The quote length is divisible by 3, the font styling should always be bold, with no other styling applied
        if (length % 3 == 0)
        {
            QuoteFontAttributes = FontAttributes.Bold;
        }
        else
        {
            switch (length)
            {
                //no font styling should apply
                case < 50:
                    QuoteFontAttributes = FontAttributes.None;
                    break;
                //the font styling should be underlined
                case < 80:
                    QuoteTextDecorations = TextDecorations.Underline;
                    break;
                //the font styling should be italic
                default:
                    QuoteFontAttributes = FontAttributes.Italic;
                    break;
            }
        }
    }

    public void ApplyAuthorModifications(string author)
    {
        if (author.Contains(' ')){
            author = author.ToUpper();
            BackgroundColour = Colors.White;
        }
        else
        {
            BackgroundColour = Colors.Green;
        }
        QuoteAuthor = author;
    }

    public void ApplyTextColours(int length)
    {
        //The quote length is divisible by 3, the font colour should always be green
        if (length % 3 == 0)
        {
            QuoteTextColor = Colors.Green;
        }
        else
        {
            switch (length)
            {
                case < 30:
                    QuoteTextColor = Colors.Black;
                    break;
                case <= 65:
                    QuoteTextColor = Colors.Purple;
                    break;
                case < 100:
                    QuoteTextColor = Colors.Red;
                    break;
                default:
                    QuoteTextColor = Colors.Blue;
                    break;
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
