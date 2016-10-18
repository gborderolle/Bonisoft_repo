using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls.Configuracion
{
    public partial class Usuarios : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridUsuarios.UseAccessibleHeader = true;
            gridUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnUsuarioCount.Value = context.usuarios.Count().ToString();
                if (context.usuarios.Count() > 0)
                {
                    gridUsuarios.DataSource = context.usuarios.ToList();
                    gridUsuarios.DataBind();
                }
                else
                {
                    var obj = new List<usuario>();
                    obj.Add(new usuario());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridUsuarios.DataSource = obj;
                    gridUsuarios.DataBind();
                    int columnsCount = gridUsuarios.Columns.Count;
                    gridUsuarios.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridUsuarios.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridUsuarios.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridUsuarios.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridUsuarios.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridUsuarios.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridUsuarios.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gridUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridUsuarios.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                CheckBox chk = row.FindControl("chkNew") as CheckBox;
                if (txb1 != null && txb2 != null && chk != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        usuario obj = new usuario();
                        obj.Usuario1 = txb1.Text;
                        obj.Clave = txb2.Text;
                        obj.EsAdmin = chk.Checked;

                        context.usuarios.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
try 
{
                        int id = 1;
                        usuario usuario1 = (usuario)context.usuarios.OrderByDescending(p => p.Usuario_ID).FirstOrDefault();
                        if (usuario1 != null)
                        {
                            id = usuario1.Usuario_ID;
                        }

                        string userID1 = HttpContext.Current.Session["UserID"].ToString();
                        string username = HttpContext.Current.Session["UserName"].ToString();
                        Global_Objects.Logs.AddUserLog("Agrega variedad", id, userID1, username);
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

        }

        protected void gridUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridUsuarios.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridUsuarios.EditIndex = -1;
            BindGrid();
        }
        protected void gridUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            GridViewRow row = gridUsuarios.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            CheckBox chk = row.FindControl("chk1") as CheckBox;
            if (txb1 != null && txb2 != null && chk != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int Usuario_ID = Convert.ToInt32(gridUsuarios.DataKeys[e.RowIndex].Value);
                    usuario obj = context.usuarios.First(x => x.Usuario_ID == Usuario_ID);
                    obj.Usuario1 = txb1.Text;
                    obj.Clave = txb2.Text;
                    obj.EsAdmin = chk.Checked;

                    context.SaveChanges();

                    #region Guardar log 
try 
{
                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Global_Objects.Logs.AddUserLog("Modifica usuario", obj.Usuario_ID, userID1, username);
                    }
                    catch (Exception ex)
                    {
                        Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                    }
                    #endregion

                    lblMessage.Text = "Guardado correctamente.";
                    gridUsuarios.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            int Usuario_ID = Convert.ToInt32(gridUsuarios.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                usuario obj = context.usuarios.First(x => x.Usuario_ID == Usuario_ID);
                context.usuarios.Remove(obj);
                context.SaveChanges();

                #region Guardar log 
try 
{
                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                string username = HttpContext.Current.Session["UserName"].ToString();
                Global_Objects.Logs.AddUserLog("Borra usuario", obj.Usuario_ID, userID1, username);
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
            GridViewRow pagerRow = gridUsuarios.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridUsuarios.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }



    }
}
