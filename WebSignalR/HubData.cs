using BusinessObjects;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSignalR
{
    /// <summary>
    /// Envois et reçois les appel au Client
    /// </summary>
    public class HubData : Hub<IHubData>
    {
        /// <summary>
        /// Injection de dépendance
        /// </summary>
        /// <param name = "dao" ></ param >
        private readonly IDAO _dao;
        public HubData(IDAO dao)
        {
            _dao = dao;
        }

        public List<Offre> GetOffres() 
        {
            return _dao.GetOffres();
        }

        #region Gestion nombre de personnes connectées
        /// <summary>
        /// Chaque thread on la même valeur de _connectionCount à un instant donné
        /// Volatile ==> pas d'optimisation du system
        /// Comme c'est juste un compteur en int cela suffit
        /// Sinon utiliser un lock
        /// </summary>
        private static volatile int _connectionCount;

        public async override Task OnConnectedAsync()
        {
            _connectionCount++;
            //await Clients.All.HubConnectionsCount(_connectionCount);
            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            _connectionCount--;
            //await Clients.All.HubConnectionsCount(_connectionCount);
            await base.OnDisconnectedAsync(exception);
        }
        #endregion


    }
}
