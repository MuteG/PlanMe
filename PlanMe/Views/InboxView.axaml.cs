using Avalonia.Controls;
using Avalonia.Input;
using PlanMe.ViewModels;

namespace PlanMe.Views;

public partial class InboxView : UserControl
{
    public InboxView()
    {
        InitializeComponent();
    }

    private void InputElement_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && e.KeyModifiers == KeyModifiers.None)
        {
            if (string.IsNullOrEmpty(TextBoxAddTask.Text)) return;
            if (DataContext is InboxViewModel model)
            {
                model.AddTask(TextBoxAddTask.Text);
                TextBoxAddTask.Clear();
            }
        }
    }
}