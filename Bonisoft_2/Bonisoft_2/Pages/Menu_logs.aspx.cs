using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Menu_logs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridLogs();
            }

            gridLogs.UseAccessibleHeader = true;
            gridLogs.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGridLogs()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var elements = context.logs.OrderByDescending(e => e.Fecha).ToList();
                if (elements.Count() > 0)
                {
                    gridLogs.DataSource = elements;
                    gridLogs.DataBind();
                }
                else
                {
                    var obj = new List<viaje>();
                    obj.Add(new viaje());

                    /* Grid Viajes */

                    // Bind the DataTable which contain a blank row to the GridView
                    gridLogs.DataSource = obj;
                    gridLogs.DataBind();
                    int columnsCount = gridLogs.Columns.Count;
                    gridLogs.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridLogs.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridLogs.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridLogs.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridLogs.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridLogs.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    gridLogs.Rows[0].Cells[0].Text = "No hay registros";
                }

                gridLogs.UseAccessibleHeader = true;
                gridLogs.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridLogs.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridLogs.PageIndex = pageList.SelectedIndex;
            // Quita el mensaje de información si lo hubiera...
            gridLogs_lblMessage.Text = string.Empty;
        }

    }
}