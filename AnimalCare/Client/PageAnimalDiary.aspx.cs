﻿using System;
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

            if (animalID > 0)
            {
                if (Ctrl.isOwnerOfAnimal(animalID))
                {
                    reg.Attributes["href"] = "PageAnimalDiaryNew.aspx?AnimalID=" + animalID;

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

        public void AnimalIDParam()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AnimalID"]))
                int.TryParse(Request.QueryString["AnimalID"], out animalID);
            else
                animalID = 0;
        }
    }
}