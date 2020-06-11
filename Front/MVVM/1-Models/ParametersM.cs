using BusinessObjects;
using Newtonsoft.Json;
using System;
using Windows.Storage;

namespace AppMobileJobChannel
{
    public class ParametersM
    {
        private const string KEY_PARAMETERS = "Parameters";

        private static volatile ParametersM instance;
        private static readonly object syncRoot = new Object();

        private ParametersM() { }

        public static ParametersM Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot) // Verrouillage pour un accès multi-thread
                    {
                        if (instance == null)
                        {
                            if (String.IsNullOrEmpty(ApplicationData.Current.LocalSettings.Values[KEY_PARAMETERS] as String))
                                instance = new ParametersM();
                            else
                                instance = JsonConvert.DeserializeObject<ParametersM>(ApplicationData.Current.LocalSettings.Values[KEY_PARAMETERS] as string);
                        }
                    }
                }

                return instance;
            }
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string HubAdress { get; set; }
        public Offre Offre { get; set; }

        public void Save() => ApplicationData.Current.LocalSettings.Values[KEY_PARAMETERS] = JsonConvert.SerializeObject(this);
    }
}
