<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Internos.ascx.cs" Inherits="Bonisoft_2.User_Controls.Internos" %>
<h2>Lista de Internos</h2>

        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:GridView ID="gridSample" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                        CssClass="grid" OnRowCommand="gridSample_RowCommand" DataKeyNames="Interno_ID" CellPadding="4" ForeColor="#333333"
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
                            <asp:TemplateField HeaderText="Fecha_nacimiento">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb3" runat="server" Text='<%# Bind("Fecha_nacimiento") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Fecha_nacimiento") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew3" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="CI">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb4" runat="server" Text='<%# Bind("CI") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl4" runat="server" Text='<%# Bind("CI") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew4" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Fecha_ingreso">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb5" runat="server" Text='<%# Bind("Fecha_ingreso") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl5" runat="server" Text='<%# Bind("Fecha_ingreso") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew5" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Fecha_egreso">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb6" runat="server" Text='<%# Bind("Fecha_egreso") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl6" runat="server" Text='<%# Bind("Fecha_egreso") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew6" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Cargo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb7" runat="server" Text='<%# Bind("Cargo") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl7" runat="server" Text='<%# Bind("Cargo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew7" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Comentarios">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txb8" runat="server" Text='<%# Bind("Comentarios") %>' CssClass="" MaxLength="30"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl8" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                   <asp:TextBox ID="txbNew8" runat="server" CssClass=""  MaxLength="30"></asp:TextBox>
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
