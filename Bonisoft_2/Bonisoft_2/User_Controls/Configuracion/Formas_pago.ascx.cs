using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls.Configuracion
{
    public partial class Formas_pago : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridFormas.UseAccessibleHeader = true;
            gridFormas.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnFormaCount.Value = context.forma_de_pago.Count().ToString();
                if (context.forma_de_pago.Count() > 0)
                {
                    gridFormas.DataSource = context.forma_de_pago.ToList();
                    gridFormas.DataBind();
                }
                else
                {
                    var obj = new List<forma_de_pago>();
                    obj.Add(new forma_de_pago());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridFormas.DataSource = obj;
                    gridFormas.DataBind();
                    int columnsCount = gridFormas.Columns.Count;
                    gridFormas.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridFormas.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridFormas.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridFormas.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridFormas.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridFormas.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridFormas.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridFormas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Updatepanel triggers

            ScriptManager ScriptManager1 = ScriptManager.GetCurrent(this.Page);
            if (ScriptManager1 != null)
            {
                LinkButton lnk = null;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    lnk = e.Row.FindControl("lnkEdit") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkDelete") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkInsert") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkCancel") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }
                }
            }

            #endregion

        }

        protected void gridFormas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridFormas.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                if (txb1 != null && txb2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        forma_de_pago obj = new forma_de_pago();
                        obj.Forma = txb1.Text;
                        obj.Comentarios = txb2.Text;

                        context.forma_de_pago.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
        }

        protected void gridFormas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridFormas.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridFormas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridFormas.EditIndex = -1;
            BindGrid();
        }
        protected void gridFormas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridFormas.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            if (txb1 != null && txb2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int forma_de_pago_ID = Convert.ToInt32(gridFormas.DataKeys[e.RowIndex].Value);
                    forma_de_pago obj = context.forma_de_pago.First(x => x.Forma_de_pago_ID == forma_de_pago_ID);
                    obj.Forma = txb1.Text;
                    obj.Comentarios = txb2.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridFormas.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridFormas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int forma_de_pago_ID = Convert.ToInt32(gridFormas.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                forma_de_pago obj = context.forma_de_pago.First(x => x.Forma_de_pago_ID == forma_de_pago_ID);
                context.forma_de_pago.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridFormas.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridFormas.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }
    }
}