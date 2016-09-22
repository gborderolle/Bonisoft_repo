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
    public partial class Mercaderias : System.Web.UI.UserControl
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
                hdnMercaderiasCount.Value = context.mercaderia_comprada.Count().ToString();
                if (context.mercaderia_comprada.Count() > 0)
                {
                    gridMercaderias.DataSource = context.mercaderia_comprada.ToList();
                    gridMercaderias.DataBind();
                }
                else
                {
                    var obj = new List<mercaderia_comprada>();
                    obj.Add(new mercaderia_comprada());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridMercaderias.DataSource = obj;
                    gridMercaderias.DataBind();
                    int columnsCount = gridMercaderias.Columns.Count;
                    gridMercaderias.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridMercaderias.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridMercaderias.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridMercaderias.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridMercaderias.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridMercaderias.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridMercaderias.Rows[0].Cells[0].Text = "No hay registros";
                }
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridMercaderias_RowDataBound(object sender, GridViewRowEventArgs e)
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

            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlVariedad1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlVariedad2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.variedad.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre";
                    ddl.DataValueField = "Variedad_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((mercaderia_comprada)(e.Row.DataItem)).Variedad_ID.ToString();
                }
            }

            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlProcesador1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlProcesador2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.procesadores.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre";
                    ddl.DataValueField = "Procesador_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((mercaderia_comprada)(e.Row.DataItem)).Procesador_ID.ToString();
                }
            }
        }

        protected void gridMercaderias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridMercaderias.FooterRow;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                TextBox txb5 = row.FindControl("txbNew5") as TextBox;
                TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                TextBox txb7 = row.FindControl("txbNew5") as TextBox;
                DropDownList ddlVariedad2 = row.FindControl("ddlVariedad2") as DropDownList;
                DropDownList ddlProcesador2 = row.FindControl("ddlProcesador2") as DropDownList;
                if (ddlVariedad2 != null && ddlProcesador2 != null && txb4 != null && txb5 != null && txb6 != null && txb7 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        mercaderia_comprada obj = new mercaderia_comprada();
                        obj.Precio_xTonelada_compra = decimal.Parse(txb5.Text);
                        obj.Precio_xTonelada_venta= decimal.Parse(txb6.Text);
                        obj.Comentarios = txb7.Text;

                        #region DDL logic

                        int ddl1 = 0;
                        if (!int.TryParse(ddlVariedad2.SelectedValue, out ddl1))
                        {
                            ddl1 = 0;
                        }
                        obj.Variedad_ID = ddl1;

                        int ddl2 = 0;
                        if (!int.TryParse(ddlProcesador2.SelectedValue, out ddl1))
                        {
                            ddl2 = 0;
                        }
                        obj.Procesador_ID = ddl2;

                        #endregion DDL logic

                        #region Datetime logic

                        DateTime date1 = DateTime.Now;
                        if (!DateTime.TryParseExact(txb4.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                        {
                            date1 = DateTime.Now;
                        }
                        obj.Fecha_corte = date1;

                        #endregion

                        context.mercaderia_comprada.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
        }

        protected void gridMercaderias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridMercaderias.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridMercaderias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridMercaderias.EditIndex = -1;
            BindGrid();
        }
        protected void gridMercaderias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridMercaderias.Rows[e.RowIndex];
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            TextBox txb5 = row.FindControl("txb5") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            DropDownList ddlVariedad1 = row.FindControl("ddlVariedad1") as DropDownList;
            DropDownList ddlProcesador1 = row.FindControl("ddlProcesador1") as DropDownList;
            if (ddlVariedad1 != null && ddlProcesador1 != null && txb4 != null && txb5 != null && txb6 != null && txb7 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int mercaderia_ID = Convert.ToInt32(gridMercaderias.DataKeys[e.RowIndex].Value);
                    mercaderia_comprada obj = context.mercaderia_comprada.First(x => x.Mercaderia_ID == mercaderia_ID);
                    obj.Precio_xTonelada_compra = decimal.Parse(txb5.Text);
                    obj.Precio_xTonelada_venta = decimal.Parse(txb6.Text);
                    obj.Comentarios = txb7.Text;

                    #region DDL logic

                    int ddl1 = obj.Variedad_ID;
                    if (!int.TryParse(ddlVariedad1.SelectedValue, out ddl1))
                    {
                        ddl1 = obj.Variedad_ID;
                    }
                    obj.Variedad_ID = ddl1;

                    int ddl2 = obj.Procesador_ID;
                    if (!int.TryParse(ddlProcesador1.SelectedValue, out ddl2))
                    {
                        ddl2 = obj.Procesador_ID;
                    }
                    obj.Procesador_ID = ddl2;

                    #endregion DDL logic

                    #region Datetime logic

                    DateTime date1 = obj.Fecha_corte;
                    if (!DateTime.TryParseExact(txb4.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                    {
                        date1 = obj.Fecha_corte;
                    }
                    obj.Fecha_corte = date1;

                    #endregion Datetime logic

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridMercaderias.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridMercaderias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int mercaderias_ID = Convert.ToInt32(gridMercaderias.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                mercaderia_comprada obj = context.mercaderia_comprada.First(x => x.Mercaderia_ID == mercaderias_ID);
                context.mercaderia_comprada.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridMercaderias.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridMercaderias.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }
    }
}