<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Internos.ascx.cs" Inherits="Bonisoft_2.User_Controls.Internos" %>
<h2>Lista de Internos</h2>

<asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
<asp:GridView ID="gridInternos" runat="server" ClientIDMode="Static" HorizontalAlign="Center" AutoGenerateColumns="False" ShowFooter="True" 
    CssClass="table table-hover table-striped"
    DataKeyNames="Interno_ID"
    OnRowCommand="gridInternos_RowCommand"
    OnRowCancelingEdit="gridInternos_RowCancelingEdit"
    OnRowEditing="gridInternos_RowEditing"
    OnRowUpdating="gridInternos_RowUpdating"
    OnRowDataBound="gridInternos_RowDataBound"
    OnRowDeleting="gridInternos_RowDeleting">

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
        <asp:TemplateField HeaderText="Fecha nacim.">
            <EditItemTemplate>
                <asp:TextBox ID="txb3" runat="server" Text='<%# Bind("Fecha_nacimiento", "{0:MMMM d, yyyy}") %>' CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Fecha_nacimiento", "{0:MMMM d, yyyy}") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew3" runat="server" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CI">
            <EditItemTemplate>
                <asp:TextBox ID="txb4" runat="server" Text='<%# Bind("CI") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl4" runat="server" Text='<%# Bind("CI") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew4" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha ingreso">
            <EditItemTemplate>
                <asp:TextBox ID="txb5" runat="server" Text='<%# Bind("Fecha_ingreso", "{0:MMMM d, yyyy}") %>' CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl5" runat="server" Text='<%# Bind("Fecha_ingreso", "{0:MMMM d, yyyy}") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew5" runat="server" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha egreso">
            <EditItemTemplate>
                <asp:TextBox ID="txb6" runat="server" Text='<%# Bind("Fecha_egreso", "{0:MMMM d, yyyy}") %>' CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl6" runat="server" Text='<%# Bind("Fecha_egreso", "{0:MMMM d, yyyy}") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew6" runat="server" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cargo">
            <EditItemTemplate>
                <asp:TextBox ID="txb7" runat="server" Text='<%# Bind("Cargo") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl7" runat="server" Text='<%# Bind("Cargo") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew7" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Comentarios">
            <EditItemTemplate>
                <asp:TextBox ID="txb8" runat="server" Text='<%# Bind("Comentarios") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl8" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew8" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>
<asp:HiddenField ClientIDMode="Static" ID="hdnInternosCount" runat="server" />
