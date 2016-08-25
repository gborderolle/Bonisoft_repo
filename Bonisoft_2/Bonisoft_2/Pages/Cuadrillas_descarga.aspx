<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuadrillas_descarga.aspx.cs" Inherits="Bonisoft_2.Pages.Cuadrillas_descarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de Cuadrillas de descarga</h2>

    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:GridView ID="gridSample" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                        CssClass="grid" OnRowCommand="gridSample_RowCommand" DataKeyNames="Cuadrilla_descarga_ID" CellPadding="4" ForeColor="#333333"
                        GridLines="None" OnRowCancelingEdit="gridSample_RowCancelingEdit"
                        OnRowEditing="gridSample_RowEditing" OnRowUpdating="gridSample_RowUpdating" onrowdatabound="gridSample_RowDataBound" 
                        onrowdeleting="gridSample_RowDeleting">

                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit" 
                                        CommandArgument=''><img src="../Images/show.png" /></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                                        ToolTip="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                                        CommandArgument=''><img src="../Images/icon_delete.png" /></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="Update" ToolTip="Save"
                                        CommandArgument=''><img src="../Images/icon_save.png" /></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                        CommandArgument=''><img src="../Images/refresh.png" /></asp:LinkButton>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkInsert" runat="server" Text=""  ValidationGroup="newGrp" CommandName="InsertNew" ToolTip="Add New Entry"
                                        CommandArgument=''><img src="../Images/icon_new.png" /></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ToolTip="Cancel"
                                        CommandArgument=''><img src="../Images/refresh.png" /></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuadrilla_descarga_ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Bind("Cuadrilla_descarga_ID") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("Cuadrilla_descarga_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txtFirstNameNew" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>       
                            <asp:TemplateField HeaderText="Empresa_ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLastName" runat="server" Text='<%# Bind("Empresa_ID") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("Empresa_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txtLastNameNew" runat="server" CssClass=""   MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Comentarios">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Comentarios") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txtEmailNew" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
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
