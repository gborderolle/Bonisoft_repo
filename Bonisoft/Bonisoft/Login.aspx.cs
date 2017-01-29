using Bonisoft.Models;
using Bonisoft.Global_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft
{
    public partial class Login : System.Web.UI.Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            Logout();
        }

        protected void btnSubmit_candidato1_ServerClick(object sender, EventArgs e)
        {
            string username = txbUser1.Value;
            string password = txbPassword1.Value;
            Perform_login(username, password, false);
        }

        #endregion Events

        #region Methods

        private void Logout()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
        }

        private void Perform_login(string username, string password, bool isPasswordInput_hashed = false)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            int resultado = 0;
            if (!string.IsNullOrWhiteSpace(username) || !string.IsNullOrWhiteSpace(password))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    try
                    {
                        usuario usuario = (usuario)context.usuarios.FirstOrDefault(v => v.Usuario1 == username && v.Clave == password);
                        if (usuario != null)
                        {
                            Session["UserID"] = usuario.Usuario_ID;
                            Session["UserName"] = username;

                            Response.Redirect("Pages/Viajes", false);
                        }
                        else
                        {
                            resultado = 2;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logs.AddErrorLog("Excepcion. Haciendo login. ERROR:", className, methodName, ex.Message);
                        resultado = 3;
                    }
                }
            }
            else
            {
                resultado = 1;
            }

            ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowErrorMessage", "ShowErrorMessage('" + resultado + "');", true);
        }

        #endregion Methods

    }
}