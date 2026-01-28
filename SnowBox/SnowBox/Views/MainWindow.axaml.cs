using System.Runtime.InteropServices;
using Avalonia.Controls;

namespace SnowBox.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // Setup platform-specific window chrome
        SetupPlatformSpecificChrome();
    }

    private void SetupPlatformSpecificChrome()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            // macOS: Use native title bar with traffic lights (red/yellow/green buttons)
            // System will automatically handle theme colors
            ExtendClientAreaToDecorationsHint = false;
            ExtendClientAreaChromeHints = Avalonia.Platform.ExtendClientAreaChromeHints.Default;
            
            // Hide custom title bar on macOS
            var titleBar = this.FindControl<Controls.Window.CustomTitleBar>("TitleBar");
            if (titleBar != null)
            {
                titleBar.IsVisible = false;
            }
            
            // Adjust main content to fill the space
            var mainGrid = this.FindControl<Grid>("MainGrid");
            if (mainGrid != null)
            {
                mainGrid.RowDefinitions.Clear();
                mainGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            // Linux: Use native window decorations
            // System will automatically handle theme colors
            ExtendClientAreaToDecorationsHint = false;
            ExtendClientAreaChromeHints = Avalonia.Platform.ExtendClientAreaChromeHints.Default;
            
            // Hide custom title bar on Linux
            var titleBar = this.FindControl<Controls.Window.CustomTitleBar>("TitleBar");
            if (titleBar != null)
            {
                titleBar.IsVisible = false;
            }
            
            // Adjust main content to fill the space
            var mainGrid = this.FindControl<Grid>("MainGrid");
            if (mainGrid != null)
            {
                mainGrid.RowDefinitions.Clear();
                mainGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));
            }
        }
        else
        {
            // Windows: Use custom title bar (already set in AXAML)
            // System will automatically handle theme colors
            ExtendClientAreaToDecorationsHint = true;
            ExtendClientAreaChromeHints = Avalonia.Platform.ExtendClientAreaChromeHints.NoChrome;
        }
    }
}