using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Datos_configuracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Web methods

        [WebMethod]
        public static bool CheckUserAdmin(string userID_str)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            bool isAdmin = false;
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                if (!string.IsNullOrWhiteSpace(userID_str))
                {
                    int userID = 0;
                    if (!int.TryParse(userID_str, out userID))
                    {
                        userID = 0;
                        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, userID_str);
                        //Global_Objects.ErrorLog.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, e.Message);
                    }

                    if (userID > 0)
                    {
                        usuario usuario = (usuario)context.usuarios.FirstOrDefault(v => v.Usuario_ID == userID);
                        if (usuario != null)
                        {
                            isAdmin = usuario.EsAdmin;
                        }
                    }
                }
            }
            return isAdmin;
        }

        #endregion
    }
}