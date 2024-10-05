using Prism.Modularity;
using System.Windows;

namespace Modules.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IModuleManager _moduleManager;

        public MainWindow(IModuleManager moduleManager)
        {
            InitializeComponent();
            _moduleManager = moduleManager;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //在Prism框架中，当你手动向IModuleCatalog添加模块时，
            //你实际上是在告诉框架有关模块的存在和其元数据，
            //但这并不意味着模块已经被加载或初始化。
            //IModuleCatalog仅仅是模块信息的容器，它负责跟踪哪些模块是可用的，但并不负责模块的加载或激活。

            //当你使用moduleCatalog.AddModule(...)方法添加模块时，你只是在注册模块的信息。
            //为了实际加载和使用模块，你需要调用某种机制来触发模块的加载过程。
            //在Prism中，这通常是通过IModuleManager的LoadModule方法来完成的。
            _moduleManager.LoadModule("ModuleAModule");
        }
    }
}
