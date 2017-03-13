using Bonisoft.Global_Objects;
using Bonisoft.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Bonisoft.Models;

namespace Bonisoft.Pages
{
    public partial class Resumen_proveedores : System.Web.UI.Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridProveedores();
                BindModalAgregarPago();
                BindModalModificarPago();
            }

            gridProveedores.UseAccessibleHeader = true;
            gridProveedores.HeaderRow.TableSection = TableRowSection.TableHeader;

            gridProveedores_lblMessage.Text = string.Empty;
        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            gridPagos.PageIndex = e.NewPageIndex;

            string proveedor_ID_str = hdn_proveedorID.Value;
            if (!string.IsNullOrWhiteSpace(proveedor_ID_str))
            {
                int Proveedor_ID = 0;
                if (!int.TryParse(proveedor_ID_str, out Proveedor_ID))
                {
                    Proveedor_ID = 0;
                    Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, proveedor_ID_str);
                }

                if (Proveedor_ID > 0)
                {
                    BindGridPagos(Proveedor_ID);
                }
            }
        }

        protected void grid2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProveedores.PageIndex = e.NewPageIndex;
            BindGridProveedores();
        }

        protected void grid3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            gridViajes.PageIndex = e.NewPageIndex;

            string proveedor_ID_str = hdn_proveedorID.Value;
            if (!string.IsNullOrWhiteSpace(proveedor_ID_str))
            {
                int proveedor_ID = 0;
                if (!int.TryParse(proveedor_ID_str, out proveedor_ID))
                {
                    proveedor_ID = 0;
                    Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, proveedor_ID_str);
                }

                if (proveedor_ID > 0)
                {
                    BindGridViajes(proveedor_ID);
                }
            }
        }

        protected void gridProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                if (!string.IsNullOrWhiteSpace(e.CommandArgument.ToString()) && !string.IsNullOrWhiteSpace(e.CommandName))
                {
                    using (bonisoftEntities context = new bonisoftEntities())
                    {

                    }
                }
            }
        }

        protected void gridProveedores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Buttons

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }

            #endregion Buttons

            #region Labels

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }

            #endregion Labels

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridProveedores, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gridViajes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region DDL Default values

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Fleteros ----------------------------------------------------
                Label lbl = e.Row.FindControl("lblFletero") as Label;
                if (lbl != null)
                {
                    lbl.Text = string.Empty;
                    using (bonisoftEntities context = new bonisoftEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Fletero_ID;
                            fletero fletero = (fletero)context.fleteros.FirstOrDefault(c => c.Fletero_ID == id);
                            if (fletero != null)
                            {
                                string nombre = fletero.Nombre;
                                lbl.Text = nombre;
                                //lbl.CommandArgument = "fleteros," + fletero.Nombre;
                            }
                        }
                    }
                }

                // Camion ----------------------------------------------------
                lbl = e.Row.FindControl("lblCamion") as Label;
                if (lbl != null)
                {
                    lbl.Text = string.Empty; using (bonisoftEntities context = new bonisoftEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Camion_ID;
                            camion camion = (camion)context.camiones.FirstOrDefault(c => c.Camion_ID == id);
                            if (camion != null)
                            {
                                string nombre = camion.Matricula_camion;
                                lbl.Text = nombre;
                                //lbl.CommandArgument = "camiones," + camion.Marca;
                            }
                        }
                    }
                }

                // Chofer ----------------------------------------------------
                lbl = e.Row.FindControl("lblChofer") as Label;
                if (lbl != null)
                {
                    lbl.Text = string.Empty; using (bonisoftEntities context = new bonisoftEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Chofer_ID;
                            chofer chofer = (chofer)context.choferes.FirstOrDefault(c => c.Chofer_ID == id);
                            if (chofer != null)
                            {
                                string nombre = chofer.Nombre_completo;
                                lbl.Text = nombre;
                                //lbl.CommandArgument = "choferes," + chofer.Nombre_completo;
                            }
                        }
                    }
                }

                // Cliente ----------------------------------------------------
                lbl = e.Row.FindControl("lblCliente") as Label;
                if (lbl != null)
                {
                    lbl.Text = string.Empty; using (bonisoftEntities context = new bonisoftEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Cliente_ID;
                            cliente cliente = (cliente)context.clientes.FirstOrDefault(c => c.cliente_ID == id);
                            if (cliente != null)
                            {
                                string nombre = cliente.Nombre;
                                lbl.Text = nombre;
                                //lbl.CommandArgument = "proveedores," + proveedor.Nombre;
                            }
                        }
                    }
                }

                //// Pesada origen ----------------------------------------------------
                //lbl = e.Row.FindControl("lblPesadaOrigen") as Label;
                //if (lbl != null)
                //{
                //    lbl.Text = string.Empty; using (bonisoftEntities context = new bonisoftEntities())
                //    {
                //        viaje viaje = (viaje)(e.Row.DataItem);
                //        if (viaje != null)
                //        {
                //            int id = viaje.Pesada_ID;
                //            pesada pesada = (pesada)context.pesadas.FirstOrDefault(c => c.pesada_ID == id);
                //            if (pesada != null)
                //            {
                //                lbl.Text = pesada.Origen_lugar + ": " + pesada.Origen_peso_neto;
                //                //string nombre = pesada.ToString();
                //                //lbl.Text = nombre;
                //            }
                //        }
                //    }
                //}

                //// Pesada destino ----------------------------------------------------
                //lbl = e.Row.FindControl("lblPesadaDestino") as Label;
                //if (lbl != null)
                //{
                //    lbl.Text = string.Empty; using (bonisoftEntities context = new bonisoftEntities())
                //    {
                //        viaje viaje = (viaje)(e.Row.DataItem);
                //        if (viaje != null)
                //        {
                //            int id = viaje.Pesada_ID;
                //            pesada pesada = (pesada)context.pesadas.FirstOrDefault(c => c.pesada_ID == id);
                //            if (pesada != null)
                //            {
                //                lbl.Text = pesada.Destino_lugar + ": " + pesada.Destino_peso_neto;
                //                //string nombre = pesada.ToString();
                //                //lbl.Text = nombre;
                //            }
                //        }
                //    }
                //}

                lbl = e.Row.FindControl("lblFechaPartida") as Label;
                if (lbl != null)
                {
                    using (bonisoftEntities context = new bonisoftEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            if (viaje.Fecha_partida == DateTime.MinValue)
                            {
                                lbl.Text = string.Empty;
                            }
                        }
                    }

                }

            }
            #endregion
        }

        protected void gridViajes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {

            }
            else if (e.CommandName.Equals("View"))
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

        protected void gridPagos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region DDL Default values

            // Formas de pago ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = e.Row.FindControl("lblForma") as LinkButton;
                if (lnk != null)
                {
                    lnk.Text = string.Empty; using (bonisoftEntities context = new bonisoftEntities())
                    {
                        proveedor_pagos pago = (proveedor_pagos)(e.Row.DataItem);
                        if (pago != null)
                        {
                            int id = pago.Forma_de_pago_ID;
                            forma_de_pago forma = (forma_de_pago)context.forma_de_pago.FirstOrDefault(c => c.Forma_de_pago_ID == id);
                            if (forma != null)
                            {
                                string nombre = forma.Forma;
                                lnk.Text = nombre;
                                lnk.CommandArgument = "formas," + nombre;
                            }
                        }
                    }
                }

                Label lbl = e.Row.FindControl("lblFechaPago") as Label;
                if (lbl != null)
                {
                    using (bonisoftEntities context = new bonisoftEntities())
                    {
                        proveedor_pagos pago = (proveedor_pagos)(e.Row.DataItem);
                        if (pago != null)
                        {
                            if (pago.Fecha_pago == DateTime.MinValue)
                            {
                                lbl.Text = string.Empty;
                            }
                        }
                    }
                }

            }

            #endregion
        }

        protected void gridPagos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {

            }
            else if (e.CommandName.Equals("View"))
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

        protected void gridProveedores_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Source: http://www.codeproject.com/Tips/622720/Fire-GridView-SelectedIndexChanged-Event-without-S

            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            foreach (GridViewRow row in gridProveedores.Rows)
            {
                if (row.RowIndex == gridProveedores.SelectedIndex)
                {
                    string proveedor_ID_str = gridProveedores.SelectedRow.Cells[0].Text;
                    if (!string.IsNullOrWhiteSpace(proveedor_ID_str))
                    {
                        int proveedor_ID = 0;
                        if (!int.TryParse(proveedor_ID_str, out proveedor_ID))
                        {
                            proveedor_ID = 0;
                            Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, proveedor_ID_str);
                        }

                        if (proveedor_ID > 0)
                        {
                            using (bonisoftEntities context = new bonisoftEntities())
                            {
                                proveedor proveedor = (proveedor)context.proveedores.FirstOrDefault(c => c.Proveedor_ID == proveedor_ID);
                                if (proveedor != null)
                                {
                                    lblProveedorName_1.Text = proveedor.Nombre;

                                    BindGridViajes(proveedor_ID);
                                    BindGridPagos(proveedor_ID);

                                    hdn_proveedorID.Value = proveedor_ID_str;

                                    gridViajes.UseAccessibleHeader = true;
                                    gridViajes.HeaderRow.TableSection = TableRowSection.TableHeader;
                                }
                            }
                        }
                    }
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    foreach (TableCell cell in row.Cells)
                    {
                        cell.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    }
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    foreach (TableCell cell in row.Cells)
                    {
                        cell.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                }
            }
        }

        #endregion Events

        #region General methods

        private void BindGridProveedores()
        {
            using (bonisoftEntities context = new bonisoftEntities())
            {
                var elements = context.proveedores.OrderBy(e => e.Nombre).ToList();
                if (elements.Count() > 0)
                {
                    gridProveedores.DataSource = elements;
                    gridProveedores.DataBind();

                    gridProveedores.UseAccessibleHeader = true;
                    gridProveedores.HeaderRow.TableSection = TableRowSection.TableHeader;

                    lblgridProveedoresCount.Text = "# " + elements.Count();
                }
                else
                {
                    var obj = new List<proveedor>();
                    obj.Add(new proveedor());

                    // Bind the DataTable which contain a blank row to the GridView
                    gridProveedores.DataSource = obj;
                    gridProveedores.DataBind();
                    int columnsCount = gridProveedores.Columns.Count;
                    gridProveedores.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridProveedores.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridProveedores.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridProveedores.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridProveedores.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridProveedores.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    gridProveedores.Rows[0].Cells[0].Text = "No hay registros";
                }
            }
        }

        private void BindGridViajes(int proveedor_ID)
        {
            if (proveedor_ID > 0)
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    var elements = context.viajes.Where(v => v.Proveedor_ID == proveedor_ID && !v.isFicticio).ToList();
                    if (elements.Count() > 0)
                    {
                        gridViajes.DataSource = elements;
                        gridViajes.DataBind();

                        gridViajes.UseAccessibleHeader = true;
                        gridViajes.HeaderRow.TableSection = TableRowSection.TableHeader;

                        lblGridViajesCount.Text = "# " + elements.Count();
                    }
                    else
                    {
                        var obj = new List<viaje>();
                        obj.Add(new viaje());

                        /* Grid Viajes */

                        // Bind the DataTable which contain a blank row to the GridView
                        gridViajes.DataSource = obj;
                        gridViajes.DataBind();
                        int columnsCount = gridViajes.Columns.Count;
                        gridViajes.Rows[0].Cells.Clear();// clear all the cells in the row
                        gridViajes.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        gridViajes.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                        //You can set the styles here
                        gridViajes.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        gridViajes.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        gridViajes.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        gridViajes.Rows[0].Cells[0].Text = "No hay registros";
                    }
                }
            }
        }

        private void BindGridPagos(int proveedor_ID)
        {
            if (proveedor_ID > 0)
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    var elements = context.proveedor_pagos.Where(v => v.Proveedor_ID == proveedor_ID).ToList();
                    if (elements.Count() > 0)
                    {
                        gridPagos.DataSource = elements;
                        gridPagos.DataBind();

                        gridPagos.UseAccessibleHeader = true;
                        gridPagos.HeaderRow.TableSection = TableRowSection.TableHeader;

                        lblGridPagosCount.Text = "# " + elements.Count();
                    }
                    else
                    {
                        var obj = new List<proveedor_pagos>();
                        obj.Add(new proveedor_pagos());

                        /* Grid Viajes */

                        // Bind the DataTable which contain a blank row to the GridView
                        gridPagos.DataSource = obj;
                        gridPagos.DataBind();
                        int columnsCount = gridPagos.Columns.Count;
                        gridPagos.Rows[0].Cells.Clear();// clear all the cells in the row
                        gridPagos.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        gridPagos.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                        //You can set the styles here
                        gridPagos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        gridPagos.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        gridPagos.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        gridPagos.Rows[0].Cells[0].Text = "No hay registros";
                    }
                }
            }
        }

        private void BindModalAgregarPago()
        {
            // Formas de pago --------------------------------------------------
            if (add_ddlFormas != null)
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.forma_de_pago.ToList());

                    add_ddlFormas.DataSource = dt1;
                    add_ddlFormas.DataTextField = "Forma";
                    add_ddlFormas.DataValueField = "Forma_de_pago_ID";
                    add_ddlFormas.DataBind();
                    add_ddlFormas.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }
        }

        private void BindModalModificarPago()
        {
            // Formas de pago --------------------------------------------------
            if (edit_ddlFormas != null)
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.forma_de_pago.ToList());

                    edit_ddlFormas.DataSource = dt1;
                    edit_ddlFormas.DataTextField = "Forma";
                    edit_ddlFormas.DataValueField = "Forma_de_pago_ID";
                    edit_ddlFormas.DataBind();
                    edit_ddlFormas.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }
        }

        #endregion General methods

        #region Web methods

        [WebMethod]
        public static string Update_Saldos(string proveedorID_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string ret = string.Empty;
            if (!string.IsNullOrWhiteSpace(proveedorID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int proveedor_ID = 0;
                    if (!int.TryParse(proveedorID_str, out proveedor_ID))
                    {
                        proveedor_ID = 0;
                        Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, proveedorID_str);
                    }

                    if (proveedor_ID > 0)
                    {
                        #region Cálculo saldo inicial

                        decimal saldo_inicial = 0;
                        var viajes = context.viajes.Where(m => m.Proveedor_ID == proveedor_ID).ToList();
                        if (viajes.Count() > 0)
                        {
                            foreach (viaje viaje in viajes)
                            {
                                saldo_inicial += viaje.precio_venta;
                            }
                        }

                        #endregion Cálculo saldo inicial

                        #region Cálculo saldo final

                        decimal saldo_final = 0;
                        decimal total_pagos = 0;
                        var pagos = context.proveedor_pagos.Where(m => m.Proveedor_ID == proveedor_ID).ToList();
                        if (pagos.Count() > 0)
                        {
                            foreach (proveedor_pagos pago in pagos)
                            {
                                total_pagos += pago.Monto;
                            }
                        }

                        saldo_final = saldo_inicial - total_pagos;
                        ret = saldo_inicial.ToString() + "|" + saldo_final.ToString();

                        #endregion Cálculo saldo final

                    }
                }
            }

            return ret;
        }

        [WebMethod]
        public static bool IngresarPago(string proveedorID_str, string fecha_str, string ddlFormas, string monto_str, string comentarios_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            bool ret = false;
            if (!string.IsNullOrWhiteSpace(proveedorID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int proveedor_ID = 0;
                    if (!int.TryParse(proveedorID_str, out proveedor_ID))
                    {
                        proveedor_ID = 0;
                        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, proveedorID_str);
                    }

                    if (proveedor_ID > 0)
                    {
                        proveedor_pagos obj = new proveedor_pagos();

                        obj.Proveedor_ID = proveedor_ID;
                        obj.Comentarios = comentarios_str;
                        obj.Fecha_registro = DateTime.Now;

                        DateTime date = DateTime.MinValue;
                        if (!string.IsNullOrWhiteSpace(fecha_str))
                        {
                            if (!DateTime.TryParseExact(fecha_str, GlobalVariables.ShortDateTime_format, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                            {
                                date = DateTime.MinValue;
                                Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo datetime. ERROR:", className, methodName, fecha_str);
                            }
                        }
                        obj.Fecha_pago = date;

                        decimal value = 0;
                        if (!decimal.TryParse(monto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                        {
                            value = 0;
                            Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo decimal. ERROR:", className, methodName, monto_str);
                        }
                        obj.Monto = value;

                        int ddl = 0;
                        if (!int.TryParse(ddlFormas, out ddl))
                        {
                            ddl = 0;
                            Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, ddlFormas);
                        }
                        obj.Forma_de_pago_ID = ddl;

                        context.proveedor_pagos.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
                        try
                        {
                            int id = 1;
                            proveedor_pagos proveedor_pago1 = (proveedor_pagos)context.proveedor_pagos.OrderByDescending(p => p.Proveedor_pagos_ID).FirstOrDefault();
                            if (proveedor_pago1 != null)
                            {
                                id = proveedor_pago1.Proveedor_pagos_ID;
                            }

                            string userID1 = HttpContext.Current.Session["UserID"].ToString();
                            string username = HttpContext.Current.Session["UserName"].ToString();
                            Global_Objects.Logs.AddUserLog("Agrega pago", obj.GetType().Name + ": " + id, userID1, username);
                        }
                        catch (Exception ex)
                        {
                            Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                        }
                        #endregion

                        ret = true;
                    }
                }
            }

            return ret;
        }

        [WebMethod]
        public static bool BorrarPago(string pagoID_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            bool ret = false;
            if (!string.IsNullOrWhiteSpace(pagoID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int pago_ID_str = 0;
                    if (!int.TryParse(pagoID_str, out pago_ID_str))
                    {
                        pago_ID_str = 0;
                        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, pagoID_str);
                    }

                    if (pago_ID_str > 0)
                    {
                        proveedor_pagos pago = (proveedor_pagos)context.proveedor_pagos.FirstOrDefault(v => v.Proveedor_pagos_ID == pago_ID_str);
                        if (pago != null)
                        {
                            context.proveedor_pagos.Remove(pago);
                            context.SaveChanges();

                            #region Guardar log 
                            try
                            {
                                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                                string username = HttpContext.Current.Session["UserName"].ToString();
                                Global_Objects.Logs.AddUserLog("Borra pago", pago.GetType().Name + ": " + pago.Proveedor_pagos_ID, userID1, username);
                            }
                            catch (Exception ex)
                            {
                                Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                            }
                            #endregion

                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        [WebMethod]
        public static string ModificarPago_1(string pagoID_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string ret = string.Empty;
            if (!string.IsNullOrWhiteSpace(pagoID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int pago_ID = 0;
                    if (!int.TryParse(pagoID_str, out pago_ID))
                    {
                        pago_ID = 0;
                        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, pagoID_str);
                    }

                    if (pago_ID > 0)
                    {
                        proveedor_pagos pago = (proveedor_pagos)context.proveedor_pagos.FirstOrDefault(v => v.Proveedor_pagos_ID == pago_ID);
                        if (pago != null)
                        {
                            string fecha = pago.Fecha_pago.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                            ret = fecha + "|" + pago.Forma_de_pago_ID + "|" + pago.Monto + "|" + pago.Comentarios;
                        }
                    }
                }
            }
            return ret;
        }

        [WebMethod]
        public static bool ModificarPago_2(string pagoID_str, string fecha_str, string ddlFormas, string monto_str, string comentarios_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            bool ret = false;
            if (!string.IsNullOrWhiteSpace(pagoID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int pago_ID = 0;
                    if (!int.TryParse(pagoID_str, out pago_ID))
                    {
                        pago_ID = 0;
                        Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, pagoID_str);
                    }

                    if (pago_ID > 0)
                    {
                        proveedor_pagos pago = (proveedor_pagos)context.proveedor_pagos.FirstOrDefault(v => v.Proveedor_pagos_ID == pago_ID);
                        if (pago != null)
                        {
                            DateTime date = pago.Fecha_pago;
                            if (!string.IsNullOrWhiteSpace(fecha_str))
                            {
                                if (!DateTime.TryParseExact(fecha_str, GlobalVariables.ShortDateTime_format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                                {
                                    date = pago.Fecha_pago;
                                    Logs.AddErrorLog("Excepcion. Convirtiendo datetime. ERROR:", className, methodName, fecha_str);
                                }
                            }
                            pago.Fecha_pago = date;

                            int ddl = pago.Forma_de_pago_ID;
                            if (!int.TryParse(ddlFormas, out ddl))
                            {
                                ddl = pago.Forma_de_pago_ID;
                                Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, ddlFormas);
                            }
                            pago.Forma_de_pago_ID = ddl;

                            decimal value = pago.Monto;
                            if (!decimal.TryParse(monto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                            {
                                value = pago.Monto;
                                Logs.AddErrorLog("Excepcion. Convirtiendo decimal. ERROR:", className, methodName, monto_str);
                            }
                            pago.Monto = value;

                            pago.Comentarios = comentarios_str;

                            context.SaveChanges();

                            #region Guardar log 
                            try
                            {
                                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                                string username = HttpContext.Current.Session["UserName"].ToString();
                                Global_Objects.Logs.AddUserLog("Modifica pago", pago.GetType().Name + ": " + pago.Proveedor_pagos_ID, userID1, username);
                            }
                            catch (Exception ex)
                            {
                                Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                            }
                            #endregion

                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        [WebMethod]
        public static string ViajeFicticio_1(string proveedorID_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string ret = string.Empty;
            if (!string.IsNullOrWhiteSpace(proveedorID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int proveedor_ID = 0;
                    if (!int.TryParse(proveedorID_str, out proveedor_ID))
                    {
                        proveedor_ID = 0;
                        Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, proveedorID_str);
                    }

                    if (proveedor_ID > 0)
                    {
                        proveedor proveedor = (proveedor)context.proveedores.FirstOrDefault(v => v.Proveedor_ID == proveedor_ID);
                        if (proveedor != null)
                        {
                            string saldo = "0";
                            string comentarios = string.Empty;

                            viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Proveedor_ID == proveedor.Proveedor_ID && v.isFicticio);
                            if (viaje != null)
                            {
                                saldo = viaje.precio_venta.ToString();
                                comentarios = viaje.Comentarios;
                            }
                            ret = saldo + "|" + comentarios;
                        }
                    }
                }
            }
            return ret;
        }

        [WebMethod]
        public static bool ViajeFicticio_2(string saldo_str, string comentarios, string proveedorID_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            bool ret = false;
            if (!string.IsNullOrWhiteSpace(proveedorID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int proveedor_ID = 0;
                    if (!int.TryParse(proveedorID_str, out proveedor_ID))
                    {
                        proveedor_ID = 0;
                        Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, proveedorID_str);
                    }

                    if (proveedor_ID > 0)
                    {
                        bool isNew = false;
                        decimal saldo = 0;
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Proveedor_ID == proveedor_ID && v.isFicticio);
                        if (viaje != null)
                        {
                            saldo = viaje.precio_venta;
                        }
                        else
                        {
                            isNew = true;

                            viaje = new viaje();
                            viaje.isFicticio = true;
                            viaje.Proveedor_ID = proveedor_ID;
                        }
                        if (!string.IsNullOrWhiteSpace(saldo_str))
                        {
                            if (!decimal.TryParse(saldo_str, NumberStyles.Number, CultureInfo.InvariantCulture, out saldo))
                            {
                                saldo = 0;
                                Logs.AddErrorLog("Excepcion. Convirtiendo decimal. ERROR:", className, methodName, saldo_str);
                            }
                        }
                        viaje.precio_venta = saldo;
                        viaje.Comentarios = comentarios;

                        if (isNew)
                        {
                            viaje.Fecha_partida = DateTime.MinValue;
                            viaje.Fecha_llegada = DateTime.MinValue;
                            viaje.Fecha_registro = DateTime.Now;

                            viaje.Carga = string.Empty;
                            viaje.Descarga = string.Empty;
                            viaje.EnViaje = false;
                            viaje.Empresa_de_carga_ID = 0;
                            viaje.Fletero_ID = 0;
                            viaje.Camion_ID = 0;
                            viaje.Chofer_ID = 0;

                            #region Datos pesadas

                            viaje.Pesada_Origen_lugar = string.Empty;
                            viaje.Pesada_Origen_fecha = DateTime.Now;
                            viaje.Pesada_Origen_peso_bruto = 0;
                            viaje.Pesada_Origen_peso_neto = 0;
                            viaje.Pesada_Destino_lugar = string.Empty;
                            viaje.Pesada_Destino_fecha = DateTime.Now;
                            viaje.Pesada_Destino_peso_bruto = 0;
                            viaje.Pesada_Destino_peso_neto = 0;
                            viaje.Pesada_Comentarios = string.Empty;

                            #endregion Datos pesadas

                            #region Datos mercadería

                            viaje.Mercaderia_Lena_tipo_ID = 0;
                            viaje.Mercaderia_Procesador_ID = 0;
                            viaje.Mercaderia_Fecha_corte = DateTime.Now;
                            viaje.Mercaderia_Precio_xTonelada_compra = 0;
                            viaje.Mercaderia_Precio_xTonelada_venta = 0;
                            viaje.Mercaderia_Comentarios = string.Empty;

                            #endregion Datos mercadería

                            context.viajes.Add(viaje);
                        }
                        context.SaveChanges();

                        #region Guardar log
                        try
                        {
                            int id = 1;
                            if (viaje != null)
                            {
                                id = viaje.Viaje_ID;
                            }

                            string userID1 = HttpContext.Current.Session["UserID"].ToString();
                            string username = HttpContext.Current.Session["UserName"].ToString();
                            Logs.AddUserLog("Modifica viaje ficticio", viaje.GetType().Name + ": " + viaje.Viaje_ID, userID1, username);
                        }
                        catch (Exception ex)
                        {
                            Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                        }
                        #endregion

                        ret = true;
                    }
                }
            }
            return ret;
        }

        #endregion

    }
}

