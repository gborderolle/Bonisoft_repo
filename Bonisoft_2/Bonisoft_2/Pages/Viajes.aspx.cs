using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Viajes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
        }

        void BindGrid()
        {
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                if (context.viajes.Count() > 0)
                {
                    gridSample.DataSource = context.viajes.ToList();
                    gridSample.DataBind();
                }
                else
                {
                    var obj = new List<viaje>();
                    obj.Add(new viaje());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridSample.DataSource = obj;
                    gridSample.DataBind();
                    int columnsCount = gridSample.Columns.Count;
                    gridSample.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridSample.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridSample.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridSample.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridSample.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridSample.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridSample.Rows[0].Cells[0].Text = "No hay registros";
                }
            }
        }

        protected void gridSample_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }


        protected void gridSample_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridSample.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;
                TextBox txb4 = row.FindControl("txbNew4") as TextBox;
                TextBox txb5 = row.FindControl("txbNew5") as TextBox;
                TextBox txb6 = row.FindControl("txbNew6") as TextBox;
                TextBox txb7 = row.FindControl("txbNew7") as TextBox;
                TextBox txb8 = row.FindControl("txbNew8") as TextBox;
                TextBox txb9 = row.FindControl("txbNew9") as TextBox;
                TextBox txb10 = row.FindControl("txbNew10") as TextBox;
                TextBox txb11 = row.FindControl("txbNew11") as TextBox;
                TextBox txb12 = row.FindControl("txbNew12") as TextBox;
                TextBox txb13 = row.FindControl("txbNew13") as TextBox;
                TextBox txb14 = row.FindControl("txbNew14") as TextBox;
                TextBox txb15 = row.FindControl("txbNew15") as TextBox;
                if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb5 != null && txb6 != null && txb7 != null &&
                    txb8 != null && txb9 != null && txb10 != null && txb11 != null && txb12 != null && txb3 != null && txb14 != null && txb15 != null)
                {
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        viaje obj = new viaje();
                        obj.Precio_compra_por_tonelada = decimal.Parse(txb1.Text);
                        obj.Precio_valor_total = decimal.Parse(txb2.Text);
                        obj.Importe_viaje = decimal.Parse(txb3.Text);
                        obj.Saldo = decimal.Parse(txb4.Text);
                        obj.Forma_de_pago_ID = int.Parse(txb5.Text);
                        obj.Carga_ID = int.Parse(txb6.Text);
                        obj.Descarga_ID = int.Parse(txb7.Text);
                        obj.Pesada_origen_ID = int.Parse(txb8.Text);
                        obj.Pesada_destino_ID = int.Parse(txb9.Text);
                        obj.Empresa_de_carga_ID = int.Parse(txb4.Text);
                        obj.Fecha_partida = DateTime.Parse(txb5.Text);
                        obj.Fecha_llegada = DateTime.Parse(txb6.Text);
                        obj.Camion_ID = int.Parse(txb7.Text);
                        obj.Chofer_ID = int.Parse(txb8.Text);
                        obj.Comentarios = txb9.Text;


                        context.viajes.Add(obj);
                        context.SaveChanges();
                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
            }
        }

        protected void gridSample_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridSample.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridSample_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridSample.EditIndex = -1;
            BindGrid();
        }
        protected void gridSample_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridSample.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            TextBox txb4 = row.FindControl("txb4") as TextBox;
            TextBox txb5 = row.FindControl("txb5") as TextBox;
            TextBox txb6 = row.FindControl("txb6") as TextBox;
            TextBox txb7 = row.FindControl("txb7") as TextBox;
            TextBox txb8 = row.FindControl("txb8") as TextBox;
            TextBox txb9 = row.FindControl("txb9") as TextBox;
            TextBox txb10 = row.FindControl("txb10") as TextBox;
            TextBox txb11 = row.FindControl("txb11") as TextBox;
            TextBox txb12 = row.FindControl("txb12") as TextBox;
            TextBox txb13 = row.FindControl("txb13") as TextBox;
            TextBox txb14 = row.FindControl("txb14") as TextBox;
            TextBox txb15 = row.FindControl("txb15") as TextBox;
            if (txb1 != null && txb2 != null && txb3 != null && txb4 != null && txb5 != null && txb6 != null && txb7 != null && 
                txb8 != null && txb9 != null && txb10 != null && txb11 != null && txb12 != null && txb3 != null && txb14 != null && txb15 != null)
            {
                using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                {
                    int viaje_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
                    viaje obj = context.viajes.First(x => x.Viaje_ID == viaje_ID);
                    obj.Precio_compra_por_tonelada = decimal.Parse(txb1.Text);
                    obj.Precio_valor_total = decimal.Parse(txb2.Text);
                    obj.Importe_viaje = decimal.Parse(txb3.Text);
                    obj.Saldo = decimal.Parse(txb4.Text);
                    obj.Forma_de_pago_ID = int.Parse(txb5.Text);
                    obj.Carga_ID = int.Parse(txb6.Text);
                    obj.Descarga_ID = int.Parse(txb7.Text);
                    obj.Pesada_origen_ID = int.Parse(txb8.Text);
                    obj.Pesada_destino_ID = int.Parse(txb9.Text);
                    obj.Empresa_de_carga_ID = int.Parse(txb4.Text);
                    obj.Fecha_partida = DateTime.Parse(txb5.Text);
                    obj.Fecha_llegada = DateTime.Parse(txb6.Text);
                    obj.Camion_ID = int.Parse(txb7.Text);
                    obj.Chofer_ID = int.Parse(txb8.Text);
                    obj.Comentarios = txb9.Text;

                    context.SaveChanges();
                    lblMessage.Text = "Guardado correctamente.";
                    gridSample.EditIndex = -1;
                    BindGrid();
                }
            }
        }

        protected void gridSample_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int viaje_ID = Convert.ToInt32(gridSample.DataKeys[e.RowIndex].Value);
            using (bonisoft_dbEntities context = new bonisoft_dbEntities())
            {
                viaje obj = context.viajes.First(x => x.Viaje_ID == viaje_ID);
                context.viajes.Remove(obj);
                context.SaveChanges();
                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }

    }
}