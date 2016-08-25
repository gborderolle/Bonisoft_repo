<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Choferes.aspx.cs" Inherits="Bonisoft_2.Pages.Choferes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de Choferes</h2>

        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:GridView ID="gridSample" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                        CssClass="grid" OnRowCommand="gridSample_RowCommand" DataKeyNames="Chofer_ID" CellPadding="4" ForeColor="#333333"
                        GridLines="None" OnRowCancelingEdit="gridSample_RowCancelingEdit"
                        OnRowEditing="gridSample_RowEditing" OnRowUpdating="gridSample_RowUpdating" onrowdatabound="gridSample_RowDataBound" 
                        onrowdeleting="gridSample_RowDeleting">

                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Modificar" 
                                        CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                                        ToolTip="Delete" OnClientClick='return confirm("Está seguro que desea borrar este registro?");'
                                        CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="Update" ToolTip="Guardar"
                                        CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                        CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text=""  ValidationGroup="newGrp" CommandName="InsertNew" ToolTip="Agregar"
                                        CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ToolTip="Cancelar"
                                        CommandArgument=''><span aria-hidden="true" class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apellidos">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb1" runat="server" Text='<%# Bind("Apellidos") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl1" runat="server" Text='<%# Bind("Apellidos") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew1" runat="server" CssClass=""   MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Nombres">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb2" runat="server" Text='<%# Bind("Nombres") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl2" runat="server" Text='<%# Bind("Nombres") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew2" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Empresa_pertenece_ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb3" runat="server" Text='<%# Bind("Empresa_pertenece_ID") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Empresa_pertenece_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew3" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Comentarios">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb4" runat="server" Text='<%# Bind("Comentarios") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl4" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew4" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 

                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />

        </asp:GridView>
</asp:Content>
