using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
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
                model.InboxTasks = _planService.GetInboxTasks(model.IncludeCompleted);
                TextBoxAddTask.Clear();
            }
        }
    }

    private void MenuDelete_OnClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is InboxViewModel model &&
            ((MenuItem)sender).DataContext is TaskModel task)
        {
            _planService.RemoveTask(task.Id);
            model.InboxTasks = _planService.GetInboxTasks(model.IncludeCompleted);
        }
    }

    private void TaskControl_OnIsCompletedChanged(object sender, EventArgs e)
    {
        if (DataContext is InboxViewModel model)
        {
            model.InboxTasks = _planService.GetInboxTasks(model.IncludeCompleted);
        }
    }
}