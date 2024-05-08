using Avalonia.Controls;
using Avalonia.Input;
using PlanMe.Services;
using PlanMe.ViewModels;

namespace PlanMe.Views;

public partial class InboxView : UserControl
{
    private readonly PlanService _planService;
    
    public InboxView()
    {
        InitializeComponent();
        _planService = new PlanService();
    }

    private void InputElement_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && e.KeyModifiers == KeyModifiers.None)
        {
            if (string.IsNullOrEmpty(TextBoxAddTask.Text)) return;
            if (DataContext is InboxViewModel model)
            {
                _planService.AddInboxTask(TextBoxAddTask.Text);
                model.TaskList.Tasks = _planService.GetInboxTasks(model.TaskList.IncludeCompleted);
                TextBoxAddTask.Clear();
            }
        }
    }
}