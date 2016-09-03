<%@ Page Title="Viajes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Viajes.aspx.cs" Inherits="Bonisoft_2.Pages.Viajes" %>


<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->

    <!-- Page JS -->
    <script src="/assets/dist/js/pages/Viajes.js"></script>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box box-default">
        <div class="box-header with-border" style="padding-bottom: 0;">

            <div class="row">
                <div class="col-md-9">
                    <h2>Menú de Viajes</h2>
                </div>

                <div class="col-md-9">
                    <div class="row">
                        <h3>Viajes en Curso</h3>
                    </div>

                    <div class="row">
                        <h3>Historial</h3>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-2 pull-right" style="margin-right: 10px; margin-bottom: 10px;">
                            <form action="#" method="get" class="sidebar-form" style="display: block !important; width: 100%;">
                                <div class="input-group ">
                                    <input type="text" id="txbSearchTable" name="q" class="form-control" placeholder="Buscar...">
                                    <span class="input-group-btn">
                                        <button type="submit" name="search" id="search-btn" class="btn btn-flat">
                                            <i class="fa fa-search"></i>
                                        </button>
                                    </span>
                                </div>
                            </form>
                        </div>
                    </div>

                    <div class="row">
                        <div id="divContent" style="overflow: auto;">

                            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:GridView ID="gridSample" runat="server" AutoGenerateColumns="False" ShowFooter="True" CssClass="table table-bordered bs-table"
                                DataKeyNames="Viaje_ID"
                                OnRowCommand="gridSample_RowCommand"
                                OnRowCancelingEdit="gridSample_RowCancelingEdit"
                                OnRowEditing="gridSample_RowEditing"
                                OnRowUpdating="gridSample_RowUpdating"
                                OnRowDataBound="gridSample_RowDataBound"
                                OnRowDeleting="gridSample_RowDeleting">

                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#EFF3FB" />
                                <EditRowStyle BackColor="#ffffcc" />
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
                                    <asp:TemplateField HeaderText="Fecha partida">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb11" runat="server" Text='<%# Bind("Fecha_partida") %>' CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl11" runat="server" Text='<%# Bind("Fecha_partida") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew11" runat="server" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha llegada">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb12" runat="server" Text='<%# Bind("Fecha_llegada") %>' CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl12" runat="server" Text='<%# Bind("Fecha_llegada") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew12" runat="server" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Precio compra por ton">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb1" runat="server" Text='<%# Bind("Precio_compra_por_tonelada", "{0:C2}") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                            <asp:CompareValidator ID="vtxb1" runat="server" ControlToValidate="txb1" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl1" runat="server" Text='<%# Bind("Precio_compra_por_tonelada", "{0:C2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew1" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                            <asp:CompareValidator ID="vtxbNew1" runat="server" ControlToValidate="txbNew1" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Precio valor total">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb2" runat="server" Text='<%# Bind("Precio_valor_total", "{0:C2}") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl2" runat="server" Text='<%# Bind("Precio_valor_total", "{0:C2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew2" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Importe viaje">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb3" runat="server" Text='<%# Bind("Importe_viaje", "{0:C2}") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                            <asp:CompareValidator ID="vtxb3" runat="server" ControlToValidate="txb3" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Importe_viaje", "{0:C2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew3" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                            <asp:CompareValidator ID="vtxbNew3" runat="server" ControlToValidate="txbNew3" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Saldo">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb4" runat="server" Text='<%# Bind("Saldo", "{0:C2}") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                            <asp:CompareValidator ID="vtxb4" runat="server" ControlToValidate="txb4" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl4" runat="server" Text='<%# Bind("Saldo", "{0:C2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew4" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                            <asp:CompareValidator ID="vtxbNew4" runat="server" ControlToValidate="txbNew4" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Forma de pago">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlFormas1" runat="server" CssClass="form-control" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl5" runat="server" Text='<%# Bind("Forma_de_pago_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlFormas2" runat="server" CssClass="form-control" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Carga">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb6" runat="server" Text='<%# Bind("Carga_ID") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl6" runat="server" Text='<%# Bind("Carga_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew6" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descarga">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb7" runat="server" Text='<%# Bind("Descarga_ID") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl7" runat="server" Text='<%# Bind("Descarga_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew7" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pesada Origen">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb8" runat="server" Text='<%# Bind("Pesada_origen_ID") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl8" runat="server" Text='<%# Bind("Pesada_origen_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew8" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pesada Destino">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb9" runat="server" Text='<%# Bind("Pesada_destino_ID") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl9" runat="server" Text='<%# Bind("Pesada_destino_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew9" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Empresa de carga">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlEmpresas1" runat="server" CssClass="form-control" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl10" runat="server" Text='<%# Bind("Empresa_de_carga_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlEmpresas2" runat="server" CssClass="form-control" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Camión">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlCamiones1" runat="server" CssClass="form-control" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl13" runat="server" Text='<%# Bind("Camion_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlCamiones2" runat="server" CssClass="form-control" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chofer">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlChoferes1" runat="server" CssClass="form-control" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl14" runat="server" Text='<%# Bind("Chofer_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlChoferes2" runat="server" CssClass="form-control" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comentarios">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txb15" runat="server" Text='<%# Bind("Comentarios") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl15" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txbNew15" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                </Columns>

                            </asp:GridView>
                            <asp:HiddenField ClientIDMode="Static" ID="hdnViajesCount" runat="server" />

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>




</asp:Content>
