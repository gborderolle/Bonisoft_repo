﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls.Estaticos
{
    public partial class Cargadores : System.Web.UI.UserControl
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
                hdnCargadoresCount.Value = context.cargadores.Count().ToString();
                if (context.cargadores.Count() > 0)
                {
                    gridCargadores.DataSource = context.cargadores.ToList();
                    gridCargadores.DataBind();
                }
                else
                {
                    var obj = new List<cargador>();
                    obj.Add(new cargador());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridCargadores.DataSource = obj;
                    gridCargadores.DataBind();
                    int columnsCount = gridCargadores.Columns.Count;
                    gridCargadores.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridCargadores.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridCargadores.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridCargadores.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridCargadores.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridCargadores.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridCargadores.Rows[0].Cells[0].Text = "No hay registros";
                }
            }
        }

        protected void gridCargadores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }


        protected void gridCargadores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridCargadores.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                if (txb1 != null && txb2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        cargador obj = new cargador();
                        obj.Nombre = txb1.Text;
                        obj.Comentarios = txb2.Text;

                        context.cargadores.Add(obj);
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

        protected void gridCargadores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridCargadores.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridCargadores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCargadores.EditIndex = -1;
            BindGrid();
        }
        protected void gridCargadores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridCargadores.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            if (txb1 != null && txb2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int cargador_ID = Convert.ToInt32(gridCargadores.DataKeys[e.RowIndex].Value);
                    cargador obj = context.cargadores.First(x => x.Cargador_ID == cargador_ID);
                    obj.Nombre = txb1.Text;
                    obj.Comentarios = txb2.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridCargadores.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridCargadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cargador_ID = Convert.ToInt32(gridCargadores.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                cargador obj = context.cargadores.First(x => x.Cargador_ID == cargador_ID);
                context.cargadores.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridCargadores.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridCargadores.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}