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
    public sealed partial class OffresPage : Page
    {
        private OffresVM vm = new OffresVM();

        public OffresPage()
        {
            this.InitializeComponent();

            DataContext = vm;
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            await vm.ConnectAsync();
        }

        private async void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            await vm.DisconnectAsync();
        }

        private async void mnuRafraichir_Click(object sender, RoutedEventArgs e)
        {
            await vm.GetOffres();
        }

        private void mnuFermer_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
