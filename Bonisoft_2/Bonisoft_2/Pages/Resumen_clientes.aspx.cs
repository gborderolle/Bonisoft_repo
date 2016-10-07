using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

                gridClientes.UseAccessibleHeader = true;
                gridClientes.HeaderRow.TableSection = TableRowSection.TableHeader;

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

            // Empresa de carga ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lblCargador") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Empresa_de_carga_ID;
                            cargador cargador = (cargador)context.cargadores.FirstOrDefault(c => c.Cargador_ID == id);
                            if (cargador != null)
                            {
                                string nombre = cargador.ToString();
                                lbl.Text = nombre;
                                lbl.CommandArgument = "cargadores," + cargador.Nombre;
                            }
                        }
                    }
                }
            }

            // Fleteros ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lblFletero") as LinkButton;
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
                                lbl.CommandArgument = "fleteros," + fletero.Nombre;
                            }
                        }
                    }
                }
            }

            // Camion ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lblCamion") as LinkButton;
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
                                lbl.CommandArgument = "camiones," + camion.Marca;
                            }
                        }
                    }
                }
            }

            // Chofer ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lblChofer") as LinkButton;
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
                                lbl.CommandArgument = "choferes," + chofer.Nombre_completo;
                            }
                        }
                    }
                }
            }

            // Proveedor ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lblProveedor") as LinkButton;
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
                                lbl.CommandArgument = "proveedores," + proveedor.Nombre;
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
                                //lbl.CommandArgument = "pesadas," + pesada.Nombre_balanza;
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
                                //lbl.CommandArgument = "pesadas," + pesada.Nombre_balanza;
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

        }

        protected void gridPagos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {

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
            if (ddlFormas != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.forma_de_pago.ToList());

                    ddlFormas.DataSource = dt1;
                    ddlFormas.DataTextField = "Forma";
                    ddlFormas.DataValueField = "Forma_de_pago_ID";
                    ddlFormas.DataBind();
                    ddlFormas.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }
        }



        #endregion General methods

       
    }
}