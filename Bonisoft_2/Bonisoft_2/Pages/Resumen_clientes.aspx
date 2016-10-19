<%@ Page Title="Resumen de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumen_clientes.aspx.cs" Inherits="Bonisoft_2.Pages.Resumen_clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="/assets/dist/css/jquery.modal.css">

    <!-- PAGE CSS -->
    <link rel="stylesheet" href="/assets/dist/css/pages/Resumen_clientes.css">
    <link rel="stylesheet" href="/assets/dist/css/pages/Modal_styles.css">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->
    <script type="text/javascript" src="/assets/dist/js/jquery.quicksearch.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.modal.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.tablesorter.js"></script>

    <!-- PAGE JS -->
    <script type="text/javascript" src="/assets/dist/js/AuxiliarFunctions.js"></script>
    <script type="text/javascript" src="/assets/dist/js/pages/Resumen_clientes.js"></script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box box-default">
        <div class="box-header with-border" style="padding-bottom: 0;">

            <div class="row">
                <div class="col-md-9">
                    <h1 style="font-size: 24px;">Resumen de Clientes</h1>
                </div>
            </div>


            <div class="row panel panel-default" style="margin-top: 10px; padding-top: 10px;">

                <div class="col-md-3">

                    <div style="text-align: center">

                        <asp:UpdatePanel ID="upClientes" runat="server">
                        <ContentTemplate>

                            <div class="row" style="margin-bottom: 10px;">
                                <div class="col-md-7 pull-right">
                                    <form action="#" method="get" class="sidebar-form" style="display: block !important; width: 100%;">
                                        <div class="input-group ">
                                            <input type="text" id="txbSearchClientes" name="q" class="form-control" placeholder="Buscar...">
                                            <span class="input-group-btn">
                                                <button type="button" name="search" id="search-btn1" class="btn btn-flat">
                                                    <i class="fa fa-search"></i>
                                                </button>
                                            </span>
                                        </div>
                                    </form>
                                </div>
                            </div>

                            <asp:Label ID="gridClientes_lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:GridView ID="gridClientes" runat="server" ClientIDMode="Static" HorizontalAlign="Left" 
                                AutoGenerateColumns="false" CssClass="table table-hover table-striped" AllowPaging="true" PageSize="30"
                                DataKeyNames="Cliente_ID"
                                OnRowDataBound="gridClientes_RowDataBound"
                                OnRowCommand="gridClientes_RowCommand"
                                OnSelectedIndexChanged = "gridClientes_OnSelectedIndexChanged"
                                OnPageIndexChanging="grid2_PageIndexChanging">

                                <RowStyle HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundField DataField="cliente_ID" HeaderText="Cliente_ID" HtmlEncode="false" ItemStyle-CssClass="hiddencol hiddencol_real" HeaderStyle-CssClass="hiddencol hiddencol_real" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" HtmlEncode="false" />
                                </Columns>
                            </asp:GridView>
                            <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                            <asp:Label ID="lblGridClientesCount" runat="server" ClientIDMode="Static" Text="0" CssClass="lblResultados label label-info"></asp:Label>

                        </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="gridClientes" EventName="SelectedIndexChanged"/>
                            </Triggers>
                    </asp:UpdatePanel>

                    </div>                

                </div>

                <div class="col-md-9">

                    <div id="tabsClientes">
                    <ul>
                        <li><a href="#tabsClientes_1" class="tabsClientes">Pagos</a></li>
                        <li><a href="#tabsClientes_2" class="tabsClientes">Viajes</a></li>
                    </ul>

                    <!-- Tab Viajes BEGIN -->
                    <div id="tabsClientes_1">

                        <div style="overflow: auto;">
                        
                            <asp:UpdatePanel ID="upPagos" runat="server">
                            <ContentTemplate>
                            
                                <asp:HiddenField ID="hdn_clientID" runat="server" ClientIDMode="Static" />

                                <div class="row" style="margin-bottom: 10px; margin-right: 0; margin-left: 0;">
                                    <h3 class="pull-left" title="Precio de venta total">Saldo inicial: <label id="lblSaldo_inicial" class="label label-warning">0</label></h3>
                                    <h3 class="pull-right" title="Saldo final después de pagos">Saldo final: <label id="lblSaldo_final" class="label label-success">0</label></h3>
                                </div>

                                <asp:Label ID="gridPagos_lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="gridPagos" runat="server" ClientIDMode="Static" HorizontalAlign="Center"
                                    AutoGenerateColumns="false" CssClass="table table-hover table-striped" AllowPaging="true" PageSize="30"
                                    DataKeyNames="Cliente_pagos_ID" 
                                    OnRowDataBound="gridPagos_RowDataBound"
                                    OnRowCommand="gridPagos_RowCommand"
                                    OnPageIndexChanging="grid_PageIndexChanging">

                                    <Columns>
                                        <asp:BoundField DataField="Cliente_pagos_ID" HeaderText="ID" HtmlEncode="false" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Cliente_ID" HeaderText="Cliente_ID" HtmlEncode="false" ItemStyle-CssClass="hiddencol hiddencol_real" HeaderStyle-CssClass="hiddencol hiddencol_real" />
                                        <asp:BoundField DataField="Fecha_registro" HeaderText="Fecha de registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                        <asp:BoundField DataField="Fecha_pago" HeaderText="Fecha de pago" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False" />
                                        <asp:TemplateField HeaderText = "Forma de pago">
                                            <ItemTemplate>
                                                <asp:Label ID="lblForma" runat="server" CommandName="View" Text='<%# Eval("Forma_de_pago_ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Monto" DataFormatString="{0:C0}" HeaderText="Monto" HtmlEncode="False" />
                                        <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" HtmlEncode="False" />

                                         <asp:TemplateField HeaderText="Acciones" ControlStyle-CssClass="btn btn-info btn-xs">
                                            <ItemTemplate>
                                                    <a id="btnModificar" role="button" onclick='<%# "ModificarPago_1(" +Eval("Cliente_pagos_ID") + " );" %>' class="btn btn-info btn-xs glyphicon glyphicon-pencil"></a>
                                                    <a id="btnBorrar" role="button" onclick='<%# "BorrarPago(" +Eval("Cliente_ID") + " );" %>' class="btn btn-danger btn-xs glyphicon glyphicon-remove"></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblGridPagosCount" runat="server" ClientIDMode="Static" Text="Resultados: 0" CssClass="lblResultados label label-info"></asp:Label>


                                <div class="row" style="margin-right: 0; margin-left: 0;">
                                        <a href="#addPagoModal" rel="modal:open" class="btn btn-primary pull-right">Ingresar pago</a>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                        </div>



                    </div>

                    <div id="tabsClientes_2">


                        <div style="overflow: auto;">
                        
                            <asp:UpdatePanel ID="upViajes" runat="server">
                            <ContentTemplate>

                                <div class="row" style="margin-bottom: 10px;">
                                    <div class="col-md-4 pull-right">
                                        <form action="#" method="get" class="sidebar-form" style="display: block !important; width: 100%;">
                                            <div class="input-group ">
                                                <input type="text" id="txbSearchViajes" name="q" class="form-control" placeholder="Buscar...">
                                                <span class="input-group-btn">
                                                    <button type="button" name="search" id="btnSearchViajes" class="btn btn-flat">
                                                        <i class="fa fa-search"></i>
                                                    </button>
                                                </span>
                                            </div>
                                        </form>
                                    </div>
                                </div>

                                <asp:Label ID="gridViajeslblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="gridViajes" runat="server" ClientIDMode="Static" HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle"
                                    AutoGenerateColumns="false" CssClass="table table-hover table-striped" AllowPaging="true" PageSize="30"
                                    DataKeyNames="Viaje_ID" 
                                    OnRowDataBound="gridViajes_RowDataBound"
                                    OnRowCommand="gridViajes_RowCommand" 
                                    OnPageIndexChanging="grid3_PageIndexChanging">

                                <HeaderStyle VerticalAlign="Middle" />
                                    <RowStyle Font-Size="Smaller" />

                                    <Columns>
                                    <asp:BoundField DataField="Viaje_ID" HeaderText="ID" HtmlEncode="false" ReadOnly="true" />
                                        <asp:BoundField DataField="Fecha_partida" HeaderText="Fecha partida" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                         <asp:TemplateField HeaderText = "Proveedor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProveedor" runat="server" CommandName="View" Text='<%# Eval("Proveedor_ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText = "Fletero">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFletero" runat="server" CommandName="View" Text='<%# Eval("Fletero_ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText = "Camión">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCamion" runat="server" CommandName="View" Text='<%# Eval("Camion_ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText = "Chofer">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChofer" runat="server" CommandName="View" Text='<%# Eval("Chofer_ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Carga" HeaderText="Lugar carga" />

                                        <asp:BoundField DataField="Precio_compra" HeaderText="Precio compra" DataFormatString="{0:C0}" HtmlEncode="False" />
                                        <asp:BoundField DataField="Precio_venta" HeaderText="Precio venta" DataFormatString="{0:C0}" HtmlEncode="False" />

                                        <asp:TemplateField HeaderText = "Pesada origen/Neto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPesadaOrigen" runat="server" Text='<%# Eval("Pesada_ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText = "Pesada destino/Neto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPesadaDestino" runat="server" Text='<%# Eval("Pesada_ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblGridViajesCount" runat="server" ClientIDMode="Static" Text="# 0" CssClass="lblResultados label label-info"></asp:Label>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                        </div>



                    </div>
                </div>

                </div>

            </div>

        </div>
    </div>


    <div id="dialog" title="Mensaje Bonisoft" style="height: 0 !important;">
        <p style="text-align: left;"></p>
    </div>

<%--    http://www.vandelaydesign.com/modal-bootstrap/
    http://www.vandelaydesign.com/demos/bootstrap-modal/--%>

     <!-- Modal agregar pago BEGIN -->
    <div id="addPagoModal" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true" style="display: none; max-width: 500px; overflow: hidden;" class="modal fade dark in">

        <div class="modal-header">
            <h3 id="addModalLabel">Agregar pago</h3>
        </div>
        <asp:UpdatePanel ID="upAdd" runat="server">
            <ContentTemplate>
                <div class="modal-body">
                    <table class="table table-hover">
                        <tr>
                            <td>Fecha de pago: 
                            <asp:TextBox ID="add_txbFecha" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30" DataFormatString="{0:dd-MM-yyyy}"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Forma de pago: 
                            <asp:DropDownList ID="add_ddlFormas" runat="server" ClientIDMode="Static" CssClass="form-control" />
                            </td>
                        </tr>
                        <tr>
                            <td>Monto: 
                                <asp:TextBox ID="add_txbMonto" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" />
                                <asp:CompareValidator ID="vadd_txbMonto" runat="server" ControlToValidate="add_txbMonto" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                            </td>
                        </tr>
                        <tr>
                                <td>Comentarios: 
                                <asp:TextBox ID="add_txbComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" />
                            </td>
                        </tr>

                    </table>
                </div>
                <div class="modal-footer">
                    <button class="btn" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();">Cerrar</button>
                    <a ID="aIngresarPago" class="btn btn-primary" onClick="IngresarPago();">Guardar</a>                                                        

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- Modal agregar pago END -->

      <!-- Modal modificar pago BEGIN -->
    <div id="editPagoModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true" style="display: none; max-width: 500px; overflow: hidden;" class="modal fade dark in">

        <div class="modal-header">
            <h3 id="editModalLabel">Modificar pago</h3>
        </div>
        <asp:UpdatePanel ID="upEdit" runat="server">
            <ContentTemplate>
                <div class="modal-body">
                    <table class="table table-hover">
                        <tr>
                            <td>Fecha de pago: 
                            <asp:TextBox ID="edit_txbFecha" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30" DataFormatString="{0:dd-MM-yyyy}"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Forma de pago: 
                            <asp:DropDownList ID="edit_ddlFormas" runat="server" ClientIDMode="Static" CssClass="form-control" />
                            </td>
                        </tr>
                        <tr>
                            <td>Monto: 
                                <asp:TextBox ID="edit_txbMonto" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" />
                                <asp:CompareValidator ID="vedit_txbMonto" runat="server" ControlToValidate="edit_txbMonto" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                            </td>
                        </tr>
                        <tr>
                                <td>Comentarios: 
                                <asp:TextBox ID="edit_txbComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" />
                            </td>
                        </tr>

                    </table>
                </div>
                <div class="modal-footer">
                    <button class="btn" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();">Cerrar</button>
                    <a ID="aModificarPago" class="btn btn-primary" onClick="ModificarPago_2();">Guardar</a>                                                        

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- Modal modificar pago END -->

</asp:Content>
