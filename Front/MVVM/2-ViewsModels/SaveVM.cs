using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace AppMobileJobChannel
{
    class SaveVM : ViewModelBase
    {
        /// <summary>
        /// Va lire les paramètres sauvegardés
        /// </summary>
        private string _offre = SaveM.Instance.Offre;
        private string _detail = SaveM.Instance.Detail;
        private string _region = SaveM.Instance.Region;
        private string _contrat = SaveM.Instance.Contrat;
        private string _poste = SaveM.Instance.Poste;
        private string _datePublication = SaveM.Instance.DatePublication;
        private string _lien = SaveM.Instance.Lien;

        public string Offre 
        {
            get { return _offre; }
            set 
            {
                _offre = value;
                RaisePropertyChanged();
            }  
        }
        public string Detail
        {
            get { return _detail; }
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

        public void Save()
        {
            SaveM.Instance.Offre = _offre;
            SaveM.Instance.Detail = _detail;
            SaveM.Instance.Region = _region;
            SaveM.Instance.Contrat = _contrat;
            SaveM.Instance.Poste = _poste;
            SaveM.Instance.DatePublication = _datePublication;
            SaveM.Instance.Lien = _lien;
        }

    }
}
