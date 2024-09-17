using KioscoInformaticoApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoInformaticoApp.ViewModels
{
    public class InicioSesionViewModel : ObjectNotification
    {
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }

        private bool rememberPassword;
        public bool RememberPassword
        {
            get { return rememberPassword; }
            set 
            {
                rememberPassword = value;
                OnPropertyChanged();
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public InicioSesionViewModel()
        {
            LoginCommand = new Command(Login, allowLogin);
        }

        private bool allowLogin(object arg)
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private void Login(object obj)
        {
            App.Current.MainPage.DisplayAlert("Inicio de sesión", "Inicio de sesión exitoso", "Aceptar");
        }
    }
}
