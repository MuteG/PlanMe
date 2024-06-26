﻿using PlanMe.Domain;
using PlanMe.ViewModels;

namespace PlanMe.Services.EntityExtensions;

public static class FourQuadrantExtension
{
    public static FourQuadrantViewModel ToModel(this FourQuadrant entity)
    {
        return new FourQuadrantViewModel
        {
            ImportantAndUrgentTasks = new TaskListViewModel(entity.ImportantAndUrgentTasks.ToModel()),
            ImportantButNotUrgentTasks = new TaskListViewModel(entity.ImportantButNotUrgentTasks.ToModel()),
            NotImportantButUrgentTasks = new TaskListViewModel(entity.NotImportantButUrgentTasks.ToModel()),
            NotImportantAndNotUrgentTasks = new TaskListViewModel(entity.NotImportantAndNotUrgentTasks.ToModel())
        };
    }
}