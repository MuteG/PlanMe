using Avalonia.Controls;
using Avalonia.Interactivity;
using PlanMe.ViewModels;

namespace PlanMe.Views;

public partial class TaskControl : UserControl
{
    public TaskControl()
    {
        InitializeComponent();
    }

    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaskModel model)
        {
            model.Delete();
        }
    }
}