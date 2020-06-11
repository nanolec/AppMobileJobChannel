using System;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppMobileJobChannel
{
    /// <summary>
    /// ATTENTION, on respecte l'architecture MVVM, donc on ne peut accèder qu'au ViewModel 'OffresVM' et pas
    /// directement au Model 'OffresM'
    /// </summary>
    public sealed partial class OffresPage : Page
    {
        //Création du ViewModel
        private OffresVM vm = new OffresVM();

        public OffresPage()
        {
            this.InitializeComponent();

            // Liaison entre la View et le ViewModel
            DataContext = vm;
        }

        //private async void Page_Loading(FrameworkElement sender, object args)
        //{
        //    // On se connecte au WebService à l'ouverture de la View
        //    await vm.ConnectAsync();
        //}

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            // On se déconnecte de l'évènement
            vm.Close();
        }


        private void mnuFermer_Click(object sender, RoutedEventArgs e)
        {
            // Retour à la fenêtre appelante
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
        private async void mnuRafraichir_Click(object sender, RoutedEventArgs e)
        {
            // Appel de la méthode 'GetOffres' 
            if (!await vm.GetOffres())
            {
                await new ContentDialog()
                {
                    Title = ResourceLoader.GetForCurrentView("Messages").GetString("TITLE_ERRORCONNECT"),
                    Content = ResourceLoader.GetForCurrentView("Messages").GetString("MSG_ERRORCONNECT"),
                    CloseButtonText = "Ok"
                }.ShowAsync();
            }
        }
        
        private async void BtConnect_Click(object sender, RoutedEventArgs e)
        {
            if (!await vm.ConnectAsync())
            {
                await new ContentDialog()
                {
                    Title = ResourceLoader.GetForCurrentView("Messages").GetString("TITLE_ERRORCONNECT"),
                    Content = ResourceLoader.GetForCurrentView("Messages").GetString("MSG_ERRORCONNECT"),
                    CloseButtonText = "Ok"
                }.ShowAsync();
            }
        }

        private async void BtDisconnect_Click(object sender, RoutedEventArgs e)
        {
            await vm.DisconnectAsync();
        }
    }
}
