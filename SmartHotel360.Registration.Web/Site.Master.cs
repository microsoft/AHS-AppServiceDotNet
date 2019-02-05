using SmartHotel.Registration.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHotel.Registration
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            using (var context = new BookingsDbContext())
            {
                var totalCheckins = context.Bookings
                    .Count(b => b.From == DateTime.Today);

                var totalCheckouts = context.Bookings
                    .Count(b => b.To == DateTime.Today);

                var summary = new RegistrationDaySummary
                {
                    Date = DateTime.Today,
                    CheckIns = totalCheckins,
                    CheckOuts = totalCheckouts
                };

                Checkins.InnerText = summary.CheckIns.ToString();
                Checkouts.InnerText = summary.CheckOuts.ToString();

                Clock.Text = DateTime.Now.ToShortTimeString();
            }
        }

        protected void ClockTimer_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToShortTimeString();
        }
    }
}