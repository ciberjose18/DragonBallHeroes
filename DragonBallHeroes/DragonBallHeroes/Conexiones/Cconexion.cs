using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace DragonBallHeroes.Conexiones
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://dragonball-c2c2c-default-rtdb.firebaseio.com/");

    }
}
