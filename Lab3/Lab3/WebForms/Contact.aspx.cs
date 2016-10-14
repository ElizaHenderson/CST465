using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3.WebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            uxEventOutput.Text += "oninit";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            uxEventOutput.Text += ", onload";

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            uxEventOutput.Text += ", onprerender";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder submit = new StringBuilder();
            submit.Append("Name: " + uxName.Text + "<br />");
            submit.Append("Priority: " + uxPriority.SelectedValue + "<br />");
            submit.Append("Subject: " + uxSubject.Text + "<br />");
            submit.Append("Description: " + uxDescription.Text + +"<br />");
        }
    }
}