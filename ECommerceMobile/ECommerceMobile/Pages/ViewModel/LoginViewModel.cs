using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ECommerceMobile.Services;
using GalaSoft.MvvmLight.Command;

namespace ECommerceMobile.Pages.ViewModel
{
    public class LoginViewModel
    {
        #region Attributes
        private NavigationService navigationService;

        private DialogService dialogService;
        #endregion

        #region Properties
        public string User { get; set; }

        public string Password { get; set; }

        public bool IsRemembered { get; set; }



        #endregion

        #region Constructor
        public LoginViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();

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

            navigationService.SetMainPage();
        }

        #endregion

    }
}
