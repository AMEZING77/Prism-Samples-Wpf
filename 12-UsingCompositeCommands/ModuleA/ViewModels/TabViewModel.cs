﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;
using UsingCompositeCommands.Core;

namespace ModuleA.ViewModels
{
    public class TabViewModel : BindableBase
    {
        IApplicationCommands _applicationCommands;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _canUpdate = true;
        public bool CanUpdate
        {
            get { return _canUpdate; }
            set { SetProperty(ref _canUpdate, value); }
        }

        private string _updatedText;
        public string UpdateText
        {
            get { return _updatedText; }
            set { SetProperty(ref _updatedText, value); }
        }

        public DelegateCommand UpdateCommand { get; private set; }
        public DelegateCommand ShowCommand { get; private set; }

        public TabViewModel(IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;

            UpdateCommand = new DelegateCommand(Update).ObservesCanExecute(() => CanUpdate);
            ShowCommand = new DelegateCommand(Show).ObservesCanExecute(() => CanUpdate);

            _applicationCommands.SaveCommand.RegisterCommand(UpdateCommand);
            _applicationCommands.SaveCommand.RegisterCommand(ShowCommand);

        }

        private void Show()
        {
            UpdateText += "ShowCommand";
        }

        private void Update()
        {
            UpdateText = $"Updated: {DateTime.Now}";
        }
    }
}
