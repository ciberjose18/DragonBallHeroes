using DragonBallHeroes.Datos;
using DragonBallHeroes.Modelo;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SkiaSharp;
using System.ComponentModel;

namespace DragonBallHeroes.VistaModelo
{
    public class VMLista : BaseViewModel
    {
        //-------------------------------------------------------- VARIABLES ---------------------------------------------------------

        #region VARIABLES


        List<MLista> _lista;
        SKBitmap bitmap;
        string _color;
        private int _indexselect;
        string _imagen;
        string _color1;
        string _color2;


        #endregion
        //-------------------------------------------------------- CONSTRUCTOR ---------------------------------------------------------

        #region CONSTRUCTOR

        public VMLista(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().Transparente();
            Mostrar();
        }


        #endregion

        //-------------------------------------------------------- OBJETOS ---------------------------------------------------------

        #region OBJETOS

        public string Color1
        {
            get { return _color1; }
            set { SetValue(ref _color1, value); }
        }
        public string Color2
        {
            get { return _color2; }
            set { SetValue(ref _color2, value); }
        }

        public string Color
        {
            get { return _color; }
            set { SetValue(ref _color, value); }
        }

        public string Imagen
        {
            get { return _imagen; }
            set { SetValue(ref _imagen, value); }
        }

        public List<MLista> Lista
        {
            get { return _lista; }
            set { SetValue(ref _lista, value); }
        }

        #endregion

        //-------------------------------------------------------- PROCESOS ---------------------------------------------------------

        #region PROCESOS

        public async Task ObtenercolorPrimerimagen()
        {
            try
            {
                Imagen = Lista[0].Icono;
                Color = await Obtenercolores(Imagen);
                string[] c1 = Color.Split('|');
                Color1 = c1[0];
                Color2 = c1[1];

            }
            catch(Exception)
            {
                throw;
            }
        }


        public async Task Desplazarcardview(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName.Equals("SelectedIndex"))
            {
                var index = ((PanCardView.CoverFlowView)sender).SelectedIndex;
                if (index != _indexselect)
                {
                    _indexselect = index;
                    try
                    {
                        Imagen = Lista[_indexselect].Icono;
                        Color = await Obtenercolores(Imagen);
                        string[] c1 = Color.Split('|');
                        Color1 = c1[0];
                        Color2 = c1[1];

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            }

        public async Task<string> Obtenercolores(string url)
        {
            HttpClient client = new HttpClient();
            string Url = url;
            using (Stream stream = await client.GetStreamAsync(Url))
            using (MemoryStream memori = new MemoryStream())
            {
                await stream.CopyToAsync(memori);
                memori.Seek(0, SeekOrigin.Begin);
                bitmap = SKBitmap.Decode(memori);
                var colorunido = ObtenerColordominante(bitmap);
                Color = colorunido;

            };
            return Color;
        }



        public async Task Mostrar()
        {
            var funcion = new DLista();
            Lista = await funcion.Mostrar();
            await ObtenercolorPrimerimagen();

        }


        public void ProcesoSimple()
        {

        }
        #endregion
        //-------------------------------------------------------- COMANDOS ---------------------------------------------------------

        #region COMANDOS
        // public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
