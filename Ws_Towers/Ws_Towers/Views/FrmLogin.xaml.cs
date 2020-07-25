using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ws_Towers.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ws_Towers.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmLogin : ContentPage
    {
        LoginViewModel vm = new LoginViewModel();
        public FrmLogin()
        {
            InitializeComponent();
            this.BindingContext = vm;

            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "ErroLogin", (str) =>
            {
                DisplayAlert("Erro", str, "Cancelar");
            });

            MessagingCenter.Subscribe<string>(this, "SucessoLogin", (str) =>
            {
                App.Current.MainPage = new Master();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "ErroLogin");
            MessagingCenter.Unsubscribe<string>(this, "SucessoLogin");
        }
    }
}