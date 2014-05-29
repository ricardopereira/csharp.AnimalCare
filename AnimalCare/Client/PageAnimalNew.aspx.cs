using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageAnimalNew : ClientPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if(User.Identity.IsAuthenticated && !IsPostBack)
                HasLocals();
        }

        private void HasLocals()
        {
            SqlDataReader dataLocals =  Ctrl.getOwnerLocals().ExecuteReader();

            if (dataLocals.HasRows)
                PopulateDDLLocals(dataLocals);
            else
            {
                dataLocals.Close();
                Response.Redirect("/Client/PageClientLocals.aspx?Error=message");
            }
            dataLocals.Close();
        }

        private void PopulateDDLLocals(SqlDataReader dataLocals)
        {
            while (dataLocals.Read())
                ddlLocals.Items.Add(new ListItem(dataLocals.GetString(2), Convert.ToString(dataLocals.GetInt32(0))));
            dataLocals.Close();
        }

        protected void chkGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGroup.Checked)
            {
                boxNumberAnimals.Visible = true;
                lblNGroup.Visible = true;
            }
            else
            {
                boxNumberAnimals.Visible = false;
                lblNGroup.Visible = false;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAnimal.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int recordID;
            string name = boxName.Text;
            string identityNumber = boxIdentity.Text;
            int quantity;
            int localID = Convert.ToInt32(ddlLocals.SelectedValue);
            int animalRace = Convert.ToInt32(ddlRaces.SelectedValue);
            int animalCondition = Convert.ToInt32(ddlCondition.SelectedValue);
            int animalHabitat = Convert.ToInt32(ddlHabitat.SelectedValue);
            DateTime birth = CalendarBirth.SelectedDate;
            int sex = Convert.ToInt16(ddlSex.SelectedValue);

            if (chkGroup.Checked)
                quantity = Convert.ToInt16(boxNumberAnimals.Text);
            else
                quantity = 1;

            recordID = Ctrl.insertAnimalInfo(localID, name, identityNumber, quantity, animalRace, animalCondition, animalHabitat, birth, sex);
            Ctrl.insertOwnerAnimalsRel(recordID);
            Response.Redirect("PageAnimalDashboard.aspx");
        }
    }
}