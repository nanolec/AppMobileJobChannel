using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppMobileJobChannel
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ParametersPage : Page
    {

        //Création du ViewModel
        private ParametersVM vm = new ParametersVM();

        public ParametersPage()
        {
            this.InitializeComponent();

            // Liaison entre la View et le ViewModel
            DataContext = vm;
        }

        private void mnuValider_Click(object sender, RoutedEventArgs e)
        {
            // Sauvegarde des paramètres dans le Model. ils ne seront vraiment sauvegardés (sérialisés)
            // qu'a la fermeture de l'application (événement 'OnSuspending' de la classe App)
            vm.Save();

            // Retour à la fenêtre appelante
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void mnuAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Retour à la fenêtre appelante
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    }
}
