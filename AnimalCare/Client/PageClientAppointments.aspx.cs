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
                AnimaisDS.SelectCommand = Ctrl.getOwnerAnimalsSQL();

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

        protected bool DateValidation(DateTime date)
        {
            DateTime fakeDate = new DateTime(0001, 01, 01);
            if (date.Equals(fakeDate))
                return false;
            else
                return true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dateAux = calDateAppointment.SelectedDate;

            if (DateValidation(dateAux))
            {
                dateAux = dateAux.AddHours(Convert.ToInt16(listHour.SelectedItem.Text));
                dateAux = dateAux.AddMinutes(Convert.ToInt16(listMinutes.SelectedItem.Text));

                for (int i = 0; i < chkAnimais.Items.Count; i++)
                {
                    if (chkAnimais.Items[i].Selected)
                    {
                        Ctrl.insertAppointment(Convert.ToInt32(chkAnimais.Items[i].Value),
                          Convert.ToInt32(listAppointmentTypes.SelectedValue), dateAux, boxDetail.Text, chkUrgent.Checked);
                    }
                }

                Response.Redirect("PageClientDashboard.aspx");
            }
            else
                pnlError.Visible = true;
        }

        protected void chkUrgent_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageClientDashboard.aspx");
        }
    }
}