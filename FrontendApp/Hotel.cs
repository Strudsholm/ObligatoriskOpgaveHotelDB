﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendApp
{
    public class Hotel
    {
        public Hotel()
        {
            Room = new HashSet<Room>();
        }

        public int Hotel_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
