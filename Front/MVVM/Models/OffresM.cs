using BusinessObjects;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileJobChannel
{
    class OffresM
    {
        private static volatile OffresM instance;
        private static readonly object syncRoot = new object();
        private HubConnection _connection;

        private OffresM() { }

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

        public async Task ConnectAsync(string hubAddress)
        {
            // Le builder permet de créér la connexion
            HubConnectionBuilder builder = new HubConnectionBuilder();

            // HubData est le nom logique du Hub défini dans le Startup du WebService
            //builder.WithUrl(hubAddress + "/HubData");
            builder.WithUrl($"{hubAddress}/HubData");

            // Création de la connexion
            _connection = builder.Build();

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
            return await _connection.InvokeAsync<List<Offre>>("GetOffres");
        }
    }
}
