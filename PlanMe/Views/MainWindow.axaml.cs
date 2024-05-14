using Avalonia.Controls;
using Avalonia.Interactivity;
using PlanMe.Services;
using PlanMe.ViewModels;

namespace PlanMe.Views;

public partial class MainWindow : Window
{
    private readonly PlanService _planService;
    
    public MainWindow()
    {
        InitializeComponent();
        _planService = new PlanService();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        var tasks = _planService.GetInboxTaskModels(true);
        DataContext = new MainWindowViewModel
        {
            Inbox = new InboxViewModel(tasks)
        };

        var fourQuadrantWindow = new FourQuadrantWindow();
        fourQuadrantWindow.DataContext = _planService.GetInboxFourQuadrantViewModel(true);
        fourQuadrantWindow.Show(this);
    }
}