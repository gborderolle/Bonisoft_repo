using Bonisoft_2.Models;
using Bonisoft_2.Global_Objects;
using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls.Configuracion
{
    public partial class Mercaderias : System.Web.UI.UserControl
    {
        public string Viaje_ID1
        {
            get
            {
                if (ViewState["viaje_ID1"] == null)
                    return string.Empty;
                else
                    return ViewState["viaje_ID1"].ToString();
            }
            set { ViewState["viaje_ID1"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridMercaderias.UseAccessibleHeader = true;
            gridMercaderias.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        public void BindGrid()
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;


            using (bonisoftEntities context = new bonisoftEntities())
            {
                bool ok = false;

                if (!string.IsNullOrWhiteSpace(Viaje_ID1))
                {
                    int viaje_ID = 0;
                    if (!int.TryParse(Viaje_ID1, out viaje_ID))
                    {
                        viaje_ID = 0;
                        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, Viaje_ID1);
                    }
                    if (viaje_ID > 0)
                    {
                        var elements = context.mercaderia_comprada.Where(e => e.Viaje_ID == viaje_ID).ToList();
                        if (elements.Count() > 0)
                        {
                            gridMercaderias.DataSource = elements;
                            gridMercaderias.DataBind();

                            hdnMercaderiasCount.Value = elements.Count().ToString();

                            ok = true;
                        }
                    }
                }
                if (!ok)
                {
                    var obj = new List<mercaderia_comprada>();
                    obj.Add(new mercaderia_comprada());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridMercaderias.DataSource = obj;
                    gridMercaderias.DataBind();
                    int columnsCount = gridMercaderias.Columns.Count;
                    gridMercaderias.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridMercaderias.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridMercaderias.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridMercaderias.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridMercaderias.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridMercaderias.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridMercaderias.Rows[0].Cells[0].Text = "No hay registros";
                }
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModalDialog", "<script type='text/javascript'>$('.datepicker').datepicker();  </script>", false);
            }
        }

        protected void gridMercaderias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Updatepanel triggers

            ScriptManager ScriptManager1 = ScriptManager.GetCurrent(this.Page);
            if (ScriptManager1 != null)
            {
                LinkButton lnk = null;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    lnk = e.Row.FindControl("lnkEdit") as LinkButton;
                }
                if (lnk != null)
                {
                    ScriptManager1.RegisterAsyncPostBackControl(lnk);
                }

                lnk = null;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    lnk = e.Row.FindControl("lnkDelete") as LinkButton;
                }
                if (lnk != null)
                {
                    ScriptManager1.RegisterAsyncPostBackControl(lnk);
                }

                lnk = null;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    lnk = e.Row.FindControl("lnkInsert") as LinkButton;
                }
                if (lnk != null)
                {
                    ScriptManager1.RegisterAsyncPostBackControl(lnk);
                }

                lnk = null;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    lnk = e.Row.FindControl("lnkCancel") as LinkButton;
                }
                if (lnk != null)
                {
                    ScriptManager1.RegisterAsyncPostBackControl(lnk);
                }
            }

            #endregion

        }

        protected void gridMercaderias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            #region InsertNew

            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridMercaderias.FooterRow;
                
                //HiddenField hdn_modalMercaderia_txbNew4 = this.Parent.FindControl("hdn_modalMercaderia_txbNew4") as HiddenField;
                HiddenField hdn_modalMercaderia_txbNew5 = this.Parent.FindControl("hdn_modalMercaderia_txbNew5") as HiddenField;
                HiddenField hdn_modalMercaderia_txbNew7 = this.Parent.FindControl("hdn_modalMercaderia_txbNew7") as HiddenField;

                if (hdn_modalMercaderia_txbNew5 != null && hdn_modalMercaderia_txbNew7 != null)
                {
                    //string txb4 = hdn_modalMercaderia_txbNew4.Value;
                    string txb5 = hdn_modalMercaderia_txbNew5.Value;
                    string txb7 = hdn_modalMercaderia_txbNew7.Value;

                    int viaje_ID = 0;
                    if (!int.TryParse(Viaje_ID1, out viaje_ID))
                    {
                        viaje_ID = 0;
                        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, Viaje_ID1);
                    }
                    if (viaje_ID > 0)
                    {
                        using (bonisoftEntities context = new bonisoftEntities())
                        {
                            mercaderia_comprada obj = new mercaderia_comprada();
                            obj.Comentarios = txb7;

                            decimal valor = 0;
                            if (!string.IsNullOrWhiteSpace(txb5))
                            {
                                if (!decimal.TryParse(txb5, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
                                {
                                    valor = 0;
                                    Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo decimal. ERROR:", className, methodName, txb5);
                                }
                            }
                            obj.Precio_xTonelada_compra = valor;

                            #region Datetime logic

                            DateTime date1 = DateTime.Now;
                            //if (!string.IsNullOrWhiteSpace(txb4))
                            //{
                            //    if (!DateTime.TryParseExact(txb4, GlobalVariables.ShortDateTime_format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
                            //    {
                            //        date1 = DateTime.Now;
                            //        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo datetime. ERROR:", className, methodName, txb4);
                            //    }
                            //}
                            obj.Fecha_corte = date1;

                            #endregion

                            obj.Viaje_ID = viaje_ID;

                            context.mercaderia_comprada.Add(obj);
                            context.SaveChanges();

                            #region Guardar log 

                            try
                            {
                                int id = 1;
                                mercaderia_comprada mercaderia_comprada1 = (mercaderia_comprada)context.mercaderia_comprada.OrderByDescending(p => p.Mercaderia_ID).FirstOrDefault();
                                if (mercaderia_comprada1 != null)
                                {
                                    id = mercaderia_comprada1.Mercaderia_ID;
                                }

                                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                                string username = HttpContext.Current.Session["UserName"].ToString();
                                Global_Objects.Logs.AddUserLog("Agrega mercadería", mercaderia_comprada1.GetType().Name + ": " + id, userID1, username);
                            }
                            catch (Exception ex)
                            {
                                Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                            }

                            #endregion

                            lblMessage.Text = "Agregado correctamente.";
                            BindGrid();

                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModalDialog", "<script type='text/javascript'>show_message_accept('OK_Datos'); $.modal.close();</script>", false);
                        }
                    }
                }
            }

            #endregion

            else if (e.CommandName == "View")
            {
                string[] values = e.CommandArgument.ToString().Split(new char[] { ',' });
                if (values.Length > 1)
                {
                    string tabla = values[0];
                    string dato = values[1];
                    if (!string.IsNullOrWhiteSpace(tabla) && !string.IsNullOrWhiteSpace(dato))
                    {
                        Response.Redirect("Listados.aspx?tabla=" + tabla + "&dato=" + dato);
                    }
                }

            }
        }

        protected void gridMercaderias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridMercaderias.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gridMercaderias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridMercaderias.EditIndex = -1;
            BindGrid();
        }

        protected void gridMercaderias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            //HiddenField hdn_modalMercaderia_txb4 = this.Parent.FindControl("hdn_modalMercaderia_txb4") as HiddenField;
            HiddenField hdn_modalMercaderia_txb5 = this.Parent.FindControl("hdn_modalMercaderia_txb5") as HiddenField;
            HiddenField hdn_modalMercaderia_txb7 = this.Parent.FindControl("hdn_modalMercaderia_txb7") as HiddenField;

            if (hdn_modalMercaderia_txb5 != null && hdn_modalMercaderia_txb7 != null)
            {
                //string txb4 = hdn_modalMercaderia_txb4.Value;
                string txb5 = hdn_modalMercaderia_txb5.Value;
                string txb7 = hdn_modalMercaderia_txb7.Value;

                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int mercaderia_ID = Convert.ToInt32(gridMercaderias.DataKeys[e.RowIndex].Value);
                    mercaderia_comprada obj = context.mercaderia_comprada.First(x => x.Mercaderia_ID == mercaderia_ID);
                    obj.Comentarios = txb7;

                    decimal valor = obj.Precio_xTonelada_compra;
                    if (!decimal.TryParse(txb5, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
                    {
                        valor = obj.Precio_xTonelada_compra;
                        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo decimal. ERROR:", className, methodName, txb5);
                    }
                    obj.Precio_xTonelada_compra = valor;

                    #region Datetime logic

                    DateTime date1 = obj.Fecha_corte;
                    //if (!string.IsNullOrWhiteSpace(txb4))
                    //{
                    //    if (!DateTime.TryParseExact(txb4, GlobalVariables.ShortDateTime_format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
                    //    {
                    //        date1 = obj.Fecha_corte;
                    //        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo datetime. ERROR:", className, methodName, txb4);
                    //    }
                    //}
                    obj.Fecha_corte = date1;

                    #endregion Datetime logic

                    context.SaveChanges();

                    #region Guardar log 
                    try
                    {
                        string userID1 = HttpContext.Current.Session["UserID"].ToString();
                        string username = HttpContext.Current.Session["UserName"].ToString();
                        Global_Objects.Logs.AddUserLog("Modifica mercadería", obj.GetType().Name + ": " + obj.Mercaderia_ID, userID1, username);
                    }
                    catch (Exception ex)
                    {
                        Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                    }
                    #endregion

                    lblMessage.Text = "Guardado correctamente.";
                    gridMercaderias.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridMercaderias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;


            int mercaderias_ID = Convert.ToInt32(gridMercaderias.DataKeys[e.RowIndex].Value);
            using (bonisoftEntities context = new bonisoftEntities())
            {
                mercaderia_comprada obj = context.mercaderia_comprada.First(x => x.Mercaderia_ID == mercaderias_ID);
                context.mercaderia_comprada.Remove(obj);
                context.SaveChanges();

                #region Guardar log 
                try
                {
                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Global_Objects.Logs.AddUserLog("Borra mercadería", obj.GetType().Name + ": " + obj.Mercaderia_ID, userID1, username);
                }
                catch (Exception ex)
                {
                    Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                }
                #endregion

                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridMercaderias.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridMercaderias.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }
    }
}