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
        <asp:BoundField DataField="Mercaderia_ID" HeaderText="ID" HtmlEncode="false" ReadOnly="true"/>
        <asp:TemplateField HeaderText="Precio Compra / Tonelada">
            <HeaderStyle Width="170" />
            <ItemStyle Width="170" />
            <EditItemTemplate>
                <asp:TextBox ID="mercaderias_txb5" runat="server" Text='<%# Bind("Precio_xTonelada_compra") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                <asp:CompareValidator ID="vtxb5" runat="server" ControlToValidate="mercaderias_txb5" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Currency" />
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="mercaderias_lbl5" runat="server" Text='<%# Bind("Precio_xTonelada_compra", "{0:n2}") %>'></asp:Label>
                <%--<asp:Label ID="mercaderias_lbl5" runat="server" Text='<%# Bind("Precio_xTonelada_compra", "{0:C0}") %>'></asp:Label>--%>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="mercaderias_txbNew5" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                <asp:CompareValidator ID="vtxbNew5" runat="server" ControlToValidate="mercaderias_txbNew5" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Currency" />
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
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ClientIDMode="AutoID" CausesValidation="False"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-info btn-xs glyphicon glyphicon-pencil"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" ClientIDMode="AutoID" CausesValidation="False"
                    OnClientClick='return confirm("Está seguro que desea borrar este registro?");'
                    CommandArgument=''><span aria-hidden="true" class="btn btn-danger btn-xs glyphicon glyphicon-remove"></span></asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="Update" OnClientClick = "return GetSelectedRow(this)" ClientIDMode="AutoID" CausesValidation="False"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-success btn-xs glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ClientIDMode="AutoID" CausesValidation="False"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-warning btn-xs glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="InsertNew" ClientIDMode="AutoID" CausesValidation="False"
                    CommandArgument='' OnClientClick="guardarMercaderias();"><span aria-hidden="true" class="btn btn-success btn-xs glyphicon glyphicon-plus"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ClientIDMode="AutoID" CausesValidation="False"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-warning btn-xs glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>

</asp:GridView>
<asp:HiddenField ClientIDMode="Static" ID="hdnMercaderiasCount" runat="server" />



