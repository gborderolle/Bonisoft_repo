using Bonisoft_2.Models;
using System;
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
            gridCargadores.UseAccessibleHeader = true;
            gridCargadores.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGrid()
        {
            using (bonisoftEntities context = new bonisoftEntities())
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridCargadores_RowDataBound(object sender, GridViewRowEventArgs e)
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


        protected void gridCargadores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Logger variables
System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                        System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;


            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridCargadores.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                if (txb1 != null && txb2 != null && txb3 != null && txb4 != null)
                {
                    using (bonisoftEntities context = new bonisoftEntities())
                    {
                        cargador obj = new cargador();
                        obj.Nombre = txb1.Text;
                        obj.Comentarios = txb2.Text;
                        obj.Direccion = txb3.Text;
                        obj.Telefono = txb4.Text;

                        context.cargadores.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
try 
{
                        int id = 1;
                        cargador cargador = (cargador)context.cargadores.OrderByDescending(p => p.Cargador_ID).FirstOrDefault();
                        if (cargador != null)
                        {
                            id = cargador.Cargador_ID;
                        }

                        string userID1 = HttpContext.Current.Session["UserID"].ToString();
                        string username = HttpContext.Current.Session["UserName"].ToString();
                        Global_Objects.Logs.AddUserLog("Agrega cargador", cargador.GetType().Name + ": " + id, userID1, username);
                        }
                        catch (Exception ex)
                        {
                            Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
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
            // Logger variables
System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                        System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;


            GridViewRow row = gridCargadores.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            if (txb1 != null && txb2 != null && txb3 != null && txb4 != null)
            {
                using (bonisoftEntities context = new bonisoftEntities())
                {
                    int cargador_ID = Convert.ToInt32(gridCargadores.DataKeys[e.RowIndex].Value);
                    cargador obj = context.cargadores.First(x => x.Cargador_ID == cargador_ID);
                    obj.Nombre = txb1.Text;
                    obj.Comentarios = txb2.Text;
                    obj.Direccion = txb3.Text;
                    obj.Telefono = txb4.Text;

                    context.SaveChanges();

                    #region Guardar log 
try 
{
                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Global_Objects.Logs.AddUserLog("Modifica cargador", obj.GetType().Name + ": " +obj.Cargador_ID, userID1, username);
                    }
                    catch (Exception ex)
                    {
                        Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                    }
                    #endregion

                    lblMessage.Text = "Guardado correctamente.";
                    gridCargadores.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridCargadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Logger variables
System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                        System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;


            int cargador_ID = Convert.ToInt32(gridCargadores.DataKeys[e.RowIndex].Value);
            using (bonisoftEntities context = new bonisoftEntities())
            {
                cargador obj = context.cargadores.First(x => x.Cargador_ID == cargador_ID);
                context.cargadores.Remove(obj);
                context.SaveChanges();

                #region Guardar log 
try 
{
                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                string username = HttpContext.Current.Session["UserName"].ToString();
                Global_Objects.Logs.AddUserLog("Borra cargador", obj.GetType().Name + ": " +obj.Cargador_ID, userID1, username);
                }
                catch (Exception ex)
                {
                    Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                }
                #endregion

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