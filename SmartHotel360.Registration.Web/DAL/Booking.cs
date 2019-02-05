namespace SmartHotel.Registration.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        public int Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Passport { get; set; }

        public string Address { get; set; }

        public int Amount { get; set; }

        public int Total { get; set; }
    }
}
