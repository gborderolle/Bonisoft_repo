using Bonisoft.Models;
using Bonisoft.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft.User_Controls
{
    public partial class Clientes : System.Web.UI.UserControl
    {
        public event Action LoadCompleted = delegate { };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridClientes.UseAccessibleHeader = true;
            gridClientes.HeaderRow.TableSection = TableRowSection.TableHeader;
            //this.LoadCompleted();
        }

        private void BindGrid()
        {
            using (bonisoftEntities context = new bonisoftEntities())
            {
                hdnClientesCount.Value = context.clientes.Where(e => e.EsBarraca == null || e.EsBarraca == false).Count().ToString();
                if (context.clientes.Count() > 0)
                {
                    gridClientes.DataSource = context.clientes.Where(e => e.EsBarraca == null || e.EsBarraca == false).ToList();
                    gridClientes.DataBind();
                }
                else
                {
                    var obj = new List<cliente>();
                    obj.Add(new cliente());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridClientes.DataSource = obj;
                    gridClientes.DataBind();
                    int columnsCount = gridClientes.Columns.Count;
                    gridClientes.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridClientes.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridClientes.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridClientes.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridClientes.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridClientes.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridClientes.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Action buttons

            ScriptManager ScriptManager1 = ScriptManager.GetCurrent(this.Page);
            if (ScriptManager1 != null)
            {
                LinkButton lnk = null;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    lnk = e.Row.FindControl("lnkEdit") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkDelete") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkInsert") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkCancel") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }
                }
            }

            #endregion
        }

        protected void gridClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridClientes.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb5 = row.FindControl("txbNew5") as TextBox;
                TextBox txb7 = row.FindControl("txbNew7") as TextBox;
                TextBox txb13 = row.FindControl("txbNew13") as TextBox;
                TextBox txb14 = row.FindControl("txbNew14") as TextBox;
                TextBox txb15 = row.FindControl("txbNew15") as TextBox;
                TextBox txb16 = row.FindControl("txbNew16") as TextBox;
                TextBox txb17 = row.FindControl("txbNew17") as TextBox;
                TextBox txb22 = row.FindControl("txbNew22") as TextBox;
                TextBox txb23 = row.FindControl("txbNew23") as TextBox;
                TextBox txb24 = row.FindControl("txbNew24") as TextBox;
                if (txb1 != null && txb3 != null && txb5 != null && txb13 != null && txb14 != null && txb15 != null &&
                    txb16 != null && txb17 != null && txb22 != null && txb23 != null && txb24 != null)
                {
                    using (bonisoftEntities context = new bonisoftEntities())
                    {
                        cliente obj = new cliente();
                        obj.Dueno_nombre = txb1.Text;
                        obj.Encargado_lena_nombre = txb3.Text;
                        obj.Encargado_pagos_nombre = txb5.Text;
                        //obj.Supervisor_lena_nombre = txb7.Text;
                        obj.Supervisor_lena_nombre = string.Empty;
                        obj.Nombre = txb13.Text;
                        obj.Razon_social = txb14.Text;
                        obj.RUT = txb15.Text;
                        obj.Direccion = txb16.Text;
                        obj.Telefono = txb17.Text;
                        obj.Comentarios = txb22.Text;
                        obj.Email = txb23.Text;
                        obj.Nro_cuenta = txb24.Text;

                        //
                        obj.Forma_de_pago_ID = 0;
                        obj.Dueno_contacto = string.Empty;
                        obj.Encargado_lena_contacto = string.Empty;
                        obj.Encargado_pagos_contacto = string.Empty;
                        obj.Supervisor_lena_contacto = string.Empty;
                        obj.Periodos_liquidacion = string.Empty;
                        obj.Fechas_pago = string.Empty;
                        //

                        obj.EsBarraca = false;

                        context.clientes.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
                        try
                        {
                            int id = 1;
                            cliente cliente = (cliente)context.clientes.OrderByDescending(p => p.cliente_ID).FirstOrDefault();
                            if (cliente != null)
                            {
                                id = cliente.cliente_ID;
                            }

                            string userID1 = HttpContext.Current.Session["UserID"].ToString();
                            string username = HttpContext.Current.Session["UserName"].ToString();
                            Global_Objects.Logs.AddUserLog("Agrega cliente", cliente.GetType().Name + ": " + id, userID1, username);
                        }
                        catch (Exception ex)
                        {
                            Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                        }
                        #endregion

                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
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
            else
            {
                //BindGrid();
            }
        }

        protected void gridClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridClientes.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridClientes.EditIndex = -1;
            BindGrid();
        }
        protected void gridClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            GridViewRow row = gridClientes.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb5 = row.FindControl("txb5") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            TextBox txb13 = row.FindControl("txb13") as TextBox;
            TextBox txb14 = row.FindControl("txb14") as TextBox;
            TextBox txb15 = row.FindControl("txb15") as TextBox;
            TextBox txb16 = row.FindControl("txb16") as TextBox;
            TextBox txb17 = row.FindControl("txb17") as TextBox;
            TextBox txb22 = row.FindControl("txb22") as TextBox;
            TextBox txb23 = row.FindControl("txb23") as TextBox;
            TextBox txb24 = row.FindControl("txb24") as TextBox;
            if (txb1 != null && txb3 != null && txb5 != null && txb13 != null && txb14 != null && txb15 != null &&
                txb16 != null && txb17 != null && txb22 != null && txb23 != null && txb24 != null)
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int cliente_ID = Convert.ToInt32(gridClientes.DataKeys[e.RowIndex].Value);
                    cliente obj = context.clientes.First(x => x.cliente_ID == cliente_ID);
                    obj.Dueno_nombre = txb1.Text;
                    obj.Encargado_lena_nombre = txb3.Text;
                    obj.Encargado_pagos_nombre = txb5.Text;
                    //obj.Supervisor_lena_nombre = txb7.Text;
                    obj.Supervisor_lena_nombre = string.Empty;
                    obj.Nombre = txb13.Text;
                    obj.Razon_social = txb14.Text;
                    obj.RUT = txb15.Text;
                    obj.Direccion = txb16.Text;
                    obj.Telefono = txb17.Text;
                    obj.Comentarios = txb22.Text;
                    obj.Email = txb23.Text;
                    obj.Nro_cuenta = txb24.Text;

                    context.SaveChanges();

                    #region Guardar log 
                    try
                    {
                        string userID1 = HttpContext.Current.Session["UserID"].ToString();
                        string username = HttpContext.Current.Session["UserName"].ToString();
                        Global_Objects.Logs.AddUserLog("Modifica cliente", obj.GetType().Name + ": " + obj.cliente_ID, userID1, username);
                    }
                    catch (Exception ex)
                    {
                        Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                    }
                    #endregion

                    lblMessage.Text = "Guardado correctamente.";
                    gridClientes.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;


            int cliente_ID = Convert.ToInt32(gridClientes.DataKeys[e.RowIndex].Value);
            using (bonisoftEntities context = new bonisoftEntities())
            {
                cliente obj = context.clientes.First(x => x.cliente_ID == cliente_ID);
                context.clientes.Remove(obj);
                context.SaveChanges();

                #region Guardar log 
                try
                {
                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Global_Objects.Logs.AddUserLog("Borra cliente", obj.GetType().Name + ": " + obj.cliente_ID, userID1, username);
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
            GridViewRow pagerRow = gridClientes.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridClientes.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}