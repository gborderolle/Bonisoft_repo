using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls
{
    public partial class Cuadrillas : System.Web.UI.UserControl
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
                hdnCuadrillasCount.Value = context.cuadrilla_descarga.Count().ToString();
                if (context.cuadrilla_descarga.Count() > 0)
                {
                    gridCuadrilla.DataSource = context.cuadrilla_descarga.ToList();
                    gridCuadrilla.DataBind();
                }
                else
                {
                    var obj = new List<cuadrilla_descarga>();
                    obj.Add(new cuadrilla_descarga());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridCuadrilla.DataSource = obj;
                    gridCuadrilla.DataBind();
                    int columnsCount = gridCuadrilla.Columns.Count;
                    gridCuadrilla.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridCuadrilla.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridCuadrilla.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridCuadrilla.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridCuadrilla.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridCuadrilla.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridCuadrilla.Rows[0].Cells[0].Text = "No hay registros";
                }
            }
        }

        protected void gridSample_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlEmpresas1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlEmpresas2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    var elements = context.proveedores.Select(c => new { ID = c.Proveedor_ID, DisplayText = "Proveedor: " + c.Nombre_fantasia.ToString() }).ToList();
                    elements.AddRange(context.clientes.Select(c => new { ID = c.cliente_ID, DisplayText = "Cliente: " + c.Nombre_fantasia.ToString() }).ToList());

                    ddl.DataSource = elements;
                    ddl.DataTextField = "DisplayText";
                    ddl.DataValueField = "ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((cuadrilla_descarga)(e.Row.DataItem)).Empresa_ID.ToString();
                }
            }
        }

        protected void gridSample_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridCuadrilla.FooterRow;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                DropDownList ddlEmpresas2 = row.FindControl("ddlEmpresas2") as DropDownList;
                if (ddlEmpresas2 != null && txb2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        cuadrilla_descarga obj = new cuadrilla_descarga();
                        obj.Empresa_ID = Convert.ToInt32(ddlEmpresas2.SelectedValue);
                        obj.Comentarios = txb2.Text;

                        bool isClient = false;
                        string selectedText = ddlEmpresas2.SelectedItem.Text;
                        if (!string.IsNullOrWhiteSpace(selectedText))
                        {
                            isClient = selectedText.Contains("Cliente");
                        }
                        obj.Empresa_esCliente = isClient;

                        context.cuadrilla_descarga.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
        }

        protected void gridSample_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridCuadrilla.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridSample_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCuadrilla.EditIndex = -1;
            BindGrid();
        }
        protected void gridSample_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridCuadrilla.Rows[e.RowIndex];
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            DropDownList ddlEmpresas2 = row.FindControl("ddlEmpresas2") as DropDownList;
            if (ddlEmpresas2 != null && txb2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int cuadrilla_descarga_ID = Convert.ToInt32(gridCuadrilla.DataKeys[e.RowIndex].Value);
                    cuadrilla_descarga obj = context.cuadrilla_descarga.First(x => x.Cuadrilla_descarga_ID == cuadrilla_descarga_ID);
                    obj.Empresa_ID = Convert.ToInt32(ddlEmpresas2.SelectedValue);
                    obj.Comentarios = txb2.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridCuadrilla.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cuadrilla_descarga_ID = Convert.ToInt32(gridCuadrilla.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                cuadrilla_descarga obj = context.cuadrilla_descarga.First(x => x.Cuadrilla_descarga_ID == cuadrilla_descarga_ID);
                context.cuadrilla_descarga.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridCuadrilla.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridCuadrilla.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }
    }
}