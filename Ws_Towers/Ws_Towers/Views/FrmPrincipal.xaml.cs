using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ws_Towers.Models;
using Ws_Towers.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ws_Towers.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmPrincipal : ContentPage
    {
        public IList<Eventos> Monkeys { get; private set; }

        PrincipalViewModel vm = new PrincipalViewModel();
        public FrmPrincipal()
        {
            InitializeComponent();
            this.BindingContext = vm;
        }
    }
}