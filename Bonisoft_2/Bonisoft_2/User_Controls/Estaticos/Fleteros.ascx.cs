﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls.Estaticos
{
    public partial class Fleteros : System.Web.UI.UserControl
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
                hdnFleterosCount.Value = context.fleteros.Count().ToString();
                if (context.fleteros.Count() > 0)
                {
                    gridFleteros.DataSource = context.fleteros.ToList();
                    gridFleteros.DataBind();
                }
                else
                {
                    var obj = new List<fletero>();
                    obj.Add(new fletero());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridFleteros.DataSource = obj;
                    gridFleteros.DataBind();
                    int columnsCount = gridFleteros.Columns.Count;
                    gridFleteros.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridFleteros.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridFleteros.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridFleteros.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridFleteros.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridFleteros.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridFleteros.Rows[0].Cells[0].Text = "No hay registros";
                }
            }
        }

        protected void gridFleteros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }


        protected void gridFleteros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridFleteros.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                if (txb1 != null && txb2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        fletero obj = new fletero();
                        obj.Nombre = txb1.Text;
                        obj.Comentarios = txb2.Text;

                        context.fleteros.Add(obj);
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

        protected void gridFleteros_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridFleteros.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridFleteros_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridFleteros.EditIndex = -1;
            BindGrid();
        }
        protected void gridFleteros_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridFleteros.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            if (txb1 != null && txb2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int fletero_ID = Convert.ToInt32(gridFleteros.DataKeys[e.RowIndex].Value);
                    fletero obj = context.fleteros.First(x => x.Fletero_ID == fletero_ID);
                    obj.Nombre = txb1.Text;
                    obj.Comentarios = txb2.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridFleteros.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridFleteros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int fletero_ID = Convert.ToInt32(gridFleteros.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                fletero obj = context.fleteros.First(x => x.Fletero_ID == fletero_ID);
                context.fleteros.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridFleteros.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridFleteros.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}