using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;

namespace BasicRegionNavigation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath == null) return;
            if (navigatePath.Contains("A")) _regionManager.RequestNavigate("ContentRegionA", navigatePath);
            if (navigatePath.Contains("B")) _regionManager.RequestNavigate("ContentRegionB", navigatePath);

        }
    }
}
