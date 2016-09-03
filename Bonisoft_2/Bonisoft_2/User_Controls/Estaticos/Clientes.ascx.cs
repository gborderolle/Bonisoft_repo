using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls
{
    public partial class Clientes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
        }

        void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnClientesCount.Value = context.clientes.Count().ToString();
                if (context.clientes.Count() > 0)
                {
                    gridSample.DataSource = context.clientes.ToList();
                    gridSample.DataBind();
                }
                else
                {
                    var obj = new List<cliente>();
                    obj.Add(new cliente());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridSample.DataSource = obj;
                    gridSample.DataBind();
                    int columnsCount = gridSample.Columns.Count;
                    gridSample.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridSample.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridSample.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridSample.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridSample.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridSample.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridSample.Rows[0].Cells[0].Text = "No hay registros";
                }
            }
        }

        protected void gridSample_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }


        protected void gridSample_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridSample.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                TextBox txb5 = row.FindControl("txbNew5") as TextBox;
                TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                TextBox txb7 = row.FindControl("txbNew7") as TextBox;
                TextBox txb8 = row.FindControl("txbNew8") as TextBox;
                TextBox txb9 = row.FindControl("txbNew9") as TextBox;
                TextBox txb10 = row.FindControl("txbNew10") as TextBox;
                TextBox txb11 = row.FindControl("txbNew11") as TextBox;
                TextBox txb12 = row.FindControl("txbNew12") as TextBox;
                TextBox txb13 = row.FindControl("txbNew13") as TextBox;
                TextBox txb14 = row.FindControl("txbNew14") as TextBox;
                TextBox txb15 = row.FindControl("txbNew15") as TextBox;
                TextBox txb16 = row.FindControl("txbNew16") as TextBox;
                TextBox txb17 = row.FindControl("txbNew17") as TextBox;
                TextBox txb18 = row.FindControl("txbNew18") as TextBox;
                TextBox txb19 = row.FindControl("txbNew19") as TextBox;
                TextBox txb20 = row.FindControl("txbNew20") as TextBox;
                TextBox txb21 = row.FindControl("txbNew21") as TextBox;
                TextBox txb22 = row.FindControl("txbNew22") as TextBox;
                if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb5 != null && txb6 != null && txb7 != null && txb8 != null && txb9 != null && txb10 != null &&
                    txb11 != null && txb12 != null && txb13 != null && txb14 != null && txb15 != null && txb16 != null && txb17 != null && txb18 != null && txb19 != null && txb20 != null && txb21 != null && txb22 != null)
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
                        obj.Contacto_nuestro_ID = int.Parse(txb9.Text);
                        obj.Forma_de_pago_ID = int.Parse(txb10.Text);
                        obj.Periodos_liquidacion = txb11.Text;
                        obj.Fechas_pago = txb12.Text;
                        obj.Nombre_fantasia = txb13.Text;
                        obj.Nombre_real = txb14.Text;
                        obj.RUT = txb15.Text;
                        obj.Direccion = txb16.Text;
                        obj.Dueno_nombre = txb17.Text;
                        obj.Telefono_1 = txb18.Text;
                        obj.Telefono_2 = txb19.Text;
                        obj.Email = txb20.Text;
                        obj.Ciudad = txb21.Text;
                        obj.Comentarios = txb22.Text;

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

        protected void gridSample_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridSample.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridSample_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridSample.EditIndex = -1;
            BindGrid();
        }
        protected void gridSample_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridSample.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            TextBox txb5 = row.FindControl("txb5") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            TextBox txb8 = row.FindControl("txb8") as TextBox;
            TextBox txb9 = row.FindControl("txb9") as TextBox;
            TextBox txb10 = row.FindControl("txb10") as TextBox;
            TextBox txb11 = row.FindControl("txb11") as TextBox;
            TextBox txb12 = row.FindControl("txb12") as TextBox;
            TextBox txb13 = row.FindControl("txb13") as TextBox;
            TextBox txb14 = row.FindControl("txb14") as TextBox;
            TextBox txb15 = row.FindControl("txb15") as TextBox;
            TextBox txb16 = row.FindControl("txb16") as TextBox;
            TextBox txb17 = row.FindControl("txb17") as TextBox;
            TextBox txb18 = row.FindControl("txb18") as TextBox;
            TextBox txb19 = row.FindControl("txb19") as TextBox;
            TextBox txb20 = row.FindControl("txb20") as TextBox;
            TextBox txb21 = row.FindControl("txb21") as TextBox;
            TextBox txb22 = row.FindControl("txb22") as TextBox;
            if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb5 != null && txb6 != null && txb7 != null && txb8 != null && txb9 != null && txb10 != null &&
                txb11 != null && txb12 != null && txb13 != null && txb14 != null && txb15 != null && txb16 != null && txb17 != null && txb18 != null && txb19 != null && txb20 != null && txb21 != null && txb22 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int cliente_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
                    cliente obj = context.clientes.First(x => x.cliente_ID == cliente_ID);
                    obj.Dueno_nombre = txb1.Text;
                    obj.Dueno_contacto = txb2.Text;
                    obj.Encargado_lena_nombre = txb3.Text;
                    obj.Encargado_lena_contacto = txb4.Text;
                    obj.Encargado_pagos_nombre = txb5.Text;
                    obj.Encargado_pagos_contacto = txb6.Text;
                    obj.Supervisor_lena_nombre = txb7.Text;
                    obj.Supervisor_lena_contacto = txb8.Text;
                    obj.Contacto_nuestro_ID = int.Parse(txb9.Text);
                    obj.Forma_de_pago_ID = int.Parse(txb10.Text);
                    obj.Periodos_liquidacion = txb11.Text;
                    obj.Fechas_pago = txb12.Text;
                    obj.Nombre_fantasia = txb13.Text;
                    obj.Nombre_real = txb14.Text;
                    obj.RUT = txb15.Text;
                    obj.Direccion = txb16.Text;
                    obj.Dueno_nombre = txb17.Text;
                    obj.Telefono_1 = txb18.Text;
                    obj.Telefono_2 = txb19.Text;
                    obj.Email = txb20.Text;
                    obj.Ciudad = txb21.Text;
                    obj.Comentarios = txb22.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridSample.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cliente_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
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
            GridViewRow pagerRow = gridSample.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridSample.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}