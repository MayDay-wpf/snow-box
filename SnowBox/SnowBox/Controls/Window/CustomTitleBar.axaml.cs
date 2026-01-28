using System.Linq;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;

namespace SnowBox.Controls.Window;

public partial class CustomTitleBar : UserControl
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<CustomTitleBar, string>(nameof(Title), "SnowBox");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public CustomTitleBar()
    {
        InitializeComponent();
        
        // Bind Title property to TextBlock
        this.PropertyChanged += (s, e) =>
        {
            if (e.Property == TitleProperty)
            {
                var titleTextBlock = this.FindControl<TextBlock>("TitleTextBlock");
                if (titleTextBlock != null)
                {
                    titleTextBlock.Text = Title;
                }
            }
        };
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        
        var window = this.FindLogicalAncestorOfType<Avalonia.Controls.Window>();
        if (window != null)
        {
            SetupWindowControls(window);
            SetupDraggableTitleBar(window);
            
            // Update maximize icon when window state changes
            window.PropertyChanged += (s, ev) =>
            {
                if (ev.Property == Avalonia.Controls.Window.WindowStateProperty)
                {
                    UpdateMaximizeIcon(window);
                }
            };
            
            // Initial icon update
            UpdateMaximizeIcon(window);
        }
    }

    private void SetupWindowControls(Avalonia.Controls.Window window)
    {
        // Minimize button
        var minimizeButton = this.FindControl<Button>("MinimizeButton");
        if (minimizeButton != null)
        {
            minimizeButton.Click += (s, e) => window.WindowState = WindowState.Minimized;
        }

        // Maximize/Restore button
        var maximizeButton = this.FindControl<Button>("MaximizeButton");
        if (maximizeButton != null)
        {
            maximizeButton.Click += (s, e) =>
            {
                window.WindowState = window.WindowState == WindowState.Maximized 
                    ? WindowState.Normal 
                    : WindowState.Maximized;
                UpdateMaximizeIcon(window);
            };
        }

        // Close button
        var closeButton = this.FindControl<Button>("CloseButton");
        if (closeButton != null)
        {
            closeButton.Click += (s, e) => window.Close();
        }
    }

    private void SetupDraggableTitleBar(Avalonia.Controls.Window window)
    {
        // Find the draggable area (Grid.Column="1" in title bar)
        var titleBar = this.FindControl<Grid>("TitleBar");
        if (titleBar != null)
        {
            var draggableArea = titleBar.Children
                .OfType<Border>()
                .FirstOrDefault(b => Grid.GetColumn(b) == 1);
            
            if (draggableArea != null)
            {
                draggableArea.PointerPressed += (s, e) =>
                {
                    if (e.GetCurrentPoint(window).Properties.IsLeftButtonPressed)
                    {
                        window.BeginMoveDrag(e);
                    }
                };

                // Double-click to maximize/restore
                draggableArea.DoubleTapped += (s, e) =>
                {
                    window.WindowState = window.WindowState == WindowState.Maximized 
                        ? WindowState.Normal 
                        : WindowState.Maximized;
                };
            }
        }
    }

    private void UpdateMaximizeIcon(Avalonia.Controls.Window window)
    {
        var maximizeIcon = this.FindControl<Avalonia.Controls.Shapes.Path>("MaximizeIcon");
        if (maximizeIcon != null)
        {
            // Change icon based on window state
            maximizeIcon.Data = window.WindowState == WindowState.Maximized
                ? Avalonia.Media.Geometry.Parse("M 0,2 L 0,10 L 8,10 L 8,2 Z M 2,0 L 10,0 L 10,8")
                : Avalonia.Media.Geometry.Parse("M 0,0 L 10,0 L 10,10 L 0,10 Z");
        }
    }
}
