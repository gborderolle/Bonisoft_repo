using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls.Configuracion
{
    public partial class Camion_ejes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridEjes.UseAccessibleHeader = true;
            gridEjes.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnEjesCount.Value = context.camion_ejes.Count().ToString();
                if (context.camion_ejes.Count() > 0)
                {
                    gridEjes.DataSource = context.camion_ejes.ToList();
                    gridEjes.DataBind();
                }
                else
                {
                    var obj = new List<camion_ejes>();
                    obj.Add(new camion_ejes());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridEjes.DataSource = obj;
                    gridEjes.DataBind();
                    int columnsCount = gridEjes.Columns.Count;
                    gridEjes.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridEjes.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridEjes.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridEjes.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridEjes.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridEjes.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridEjes.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridEjes_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gridEjes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridEjes.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                if (txb1 != null && txb2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        camion_ejes obj = new camion_ejes();
                        obj.Ejes = txb1.Text;
                        obj.Comentarios = txb2.Text;

                        context.camion_ejes.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
        }

        protected void gridEjes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridEjes.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridEjes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridEjes.EditIndex = -1;
            BindGrid();
        }
        protected void gridEjes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridEjes.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            if (txb1 != null && txb2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int camion_ejes_ID = Convert.ToInt32(gridEjes.DataKeys[e.RowIndex].Value);
                    camion_ejes obj = context.camion_ejes.First(x => x.Camion_ejes_ID == camion_ejes_ID);
                    obj.Ejes = txb1.Text;
                    obj.Comentarios = txb2.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridEjes.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridEjes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int camion_ejes_ID = Convert.ToInt32(gridEjes.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                camion_ejes obj = context.camion_ejes.First(x => x.Camion_ejes_ID == camion_ejes_ID);
                context.camion_ejes.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridEjes.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridEjes.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }
    }
}