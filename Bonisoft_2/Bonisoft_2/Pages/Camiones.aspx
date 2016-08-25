<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Camiones.aspx.cs" Inherits="Bonisoft_2.Pages.Camiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de Camiones</h2>

        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:GridView ID="gridSample" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                        CssClass="grid" OnRowCommand="gridSample_RowCommand" DataKeyNames="Camion_ID" CellPadding="4" ForeColor="#333333"
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
                            <asp:TemplateField HeaderText="Matricula_camion">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb1" runat="server" Text='<%# Bind("Matricula_camion") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl1" runat="server" Text='<%# Bind("Matricula_camion") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew1" runat="server" CssClass=""   MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Matricula_zorra">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb2" runat="server" Text='<%# Bind("Matricula_zorra") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl2" runat="server" Text='<%# Bind("Matricula_zorra") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew2" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Numero_ejes">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb3" runat="server" Text='<%# Bind("Numero_ejes") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Numero_ejes") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew3" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Peso_Tara_origen">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb4" runat="server" Text='<%# Bind("Peso_Tara_origen") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl4" runat="server" Text='<%# Bind("Peso_Tara_origen") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew4" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Peso_Tara_destino">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb5" runat="server" Text='<%# Bind("Peso_Tara_destino") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl5" runat="server" Text='<%# Bind("Peso_Tara_destino") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew5" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Marca">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb6" runat="server" Text='<%# Bind("Marca") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl6" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew6" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Modelo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb7" runat="server" Text='<%# Bind("Modelo") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl7" runat="server" Text='<%# Bind("Modelo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew7" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Peso_neto">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb8" runat="server" Text='<%# Bind("Peso_neto") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl8" runat="server" Text='<%# Bind("Peso_neto") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew8" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Comentarios">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb9" runat="server" Text='<%# Bind("Comentarios") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl9" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew9" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
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
