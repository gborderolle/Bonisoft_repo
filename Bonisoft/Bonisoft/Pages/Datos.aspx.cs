using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft.Pages
{
    public partial class Datos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // http://www.aspsnippets.com/Articles/Assign-PostBack-Trigger-Full-PostBack-for-LinkButton-inside-GridView-within-AJAX-UpdatePanel-in-ASPNet.aspx
            // Source: http://stackoverflow.com/questions/11235062/is-there-an-after-page-load-event-in-asp-net
            //this.Clientes.LoadCompleted += () =>
            //{
            //    ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            //    Control ctrl = Clientes.FindControl("lnkEdit");
            //    if (ctrl != null)
            //    {
            //        scriptManager.RegisterPostBackControl(ctrl);
            //    }
            //};
        }
    }
}