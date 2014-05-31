using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Doctor
{
    public partial class PageDoctorServiceEdit : DoctorPage
    {
        private int serviceID;
        private bool serviceDone;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            loadParameters();

            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                loadDefault();

                if (serviceID > 0)
                {
                    loadService();
                }
                else
                    Response.Redirect("~/Doctor/PageDoctorDashboard.aspx");
            }
        }

        private void loadDefault()
        {
            // Horas
            listHourService.Items.Clear();
            for (int i = 0; i < 24; i++)
                listHourService.Items.Add(Convert.ToString(i));

            // Minutos
            listMinutesService.Items.Clear();
            for (int i = 0; i < 60; i++)
                if (i % 5 == 0)
                    listMinutesService.Items.Add(Convert.ToString(i));

            calDateService.SelectedDate = DateTime.Today;

            listHourService.SelectedValue = Convert.ToString(DateTime.Now.Hour);
        }

        private void loadService()
        {
            SqlDataReader data = Ctrl.getService(serviceID).ExecuteReader();
            if (!data.HasRows) return;

            data.Read();

            if (!data.IsDBNull(19))
            {
                serviceDone = Convert.ToBoolean(data.GetInt32(19));
                lblDone.Visible = serviceDone;

                boxDescription.Enabled = !serviceDone;
                listClinic.Enabled = !serviceDone;
                listServiceKind.Enabled = !serviceDone;
                calDateService.Enabled = !serviceDone;
                listHourService.Enabled = !serviceDone;
                listMinutesService.Enabled = !serviceDone;
                btnFinish.Visible = !serviceDone;
            }

            if (!data.IsDBNull(4))
            {
                DateTime dateAux = data.GetDateTime(4);
                calDateService.SelectedDate = dateAux.Date;
                listHourService.SelectedValue = Convert.ToString(dateAux.Hour);
                listMinutesService.SelectedValue = Convert.ToString(dateAux.Minute);
            }

            int animalID = data.GetInt32(9);

            linkAnimal.PostBackUrl = "PageDoctorAnimal.aspx?AnimalID=" + Convert.ToString(animalID);

            if (!data.IsDBNull(12))
                lblOwner.Text = data.GetString(12);
            lblFeedback.Text = lblOwner.Text;

            if (!data.IsDBNull(13))
                lblAnimal.Text = data.GetString(13);

            if (!data.IsDBNull(17))
                lblRace.Text = data.GetString(17);

            if (!data.IsDBNull(16))
                lblSpecie.Text = data.GetString(16);

            if (!data.IsDBNull(8))
                listServiceKind.SelectedValue = Convert.ToString(data.GetInt32(8));

            if (!data.IsDBNull(11))
                listClinic.SelectedValue = Convert.ToString(data.GetInt32(11));

            if (!data.IsDBNull(3))
                boxDescription.Text = data.GetString(3);

            if (!data.IsDBNull(7))
                boxObs.Text = data.GetString(7);

            data.Close();

            // Diário 
            SqlDataReader dr;
            dr = Ctrl.getAnimalDiaryByService(animalID, serviceID).ExecuteReader();
            tblDiary.DataSource = dr;
            tblDiary.DataBind();
            dr.Close();
        }

        private void loadParameters()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ServiceID"]))
                int.TryParse(Request.QueryString["ServiceID"], out serviceID);
            else
                serviceID = 0;
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            if (serviceID <= 0) return;
            if (listServiceKind.SelectedValue.Equals("")) return;
            if (listClinic.SelectedValue.Equals("")) return;

            DateTime dateAux = calDateService.SelectedDate;

            dateAux = dateAux.AddHours(Convert.ToInt16(listHourService.SelectedItem.Text));
            dateAux = dateAux.AddMinutes(Convert.ToInt16(listMinutesService.SelectedItem.Text));

            Ctrl.updateServiceEvent(serviceID, boxDescription.Text.Trim(), Convert.ToInt32(listServiceKind.SelectedValue),
                dateAux, DateTime.Now, boxObs.Text.Trim(), Convert.ToInt32(listClinic.SelectedValue));

            Response.Redirect("~/Doctor/PageDoctorDashboard.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (serviceID <= 0) return;
            if (listServiceKind.SelectedValue.Equals("")) return;
            if (listClinic.SelectedValue.Equals("")) return;

            DateTime dateAux = calDateService.SelectedDate;

            dateAux = dateAux.AddHours(Convert.ToInt16(listHourService.SelectedItem.Text));
            dateAux = dateAux.AddMinutes(Convert.ToInt16(listMinutesService.SelectedItem.Text));

            Ctrl.updateServiceEvent(serviceID, boxDescription.Text.Trim(), Convert.ToInt32(listServiceKind.SelectedValue), 
                dateAux, DateTime.MinValue,  boxObs.Text.Trim(), Convert.ToInt32(listClinic.SelectedValue));

            Response.Redirect("~/Doctor/PageDoctorDashboard.aspx");
        }
    }
}