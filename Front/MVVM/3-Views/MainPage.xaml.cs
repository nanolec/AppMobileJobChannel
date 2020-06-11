using System;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppMobileJobChannel
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainVm vm = new MainVm();

        public MainPage()
        {
            this.InitializeComponent();

        /// <summary>
        /// Liaison avec le ViewModel
        /// </summary>
            DataContext = vm;
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Si les paramètres ne sont pas renseignés, on averti l'utilisateur. ATTENTION, la View ne peut
            // accèder qu'au ViewModel, pas au Model !!
            if (String.IsNullOrEmpty(vm.Nom) || String.IsNullOrEmpty(vm.Prenom) || String.IsNullOrEmpty(vm.HubAdress))
            {
                await new ContentDialog()
                {
                    Title = ResourceLoader.GetForCurrentView("Messages").GetString("TITLE_PARAM"),
                    Content = ResourceLoader.GetForCurrentView("Messages").GetString("MSG_PARAM"),
                    CloseButtonText = "Ok"
                }.ShowAsync();

                Frame.Navigate(typeof(ParametersPage));
            }
        }

        private void mnuSave_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavePage));
        }

        private void mnuParameters_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ParametersPage));
        }

        private void mnuOffres_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OffresPage));
        }
    }
}
