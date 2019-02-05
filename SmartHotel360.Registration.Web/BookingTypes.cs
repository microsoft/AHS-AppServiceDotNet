using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHotel.Registration.DAL;

namespace SmartHotel.Registration
{
    public static class BookingTypes
    {
        public static DAL.Registration BookingToCheckin(Booking booking)
        {
            return new DAL.Registration
            {
                Id = booking.Id,
                Type = "CheckIn",
                Date = booking.From,
                CustomerId = booking.CustomerId,
                CustomerName = booking.CustomerName,
                Passport = booking.Passport,
                Address = booking.Address,
                Amount = booking.Amount,
                Total = booking.Total
            };
        }

        public static DAL.Registration BookingToCheckout(Booking booking)
        {
            return new DAL.Registration
            {
                Id = booking.Id,
                Type = "CheckOut",
                Date = booking.To,
                CustomerId = booking.CustomerId,
                CustomerName = booking.CustomerName,
                Passport = booking.Passport,
                Address = booking.Address,
                Amount = booking.Amount,
                Total = booking.Total
            };
        }
    }
}