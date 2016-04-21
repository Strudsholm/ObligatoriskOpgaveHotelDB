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
        public ObservableCollection<GuestAndBookings> GuestAndBookingss { get; set; }
        public List<GuestAndBookings> random { get; set; }

        public GæstVM()
        {
            Facade = new Facade();
            GuestsOC = new ObservableCollection<Guest>();
            foreach (var g in GuestListSingleton.Instance.Guests)
            {
                GuestsOC.Add(g);
            }
            random = new List<GuestAndBookings>();
            random = Facade.ViewGetMetode();

            GuestAndBookingss = new ObservableCollection<GuestAndBookings>();
            foreach (var g in random)
            {
                GuestAndBookingss.Add(g);
            }

            GemCommand = new RelayCommand(GemGuest);
            HentCommand = new RelayCommand(Hentinfo);
            UpdateCommand = new RelayCommand(UpdateInfo);
            DeleteCommand = new RelayCommand(DeleteGuest);
                      
        }



        public void GemGuest()
        {
            Guest nyGuest = new Guest();

            nyGuest.Guest_No = GuestNo;
            nyGuest.Name = GuestName;
            nyGuest.Address = GuestAddress;

            Facade.CreateGuest(nyGuest);
        }

        public void Hentinfo()
        {
            Guest InfoGuest = GuestsOC[SelectedIndex];

            GuestName = InfoGuest.Name;
            GuestAddress = InfoGuest.Address;
            GuestNo = InfoGuest.Guest_No;
            OnPropertyChanged(string.Empty);
        }

        public void UpdateInfo()
        {
            Guest InfoGuest = new Guest();
            InfoGuest = GuestListSingleton.Instance.Guests[SelectedIndex];
            InfoGuest.Name = GuestName;
            InfoGuest.Address = GuestAddress;
            //xd.Guest_No = GuestNo;

            Facade.UpdateGuest(InfoGuest.Guest_No, InfoGuest);

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
