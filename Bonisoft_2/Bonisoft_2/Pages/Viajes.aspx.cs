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

                BindGrid_2();
            }
            lblMessage.Text = "";
        }

        void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var elements = context.viajes.Where(e => e.EnViaje == false).ToList();
                if (elements.Count() > 0)
                {
                    grdViajes.DataSource = context.viajes.ToList();
                    grdViajes.DataBind();
                }
                else
                {
                    var obj = new List<viaje>();
                    obj.Add(new viaje());

                    /* Grid Viajes */

                    // Bind the DataTable which contain a blank row to the GridView
                    grdViajes.DataSource = obj;
                    grdViajes.DataBind();
                    int columnsCount = grdViajes.Columns.Count;
                    grdViajes.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdViajes.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdViajes.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    grdViajes.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdViajes.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdViajes.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdViajes.Rows[0].Cells[0].Text = "No hay registros";
                }
            }
        }

        protected void gridSample_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                    ddl.DataTextField = "Apellidos";
                    ddl.DataValueField = "Chofer_ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Empresa_de_carga_ID.ToString();
                }
            }

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

            ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("ddlEmpresas1") as DropDownList;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ddl = e.Row.FindControl("ddlEmpresas2") as DropDownList;
            }
            if (ddl != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    var elements = context.proveedores.Select(c => new { ID = c.Proveedor_ID, DisplayText = "Proveedor: " + c.Nombre_fantasia.ToString() }).ToList();
                    elements.AddRange(context.clientes.Select(c => new { ID = c.cliente_ID, DisplayText = "Cliente: " + c.Nombre_fantasia.ToString() }).ToList());

                    ddl.DataSource = elements;
                    ddl.DataTextField = "DisplayText";
                    ddl.DataValueField = "ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Elegir"));

                }//Add Default Item in the DropDownList
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddl.SelectedValue = ((viaje)(e.Row.DataItem)).Empresa_de_carga_ID.ToString();
                }
            }

        }

        protected void gridSample_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = grdViajes.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                TextBox txb7 = row.FindControl("txbNew7") as TextBox;
                TextBox txb8 = row.FindControl("txbNew8") as TextBox;
                TextBox txb9 = row.FindControl("txbNew9") as TextBox;
                TextBox txb11 = row.FindControl("txbNew11") as TextBox;
                TextBox txb12 = row.FindControl("txbNew12") as TextBox;
                TextBox txb15 = row.FindControl("txbNew15") as TextBox;
                DropDownList ddlFormas2 = row.FindControl("ddlFormas2") as DropDownList;
                DropDownList ddlEmpresas2 = row.FindControl("ddlEmpresas2") as DropDownList;
                DropDownList ddlCamiones2 = row.FindControl("ddlCamiones2") as DropDownList;
                DropDownList ddlChoferes2 = row.FindControl("ddlChoferes2") as DropDownList;

                if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb6 != null && txb7 != null && ddlChoferes2 != null && txb15 != null &&
                    txb8 != null && txb9 != null && ddlFormas2 != null && txb11 != null && txb12 != null && txb3 != null && ddlEmpresas2 != null && ddlCamiones2 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje obj = new viaje();
                        obj.Fecha_partida = DateTime.Parse(txb11.Text);
                        obj.Fecha_llegada = DateTime.Parse(txb12.Text);
                        obj.Precio_compra_por_tonelada = decimal.Parse(txb1.Text);
                        obj.Precio_valor_total = decimal.Parse(txb2.Text);
                        obj.Importe_viaje = decimal.Parse(txb3.Text);
                        obj.Saldo = decimal.Parse(txb4.Text);
                        obj.Carga = txb6.Text;
                        obj.Descarga = txb7.Text;
                        obj.Pesada_origen_ID = int.Parse(txb8.Text);
                        obj.Pesada_destino_ID = int.Parse(txb9.Text);
                        obj.Comentarios = txb15.Text;

                        obj.Empresa_de_carga_ID = Convert.ToInt32(ddlEmpresas2.SelectedValue);
                        obj.Camion_ID = Convert.ToInt32(ddlCamiones2.SelectedValue);
                        obj.Chofer_ID = Convert.ToInt32(ddlChoferes2.SelectedValue);
                        obj.Forma_de_pago_ID = Convert.ToInt32(ddlFormas2.SelectedValue);

                        bool isClient = false;
                        string selectedText = ddlEmpresas2.SelectedItem.Text;
                        if (!string.IsNullOrWhiteSpace(selectedText))
                        {
                            isClient = selectedText.Contains("Cliente");
                        }
                        obj.Empresa_esCliente = isClient;

                        context.viajes.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }

            else
            {
                BindGrid();
            }
        }

        protected void gridSample_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdViajes.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gridSample_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdViajes.EditIndex = -1;
            BindGrid();
        }

        protected void gridSample_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdViajes.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            TextBox txb8 = row.FindControl("txb8") as TextBox;
            TextBox txb9 = row.FindControl("txb9") as TextBox;
            TextBox txb11 = row.FindControl("txb11") as TextBox;
            TextBox txb12 = row.FindControl("txb12") as TextBox;
            TextBox txb15 = row.FindControl("txb15") as TextBox;
            DropDownList ddlFormas2 = row.FindControl("ddlFormas2") as DropDownList;
            DropDownList ddlEmpresas2 = row.FindControl("ddlEmpresas2") as DropDownList;
            DropDownList ddlCamiones2 = row.FindControl("ddlCamiones2") as DropDownList;
            DropDownList ddlChoferes2 = row.FindControl("ddlChoferes2") as DropDownList;

            if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb6 != null && txb7 != null && ddlChoferes2 != null && txb15 != null &&
                txb8 != null && txb9 != null && ddlFormas2 != null && txb11 != null && txb12 != null && txb3 != null && ddlEmpresas2 != null && ddlCamiones2 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = Convert.ToInt32(grdViajes.DataKeys[e.RowIndex].Value);
                    viaje obj = context.viajes.First(x => x.Viaje_ID == viaje_ID);
                    obj.Precio_compra_por_tonelada = decimal.Parse(txb1.Text);
                    obj.Precio_valor_total = decimal.Parse(txb2.Text);
                    obj.Importe_viaje = decimal.Parse(txb3.Text);
                    obj.Saldo = decimal.Parse(txb4.Text);
                    obj.Carga = txb6.Text;
                    obj.Descarga = txb7.Text;
                    obj.Pesada_origen_ID = int.Parse(txb8.Text);
                    obj.Pesada_destino_ID = int.Parse(txb9.Text);
                    obj.Comentarios = txb15.Text;
                    obj.Fecha_partida = DateTime.Parse(txb11.Text);
                    obj.Fecha_llegada = DateTime.Parse(txb12.Text);

                    obj.Empresa_de_carga_ID = Convert.ToInt32(ddlEmpresas2.SelectedValue);
                    obj.Camion_ID = Convert.ToInt32(ddlCamiones2.SelectedValue);
                    obj.Chofer_ID = Convert.ToInt32(ddlChoferes2.SelectedValue);
                    obj.Forma_de_pago_ID = Convert.ToInt32(ddlFormas2.SelectedValue);

                    bool isClient = false;
                    string selectedText = ddlEmpresas2.SelectedItem.Text;
                    if (!string.IsNullOrWhiteSpace(selectedText))
                    {
                        isClient = selectedText.Contains("Cliente");
                    }
                    obj.Empresa_esCliente = isClient;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    grdViajes.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int viaje_ID = Convert.ToInt32(grdViajes.DataKeys[e.RowIndex].Value);
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
            GridViewRow pagerRow = grdViajes.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            grdViajes.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        public void BindGrid_2()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                var elements = context.viajes.Where(e => e.EnViaje == true).ToList();
                if (elements.Count() > 0)
                {
                    GridView1.DataSource = context.viajes.ToList();
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int viaje_ID = int.Parse(GridView1.DataKeys[index].Value.ToString());
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                if (e.CommandName.Equals("detail"))
                {
                    var elements = context.viajes.Where(v => v.Viaje_ID == viaje_ID).ToList();
                    if (elements.Count > 0)
                    {
                        GridView1.DataSource = elements;
                        GridView1.DataBind();

                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script type='text/javascript'>");
                        sb.Append("$('#detailModal').modal('show');");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
                    }
                }
                else if (e.CommandName.Equals("editRecord"))
                {
                    GridViewRow gvrow = GridView1.Rows[index];
                    lblCountryCode.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
                    txtPopulation.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                    lblResult.Visible = false;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#editModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);

                }
                else if (e.CommandName.Equals("deleteRecord"))
                {
                    hfCode.Value = viaje_ID.ToString();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#deleteModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
                }

            }
        }


        protected void btnSave_Click_2(object sender, EventArgs e)
        {
            int viaje_ID = int.Parse(lblCountryCode.Text);
            string comentarios = txtPopulation.Text;
            executeUpdate(viaje_ID, comentarios);
            BindGrid_2();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Records Updated Successfully');");
            sb.Append("$('#editModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

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

        protected void btnAddRecord_Click(object sender, EventArgs e)
        {
            string comentarios = txtCountryName.Text;
            executeAdd(comentarios);
            BindGrid_2();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Record Added Successfully');");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);


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
            BindGrid_2();
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
    }
}