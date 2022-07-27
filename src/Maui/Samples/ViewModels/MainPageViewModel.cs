using System.Windows.Input;

namespace Samples.ViewModels;

public class MainPageViewModel
{
    public MainPageViewModel()
    {
        SeeDocumentationCommand = new Command((url) =>
        {
            Launcher.OpenAsync(new System.Uri( "https://github.com/MicrosoftDocs/CommunityToolkit/tree/main/docs/maui/extensions/on-screen-size-extension.md"));
        });
    }

    public ICommand SeeDocumentationCommand { get; set; }

    
}