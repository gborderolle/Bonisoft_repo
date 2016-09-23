using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls
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
            //this.LoadCompleted();
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnClientesCount.Value = context.clientes.Count().ToString();
                if (context.clientes.Count() > 0)
                {
                    gridClientes.DataSource = context.clientes.ToList();
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

            LinkButton lnk = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                lnk = e.Row.FindControl("lnkEdit") as LinkButton;
            }
            if (lnk != null)
            {
                ScriptManager ScriptManager1 = ScriptManager.GetCurrent(this.Page);
                if (ScriptManager1 != null)
                {
                    ScriptManager1.RegisterAsyncPostBackControl(lnk);
                }
            }

            lnk = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                lnk = e.Row.FindControl("lnkDelete") as LinkButton;
            }
            if (lnk != null)
            {
                ScriptManager ScriptManager1 = ScriptManager.GetCurrent(this.Page);
                if (ScriptManager1 != null)
                {
                    ScriptManager1.RegisterAsyncPostBackControl(lnk);
                }
            }

            lnk = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                lnk = e.Row.FindControl("lnkInsert") as LinkButton;
            }
            if (lnk != null)
            {
                ScriptManager ScriptManager1 = ScriptManager.GetCurrent(this.Page);
                if (ScriptManager1 != null)
                {
                    ScriptManager1.RegisterAsyncPostBackControl(lnk);
                }
            }

            lnk = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                lnk = e.Row.FindControl("lnkCancel") as LinkButton;
            }
            if (lnk != null)
            {
                ScriptManager ScriptManager1 = ScriptManager.GetCurrent(this.Page);
                if (ScriptManager1 != null)
                {
                    ScriptManager1.RegisterAsyncPostBackControl(lnk);
                }
            }

            #endregion

            #region DDLs

            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlFormas1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlFormas2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.forma_de_pago.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Forma";
                    ddl.DataValueField = "Forma_de_pago_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((cliente)(e.Row.DataItem)).Forma_de_pago_ID.ToString();
                }
            }

            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlContactoNuestro1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlContactoNuestro2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.internos.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre_completo";
                    ddl.DataValueField = "Interno_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((cliente)(e.Row.DataItem)).Contacto_nuestro_ID.ToString();
                }
            }

            #endregion

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lbl10") as Label;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        cliente cliente = (cliente)(e.Row.DataItem);
                        if (cliente != null)
                        {
                            int id = cliente.Forma_de_pago_ID;
                            forma_de_pago forma_de_pago = (forma_de_pago)context.forma_de_pago.FirstOrDefault(c => c.Forma_de_pago_ID == id);
                            if (forma_de_pago != null)
                            {
                                string nombre = forma_de_pago.Forma;
                                lbl.Text = nombre;
                            }
                        }
                    }
                }
            }


        }


        protected void gridClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridClientes.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                TextBox txb5 = row.FindControl("txbNew5") as TextBox;
                TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                TextBox txb7 = row.FindControl("txbNew7") as TextBox;
                TextBox txb8 = row.FindControl("txbNew8") as TextBox;
                TextBox txb11 = row.FindControl("txbNew11") as TextBox;
                TextBox txb12 = row.FindControl("txbNew12") as TextBox;
                TextBox txb13 = row.FindControl("txbNew13") as TextBox;
                TextBox txb15 = row.FindControl("txbNew15") as TextBox;
                TextBox txb16 = row.FindControl("txbNew16") as TextBox;
                TextBox txb17 = row.FindControl("txbNew17") as TextBox;
                TextBox txb22 = row.FindControl("txbNew22") as TextBox;
                DropDownList ddlContactoNuestro2 = row.FindControl("ddlContactoNuestro2") as DropDownList;
                DropDownList ddlFormas2 = row.FindControl("ddlFormas2") as DropDownList;
                if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb5 != null && txb6 != null && txb7 != null && txb8 != null
                    && ddlFormas2 != null && ddlContactoNuestro2 != null &&
                    txb11 != null && txb12 != null && txb13 != null && txb15 != null && txb16 != null && txb17 != null && txb22 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        cliente obj = new cliente();
                        obj.Dueno_nombre = txb1.Text;
                        obj.Dueno_contacto = txb2.Text;
                        obj.Encargado_lena_nombre = txb3.Text;
                        obj.Encargado_lena_contacto = txb4.Text;
                        obj.Encargado_pagos_nombre = txb5.Text;
                        obj.Encargado_pagos_contacto = txb6.Text;
                        obj.Supervisor_lena_nombre = txb7.Text;
                        obj.Supervisor_lena_contacto = txb8.Text;
                        obj.Periodos_liquidacion = txb11.Text;
                        obj.Fechas_pago = txb12.Text;
                        obj.Nombre = txb13.Text;
                        obj.RUT = txb15.Text;
                        obj.Direccion = txb16.Text;
                        obj.Telefono = txb17.Text;
                        obj.Comentarios = txb22.Text;

                        #region DDL logic

                        int ddl1 = 0;
                        if (!int.TryParse(ddlFormas2.SelectedValue, out ddl1))
                        {
                            ddl1 = 0;
                        }
                        obj.Forma_de_pago_ID = ddl1;

                        int ddl2 = 0;
                        if (!int.TryParse(ddlContactoNuestro2.SelectedValue, out ddl1))
                        {
                            ddl2 = 0;
                        }
                        obj.Contacto_nuestro_ID = ddl2;

                        #endregion DDL logic

                        context.clientes.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
            else
            {
                BindGrid();
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
            GridViewRow row = gridClientes.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            TextBox txb5 = row.FindControl("txb5") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            TextBox txb8 = row.FindControl("txb8") as TextBox;
            TextBox txb11 = row.FindControl("txb11") as TextBox;
            TextBox txb12 = row.FindControl("txb12") as TextBox;
            TextBox txb13 = row.FindControl("txb13") as TextBox;
            TextBox txb15 = row.FindControl("txb15") as TextBox;
            TextBox txb16 = row.FindControl("txb16") as TextBox;
            TextBox txb17 = row.FindControl("txb17") as TextBox;
            TextBox txb22 = row.FindControl("txb22") as TextBox;
            DropDownList ddlContactoNuestro2 = row.FindControl("ddlContactoNuestro1") as DropDownList;
            DropDownList ddlFormas2 = row.FindControl("ddlFormas1") as DropDownList;
            if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb5 != null && txb6 != null && txb7 != null && txb8 != null 
                && ddlFormas2 != null && ddlContactoNuestro2 != null &&
                txb11 != null && txb12 != null && txb13 != null && txb15 != null && txb16 != null && txb17 != null && txb22 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int cliente_ID = Convert.ToInt32(gridClientes.DataKeys[e.RowIndex].Value);
                    cliente obj = context.clientes.First(x => x.cliente_ID == cliente_ID);
                    obj.Dueno_nombre = txb1.Text;
                    obj.Dueno_contacto = txb2.Text;
                    obj.Encargado_lena_nombre = txb3.Text;
                    obj.Encargado_lena_contacto = txb4.Text;
                    obj.Encargado_pagos_nombre = txb5.Text;
                    obj.Encargado_pagos_contacto = txb6.Text;
                    obj.Supervisor_lena_nombre = txb7.Text;
                    obj.Supervisor_lena_contacto = txb8.Text;
                    obj.Periodos_liquidacion = txb11.Text;
                    obj.Fechas_pago = txb12.Text;
                    obj.Nombre = txb13.Text;
                    obj.RUT = txb15.Text;
                    obj.Direccion = txb16.Text;
                    obj.Telefono = txb17.Text;
                    obj.Comentarios = txb22.Text;

                    #region DDL logic

                    int ddl1 = obj.Forma_de_pago_ID;
                    if (!int.TryParse(ddlFormas2.SelectedValue, out ddl1))
                    {
                        ddl1 = obj.Forma_de_pago_ID;
                    }
                    obj.Forma_de_pago_ID = ddl1;

                    int ddl2 = obj.Contacto_nuestro_ID;
                    if (!int.TryParse(ddlContactoNuestro2.SelectedValue, out ddl2))
                    {
                        ddl2 = obj.Contacto_nuestro_ID;
                    }
                    obj.Contacto_nuestro_ID = ddl2;

                    #endregion DDL logic

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridClientes.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cliente_ID = Convert.ToInt32(gridClientes.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                cliente obj = context.clientes.First(x => x.cliente_ID == cliente_ID);
                context.clientes.Remove(obj);
                context.SaveChanges();
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