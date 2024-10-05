using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;
using ViewModelLocator.ViewModels;
using ViewModelLocator.Views;

namespace ViewModelLocator
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

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            // type / type
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), typeof(CustomViewModel));

            // type / factory
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), () => Container.Resolve<CustomViewModel>());

            // generic factory
            //如果你的视图模型需要特殊的初始化逻辑或依赖项注入，那么使用带有工厂函数的注册方式可能更加合适。
            ViewModelLocationProvider.Register<MainWindow>(() => Container.Resolve<CustomViewModel>());

            // generic type
            //最简洁的注册方法。
            //它使用泛型来指定视图和视图模型的类型。
            //Prism 框架内部将处理视图模型的创建和关联逻辑。这种方法也依赖于默认构造函数;
            //ViewModelLocationProvider.Register<MainWindow, CustomViewModel>();
        }
    }
}
