using System.Windows;
using System.Windows.Input;
using Prism.Commands;

namespace UsingCompositeCommands.Core
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _saveCommand = new CompositeCommand();

        public ApplicationCommands()
        {
            // 使用 DelegateCommand 创建一个命令，该命令使用 Lambda 表达式定义 Execute 方法
            var saveFileCommand = new DelegateCommand(() =>
            {
                MessageBox.Show("保存完成");
            });

            // 注册新创建的命令到 CompositeCommand 中
            _saveCommand.RegisterCommand(saveFileCommand);
        }

        public CompositeCommand SaveCommand
        {
            get { return _saveCommand; }
        }



    }
}
