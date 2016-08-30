﻿using System;
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

        void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                grdInternosCount.Value = context.internos.Count().ToString();
                if (context.internos.Count() > 0)
                {
                    gridSample.DataSource = context.internos.ToList();
                    gridSample.DataBind();
                }
                else
                {
                    var obj = new List<interno>();
                    obj.Add(new interno());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridSample.DataSource = obj;
                    gridSample.DataBind();
                    int columnsCount = gridSample.Columns.Count;
                    gridSample.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridSample.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridSample.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridSample.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridSample.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridSample.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridSample.Rows[0].Cells[0].Text = "No hay registros";
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
                GridViewRow row = gridSample.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                TextBox txb5 = row.FindControl("txbNew5") as TextBox;
                TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                TextBox txb7 = row.FindControl("txbNew7") as TextBox;
                TextBox txb8 = row.FindControl("txbNew8") as TextBox;
                if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb5 != null && txb6 != null && txb7 != null && txb8 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        interno obj = new interno();
                        obj.Apellidos = txb1.Text;
                        obj.Nombres= txb2.Text;
                        obj.Fecha_nacimiento = DateTime.Parse(txb3.Text);
                        obj.CI = txb4.Text;
                        obj.Fecha_ingreso = DateTime.Parse(txb5.Text);
                        obj.Fecha_egreso = DateTime.Parse(txb6.Text);
                        obj.Cargo = txb7.Text;
                        obj.Comentarios = txb8.Text;

                        context.internos.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
        }

        protected void gridSample_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridSample.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridSample_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridSample.EditIndex = -1;
            BindGrid();
        }
        protected void gridSample_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridSample.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            TextBox txb5 = row.FindControl("txb5") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            TextBox txb8 = row.FindControl("txb8") as TextBox;
            if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb5 != null && txb6 != null && txb7 != null && txb8 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int interno_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
                    interno obj = context.internos.First(x => x.Interno_ID == interno_ID);
                    obj.Apellidos = txb1.Text;
                    obj.Nombres = txb2.Text;
                    obj.Fecha_nacimiento = DateTime.Parse(txb3.Text);
                    obj.CI = txb4.Text;
                    obj.Fecha_ingreso = DateTime.Parse(txb5.Text);
                    obj.Fecha_egreso = DateTime.Parse(txb6.Text);
                    obj.Cargo = txb7.Text;
                    obj.Comentarios = txb8.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridSample.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int interno_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                interno obj = context.internos.First(x => x.Interno_ID == interno_ID);
                context.internos.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

    }
}