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
    public partial class Choferes2 : System.Web.UI.UserControl
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
                hdnChoferesCount.Value = context.choferes.Count().ToString();
                if (context.choferes.Count() > 0)
                {
                    gridChoferes.DataSource = context.choferes.ToList();
                    gridChoferes.DataBind();
                }
                else
                {
                    var obj = new List<chofer>();
                    obj.Add(new chofer());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridChoferes.DataSource = obj;
                    gridChoferes.DataBind();
                    int columnsCount = gridChoferes.Columns.Count;
                    gridChoferes.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridChoferes.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridChoferes.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridChoferes.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridChoferes.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridChoferes.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridChoferes.Rows[0].Cells[0].Text = "No hay registros";
                }
            }
        }

        protected void gridChoferes_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    var elements = context.proveedores.Select(c => new { ID = c.Proveedor_ID, DisplayText = "Proveedor: " + c.Nombre.ToString() }).ToList();
                    elements.AddRange(context.clientes.Select(c => new { ID = c.cliente_ID, DisplayText = "Cliente: " + c.Nombre.ToString() }).ToList());

                    ddl.DataSource = elements;
                    ddl.DataTextField = "DisplayText";
                    ddl.DataValueField = "ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        ddl.SelectedValue = ((chofer)(e.Row.DataItem)).Empresa_pertenece_ID.ToString();                      
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lbl3") as Label;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        chofer chofer = (chofer)(e.Row.DataItem);
                        if (chofer != null)
                        {
                            try
                            {
                                int id = chofer.Empresa_pertenece_ID;
                                string empresa = chofer.Empresa_esCliente ? ((cliente)context.clientes.FirstOrDefault(c => c.cliente_ID == id)).Nombre : ((proveedor)context.proveedores.FirstOrDefault(c => c.Proveedor_ID == id)).Nombre;
                                lbl.Text = empresa;
                            }
                            catch (Exception) { }
                        }
                    }
                }
            }
        }

        protected void gridChoferes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridChoferes.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                DropDownList ddlEmpresas2 = row.FindControl("ddlEmpresas2") as DropDownList;
                if (txb1 != null && txb2 != null && ddlEmpresas2 != null && txb4 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        chofer obj = new chofer();
                        obj.Apellidos = txb1.Text;
                        obj.Nombres = txb2.Text;
                        obj.Comentarios = txb4.Text;

                        #region DDL logic

                        int ddl1 = 0;
                        if (!int.TryParse(ddlEmpresas2.SelectedValue, out ddl1))
                        {
                            ddl1 = 0;
                        }
                        obj.Empresa_pertenece_ID = ddl1;

                        #endregion DDL logic

                        bool isClient = false;
                        string selectedText = ddlEmpresas2.SelectedItem.Text;
                        if (!string.IsNullOrWhiteSpace(selectedText))
                        {
                            isClient = selectedText.Contains("Cliente");
                        }
                        obj.Empresa_esCliente = isClient;

                        context.choferes.Add(obj);
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

        protected void gridChoferes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridChoferes.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridChoferes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridChoferes.EditIndex = -1;
            BindGrid();
        }
        protected void gridChoferes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridChoferes.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            DropDownList ddlEmpresas1 = row.FindControl("ddlEmpresas1") as DropDownList;
            if (txb1 != null && txb2 != null && ddlEmpresas1 != null && txb4 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int chofer_ID = Convert.ToInt32(gridChoferes.DataKeys[e.RowIndex].Value);
                    chofer obj = context.choferes.First(x => x.Chofer_ID == chofer_ID);
                    obj.Apellidos = txb1.Text;
                    obj.Nombres = txb2.Text;
                    obj.Empresa_pertenece_ID = Convert.ToInt32(ddlEmpresas1.SelectedValue);
                    obj.Comentarios = txb4.Text;

                    bool isClient = false;
                    string selectedText = ddlEmpresas1.SelectedItem.Text;
                    if (!string.IsNullOrWhiteSpace(selectedText))
                    {
                        isClient = selectedText.Contains("Cliente");
                    }
                    obj.Empresa_esCliente = isClient;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridChoferes.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridChoferes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int chofer_ID = Convert.ToInt32(gridChoferes.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                chofer obj = context.choferes.First(x => x.Chofer_ID == chofer_ID);
                context.choferes.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridChoferes.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridChoferes.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}