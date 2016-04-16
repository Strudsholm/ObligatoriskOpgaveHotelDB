using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendApp.Model
{
    public class GuestListSingleton
    {
        private static GuestListSingleton instance;

        

        public static GuestListSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GuestListSingleton();
                }
                return instance;
            }
            
        }

        public List<Guest> Guests { get; set; }

        private GuestListSingleton()
        {
            Guests = new List<Guest>();
        }
    }
}
