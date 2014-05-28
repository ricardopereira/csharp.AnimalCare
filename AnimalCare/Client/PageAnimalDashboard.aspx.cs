using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageAnimalDashboard : ClientPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
            {
                SqlDataReader dr = Ctrl.getOwnerAnimals().ExecuteReader();
                // Efectuar o data binding
                tabelaAnimais.DataSource = dr;
                tabelaAnimais.DataBind();
                dr.Close();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataReader dr = Ctrl.getOwnerAnimals(boxFilter.Text.Trim()).ExecuteReader();
            // Efectuar o data binding
            tabelaAnimais.DataSource = dr;
            tabelaAnimais.DataBind();
            dr.Close();
        }
    }
}