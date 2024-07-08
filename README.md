# Relay UK Take Home Assessment

## Description

This is a barebones MAUI template for a project called "TakeHomeAssessment".

There are four tasks that need completing as part of this assessment. We would like you to provide a working solution that you have tested on two platforms, one mobile (Android or iOS) and one desktop (Windows or macOS).

The following has already been done for you:

- Views required have been created and placed in the `Views` folder
- Views have been registered with routing in `AppShell`
- View model bindings have been created and implemented for the `MainPage`, found in the `ViewModels` folder
- Models required have been created, found in the `Models` folder
- `Nullable` has been turned off, so you will not get warnings about null related issues

The template does not use any external nuget packages. Feel free to use them if you see fit. For example, you may want to use the [MAUI Community Toolkit](https://github.com/CommunityToolkit/Maui).

## Development

Please fork the repository and push your code to your fork. Feel free to use a different code hosting solution if you prefer it, such as GitLab.

Please commit your code after you have completed each task with the message of `Complete X task`, where X is the number of the task. You can make commits in between if you need to. If you commit a completed task and want to change it, please commit with the message `Complete X task update`, where X is the number of the task.

## Task One

Change the button in `MainPage` so that is no longer performs the click counting and instead navigates to the `QuotesPage`.

> The navigation has been defined in an unused method called `NavigateToQuotes` inside of the `MainPageViewModel`

## Task Two

Add an image towards the top of the `QuotesPage`.

Randomise the selection of image everytime you navigate to this page. The random choice should use one of the pre-bundled assets called `quote_image_one` or `quote_image_two` as the source of the image. Size it according to what you think is best per platform.

> The images are already registered in the application using the `Resources/Images` folder

## Task Three

Implement a button on the `QuotesPage`, below the image from task two, that fetches a random quote from the HTTP API provided. The button should have the following:

- Text of "Get Quote"
- A different background colour per platform (iOS, Android, WinUI, MacCatalyst)

When the quote has been fetched, show the quote content on the screen below the button you have added.

### Using the HTTP API

The API url to use is `https://zenquotes.io/api/random`. This will fetch a singular quote (in a list) that can be parsed into the `QuoteDTO` model. You are free to decide how to handle any errors that may occur.

> The mapping to convert the API structure to `QuoteDTO` is done for you using `System.Text.Json`.

No authentication or headers are required to use this API. It is rate limited at 5 requests per 30 seconds, per IP address.

If needed, documentation is available at [https://docs.zenquotes.io/zenquotes-documentation/](https://docs.zenquotes.io/zenquotes-documentation/).

## Task Four

Style the quote text from task three based on the following criteria:

**Font Styling**

- If the quote length is under 50 characters, no font styling should apply
- If the quote length is between 50-79 characters, the font styling should be underlined
- If the quote length is 80 characters or more, the font styling should be italic
- If the quote length is divisible by 3, the font styling should **always** be bold, with no other styling applied

**Text Colours**

- If the quote length is under 30 characters, the font colour should be black
- If the quote length is 30 or more characters, but less than or equal to 65, the font colour should be purple
- If the quote length is over 65 characters, but less than 100, the font colour should be red
- Anything else, the font colour should be blue
- If the quote length is divisible by 3, the font colour should **always** be green

> Due to a bug in .NET MAUI regarding label styling, a custom label handler replaces the default for iOS and MacCatalyst. This is already registered so you do not need to do anything as long as you use the `<Label>` control.

> Registered fonts from the default MAUI template have been removed from `MauiProgram` as they could cause issues with label styling.
