<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Formas_pago.ascx.cs" Inherits="Bonisoft_2.User_Controls.Configuracion.Formas_pago" %>
<h2>Lista de Formas de Pago</h2>

<asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
<asp:GridView ID="gridFormas" runat="server" ClientIDMode="Static" HorizontalAlign="Center" AutoGenerateColumns="False" ShowFooter="True" 
    CssClass="table table-hover table-striped" AllowPaging="true"
    DataKeyNames="Forma_de_pago_ID"
    OnRowCommand="gridFormas_RowCommand"
    OnRowCancelingEdit="gridFormas_RowCancelingEdit"
    OnRowEditing="gridFormas_RowEditing"
    OnRowUpdating="gridFormas_RowUpdating"
    OnRowDataBound="gridFormas_RowDataBound"
    OnRowDeleting="gridFormas_RowDeleting">

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
       
        <asp:TemplateField HeaderText="Nombre">
            <EditItemTemplate>
                <asp:TextBox ID="txb1" runat="server" Text='<%# Bind("Forma") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl1" runat="server" Text='<%# Bind("Forma") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="txbNew1" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
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
                    OnClientClick='return confirm("Está seguro que desea borrar este registro?");'
                    CommandArgument=''><span aria-hidden="true" class="btn btn-danger btn-xs glyphicon glyphicon-remove"></span></asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="Update" ClientIDMode="AutoID"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-success btn-xs glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ClientIDMode="AutoID"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-warning btn-xs glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="newGrp" CommandName="InsertNew" ClientIDMode="AutoID"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-success btn-xs glyphicon glyphicon-plus"></span></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ClientIDMode="AutoID"
                    CommandArgument=''><span aria-hidden="true" class="btn btn-warning btn-xs glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>

</asp:GridView>
<asp:HiddenField ClientIDMode="Static" ID="hdnFormaCount" runat="server" />
