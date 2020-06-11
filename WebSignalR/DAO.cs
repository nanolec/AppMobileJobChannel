using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSignalR
{
    public class DAO : IDAO
    {
        /// <summary>
        /// C'est ici qu'il faut faire les SELECT
        /// </summary>
        /// <returns></returns>
        public List<Offre> GetOffres()
        {
            return new List<Offre>()
            {
            new Offre(){ Nom = "Titre1", Detail = "Detail1", Region = "Region1", Contrat = "Contrat1", Poste = "Poste1", DatePublication = "01/01/2020", Lien = "Lien1"},
            new Offre(){ Nom = "Titre2", Detail = "Detail2", Region = "Region2", Contrat = "Contrat2", Poste = "Poste2", DatePublication = "02/01/2020", Lien = "Lien2"},
            new Offre(){ Nom = "Titre3", Detail = "Detail3", Region = "Region3", Contrat = "Contrat3", Poste = "Poste3", DatePublication = "03/01/2020", Lien = "Lien3"},
            new Offre(){ Nom = "Titre4", Detail = "Detail4", Region = "Region4", Contrat = "Contrat4", Poste = "Poste4", DatePublication = "04/01/2020", Lien = "Lien4"},
            new Offre(){ Nom = "Titre5", Detail = "Detail5", Region = "Region5", Contrat = "Contrat5", Poste = "Poste5", DatePublication = "05/01/2020", Lien = "Lien5"},
            new Offre(){ Nom = "Titre6", Detail = "Detail6", Region = "Region6", Contrat = "Contrat6", Poste = "Poste6", DatePublication = "06/01/2020", Lien = "Lien6"},
            new Offre(){ Nom = "Titre7", Detail = "Detail7", Region = "Region7", Contrat = "Contrat7", Poste = "Poste7", DatePublication = "07/01/2020", Lien = "Lien7"},
            new Offre(){ Nom = "Titre8", Detail = "Detail8", Region = "Region8", Contrat = "Contrat8", Poste = "Poste8", DatePublication = "08/01/2020", Lien = "Lien8"},
            new Offre(){ Nom = "Titre9", Detail = "Detail9", Region = "Region9", Contrat = "Contrat9", Poste = "Poste9", DatePublication = "09/01/2020", Lien = "Lien9"},
            new Offre(){ Nom = "Titre10", Detail = "Detai10", Region = "Region10", Contrat = "Contrat10", Poste = "Poste10", DatePublication = "10/01/2020", Lien = "Lien10"},
            new Offre(){ Nom = "Titre11", Detail = "Detai11", Region = "Region11", Contrat = "Contrat11", Poste = "Poste11", DatePublication = "11/01/2020", Lien = "Lien11"}

            };
        }
    }
}
