using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace C_Shop.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.AbsolutePath.Contains("Default.aspx"))
            {
                Control SliderUserControl = (Control)Page.LoadControl("~/User/SliderUserControl.ascx");
                pnlSliderUC.Controls.Add(SliderUserControl);
            }
        }
    }
}