using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls
{
    public partial class Internos : System.Web.UI.UserControl
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
                hdnInternosCount.Value = context.internos.Count().ToString();
                if (context.internos.Count() > 0)
                {
                    gridInternos.DataSource = context.internos.ToList();
                    gridInternos.DataBind();
                }
                else
                {
                    var obj = new List<interno>();
                    obj.Add(new interno());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridInternos.DataSource = obj;
                    gridInternos.DataBind();
                    int columnsCount = gridInternos.Columns.Count;
                    gridInternos.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridInternos.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridInternos.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridInternos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridInternos.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridInternos.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridInternos.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridInternos_RowDataBound(object sender, GridViewRowEventArgs e)
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


        protected void gridInternos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridInternos.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb5 = row.FindControl("txbNew5") as TextBox;
                TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                TextBox txb7 = row.FindControl("txbNew7") as TextBox;
                TextBox txb8 = row.FindControl("txbNew8") as TextBox;
                if (txb1 != null && txb3 != null && txb5 != null && txb6 != null && txb7 != null && txb8 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        interno obj = new interno();
                        obj.Nombre_completo = txb1.Text;
                        obj.Cargo = txb7.Text;
                        obj.Comentarios = txb8.Text;

                        #region Datetime logic

                        DateTime date1 = DateTime.Now;
                        if (!DateTime.TryParseExact(txb3.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                        {
                            date1 = DateTime.Now;
                        }
                        obj.Fecha_nacimiento = date1;

                        DateTime date2 = DateTime.Now;
                        if (!DateTime.TryParseExact(txb5.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                        {
                            date2 = DateTime.Now;
                        }
                        obj.Fecha_ingreso = date2;

                        DateTime date3 = DateTime.Now;
                        if (!DateTime.TryParseExact(txb6.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                        {
                            date3 = DateTime.Now;
                        }
                        obj.Fecha_egreso = date3;

                        #endregion

                        context.internos.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
            else
            {
                //BindGrid();
            }
        }

        protected void gridInternos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridInternos.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridInternos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridInternos.EditIndex = -1;
            BindGrid();
        }
        protected void gridInternos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridInternos.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb5 = row.FindControl("txb5") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            TextBox txb8 = row.FindControl("txb8") as TextBox;
            if (txb1 != null && txb3 != null && txb5 != null && txb6 != null && txb7 != null && txb8 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int interno_ID = Convert.ToInt32(gridInternos.DataKeys[e.RowIndex].Value);
                    interno obj = context.internos.First(x => x.Interno_ID == interno_ID);
                    obj.Nombre_completo = txb1.Text;
                    obj.Cargo = txb7.Text;
                    obj.Comentarios = txb8.Text;

                    #region Datetime logic

                    DateTime date1 = obj.Fecha_nacimiento;
                    if (!DateTime.TryParseExact(txb3.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                    {
                        date1 = obj.Fecha_nacimiento;
                    }
                    obj.Fecha_nacimiento = date1;

                    DateTime date2 = obj.Fecha_ingreso;
                    if (!DateTime.TryParseExact(txb5.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                    {
                        date2 = obj.Fecha_ingreso;
                    }
                    obj.Fecha_ingreso = date2;

                    DateTime date3 = obj.Fecha_egreso;
                    if (!DateTime.TryParseExact(txb6.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                    {
                        date3 = obj.Fecha_egreso;
                    }
                    obj.Fecha_egreso = date3;

                    #endregion

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridInternos.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridInternos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int interno_ID = Convert.ToInt32(gridInternos.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                interno obj = context.internos.First(x => x.Interno_ID == interno_ID);
                context.internos.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridInternos.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridInternos.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}