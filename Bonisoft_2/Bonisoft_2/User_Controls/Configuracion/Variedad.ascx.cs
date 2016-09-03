﻿using System;
using System.Collections.Generic;
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

        void BindGrid()
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
            }
        }

        protected void gridSample_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void gridSample_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridVariedades.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                if (txb1 != null && txb2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        variedad obj = new variedad();
                        obj.Nombre = txb1.Text;
                        obj.Comentarios = txb2.Text;

                        context.variedad.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
        }

        protected void gridSample_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridVariedades.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridSample_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridVariedades.EditIndex = -1;
            BindGrid();
        }
        protected void gridSample_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridVariedades.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            if (txb1 != null && txb2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int variedad_ID = Convert.ToInt32(gridVariedades.DataKeys[e.RowIndex].Value);
                    variedad obj = context.variedad.First(x => x.Variedad_ID == variedad_ID);
                    obj.Nombre = txb1.Text;
                    obj.Comentarios = txb2.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridVariedades.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
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