using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.User_Controls
{
    public partial class Proveedores : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridProveedores.UseAccessibleHeader = true;
            gridProveedores.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                hdnProveedoresCount.Value = context.proveedores.Count().ToString();
                if (context.proveedores.Count() > 0)
                {
                    gridProveedores.DataSource = context.proveedores.ToList();
                    gridProveedores.DataBind();
                }
                else
                {
                    var obj = new List<proveedor>();
                    obj.Add(new proveedor());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridProveedores.DataSource = obj;
                    gridProveedores.DataBind();
                    int columnsCount = gridProveedores.Columns.Count;
                    gridProveedores.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridProveedores.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridProveedores.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridProveedores.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridProveedores.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridProveedores.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridProveedores.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridProveedores_RowDataBound(object sender, GridViewRowEventArgs e)
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


        protected void gridProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridProveedores.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                TextBox txb5 = row.FindControl("txbNew5") as TextBox;
                TextBox txb10 = row.FindControl("txbNew10") as TextBox;
                if (txb1 != null && txb3 != null && txb4 != null && txb5 != null && txb10 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        proveedor obj = new proveedor();
                        obj.Nombre = txb1.Text;
                        obj.RUT = txb3.Text;
                        obj.Direccion = txb4.Text;
                        obj.Telefono = txb5.Text;
                        obj.Comentarios = txb10.Text;

                        context.proveedores.Add(obj);
                        context.SaveChanges();

                        #region Guardar log 
                        try
                        {
                            int id = 1;
                            proveedor proveedor = (proveedor)context.proveedores.OrderByDescending(p => p.Proveedor_ID).FirstOrDefault();
                            if (proveedor != null)
                            {
                                id = proveedor.Proveedor_ID;
                            }

                            string userID1 = HttpContext.Current.Session["UserID"].ToString();
                            string username = HttpContext.Current.Session["UserName"].ToString();
                            Global_Objects.Logs.AddUserLog("Agrega proveedor", proveedor.GetType().Name + ": " + id, userID1, username);
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

        protected void gridProveedores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridProveedores.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridProveedores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridProveedores.EditIndex = -1;
            BindGrid();
        }
        protected void gridProveedores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            GridViewRow row = gridProveedores.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            TextBox txb5 = row.FindControl("txb5") as TextBox;
            TextBox txb10 = row.FindControl("txb10") as TextBox;
            if (txb1 != null && txb3 != null && txb4 != null && txb5 != null && txb10 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int proveedor_ID = Convert.ToInt32(gridProveedores.DataKeys[e.RowIndex].Value);
                    proveedor obj = context.proveedores.First(x => x.Proveedor_ID == proveedor_ID);
                    obj.Nombre = txb1.Text;
                    obj.RUT = txb3.Text;
                    obj.Direccion = txb4.Text;
                    obj.Telefono = txb5.Text;
                    obj.Comentarios = txb10.Text;

                    context.SaveChanges();

                    #region Guardar log 
                    try
                    {
                        string userID1 = HttpContext.Current.Session["UserID"].ToString();
                        string username = HttpContext.Current.Session["UserName"].ToString();
                        Global_Objects.Logs.AddUserLog("Modifica proveedor", obj.GetType().Name + ": " + obj.GetType().Name + ": " +obj.Proveedor_ID, userID1, username);
                    }
                    catch (Exception ex)
                    {
                        Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                    }
                    #endregion


                    lblMessage.Text = "Guardado correctamente.";
                    gridProveedores.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            int proveedor_ID = Convert.ToInt32(gridProveedores.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                proveedor obj = context.proveedores.First(x => x.Proveedor_ID == proveedor_ID);
                context.proveedores.Remove(obj);
                context.SaveChanges();

                #region Guardar log 
                try
                {
                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Global_Objects.Logs.AddUserLog("Borra proveedor", obj.GetType().Name + ": " +obj.Proveedor_ID, userID1, username);
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
            GridViewRow pagerRow = gridProveedores.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridProveedores.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

    }
}