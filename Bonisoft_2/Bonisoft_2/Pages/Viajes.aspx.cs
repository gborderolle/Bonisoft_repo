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
    public partial class Viajes : System.Web.UI.Page
    {
        // http://www.programming-free.com/2013/09/gridview-crud-bootstrap-modal-popup.html

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();

                BindGrid_EnCurso();

                BindModals();
            }
            lblMessage.Text = string.Empty;
        }

        private void BindModals()
        {
            BindAdd();
        }

        private void BindAdd()
        {
            #region AddModal Fill DDLs

            // Proveedores --------------------------------------------------
            if (modalAdd_ddlProveedores != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.proveedores.ToList());

                    modalAdd_ddlProveedores.DataSource = dt1;
                    modalAdd_ddlProveedores.DataTextField = "Nombre";
                    modalAdd_ddlProveedores.DataValueField = "Proveedor_ID";
                    modalAdd_ddlProveedores.DataBind();
                    modalAdd_ddlProveedores.Items.Insert(0, new ListItem("Elegir"));

                }
            }

            // Clientes --------------------------------------------------
            if (modalAdd_ddlClientes != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.clientes.ToList());

                    modalAdd_ddlClientes.DataSource = dt1;
                    modalAdd_ddlClientes.DataTextField = "Nombre";
                    modalAdd_ddlClientes.DataValueField = "Cliente_ID";
                    modalAdd_ddlClientes.DataBind();
                    modalAdd_ddlClientes.Items.Insert(0, new ListItem("Elegir"));

                }
            }

            // Empresas de carga --------------------------------------------------
            if (modalAdd_ddlEmpresaCarga != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.cargadores.ToList());

                    modalAdd_ddlEmpresaCarga.DataSource = dt1;
                    modalAdd_ddlEmpresaCarga.DataTextField = "Nombre";
                    modalAdd_ddlEmpresaCarga.DataValueField = "Cargador_ID";
                    modalAdd_ddlEmpresaCarga.DataBind();
                    modalAdd_ddlEmpresaCarga.Items.Insert(0, new ListItem("Elegir"));

                }
            }

            // Fleteros --------------------------------------------------
            if (modalAdd_ddlFleteros != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.fleteros.ToList());

                    modalAdd_ddlFleteros.DataSource = dt1;
                    modalAdd_ddlFleteros.DataTextField = "Nombre";
                    modalAdd_ddlFleteros.DataValueField = "Fletero_ID";
                    modalAdd_ddlFleteros.DataBind();
                    modalAdd_ddlFleteros.Items.Insert(0, new ListItem("Elegir"));

                }
            }

            // Camiones --------------------------------------------------
            if (modalAdd_ddlCamiones != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.camiones.ToList());

                    modalAdd_ddlCamiones.DataSource = dt1;
                    modalAdd_ddlCamiones.DataTextField = "Matricula_camion";
                    modalAdd_ddlCamiones.DataValueField = "Camion_ID";
                    modalAdd_ddlCamiones.DataBind();
                    modalAdd_ddlCamiones.Items.Insert(0, new ListItem("Elegir"));

                }
            }

            // Choferes --------------------------------------------------
            if (modalAdd_ddlChoferes != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.choferes.ToList());

                    modalAdd_ddlChoferes.DataSource = dt1;
                    modalAdd_ddlChoferes.DataTextField = "Nombre_completo";
                    modalAdd_ddlChoferes.DataValueField = "Chofer_ID";
                    modalAdd_ddlChoferes.DataBind();
                    modalAdd_ddlChoferes.Items.Insert(0, new ListItem("Elegir"));

                }
            }

            #endregion
        }

        void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var elements = context.viajes.Where(e => e.EnViaje == false).ToList();
                if (elements.Count() > 0)
                {
                    gridViajes.DataSource = context.viajes.ToList();
                    gridViajes.DataBind();
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
            }
        }

        protected void gridViajes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Fill DDLs 

            // Camiones --------------------------------------------------
            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlCamiones1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlCamiones2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.camiones.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Matricula_camion";
                    ddl.DataValueField = "Camion_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Empresa_de_carga_ID.ToString();
                }
            }

            // Choferes --------------------------------------------------
            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlChoferes1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlChoferes2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.choferes.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre_completo";
                    ddl.DataValueField = "Chofer_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Empresa_de_carga_ID.ToString();
                }
            }

            // Formas de pago --------------------------------------------------
            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlFormas1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlFormas2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.forma_de_pago.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Forma";
                    ddl.DataValueField = "Forma_de_pago_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Empresa_de_carga_ID.ToString();
                }
            }

            // Empresas de carga --------------------------------------------------
            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlCargadores1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlCargadores2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.cargadores.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre";
                    ddl.DataValueField = "Cargador_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Empresa_de_carga_ID.ToString();
                }
            }

            // Fleteros --------------------------------------------------
            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlFleteros1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlFleteros2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.fleteros.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre";
                    ddl.DataValueField = "Fletero_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Fletero_ID.ToString();
                }
            }

            // Proveedores --------------------------------------------------
            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlProveedores1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlProveedores2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.proveedores.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre";
                    ddl.DataValueField = "Proveedor_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Proveedor_ID.ToString();
                }
            }

            // Clientes --------------------------------------------------
            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlClientes1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlClientes2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.clientes.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre";
                    ddl.DataValueField = "Cliente_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Cliente_ID.ToString();
                }
            }

            // Cargadores --------------------------------------------------
            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlCargadores1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlCargadores2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.cargadores.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre";
                    ddl.DataValueField = "Cargador_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Empresa_de_carga_ID.ToString();
                }
            }

            // Pesadas origen --------------------------------------------------
            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlPesadaOrigen1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlPesadaOrigen2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.pesadas.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre_balanza";
                    ddl.DataValueField = "Pesada_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Pesada_origen_ID.ToString();
                }
            }

            // Pesadas destino --------------------------------------------------
            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlPesadaDestino1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlPesadaDestino2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.pesadas.ToList());

                    ddl.DataSource = dt1;
                    ddl.DataTextField = "Nombre_balanza";
                    ddl.DataValueField = "Pesada_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Pesada_destino_ID.ToString();
                }
            }

            #endregion

            #region DDL Default values

            // Forma de pago ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl5") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Forma_de_pago_ID;
                            forma_de_pago forma_de_pago = (forma_de_pago)context.forma_de_pago.FirstOrDefault(c => c.Forma_de_pago_ID == id);
                            if (forma_de_pago != null)
                            {
                                string nombre = forma_de_pago.Forma;
                                lbl.Text = nombre;
                                lbl.CommandArgument = "formas," + forma_de_pago.Forma;
                            }
                        }
                    }
                }
            }

            // Empresa de carga ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl10") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Empresa_de_carga_ID;
                            cargador cargador = (cargador)context.cargadores.FirstOrDefault(c => c.Cargador_ID == id);
                            if (cargador != null)
                            {
                                string nombre = cargador.ToString();
                                lbl.Text = nombre;
                                lbl.CommandArgument = "cargadores," + cargador.Nombre;
                            }
                        }
                    }
                }
            }

            // Fleteros ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl16") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Fletero_ID;
                            fletero fletero = (fletero)context.fleteros.FirstOrDefault(c => c.Fletero_ID == id);
                            if (fletero != null)
                            {
                                string nombre = fletero.ToString();
                                lbl.Text = nombre;
                                lbl.CommandArgument = "fleteros," + fletero.Nombre;
                            }
                        }
                    }
                }
            }

            // Camion ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl13") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Camion_ID;
                            camion camion = (camion)context.camiones.FirstOrDefault(c => c.Camion_ID == id);
                            if (camion != null)
                            {
                                string nombre = camion.ToString();
                                lbl.Text = nombre;
                                lbl.CommandArgument = "camiones," + camion.Marca;
                            }
                        }
                    }
                }
            }

            // Chofer ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl14") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Chofer_ID;
                            chofer chofer = (chofer)context.choferes.FirstOrDefault(c => c.Chofer_ID == id);
                            if (chofer != null)
                            {
                                string nombre = chofer.ToString();
                                lbl.Text = nombre;
                                lbl.CommandArgument = "choferes," + chofer.Nombre_completo;
                            }
                        }
                    }
                }
            }

            // Proveedor ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl17") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Proveedor_ID;
                            proveedor proveedor = (proveedor)context.proveedores.FirstOrDefault(c => c.Proveedor_ID == id);
                            if (proveedor != null)
                            {
                                string nombre = proveedor.ToString();
                                lbl.Text = nombre;
                                lbl.CommandArgument = "proveedores," + proveedor.Nombre;
                            }
                        }
                    }
                }
            }

            // Cliente ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl18") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Cliente_ID;
                            cliente cliente = (cliente)context.clientes.FirstOrDefault(c => c.cliente_ID == id);
                            if (cliente != null)
                            {
                                string nombre = cliente.ToString();
                                lbl.Text = nombre;
                                lbl.CommandArgument = "clientes," + cliente.Nombre;
                            }
                        }
                    }
                }
            }

            // Cargador ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl10") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Empresa_de_carga_ID;
                            cargador cargador = (cargador)context.cargadores.FirstOrDefault(c => c.Cargador_ID == id);
                            if (cargador != null)
                            {
                                string nombre = cargador.Nombre;
                                lbl.Text = nombre;
                                lbl.CommandArgument = "cargadores," + cargador.Nombre;
                            }
                        }
                    }
                }
            }

            // Pesada origen ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl8") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Pesada_origen_ID;
                            pesada pesada = (pesada)context.pesadas.FirstOrDefault(c => c.pesada_ID == id);
                            if (pesada != null)
                            {
                                string nombre = pesada.ToString();
                                lbl.Text = nombre;
                                lbl.CommandArgument = "pesadas," + pesada.Nombre_balanza;
                            }
                        }
                    }
                }
            }

            // Pesada destino ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbl = e.Row.FindControl("lbl9") as LinkButton;
                if (lbl != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje viaje = (viaje)(e.Row.DataItem);
                        if (viaje != null)
                        {
                            int id = viaje.Pesada_destino_ID;
                            pesada pesada = (pesada)context.pesadas.FirstOrDefault(c => c.pesada_ID == id);
                            if (pesada != null)
                            {
                                string nombre = pesada.ToString();
                                lbl.Text = nombre;
                                lbl.CommandArgument = "pesadas," + pesada.Nombre_balanza;
                            }
                        }
                    }
                }
            }

            #endregion


        }

        protected void gridViajes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                if (!string.IsNullOrWhiteSpace(e.CommandArgument.ToString()) && !string.IsNullOrWhiteSpace(e.CommandName))
                {
                    #region InsertNew

                    if (e.CommandName == "InsertNew")
                    {
                        int index = Convert.ToInt32(e.CommandArgument);

                        GridViewRow row = gridViajes.FooterRow;
                        TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                        TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                        TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                        TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                        TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                        TextBox txb7 = row.FindControl("txbNew7") as TextBox;
                        TextBox txb11 = row.FindControl("txbNew11") as TextBox;
                        TextBox txb12 = row.FindControl("txbNew12") as TextBox;
                        TextBox txb15 = row.FindControl("txbNew15") as TextBox;
                        DropDownList ddlFormas2 = row.FindControl("ddlFormas2") as DropDownList;
                        DropDownList ddlCargadores2 = row.FindControl("ddlCargadores2") as DropDownList;
                        DropDownList ddlCamiones2 = row.FindControl("ddlCamiones2") as DropDownList;
                        DropDownList ddlChoferes2 = row.FindControl("ddlChoferes2") as DropDownList;
                        DropDownList ddlFleteros2 = row.FindControl("ddlFleteros2") as DropDownList;
                        DropDownList ddlProveedores2 = row.FindControl("ddlProveedores2") as DropDownList;
                        DropDownList ddlClientes2 = row.FindControl("ddlClientes2") as DropDownList;
                        DropDownList ddlPesadaOrigen2 = row.FindControl("ddlPesadaOrigen2") as DropDownList;
                        DropDownList ddlPesadaDestino2 = row.FindControl("ddlPesadaDestino2") as DropDownList;

                        if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb6 != null && txb7 != null && ddlChoferes2 != null && txb15 != null &&
                            ddlPesadaOrigen2 != null && txb11 != null && txb12 != null && txb3 != null && ddlCargadores2 != null && ddlCamiones2 != null &&
                            ddlPesadaDestino2 != null && ddlFleteros2 != null && ddlProveedores2 != null && ddlClientes2 != null)
                        {
                            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                            {
                                viaje obj = new viaje();
                                obj.Precio_compra_por_tonelada = decimal.Parse(txb1.Text);
                                obj.Precio_valor_total = decimal.Parse(txb2.Text);
                                obj.Importe_viaje = decimal.Parse(txb3.Text);
                                obj.Saldo = decimal.Parse(txb4.Text);
                                obj.Carga = txb6.Text;
                                obj.Descarga = txb7.Text;
                                obj.Comentarios = txb15.Text;

                                DateTime date1 = DateTime.Now;
                                if (!DateTime.TryParseExact(txb11.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                                {
                                    date1 = DateTime.Now;
                                }
                                obj.Fecha_partida = date1;

                                DateTime date2 = DateTime.Now;
                                if (!DateTime.TryParseExact(txb12.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date2))
                                {
                                    date2 = DateTime.Now;
                                }
                                obj.Fecha_llegada = date2;

                                #region DDL logic

                                int ddl = 0;
                                if (!int.TryParse(ddlCargadores2.SelectedValue, out ddl))
                                {
                                    ddl = 0;
                                }
                                obj.Empresa_de_carga_ID = ddl;

                                ddl = 0;
                                if (!int.TryParse(ddlCamiones2.SelectedValue, out ddl))
                                {
                                    ddl = 0;
                                }
                                obj.Camion_ID = ddl;

                                ddl = 0;
                                if (!int.TryParse(ddlChoferes2.SelectedValue, out ddl))
                                {
                                    ddl = 0;
                                }
                                obj.Chofer_ID = ddl;

                                ddl = 0;
                                if (!int.TryParse(ddlFormas2.SelectedValue, out ddl))
                                {
                                    ddl = 0;
                                }
                                obj.Forma_de_pago_ID = ddl;

                                ddl = 0;
                                if (!int.TryParse(ddlFleteros2.SelectedValue, out ddl))
                                {
                                    ddl = 0;
                                }
                                obj.Fletero_ID = ddl;

                                ddl = 0;
                                if (!int.TryParse(ddlProveedores2.SelectedValue, out ddl))
                                {
                                    ddl = 0;
                                }
                                obj.Proveedor_ID = ddl;

                                ddl = 0;
                                if (!int.TryParse(ddlClientes2.SelectedValue, out ddl))
                                {
                                    ddl = 0;
                                }
                                obj.Cliente_ID = ddl;

                                ddl = 0;
                                if (!int.TryParse(ddlPesadaOrigen2.SelectedValue, out ddl))
                                {
                                    ddl = 0;
                                }
                                obj.Pesada_origen_ID = ddl;

                                ddl = 0;
                                if (!int.TryParse(ddlPesadaDestino2.SelectedValue, out ddl))
                                {
                                    ddl = 0;
                                }
                                obj.Pesada_destino_ID = ddl;

                                #endregion DDL logic

                                context.viajes.Add(obj);
                                context.SaveChanges();
                                lblMessage.Text = "Agregado correctamente.";
                                BindGrid();
                            }
                        }
                    }
                    #endregion

                    if (e.CommandName == "View")
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

                    else
                    {
                        BindGrid();
                    }
                }
            }
        }

        protected void gridViajes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViajes.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gridViajes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViajes.EditIndex = -1;
            BindGrid();
        }

        protected void gridViajes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridViajes.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            TextBox txb11 = row.FindControl("txb11") as TextBox;
            TextBox txb12 = row.FindControl("txb12") as TextBox;
            TextBox txb15 = row.FindControl("txb15") as TextBox;
            DropDownList ddlFormas2 = row.FindControl("ddlFormas1") as DropDownList;
            DropDownList ddlCargadores2 = row.FindControl("ddlCargadores1") as DropDownList;
            DropDownList ddlCamiones2 = row.FindControl("ddlCamiones1") as DropDownList;
            DropDownList ddlChoferes2 = row.FindControl("ddlChoferes1") as DropDownList;
            DropDownList ddlFleteros2 = row.FindControl("ddlFleteros1") as DropDownList;
            DropDownList ddlProveedores2 = row.FindControl("ddlProveedores1") as DropDownList;
            DropDownList ddlClientes2 = row.FindControl("ddlClientes1") as DropDownList;
            DropDownList ddlPesadaOrigen2 = row.FindControl("ddlPesadaOrigen1") as DropDownList;
            DropDownList ddlPesadaDestino2 = row.FindControl("ddlPesadaDestino1") as DropDownList;

            if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb6 != null && txb7 != null && ddlChoferes2 != null && txb15 != null &&
                ddlPesadaOrigen2 != null && txb11 != null && txb12 != null && txb3 != null && ddlCargadores2 != null && ddlCamiones2 != null &&
                ddlPesadaDestino2 != null && ddlFleteros2 != null && ddlProveedores2 != null && ddlClientes2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = Convert.ToInt32(gridViajes.DataKeys[e.RowIndex].Value);
                    viaje obj = context.viajes.First(x => x.Viaje_ID == viaje_ID);
                    obj.Precio_compra_por_tonelada = decimal.Parse(txb1.Text);
                    obj.Precio_valor_total = decimal.Parse(txb2.Text);
                    obj.Importe_viaje = decimal.Parse(txb3.Text);
                    obj.Saldo = decimal.Parse(txb4.Text);
                    obj.Carga = txb6.Text;
                    obj.Descarga = txb7.Text;
                    obj.Comentarios = txb15.Text;

                    #region Datetime logic

                    DateTime date1 = obj.Fecha_partida;
                    if (!DateTime.TryParseExact(txb11.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                    {
                        date1 = obj.Fecha_partida;
                    }
                    obj.Fecha_partida = date1;

                    DateTime date2 = obj.Fecha_llegada;
                    if (!DateTime.TryParseExact(txb12.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date2))
                    {
                        date2 = obj.Fecha_partida;
                    }
                    obj.Fecha_llegada = date2;

                    #endregion 

                    #region DDL logic

                    int ddl1 = obj.Empresa_de_carga_ID;
                    if (!int.TryParse(ddlCargadores2.SelectedValue, out ddl1))
                    {
                        ddl1 = obj.Empresa_de_carga_ID;
                    }
                    obj.Empresa_de_carga_ID = ddl1;

                    int ddl2 = obj.Camion_ID;
                    if (!int.TryParse(ddlCamiones2.SelectedValue, out ddl2))
                    {
                        ddl2 = obj.Camion_ID;
                    }
                    obj.Camion_ID = ddl2;

                    int ddl3 = obj.Chofer_ID;
                    if (!int.TryParse(ddlChoferes2.SelectedValue, out ddl3))
                    {
                        ddl3 = obj.Chofer_ID;
                    }
                    obj.Chofer_ID = ddl3;

                    int ddl4 = obj.Forma_de_pago_ID;
                    if (!int.TryParse(ddlFormas2.SelectedValue, out ddl4))
                    {
                        ddl4 = obj.Forma_de_pago_ID;
                    }
                    obj.Forma_de_pago_ID = ddl4;

                    int ddl5 = obj.Fletero_ID;
                    if (!int.TryParse(ddlFleteros2.SelectedValue, out ddl5))
                    {
                        ddl5 = obj.Fletero_ID;
                    }
                    obj.Fletero_ID = ddl5;

                    int ddl6 = obj.Proveedor_ID;
                    if (!int.TryParse(ddlProveedores2.SelectedValue, out ddl6))
                    {
                        ddl6 = obj.Proveedor_ID;
                    }
                    obj.Proveedor_ID = ddl6;

                    int ddl7 = obj.Cliente_ID;
                    if (!int.TryParse(ddlClientes2.SelectedValue, out ddl7))
                    {
                        ddl7 = obj.Cliente_ID;
                    }
                    obj.Cliente_ID = ddl7;

                    int ddl8 = obj.Pesada_origen_ID;
                    if (!int.TryParse(ddlPesadaOrigen2.SelectedValue, out ddl8))
                    {
                        ddl8 = obj.Pesada_origen_ID;
                    }
                    obj.Pesada_origen_ID = ddl8;

                    int ddl9 = obj.Pesada_destino_ID;
                    if (!int.TryParse(ddlPesadaDestino2.SelectedValue, out ddl9))
                    {
                        ddl9 = obj.Pesada_destino_ID;
                    }
                    obj.Pesada_destino_ID = ddl9;

                    #endregion DDL logic

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridViajes.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridViajes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int viaje_ID = Convert.ToInt32(gridViajes.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                viaje obj = context.viajes.First(x => x.Viaje_ID == viaje_ID);
                context.viajes.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridViajes.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridViajes.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        public void BindGrid_EnCurso()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var elements = context.viajes.Where(e => e.EnViaje == true).ToList();
                if (elements.Count() > 0)
                {
                    gridViajesEnCurso.DataSource = context.viajes.ToList();
                    gridViajesEnCurso.DataBind();
                }
            }
        }

        protected void gridViajesEnCurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int viaje_ID = int.Parse(gridViajesEnCurso.DataKeys[index].Value.ToString());
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                if (e.CommandName.Equals("inspectViajeEnCurso"))
                {
                    viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                    if (viaje != null)
                    {
                        modalInspect_lblFecha1.Text = viaje.Fecha_partida.ToShortDateString();
                        modalInspect_lblFecha2.Text = viaje.Fecha_llegada.ToShortDateString();
                        modalInspect_lblLugarCarga.Text = viaje.Carga;
                        modalInspect_lblComentarios.Text = viaje.Comentarios;

                        proveedor proveedor = (proveedor)context.proveedores.FirstOrDefault(v => v.Proveedor_ID == viaje.Proveedor_ID);
                        if (proveedor != null)
                        {
                            modalInspect_lblProveedor.Text = proveedor.Nombre;
                        }
                        cliente cliente = (cliente)context.clientes.FirstOrDefault(v => v.cliente_ID == viaje.Cliente_ID);
                        if (cliente != null)
                        {
                            modalInspect_lblCliente.Text = cliente.Nombre;
                        }
                        cargador cargador = (cargador)context.cargadores.FirstOrDefault(v => v.Cargador_ID == viaje.Empresa_de_carga_ID);
                        if (cargador != null)
                        {
                            modalInspect_lblCargadores.Text = cargador.Nombre;
                        }
                        fletero fletero = (fletero)context.fleteros.FirstOrDefault(v => v.Fletero_ID == viaje.Fletero_ID);
                        if (fletero != null)
                        {
                            modalInspect_lblFletero.Text = fletero.Nombre;
                        }
                        camion camion = (camion)context.camiones.FirstOrDefault(v => v.Camion_ID == viaje.Camion_ID);
                        if (camion != null)
                        {
                            modalInspect_lblCamion.Text = camion.Matricula_camion;
                        }
                        chofer chofer = (chofer)context.choferes.FirstOrDefault(v => v.Chofer_ID == viaje.Chofer_ID);
                        if (chofer != null)
                        {
                            modalInspect_lblChofer.Text = chofer.Nombre_completo;
                        }

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#inspectModal').modal('show');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "InspectModalScript", sb.ToString(), false);
                    }
                }
                else if (e.CommandName.Equals("detail"))
                {
                    var elements = context.viajes.Where(v => v.Viaje_ID == viaje_ID).ToList();
                    if (elements.Count > 0)
                    {
                        gridViajesEnCurso.DataSource = elements;
                        gridViajesEnCurso.DataBind();

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#detailModal').modal('show');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
                    }
                }
                else if (e.CommandName.Equals("editViajeEnCurso"))
                {
                    viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                    if (viaje != null)
                    {
                        modalEdit_txbFecha1.Text = viaje.Fecha_partida.ToShortDateString();
                        modalEdit_txbFecha2.Text = viaje.Fecha_llegada.ToShortDateString();
                        modalEdit_txbLugarCarga.Text = viaje.Carga;
                        modalEdit_txbComentarios.Text = viaje.Comentarios;

                        proveedor proveedor = (proveedor)context.proveedores.FirstOrDefault(v => v.Proveedor_ID == viaje.Proveedor_ID);
                        if (proveedor != null)
                        {
                            modalEdit_ddlProveedor.Text = proveedor.Nombre;
                        }
                        cliente cliente = (cliente)context.clientes.FirstOrDefault(v => v.cliente_ID == viaje.Cliente_ID);
                        if (cliente != null)
                        {
                            modalEdit_ddlCliente.Text = cliente.Nombre;
                        }
                        cargador cargador = (cargador)context.cargadores.FirstOrDefault(v => v.Cargador_ID == viaje.Empresa_de_carga_ID);
                        if (cargador != null)
                        {
                            modalEdit_ddlCargadores.Text = cargador.Nombre;
                        }
                        fletero fletero = (fletero)context.fleteros.FirstOrDefault(v => v.Fletero_ID == viaje.Fletero_ID);
                        if (fletero != null)
                        {
                            modalEdit_ddlFletero.Text = fletero.Nombre;
                        }
                        camion camion = (camion)context.camiones.FirstOrDefault(v => v.Camion_ID == viaje.Camion_ID);
                        if (camion != null)
                        {
                            modalEdit_ddlCamion.Text = camion.Matricula_camion;
                        }
                        chofer chofer = (chofer)context.choferes.FirstOrDefault(v => v.Chofer_ID == viaje.Chofer_ID);
                        if (chofer != null)
                        {
                            modalEdit_ddlChofer.Text = chofer.Nombre_completo;
                        }

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#editModal').modal('show');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                    }
                }
                else if (e.CommandName.Equals("deleteViajeEnCurso"))
                {
                    hfCode.Value = viaje_ID.ToString();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#deleteModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
                }

            }
        }

        private void executeUpdate(int viaje_ID, string comentarios)
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var element = context.viajes.SingleOrDefault(v => v.Viaje_ID == viaje_ID);
                if (element != null)
                {
                    element.Comentarios = comentarios;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

        }

        private void executeAdd(string comentarios)
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                viaje new_viaje = new viaje();
                new_viaje.Comentarios = comentarios;
                var element = context.viajes.Add(new_viaje);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string viaje_ID = hfCode.Value;
            executeDelete(viaje_ID);
            BindGrid_EnCurso();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Record deleted Successfully');");
            sb.Append("$('#deleteModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
        }

        private void executeDelete(string viaje_ID)
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var element = context.viajes.SingleOrDefault(v => v.Viaje_ID == int.Parse(viaje_ID));
                if (element != null)
                {
                    context.viajes.Remove(element);
                }
            }
        }

        protected void gridViajesEnCurso_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnInspeccionar = e.Row.FindControl("btnInspeccionar") as LinkButton;
                if (btnInspeccionar != null)
                {
                    btnInspeccionar.CommandArgument = e.Row.DataItemIndex.ToString();
                }
                LinkButton btnModificar = e.Row.FindControl("btnModificar") as LinkButton;
                if (btnModificar != null)
                {
                    btnModificar.CommandArgument = e.Row.DataItemIndex.ToString();
                }
                LinkButton btnBorrar = e.Row.FindControl("btnBorrar") as LinkButton;
                if (btnBorrar != null)
                {
                    btnBorrar.CommandArgument = e.Row.DataItemIndex.ToString();
                }
            }
        }

        protected void btnAddRecord1_Click(object sender, EventArgs e)
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                string txbFecha1 = hdn_modalAdd_txbFecha1.Value;
                string txbFecha2 = hdn_modalAdd_txbFecha2.Value;
                string ddlProveedores = hdn_modalAdd_ddlProveedores.Value;
                string ddlClientes = hdn_modalAdd_ddlClientes.Value;
                string ddlEmpresaCarga = hdn_modalAdd_ddlEmpresaCarga.Value;
                string txbLugarCarga = hdn_modalAdd_txbLugarCarga.Value;
                string ddlFleteros = hdn_modalAdd_ddlFleteros.Value;
                string ddlCamiones = hdn_modalAdd_ddlCamiones.Value;
                string ddlChoferes = hdn_modalAdd_ddlChoferes.Value;
                string txbComentarios = hdn_modalAdd_txbComentarios.Value;

                if (txbFecha1 != null && txbFecha2 != null && ddlProveedores != null && ddlClientes != null && ddlEmpresaCarga != null && txbLugarCarga != null && 
                    ddlFleteros != null && ddlCamiones != null && ddlChoferes != null && txbComentarios != null)
                {

                    viaje new_viaje = new viaje();

                    DateTime date1 = DateTime.Now;
                    if (!DateTime.TryParseExact(txbFecha1, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                    {
                        date1 = DateTime.Now;
                    }
                    new_viaje.Fecha_partida = date1;

                    DateTime date2 = DateTime.Now;
                    if (!DateTime.TryParseExact(txbFecha2, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date2))
                    {
                        date2 = DateTime.Now;
                    }
                    new_viaje.Fecha_llegada = date2;

                    #region DDL logic

                    int ddl = 0;
                    if (!int.TryParse(ddlProveedores, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Empresa_de_carga_ID = ddl;

                    ddl = 0;
                    if (!int.TryParse(ddlClientes, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Camion_ID = ddl;

                    ddl = 0;
                    if (!int.TryParse(ddlEmpresaCarga, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Chofer_ID = ddl;

                    ddl = 0;
                    if (!int.TryParse(ddlFleteros, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Fletero_ID = ddl;

                    ddl = 0;
                    if (!int.TryParse(ddlProveedores, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Proveedor_ID = ddl;

                    ddl = 0;
                    if (!int.TryParse(ddlClientes, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Cliente_ID = ddl;

                    #endregion DDL logic

                    new_viaje.Carga = txbLugarCarga;
                    new_viaje.Descarga = string.Empty;
                    new_viaje.Comentarios = txbComentarios;
                    new_viaje.EnViaje = true;

                    context.viajes.Add(new_viaje);
                    context.SaveChanges();

                    BindGrid_EnCurso();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("alert('Viaje agregado');");
                    //sb.Append("$('#addModal').modal('hide');");
                    sb.Append("$.modal.close();");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
                }

            }
        }

    }
}