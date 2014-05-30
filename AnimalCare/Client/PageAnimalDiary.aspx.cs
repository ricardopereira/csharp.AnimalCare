using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageAnimalDiary : ClientPage
    {
        int animalID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AnimalIDParam();
            pnlError.Visible = false;
            if (!IsPostBack)
            {
                if (animalID > 0)
                {
                    if (Ctrl.isOwnerOfAnimal(animalID))
                    {
                        reg.Attributes["href"] = "PageAnimalDiaryNew.aspx?AnimalID=" + animalID;
                        calendarDateStart.SelectedDate = DateTime.Today;
                        calendarDateEnd.SelectedDate = DateTime.Today;

                        SqlDataReader dr;

                        dr = Ctrl.getAnimalDiary(animalID).ExecuteReader();
                        tblDiary.DataSource = dr;
                        tblDiary.DataBind();
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
                        Response.Redirect("PageClientDashboard.aspx");
                }
                else
                    Response.Redirect("PageAnimalDashboard.aspx");
            }
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
                if(chkType.Checked)
                    dr = Ctrl.getAnimalDiarySearch(animalID,start, end, Convert.ToInt32(ddlListType.SelectedValue)).ExecuteReader();
                else
                    dr = Ctrl.getAnimalDiarySearch(animalID,start,end,0).ExecuteReader();

                tblDiary.DataSource = dr;
                tblDiary.DataBind();
                dr.Close();
            }

        }

        private void AnimalIDParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AnimalID"]))
                int.TryParse(Request.QueryString["AnimalID"], out animalID);
            else
                animalID = 0;
        }
    }
}