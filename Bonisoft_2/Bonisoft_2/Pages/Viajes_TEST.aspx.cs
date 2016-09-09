using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bonisoft_2.Pages
{
    public partial class Viajes_TEST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid_EnCurso();
            }
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

        protected void gridViajesEnCurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                if (!string.IsNullOrWhiteSpace(e.CommandArgument.ToString()) && !string.IsNullOrWhiteSpace(e.CommandName))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int viaje_ID = int.Parse(gridViajesEnCurso.DataKeys[index].Value.ToString());
                    using (bonisoft_dbEntities context = new bonisoft_dbEntities())
                    {
                        if (e.CommandName.Equals("detail"))
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
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
                            }
                        }
                        else if (e.CommandName.Equals("editRecord"))
                        {
                            GridViewRow gvrow = gridViajesEnCurso.Rows[index];
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
            }
        }

        protected void btnSave_Click_2(object sender, EventArgs e)
        {
            int viaje_ID = int.Parse(lblCountryCode.Text);
            string comentarios = txtPopulation.Text;
            executeUpdate(viaje_ID, comentarios);
            BindGrid_EnCurso();
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
            BindGrid_EnCurso();
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
    }
}