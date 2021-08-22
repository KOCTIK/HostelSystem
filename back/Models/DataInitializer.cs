using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;

namespace Hostelsystem.Models
{
    public class DataInitializer
    {
        private readonly HostelSystemDbContext context;

        public DataInitializer(HostelSystemDbContext context)
        {
            this.context = context;
        }


        public void SeedData()
        {
            SeedGuests();
            SeedReservations();
        }

        private void SeedGuests()
        {
            if (this.context.Guests.Any()) return;
            var guests = new Faker<Guest>()
                .RuleFor(x => x.FirstName, x => x.Name.FirstName())
                .RuleFor(x => x.LastName, x => x.Name.LastName())
                .RuleFor(x => x.DateOfBirth, x => x.Date.Between(new DateTime(1980, 1, 1), new DateTime(2002, 12, 31)).Date)
                .RuleFor(x => x.Email, x => x.Person.Email)
                .Generate(20);

            this.context.Guests.AddRange(guests);
            this.context.SaveChanges();
        }

        private void SeedReservations()
        {
            if (this.context.Reservations.Any()) return;

            var guests = this.context.Guests.Select(x => x.GuestId).ToList();
            var reservationCode = new[] { "Confirmed", "Tentative", "Waitlist", "Cancelled", "Guarantee" };
            var currency = new[] { "USD", "EUR", "PLN", "UAH" };

            var reservations = new Faker<Reservation>()
                .RuleFor(x => x.ReservationCode, x => x.PickRandom(reservationCode))
                .RuleFor(x => x.Currency, x => x.PickRandom(currency))
                .RuleFor(x => x.Price, x => x.Random.Decimal(50, 700))
                .RuleFor(x => x.CreationDate, x => x.Date.Between(new DateTime(2021, 1, 1), new DateTime(2002, 8, 15)).Date)
                .RuleFor(x => x.CheckInDate, x => x.Date.Between(new DateTime(2021, 1, 1), new DateTime(2002, 8, 15)).Date)
                .RuleFor(x => x.CheckOutDate, x => x.Date.Between(new DateTime(2021, 1, 1), new DateTime(2002, 8, 15)).Date)
                .Generate(20);

            var random = new Random();

            foreach (var reserv in reservations)
            {
                var guestsList = new List<GuestReservation>();

                for (int i = 0; i < random.Next(1, 3); i++)
                    guestsList.Add(new GuestReservation() { GuestId = guests[random.Next(guests.Count)] });

                reserv.Guests = guestsList;
            }

            this.context.Reservations.AddRange(reservations);
            this.context.SaveChanges();
        }
    }
}
