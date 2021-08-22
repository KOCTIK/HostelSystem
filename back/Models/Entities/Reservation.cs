using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hostelsystem.Models
{
    public class Reservation
    {
        public long ReservationId { get; set; }
        [Required]
        [MaxLength(10)]
        public string ReservationCode { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        [Required]
        public string Currency { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Commission { get; set; }
        public string Source { get; set; }

        public List<GuestReservation> Guests { get; set; }
    }
}
