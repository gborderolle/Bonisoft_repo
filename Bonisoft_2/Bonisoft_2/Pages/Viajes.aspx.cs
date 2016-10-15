﻿using Bonisoft_2.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Viajes : System.Web.UI.Page
    {
        // http://www.programming-free.com/2013/09/gridview-crud-bootstrap-modal-popup.html

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViajes();
                BindGrid_ViajesEnCurso();
                BindAddModal();
                BindEditModal();
            }
            gridViajes.UseAccessibleHeader = true;
            gridViajes.HeaderRow.TableSection = TableRowSection.TableHeader;

            gridViajesEnCurso.UseAccessibleHeader = true;
            gridViajesEnCurso.HeaderRow.TableSection = TableRowSection.TableHeader;

            gridViajes_lblMessage.Text = string.Empty;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

        }

        protected void btnAddRecord1_Click(object sender, EventArgs e)
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                string txbFecha1 = hdn_modalAdd_txbFecha1.Value;
                string txbFecha2 = hdn_modalAdd_txbFecha2.Value;
                string ddlProveedores = hdn_modalAdd_ddlProveedores.Value;
                string ddlClientes = hdn_modalAdd_ddlClientes.Value;
                string ddlCargadores = hdn_modalAdd_ddlCargadores.Value;
                string txbLugarCarga = hdn_modalAdd_txbLugarCarga.Value;
                string ddlFleteros = hdn_modalAdd_ddlFleteros.Value;
                string ddlCamiones = hdn_modalAdd_ddlCamiones.Value;
                string ddlChoferes = hdn_modalAdd_ddlChoferes.Value;
                string txbComentarios = hdn_modalAdd_txbComentarios.Value;

                if (txbFecha1 != null && txbFecha2 != null && ddlProveedores != null && ddlClientes != null && ddlCargadores != null && txbLugarCarga != null &&
                    ddlFleteros != null && ddlCamiones != null && ddlChoferes != null && txbComentarios != null)
                {
                    viaje new_viaje = new viaje();

                    DateTime date1 = DateTime.Now;
                    if (!DateTime.TryParseExact(txbFecha1, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                    {
                        date1 = DateTime.Now;
                    }
                    new_viaje.Fecha_partida = date1;

                    DateTime date2 = DateTime.Now;
                    if (!DateTime.TryParseExact(txbFecha2, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date2))
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
                    new_viaje.Proveedor_ID = ddl;

                    ddl = 0;
                    if (!int.TryParse(ddlClientes, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Cliente_ID = ddl;

                    ddl = 0;
                    if (!int.TryParse(ddlCargadores, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Empresa_de_carga_ID = ddl;

                    ddl = 0;
                    if (!int.TryParse(ddlFleteros, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Fletero_ID = ddl;

                    ddl = 0;
                    if (!int.TryParse(ddlCamiones, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Camion_ID = ddl;

                    ddl = 0;
                    if (!int.TryParse(ddlChoferes, out ddl))
                    {
                        ddl = 0;
                    }
                    new_viaje.Chofer_ID = ddl;

                    #endregion DDL logic

                    new_viaje.Carga = txbLugarCarga;
                    new_viaje.Descarga = string.Empty;
                    new_viaje.Comentarios = txbComentarios;
                    new_viaje.EnViaje = true;

                    new_viaje.Fecha_registro = DateTime.Now;

                    context.viajes.Add(new_viaje);

                    #region Log

                    //log new_log = new log();
                    //new_log.Usuario_ID = 0;
                    //new_log.Fecha = DateTime.Now;
                    ////new_log.Descripcion="Nuevo pago: " + pago
                    //context.logs.Add(new_log);

                    #endregion

                    context.SaveChanges();

                    BindGrid_ViajesEnCurso();
                    ScriptManager.RegisterStartupScript(upAdd, this.GetType(), "btnAddRecord1_Click", "<script type='text/javascript'>show_message_info('OK_ViajeNuevo'); $.modal.close();</script>", false);
                }

            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                string value = hdn_editViaje_viajeID.Value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    int viaje_ID = 0;
                    if (!int.TryParse(value, out viaje_ID))
                    {
                        viaje_ID = 0;
                    }
                    if (viaje_ID > 0)
                    {
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                        if (viaje != null)
                        {
                            string txbFecha1 = hdn_modalEdit_txbFecha1.Value;
                            string txbFecha2 = hdn_modalEdit_txbFecha2.Value;
                            string ddlProveedores = hdn_modalEdit_ddlProveedores.Value;
                            string ddlClientes = hdn_modalEdit_ddlClientes.Value;
                            string ddlCargadores = hdn_modalEdit_ddlCargadores.Value;
                            string txbLugarCarga = hdn_modalEdit_txbLugarCarga.Value;
                            string ddlFleteros = hdn_modalEdit_ddlFleteros.Value;
                            string ddlCamiones = hdn_modalEdit_ddlCamiones.Value;
                            string ddlChoferes = hdn_modalEdit_ddlChoferes.Value;
                            string txbComentarios = hdn_modalEdit_txbComentarios.Value;

                            if (txbFecha1 != null && txbFecha2 != null && ddlProveedores != null && ddlClientes != null && ddlCargadores != null && txbLugarCarga != null &&
                                ddlFleteros != null && ddlCamiones != null && ddlChoferes != null && txbComentarios != null)
                            {
                                DateTime date1 = viaje.Fecha_partida;
                                if (!DateTime.TryParseExact(txbFecha1, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                                {
                                    date1 = viaje.Fecha_partida;
                                }
                                viaje.Fecha_partida = date1;

                                DateTime date2 = viaje.Fecha_llegada;
                                if (!DateTime.TryParseExact(txbFecha2, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date2))
                                {
                                    date2 = viaje.Fecha_llegada;
                                }
                                viaje.Fecha_llegada = date2;

                                #region DDL logic

                                int ddl = viaje.Proveedor_ID;
                                if (!int.TryParse(ddlProveedores, out ddl))
                                {
                                    ddl = viaje.Proveedor_ID;
                                }
                                viaje.Proveedor_ID = ddl;

                                ddl = viaje.Cliente_ID;
                                if (!int.TryParse(ddlClientes, out ddl))
                                {
                                    ddl = viaje.Cliente_ID;
                                }
                                viaje.Cliente_ID = ddl;

                                ddl = viaje.Empresa_de_carga_ID;
                                if (!int.TryParse(ddlCargadores, out ddl))
                                {
                                    ddl = viaje.Empresa_de_carga_ID;
                                }
                                viaje.Empresa_de_carga_ID = ddl;

                                ddl = viaje.Fletero_ID;
                                if (!int.TryParse(ddlFleteros, out ddl))
                                {
                                    ddl = viaje.Fletero_ID;
                                }
                                viaje.Fletero_ID = ddl;

                                ddl = viaje.Camion_ID;
                                if (!int.TryParse(ddlCamiones, out ddl))
                                {
                                    ddl = viaje.Camion_ID;
                                }
                                viaje.Camion_ID = ddl;

                                ddl = viaje.Chofer_ID;
                                if (!int.TryParse(ddlChoferes, out ddl))
                                {
                                    ddl = viaje.Chofer_ID;
                                }
                                viaje.Chofer_ID = ddl;

                                #endregion DDL logic

                                viaje.Carga = txbLugarCarga;
                                viaje.Descarga = string.Empty;
                                viaje.Comentarios = txbComentarios;
                                viaje.EnViaje = true;

                                #region Log

                                //log new_log = new log();
                                //new_log.Usuario_ID = 0;
                                //new_log.Fecha = DateTime.Now;
                                ////new_log.Descripcion="Nuevo pago: " + pago
                                //context.logs.Add(new_log);

                                #endregion

                                context.SaveChanges();

                                BindGrid_ViajesEnCurso();
                                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                sb.Append(@"<script type='text/javascript'>");
                                sb.Append("$.modal.close();");
                                sb.Append(@"</script>");
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
                            }

                        }
                    }
                }
            }
        }

        private void FillData_Pesadas(viaje viaje)
        {
            if (viaje != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    #region Pesada 1

                    int pesada_origen_ID = viaje.Pesada_origen_ID;
                    if (pesada_origen_ID > 0)
                    {
                        pesada pesada_origen = (pesada)context.pesadas.FirstOrDefault(v => v.pesada_ID == pesada_origen_ID);
                        if (pesada_origen != null)
                        {
                            hdn_notificacionesPesadaOrigenID.Value = pesada_origen_ID.ToString();

                            // Fields
                            txb_pesada1Lugar.Text = pesada_origen.Lugar;
                            txb_pesada1Fecha.Text = pesada_origen.Fecha.ToShortDateString();
                            txb_pesada1Nombre.Text = pesada_origen.Nombre_balanza;
                            txb_pesada1Peso_bruto.Text = pesada_origen.Peso_bruto.ToString();
                            txb_pesada1Peso_neto.Text = pesada_origen.Peso_neto.ToString();
                            txb_pesada1Comentarios.Text = pesada_origen.Comentarios;

                            // Hidden Fields
                            hdn_modalNotificaciones_pesadas1_txbLugar.Value = pesada_origen.Lugar;
                            hdn_modalNotificaciones_pesadas1_txbFecha.Value = pesada_origen.Fecha.ToShortDateString();
                            hdn_modalNotificaciones_pesadas1_txbPesoBruto.Value = pesada_origen.Nombre_balanza;
                            hdn_modalNotificaciones_pesadas1_txbPesoNeto.Value = pesada_origen.Peso_bruto.ToString();
                            hdn_modalNotificaciones_pesadas1_txbNombre.Value = pesada_origen.Peso_neto.ToString();
                            hdn_modalNotificaciones_pesadas1_txbComentarios.Value = pesada_origen.Comentarios;
                        }
                    }
                    #endregion

                    #region Pesada 2

                    int pesada_destino_ID = viaje.Pesada_destino_ID;
                    if (pesada_destino_ID > 0)
                    {
                        pesada pesada_destino = (pesada)context.pesadas.FirstOrDefault(v => v.pesada_ID == pesada_destino_ID);
                        if (pesada_destino != null)
                        {
                            hdn_notificacionesPesadaDestinoID.Value = pesada_destino_ID.ToString();

                            // Fields
                            txb_pesada2Lugar.Text = pesada_destino.Lugar;
                            txb_pesada2Fecha.Text = pesada_destino.Fecha.ToShortDateString();
                            txb_pesada2Nombre.Text = pesada_destino.Nombre_balanza;
                            txb_pesada2Peso_bruto.Text = pesada_destino.Peso_bruto.ToString();
                            txb_pesada2Peso_neto.Text = pesada_destino.Peso_neto.ToString();
                            txb_pesada2Comentarios.Text = pesada_destino.Comentarios;

                            // Hidden Fields                                        
                            hdn_modalNotificaciones_pesadas2_txbLugar.Value = pesada_destino.Lugar;
                            hdn_modalNotificaciones_pesadas2_txbFecha.Value = pesada_destino.Fecha.ToShortDateString();
                            hdn_modalNotificaciones_pesadas2_txbPesoBruto.Value = pesada_destino.Nombre_balanza;
                            hdn_modalNotificaciones_pesadas2_txbPesoNeto.Value = pesada_destino.Peso_bruto.ToString();
                            hdn_modalNotificaciones_pesadas2_txbNombre.Value = pesada_destino.Peso_neto.ToString();
                            hdn_modalNotificaciones_pesadas2_txbComentarios.Value = pesada_destino.Comentarios;
                        }
                    }
                    #endregion
                }
            }
        }

        private void FillData_Ventas(viaje viaje)
        {
            if (viaje != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    notif_txbPrecioFlete.Text = viaje.precio_flete.ToString();
                    notif_txbPrecioDescarga.Text = viaje.precio_descarga.ToString();
                    notif_txbGananciaXTon.Text = viaje.GananciaXTon.ToString();
                    notif_txbIVA.Text = viaje.IVA.ToString();

                    string precio_venta_str = viaje.precio_venta.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "FillData_Ventas", "<script type='text/javascript'>$('#notif_lblPrecioVenta').text(" + precio_venta_str + "); </script>", false);
                }
            }
        }

        protected void lnkViajeDestino_Click(object sender, EventArgs e)
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                int viaje_ID = 0;
                if (!int.TryParse(hdn_notificaciones_viajeID.Value, out viaje_ID))
                {
                    viaje_ID = 0;
                }
                if (viaje_ID > 0)
                {
                    viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                    if (viaje != null)
                    {
                        bool save_ok = false;

                        // Check si tiene Mercaderías
                        var elements = context.mercaderia_comprada.Where(m => m.Viaje_ID == viaje_ID).ToList();
                        if (elements.Count() > 0)
                        {
                            save_ok = true;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "lnkViajeDestino_Click1", "<script type='text/javascript'>show_message_info('Error_DatosMercaderias'); </script>", false);

                            FillData_Pesadas(viaje);
                            FillData_Ventas(viaje);
                        }
                        if (save_ok)
                        {
                            // Check si tiene Pesadas origen y destino
                            if (viaje.Pesada_origen_ID == 0 || viaje.Pesada_destino_ID == 0)
                            {
                                save_ok = false;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "lnkViajeDestino_Click2", "<script type='text/javascript'>show_message_info('Error_DatosPesadas'); </script>", false);

                                FillData_Pesadas(viaje);
                                FillData_Ventas(viaje);
                            }
                        }
                        if (save_ok)
                        {
                            // Check si tiene Precio de venta calculado
                            if (viaje.precio_venta == 0)
                            {
                                save_ok = false;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "lnkViajeDestino_Click4", "<script type='text/javascript'>show_message_info('Error_DatosPrecioVenta'); </script>", false);

                                FillData_Pesadas(viaje);
                                FillData_Ventas(viaje);
                            }
                        }

                        if (save_ok)
                        {
                            viaje.EnViaje = false;

                            #region Log

                            //log new_log = new log();
                            //new_log.Usuario_ID = 0;
                            //new_log.Fecha = DateTime.Now;
                            ////new_log.Descripcion="Nuevo pago: " + pago
                            //context.logs.Add(new_log);

                            #endregion

                            context.SaveChanges();

                            BindGrid_ViajesEnCurso();
                            BindGridViajes();

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "lnkViajeDestino_Click3", "<script type='text/javascript'>show_message_info('OK_FINViaje'); $.modal.close();</script>", false);
                        }
                        else
                        {
                            Mercaderias.BindGrid();

                        }


                    }
                }
            }
        }

        protected void btnSubmit_upAdd_Click(object sender, EventArgs e)
        {
            BindAddModal();
        }

        protected void upAdd_Load(object sender, EventArgs e)
        {
            BindAddModal();
        }

        protected void btnUpdateViajesEnCurso_Click(object sender, EventArgs e)
        {
            BindGrid_ViajesEnCurso();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("bindEvents();");
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "btnUpdateViajesEnCurso_Click", sb.ToString(), false);
        }

        protected void btnUpdateViajes_Click(object sender, EventArgs e)
        {
            BindGridViajes();
        }

        #endregion Events

        #region GridView methods

        protected void gridViajes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Updatepanel triggers

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = e.Row.FindControl("lnkEdit") as LinkButton;
                if (lnk != null)
                {
                    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lnk);
                }
                lnk = e.Row.FindControl("lnkDelete") as LinkButton;
                if (lnk != null)
                {
                    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lnk);
                }
                lnk = e.Row.FindControl("lnkInsert") as LinkButton;
                if (lnk != null)
                {
                    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lnk);
                }
                lnk = e.Row.FindControl("lnkCancel") as LinkButton;
                if (lnk != null)
                {
                    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lnk);
                }
            }

            #endregion

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
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

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
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

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
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

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
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

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
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

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
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Cliente_ID.ToString();
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
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

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
                    ddl.Items.Insert(0, new ListItem("Elegir", "0"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Pesada_destino_ID.ToString();
                }
            }

            #endregion

            #region DDL Default values

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
                                string nombre = fletero.Nombre;
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
                                string nombre = chofer.Nombre_completo;
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
                                string nombre = proveedor.Nombre;
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
                                string nombre = cliente.Nombre;
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
                Label lbl = e.Row.FindControl("lbl8") as Label;
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
                                //lbl.CommandArgument = "pesadas," + pesada.Nombre_balanza;
                            }
                        }
                    }
                }
            }

            // Pesada destino ----------------------------------------------------
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lbl9") as Label;
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
                                //lbl.CommandArgument = "pesadas," + pesada.Nombre_balanza;
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

                    if (e.CommandName.Equals("InsertNew"))
                    {
                        int index = Convert.ToInt32(e.CommandArgument);

                        GridViewRow row = gridViajes.FooterRow;
                        TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                        TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                        TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                        TextBox txb11 = row.FindControl("txbNew11") as TextBox;
                        TextBox txb12 = row.FindControl("txbNew12") as TextBox;
                        TextBox txb15 = row.FindControl("txbNew15") as TextBox;
                        DropDownList ddlCargadores2 = row.FindControl("ddlCargadores2") as DropDownList;
                        DropDownList ddlCamiones2 = row.FindControl("ddlCamiones2") as DropDownList;
                        DropDownList ddlChoferes2 = row.FindControl("ddlChoferes2") as DropDownList;
                        DropDownList ddlFleteros2 = row.FindControl("ddlFleteros2") as DropDownList;
                        DropDownList ddlProveedores2 = row.FindControl("ddlProveedores2") as DropDownList;
                        DropDownList ddlClientes2 = row.FindControl("ddlClientes2") as DropDownList;
                        DropDownList ddlPesadaOrigen2 = row.FindControl("ddlPesadaOrigen2") as DropDownList;
                        DropDownList ddlPesadaDestino2 = row.FindControl("ddlPesadaDestino2") as DropDownList;

                        if (txb2 != null && txb3 != null && txb6 != null && ddlChoferes2 != null && txb15 != null &&
                            ddlPesadaOrigen2 != null && txb11 != null && txb12 != null && txb3 != null && ddlCargadores2 != null && ddlCamiones2 != null &&
                            ddlPesadaDestino2 != null && ddlFleteros2 != null && ddlProveedores2 != null && ddlClientes2 != null)
                        {
                            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                            {
                                viaje obj = new viaje();
                                obj.Carga = txb6.Text;
                                obj.Comentarios = txb15.Text;

                                decimal value = obj.precio_compra;
                                if (!decimal.TryParse(txb2.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                                {
                                    value = obj.precio_compra;
                                }
                                obj.precio_compra = value;

                                value = obj.precio_venta;
                                if (!decimal.TryParse(txb3.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                                {
                                    value = obj.precio_venta;
                                }
                                obj.precio_venta = value;

                                #region Datetime logic

                                DateTime date1 = DateTime.Now;
                                if (!DateTime.TryParseExact(txb11.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                                {
                                    date1 = DateTime.Now;
                                }
                                obj.Fecha_partida = date1;

                                DateTime date2 = DateTime.Now;
                                if (!DateTime.TryParseExact(txb12.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date2))
                                {
                                    date2 = DateTime.Now;
                                }
                                obj.Fecha_llegada = date2;

                                #endregion Datetime logic

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

                                #region Log

                                //log new_log = new log();
                                //new_log.Usuario_ID = 0;
                                //new_log.Fecha = DateTime.Now;
                                ////new_log.Descripcion="Nuevo pago: " + pago
                                //context.logs.Add(new_log);

                                #endregion

                                context.SaveChanges();

                                gridViajes_lblMessage.Text = "Agregado correctamente.";
                                BindGridViajes();
                            }
                        }
                    }
                    #endregion

                    else if (e.CommandName.Equals("View"))
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
            }
        }

        protected void gridViajes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViajes.EditIndex = e.NewEditIndex;
            BindGridViajes();
        }

        protected void gridViajes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViajes.EditIndex = -1;
            BindGridViajes();
        }

        protected void gridViajes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridViajes.Rows[e.RowIndex];
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb11 = row.FindControl("txb11") as TextBox;
            TextBox txb12 = row.FindControl("txb12") as TextBox;
            TextBox txb15 = row.FindControl("txb15") as TextBox;
            //DropDownList ddlFormas2 = row.FindControl("ddlFormas1") as DropDownList;
            DropDownList ddlCargadores2 = row.FindControl("ddlCargadores1") as DropDownList;
            DropDownList ddlCamiones2 = row.FindControl("ddlCamiones1") as DropDownList;
            DropDownList ddlChoferes2 = row.FindControl("ddlChoferes1") as DropDownList;
            DropDownList ddlFleteros2 = row.FindControl("ddlFleteros1") as DropDownList;
            DropDownList ddlProveedores2 = row.FindControl("ddlProveedores1") as DropDownList;
            DropDownList ddlClientes2 = row.FindControl("ddlClientes1") as DropDownList;
            DropDownList ddlPesadaOrigen2 = row.FindControl("ddlPesadaOrigen1") as DropDownList;
            DropDownList ddlPesadaDestino2 = row.FindControl("ddlPesadaDestino1") as DropDownList;

            if (txb2 != null && txb3 != null && txb6 != null && ddlChoferes2 != null && txb15 != null &&
                ddlPesadaOrigen2 != null && txb11 != null && txb12 != null && txb3 != null && ddlCargadores2 != null && ddlCamiones2 != null &&
                ddlPesadaDestino2 != null && ddlFleteros2 != null && ddlProveedores2 != null && ddlClientes2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = Convert.ToInt32(gridViajes.DataKeys[e.RowIndex].Value);
                    viaje obj = context.viajes.First(x => x.Viaje_ID == viaje_ID);
                    obj.Carga = txb6.Text;
                    obj.Comentarios = txb15.Text;

                    decimal value = 0;
                    if (!decimal.TryParse(txb2.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                    {
                        value = 0;
                    }
                    obj.precio_compra = value;

                    value = 0;
                    if (!decimal.TryParse(txb3.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                    {
                        value = 0;
                    }
                    obj.precio_venta = value;

                    #region Datetime logic

                    DateTime date1 = obj.Fecha_partida;
                    if (!DateTime.TryParseExact(txb11.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                    {
                        date1 = obj.Fecha_partida;
                    }
                    obj.Fecha_partida = date1;

                    DateTime date2 = obj.Fecha_llegada;
                    if (!DateTime.TryParseExact(txb12.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date2))
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

                    //int ddl4 = obj.Forma_de_pago_ID;
                    //if (!int.TryParse(ddlFormas2.SelectedValue, out ddl4))
                    //{
                    //    ddl4 = obj.Forma_de_pago_ID;
                    //}
                    //obj.Forma_de_pago_ID = ddl4;

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

                    #region Log

                    //log new_log = new log();
                    //new_log.Usuario_ID = 0;
                    //new_log.Fecha = DateTime.Now;
                    ////new_log.Descripcion="Nuevo pago: " + pago
                    //context.logs.Add(new_log);

                    #endregion

                    context.SaveChanges();

                    gridViajes_lblMessage.Text = "Guardado correctamente.";
                    gridViajes.EditIndex = -1;
                    BindGridViajes();
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

                #region Log

                //log new_log = new log();
                //new_log.Usuario_ID = 0;
                //new_log.Fecha = DateTime.Now;
                ////new_log.Descripcion="Nuevo pago: " + pago
                //context.logs.Add(new_log);

                #endregion

                context.SaveChanges();

                BindGridViajes();
                gridViajes_lblMessage.Text = "Borrado correctamente.";
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
            gridViajes_lblMessage.Text = string.Empty;
        }

        protected void gridViajesEnCurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                if (!string.IsNullOrWhiteSpace(e.CommandArgument.ToString()) && !string.IsNullOrWhiteSpace(e.CommandName))
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        if (e.CommandName.Equals("notificar"))
                        {
                            int index = Convert.ToInt32(e.CommandArgument);
                            int viaje_ID = int.Parse(gridViajesEnCurso.DataKeys[index].Value.ToString());
                            hdn_editViaje_viajeID.Value = viaje_ID.ToString();

                            viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                            if (viaje != null)
                            {
                                notif_lblPrecioCompra.InnerText = viaje.precio_compra.ToString();

                                // http://asp.net-tutorials.com/user-controls/using/
                                hdn_notificaciones_viajeID.Value = viaje_ID.ToString();

                                Mercaderias.Viaje_ID1 = viaje_ID.ToString();
                                Mercaderias.BindGrid();

                                FillData_Pesadas(viaje);
                                FillData_Ventas(viaje);

                                BindGridViajes();

                                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                sb.Append(@"<script type='text/javascript'>");
                                sb.Append("$('#tabsNotificaciones').tabs(); $('#notificacionesModal').modal('show'); bindEvents();");
                                sb.Append(@"</script>");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotificarModalScript", sb.ToString(), false);
                            }
                        }

                        else if (e.CommandName.Equals("editViajeEnCurso"))
                        {
                            int index = Convert.ToInt32(e.CommandArgument);
                            int viaje_ID = int.Parse(gridViajesEnCurso.DataKeys[index].Value.ToString());
                            hdn_editViaje_viajeID.Value = viaje_ID.ToString();

                            viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                            if (viaje != null)
                            {
                                BindEditModal();

                                modalEdit_txbFecha1.Text = viaje.Fecha_partida.ToShortDateString();
                                modalEdit_txbFecha2.Text = viaje.Fecha_llegada.ToShortDateString();
                                modalEdit_txbLugarCarga.Text = viaje.Carga;
                                modalEdit_txbComentarios.Text = viaje.Comentarios;

                                modalEdit_ddlProveedores.SelectedValue = viaje.Proveedor_ID.ToString();
                                modalEdit_ddlClientes.SelectedValue = viaje.Cliente_ID.ToString();
                                modalEdit_ddlCargadores.SelectedValue = viaje.Empresa_de_carga_ID.ToString();
                                modalEdit_ddlFleteros.SelectedValue = viaje.Fletero_ID.ToString();
                                modalEdit_ddlCamiones.SelectedValue = viaje.Camion_ID.ToString();
                                modalEdit_ddlChoferes.SelectedValue = viaje.Chofer_ID.ToString();

                                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                sb.Append(@"<script type='text/javascript'>");
                                //sb.Append("$('#editModal').modal('show'); $('.datepicker').datepicker({ dateFormat: 'dd-MM-yyyy' });");
                                sb.Append("$('#editModal').modal('show');");
                                sb.Append(@"</script>");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "EditModalScript", sb.ToString(), false);
                            }
                        }

                        else if (e.CommandName.Equals("deleteViajeEnCurso"))
                        {
                            int index = Convert.ToInt32(e.CommandArgument);
                            int viaje_ID = int.Parse(gridViajesEnCurso.DataKeys[index].Value.ToString());
                            hdn_editViaje_viajeID.Value = viaje_ID.ToString();

                            viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                            if (viaje != null)
                            {
                                context.viajes.Remove(viaje);

                                #region Log

                                //log new_log = new log();
                                //new_log.Usuario_ID = 0;
                                //new_log.Fecha = DateTime.Now;
                                ////new_log.Descripcion="Nuevo pago: " + pago
                                //context.logs.Add(new_log);

                                #endregion

                                context.SaveChanges();

                                BindGrid_ViajesEnCurso();
                                gridViajesEnCurso_lblMessage.Text = "Borrado correctamente.";
                            }
                        }

                        else if (e.CommandName.Equals("View"))
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
                }
            }
        }

        protected void gridViajesEnCurso_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Updatepanel triggers

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btn = e.Row.FindControl("btnModificar") as LinkButton;
                if (btn != null)
                {
                    btn.CommandArgument = e.Row.DataItemIndex.ToString();
                    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btn);
                }
                btn = e.Row.FindControl("btnBorrar") as LinkButton;
                if (btn != null)
                {
                    btn.CommandArgument = e.Row.DataItemIndex.ToString();
                    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btn);
                }
            }

            #endregion Buttons

            #region Labels

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lblProveedor = e.Row.FindControl("lblProveedor") as LinkButton;
                if (lblProveedor != null)
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
                                lblProveedor.Text = proveedor.Nombre;
                                lblProveedor.CommandArgument = "proveedores," + proveedor.Nombre;
                            }
                        }
                    }
                }

                LinkButton lblFletero = e.Row.FindControl("lblFletero") as LinkButton;
                if (lblFletero != null)
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
                                lblFletero.Text = fletero.Nombre;
                                lblFletero.CommandArgument = "fleteros," + fletero.Nombre;
                            }
                        }
                    }
                }

                LinkButton lblCliente = e.Row.FindControl("lblCliente") as LinkButton;
                if (lblCliente != null)
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
                                lblCliente.Text = cliente.Nombre;
                                lblCliente.CommandArgument = "clientes," + cliente.Nombre;
                            }
                        }
                    }
                }
            }

            #endregion Labels
        }

        #endregion Events

        #region General methods

        private void BindAddModal()
        {
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
                    modalAdd_ddlProveedores.Items.Insert(0, new ListItem("Elegir", "0"));

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
                    modalAdd_ddlClientes.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }

            // Empresas de carga --------------------------------------------------
            if (modalAdd_ddlCargadores != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.cargadores.ToList());

                    modalAdd_ddlCargadores.DataSource = dt1;
                    modalAdd_ddlCargadores.DataTextField = "Nombre";
                    modalAdd_ddlCargadores.DataValueField = "Cargador_ID";
                    modalAdd_ddlCargadores.DataBind();
                    modalAdd_ddlCargadores.Items.Insert(0, new ListItem("Elegir", "0"));

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
                    modalAdd_ddlFleteros.Items.Insert(0, new ListItem("Elegir", "0"));

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
                    modalAdd_ddlCamiones.Items.Insert(0, new ListItem("Elegir", "0"));

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
                    modalAdd_ddlChoferes.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }
        }

        private void BindEditModal()
        {
            // Proveedores --------------------------------------------------
            if (modalEdit_ddlProveedores != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.proveedores.ToList());

                    modalEdit_ddlProveedores.DataSource = dt1;
                    modalEdit_ddlProveedores.DataTextField = "Nombre";
                    modalEdit_ddlProveedores.DataValueField = "Proveedor_ID";
                    modalEdit_ddlProveedores.DataBind();
                    modalEdit_ddlProveedores.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }

            // Clientes --------------------------------------------------
            if (modalEdit_ddlClientes != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.clientes.ToList());

                    modalEdit_ddlClientes.DataSource = dt1;
                    modalEdit_ddlClientes.DataTextField = "Nombre";
                    modalEdit_ddlClientes.DataValueField = "Cliente_ID";
                    modalEdit_ddlClientes.DataBind();
                    modalEdit_ddlClientes.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }

            // Empresas de carga --------------------------------------------------
            if (modalEdit_ddlCargadores != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.cargadores.ToList());

                    modalEdit_ddlCargadores.DataSource = dt1;
                    modalEdit_ddlCargadores.DataTextField = "Nombre";
                    modalEdit_ddlCargadores.DataValueField = "Cargador_ID";
                    modalEdit_ddlCargadores.DataBind();
                    modalEdit_ddlCargadores.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }

            // Fleteros --------------------------------------------------
            if (modalEdit_ddlFleteros != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.fleteros.ToList());

                    modalEdit_ddlFleteros.DataSource = dt1;
                    modalEdit_ddlFleteros.DataTextField = "Nombre";
                    modalEdit_ddlFleteros.DataValueField = "Fletero_ID";
                    modalEdit_ddlFleteros.DataBind();
                    modalEdit_ddlFleteros.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }

            // Camiones --------------------------------------------------
            if (modalEdit_ddlCamiones != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.camiones.ToList());

                    modalEdit_ddlCamiones.DataSource = dt1;
                    modalEdit_ddlCamiones.DataTextField = "Matricula_camion";
                    modalEdit_ddlCamiones.DataValueField = "Camion_ID";
                    modalEdit_ddlCamiones.DataBind();
                    modalEdit_ddlCamiones.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }

            // Choferes --------------------------------------------------
            if (modalEdit_ddlChoferes != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    DataTable dt1 = new DataTable();
                    dt1 = Extras.ToDataTable(context.choferes.ToList());

                    modalEdit_ddlChoferes.DataSource = dt1;
                    modalEdit_ddlChoferes.DataTextField = "Nombre_completo";
                    modalEdit_ddlChoferes.DataValueField = "Chofer_ID";
                    modalEdit_ddlChoferes.DataBind();
                    modalEdit_ddlChoferes.Items.Insert(0, new ListItem("Elegir", "0"));

                }
            }
        }

        private void BindGridViajes()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var elements = context.viajes.Where(e => e.EnViaje == false).OrderByDescending(e => e.Fecha_partida).ToList();
                if (elements.Count() > 0)
                {
                    gridViajes.DataSource = elements;
                    gridViajes.DataBind();

                    lblGridViajesCount.Text = "# " + elements.Count();
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
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "BindGrid", "<script type='text/javascript'>$('.datepicker').datepicker({ dateFormat: 'dd-MM-yyyy' }); </script>", false);

                gridViajes.UseAccessibleHeader = true;
                gridViajes.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        public void BindGrid_ViajesEnCurso()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var elements = context.viajes.Where(e => e.EnViaje == true).OrderByDescending(e => e.Fecha_partida).ToList();
                if (elements.Count() > 0)
                {
                    gridViajesEnCurso.DataSource = elements;
                    gridViajesEnCurso.DataBind();

                    lblGridViajesEnCursoCount.Text = "# " + elements.Count();
                }
                else
                {
                    var obj = new List<viaje>();
                    obj.Add(new viaje());

                    /* Grid Viajes */

                    // Bind the DataTable which contain a blank row to the GridView
                    gridViajesEnCurso.DataSource = obj;
                    gridViajesEnCurso.DataBind();
                    int columnsCount = gridViajes.Columns.Count;
                    gridViajesEnCurso.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridViajesEnCurso.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridViajesEnCurso.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridViajesEnCurso.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridViajesEnCurso.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridViajesEnCurso.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    gridViajesEnCurso.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "BindGrid_EnCurso", "<script type='text/javascript'>bindEvents(); </script>", false);

                gridViajesEnCurso.UseAccessibleHeader = true;
                gridViajesEnCurso.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        #endregion Events

        #region Private methods

        private static decimal CalcularPrecioCompra(int viaje_ID)
        {
            decimal ret = 0;
            if (viaje_ID > 0)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    decimal totalCostos = 0;
                    //decimal totalPrecios = 0;

                    decimal peso_neto_origen = 0;
                    decimal peso_neto_destino = 0;

                    var elements = context.mercaderia_comprada.Where(m => m.Viaje_ID == viaje_ID).ToList();
                    if (elements.Count() > 0)
                    {
                        foreach (mercaderia_comprada mercaderia in elements)
                        {
                            totalCostos += mercaderia.Precio_xTonelada_compra;
                            //totalPrecios += mercaderia.Precio_xTonelada_venta;
                        }
                    }

                    viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                    if (viaje != null)
                    {
                        int pesada_origen_ID = viaje.Pesada_origen_ID;
                        if (pesada_origen_ID > 0)
                        {
                            pesada pesada_origen = (pesada)context.pesadas.FirstOrDefault(v => v.pesada_ID == pesada_origen_ID);
                            if (pesada_origen != null)
                            {
                                peso_neto_origen = pesada_origen.Peso_neto;
                            }
                        }

                        int pesada_destino_ID = viaje.Pesada_destino_ID;
                        if (pesada_destino_ID > 0)
                        {
                            pesada pesada_destino = (pesada)context.pesadas.FirstOrDefault(v => v.pesada_ID == pesada_destino_ID);
                            if (pesada_destino != null)
                            {
                                peso_neto_destino = pesada_destino.Peso_neto;
                            }
                        }

                        if (peso_neto_destino == 0)
                        {
                            peso_neto_destino = peso_neto_origen;
                        }

                        decimal precio_compra = peso_neto_destino * totalCostos;
                        viaje.precio_compra = precio_compra;
                        ret = precio_compra;

                        #region Log

                        //log new_log = new log();
                        //new_log.Usuario_ID = 0;
                        //new_log.Fecha = DateTime.Now;
                        ////new_log.Descripcion="Nuevo pago: " + pago
                        //context.logs.Add(new_log);

                        context.SaveChanges();

                        #endregion
                    }
                }
            }
            return ret;
        }

        #endregion Private methods

        #region Web methods

        [WebMethod]
        public static bool GuardarPrecioVenta(string viajeID, string precioFlete_str, string precioDescarga_str, string gananciaXTon_str,
            string IVA_str, string precio_venta_str)
        {
            bool save_ok = false;
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                if (!string.IsNullOrWhiteSpace(viajeID) && !string.IsNullOrWhiteSpace(precioFlete_str) && !string.IsNullOrWhiteSpace(precioDescarga_str) && !string.IsNullOrWhiteSpace(gananciaXTon_str) &&
                    !string.IsNullOrWhiteSpace(IVA_str) && !string.IsNullOrWhiteSpace(precio_venta_str))
                {
                    int viajeID_value = 0;
                    if (!int.TryParse(viajeID, out viajeID_value))
                    {
                        viajeID_value = 0;
                    }

                    if (viajeID_value > 0)
                    {
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viajeID_value);
                        if (viaje != null)
                        {
                            decimal precioFlete = 0;
                            if (!decimal.TryParse(precioFlete_str, NumberStyles.Number, CultureInfo.InvariantCulture, out precioFlete))
                            {
                                precioFlete = 0;
                            }

                            decimal precioDescarga = 0;
                            if (!decimal.TryParse(precioDescarga_str, NumberStyles.Number, CultureInfo.InvariantCulture, out precioDescarga))
                            {
                                precioDescarga = 0;
                            }

                            decimal gananciaXTon = 0;
                            if (!decimal.TryParse(gananciaXTon_str, NumberStyles.Number, CultureInfo.InvariantCulture, out gananciaXTon))
                            {
                                gananciaXTon = 0;
                            }

                            int IVA = 0;
                            if (!int.TryParse(IVA_str, NumberStyles.Number, CultureInfo.InvariantCulture, out IVA))
                            {
                                IVA = 0;
                            }

                            decimal precio_venta = 0;
                            if (!decimal.TryParse(precio_venta_str, NumberStyles.Number, CultureInfo.InvariantCulture, out precio_venta))
                            {
                                precio_venta = 0;
                            }
                            if (precio_venta > 0)
                            {
                                viaje.precio_venta = precio_venta;

                                viaje.precio_flete = precioFlete;
                                viaje.precio_descarga = precioDescarga;
                                viaje.GananciaXTon = gananciaXTon;
                                viaje.IVA = IVA;

                                #region Log

                                //log new_log = new log();
                                //new_log.Usuario_ID = 0;
                                //new_log.Fecha = DateTime.Now;
                                ////new_log.Descripcion="Nuevo pago: " + pago
                                //context.logs.Add(new_log);

                                #endregion

                                context.SaveChanges();

                                save_ok = true;
                            }
                        }

                    }
                }
            }
            return save_ok;
        }

        [WebMethod]
        public static string GuardarPesadas(string viajeID_str, int isOrigen, string pesadaID_str, string txb_pesadaLugar_str,
            string txb_pesadaFecha_str, string txb_pesadaPeso_bruto_str, string txb_pesadaPeso_neto_str, string txb_pesadaNombre_str,
            string txb_pesadaComentarios_str)
        {
            bool save_ok = false;
            decimal precio_compra = 0;

            if (!string.IsNullOrWhiteSpace(viajeID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = 0;
                    if (!int.TryParse(viajeID_str, out viaje_ID))
                    {
                        viaje_ID = 0;
                    }

                    int pesada_ID = 0;
                    if (!int.TryParse(pesadaID_str, out pesada_ID))
                    {
                        pesada_ID = 0;
                    }

                    if (viaje_ID > 0)
                    {
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                        if (viaje != null)
                        {
                            if (isOrigen == 1)
                            {
                                #region Pesada origen

                                if (pesada_ID > 0)
                                {
                                    pesada pesada = (pesada)context.pesadas.FirstOrDefault(v => v.pesada_ID == pesada_ID);
                                    if (pesada != null)
                                    {
                                        // Ya existe
                                        pesada.Lugar = txb_pesadaLugar_str;
                                        pesada.Nombre_balanza = txb_pesadaNombre_str;
                                        pesada.Comentarios = txb_pesadaComentarios_str;

                                        DateTime date = pesada.Fecha;
                                        if (!DateTime.TryParseExact(txb_pesadaFecha_str, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                                        {
                                            date = pesada.Fecha;
                                        }
                                        pesada.Fecha = date;

                                        decimal value = pesada.Peso_bruto;
                                        if (!decimal.TryParse(txb_pesadaPeso_bruto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                                        {
                                            value = pesada.Peso_bruto;
                                        }
                                        pesada.Peso_bruto = value;

                                        value = pesada.Peso_neto;
                                        if (!decimal.TryParse(txb_pesadaPeso_neto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                                        {
                                            value = pesada.Peso_neto;
                                        }
                                        pesada.Peso_neto = value;

                                        #region Log

                                        //log new_log = new log();
                                        //new_log.Usuario_ID = 0;
                                        //new_log.Fecha = DateTime.Now;
                                        ////new_log.Descripcion="Nuevo pago: " + pago
                                        //context.logs.Add(new_log);

                                        #endregion

                                        context.SaveChanges();

                                        save_ok = true;
                                    }
                                }
                                else
                                {
                                    // No existe
                                    pesada pesada = new pesada();

                                    pesada.Lugar = txb_pesadaLugar_str;
                                    pesada.Nombre_balanza = txb_pesadaNombre_str;
                                    pesada.Comentarios = txb_pesadaComentarios_str;

                                    DateTime date = pesada.Fecha;
                                    if (!DateTime.TryParseExact(txb_pesadaFecha_str, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                                    {
                                        date = pesada.Fecha;
                                    }
                                    pesada.Fecha = date;

                                    decimal value = pesada.Peso_bruto;
                                    if (!decimal.TryParse(txb_pesadaPeso_bruto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                                    {
                                        value = pesada.Peso_bruto;
                                    }
                                    pesada.Peso_bruto = value;

                                    value = pesada.Peso_neto;
                                    if (!decimal.TryParse(txb_pesadaPeso_neto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                                    {
                                        value = pesada.Peso_neto;
                                    }
                                    pesada.Peso_neto = value;

                                    context.pesadas.Add(pesada);

                                    #region Log

                                    //log new_log = new log();
                                    //new_log.Usuario_ID = 0;
                                    //new_log.Fecha = DateTime.Now;
                                    ////new_log.Descripcion="Nuevo pago: " + pago
                                    //context.logs.Add(new_log);

                                    #endregion

                                    context.SaveChanges();

                                    int id = 1;
                                    pesada max_pesada = (pesada)context.pesadas.OrderByDescending(p => p.pesada_ID).FirstOrDefault();
                                    if (max_pesada != null)
                                    {
                                        id = max_pesada.pesada_ID;
                                    }
                                    viaje.Pesada_origen_ID = id;
                                    context.SaveChanges();

                                    save_ok = true;
                                }

                                #endregion Pesada origen
                            }
                            else
                            {
                                #region Pesada destino

                                if (pesada_ID > 0)
                                {
                                    pesada pesada = (pesada)context.pesadas.FirstOrDefault(v => v.pesada_ID == pesada_ID);
                                    if (pesada != null)
                                    {
                                        // Ya existe
                                        pesada.Lugar = txb_pesadaLugar_str;
                                        pesada.Nombre_balanza = txb_pesadaNombre_str;
                                        pesada.Comentarios = txb_pesadaComentarios_str;

                                        DateTime date = pesada.Fecha;
                                        if (!DateTime.TryParseExact(txb_pesadaFecha_str, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                                        {
                                            date = pesada.Fecha;
                                        }
                                        pesada.Fecha = date;

                                        decimal value = pesada.Peso_bruto;
                                        if (!decimal.TryParse(txb_pesadaPeso_bruto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                                        {
                                            value = pesada.Peso_bruto;
                                        }
                                        pesada.Peso_bruto = value;

                                        value = pesada.Peso_neto;
                                        if (!decimal.TryParse(txb_pesadaPeso_neto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                                        {
                                            value = pesada.Peso_neto;
                                        }
                                        pesada.Peso_neto = value;

                                        #region Log

                                        //log new_log = new log();
                                        //new_log.Usuario_ID = 0;
                                        //new_log.Fecha = DateTime.Now;
                                        ////new_log.Descripcion="Nuevo pago: " + pago
                                        //context.logs.Add(new_log);

                                        #endregion

                                        context.SaveChanges();

                                        save_ok = true;
                                    }
                                }
                                else
                                {
                                    // No existe
                                    pesada pesada = new pesada();

                                    pesada.Lugar = txb_pesadaLugar_str;
                                    pesada.Nombre_balanza = txb_pesadaNombre_str;
                                    pesada.Comentarios = txb_pesadaComentarios_str;

                                    DateTime date = pesada.Fecha;
                                    if (!DateTime.TryParseExact(txb_pesadaFecha_str, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                                    {
                                        date = pesada.Fecha;
                                    }
                                    pesada.Fecha = date;

                                    decimal value = pesada.Peso_bruto;
                                    if (!decimal.TryParse(txb_pesadaPeso_bruto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                                    {
                                        value = pesada.Peso_bruto;
                                    }
                                    pesada.Peso_bruto = value;

                                    value = pesada.Peso_neto;
                                    if (!decimal.TryParse(txb_pesadaPeso_neto_str, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                                    {
                                        value = pesada.Peso_neto;
                                    }
                                    pesada.Peso_neto = value;

                                    context.pesadas.Add(pesada);
                                    context.SaveChanges();

                                    int id = 1;
                                    pesada max_pesada = (pesada)context.pesadas.OrderByDescending(p => p.pesada_ID).FirstOrDefault();
                                    if (max_pesada != null)
                                    {
                                        id = max_pesada.pesada_ID;
                                    }
                                    viaje.Pesada_destino_ID = id;
                                    context.SaveChanges();

                                    save_ok = true;
                                }

                                #endregion Pesada destino
                            }

                            if (save_ok)
                            {
                                precio_compra = CalcularPrecioCompra(viaje_ID);
                            }
                        }
                    }
                }
            }
            return save_ok.ToString() + "|" + precio_compra;
        }

        [WebMethod]
        public static bool Check_Mercaderias(string viajeID_str)
        {
            bool check_ok = false;
            if (!string.IsNullOrWhiteSpace(viajeID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = 0;
                    if (!int.TryParse(viajeID_str, out viaje_ID))
                    {
                        viaje_ID = 0;
                    }

                    if (viaje_ID > 0)
                    {
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                        if (viaje != null)
                        {
                            check_ok = context.mercaderia_comprada.Where(m => m.Viaje_ID == viaje_ID).ToList().Count > 0;
                        }
                    }
                }
            }
            return check_ok;
        }

        [WebMethod]
        public static bool Check_Pesadas(string viajeID_str)
        {
            bool check_ok = false;
            if (!string.IsNullOrWhiteSpace(viajeID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = 0;
                    if (!int.TryParse(viajeID_str, out viaje_ID))
                    {
                        viaje_ID = 0;
                    }

                    if (viaje_ID > 0)
                    {
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                        if (viaje != null)
                        {
                            check_ok = viaje.Pesada_origen_ID > 0 && viaje.Pesada_destino_ID > 0;
                        }
                    }
                }
            }
            return check_ok;
        }

        [WebMethod]
        public static int FinDelViaje(string viajeID_str)
        {
            int result = 0;
            bool ok = false;

            /* 0- Error
             * 1- OK_FINViaje
             * 2- Error_DatosMercaderias
             * 3- Error_DatosPesadas
             * 4- Error_DatosPrecioVenta
             * */

            if (!string.IsNullOrWhiteSpace(viajeID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = 0;
                    if (!int.TryParse(viajeID_str, out viaje_ID))
                    {
                        viaje_ID = 0;
                    }

                    if (viaje_ID > 0)
                    {
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                        if (viaje != null)
                        {
                            // Check si tiene Mercaderías
                            var elements = context.mercaderia_comprada.Where(m => m.Viaje_ID == viaje_ID).ToList();
                            if (elements.Count() > 0)
                            {
                                ok = true;
                                result = 1;
                            }
                            else
                            {
                                result = 2;
                            }
                            if (ok)
                            {
                                // Check si tiene Pesadas origen y destino
                                if (viaje.Pesada_origen_ID == 0 || viaje.Pesada_destino_ID == 0)
                                {
                                    ok = false;
                                    result = 3;
                                }
                            }
                            if (ok)
                            {
                                // Check si tiene Precio de venta calculado
                                if (viaje.precio_venta == 0)
                                {
                                    ok = false;
                                    result = 4;
                                }
                            }

                            if (ok)
                            {
                                viaje.EnViaje = false;

                                #region Log

                                //log new_log = new log();
                                //new_log.Usuario_ID = 0;
                                //new_log.Fecha = DateTime.Now;
                                ////new_log.Descripcion="Nuevo pago: " + pago
                                //context.logs.Add(new_log);

                                #endregion

                                context.SaveChanges();

                                result = 1;
                            }

                        }
                    }
                }
            }
            return result;
        }

        [WebMethod]
        public static int BorrarViajeEnCurso(string viajeID_str, string userID, string clave_str)
        {
            int resultado = 0;
            if (!string.IsNullOrWhiteSpace(viajeID_str) && !string.IsNullOrWhiteSpace(userID) && !string.IsNullOrWhiteSpace(clave_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = 0;
                    if (!int.TryParse(viajeID_str, out viaje_ID))
                    {
                        viaje_ID = 0;
                    }

                    if (viaje_ID > 0)
                    {
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                        if (viaje != null)
                        {
                            int userID_int = 0;
                            if(!int.TryParse(userID, out userID_int))
                            {
                                userID_int = 0;
                            }
                            if (userID_int > 0)
                            {
                                // Check usuario
                                usuario usuario = (usuario)context.usuarios.FirstOrDefault(v => v.Usuario_ID == userID_int);
                                if (usuario != null)
                                {
                                    if (usuario.Clave.ToLowerInvariant().Equals(clave_str.ToLowerInvariant()))
                                    {
                                        resultado = 1; // OK

                                        context.viajes.Remove(viaje);

                                        #region Log

                                        //log new_log = new log();
                                        //new_log.Usuario_ID = 0;
                                        //new_log.Fecha = DateTime.Now;
                                        ////new_log.Descripcion="Nuevo pago: " + pago
                                        //context.logs.Add(new_log);

                                        #endregion

                                        context.SaveChanges();
                                    }
                                    else
                                    {
                                        resultado = 2; // Error clave

                                    }
                                }
                                else
                                {
                                    resultado = 3; // Error usuario
                                }
                            }
                        }
                    }
                }
            }
            return resultado;
        }

        [WebMethod]
        public static string ModificarViaje_1(string viajeID_str)
        {
            string ret = string.Empty;
            if (!string.IsNullOrWhiteSpace(viajeID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = 0;
                    if (!int.TryParse(viajeID_str, out viaje_ID))
                    {
                        viaje_ID = 0;
                    }

                    if (viaje_ID > 0)
                    {
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                        if (viaje != null)
                        {
                            ret = viaje.Fecha_partida.ToShortDateString() + "|" + viaje.Fecha_llegada.ToShortDateString() + "|" + viaje.Proveedor_ID + "|" + viaje.Cliente_ID + "|" + viaje.Empresa_de_carga_ID + "|" + viaje.Carga + "|" + viaje.Fletero_ID + "|" + viaje.Camion_ID + "|" + viaje.Chofer_ID + "|" + viaje.Comentarios;
                        }
                    }
                }
            }
            return ret;
        }

        [WebMethod]
        public static bool ModificarViaje_2(string viajeID_str, string fecha1, string fecha2, string proveedor, string cliente, string cargador,
            string lugar_carga, string fletero, string camion, string chofer, string comentarios)
        {
            bool ret = false;
            if (!string.IsNullOrWhiteSpace(viajeID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = 0;
                    if (!int.TryParse(viajeID_str, out viaje_ID))
                    {
                        viaje_ID = 0;
                    }

                    if (viaje_ID > 0)
                    {
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                        if (viaje != null)
                        {
                            DateTime date1 = viaje.Fecha_partida;
                            if (!DateTime.TryParseExact(fecha1, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                            {
                                date1 = viaje.Fecha_partida;
                            }
                            viaje.Fecha_partida = date1;

                            DateTime date2 = viaje.Fecha_llegada;
                            if (!DateTime.TryParseExact(fecha2, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                            {
                                date2 = viaje.Fecha_llegada;
                            }
                            viaje.Fecha_llegada = date2;

                            #region DDL logic

                            int ddl = viaje.Proveedor_ID;
                            if (!int.TryParse(proveedor, out ddl))
                            {
                                ddl = viaje.Proveedor_ID;
                            }
                            viaje.Proveedor_ID = ddl;

                            ddl = viaje.Cliente_ID;
                            if (!int.TryParse(cliente, out ddl))
                            {
                                ddl = viaje.Cliente_ID;
                            }
                            viaje.Cliente_ID = ddl;

                            ddl = viaje.Empresa_de_carga_ID;
                            if (!int.TryParse(cargador, out ddl))
                            {
                                ddl = viaje.Empresa_de_carga_ID;
                            }
                            viaje.Empresa_de_carga_ID = ddl;

                            ddl = viaje.Fletero_ID;
                            if (!int.TryParse(fletero, out ddl))
                            {
                                ddl = viaje.Fletero_ID;
                            }
                            viaje.Fletero_ID = ddl;

                            ddl = viaje.Camion_ID;
                            if (!int.TryParse(camion, out ddl))
                            {
                                ddl = viaje.Camion_ID;
                            }
                            viaje.Camion_ID = ddl;

                            ddl = viaje.Chofer_ID;
                            if (!int.TryParse(chofer, out ddl))
                            {
                                ddl = viaje.Chofer_ID;
                            }
                            viaje.Chofer_ID = ddl;

                            #endregion DDL logic

                            viaje.Carga = lugar_carga;
                            viaje.Descarga = string.Empty;
                            viaje.Comentarios = comentarios;

                            #region Log

                            //log new_log = new log();
                            //new_log.Usuario_ID = 0;
                            //new_log.Fecha = DateTime.Now;
                            ////new_log.Descripcion="Nuevo pago: " + pago
                            //context.logs.Add(new_log);

                            #endregion

                            context.SaveChanges();

                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        [WebMethod]
        public static bool NuevoViaje(string fecha1, string fecha2, string proveedor, string cliente, string cargador,
           string lugar_carga, string fletero, string camion, string chofer, string comentarios)
        {
            bool ret = false;
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                viaje new_viaje = new viaje();

                DateTime date1 = DateTime.Now;
                if (!DateTime.TryParseExact(fecha1, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
                {
                    date1 = DateTime.Now;
                }
                new_viaje.Fecha_partida = date1;

                DateTime date2 = DateTime.Now;
                if (!DateTime.TryParseExact(fecha2, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date2))
                {
                    date2 = DateTime.Now;
                }
                new_viaje.Fecha_llegada = date2;

                #region DDL logic

                int ddl = 0;
                if (!int.TryParse(proveedor, out ddl))
                {
                    ddl = 0;
                }
                new_viaje.Proveedor_ID = ddl;

                ddl = 0;
                if (!int.TryParse(cliente, out ddl))
                {
                    ddl = 0;
                }
                new_viaje.Cliente_ID = ddl;

                ddl = 0;
                if (!int.TryParse(cargador, out ddl))
                {
                    ddl = 0;
                }
                new_viaje.Empresa_de_carga_ID = ddl;

                ddl = 0;
                if (!int.TryParse(fletero, out ddl))
                {
                    ddl = 0;
                }
                new_viaje.Fletero_ID = ddl;

                ddl = 0;
                if (!int.TryParse(camion, out ddl))
                {
                    ddl = 0;
                }
                new_viaje.Camion_ID = ddl;

                ddl = 0;
                if (!int.TryParse(chofer, out ddl))
                {
                    ddl = 0;
                }
                new_viaje.Chofer_ID = ddl;

                #endregion DDL logic

                new_viaje.Carga = lugar_carga;
                new_viaje.Descarga = string.Empty;
                new_viaje.Comentarios = comentarios;
                new_viaje.EnViaje = true;

                new_viaje.Fecha_registro = DateTime.Now;

                context.viajes.Add(new_viaje);

                #region Log

                //log new_log = new log();
                //new_log.Usuario_ID = 0;
                //new_log.Fecha = DateTime.Now;
                ////new_log.Descripcion="Nuevo pago: " + pago
                //context.logs.Add(new_log);

                #endregion

                context.SaveChanges();

                ret = true;
            }
            return ret;
        }

        [WebMethod]
        public static string NotificarViaje(string viajeID_str)
        {
            string ret = string.Empty;
            if (!string.IsNullOrWhiteSpace(viajeID_str))
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = 0;
                    if (!int.TryParse(viajeID_str, out viaje_ID))
                    {
                        viaje_ID = 0;
                    }

                    if (viaje_ID > 0)
                    {
                        viaje viaje = (viaje)context.viajes.FirstOrDefault(v => v.Viaje_ID == viaje_ID);
                        if (viaje != null)
                        {
                            #region Cargar datos

                            // Precio compra
                            ret = viaje.precio_compra.ToString() + "|";

                            // Pesada origen
                            int pesada_origen_ID = viaje.Pesada_origen_ID;
                            ret += pesada_origen_ID.ToString();

                            if (pesada_origen_ID > 0)
                            {
                                pesada pesada_origen = (pesada)context.pesadas.FirstOrDefault(v => v.pesada_ID == pesada_origen_ID);
                                if (pesada_origen != null)
                                {
                                    //hdn_notificacionesPesadaOrigenID.Value = pesada_origen_ID.ToString();

                                    // Fields
                                    ret += "&" + pesada_origen.Lugar;
                                    ret += "&" + pesada_origen.Fecha.ToShortDateString();
                                    ret += "&" + pesada_origen.Nombre_balanza;
                                    ret += "&" + pesada_origen.Peso_bruto.ToString();
                                    ret += "&" + pesada_origen.Peso_neto.ToString();
                                    ret += "&" + pesada_origen.Comentarios;
                                }
                            }

                            ret += "|";

                            // Pesada destino
                            int pesada_destino_ID = viaje.Pesada_destino_ID;
                            ret += pesada_destino_ID.ToString();
                            if (pesada_destino_ID > 0)
                            {
                                pesada pesada_destino = (pesada)context.pesadas.FirstOrDefault(v => v.pesada_ID == pesada_origen_ID);
                                if (pesada_destino != null)
                                {
                                    ret += pesada_destino_ID.ToString();
                                    //hdn_notificacionesPesadaOrigenID.Value = pesada_origen_ID.ToString();

                                    // Fields
                                    ret += "&" + pesada_destino.Lugar;
                                    ret += "&" + pesada_destino.Fecha.ToShortDateString();
                                    ret += "&" + pesada_destino.Nombre_balanza;
                                    ret += "&" + pesada_destino.Peso_bruto.ToString();
                                    ret += "&" + pesada_destino.Peso_neto.ToString();
                                    ret += "&" + pesada_destino.Comentarios;
                                }
                            }

                            // Venta
                            ret += "|" + viaje.precio_flete.ToString();
                            ret += "&" + viaje.precio_descarga.ToString();
                            ret += "&" + viaje.GananciaXTon.ToString();
                            ret += "&" + viaje.IVA.ToString();
                            ret += "&" + viaje.precio_venta.ToString();

                            #endregion

                        }
                    }
                }
            }
            return ret;
        }

        #endregion Web methods

    }
}

