using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerceMobile.Services;
using GalaSoft.MvvmLight.Command;

namespace ECommerceMobile.Pages.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private NavigationService navigationService;

        private DialogService dialogService;

        private ApiService apiService;

        private bool isRunning;

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion

        #region Properties
        public string User { get; set; }

        public string Password { get; set; }

        public bool IsRemembered { get; set; }

        public bool IsRunning
        {
            get { return isRunning; }

            set
            {
                if (isRunning != value)
                {
                    isRunning = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRunning"));
                }

            }
        }


        #endregion

        #region Constructor
        public LoginViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();
            apiService = new ApiService();

            IsRemembered = true;
        }
        #endregion


        #region Command
        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }



        private async void Login()
        {
            if (string.IsNullOrEmpty(User))
            {
                await dialogService.ShowMessage("Error", "Debes ingrear un Usuario.");

                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await dialogService.ShowMessage("Error", "Debes ingrear una Contraseña.");

                return;
            }

            IsRunning = true;

            var response = await apiService.Login(User, Password);

            IsRunning = false;

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }

            navigationService.SetMainPage();
        }

        #endregion


    }
}
