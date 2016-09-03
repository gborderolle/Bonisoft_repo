<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gridview.aspx.cs" Inherits="Bonisoft_2.Pages.Gridview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Ejemplo 2: Gridview moderno y funcional maquetado con Bootstrap</h3>
    <p>&nbsp;En este ejemplo, vamos a gestionar la tabla Clientes de la BD Northwind, mediante un control de servidor <strong>Gridview</strong>.</p>
    <h3>
        <span style="float:left;"><asp:Label ID="lblInfo" runat="server" /></span>
        <span style="float:right;"><small>Total clientes:</small> <asp:Label ID="lblTotalClientes" runat="server" CssClass="label label-warning" /></span>
    </h3>
    <p>&nbsp;</p><p>&nbsp;</p>
    <asp:GridView ID="gridSample" runat="server"
        AutoGenerateColumns="False" 
        CssClass="table table-bordered bs-table" 
        DataKeyNames="Cuadrilla_descarga_ID" 
        OnRowCancelingEdit="gridSample_RowCancelingEdit"
        OnRowEditing="gridSample_RowEditing" 
        OnRowUpdating="gridSample_RowUpdating" 
        onrowdatabound="gridSample_RowDataBound" 
        onrowdeleting="gridSample_RowDeleting"
        allowpaging="true" >
 
        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />        <AlternatingRowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#ffffcc" />
        <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
        <emptydatatemplate>
            ¡No hay clientes con los �metros seleccionados!  
        </emptydatatemplate>           
 
        <%--Paginador...--%>        
        <pagertemplate>
        <div class="row" style="margin-top:20px;">
            <div class="col-lg-1" style="text-align:right;">
                <h5><asp:label id="MessageLabel" text="Ir a la pág." runat="server" /></h5>
            </div>
             <div class="col-lg-1" style="text-align:left;">
                <asp:dropdownlist id="PageDropDownList" Width="50px" autopostback="true" onselectedindexchanged="PageDropDownList_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
            </div>
            <div class="col-lg-10" style="text-align:right;">
                <h3><asp:label id="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
            </div>
        </div>        
        </pagertemplate>             
 
        <Columns>
            <%--CheckBox para seleccionar varios registros...--%>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                <ItemTemplate>
                    <asp:CheckBox ID="chkEliminar" runat="server" AutoPostBack="true" OnCheckedChanged="chk_OnCheckedChanged" />
                </ItemTemplate>
            </asp:TemplateField>            
 
            <%--botones de acción sobre los registros...--%>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                <ItemTemplate>
                    <%--Botones de eliminar y editar cliente...--%>
                    <asp:Button ID="btnDelete" runat="server" Text="Quitar" CssClass="btn btn-danger" CommandName="Delete" OnClientClick="return confirm('¿Eliminar cliente?');" />
                    <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Edit" />
                </ItemTemplate>
                <edititemtemplate>
                    <%--Botones de grabar y cancelar la edición de registro...--%>
                    <asp:Button ID="btnUpdate" runat="server" Text="Grabar" CssClass="btn btn-success" CommandName="Update" OnClientClick="return confirm('¿Seguro que quiere modificar los datos del cliente?');" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-default" CommandName="Cancel" />
                </edititemtemplate>
            </asp:TemplateField>
 
            <%--campos no editables...--%>
            <%--<asp:BoundField DataField="ClienteID" HeaderText="Nº" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px" />
            <asp:BoundField DataField="CustomerID" HeaderText="Cód." InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px" />
            <asp:BoundField DataField="CompanyName" HeaderText="Compañía" ReadOnly="True" SortExpression="CompanyName" ControlStyle-Width="300px" />
            <asp:BoundField DataField="Country" HeaderText="Pais" ReadOnly="True" SortExpression="Country" />
 --%>
            <%--campos editables...--%>
            <asp:TemplateField HeaderStyle-Width="300px" HeaderText="Contacto">
                <ItemTemplate>
                    <asp:Label id="lblContactName" runat="server"><%# Eval("ContactName")%></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TxtContactName" runat="server" Text='<%# Bind("ContactName")%>' CssClass="form-control" ></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Teléfono">
                <ItemTemplate>
                    <asp:Label id="lblPhone" runat="server"><%# Eval("Phone")%></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TxtPhone" runat="server" Text='<%# Bind("Phone")%>' CssClass="form-control" ></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p style="text-align:center;">
        <asp:LinkButton ID="btnQuitarSeleccionados" runat="server" CssClass="btn btn-lg btn-danger disabled" OnClientClick="return confirm('¿Quitar cliente/s de la lista?');"><span class="glyphicon glyphicon-trash"></span>&nbsp; Quitar Clientes seleccionados</asp:LinkButton>
    </p>

</asp:Content>
