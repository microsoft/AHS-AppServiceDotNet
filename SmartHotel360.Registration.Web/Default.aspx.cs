using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHotel.Registration.DAL;

namespace SmartHotel.Registration
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            using (var context = new BookingsDbContext())
            {
                var checkins = context.Bookings
                .Where(b => b.From == DateTime.Today)
                .Select(BookingTypes.BookingToCheckin);

                var checkouts = context.Bookings
                    .Where(b => b.To == DateTime.Today)
                    .Select(BookingTypes.BookingToCheckout);

                var registrations = checkins.Concat(checkouts).OrderBy(r => r.Date).ToList();
                RegistrationGrid.DataSource = registrations;
                RegistrationGrid.DataBind();
            }                
        }

        protected void RegistrationGrid_SelectedIndexChanged(Object sender, EventArgs e)
        {
            GridViewRow row = RegistrationGrid.SelectedRow;

            var registrationId = RegistrationGrid.DataKeys[RegistrationGrid.SelectedIndex]["Id"];
            var registrationType = RegistrationGrid.DataKeys[RegistrationGrid.SelectedIndex]["Type"].ToString();

            if (registrationType == "CheckIn")
            {
                Response.Redirect($"Checkin.aspx?registration={registrationId}");
            }

            if (registrationType == "CheckOut")
            {
                Response.Redirect($"Checkout.aspx?registration={registrationId}");
            }
        }

        protected void RegistrationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(RegistrationGrid, "Select$" + e.Row.RowIndex);
        }
    }
}