using Prism.Navigation.Regions;
using System.Windows;

namespace ViewDiscovery.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            //view discovery
            regionManager.RegisterViewWithRegion("ViewA", typeof(ViewA));
            regionManager.RegisterViewWithRegion("ViewB", typeof(ViewB));

        }
    }
}
