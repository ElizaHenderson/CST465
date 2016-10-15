using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3.WebForms
{
    public partial class RequireedTextBox : System.Web.UI.UserControl
    {
        public string LabelText
        {
            get { return uxLabel.Text; }
            set { uxLabel.Text = value; }
        }

        public string TextBoxText
        {
            get { return uxTextBox.Text; }
            set { uxTextBox.Text = value; }
        }

        public string ValidationGroup
        {
            get { return uxFieldValidator.ValidationGroup.ToString(); }
            set { uxFieldValidator.ValidationGroup = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}