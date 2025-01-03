using Avalonia;
using Avalonia.Media;
using Avalonia.Styling;
using PlanMe.Domain;
using PlanMe.ViewModels;

namespace PlanMe.Services.EntityExtensions;

public static class FourQuadrantExtension
{
    public static FourQuadrantViewModel ToModel(this FourQuadrant entity)
    {
        return new FourQuadrantViewModel
        {
            ImportantAndUrgentTasks = new TitledTaskListViewModel
            {
                Title = GetResourcesText("FourQuadrantView.Label.ImportantAndUrgent"),
                TitleForeColor = Brushes.White,
                TitleBackColor = Brushes.Crimson,
                Tasks = entity.ImportantAndUrgentTasks.ToModel()
            },
            ImportantButNotUrgentTasks = new TitledTaskListViewModel
            {
                Title = GetResourcesText("FourQuadrantView.Label.ImportantButNotUrgent"),
                TitleForeColor = Brushes.White,
                TitleBackColor = Brushes.Coral,
                Tasks = entity.ImportantButNotUrgentTasks.ToModel()
            },
            NotImportantButUrgentTasks = new TitledTaskListViewModel
            {
                Title = GetResourcesText("FourQuadrantView.Label.NotImportantButUrgent"),
                TitleForeColor = Brushes.White,
                TitleBackColor = Brushes.Orchid,
                Tasks = entity.NotImportantButUrgentTasks.ToModel()
            },
            NotImportantAndNotUrgentTasks = new TitledTaskListViewModel
            {
                Title = GetResourcesText("FourQuadrantView.Label.NotImportantAndNotUrgent"),
                TitleForeColor = Brushes.White,
                TitleBackColor = Brushes.LimeGreen,
                Tasks = entity.NotImportantAndNotUrgentTasks.ToModel()
            }
        };
    }

    private static string GetResourcesText(string key)
    {
        if (Application.Current == null) return null;
        Application.Current.Resources.MergedDictionaries[0].TryGetResource(key, ThemeVariant.Default, out var value);
        return value as string;
    }
}