using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls.Estaticos
{
    public partial class Procesadores : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridProcesadores.UseAccessibleHeader = true;
            gridProcesadores.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnProcesadoresCount.Value = context.procesadores.Count().ToString();
                if (context.procesadores.Count() > 0)
                {
                    gridProcesadores.DataSource = context.procesadores.ToList();
                    gridProcesadores.DataBind();
                }
                else
                {
                    var obj = new List<procesador>();
                    obj.Add(new procesador());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridProcesadores.DataSource = obj;
                    gridProcesadores.DataBind();
                    int columnsCount = gridProcesadores.Columns.Count;
                    gridProcesadores.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridProcesadores.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridProcesadores.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridProcesadores.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridProcesadores.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridProcesadores.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridProcesadores.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridProcesadores_RowDataBound(object sender, GridViewRowEventArgs e)
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


        protected void gridProcesadores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Logger variables
System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                        System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;


            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridProcesadores.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                if (txb1 != null && txb2 != null && txb3 != null && txb4 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        procesador obj = new procesador();
                        obj.Nombre = txb1.Text;
                        obj.Comentarios = txb2.Text;
                        obj.Direccion = txb3.Text;
                        obj.Telefono = txb4.Text;

                        context.procesadores.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
                        try
                        {
                            int id = 1;
                            procesador procesador = (procesador)context.procesadores.OrderByDescending(p => p.Procesador_ID).FirstOrDefault();
                            if (procesador != null)
                            {
                                id = procesador.Procesador_ID;
                            }

                            string userID1 = HttpContext.Current.Session["UserID"].ToString();
                            string username = HttpContext.Current.Session["UserName"].ToString();
                            Global_Objects.Logs.AddUserLog("Agrega procesador", procesador.GetType().Name + ": " + id, userID1, username);
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

        protected void gridProcesadores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridProcesadores.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridProcesadores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridProcesadores.EditIndex = -1;
            BindGrid();
        }
        protected void gridProcesadores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Logger variables
System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                        System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;


            GridViewRow row = gridProcesadores.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            if (txb1 != null && txb2 != null && txb3 != null && txb4 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int procesador_ID = Convert.ToInt32(gridProcesadores.DataKeys[e.RowIndex].Value);
                    procesador obj = context.procesadores.First(x => x.Procesador_ID == procesador_ID);
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
                        Global_Objects.Logs.AddUserLog("Modifica procesador", obj.GetType().Name + ": " + obj.Procesador_ID, userID1, username);
                    }
                    catch (Exception ex)
                    {
                        Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                    }
                    #endregion

                    lblMessage.Text = "Guardado correctamente.";
                    gridProcesadores.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridProcesadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Logger variables
System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                        System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;


            int procesador_ID = Convert.ToInt32(gridProcesadores.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                procesador obj = context.procesadores.First(x => x.Procesador_ID == procesador_ID);
                context.procesadores.Remove(obj);
                context.SaveChanges();

                #region Guardar log 
                try
                {
                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Global_Objects.Logs.AddUserLog("Borra procesador", obj.GetType().Name + ": " + obj.Procesador_ID, userID1, username);
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
            GridViewRow pagerRow = gridProcesadores.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridProcesadores.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}