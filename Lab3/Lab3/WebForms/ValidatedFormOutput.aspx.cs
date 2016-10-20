using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3.WebForms
{
    public partial class ValidatedFormOutput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["name"] ==null || Request.QueryString["favoritecolor"] == null || Request.QueryString["city"] == null)
            {
                uxInvalidDataArea.Visible = true;
            }

            uxName.Text = Request.QueryString["name"];
            uxFavoriteColor.Text = Request.QueryString["favoritecolor"];
            uxCity.Text = Request.QueryString["city"];

            uxValidDataArea.Visible = true;

        }
    }
}