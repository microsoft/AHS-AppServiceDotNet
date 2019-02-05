using SmartHotel.Registration.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHotel.Registration
{
    public partial class Checkin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var registrationProvided = 
                int.TryParse(Request.QueryString["registration"], out int registrationId);
                //int.TryParse(Request.QueryString["registrationId"], out int registrationId);

            if (registrationId == 0)
                throw new System.ArgumentException("Parameter cannot be null");

            if (!registrationProvided)
                Response.Redirect("Default.aspx");

            using (var context = new BookingsDbContext())
            {
                Booking checkin = context.Bookings.Find(registrationId);

                CustomerName.Value = checkin.CustomerName;
                Passport.Value = checkin.Passport;
                CustomerId.Value = checkin.CustomerId;
                Address.Value = checkin.Address;
                Amount.Value = checkin.Amount.ToString();
            }
        }
    }
}