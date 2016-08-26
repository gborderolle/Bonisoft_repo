using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Cuadrillas_descarga : System.Web.UI.Page
    {
        // http://techbrij.com/insert-update-delete-gridview-entity-framework

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
                if (context.cuadrilla_descarga.Count() > 0)
                {
                    gridSample.DataSource = context.cuadrilla_descarga.ToList();
                    gridSample.DataBind();
                }
                else
                {
                    var obj = new List<cuadrilla_descarga>();
                    obj.Add(new cuadrilla_descarga());
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
            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlCategoryNew") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlCategory") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    ddl.DataSource = context.cuadrilla_descarga;
                    ddl.DataTextField = "Name";
                    ddl.DataValueField = "CategoryID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem(""));
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((cuadrilla_descarga)(e.Row.DataItem)).Cuadrilla_descarga_ID.ToString();
                }
            }
        }


        protected void gridSample_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridSample.FooterRow;
                TextBox txtFirstName = row.FindControl("txtFirstNameNew") as TextBox;
                TextBox txtLastName = row.FindControl("txtLastNameNew") as TextBox;
                TextBox txtEmail = row.FindControl("txtEmailNew") as TextBox;
                if (txtFirstName != null && txtLastName != null && txtEmail != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        cuadrilla_descarga obj = new cuadrilla_descarga();
                        obj.Empresa_ID = int.Parse(txtFirstName.Text);
                        obj.Comentarios = txtLastName.Text;
                        context.cuadrilla_descarga.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Added successfully.";
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
            TextBox txtFirstName = row.FindControl("txtFirstName") as TextBox;
            TextBox txtLastName = row.FindControl("txtLastName") as TextBox;
            TextBox txtEmail = row.FindControl("txtEmail") as TextBox;
            if (txtFirstName != null && txtLastName != null && txtEmail != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int Cuadrilla_descarga_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
                    cuadrilla_descarga obj = context.cuadrilla_descarga.First(x => x.Cuadrilla_descarga_ID == Cuadrilla_descarga_ID);
                    obj.Empresa_ID = int.Parse(txtFirstName.Text);
                    obj.Comentarios = txtLastName.Text;
                    context.SaveChanges();
                    lblMessage.Text = "Saved successfully.";
                    gridSample.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Cuadrilla_descarga_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                cuadrilla_descarga obj = context.cuadrilla_descarga.First(x => x.Cuadrilla_descarga_ID == Cuadrilla_descarga_ID);
                context.cuadrilla_descarga.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Deleted successfully.";
            }
        }

    }
}