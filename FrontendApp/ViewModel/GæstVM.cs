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
        //public GuestListSingleton GuestListSingleton { get; set; }
        public ObservableCollection<Guest> GuestsOC { get; set; }

        public RelayCommand GemCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand HentCommand { get; set; }

        public int SelectedIndex { get; set; }

        public string GuestName { get; set; }
        public string GuestAddress { get; set; }
        public int GuestNo { get; set; }

        public GæstVM()
        {
            GuestsOC = new ObservableCollection<Guest>();
            foreach (var g in GuestListSingleton.Instance.Guests)
            {
                GuestsOC.Add(g);
            }
            //GemCommand = new RelayCommand();
            HentCommand = new RelayCommand(Hentinfo);
            UpdateCommand = new RelayCommand(UpdateInfo);
            //DeleteCommand = new RelayCommand();

        }

        public void Hentinfo()
        {
            Guest xd = new Guest();
            xd = GuestListSingleton.Instance.Guests[SelectedIndex];
            GuestName = xd.Name;
            GuestAddress = xd.Address;
            GuestNo = xd.Guest_No;

            OnPropertyChanged(string.Empty);
        }

        public void UpdateInfo()
        {
            Guest xd = new Guest();
            xd = GuestListSingleton.Instance.Guests[SelectedIndex];
            xd.Name = GuestName;
            xd.Address = GuestAddress;
            //xd.Guest_No = GuestNo;

            OnPropertyChanged(string.Empty);

        }

        public void DeleteGuest(int )
        {
            //GuestListSingleton.Instance.Guests[SelectedIndex];
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
