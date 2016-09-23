using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Camiones1 : System.Web.UI.UserControl
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
                hdnCamionesCount.Value = context.camiones.Count().ToString();
                if (context.camiones.Count() > 0)
                {
                    gridCamiones.DataSource = context.camiones.ToList();
                    gridCamiones.DataBind();
                }
                else
                {
                    var obj = new List<camion>();
                    obj.Add(new camion());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridCamiones.DataSource = obj;
                    gridCamiones.DataBind();
                    int columnsCount = gridCamiones.Columns.Count;
                    gridCamiones.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridCamiones.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridCamiones.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridCamiones.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridCamiones.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridCamiones.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridCamiones.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridCamiones_RowDataBound(object sender, GridViewRowEventArgs e)
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


        protected void gridCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridCamiones.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                TextBox txb7 = row.FindControl("txbNew7") as TextBox;
                TextBox txb9 = row.FindControl("txbNew9") as TextBox;
                if (txb1 != null && txb2 != null && txb3 != null && txb6 != null && txb7 != null && txb9 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        camion obj = new camion();
                        obj.Matricula_camion = txb1.Text;
                        obj.Matricula_zorra = txb2.Text;
                        obj.Numero_ejes = int.Parse(txb3.Text);
                        obj.Marca = txb6.Text;
                        obj.Modelo = txb7.Text;
                        obj.Comentarios = txb9.Text;

                        context.camiones.Add(obj);
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

        protected void gridCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridCamiones.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCamiones.EditIndex = -1;
            BindGrid();
        }
        protected void gridCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridCamiones.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            TextBox txb9 = row.FindControl("txb9") as TextBox;
            if (txb1 != null && txb2 != null && txb3 != null && txb6 != null && txb7 != null && txb9 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int camion_ID = Convert.ToInt32(gridCamiones.DataKeys[e.RowIndex].Value);
                    camion obj = context.camiones.First(x => x.Camion_ID == camion_ID);
                    obj.Matricula_camion = txb1.Text;
                    obj.Matricula_zorra = txb2.Text;
                    obj.Numero_ejes = int.Parse(txb3.Text);
                    obj.Marca = txb6.Text;
                    obj.Modelo = txb7.Text;
                    obj.Comentarios = txb9.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridCamiones.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int camion_ID = Convert.ToInt32(gridCamiones.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                camion obj = context.camiones.First(x => x.Camion_ID == camion_ID);
                context.camiones.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridCamiones.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridCamiones.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}