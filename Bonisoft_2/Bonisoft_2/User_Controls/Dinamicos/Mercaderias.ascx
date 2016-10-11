<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mercaderias.ascx.cs" Inherits="Bonisoft_2.User_Controls.Configuracion.Mercaderias" %>

<asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
<asp:GridView ID="gridMercaderias" runat="server" ClientIDMode="Static" AutoGenerateColumns="False" ShowFooter="True" CssClass="table table-bordered bs-table" AllowPaging="true" EnableViewState="True"
    DataKeyNames="Mercaderia_ID"
    OnRowCommand="gridMercaderias_RowCommand"
    OnRowCancelingEdit="gridMercaderias_RowCancelingEdit"
    OnRowEditing="gridMercaderias_RowEditing"
    OnRowUpdating="gridMercaderias_RowUpdating"
    OnRowDataBound="gridMercaderias_RowDataBound"
    OnRowDeleting="gridMercaderias_RowDeleting">    

    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="#EFF3FB" />
    <EditRowStyle BackColor="Red" />
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
                <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" 
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                    OnClientClick='return confirm("Está seguro que desea borrar este registro?");'
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-remove"></span></asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="Update" OnClientClick = "return GetSelectedRow(this)"
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" 
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="newGrp" CommandName="InsertNew" 
                    CommandArgument='' OnClientClick="Javascript:DoPost_Mercaderias();"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" 
                    CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Variedad">
            <EditItemTemplate>
                <asp:DropDownList ID="mercaderias_ddlVariedad1" runat="server" CssClass="form-control" />
            </EditItemTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="mercaderias_lbl1" runat="server" CommandName="View" Text='<%# Bind("Variedad_ID") %>'></asp:LinkButton>
            </ItemTemplate>
            <FooterTemplate>
                <asp:DropDownList ID="mercaderias_ddlVariedad2" runat="server" CssClass="form-control" />
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha de corte">
            <EditItemTemplate>
                <asp:TextBox ID="mercaderias_txb4" runat="server" Text='<%# Bind("Fecha_corte", "{0:dd-mm-yyyy}") %>' CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="mercaderias_lbl4" runat="server" Text='<%# Bind("Fecha_corte", "{0:dd-mm-yyyy}") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="mercaderias_txbNew4" runat="server" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Precio Compra xTON">
            <EditItemTemplate>
                <asp:TextBox ID="mercaderias_txb5" runat="server" Text='<%# Bind("Precio_xTonelada_compra") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                <asp:CompareValidator ID="vtxb5" runat="server" ControlToValidate="mercaderias_txb5" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="mercaderias_lbl5" runat="server" Text='<%# Bind("Precio_xTonelada_compra", "{0:C0}") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="mercaderias_txbNew5" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                <asp:CompareValidator ID="vtxbNew5" runat="server" ControlToValidate="mercaderias_txbNew5" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
            </FooterTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Comentarios">
            <EditItemTemplate>
                <asp:TextBox ID="mercaderias_txb7" runat="server" Text='<%# Bind("Comentarios") %>' CssClass="form-control" MaxLength="100"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="mercaderias_lbl7" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="mercaderias_txbNew7" runat="server" CssClass="form-control" MaxLength="100" EnableViewState="true"></asp:TextBox>
            </FooterTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>
<asp:HiddenField ClientIDMode="Static" ID="hdnMercaderiasCount" runat="server" />



