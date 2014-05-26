using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AnimalCare.Client
{
    public partial class PageClientLocals : ClientPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (User.Identity.IsAuthenticated)
            {
                refreshController();

                SqlDataReader dr = Ctrl.getOwnerLocals().ExecuteReader();

                // Efectuar o data binding
                tabelaLocais.DataSource = dr;
                tabelaLocais.DataBind();

                dr.Close();
                Ctrl.Database.Connection.Close();
            }
        }

        protected void linkDelete_ServerClick(object sender, EventArgs e)
        {
            DBConn db = new DBConn();

            HtmlAnchor link = (HtmlAnchor)sender;

            // Obtém o ID
            int ownerLocalID = Convert.ToInt32(link.Attributes["data-ownerlocalid"]);

            if (ownerLocalID <= 0)
                return;

            String str = "DELETE FROM OwnerLocals WHERE [OwnerLocalID] = @id";
            // SQL Query
            SqlCommand cmd = new SqlCommand(str, db.Connection);
            cmd.Parameters.AddWithValue("@id", ownerLocalID);

            db.Connection.Open();

            // Executa
            int count = cmd.ExecuteNonQuery();

            db.Connection.Close();

            // Refrescar página
            Response.Redirect("PageClientLocals.aspx");
        }
    }
}