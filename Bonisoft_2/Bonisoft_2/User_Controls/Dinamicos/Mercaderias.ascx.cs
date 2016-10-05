﻿using Bonisoft_2.Helpers;
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
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                bool ok = false;
                hdnMercaderiasCount.Value = context.mercaderia_comprada.Count().ToString();

                int viaje_ID = 0;
                if (!int.TryParse(Viaje_ID1, out viaje_ID))
                {
                    viaje_ID = 0;
                }
                if (viaje_ID > 0)
                {
                    var elements = context.mercaderia_comprada.Where(e => e.Viaje_ID == viaje_ID).ToList();
                    if (elements.Count() > 0)
                    {
                        gridMercaderias.DataSource = elements;
                        gridMercaderias.DataBind();

                        ok = true;
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

                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModalDialog", "<script type='text/javascript'>$('.datepicker').datepicker();  </script>", false);
            }
        }

        protected void gridMercaderias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Action buttons

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
                if (e.Row.RowType == DataControlRowType.Footer)
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

            #region Fill DDLs

            // Variedad ----------------------------------------------------

            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("mercaderias_ddlVariedad1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("mercaderias_ddlVariedad2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.variedad.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre";
                    ddl.DataValueField = "Variedad_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((mercaderia_comprada)(e.Row.DataItem)).Variedad_ID.ToString();
                }
            }

            // Procesador ----------------------------------------------------

            //ddl = null;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    ddl = e.Row.FindControl("mercaderias_ddlProcesador1") as DropDownList;
            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    ddl = e.Row.FindControl("mercaderias_ddlProcesador2") as DropDownList;
            //}
            //if (ddl != null)
            //{
            //    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            //    {
            //        DataTable dt1 = new DataTable();
            //        dt1 = Extras.ToDataTable(context.procesadores.ToList());

            //        ddl.DataSource = dt1;
            //        ddl.DataTextField = "Nombre";
            //        ddl.DataValueField = "Procesador_ID";
            //        ddl.DataBind();
            //        ddl.Items.Insert(0, new ListItem("Elegir", "0"));

            //    }//Add Default Item in the DropDownList
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        ddl.SelectedValue = ((mercaderia_comprada)(e.Row.DataItem)).Procesador_ID.ToString();
            //    }
            //}

            #endregion

            #region DDL Default values

            // Variedad ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("mercaderias_lbl1") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        mercaderia_comprada mercaderia_comprada = (mercaderia_comprada)(e.Row.DataItem);
                        if (mercaderia_comprada != null)
                        {
                            int id = mercaderia_comprada.Variedad_ID;
                            variedad variedad = (variedad)context.variedad.FirstOrDefault(c => c.Variedad_ID == id);
                            if (variedad != null)
                            {
                                string nombre = variedad.Nombre;
                                lbl.Text = nombre;
                                lbl.CommandArgument = "variedades," + nombre;
                            }
                        }
                    }
                }

                // Procesador ----------------------------------------------------
                //    LinkButton lbl = e.Row.FindControl("mercaderias_lbl2") as LinkButton;
                //    if (lbl != null)
                //    {
                //        using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                //        {
                //            mercaderia_comprada mercaderia_comprada = (mercaderia_comprada)(e.Row.DataItem);
                //            if (mercaderia_comprada != null)
                //            {
                //                int id = mercaderia_comprada.Procesador_ID;
                //                procesador procesador = (procesador)context.procesadores.FirstOrDefault(c => c.Procesador_ID == id);
                //                if (procesador != null)
                //                {
                //                    string nombre = procesador.Nombre;
                //                    lbl.Text = nombre;
                //                    lbl.CommandArgument = "procesadores," + nombre;
                //                }
                //            }
                //        }
                //    }

            }
            #endregion

        }

        protected void gridMercaderias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                HiddenField hdn_modalMercaderia_txbNew4 = this.Parent.FindControl("hdn_modalMercaderia_txbNew4") as HiddenField;
                HiddenField hdn_modalMercaderia_txbNew5 = this.Parent.FindControl("hdn_modalMercaderia_txbNew5") as HiddenField;
                HiddenField hdn_modalMercaderia_txbNew7 = this.Parent.FindControl("hdn_modalMercaderia_txbNew7") as HiddenField;
                HiddenField hdn_modalMercaderia_ddlVariedad2 = this.Parent.FindControl("hdn_modalMercaderia_ddlVariedad2") as HiddenField;

                if (hdn_modalMercaderia_txbNew4 != null && hdn_modalMercaderia_txbNew5 != null &&
                    hdn_modalMercaderia_txbNew7 != null && hdn_modalMercaderia_ddlVariedad2 != null)
                {
                    string txb4 = hdn_modalMercaderia_txbNew4.Value;
                    string txb5 = hdn_modalMercaderia_txbNew5.Value;
                    string txb7 = hdn_modalMercaderia_txbNew7.Value;
                    string ddlVariedad2 = hdn_modalMercaderia_ddlVariedad2.Value;

                    int viaje_ID = 0;
                    if (!int.TryParse(Viaje_ID1, out viaje_ID))
                    {
                        viaje_ID = 0;
                    }
                    if (viaje_ID > 0)
                    {
                        using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                        {
                            mercaderia_comprada obj = new mercaderia_comprada();
                            obj.Comentarios = txb7;

                            decimal valor = 0;
                            if (!decimal.TryParse(txb5, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
                            {
                                valor = 0;
                            }
                            obj.Precio_xTonelada_compra = valor;

                            #region DDL logic

                            int ddl1 = 0;
                            if (!int.TryParse(ddlVariedad2, out ddl1))
                            {
                                ddl1 = 0;
                            }
                            obj.Variedad_ID = ddl1;

                            //int ddl2 = 0;
                            //if (!int.TryParse(ddlProcesador2, out ddl2))
                            //{
                            //    ddl2 = 0;
                            //}
                            //obj.Procesador_ID = ddl2;

                            #endregion DDL logic

                            #region Datetime logic

                            DateTime date1 = DateTime.Now;
                            if (!DateTime.TryParseExact(txb4, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                            {
                                date1 = DateTime.Now;
                            }
                            obj.Fecha_corte = date1;

                            #endregion

                            obj.Viaje_ID = viaje_ID;

                            context.mercaderia_comprada.Add(obj);
                            context.SaveChanges();
                            lblMessage.Text = "Agregado correctamente.";
                            BindGrid();

                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModalDialog", "<script type='text/javascript'>show_message_accept('OK_Datos'); $.modal.close();</script>", false);
                        }
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
            HiddenField hdn_modalMercaderia_txb4 = this.Parent.FindControl("hdn_modalMercaderia_txb4") as HiddenField;
            HiddenField hdn_modalMercaderia_txb5 = this.Parent.FindControl("hdn_modalMercaderia_txb5") as HiddenField;
            HiddenField hdn_modalMercaderia_txb7 = this.Parent.FindControl("hdn_modalMercaderia_txb7") as HiddenField;
            HiddenField hdn_modalMercaderia_ddlVariedad1 = this.Parent.FindControl("hdn_modalMercaderia_ddlVariedad1") as HiddenField;
            //HiddenField hdn_modalMercaderia_ddlProcesador1 = this.Parent.FindControl("hdn_modalMercaderia_ddlProcesador1") as HiddenField;

            if (hdn_modalMercaderia_txb4 != null && hdn_modalMercaderia_txb5 != null &&
                hdn_modalMercaderia_txb7 != null && hdn_modalMercaderia_ddlVariedad1 != null)
            {
                string txb4 = hdn_modalMercaderia_txb4.Value;
                string txb5 = hdn_modalMercaderia_txb5.Value;
                string txb7 = hdn_modalMercaderia_txb7.Value;
                string ddlVariedad1 = hdn_modalMercaderia_ddlVariedad1.Value;
                //string ddlProcesador1 = hdn_modalMercaderia_ddlProcesador1.Value;

                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int mercaderia_ID = Convert.ToInt32(gridMercaderias.DataKeys[e.RowIndex].Value);
                    mercaderia_comprada obj = context.mercaderia_comprada.First(x => x.Mercaderia_ID == mercaderia_ID);
                    obj.Comentarios = txb7;

                    decimal valor = obj.Precio_xTonelada_compra;
                    if (!decimal.TryParse(txb5, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
                    {
                        valor = obj.Precio_xTonelada_compra;
                    }
                    obj.Precio_xTonelada_compra = valor;

                    #region DDL logic

                    int ddl1 = obj.Variedad_ID;
                    if (!int.TryParse(ddlVariedad1, out ddl1))
                    {
                        ddl1 = obj.Variedad_ID;
                    }
                    obj.Variedad_ID = ddl1;

                    //int ddl2 = obj.Procesador_ID;
                    //if (!int.TryParse(ddlProcesador1, out ddl2))
                    //{
                    //    ddl2 = obj.Procesador_ID;
                    //}
                    //obj.Procesador_ID = ddl2;

                    #endregion DDL logic

                    #region Datetime logic

                    DateTime date1 = obj.Fecha_corte;
                    if (!DateTime.TryParseExact(txb4, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                    {
                        date1 = obj.Fecha_corte;
                    }
                    obj.Fecha_corte = date1;

                    #endregion Datetime logic

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridMercaderias.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridMercaderias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int mercaderias_ID = Convert.ToInt32(gridMercaderias.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                mercaderia_comprada obj = context.mercaderia_comprada.First(x => x.Mercaderia_ID == mercaderias_ID);
                context.mercaderia_comprada.Remove(obj);
                context.SaveChanges();
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