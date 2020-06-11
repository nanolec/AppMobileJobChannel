using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileJobChannel
{
    /// <summary>
    /// Implémentation de l'Interface INotifyPropertyChanged
    /// Permet de signifier qu'il y a des propriétées qui change si besoin
    /// </summary>
    public class MainVm : ViewModelBase
    {
        // Le ViewModel peut accèder au Model
        public string Nom { get => ParametersM.Instance.Nom; }
        public string Prenom { get => ParametersM.Instance.Prenom; }
        public string HubAdress { get => ParametersM.Instance.HubAdress; }

        private string _offre = "Mon Offre";
        private string _detail = "Ma déscription";
        private string _region = "Ma région";
        private string _contrat = "Mon contrat";
        private string _poste = "Ma poste";
        private string _datePublication = "Ma date de publication";
        private string _lien = "Mon lien";

        public string Offre
        {
            get
            {
                return _offre;
            }
            set
            {
                _offre = value;
                RaisePropertyChanged();
            }
        }
        public string Detail
        {
            get
            {
                return _detail;
            }
            set
            {
                _detail = value;
                RaisePropertyChanged();
            }
        }
        public string Region
        {
            get
            {
                return _region;
            }
            set
            {
                _region = value;
                RaisePropertyChanged();
            }
        }
        public string Contrat
        {
            get
            {
                return _contrat;
            }
            set
            {
                _contrat = value;
                RaisePropertyChanged();
            }
        }
        public string Poste
        {
            get
            {
                return _poste;
            }
            set
            {
                _poste = value;
                RaisePropertyChanged();
            }
        }
        public string DatePublication
        {
            get
            {
                return _datePublication;
            }
            set
            {
                _datePublication = value;
                RaisePropertyChanged();
            }
        }
        public string Lien
        {
            get
            {
                return _lien;
            }
            set
            {
                _lien = value;
                RaisePropertyChanged();
            }
        }

    }
}


