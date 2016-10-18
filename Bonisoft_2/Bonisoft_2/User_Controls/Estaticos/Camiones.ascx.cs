using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Camiones1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridCamiones.UseAccessibleHeader = true;
            gridCamiones.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnCamionesCount.Value = context.camiones.Count().ToString();
                if (context.camiones.Count() > 0)
                {
                    gridCamiones.DataSource = context.camiones.ToList();
                    gridCamiones.DataBind();
                }
                else
                {
                    var obj = new List<camion>();
                    obj.Add(new camion());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridCamiones.DataSource = obj;
                    gridCamiones.DataBind();
                    int columnsCount = gridCamiones.Columns.Count;
                    gridCamiones.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridCamiones.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridCamiones.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridCamiones.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridCamiones.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridCamiones.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridCamiones.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridCamiones_RowDataBound(object sender, GridViewRowEventArgs e)
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
                ddl = e.Row.FindControl("ddlEjes1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlEjes2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.camion_ejes.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Ejes";
                    ddl.DataValueField = "Camion_ejes_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));
                }
            }

            #endregion

            #region DDL Default values

            // Ejes ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl3") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        camion camion = (camion)(e.Row.DataItem);
                        if (camion != null)
                        {
                            int id = camion.Ejes_ID;
                            camion_ejes camion_ejes = (camion_ejes)context.camion_ejes.FirstOrDefault(c => c.Camion_ejes_ID == id);
                            if (camion_ejes != null)
                            {
                                string nombre = camion_ejes.Ejes;
                                lbl.Text = nombre;
                                lbl.CommandArgument = "ejes," + nombre;
                            }
                        }
                    }
                }
            }

            #endregion DDL Default values

        }


        protected void gridCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridCamiones.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                TextBox txb7 = row.FindControl("txbNew7") as TextBox;
                TextBox txb9 = row.FindControl("txbNew9") as TextBox;
                DropDownList ddlEjes2 = row.FindControl("ddlEjes2") as DropDownList;
                if (txb1 != null && txb2 != null && txb6 != null && txb7 != null && txb9 != null && ddlEjes2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        camion obj = new camion();
                        obj.Matricula_camion = txb1.Text;
                        obj.Matricula_zorra = txb2.Text;
                        obj.Marca = txb6.Text;
                        obj.Comentarios = txb9.Text;

                        decimal value = 0;
                        if (!decimal.TryParse(txb7.Text, out value))
                        {
                            value = 0;
                        }
                        obj.Tara = value;

                        #region DDL logic

                        int ddl1 = 0;
                        if (!int.TryParse(ddlEjes2.SelectedValue, out ddl1))
                        {
                            ddl1 = 0;
                        }
                        obj.Ejes_ID = ddl1;

                        #endregion

                        context.camiones.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
try 
{
                        int id = 1;
                        camion camion1 = (camion)context.camiones.OrderByDescending(p => p.Camion_ID).FirstOrDefault();
                        if (camion1 != null)
                        {
                            id = camion1.Camion_ID;
                        }

                        string userID1 = HttpContext.Current.Session["UserID"].ToString();
                        string username = HttpContext.Current.Session["UserName"].ToString();
                        Global_Objects.Logs.AddUserLog("Agrega camión", id, userID1, username);
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

        protected void gridCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridCamiones.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCamiones.EditIndex = -1;
            BindGrid();
        }
        protected void gridCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            GridViewRow row = gridCamiones.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            TextBox txb9 = row.FindControl("txb9") as TextBox;
            DropDownList ddlEjes2 = row.FindControl("ddlEjes1") as DropDownList;
            if (txb1 != null && txb2 != null && txb6 != null && txb7 != null && txb9 != null && ddlEjes2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int camion_ID = Convert.ToInt32(gridCamiones.DataKeys[e.RowIndex].Value);
                    camion obj = context.camiones.First(x => x.Camion_ID == camion_ID);
                    obj.Matricula_camion = txb1.Text;
                    obj.Matricula_zorra = txb2.Text;
                    obj.Marca = txb6.Text;
                    obj.Comentarios = txb9.Text;

                    decimal value = obj.Tara;
                    if (!decimal.TryParse(txb7.Text, out value))
                    {
                        value = obj.Tara;
                    }
                    obj.Tara = value;

                    #region DDL logic

                    int ddl1 = obj.Ejes_ID;
                    if (!int.TryParse(ddlEjes2.SelectedValue, out ddl1))
                    {
                        ddl1 = obj.Ejes_ID;
                    }
                    obj.Ejes_ID = ddl1;

                    #endregion

                    context.SaveChanges();

                    #region Guardar log 
try 
{
                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Global_Objects.Logs.AddUserLog("Modifica camión", obj.Camion_ID, userID1, username);
                    }
                    catch (Exception ex)
                    {
                        Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                    }
                    #endregion

                    lblMessage.Text = "Guardado correctamente.";
                    gridCamiones.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            int camion_ID = Convert.ToInt32(gridCamiones.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                camion obj = context.camiones.First(x => x.Camion_ID == camion_ID);
                context.camiones.Remove(obj);
                context.SaveChanges();

                #region Guardar log 
try 
{
                string userID1 = HttpContext.Current.Session["UserID"].ToString();
                string username = HttpContext.Current.Session["UserName"].ToString();
                Global_Objects.Logs.AddUserLog("Borra camión", obj.Camion_ID, userID1, username);
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
            GridViewRow pagerRow = gridCamiones.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridCamiones.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}