using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3.WebForms
{
    public partial class ValidatedForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            Validate();

            if (Page.IsValid == false)
                return;

            StringBuilder form = new StringBuilder();

            form.Append("?name=" + uxName.TextBoxText);
            form.Append("&favoritecolor=" + uxColor.TextBoxText);
            form.Append("&city=" + uxCity.TextBoxText);

            Response.Redirect("ValidatedFromOutput.aspx" + form);
        }
    }
}