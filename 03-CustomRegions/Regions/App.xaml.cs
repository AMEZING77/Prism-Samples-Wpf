using Prism.Ioc;
using Prism.Navigation.Regions;
using Prism.Unity;
using System.Windows;
using System.Windows.Controls;
using Regions;
using Regions.Views;

namespace Regions
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(TextBlock), Container.Resolve<TextBlockRegionAdapter>());


        }
    }
}
