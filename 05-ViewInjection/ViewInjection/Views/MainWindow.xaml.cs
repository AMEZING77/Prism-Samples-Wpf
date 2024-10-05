using Prism.Ioc;
using Prism.Navigation.Regions;
using System.Windows;

namespace ViewInjection.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContainerExtension _container;
        IRegionManager _regionManager;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = _container.Resolve<ViewA>();
            //由于在MainWindow.xaml中声明了ContentRegion的Region，这种声明是隐式的，有Prism框架自动生成
            //当Prism的初始化过程执行时（通常是在应用程序的启动过程中），
            //它会查找所有带有 prism:RegionManager.RegionName 附加属性的控件，
            //并为每个这样的控件创建一个区域对象，
            //然后将这些区域对象添加到 IRegionManager 的 Regions 集合中。
            IRegion region = _regionManager.Regions["ContentRegion"];
            region.Add(view);
        }
    }
}
