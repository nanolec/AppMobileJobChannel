using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileJobChannel
{
    public class OffresVM : ViewModelBase
    {

        private readonly ObservableCollection<Offre> _offres = new ObservableCollection<Offre>();
        public ObservableCollection<Offre> Offres 
        {
            get { return _offres; }
        }

        public async Task ConnectAsync() 
        { 
            await OffresM.Instance.ConnectAsync(ParametersM.Instance.HubAdress); 
        }

        public async Task DisconnectAsync() 
        {
            await OffresM.Instance.DisconnectAsync();
        }

        public async Task GetOffres() 
        {
            List<Offre> lst = await OffresM.Instance.GetOffres();

            Offres.Clear();
            //foreach (Offre item in lst)
            //{
            //    Offres.Add(item);
            //}
            // linq
            lst.ForEach(item => Offres.Add(item));
        }


    }
}
