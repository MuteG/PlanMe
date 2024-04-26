using System;
using System.ComponentModel;
using Avalonia.Controls;
using PlanMe.Services;
using PlanMe.ViewModels;

namespace PlanMe.Views;

public partial class TaskControl : UserControl
{
    private readonly PlanService _planService;
    
    public TaskControl()
    {
        InitializeComponent();
        _planService = new PlanService();
    }
    
    public event EventHandler IsCompleteChanged;

    protected override void OnDataContextChanged(EventArgs e)
    {
        base.OnDataContextChanged(e);
        if (DataContext is TaskModel model)
        {
            model.PropertyChanged -= ModelOnPropertyChanged;
            model.PropertyChanged += ModelOnPropertyChanged;
        }
    }

    private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(TaskModel.Foreground))
        {
            if (DataContext is TaskModel model)
            {
                if (model.IsComplete)
                {
                    _planService.CompleteTask(model.Id);
                }
                else
                {
                    _planService.ResumeTask(model.Id);
                }
            }
            
            IsCompleteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}