using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontendApp.Model;

namespace FrontendApp.ViewModel
{
    public class GæstVM
    {
        //public GuestListSingleton GuestListSingleton { get; set; }
        public ObservableCollection<Guest> GuestsOC { get; set; }

        public GæstVM()
        {
            GuestsOC = new ObservableCollection<Guest>();
            foreach (var g in GuestListSingleton.Instance.Guests)
            {
                GuestsOC.Add(g);
            }
        }


    }
}
