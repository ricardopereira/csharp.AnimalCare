using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Employee
{
    public partial class PageEmployeeScheduleNew : EmployeePage
    {
        private int appointmentID;
        private int ownerID;
        private int animalID;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Ctrl.saveAppointment(appointmentID, (int)AppointmentState.astAccepted, "Marcação aceite.");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            loadParameters();

            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                ownerID = Ctrl.getOwnerByAnimalID(animalID);

                if (appointmentID > 0)
                {
                    ownerID = 0;
                    animalID = 0;

                    // ToDo
                }
                else if (ownerID <= 0)
                {
                    // Pesquisa de Proprietário
                    Response.Redirect("PageEmployeeScheduleOwner.aspx");
                    return;
                }
                else if (animalID <= 0)
                {
                    // Pesquisa de Animal
                    Response.Redirect("PageEmployeeScheduleAnimal.aspx");
                    return;
                }

                lblAnimal.Text = Convert.ToString(animalID);
                lblOwner.Text = Convert.ToString(ownerID);
            }
        }

        private void loadParameters()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AppointmentID"]))
                int.TryParse(Request.QueryString["AppointmentID"], out appointmentID);
            else
                appointmentID = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["AnimalID"]))
                int.TryParse(Request.QueryString["AnimalID"], out animalID);
            else
                animalID = 0;
        }
    }
}