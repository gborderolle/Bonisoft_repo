<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Choferes2.ascx.cs" Inherits="Bonisoft_2.User_Controls.Choferes2" %>
<h2>Lista de Choferes</h2>

<asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
<asp:GridView ID="gridChoferes" runat="server" ClientIDMode="Static" HorizontalAlign="Center" AutoGenerateColumns="False" ShowFooter="True"
    CssClass="table table-hover table-striped" 
    DataKeyNames="Chofer_ID"
    OnRowCommand="gridChoferes_RowCommand" 
    OnRowCancelingEdit="gridChoferes_RowCancelingEdit"
    OnRowEditing="gridChoferes_RowEditing" 
    OnRowUpdating="gridChoferes_RowUpdating" 
    OnRowDataBound="gridChoferes_RowDataBound"
    OnRowDeleting="gridChoferes_RowDeleting">

    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
    <EmptyDataTemplate>
        ¡No hay clientes con los parámetros seleccionados!  
    </EmptyDataTemplate>

    <%--Paginador...--%>
    <PagerTemplate>
        <div class="row" style="margin-top: 20px;">
            <div class="col-lg-1" style="text-align: right;">
                <h5>
                    <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
            </div>
            <div class="col-lg-1" style="text-align: left;">
                <asp:DropDownList ID="PageDropDownList" Width="50px" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
            </div>
            <div class="col-lg-10" style="text-align: right;">
                <h3>
                    <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" /></h3>
            </div>
        </div>
    </PagerTemplate>

    <Columns>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Modificar"
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                    ToolTip="Borrar" OnClientClick='return confirm("Está seguro que desea borrar este registro?");'
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-remove"></span></asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="Update" ToolTip="Guardar"
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancelar"
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="newGrp" CommandName="InsertNew" ToolTip="Agregar"
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ToolTip="Cancelar"
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Apellidos">
            <EditItemTemplate>
                <asp:TextBox ID="txb1" runat="server" Text='<%# Bind("Apellidos") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl1" runat="server" Text='<%# Bind("Apellidos") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew1" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombres">
            <EditItemTemplate>
                <asp:TextBox ID="txb2" runat="server" Text='<%# Bind("Nombres") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl2" runat="server" Text='<%# Bind("Nombres") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew2" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Empresa">
            <EditItemTemplate>
                <asp:DropDownList ID="ddlEmpresas1" runat="server" CssClass="form-control" />
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Empresa_pertenece_ID") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:DropDownList ID="ddlEmpresas2" runat="server" CssClass="form-control" />
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Comentarios">
            <EditItemTemplate>
                <asp:TextBox ID="txb4" runat="server" Text='<%# Bind("Comentarios") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl4" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew4" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>
<asp:HiddenField ClientIDMode="Static" ID="hdnChoferesCount" runat="server" />
