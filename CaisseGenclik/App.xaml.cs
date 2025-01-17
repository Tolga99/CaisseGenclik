﻿using CaisseGenclik.Others;
using CaisseGenclik.ViewModels;
using CaisseGenclik.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CaisseGenclik
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            // Code à exécuter lors de la fermeture de l'application
        }

        // Vous pouvez également gérer d'autres événements de l'application ici, tels que OnUnhandledException, etc.
    }
}