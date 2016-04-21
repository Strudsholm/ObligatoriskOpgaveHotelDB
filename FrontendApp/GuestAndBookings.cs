using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendApp
{
    public class GuestAndBookings
    {
        public string Name { get; set; }
        public int Booking_id { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Booking_id: {Booking_id}";
        }
    }
}
