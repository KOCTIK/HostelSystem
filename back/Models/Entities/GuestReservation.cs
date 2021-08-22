using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hostelsystem.Models
{
    public class GuestReservation
    {
        public long GuestId { get; set; }
        public Guest Guest { get; set; }

        public long ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
