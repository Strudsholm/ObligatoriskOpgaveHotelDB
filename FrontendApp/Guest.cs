using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendApp
{
    public class Guest
    {
        public Guest()
        {
            Booking = new HashSet<Booking>();
        }

        public int Guest_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
