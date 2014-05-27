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

            if (!IsPostBack)
            {
                // Horas
                listHour.Items.Clear();
                for (int i = 0; i < 24; i++)
                    listHour.Items.Add(Convert.ToString(i));

                // Minutos
                listMinutes.Items.Clear();
                for (int i = 0; i < 60; i++)
                    if (i % 5 == 0)
                        listMinutes.Items.Add(Convert.ToString(i));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime aux = calDateAppointment.SelectedDate;

            aux = aux.AddHours(Convert.ToInt16(listHour.SelectedItem.Text));
            aux = aux.AddMinutes(Convert.ToInt16(listMinutes.SelectedItem.Text));

            // Teste
            Ctrl.insertAppointment(2, 1, aux, "Teste", false, 1);

            Response.Redirect(System.IO.Path.GetFileName(Request.Url.AbsolutePath));
        }
    }
}