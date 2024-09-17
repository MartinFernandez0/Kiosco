using KioscoInformaticoApp.Views;

namespace KioscoInformaticoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new InicioSesionView();
        }
    }
}
