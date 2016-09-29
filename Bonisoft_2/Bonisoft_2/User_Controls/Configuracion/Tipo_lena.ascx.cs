using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls.Configuracion
{
    public partial class Tipo_lena : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridTipos.UseAccessibleHeader = true;
            gridTipos.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnTiposCount.Value = context.lena_tipo.Count().ToString();
                if (context.lena_tipo.Count() > 0)
                {
                    gridTipos.DataSource = context.lena_tipo.ToList();
                    gridTipos.DataBind();
                }
                else
                {
                    var obj = new List<lena_tipo>();
                    obj.Add(new lena_tipo());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridTipos.DataSource = obj;
                    gridTipos.DataBind();
                    int columnsCount = gridTipos.Columns.Count;
                    gridTipos.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridTipos.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridTipos.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridTipos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridTipos.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridTipos.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridTipos.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridTipos_RowDataBound(object sender, GridViewRowEventArgs e)
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
        }

        protected void gridTipos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridTipos.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                if (txb1 != null && txb2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        lena_tipo obj = new lena_tipo();
                        obj.Tipo = txb1.Text;
                        obj.Comentarios = txb2.Text;

                        context.lena_tipo.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
        }

        protected void gridTipos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridTipos.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridTipos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridTipos.EditIndex = -1;
            BindGrid();
        }
        protected void gridTipos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridTipos.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            if (txb1 != null && txb2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int lena_tipo_ID = Convert.ToInt32(gridTipos.DataKeys[e.RowIndex].Value);
                    lena_tipo obj = context.lena_tipo.First(x => x.Lena_tipo_ID == lena_tipo_ID);
                    obj.Tipo = txb1.Text;
                    obj.Comentarios = txb2.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridTipos.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridTipos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int lena_tipo_ID = Convert.ToInt32(gridTipos.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                lena_tipo obj = context.lena_tipo.First(x => x.Lena_tipo_ID == lena_tipo_ID);
                context.lena_tipo.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridTipos.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridTipos.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }
    }
}