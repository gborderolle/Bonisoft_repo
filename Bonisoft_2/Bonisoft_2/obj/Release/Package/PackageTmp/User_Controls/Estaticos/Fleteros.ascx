<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Fleteros.ascx.cs" Inherits="Bonisoft_2.User_Controls.Estaticos.Fleteros" %>
<h2>Lista de Fleteros</h2>

<asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
<asp:GridView ID="gridFleteros" runat="server" ClientIDMode="Static" HorizontalAlign="Center" AutoGenerateColumns="False" ShowFooter="True" 
    CssClass="table table-hover table-striped"
    DataKeyNames="Fletero_ID"
    OnRowCommand="gridFleteros_RowCommand"
    OnRowCancelingEdit="gridFleteros_RowCancelingEdit"
    OnRowEditing="gridFleteros_RowEditing"
    OnRowUpdating="gridFleteros_RowUpdating"
    OnRowDataBound="gridFleteros_RowDataBound"
    OnRowDeleting="gridFleteros_RowDeleting">

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
       <asp:BoundField DataField="Fletero_ID" HeaderText="ID" HtmlEncode="false" ReadOnly="true"/>
        <asp:TemplateField HeaderText="Nombre">
            <EditItemTemplate>
                <asp:TextBox ID="txb1" runat="server" Text='<%# Bind("Nombre") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl1" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew1" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Dirección">
            <EditItemTemplate>
                <asp:TextBox ID="txb3" runat="server" Text='<%# Bind("Direccion") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew3" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Teléfono">
            <EditItemTemplate>
                <asp:TextBox ID="txb4" runat="server" Text='<%# Bind("Telefono") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl4" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew4" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email">
            <EditItemTemplate>
                <asp:TextBox ID="txb23" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl23" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew23" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nro cuenta">
            <EditItemTemplate>
                <asp:TextBox ID="txb24" runat="server" Text='<%# Bind("Nro_cuenta") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl24" runat="server" Text='<%# Bind("Nro_cuenta") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew24" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Comentarios">
            <EditItemTemplate>
                <asp:TextBox ID="txb2" runat="server" Text='<%# Bind("Comentarios") %>' CssClass="form-control" MaxLength="100"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl2" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew2" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ClientIDMode="AutoID"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-info btn-xs glyphicon glyphicon-pencil"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" ClientIDMode="AutoID"
                    OnClientClick='return confirm("¿Está seguro que desea eliminar este registro?");'
                    CommandArgument=''><span aria-hidden="true" class="btn btn-danger btn-xs glyphicon glyphicon-remove"></span></asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="Update" ClientIDMode="AutoID"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-success btn-xs glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ClientIDMode="AutoID"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-warning btn-xs glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="InsertNew" ClientIDMode="AutoID"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-success btn-xs glyphicon glyphicon-plus"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ClientIDMode="AutoID"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-warning btn-xs glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>

</asp:GridView>
<asp:HiddenField ClientIDMode="Static" ID="hdnFleterosCount" runat="server" />
