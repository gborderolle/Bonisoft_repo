using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Resumen_clientes : System.Web.UI.Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridClientes();
                BindModalAgregarPago();
                BindModalModificarPago();

                gridClientes.UseAccessibleHeader = true;
                gridClientes.HeaderRow.TableSection = TableRowSection.TableHeader;

                //gridViajes.UseAccessibleHeader = true;
                //gridViajes.HeaderRow.TableSection = TableRowSection.TableHeader;

                //gridPagos.UseAccessibleHeader = true;
                //gridPagos.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            gridClientes_lblMessage.Text = string.Empty;
        }

        protected void gridClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                if (!string.IsNullOrWhiteSpace(e.CommandArgument.ToString()) && !string.IsNullOrWhiteSpace(e.CommandName))
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
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

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridClientes, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gridViajes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region DDL Default values

            // Fleteros ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lblFletero") as Label;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
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
            }

            // Camion ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lblCamion") as Label;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Camion_ID;
                            camion camion = (camion)context.camiones.FirstOrDefault(c => c.Camion_ID == id);
                            if (camion != null)
                            {
                                string nombre = camion.ToString();
                                lbl.Text = nombre;
                                //lbl.CommandArgument = "camiones," + camion.Marca;
                            }
                        }
                    }
                }
            }

            // Chofer ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lblChofer") as Label;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
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
            }

            // Proveedor ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lblProveedor") as Label;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
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
            }

            // Pesada origen ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lblPesadaOrigen") as Label;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Pesada_origen_ID;
                            pesada pesada = (pesada)context.pesadas.FirstOrDefault(c => c.pesada_ID == id);
                            if (pesada != null)
                            {
                                string nombre = pesada.ToString();
                                lbl.Text = nombre;
                            }
                        }
                    }
                }
            }

            // Pesada destino ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lblPesadaDestino") as Label;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Pesada_destino_ID;
                            pesada pesada = (pesada)context.pesadas.FirstOrDefault(c => c.pesada_ID == id);
                            if (pesada != null)
                            {
                                string nombre = pesada.ToString();
                                lbl.Text = nombre;
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
                Label lbl = e.Row.FindControl("lblForma") as Label;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        cliente_pagos pago = (cliente_pagos)(e.Row.DataItem);
                        if (pago != null)
                        {
                            int id = pago.Forma_de_pago_ID;
                            forma_de_pago forma = (forma_de_pago)context.forma_de_pago.FirstOrDefault(c => c.Forma_de_pago_ID == id);
                            if (forma != null)
                            {
                                string nombre = forma.Forma;
                                lbl.Text = nombre;
                                //lbl.CommandArgument = "formas," + nombre;
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
            foreach (GridViewRow row in gridClientes.Rows)
            {
                if (row.RowIndex == gridClientes.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");

                    string cliente_ID_str = gridClientes.SelectedRow.Cells[0].Text;
                    if (!string.IsNullOrWhiteSpace(cliente_ID_str))
                    {
                        int cliente_ID = 0;
                        if(!int.TryParse(cliente_ID_str, out cliente_ID))
                        {
                            cliente_ID = 0;
                        }

                        if(cliente_ID > 0)
                        {
                            BindGridViajes(cliente_ID);
                            BindGridPagos(cliente_ID);

                            hdn_clientID.Value = cliente_ID_str;
                        }
                    }
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }

        #endregion Events

        #region General methods


        private void BindGridClientes()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var elements = context.clientes.OrderBy(e => e.Nombre).ToList();
                if (elements.Count() > 0)
                {
                    gridClientes.DataSource = elements;
                    gridClientes.DataBind();

                    lblGridClientesCount.Text = "Resultados: " + elements.Count();
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
            }
        }

        private void BindGridViajes(int cliente_ID)
        {
            if (cliente_ID > 0)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    var elements = context.viajes.Where(v => v.Cliente_ID == cliente_ID).ToList();
                    if (elements.Count() > 0)
                    {
                        gridViajes.DataSource = elements;
                        gridViajes.DataBind();

                        gridViajes.UseAccessibleHeader = true;
                        gridViajes.HeaderRow.TableSection = TableRowSection.TableHeader;

                        lblGridViajesCount.Text = "Resultados: " + elements.Count();
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

        private void BindGridPagos(int cliente_ID)
        {
            if (cliente_ID > 0)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    var elements = context.cliente_pagos.Where(v => v.Cliente_ID == cliente_ID).ToList();
                    if (elements.Count() > 0)
                    {
                        gridPagos.DataSource = elements;
                        gridPagos.DataBind();

                        gridPagos.UseAccessibleHeader = true;
                        gridPagos.HeaderRow.TableSection = TableRowSection.TableHeader;

                        lblGridPagosCount.Text = "Resultados: " + elements.Count();
                    }
                    else
                    {
                        var obj = new List<cliente_pagos>();
                        obj.Add(new cliente_pagos());

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
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
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
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
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

        [System.Web.Services.WebMethod]
        public static string Update_Saldos(string clienteID_str)
        {
            string ret = string.Empty;
            if (!string.IsNullOrWhiteSpace(clienteID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int cliente_ID = 0;
                    if (!int.TryParse(clienteID_str, out cliente_ID))
                    {
                        cliente_ID = 0;
                    }

                    if (cliente_ID > 0)
                    {
                        #region Cálculo saldo inicial

                        decimal saldo_inicial = 0;
                        var viajes = context.viajes.Where(m => m.Cliente_ID == cliente_ID).ToList();
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
                        var pagos = context.cliente_pagos.Where(m => m.Cliente_ID == cliente_ID).ToList();
                        if (pagos.Count() > 0)
                        {
                            foreach (cliente_pagos pago in pagos)
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

        [System.Web.Services.WebMethod]
        public static bool IngresarPago(string clienteID_str, string fecha_str, string ddlFormas, string monto_str, string comentarios_str)
        {
            bool ret = false;
            if (!string.IsNullOrWhiteSpace(clienteID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int cliente_ID = 0;
                    if (!int.TryParse(clienteID_str, out cliente_ID))
                    {
                        cliente_ID = 0;
                    }

                    if (cliente_ID > 0)
                    {
                        cliente_pagos obj = new cliente_pagos();

                        obj.Cliente_ID = cliente_ID;
                        obj.Comentarios = comentarios_str;
                        obj.Fecha_registro = DateTime.Now;

                        DateTime date = DateTime.Now;
                        if (!DateTime.TryParseExact(fecha_str, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                        {
                            date = DateTime.Now;
                        }
                        obj.Fecha_pago = date;

                        decimal value = 0;
                        if (!decimal.TryParse(monto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                        {
                            value = 0;
                        }
                        obj.Monto = value;

                        int ddl = 0;
                        if (!int.TryParse(ddlFormas, out ddl))
                        {
                            ddl = 0;
                        }
                        obj.Forma_de_pago_ID = ddl;

                        context.cliente_pagos.Add(obj);
                        context.SaveChanges();

                        ret = true;
                    }
                }
            }

            return ret;
        }

        [System.Web.Services.WebMethod]
        public static bool BorrarPago(string pagoID_str)
        {
            bool ret = false;
            if (!string.IsNullOrWhiteSpace(pagoID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int pago_ID_str = 0;
                    if (!int.TryParse(pagoID_str, out pago_ID_str))
                    {
                        pago_ID_str = 0;
                    }

                    if (pago_ID_str > 0)
                    {
                        cliente_pagos pago = (cliente_pagos)context.cliente_pagos.FirstOrDefault(v => v.Cliente_pagos_ID == pago_ID_str);
                        if (pago != null)
                        {
                            context.cliente_pagos.Remove(pago);
                            context.SaveChanges();

                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        [System.Web.Services.WebMethod]
        public static string ModificarPago_1(string pagoID_str)
        {
            string ret = string.Empty;
            if (!string.IsNullOrWhiteSpace(pagoID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int pago_ID_str = 0;
                    if (!int.TryParse(pagoID_str, out pago_ID_str))
                    {
                        pago_ID_str = 0;
                    }

                    if (pago_ID_str > 0)
                    {
                        cliente_pagos pago = (cliente_pagos)context.cliente_pagos.FirstOrDefault(v => v.Cliente_pagos_ID == pago_ID_str);
                        if (pago != null)
                        {
                            ret = pago.Fecha_pago.ToShortDateString() + "|" + pago.Forma_de_pago_ID + "|" + pago.Monto + "|" + pago.Comentarios;
                        }
                    }
                }
            }
            return ret;
        }

        [System.Web.Services.WebMethod]
        public static bool ModificarPago_2(string pagoID_str, string fecha_str, string ddlFormas, string monto_str, string comentarios_str)
        {
            bool ret = false;
            if (!string.IsNullOrWhiteSpace(pagoID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int pago_ID = 0;
                    if (!int.TryParse(pagoID_str, out pago_ID))
                    {
                        pago_ID = 0;
                    }

                    if (pago_ID > 0)
                    {
                        cliente_pagos pago = (cliente_pagos)context.cliente_pagos.FirstOrDefault(v => v.Cliente_pagos_ID == pago_ID);
                        if (pago != null)
                        {
                            DateTime date = pago.Fecha_pago;
                            if (!DateTime.TryParseExact(fecha_str, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                            {
                                date = pago.Fecha_pago;
                            }
                            pago.Fecha_pago = date;

                            int ddl = pago.Forma_de_pago_ID;
                            if (!int.TryParse(ddlFormas, out ddl))
                            {
                                ddl = pago.Forma_de_pago_ID;
                            }
                            pago.Forma_de_pago_ID = ddl;

                            decimal value = pago.Monto;
                            if (!decimal.TryParse(monto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                            {
                                value = pago.Monto;
                            }
                            pago.Monto = value;

                            pago.Comentarios = comentarios_str;

                            context.SaveChanges();

                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        #endregion

    }
}