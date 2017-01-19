using Bonisoft_2.Models;
using Bonisoft_2.Global_Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        private void BindGridLogs(string date_start = "", string date_end = "")
        {
            using (bonisoftEntities context = new bonisoftEntities())
            {
                // Logger variables
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
                string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                string methodName = stackFrame.GetMethod().Name;

                bool isResult = false;

                if (!string.IsNullOrWhiteSpace(date_start) && !string.IsNullOrWhiteSpace(date_end))
                {

                    DateTime date1 = DateTime.Now;
                    if (!DateTime.TryParseExact(date_start, GlobalVariables.ShortDateTime_format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
                    {
                        date1 = DateTime.Now;
                        Logs.AddErrorLog("Excepcion. Convirtiendo datetime. ERROR:", className, methodName, date_start);
                    }

                    DateTime date2 = DateTime.Now;
                    if (!DateTime.TryParseExact(date_end, GlobalVariables.ShortDateTime_format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date2))
                    {
                        date2 = DateTime.Now;
                        Logs.AddErrorLog("Excepcion. Convirtiendo datetime. ERROR:", className, methodName, date_end);
                    }

                    var elements = context.logs.Where(e => e.Fecha >= date1 && e.Fecha <= date2).OrderByDescending(e => e.Fecha).ToList();
                    if (elements.Count() > 0)
                    {
                        gridLogs.DataSource = elements;
                        gridLogs.DataBind();

                        isResult = true;
                    }
                }
                else
                {
                    var elements = context.logs.OrderByDescending(e => e.Fecha).ToList();
                    if (elements.Count() > 0)
                    {
                        gridLogs.DataSource = elements;
                        gridLogs.DataBind();

                        isResult = true;
                    }
                }

                if (!isResult)
                {
                    var obj = new List<log>();
                    obj.Add(new log());

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

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridLogs.PageIndex = e.NewPageIndex;
            BindGridLogs();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string date1 = txbFiltro1.Value;
            string date2 = txbFiltro2.Value;
            BindGridLogs(date1, date2);
        }
    }
}