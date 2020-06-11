using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AppMobileJobChannel
{
    public class OffresVM : ViewModelBase
    {

        public OffresVM()
        {
            // On s'abonne à l'événement du Model 'OffreM_ConnectionCount'
            OffresM.Instance.ConnectionsCount += OffresM_ConnectionCount;

            // On récupère le nombre de clients actuellement connectés au serveur
            ConnectionsCount = OffresM.Instance.Count;
        }

        /// <summary>
        /// Désabonnement à l'évènement du Model 'OffreM_ConnectionCount'
        /// </summary>
        public override void Close()
        {
            OffresM.Instance.ConnectionsCount -= OffresM_ConnectionCount;
        }


        #region Gestion Indicateur de progression

        private bool _isConnecting; // Sur Connexion
        public bool IsConnecting
        {
            get { return _isConnecting; }
            private set
            {
                _isConnecting = value;
                RaisePropertyChanged();
            }
        }

        private bool _isDisconnecting; // Sur Déconnexion
        public bool IsDisconnecting
        {
            get { return _isDisconnecting; }
            private set
            {
                _isDisconnecting = value;
                RaisePropertyChanged();
            }
        } 

        private bool _isGettingOffres; // Sur chargement Offres
        public bool IsGettingOffres
        {
            get { return _isGettingOffres; }
            private set
            {
                _isGettingOffres = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        /// <summary>
        /// Permet d'afficher les outils en fonction de la connexion ou pas
        /// </summary>
        public bool IsConnected 
        { 
            get { return OffresM.Instance.IsConnected; }
        }


        private readonly ObservableCollection<Offre> _offres = new ObservableCollection<Offre>();
        public ObservableCollection<Offre> Offres 
        {
            get { return _offres; }
        }

        /// <summary>
        /// Gestion nombre de connexions
        /// </summary>
        private int _connectionCount;
        public int ConnectionsCount  
        {
            get { return _connectionCount; }
            set 
            { 
                _connectionCount = value;
                RaisePropertyChanged();
            }
        }

        //public async Task ConnectAsync() 
        //{
        //    IsConnecting = true;

        //    await OffresM.Instance.ConnectAsync(ParametersM.Instance.HubAdress);
        //    RaisePropertyChanged(nameof(IsConnected));
        //    IsConnecting = false;
        //}
        public async Task<bool> ConnectAsync()
        {
            IsConnecting = true;

            try
            {
                await OffresM.Instance.ConnectAsync(ParametersM.Instance.HubAdress);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                RaisePropertyChanged(nameof(IsConnected));
                IsConnecting = false;
            }
        }

        //public async Task DisconnectAsync() 
        //{
        //    IsDisconnecting = true;

        //    // On demande au Model de se déconnecter du serveur
        //    await OffresM.Instance.DisconnectAsync();
        //    RaisePropertyChanged(nameof(IsConnected));
        //    IsDisconnecting = false;
        //}
        public async Task<bool> DisconnectAsync()
        {
            IsDisconnecting = true;

            try
            {
                await OffresM.Instance.DisconnectAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                RaisePropertyChanged(nameof(IsConnected));
                IsDisconnecting = false;
            }
        }

        public async Task<bool> GetOffres()
        {
            IsGettingOffres = true;

            try
            {
                List<Offre> lst = await OffresM.Instance.GetOffres();
                // On récupère les Offres dans la collection Offres qui est de type 'ObservableCollection<Offre>'
                Offres.Clear();
                //foreach (Offre item in lst)
                //{
                //    Offres.Add(item);
                //}
                // linq
                lst.ForEach(x => Offres.Add(x));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                RaisePropertyChanged(nameof(IsConnected));
                IsGettingOffres = false;
            }
        }


        /// <summary>
        /// Evenement de la classe OffresM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OffresM_ConnectionCount(object sender, EventArgs e)
        {
            ConnectionsCount = OffresM.Instance.Count;
        }


    }
}
