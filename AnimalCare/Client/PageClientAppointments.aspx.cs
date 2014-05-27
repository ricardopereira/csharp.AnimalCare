using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageClientAppointments : ClientPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            listHour.Items.Clear();
            for (int i = 0; i < 24; i++)
                listHour.Items.Add(Convert.ToString(i));

            listMinutes.Items.Clear();
            for (int i = 0; i < 60; i++)
                listMinutes.Items.Add(Convert.ToString(i));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Ctrl.insertAppointment(2, 1, calDateAppointment.SelectedDate, "Teste", false, 1);

            Response.Redirect(System.IO.Path.GetFileName(Request.Url.AbsolutePath));
        }
    }
}