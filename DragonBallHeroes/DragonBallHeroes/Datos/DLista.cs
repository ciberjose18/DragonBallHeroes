using DragonBallHeroes.Conexiones;
using DragonBallHeroes.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PanCardView.EventArgs;

namespace DragonBallHeroes.Datos
{
    public class DLista
    {
        public async Task <List<MLista>> Mostrar()
        {
            return (await Cconexion.firebase.Child("Lista").OnceAsync<MLista>()).Select(item => new MLista
            {
                Icono = item.Object.Icono
            }).ToList();
        }
    }
}
