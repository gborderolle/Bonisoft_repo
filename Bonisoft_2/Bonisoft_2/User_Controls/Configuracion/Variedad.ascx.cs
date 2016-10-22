using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls.Configuracion
{
    public partial class Variedad : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridVariedades.UseAccessibleHeader = true;
            gridVariedades.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnVariedadCount.Value = context.variedad.Count().ToString();
                if (context.variedad.Count() > 0)
                {
                    gridVariedades.DataSource = context.variedad.ToList();
                    gridVariedades.DataBind();
                }
                else
                {
                    var obj = new List<variedad>();
                    obj.Add(new variedad());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridVariedades.DataSource = obj;
                    gridVariedades.DataBind();
                    int columnsCount = gridVariedades.Columns.Count;
                    gridVariedades.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridVariedades.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridVariedades.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridVariedades.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridVariedades.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridVariedades.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridVariedades.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridVariedades_RowDataBound(object sender, GridViewRowEventArgs e)
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

            #region DDL Options 

            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlTipo1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlTipo2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.lena_tipo.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Tipo";
                    ddl.DataValueField = "Lena_tipo_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));
                }
            }

            #endregion

            #region DDL Default values

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl3") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        variedad variedad = (variedad)(e.Row.DataItem);
                        if (variedad != null)
                        {
                            int id = variedad.Lena_tipo_ID;
                            lena_tipo lena_tipo = (lena_tipo)context.lena_tipo.FirstOrDefault(c => c.Lena_tipo_ID == id);
                            if (lena_tipo != null)
                            {
                                string nombre = lena_tipo.Tipo;
                                lbl.Text = nombre;
                                lbl.CommandArgument = "tipos," + nombre;
                            }
                        }
                    }
                }
            }

            #endregion DDL Default values

        }

        protected void gridVariedades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
int lineNumber = stackFrame.GetFileLineNumber();

            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridVariedades.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                DropDownList ddlTipo2 = row.FindControl("ddlTipo2") as DropDownList;
                if (txb1 != null && txb2 != null && ddlTipo2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        variedad obj = new variedad();
                        obj.Nombre = txb1.Text;
                        obj.Comentarios = txb2.Text;

                        #region DDL logic

                        int ddl = 0;
                        if (!int.TryParse(ddlTipo2.SelectedValue, out ddl))
                        {
                            ddl = 0;
                        }
                        obj.Lena_tipo_ID = ddl;

                        #endregion

                        context.variedad.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
try 
{
                        int id = 1;
                        variedad variedad1 = (variedad)context.variedad.OrderByDescending(p => p.Variedad_ID).FirstOrDefault();
                        if (variedad1 != null)
                        {
                            id = variedad1.Variedad_ID;
                        }

                        string userID1 = HttpContext.Current.Session["UserID"].ToString();
                        string username = HttpContext.Current.Session["UserName"].ToString();
                        Global_Objects.Logs.AddUserLog("Agrega variedad", variedad1.GetType().Name + ": " + id, userID1, username);
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
            else if (e.CommandName == "View")
            {
                string[] values = e.CommandArgument.ToString().Split(new char[] { ',' });
                if (values.Length > 1)
                {
                    string tabla = values[0];
                    string dato = values[1];
                    if (!string.IsNullOrWhiteSpace(tabla) && !string.IsNullOrWhiteSpace(dato))
                    {
                        Response.Redirect("Listados.aspx?tabla=" + tabla + "&dato=" + dato);
                    }
                }
            }
        }

        protected void gridVariedades_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridVariedades.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridVariedades_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridVariedades.EditIndex = -1;
            BindGrid();
        }
        protected void gridVariedades_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
int lineNumber = stackFrame.GetFileLineNumber();

            GridViewRow row = gridVariedades.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            DropDownList ddlTipo2 = row.FindControl("ddlTipo1") as DropDownList;
            if (txb1 != null && txb2 != null && ddlTipo2 !=null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int variedad_ID = Convert.ToInt32(gridVariedades.DataKeys[e.RowIndex].Value);
                    variedad obj = context.variedad.First(x => x.Variedad_ID == variedad_ID);
                    obj.Nombre = txb1.Text;
                    obj.Comentarios = txb2.Text;

                    #region DDL logic

                    int ddl1 = obj.Lena_tipo_ID;
                    if (!int.TryParse(ddlTipo2.SelectedValue, out ddl1))
                    {
                        ddl1 = obj.Lena_tipo_ID;
                    }
                    obj.Lena_tipo_ID = ddl1;

                    #endregion

                    context.SaveChanges();

                    #region Guardar log 
try 
{
                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Global_Objects.Logs.AddUserLog("Modifica variedad", obj.GetType().Name + ": " +obj.Variedad_ID, userID1, username);
                    }
                    catch (Exception ex)
                    {
                        Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", lineNumber, className, methodName, ex.Message);
                    }
                    #endregion

                    lblMessage.Text = "Guardado correctamente.";
                    gridVariedades.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridVariedades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
int lineNumber = stackFrame.GetFileLineNumber();

            int variedad_ID = Convert.ToInt32(gridVariedades.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                variedad obj = context.variedad.First(x => x.Variedad_ID == variedad_ID);
                context.variedad.Remove(obj);
                context.SaveChanges();

                #region Guardar log 
try 
{
                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                string username = HttpContext.Current.Session["UserName"].ToString();
                Global_Objects.Logs.AddUserLog("Borra variedad", obj.GetType().Name + ": " +obj.Variedad_ID, userID1, username);
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
            GridViewRow pagerRow = gridVariedades.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridVariedades.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }
    }
}