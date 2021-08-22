using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hostelsystem.Models
{
    public class Guest
    {
        public long GuestId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }


        public List<GuestReservation> Reservations { get; set; }
    }
}
