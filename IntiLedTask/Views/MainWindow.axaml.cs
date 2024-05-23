using Avalonia.Controls;

using IntiLedTask.ViewModels;

namespace IntiLedTask.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += async (o, e) =>
            {
                var vm = DataContext as MainWindowViewModel;
                if (vm != null)
                {
                    await vm.Load("peoples.json");
                }
            };
            Closing += async (o, e) => 
            {
                var vm = DataContext as MainWindowViewModel;
                if (vm != null ) 
                {
                    await vm.Save("peoples.json");
                }
            };
        }
    }
}