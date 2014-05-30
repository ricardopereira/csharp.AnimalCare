using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Doctor
{
    public partial class PageDoctorDashboard : DoctorPage
    {
        public int maxServicosToShow = 5;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack && User.Identity.IsAuthenticated)
            {
                refreshController();

                SqlDataReader dr;

                // Marcacoes
                dr = Ctrl.getLastServices().ExecuteReader();
                tblLastServicos.DataSource = dr;
                tblLastServicos.DataBind();
                dr.Close();

                // Eventos
                dr = Ctrl.getScheduleWeek().ExecuteReader();
                tblSchedule.DataSource = dr;
                tblSchedule.DataBind();
                dr.Close();
                lblSelected.Text = "Semana";
            }
        }

        protected void btnDay_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            dr = Ctrl.getScheduleToday().ExecuteReader();
            tblSchedule.DataSource = dr;
            tblSchedule.DataBind();
            dr.Close();
            lblSelected.Text = "Dia";
        }

        protected void btnWeek_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            dr = Ctrl.getScheduleWeek().ExecuteReader();
            tblSchedule.DataSource = dr;
            tblSchedule.DataBind();
            dr.Close();
            lblSelected.Text = "Semana";
        }

        protected void btnMonth_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            dr = Ctrl.getScheduleMonth().ExecuteReader();
            tblSchedule.DataSource = dr;
            tblSchedule.DataBind();
            dr.Close();
            lblSelected.Text = "Mês";
        }
    }
}