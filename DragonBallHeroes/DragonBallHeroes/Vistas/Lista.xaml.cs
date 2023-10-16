using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DragonBallHeroes.VistaModelo;

namespace DragonBallHeroes.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        VMLista vm;
        public Lista()
        {

            vm = new VMLista(Navigation);
            BindingContext = vm;

            InitializeComponent();
            
        }

        private async void Desplazamiento(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            await vm.Desplazarcardview(sender, e);
        }
    }
}