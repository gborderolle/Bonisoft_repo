using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Choferes : System.Web.UI.Page
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
                if (context.choferes.Count() > 0)
                {
                    gridSample.DataSource = context.choferes.ToList();
                    gridSample.DataBind();
                }
                else
                {
                    var obj = new List<chofer>();
                    obj.Add(new chofer());
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
                    gridSample.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
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
                if (txb1 != null && txb2 != null && txb3 != null && txb4 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        chofer obj = new chofer();
                        obj.Apellidos = txb1.Text;
                        obj.Nombres= txb2.Text;
                        obj.Empresa_pertenece_ID= int.Parse(txb3.Text);
                        obj.Comentarios = txb4.Text;

                        context.choferes.Add(obj);
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
            TextBox txb1 = row.FindControl("txbNew1") as TextBox;
            TextBox txb2 = row.FindControl("txbNew2") as TextBox;
            TextBox txb3 = row.FindControl("txbNew3") as TextBox;
            TextBox txb4 = row.FindControl("txbNew4") as TextBox;
            if (txb1 != null && txb2 != null && txb3 != null && txb4 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int chofer_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
                    chofer obj = context.choferes.First(x => x.Chofer_ID == chofer_ID);
                    obj.Apellidos = txb1.Text;
                    obj.Nombres = txb2.Text;
                    obj.Empresa_pertenece_ID = int.Parse(txb3.Text);
                    obj.Comentarios = txb4.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridSample.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int chofer_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                chofer obj = context.choferes.First(x => x.Chofer_ID == chofer_ID);
                context.choferes.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

    }
}