using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Resumen_clientes : System.Web.UI.Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridClientes();

                gridClientes.UseAccessibleHeader = true;
                gridClientes.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            gridClientes_lblMessage.Text = string.Empty;
        }

        protected void gridClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                if (!string.IsNullOrWhiteSpace(e.CommandArgument.ToString()) && !string.IsNullOrWhiteSpace(e.CommandName))
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {

                    }
                }
            }
        }

        protected void gridClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Buttons

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }

            #endregion Buttons

            #region Labels

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }

            #endregion Labels

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridClientes, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gridViajes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridViajes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
              
            }
        }

        protected void gridClientes_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridClientes.Rows)
            {
                if (row.RowIndex == gridClientes.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");

                    string cliente_ID_str = gridClientes.SelectedRow.Cells[0].Text;
                    if (!string.IsNullOrWhiteSpace(cliente_ID_str))
                    {
                        int cliente_ID = 0;
                        if(!int.TryParse(cliente_ID_str, out cliente_ID))
                        {
                            cliente_ID = 0;
                        }

                        if(cliente_ID > 0)
                        {
                            BindGridViajes(cliente_ID);
                        }
                    }
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }

        #endregion Events

        #region General methods

        private void BindGridClientes()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var elements = context.clientes.OrderBy(e => e.Nombre).ToList();
                if (elements.Count() > 0)
                {
                    gridClientes.DataSource = elements;
                    gridClientes.DataBind();

                    lblGridClientesCount.Text = "Resultados: " + elements.Count();
                }
                else
                {
                    var obj = new List<cliente>();
                    obj.Add(new cliente());

                    // Bind the DataTable which contain a blank row to the GridView
                    gridClientes.DataSource = obj;
                    gridClientes.DataBind();
                    int columnsCount = gridClientes.Columns.Count;
                    gridClientes.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridClientes.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridClientes.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridClientes.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridClientes.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridClientes.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    gridClientes.Rows[0].Cells[0].Text = "No hay registros";
                }
            }
        }

        private void BindGridViajes(int cliente_ID)
        {
            if (cliente_ID > 0)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    var elements = context.viajes.Where(v => v.Cliente_ID == cliente_ID).ToList();
                    if (elements.Count() > 0)
                    {
                        gridViajes.DataSource = elements;
                        gridViajes.DataBind();

                        lblGridViajesCount.Text = "Resultados: " + elements.Count();
                    }
                    else
                    {
                        var obj = new List<viaje>();
                        obj.Add(new viaje());

                        /* Grid Viajes */

                        // Bind the DataTable which contain a blank row to the GridView
                        gridViajes.DataSource = obj;
                        gridViajes.DataBind();
                        int columnsCount = gridViajes.Columns.Count;
                        gridViajes.Rows[0].Cells.Clear();// clear all the cells in the row
                        gridViajes.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        gridViajes.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                        //You can set the styles here
                        gridViajes.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        gridViajes.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        gridViajes.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        gridViajes.Rows[0].Cells[0].Text = "No hay registros";
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "BindGrid", "<script type='text/javascript'>$('.datepicker').datepicker();  </script>", false);
                }
            }
        }

        #endregion General methods


    }
}