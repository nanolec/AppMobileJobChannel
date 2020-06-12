using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileJobChannel
{
    class ParametersVM : ViewModelBase
    {
        public string _nom = ParametersM.Instance.Nom;
        public string _prenom = ParametersM.Instance.Prenom;
        public string _hubAdress = ParametersM.Instance.HubAdress;
        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
                RaisePropertyChanged(); // Permet de notifier la View d'une modification
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
                RaisePropertyChanged(); // Permet de notifier la View d'une modification
            }
        }

        public string HubAdress
        {
            get
            {
                return _hubAdress;
            }

            set
            {
                _hubAdress = value;
                RaisePropertyChanged(); // Permet de notifier la View d'une modification
            }
        }

        public Offre _offre = ParametersM.Instance.Offre;
        public Offre Offre
        {
            get { return _offre; }
        }


        /// <summary>
        /// Sauvegarde des paramètres dans le Model. ils ne seront vraiment sauvegardés (sérialisés)
        /// qu'a la fermeture de l'application (événement 'OnSuspending' de la classe App)
        /// </summary>
        public void Save()
        {
            ParametersM.Instance.Nom = _nom;
            ParametersM.Instance.Prenom = _prenom;
            ParametersM.Instance.HubAdress = _hubAdress;
            ParametersM.Instance.Offre = _offre;
        }
    }
}
