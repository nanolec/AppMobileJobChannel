using BusinessObjects;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppMobileJobChannel
{
    class OffresM
    {
        // Evenement qui permet de notifier le ViewModel que l'on a reçu un message du serveur
        public event EventHandler ConnectionsCount;

        private static volatile OffresM instance;
        private static readonly object syncRoot = new Object();
        private HubConnection _connection;

        private OffresM() { } // Singleton = constructeur privé

        /// <summary>
        /// Propriété static pour créer l'instance
        /// </summary>
        public static OffresM Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot) // Verrou pour les accès multi threads
                    {
                        if (instance == null)
                        {
                            instance = new OffresM();
                        }
                    }
                }
                return instance;
            }
        }

        public bool IsConnected 
        {
            get { return _connection?.State == HubConnectionState.Connected; }
        }

        private int _count;
        public int Count 
        {
            get { return _count; }
            private set { _count = value; }
        }

        public async Task ConnectAsync(string hubAddress)
        {
            // Le builder permet de créér la connexion
            HubConnectionBuilder builder = new HubConnectionBuilder();

            // HubData est le nom logique du Hub défini dans le Startup du WebService
            //builder.WithUrl(hubAddress + "/HubData");
            builder.WithUrl($"{hubAddress}/HubData");

            // Création de la connexion
            _connection = builder.Build();

            // Abonnement a la connexion
            _connection.On<int>("HubConnectionsCount", (int count) =>
            {
                Count = count;

                // On émet l'événement 'ConnectionsCount' pour le ViewModel
                ConnectionsCount?.Invoke(this, new EventArgs());
            });

            // Ouverture de la connexion avec le Hub
            await _connection.StartAsync();

        }

        /// <summary>
        /// Fermeture de la connexion avec le Hub
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectAsync()
        {
            await _connection.StopAsync();
        }

        /// <summary>
        /// Appel de la méthode 'GetOffres' du WebService
        /// </summary>
        /// <returns></returns>
        public async Task<List<Offre>> GetOffres()
        {
            return await _connection.InvokeAsync<List<Offre>>(nameof(GetOffres));
        }
    }
}
