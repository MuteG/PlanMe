using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using PlanMe.Views;

namespace PlanMe.ViewModels;

public class TitledTaskListViewModel : TaskListViewModel
{
    public string Title { get; set; }

    public IBrush TitleBackColor { get; set; }
    
    public IBrush TitleForeColor { get; set; }
}