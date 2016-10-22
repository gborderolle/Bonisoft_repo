using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls
{
    public partial class Choferes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

            lblMessage.Text = "";
            gridChoferes.UseAccessibleHeader = true;
            gridChoferes.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnChoferesCount.Value = context.choferes.Count().ToString();
                if (context.choferes.Count() > 0)
                {
                    gridChoferes.DataSource = context.choferes.ToList();
                    gridChoferes.DataBind();
                }
                else
                {
                    var obj = new List<chofer>();
                    obj.Add(new chofer());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridChoferes.DataSource = obj;
                    gridChoferes.DataBind();
                    int columnsCount = gridChoferes.Columns.Count;
                    gridChoferes.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridChoferes.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridChoferes.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridChoferes.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridChoferes.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridChoferes.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridChoferes.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridChoferes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Updatepanel triggers

            ScriptManager ScriptManager1 = ScriptManager.GetCurrent(this.Page);
            if (ScriptManager1 != null)
            {
                LinkButton lnk = null;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    lnk = e.Row.FindControl("lnkEdit") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkDelete") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkInsert") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkCancel") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }
                }
            }

            #endregion
        }

        protected void gridChoferes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
int lineNumber = stackFrame.GetFileLineNumber();

            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridChoferes.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                if (txb1 != null && txb2 != null && txb4 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        chofer obj = new chofer();
                        obj.Nombre_completo = txb1.Text;
                        obj.Empresa = txb2.Text;
                        obj.Comentarios = txb4.Text;

                        context.choferes.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
try 
{
                        int id = 1;
                        chofer chofer = (chofer)context.choferes.OrderByDescending(p => p.Chofer_ID).FirstOrDefault();
                        if (chofer != null)
                        {
                            id = chofer.Chofer_ID;
                        }

                        string userID1 = HttpContext.Current.Session["UserID"].ToString();
                        string username = HttpContext.Current.Session["UserName"].ToString();
                        Global_Objects.Logs.AddUserLog("Agrega chofer", chofer.GetType().Name + ": " + id, userID1, username);
                        }
                        catch (Exception ex)
                        {
                            Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", lineNumber, className, methodName, ex.Message);
                        }
                        #endregion

                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
            else
            {
                //BindGrid();
            }
        }

        protected void gridChoferes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridChoferes.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridChoferes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridChoferes.EditIndex = -1;
            BindGrid();
        }
        protected void gridChoferes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
int lineNumber = stackFrame.GetFileLineNumber();

            GridViewRow row = gridChoferes.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            if (txb1 != null && txb2 != null && txb4 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int chofer_ID = Convert.ToInt32(gridChoferes.DataKeys[e.RowIndex].Value);
                    chofer obj = context.choferes.First(x => x.Chofer_ID == chofer_ID);
                    obj.Nombre_completo = txb1.Text;
                    obj.Empresa = txb2.Text;
                    obj.Comentarios = txb4.Text;

                    context.SaveChanges();

                    #region Guardar log 
try 
{
                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Global_Objects.Logs.AddUserLog("Modifica chofer", obj.GetType().Name + ": " +obj.Chofer_ID, userID1, username);
                    }
                    catch (Exception ex)
                    {
                        Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", lineNumber, className, methodName, ex.Message);
                    }
                    #endregion

                    lblMessage.Text = "Guardado correctamente.";
                    gridChoferes.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridChoferes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
int lineNumber = stackFrame.GetFileLineNumber();

            int chofer_ID = Convert.ToInt32(gridChoferes.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                chofer obj = context.choferes.First(x => x.Chofer_ID == chofer_ID);
                context.choferes.Remove(obj);
                context.SaveChanges();

                #region Guardar log 
try 
{
                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                string username = HttpContext.Current.Session["UserName"].ToString();
                Global_Objects.Logs.AddUserLog("Borra chofer", obj.GetType().Name + ": " +obj.Chofer_ID, userID1, username);
                }
                catch (Exception ex)
                {
                    Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", lineNumber, className, methodName, ex.Message);
                }
                #endregion

                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridChoferes.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridChoferes.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}