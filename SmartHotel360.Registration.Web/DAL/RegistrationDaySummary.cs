using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHotel.Registration.DAL
{
    public class RegistrationDaySummary
    {
        public DateTime Date { get; set; }
        public int CheckIns { get; set; }
        public int CheckOuts { get; set; }
    }
}