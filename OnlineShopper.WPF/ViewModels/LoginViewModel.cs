﻿using OnlineShopper.WPF.ViewModels;
using OnlineShopper.WPF.Commands;
using OnlineShopper.WPF.State.Authenticators;
using OnlineShopper.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OnlineShopper.WPF.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
        private string _username = "admin";
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        public bool CanLogin => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand LoginCommand { get; }
        public ICommand ViewRegisterCommand { get; }

        public LoginViewModel(
            IAuthenticator authenticator,
            IRenavigator loginRenavigator,
            IRenavigator registerRenavigator
        )
        {
            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}
