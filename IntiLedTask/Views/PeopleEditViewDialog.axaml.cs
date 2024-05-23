using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace IntiLedTask;

public partial class PeopleEditViewDialog : Window
{
    public PeopleEditViewDialog()
    {
        InitializeComponent();
    }

    private void ButtonOk(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(DataContext);
    }

    private void ButtonCancel(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(null);
    }
}