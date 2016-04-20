using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Eventmaker.Common;
using FrontendApp.Annotations;
using FrontendApp.Model;

namespace FrontendApp.ViewModel
{
    public class GæstVM : INotifyPropertyChanged
    {
        public ObservableCollection<Guest> GuestsOC { get; set; }

        public RelayCommand GemCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand HentCommand { get; set; }

        public int SelectedIndex { get; set; }

        public string GuestName { get; set; }
        public string GuestAddress { get; set; }
        public int GuestNo { get; set; }
        public Facade Facade { get; set; }

        public GæstVM()
        {
            Facade = new Facade();
            GuestsOC = new ObservableCollection<Guest>();
            foreach (var g in GuestListSingleton.Instance.Guests)
            {
                GuestsOC.Add(g);
            }
            GemCommand = new RelayCommand(GemGuest);
            HentCommand = new RelayCommand(Hentinfo);
            UpdateCommand = new RelayCommand(UpdateInfo);
            DeleteCommand = new RelayCommand(DeleteGuest);
                      
        }

        public void Opdater()
        {
            Facade.GetMetode();
        }

        public void GemGuest()
        {
            Guest test = new Guest();

            test.Guest_No = GuestNo;
            test.Name = GuestName;
            test.Address = GuestAddress;

            Facade.CreateGuest(test);
        }

        public void Hentinfo()
        {
            Guest troll = GuestsOC[SelectedIndex];

            GuestName = troll.Name;
            GuestAddress = troll.Address;
            GuestNo = troll.Guest_No;
            OnPropertyChanged(string.Empty);
        }

        public void UpdateInfo()
        {
            Guest xd = new Guest();
            xd = GuestListSingleton.Instance.Guests[SelectedIndex];
            xd.Name = GuestName;
            xd.Address = GuestAddress;
            //xd.Guest_No = GuestNo;

            Facade.UpdateGuest(xd.Guest_No, xd);

            OnPropertyChanged(string.Empty);

        }

        
        public void DeleteGuest()
        {
            Guest test = GuestsOC[SelectedIndex];
            Facade.DeleteGuest(test.Guest_No);

            GuestsOC.RemoveAt(SelectedIndex);

        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
