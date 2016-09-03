using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Gridview : System.Web.UI.Page
    {
        // http://blog.siinet.com/2015/11/22/asp-net-y-bootstrap-gridview/

        public int operacion;
        public int totalItemSeleccionados = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
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
        }


        protected void gridSample_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridSample.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                if (txb1 != null && txb2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        cuadrilla_descarga obj = new cuadrilla_descarga();
                        obj.Empresa_ID = int.Parse(txb1.Text);
                        obj.Comentarios = txb2.Text;

                        context.cuadrilla_descarga.Add(obj);
                        context.SaveChanges();
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
            if (txb1 != null && txb2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int cuadrilla_descarga_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
                    cuadrilla_descarga obj = context.cuadrilla_descarga.First(x => x.Cuadrilla_descarga_ID == cuadrilla_descarga_ID);
                    obj.Empresa_ID = int.Parse(txb1.Text);
                    obj.Comentarios = txb2.Text;

                    context.SaveChanges();
                    gridSample.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cuadrilla_descarga_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                cuadrilla_descarga obj = context.cuadrilla_descarga.First(x => x.Cuadrilla_descarga_ID == cuadrilla_descarga_ID);
                context.cuadrilla_descarga.Remove(obj);
                context.SaveChanges();
                BindGrid();
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridSample.BottomPagerRow;
            // Recupera el control DropDownList...
            //DropDownList pageList = (DropDownList)pagerRow.Cells(0).FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            //gridSample.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblInfo.Text = "";
        }

        protected void chk_OnCheckedChanged(object sender, EventArgs e)
        {
            //Recorrer las filas del GridView...
            int i = 0;
            //Quita el mensaje de información si lo hubiera...
            lblInfo.Text = "";
            for (i = 0; i <= gridSample.Rows.Count - 1; i++)
            {
                //CheckBox CheckBoxElim = (CheckBox)gridSample.Rows(i).FindControl("chkEliminar");
                //if (CheckBoxElim.Checked)
                //{
                //    totalItemSeleccionados += 1;
                //    return;
                //}
            }
        }


    }
}