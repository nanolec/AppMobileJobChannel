using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Windows.Storage;

namespace AppMobileJobChannel
{
    public class SaveM
    {
        public const string KEY_SAVE = "SAVE";

        // Volatile pour ne gèrer qu'une variable pour plusieurs thread
        private static volatile SaveM instance;
        
        /// <summary>
        /// sert de verrous
        /// </summary>
        private static readonly object syncRoot = new object();

        private SaveM() {}

        public static SaveM Instance 
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            if (String.IsNullOrEmpty(ApplicationData.Current.LocalSettings.Values[KEY_SAVE] as String))
                                instance = new SaveM();
                            else
                                instance = JsonConvert.DeserializeObject<SaveM>(ApplicationData.Current.LocalSettings.Values[KEY_SAVE] as string);

                        }
                    }
                }
                
                return instance;
            }
        
        }

        public string Offre { get; set; }
        public string Detail { get; set; }
        public string Region { get; set; }
        public string Contrat { get; set; }
        public string Poste { get; set; }
        public string DatePublication { get; set; }
        public string Lien { get; set; }

        public void Save() => ApplicationData.Current.LocalSettings.Values[KEY_SAVE] = JsonConvert.SerializeObject(this);
    }
}
