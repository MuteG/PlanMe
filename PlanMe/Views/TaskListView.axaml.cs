using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using PlanMe.Services;
using PlanMe.ViewModels;

namespace PlanMe.Views;

public partial class TaskListView : UserControl
{
    private readonly PlanService _planService;
    
    public TaskListView()
    {
        InitializeComponent();
        _planService = new PlanService();
    }
    
    public static readonly StyledProperty<bool> IsReadOnlyProperty =
        AvaloniaProperty.Register<TaskListView, bool>(nameof(IsReadOnly), defaultValue: false);

    public bool IsReadOnly
    {
        get => GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }
    
    private void ContextMenu_OnOpening(object sender, CancelEventArgs e)
    {
        e.Cancel = IsReadOnly;
    }

    private void MenuDelete_OnClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaskListViewModel model &&
            ((MenuItem)sender).DataContext is TaskModel task)
        {
            _planService.RemoveTask(task.Id);
            model.Tasks = _planService.GetInboxTasks(model.IncludeCompleted);
        }
    }

    private void TaskControl_OnIsCompletedChanged(object sender, EventArgs e)
    {
        if (DataContext is TaskListViewModel model)
        {
            model.Tasks = _planService.GetInboxTasks(model.IncludeCompleted);
        }
    }
}