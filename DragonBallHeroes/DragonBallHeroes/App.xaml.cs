﻿using DragonBallHeroes.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragonBallHeroes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Lista();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
