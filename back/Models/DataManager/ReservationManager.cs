using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hostelsystem.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hostelsystem.Models.DataManager
{
    public class ReservationManager : IDataRepository<Reservation>
    {

        private readonly HostelSystemDbContext context;

        public ReservationManager(HostelSystemDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<object> GetAll()
        {
            return context.Reservations
                .Select(x => new
                {
                    x.ReservationId,
                    x.ReservationCode,
                    x.Price,
                    x.CreationDate,
                    x.CheckInDate,
                    x.CheckOutDate,
                    Guests = x.Guests.Select(x => x.Guest).ToList()
                })
                .ToList();
        }

        public IEnumerable<object> GetFiltered(Filter filter)
        {

            var reservations = context.Reservations.AsQueryable();

            if (filter.Name != null) reservations = reservations.Where(res => res.Guests.Any(x => x.Guest.FirstName.ToLower() == filter.Name.ToLower()));
            if (filter.City != null) reservations = reservations.Where(res => res.Guests.Any(x => x.Guest.City.ToLower() == filter.City.ToLower()));

            return reservations
                 .Select(x => new
                 {
                     x.ReservationId,
                     x.ReservationCode,
                     x.Price,
                     x.CreationDate,
                     x.CheckInDate,
                     x.CheckOutDate,
                     Guests = x.Guests.Select(x => x.Guest).ToList()
                 })
                .ToList();
        }

        public void Add(Reservation entity)
        {
            //entity.Guests = new List<GuestReservation>() { new GuestReservation() { GuestId = guestId } };

            context.Reservations.Add(entity);
            this.context.SaveChanges();
        }
    }
}
