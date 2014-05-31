using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageAnimalHistory : ClientPage
    {
        int animalID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AnimalIDParam();

            if (animalID > 0)
            {
                if (!IsPostBack)
                {
                    if (Ctrl.isOwnerOfAnimal(animalID))
                    {
                        calendarDateStart.SelectedDate = DateTime.Today;
                        calendarDateEnd.SelectedDate = DateTime.Today;

                        SqlDataReader dr;

                        dr = Ctrl.getAnimalHistory(animalID).ExecuteReader();
                        tblHistory.DataSource = dr;
                        tblHistory.DataBind();
                        dr.Close();

                        SqlDataReader animalData = Ctrl.getAnimalInfo(animalID).ExecuteReader();

                        if (!animalData.HasRows)
                        {
                            animalData.Close();
                            Ctrl.Database.Connection.Close();
                            return;
                        }

                        animalData.Read();

                        lblAnimalName.Text = animalData.GetString(0);
                        lblAnimalRace.Text = animalData.GetString(3);
                        lblAnimalSpecie.Text = animalData.GetString(4);

                        animalData.Close();
                    }
                    else
                        Response.Redirect("PageAnimalDashboard.aspx");
                }
            }
            else
                Response.Redirect("PageAnimalDashboard.aspx");
        }
        public void AnimalIDParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AnimalID"]))
                int.TryParse(Request.QueryString["AnimalID"], out animalID);
            else
                animalID = 0;
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            DateTime start = calendarDateStart.SelectedDate;
            DateTime end = calendarDateEnd.SelectedDate;

            if (start > end)
                pnlError.Visible = true;
            else
            {
                SqlDataReader dr;

                if (chkType.Checked)
                    dr = Ctrl.getAnimalHistorySearch(animalID, start, end, Convert.ToInt32(ddlListType.SelectedValue)).ExecuteReader();
                else
                    dr = Ctrl.getAnimalHistorySearch(animalID, start, end, 0).ExecuteReader();

                tblHistory.DataSource = dr;
                tblHistory.DataBind();
                
                dr.Close();
            }
        }
    }
}