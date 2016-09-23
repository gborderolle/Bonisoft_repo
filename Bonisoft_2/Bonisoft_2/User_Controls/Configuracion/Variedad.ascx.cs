using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls.Configuracion
{
    public partial class Variedad : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnVariedadCount.Value = context.variedad.Count().ToString();
                if (context.variedad.Count() > 0)
                {
                    gridVariedades.DataSource = context.variedad.ToList();
                    gridVariedades.DataBind();
                }
                else
                {
                    var obj = new List<variedad>();
                    obj.Add(new variedad());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridVariedades.DataSource = obj;
                    gridVariedades.DataBind();
                    int columnsCount = gridVariedades.Columns.Count;
                    gridVariedades.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridVariedades.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridVariedades.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridVariedades.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridVariedades.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridVariedades.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridVariedades.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridVariedades_RowDataBound(object sender, GridViewRowEventArgs e)
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

            #region DDL Options 

            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlTipo1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlTipo2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.lena_tipo.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Tipo";
                    ddl.DataValueField = "Lena_tipo_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));
                }
            }

            #endregion

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lbl3") as Label;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        variedad variedad = (variedad)(e.Row.DataItem);
                        if (variedad != null)
                        {
                            int id = variedad.Lena_tipo_ID;
                            lena_tipo lena_tipo = (lena_tipo)context.lena_tipo.FirstOrDefault(c => c.Lena_tipo_ID == id);
                            if (lena_tipo != null)
                            {
                                string nombre = lena_tipo.Tipo;
                                lbl.Text = nombre;
                            }
                        }
                    }
                }
            }
        }

        protected void gridVariedades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridVariedades.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                DropDownList ddlTipo2 = row.FindControl("ddlTipo2") as DropDownList;
                if (txb1 != null && txb2 != null && ddlTipo2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        variedad obj = new variedad();
                        obj.Nombre = txb1.Text;
                        obj.Comentarios = txb2.Text;

                        obj.Lena_tipo_ID = Convert.ToInt32(ddlTipo2.SelectedValue);

                        context.variedad.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
        }

        protected void gridVariedades_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridVariedades.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridVariedades_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridVariedades.EditIndex = -1;
            BindGrid();
        }
        protected void gridVariedades_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridVariedades.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            DropDownList ddlTipo2 = row.FindControl("ddlTipo1") as DropDownList;
            if (txb1 != null && txb2 != null && ddlTipo2 !=null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int variedad_ID = Convert.ToInt32(gridVariedades.DataKeys[e.RowIndex].Value);
                    variedad obj = context.variedad.First(x => x.Variedad_ID == variedad_ID);
                    obj.Nombre = txb1.Text;
                    obj.Comentarios = txb2.Text;

                    int ddl1 = obj.Lena_tipo_ID;
                    if (!int.TryParse(ddlTipo2.SelectedValue, out ddl1))
                    {
                        ddl1 = obj.Lena_tipo_ID;
                    }
                    obj.Lena_tipo_ID = ddl1;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridVariedades.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridVariedades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int variedad_ID = Convert.ToInt32(gridVariedades.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                variedad obj = context.variedad.First(x => x.Variedad_ID == variedad_ID);
                context.variedad.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridVariedades.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridVariedades.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }
    }
}