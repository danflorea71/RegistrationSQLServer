using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationSQLServer
{
    public partial class DeleteUserInformation : System.Web.UI.Page
    {
        private int GetRequestId()
        {
            int userId = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                userId = Convert.ToInt32(Request.QueryString["id"]);
            }

            return userId;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int result = 0;

                try
                {
                    result = DBLayer.DBUtilities.DeleteUserInformationById(GetRequestId());
                }
                catch(SqlException ex)
                {
                    Response.Write(ex.Message);
                }

                if (result == 1)
                    this.lblDeleteMessage.Text = $"User Information Record with the Id={GetRequestId()} Successfully deleted";
                else
                    this.lblDeleteMessage.Text = "There was a problem deleting the record";
            }
        }
    }
}