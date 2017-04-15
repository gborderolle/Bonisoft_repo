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
using System.IO;
using System.Text;

namespace Bonisoft.Pages
{
    public partial class Resumen_fleteros : System.Web.UI.Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridClientes();
                BindModalAgregarPago();
                BindModalModificarPago();
            }

            gridClientes.UseAccessibleHeader = true;
            gridClientes.HeaderRow.TableSection = TableRowSection.TableHeader;

            gridClientes_lblMessage.Text = string.Empty;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string client_ID_str = hdn_clientID.Value;
            if (!string.IsNullOrWhiteSpace(client_ID_str))
            {
                int cliente_ID = 0;
                if (!int.TryParse(client_ID_str, out cliente_ID))
                {
                    cliente_ID = 0;
                    Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, client_ID_str);
                }

                if (cliente_ID > 0)
                {
                    string date1 = txbFiltro1.Value;
                    string date2 = txbFiltro2.Value;
                    BindGridViajesImprimir(cliente_ID, date1, date2);
                }
            }
        }

        protected void btnSearch_Click_saldos(object sender, EventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string client_ID_str = hdn_clientID.Value;
            if (!string.IsNullOrWhiteSpace(client_ID_str))
            {
                int cliente_ID = 0;
                if (!int.TryParse(client_ID_str, out cliente_ID))
                {
                    cliente_ID = 0;
                    Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, client_ID_str);
                }

                if (cliente_ID > 0)
                {
                    string date1 = txbFiltro_saldos1.Value;
                    string date2 = txbFiltro_saldos2.Value;
                    BindGridPagos(cliente_ID, date1, date2);
                }
            }
        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            gridPagos.PageIndex = e.NewPageIndex;

            string client_ID_str = hdn_clientID.Value;
            if (!string.IsNullOrWhiteSpace(client_ID_str))
            {
                int cliente_ID = 0;
                if (!int.TryParse(client_ID_str, out cliente_ID))
                {
                    cliente_ID = 0;
                    Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, client_ID_str);
                }

                if (cliente_ID > 0)
                {
                    BindGridPagos(cliente_ID);
                }
            }
        }

        protected void grid2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridClientes.PageIndex = e.NewPageIndex;
            BindGridClientes();
        }

        protected void grid3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            gridViajes.PageIndex = e.NewPageIndex;

            string client_ID_str = hdn_clientID.Value;
            if (!string.IsNullOrWhiteSpace(client_ID_str))
            {
                int cliente_ID = 0;
                if (!int.TryParse(client_ID_str, out cliente_ID))
                {
                    cliente_ID = 0;
                    Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, client_ID_str);
                }

                if (cliente_ID > 0)
                {
                    BindGridViajes(cliente_ID);
                }
            }
        }

        protected void gridViajesImprimir_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            gridViajesImprimir.PageIndex = e.NewPageIndex;

            string client_ID_str = hdn_clientID.Value;
            if (!string.IsNullOrWhiteSpace(client_ID_str))
            {
                int cliente_ID = 0;
                if (!int.TryParse(client_ID_str, out cliente_ID))
                {
                    cliente_ID = 0;
                    Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, client_ID_str);
                }

                if (cliente_ID > 0)
                {
                    BindGridViajesImprimir(cliente_ID);
                }
            }
        }

        protected void gridClientes_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gridClientes_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridClientes, "Select$" + e.Row.RowIndex);
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
                                string nombre = camion.Matricula_zorra;
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

                // Proveedor ----------------------------------------------------
                lbl = e.Row.FindControl("lblProveedor") as Label;
                if (lbl != null)
                {
                    lbl.Text = string.Empty; using (bonisoftEntities context = new bonisoftEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Proveedor_ID;
                            proveedor proveedor = (proveedor)context.proveedores.FirstOrDefault(c => c.Proveedor_ID == id);
                            if (proveedor != null)
                            {
                                string nombre = proveedor.Nombre;
                                lbl.Text = nombre;
                                //lbl.CommandArgument = "proveedores," + proveedor.Nombre;
                            }
                        }
                    }
                }

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

        protected void gridViajesImprimir_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region DDL Default values

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Mercadería ----------------------------------------------------
                Label lbl = e.Row.FindControl("lblMercaderia") as Label;
                if (lbl != null)
                {
                    lbl.Text = string.Empty;
                    using (bonisoftEntities context = new bonisoftEntities())
                    {
                        fletero_pagos cliente_pagos = (fletero_pagos)(e.Row.DataItem);
                        if (cliente_pagos != null)
                        {
                            int id_v = cliente_pagos.Viaje_ID;
                            viaje viaje = (viaje)context.viajes.FirstOrDefault(c => c.Viaje_ID == id_v);
                            if (viaje != null)
                            {
                                int id_l = viaje.Mercaderia_Lena_tipo_ID;
                                lena_tipo lena_tipo = (lena_tipo)context.lena_tipo.FirstOrDefault(c => c.Lena_tipo_ID == id_l);
                                if (lena_tipo != null)
                                {
                                    string nombre = lena_tipo.Tipo;
                                    lbl.Text = nombre;
                                }
                            }
                            else
                            {
                                lbl.Text = cliente_pagos.Comentarios;
                            }
                        }
                    }
                }

                // Kilos ----------------------------------------------------
                lbl = e.Row.FindControl("lblKilos") as Label;
                if (lbl != null)
                {
                    lbl.Text = string.Empty;
                    using (bonisoftEntities context = new bonisoftEntities())
                    {
                        fletero_pagos cliente_pagos = (fletero_pagos)(e.Row.DataItem);
                        if (cliente_pagos != null)
                        {
                            int id_v = cliente_pagos.Viaje_ID;
                            viaje viaje = (viaje)context.viajes.FirstOrDefault(c => c.Viaje_ID == id_v);
                            if (viaje != null)
                            {
                                decimal peso_neto = viaje.Pesada_Destino_peso_neto;
                                lbl.Text = peso_neto.ToString();
                            }
                        }
                    }
                }

                // Valor ----------------------------------------------------
                lbl = e.Row.FindControl("lblValor") as Label;
                if (lbl != null)
                {
                    lbl.Text = string.Empty;
                    using (bonisoftEntities context = new bonisoftEntities())
                    {
                        fletero_pagos cliente_pagos = (fletero_pagos)(e.Row.DataItem);
                        if (cliente_pagos != null)
                        {
                            int id_v = cliente_pagos.Viaje_ID;
                            viaje viaje = (viaje)context.viajes.FirstOrDefault(c => c.Viaje_ID == id_v);
                            if (viaje != null)
                            {
                                decimal peso_neto = viaje.Mercaderia_Valor_Proveedor_PorTon;
                                lbl.Text = peso_neto.ToString();
                            }
                        }
                    }
                }
                // Importe ----------------------------------------------------
                lbl = e.Row.FindControl("lblImporte") as Label;
                if (lbl != null)
                {
                    lbl.Text = string.Empty;
                    using (bonisoftEntities context = new bonisoftEntities())
                    {
                        fletero_pagos cliente_pagos = (fletero_pagos)(e.Row.DataItem);
                        if (cliente_pagos != null)
                        {
                            int id_v = cliente_pagos.Viaje_ID;
                            viaje viaje = (viaje)context.viajes.FirstOrDefault(c => c.Viaje_ID == id_v);
                            if (viaje != null)
                            {
                                decimal precio_compra = viaje.precio_compra;
                                lbl.Text = precio_compra.ToString();
                            }
                        }
                    }
                }

                // Saldo ----------------------------------------------------
                lbl = e.Row.FindControl("lblSaldo") as Label;
                if (lbl != null)
                {
                    lbl.Text = string.Empty;
                    using (bonisoftEntities context = new bonisoftEntities())
                    {
                        fletero_pagos cliente_pagos = (fletero_pagos)(e.Row.DataItem);
                        if (cliente_pagos != null)
                        {
                            DateTime fecha_desde = cliente_pagos.Fecha_pago;
                            int id_hasta = cliente_pagos.Fletero_pagos_ID;

                            int cliente_ID = cliente_pagos.Fletero_ID;
                            var elements_pagos = context.fletero_pagos.Where(v => v.Fletero_ID == cliente_ID && v.Fecha_pago >= fecha_desde && v.Fletero_pagos_ID <= id_hasta).ToList();
                            decimal total_pagos = 0;
                            foreach (fletero_pagos pago in elements_pagos)
                            {
                                total_pagos += pago.Monto;
                            }

                            // && v.Fecha_partida >= fecha_desde && v.Cliente_pagos_ID <= id_hasta
                            var elements_viajes = context.viajes.Where(v => v.Fletero_ID == cliente_ID).ToList();
                            decimal total_importes = 0;
                            foreach (viaje viaje1 in elements_viajes)
                            {
                                total_importes += viaje1.precio_compra;
                            }

                            lbl.Text = (total_importes - total_pagos).ToString();
                        }
                    }
                }

            }
            #endregion
        }

        protected void gridViajesImprimir_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        fletero_pagos pago = (fletero_pagos)(e.Row.DataItem);
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
                        fletero_pagos pago = (fletero_pagos)(e.Row.DataItem);
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

        protected void gridClientes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Source: http://www.codeproject.com/Tips/622720/Fire-GridView-SelectedIndexChanged-Event-without-S

            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            foreach (GridViewRow row in gridClientes.Rows)
            {
                if (row.RowIndex == gridClientes.SelectedIndex)
                {
                    string cliente_ID_str = gridClientes.SelectedRow.Cells[0].Text;
                    if (!string.IsNullOrWhiteSpace(cliente_ID_str))
                    {
                        int cliente_ID = 0;
                        if (!int.TryParse(cliente_ID_str, out cliente_ID))
                        {
                            cliente_ID = 0;
                            Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, cliente_ID_str);
                        }

                        if (cliente_ID > 0)
                        {
                            using (bonisoftEntities context = new bonisoftEntities())
                            {
                                fletero cliente = (fletero)context.fleteros.FirstOrDefault(c => c.Fletero_ID == cliente_ID);
                                if (cliente != null)
                                {
                                    lblClientName_1.Text = lblClientName_2.Text = cliente.Nombre;

                                    BindGridViajes(cliente_ID);
                                    BindGridViajesImprimir(cliente_ID);
                                    //BindGridPagos(cliente_ID);

                                    // Filtrar por fechas del mes corriente por defecto

                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "gridClientes_OnSelectedIndexChanged", "<script type='text/javascript'>loadFilter_CurrentMonth(); </script>", false);

                                    var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                                    string date1 = startDate.ToString(GlobalVariables.ShortDateTime_format);
                                    string date2 = startDate.AddMonths(1).AddDays(-1).ToString(GlobalVariables.ShortDateTime_format);
                                    BindGridPagos(cliente_ID, date1, date2);

                                    hdn_clientID.Value = cliente_ID_str;

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

        private void BindGridClientes()
        {
            using (bonisoftEntities context = new bonisoftEntities())
            {
                var elements = context.fleteros.OrderBy(e => e.Nombre).ToList();
                if (elements.Count() > 0)
                {
                    gridClientes.DataSource = elements;
                    gridClientes.DataBind();

                    gridClientes.UseAccessibleHeader = true;
                    gridClientes.HeaderRow.TableSection = TableRowSection.TableHeader;

                    lblGridClientesCount.Text = "# " + elements.Count();
                }
                else
                {
                    var obj = new List<fletero>();
                    obj.Add(new fletero());

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
            }
        }

        private void BindGridViajes(int cliente_ID)
        {
            if (cliente_ID > 0)
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    var elements = context.viajes.Where(v => v.Fletero_ID == cliente_ID && !v.isFicticio).ToList();
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

        private void BindGridViajesImprimir(int cliente_ID, string date_start = "", string date_end = "")
        {
            if (cliente_ID > 0)
            {
                // Logger variables
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
                string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                string methodName = stackFrame.GetMethod().Name;

                using (bonisoftEntities context = new bonisoftEntities())
                {
                    var elements = context.fletero_pagos.Where(v => v.Fletero_ID == cliente_ID).ToList();

                    // Filtro por fechas
                    if (!string.IsNullOrWhiteSpace(date_start) && !string.IsNullOrWhiteSpace(date_end))
                    {
                        DateTime date1 = DateTime.MinValue;
                        if (!DateTime.TryParseExact(date_start, GlobalVariables.ShortDateTime_format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
                        {
                            date1 = DateTime.MinValue;
                            Logs.AddErrorLog("Excepcion. Convirtiendo datetime. ERROR:", className, methodName, date_start);
                        }

                        DateTime date2 = DateTime.MinValue;
                        if (!DateTime.TryParseExact(date_end, GlobalVariables.ShortDateTime_format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
                        {
                            date2 = DateTime.MinValue;
                            Logs.AddErrorLog("Excepcion. Convirtiendo datetime. ERROR:", className, methodName, date_end);
                        }

                        elements = context.fletero_pagos.Where(v => v.Fletero_ID == cliente_ID && (v.Fecha_pago >= date1 && v.Fecha_pago <= date2)).OrderBy(e => e.Fecha_pago).ToList();
                    }

                    if (elements.Count() > 0)
                    {
                        gridViajesImprimir.DataSource = elements;
                        gridViajesImprimir.DataBind();

                        gridViajesImprimir.UseAccessibleHeader = true;
                        gridViajesImprimir.HeaderRow.TableSection = TableRowSection.TableHeader;

                        lblGridViajesImprimirCount.Text = "# " + elements.Count();
                    }
                    else
                    {
                        var obj = new List<fletero_pagos>();
                        obj.Add(new fletero_pagos());

                        /* Grid Viajes */

                        // Bind the DataTable which contain a blank row to the GridView
                        gridViajesImprimir.DataSource = obj;
                        gridViajesImprimir.DataBind();
                        int columnsCount = gridViajesImprimir.Columns.Count;
                        gridViajesImprimir.Rows[0].Cells.Clear();// clear all the cells in the row
                        gridViajesImprimir.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        gridViajesImprimir.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                        //You can set the styles here
                        gridViajesImprimir.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        gridViajesImprimir.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        gridViajesImprimir.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        gridViajesImprimir.Rows[0].Cells[0].Text = "No hay registros";
                    }
                }
            }
        }

        private void BindGridPagos(int cliente_ID, string date_start = "", string date_end = "")
        {
            if (cliente_ID > 0)
            {
                // Logger variables
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
                string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                string methodName = stackFrame.GetMethod().Name;

                using (bonisoftEntities context = new bonisoftEntities())
                {
                    var elements = context.fletero_pagos.Where(v => v.Fletero_ID == cliente_ID).OrderBy(e => e.Fecha_pago).ToList();

                    // Filtro por fechas
                    if (!string.IsNullOrWhiteSpace(date_start) && !string.IsNullOrWhiteSpace(date_end))
                    {
                        DateTime date1 = DateTime.MinValue;
                        if (!DateTime.TryParseExact(date_start, GlobalVariables.ShortDateTime_format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
                        {
                            date1 = DateTime.MinValue;
                            Logs.AddErrorLog("Excepcion. Convirtiendo datetime. ERROR:", className, methodName, date_start);
                        }

                        DateTime date2 = DateTime.MinValue;
                        if (!DateTime.TryParseExact(date_end, GlobalVariables.ShortDateTime_format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
                        {
                            date2 = DateTime.MinValue;
                            Logs.AddErrorLog("Excepcion. Convirtiendo datetime. ERROR:", className, methodName, date_end);
                        }

                        elements = context.fletero_pagos.Where(v => v.Fletero_ID == cliente_ID && (v.Fecha_pago >= date1 && v.Fecha_pago <= date2)).OrderBy(e => e.Fecha_pago).ToList();
                    }


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
                        var obj = new List<fletero_pagos>();
                        obj.Add(new fletero_pagos());

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

        protected void PrintCurrentPage(object sender, EventArgs e)
        {
            gridViajesImprimir.PagerSettings.Visible = false;
            gridViajesImprimir.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gridViajesImprimir.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            sb.Append(gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            gridViajesImprimir.PagerSettings.Visible = true;
            gridViajesImprimir.DataBind();
        }

        protected void PrintAllPages(object sender, EventArgs e)
        {
            gridViajesImprimir.AllowPaging = false;
            gridViajesImprimir.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gridViajesImprimir.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            sb.Append(gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            gridViajesImprimir.AllowPaging = true;
            gridViajesImprimir.DataBind();
        }



        #endregion General methods

        #region Static methods

        private static string AgregarFormaPago(string valor)
        {
            string ID_result = "0";

            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            using (bonisoftEntities context = new bonisoftEntities())
            {
                forma_de_pago obj = new forma_de_pago();
                obj.Forma = valor;
                obj.Comentarios = string.Empty;

                context.forma_de_pago.Add(obj);
                context.SaveChanges();

                #region Guardar log 
                try
                {
                    int id = 1;
                    forma_de_pago forma_de_pago = (forma_de_pago)context.forma_de_pago.OrderByDescending(p => p.Forma_de_pago_ID).FirstOrDefault();
                    if (forma_de_pago != null)
                    {
                        id = forma_de_pago.Forma_de_pago_ID;
                    }

                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Logs.AddUserLog("Agrega forma de pago", forma_de_pago.GetType().Name + ": " + id, userID1, username);

                    ID_result = id.ToString();
                }
                catch (Exception ex)
                {
                    Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                }
                #endregion
            }

            return ID_result;
        }

        #endregion 

        #region Web methods

        [WebMethod]
        public static string Update_Saldos(string clienteID_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string ret = string.Empty;
            if (!string.IsNullOrWhiteSpace(clienteID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int cliente_ID = 0;
                    if (!int.TryParse(clienteID_str, out cliente_ID))
                    {
                        cliente_ID = 0;
                        Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, clienteID_str);
                    }

                    if (cliente_ID > 0)
                    {
                        #region Cálculo saldo inicial

                        decimal saldo_inicial = 0;
                        var viajes = context.viajes.Where(m => m.Fletero_ID == cliente_ID).ToList();
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
                        var pagos = context.fletero_pagos.Where(m => m.Fletero_ID == cliente_ID).ToList();
                        if (pagos.Count() > 0)
                        {
                            foreach (fletero_pagos pago in pagos)
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
        public static bool IngresarPago(string clienteID_str, string fecha_str, string ddlFormas, string monto_str, string comentarios_str, bool esPago)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            bool ret = false;
            if (!string.IsNullOrWhiteSpace(clienteID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int cliente_ID = 0;
                    if (!int.TryParse(clienteID_str, out cliente_ID))
                    {
                        cliente_ID = 0;
                        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, clienteID_str);
                    }

                    if (cliente_ID > 0)
                    {
                        fletero_pagos obj = new fletero_pagos();

                        obj.Fletero_ID = cliente_ID;
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

                        if (esPago)
                        {
                            obj.Monto = value;
                        }
                        else
                        {
                            obj.Importe_viaje = value;
                        }

                        int ddl = 0;
                        if (esPago)
                        {
                            if (!int.TryParse(ddlFormas, out ddl))
                            {
                                ddl = 0;
                                Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, ddlFormas);
                            }
                        }
                        obj.Forma_de_pago_ID = ddl;

                        context.fletero_pagos.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
                        try
                        {
                            int id = 1;
                            fletero_pagos cliente_pago1 = (fletero_pagos)context.fletero_pagos.OrderByDescending(p => p.Fletero_pagos_ID).FirstOrDefault();
                            if (cliente_pago1 != null)
                            {
                                id = cliente_pago1.Fletero_pagos_ID;
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
                        fletero_pagos pago = (fletero_pagos)context.fletero_pagos.FirstOrDefault(v => v.Fletero_pagos_ID == pago_ID_str);
                        if (pago != null)
                        {
                            context.fletero_pagos.Remove(pago);
                            context.SaveChanges();

                            #region Guardar log 
                            try
                            {
                                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                                string username = HttpContext.Current.Session["UserName"].ToString();
                                Global_Objects.Logs.AddUserLog("Borra pago", pago.GetType().Name + ": " + pago.Fletero_pagos_ID, userID1, username);
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
        public static bool IngresarImporte(string clienteID_str, string fecha_str, string monto_str, string comentarios_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            bool ret = false;
            if (!string.IsNullOrWhiteSpace(clienteID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int cliente_ID = 0;
                    if (!int.TryParse(clienteID_str, out cliente_ID))
                    {
                        cliente_ID = 0;
                        Global_Objects.Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, clienteID_str);
                    }

                    if (cliente_ID > 0)
                    {
                        fletero_pagos obj = new fletero_pagos();

                        obj.Fletero_pagos_ID = cliente_ID;
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

                        obj.Forma_de_pago_ID = 0;

                        context.fletero_pagos.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
                        try
                        {
                            int id = 1;
                            fletero_pagos cliente_pago1 = (fletero_pagos)context.fletero_pagos.OrderByDescending(p => p.Fletero_pagos_ID).FirstOrDefault();
                            if (cliente_pago1 != null)
                            {
                                id = cliente_pago1.Fletero_pagos_ID;
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
        public static bool BorrarImporte(string pagoID_str)
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
                        fletero_pagos pago = (fletero_pagos)context.fletero_pagos.FirstOrDefault(v => v.Fletero_pagos_ID == pago_ID_str);
                        if (pago != null)
                        {
                            context.fletero_pagos.Remove(pago);
                            context.SaveChanges();

                            #region Guardar log 
                            try
                            {
                                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                                string username = HttpContext.Current.Session["UserName"].ToString();
                                Global_Objects.Logs.AddUserLog("Borra pago", pago.GetType().Name + ": " + pago.Fletero_pagos_ID, userID1, username);
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
                        fletero_pagos pago = (fletero_pagos)context.fletero_pagos.FirstOrDefault(v => v.Fletero_pagos_ID == pago_ID);
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
        public static bool ModificarPago_2(string pagoID_str, string fecha_str, string ddlFormas, string monto_str, string comentarios_str, bool esPago)
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
                        fletero_pagos pago = (fletero_pagos)context.fletero_pagos.FirstOrDefault(v => v.Fletero_pagos_ID == pago_ID);
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

                            int ddl = 0;
                            if (esPago)
                            {
                                ddl = pago.Forma_de_pago_ID;
                                if (!int.TryParse(ddlFormas, out ddl))
                                {
                                    ddl = pago.Forma_de_pago_ID;
                                    Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, ddlFormas);
                                }
                            }
                            pago.Forma_de_pago_ID = ddl;

                            decimal value = pago.Monto;
                            if (!decimal.TryParse(monto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                            {
                                value = pago.Monto;
                                Logs.AddErrorLog("Excepcion. Convirtiendo decimal. ERROR:", className, methodName, monto_str);
                            }

                            if (esPago)
                            {
                                pago.Monto = value;
                            }
                            else
                            {
                                pago.Importe_viaje = value;
                            }

                            pago.Comentarios = comentarios_str;

                            context.SaveChanges();

                            #region Guardar log 
                            try
                            {
                                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                                string username = HttpContext.Current.Session["UserName"].ToString();
                                Global_Objects.Logs.AddUserLog("Modifica pago", pago.GetType().Name + ": " + pago.Fletero_pagos_ID, userID1, username);
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
        public static bool ModificarImporte_2(string pagoID_str, string fecha_str, string monto_str, string comentarios_str)
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
                        fletero_pagos pago = (fletero_pagos)context.fletero_pagos.FirstOrDefault(v => v.Fletero_pagos_ID == pago_ID);
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
                                Global_Objects.Logs.AddUserLog("Modifica pago", pago.GetType().Name + ": " + pago.Fletero_pagos_ID, userID1, username);
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
        public static string ViajeFicticio_1(string clienteID_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            string ret = string.Empty;
            if (!string.IsNullOrWhiteSpace(clienteID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int clienteID = 0;
                    if (!int.TryParse(clienteID_str, out clienteID))
                    {
                        clienteID = 0;
                        Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, clienteID_str);
                    }

                    if (clienteID > 0)
                    {
                        fletero cliente = (fletero)context.fleteros.FirstOrDefault(v => v.Fletero_ID == clienteID);
                        if (cliente != null)
                        {
                            string saldo = "0";
                            string comentarios = string.Empty;

                            viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Fletero_ID == cliente.Fletero_ID && v.isFicticio);
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
        public static bool ViajeFicticio_2(string saldo_str, string comentarios, string clienteID_str)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            bool ret = false;
            if (!string.IsNullOrWhiteSpace(clienteID_str))
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int clienteID = 0;
                    if (!int.TryParse(clienteID_str, out clienteID))
                    {
                        clienteID = 0;
                        Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, clienteID_str);
                    }

                    if (clienteID > 0)
                    {
                        bool isNew = false;
                        decimal saldo = 0;
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Fletero_ID == clienteID && v.isFicticio);
                        if (viaje != null)
                        {
                            saldo = viaje.precio_venta;
                        }
                        else
                        {
                            isNew = true;

                            viaje = new viaje();
                            viaje.isFicticio = true;
                            viaje.Fletero_ID = clienteID;
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
                            viaje.Proveedor_ID = 0;
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
                            viaje.Mercaderia_Valor_Proveedor_PorTon = 0;
                            viaje.Mercaderia_Valor_Cliente_PorTon = 0;
                            viaje.Mercaderia_Proveedor_Comentarios = string.Empty;
                            viaje.Mercaderia_Cliente_Comentarios = string.Empty;

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

        [WebMethod]
        public static string AgregarOpcionDDL(string tipo, string valor)
        {
            string ID_result = "0";
            if (!string.IsNullOrWhiteSpace(tipo) && !string.IsNullOrWhiteSpace(valor))
            {
                switch (tipo)
                {
                    case "forma_pago":
                        {
                            ID_result = AgregarFormaPago(valor);
                            break;
                        }
                }
            }
            return ID_result;
        }

        #endregion

    }
}

