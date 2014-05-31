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

        protected void LoadInfo()
        {
            SqlDataReader dr = Ctrl.getOwnerLocals().ExecuteReader();

            // Efectuar o data binding
            tblLocals.DataSource = dr;
            tblLocals.DataBind();

            dr.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            pnlError.Visible = false;
            pnlErrorDelete.Visible = false;

                if (!string.IsNullOrEmpty(Request.QueryString["Error"]))
                    pnlError.Visible = true;                

                refreshController();

                LoadInfo();
        }

        protected void linkDelete_ServerClick(object sender, EventArgs e)
        {
            HtmlAnchor link = (HtmlAnchor)sender;
            int ownerLocalID = Convert.ToInt32(link.Attributes["data-ownerlocalid"]);

               if (ownerLocalID > 0)
                {
                    if (Ctrl.isOwnerOfLocal(ownerLocalID))
                    {
                        if (!Ctrl.isAnimalsInThisLocal(ownerLocalID))
                        {
                            Ctrl.deleteOwnerLocal(ownerLocalID);
                            LoadInfo();
                        }
                        else
                            pnlErrorDelete.Visible = true;
                    }
                    else
                        Response.Redirect("/PageClientLocals.aspx");
                }
                else
                    Response.Redirect("/PageClientLocals.aspx");

        }
    }
}