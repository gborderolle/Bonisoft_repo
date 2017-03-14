<%@ Page Title="Resumen de Fleteros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumen_fleteros.aspx.cs" Inherits="Bonisoft.Pages.Resumen_fleteros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="/assets/dist/css/jquery.modal.css" />
    <link rel="stylesheet" href="/assets/dist/css/chosen.css" />

    <!-- PAGE CSS -->
    <link rel="stylesheet" href="/assets/dist/css/pages/Resumen_fleteros.css" />
    <link rel="stylesheet" href="/assets/dist/css/pages/Modal_styles.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->
    <script type="text/javascript" src="/assets/dist/js/jquery.quicksearch.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.modal.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.tablesorter.js"></script>
    <script type="text/javascript" src="/assets/dist/js/chosen.jquery.js"></script>

    <!-- PAGE JS -->
    <script type="text/javascript" src="/assets/dist/js/AuxiliarFunctions.js"></script>
    <script type="text/javascript" src="/assets/dist/js/pages/Resumen_fleteros.js"></script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box box-default">
        <div class="box-header with-border" style="padding-bottom: 0;">

            <div class="row">
                <div class="col-md-9">
                    <h1 style="font-size: 24px;">Resumen de Fleteros</h1>
                </div>
            </div>

            <div class="row panel panel-default" style="margin-top: 10px; padding-top: 10px;">

                <div class="col-md-3">

                    <div style="text-align: center">

                        <asp:UpdatePanel ID="upFleteros" runat="server">
                            <ContentTemplate>

                                <div class="row" style="margin-bottom: 10px;">
                                    <div class="col-md-7 pull-right">
                                        <form action="#" method="get" class="sidebar-form" style="display: block !important; width: 100%;">
                                            <div class="input-group ">
                                                <input type="text" id="txbSearchFleteros" name="q" class="form-control" placeholder="Buscar...">
                                                <span class="input-group-btn">
                                                    <button type="button" name="search" id="search-btn1" class="btn btn-flat">
                                                        <i class="fa fa-search"></i>
                                                    </button>
                                                </span>
                                            </div>
                                        </form>
                                    </div>
                                </div>

                                <asp:Label ID="gridFleteros_lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="gridFleteros" runat="server" ClientIDMode="Static" HorizontalAlign="Left"
                                    AutoGenerateColumns="false" CssClass="table table-hover table-striped" AllowPaging="true" PageSize="30"
                                    DataKeyNames="Fletero_ID"
                                    OnRowDataBound="gridFleteros_RowDataBound"
                                    OnRowCommand="gridFleteros_RowCommand"
                                    OnSelectedIndexChanged="gridFleteros_OnSelectedIndexChanged"
                                    OnPageIndexChanging="grid2_PageIndexChanging">

                                    <RowStyle HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:BoundField DataField="Fletero_ID" HeaderText="Fletero_ID" HtmlEncode="false" ItemStyle-CssClass="hiddencol hiddencol_real" HeaderStyle-CssClass="hiddencol hiddencol_real" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" HtmlEncode="false" />
                                    </Columns>
                                </asp:GridView>
                                <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                                <asp:Label ID="lblGridFleterosCount" runat="server" ClientIDMode="Static" Text="0" CssClass="lblResultados label label-info"></asp:Label>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="gridFleteros" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                </div>

                <div class="col-md-9">

                    <div id="tabsFleteros">
                        <ul>
                            <li><a href="#tabsFleteros_1" class="tabsFleteros">Pagos del fletero</a></li>
                            <li><a href="#tabsFleteros_2" class="tabsFleteros">Viajes del fletero</a></li>
                            <li><a href="#tabsFleteros_3" class="tabsFleteros">Planilla a imprimir</a></li>
                        </ul>

                        <!-- Tab Viajes BEGIN -->
                        <div id="tabsFleteros_1">

                            <div style="overflow: auto;">

                                <asp:UpdatePanel ID="upPagos" runat="server">
                                    <ContentTemplate>

                                        <asp:HiddenField ID="hdn_FleteroID" runat="server" ClientIDMode="Static" />

                                        <div class="row">
                                            <div class="col-md-10 pull-left">
                                                <h2>
                                                    <asp:Label Text="[Nombre fletero]" runat="server" ID="lblFleteroName_1" /></h2>
                                            </div>

                                            <div class="col-md-2 pull-right">
                                                <a id="btnAddFicticioModal" role="button" onclick='ViajeFicticio_1();' class="btn btn-sm btn-warning pull-right">Saldo anterior</a>

                                            </div>
                                        </div>

                                        <div class="row" style="margin-bottom: 10px; margin-right: 0; margin-left: 0;">
                                            <h3 class="pull-left" title="Precio de venta total">Saldo inicial:
                                                <label id="lblSaldo_inicial" class="label label-warning">0</label></h3>
                                            <h3 class="pull-right" title="Saldo final después de pagos">Saldo final:
                                                <label id="lblSaldo_final" class="label label-success">0</label></h3>
                                        </div>

                                        <asp:Label ID="gridPagos_lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        <asp:GridView ID="gridPagos" runat="server" ClientIDMode="Static" HorizontalAlign="Center"
                                            AutoGenerateColumns="false" CssClass="table table-hover table-striped" AllowPaging="true" PageSize="30"
                                            DataKeyNames="Fletero_pagos_ID"
                                            OnRowDataBound="gridPagos_RowDataBound"
                                            OnRowCommand="gridPagos_RowCommand"
                                            OnPageIndexChanging="grid_PageIndexChanging">

                                            <Columns>
                                                <asp:BoundField DataField="Fletero_pagos_ID" HeaderText="ID" HtmlEncode="false" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                <asp:BoundField DataField="Fletero_ID" HeaderText="Fletero_ID" HtmlEncode="false" ItemStyle-CssClass="hiddencol hiddencol_real" HeaderStyle-CssClass="hiddencol hiddencol_real" />
                                                <asp:BoundField DataField="Fecha_registro" HeaderText="Fecha de registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                <asp:TemplateField HeaderText="Fecha de pago">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaPago" runat="server" CommandName="View" Text='<%# Eval("Fecha_pago", "{0:dd-MM-yyyy}") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Forma de pago">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblForma" runat="server" CommandName="View" Text='<%# Eval("Forma_de_pago_ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Monto" DataFormatString="{0:C2}" HeaderText="Monto" HtmlEncode="False" />
                                                <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" HtmlEncode="False" />

                                                <asp:TemplateField HeaderText="Acciones" ControlStyle-CssClass="btn btn-info btn-xs">
                                                    <ItemTemplate>
                                                        <a id="btnModificar" role="button" onclick='<%# "ModificarPago_1(" +Eval("Fletero_pagos_ID") + " );" %>' class="btn btn-info btn-xs glyphicon glyphicon-pencil"></a>
                                                        <a id="btnBorrar" role="button" onclick='<%# "BorrarPago(" +Eval("Fletero_ID") + " );" %>' class="btn btn-danger btn-xs glyphicon glyphicon-remove"></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                        <asp:Label ID="lblGridPagosCount" runat="server" ClientIDMode="Static" Text="Resultados: 0" CssClass="lblResultados label label-info"></asp:Label>


                                        <div class="row" style="margin-right: 0; margin-left: 0;">
                                            <a href="#addPagoModal" rel="modal:open" class="btn btn-primary pull-right">Ingresar pago</a>
                                        </div>

                                        <hr style="margin-top: 5px; margin-bottom: 5px;" />
                                        <div class="row" style="margin: 0;">
                                            <div class="col-md-12 pull-left" style="padding: 10px;">
                                                <p class="text-info" style="text-align: left;">Importante: El Saldo inicial es la suma del Precio de venta de todos los viajes que corresponden al fletero. </p>
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>

                        </div>

                        <div id="tabsFleteros_2">


                            <div style="overflow: auto;">

                                <asp:UpdatePanel ID="upViajes" runat="server">
                                    <ContentTemplate>

                                        <div class="row" style="margin-bottom: 10px;">
                                            <div class="col-md-8 pull-left">
                                                <h2>Datos de los viajes</h2>
                                            </div>

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
                                                <asp:TemplateField HeaderText="Fecha partida">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaPartida" runat="server" CommandName="View" Text='<%# Eval("Fecha_partida", "{0:dd-MM-yyyy}") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Proveedor">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProveedor" runat="server" CommandName="View" Text='<%# Eval("Proveedor_ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fletero">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFletero" runat="server" CommandName="View" Text='<%# Eval("Fletero_ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Camión">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCamion" runat="server" CommandName="View" Text='<%# Eval("Camion_ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Chofer">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblChofer" runat="server" CommandName="View" Text='<%# Eval("Chofer_ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Carga" HeaderText="Lugar carga" />

                                                <asp:BoundField DataField="Pesada_Origen_lugar" HeaderText="Pesada origen" HtmlEncode="False" />
                                                <asp:BoundField DataField="Pesada_Destino_lugar" HeaderText="Pesada destino" HtmlEncode="False" />

                                                <asp:BoundField DataField="Precio_compra" HeaderText="Precio compra" DataFormatString="{0:C2}" HtmlEncode="False" />
                                                <asp:BoundField DataField="Precio_venta" HeaderText="Precio venta" DataFormatString="{0:C2}" HtmlEncode="False" />

                                                <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Label ID="lblGridViajesCount" runat="server" ClientIDMode="Static" Text="# 0" CssClass="lblResultados label label-info"></asp:Label>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>



                        </div>

                        <div id="tabsFleteros_3">
                            <div style="overflow: auto;">
                                <asp:UpdatePanel ID="upViajesImprimir" runat="server">
                                    <ContentTemplate>

                                        <div class="row">
                                            <div class="col-md-6 pull-left" style="margin-right: 10px; margin-bottom: 10px;">
                                                <div class="input-group">
                                                    <input type="text" id="txbFiltro1" class="form-control datepicker" placeholder="Desde" runat="server" style="width: 120px;">
                                                    <span class="input-group-btn"></span>

                                                    <input type="text" id="txbFiltro2" class="form-control datepicker" placeholder="Hasta" runat="server" style="width: 120px;">
                                                    <span class="input-group-btn"></span>

                                                    <asp:Button ID="btnSearch" runat="server" Text="Filtrar" CssClass="btn btnUpdate btn-sm"
                                                        OnClick="btnSearch_Click" UseSubmitBehavior="false" ClientIDMode="Static" CausesValidation="false" />
                                                </div>
                                            </div>
                                            <div class="col-md-2 pull-right">
                                                <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-sm btn-warning pull-right" OnClick="PrintAllPages" Text="Imprimir" />
                                                <%--<a id="btnPrint" role="button" class="btn btn-sm btn-warning pull-right">Imprimir</a>--%>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 pull-left">
                                                <h2>
                                                    <asp:Label Text="[Nombre fletero]" runat="server" ID="lblFleteroName_2" /></h2>
                                            </div>
                                        </div>

                                        <asp:Label ID="gridViajesImprimirlblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        <asp:GridView ID="gridViajesImprimir" runat="server" ClientIDMode="Static" HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle"
                                            AutoGenerateColumns="false" CssClass="table table-hover table-striped" AllowPaging="true" PageSize="30"
                                            DataKeyNames="Viaje_ID"
                                            OnRowDataBound="gridViajesImprimir_RowDataBound"
                                            OnRowCommand="gridViajesImprimir_RowCommand"
                                            OnPageIndexChanging="gridViajesImprimir_PageIndexChanging">

                                            <HeaderStyle VerticalAlign="Middle" />
                                            <RowStyle Font-Size="Smaller" />

                                            <Columns>
                                                <asp:BoundField DataField="Fletero_ID" HeaderText="ID" HtmlEncode="false" Visible="false" />
                                                <asp:BoundField DataField="Viaje_ID" HeaderText="ID" HtmlEncode="false" Visible="false" />
                                                <asp:TemplateField HeaderText="FECHA">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFechaPago" runat="server" CommandName="View" Text='<%# Eval("Fecha_pago", "{0:dd-MM-yyyy}") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="MERCADERÍA">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMercaderia" runat="server" CommandName="View" Text='<%# Eval("Comentarios") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="KILOS">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKilos" runat="server" CommandName="View" Text='<%# Eval("Comentarios") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="VALOR">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblValor" runat="server" CommandName="View" Text='<%# Eval("Comentarios") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="IMPORTE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblImporte" runat="server" CommandName="View" Text='<%# Eval("Comentarios") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Monto" HeaderText="PAGO" DataFormatString="{0:0.00}" HtmlEncode="False" />
                                                <asp:TemplateField HeaderText="SALDO">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSaldo" runat="server" CommandName="View" Text='<%# Eval("Comentarios") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Label ID="lblGridViajesImprimirCount" runat="server" ClientIDMode="Static" Text="# 0" CssClass="lblResultados label label-info"></asp:Label>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <h2>
                                    <label class="label label-danger">Sección en construcción. NO USAR.</label></h2>

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
                    <table class="table">
                        <tr>
                            <td>Fecha de pago: 
                            <asp:TextBox ID="add_txbFecha" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control datepicker" MaxLength="30" DataFormatString="{0:dd-MM-yyyy}" TabIndex="1"></asp:TextBox>
                                <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="addToday(1)">
                                    <i class="fa fa-calendar-check-o" title="Hoy"></i>
                                </button>
                            </td>
                        </tr>
                        <tr>
                            <td>Forma de pago: 
                            <asp:DropDownList ID="add_ddlFormas" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="2" />
                                <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('forma_pago')">
                                    <i class="fa fa-plus"></i>
                                </button>
                            </td>
                        </tr>
                        <tr>
                            <td>Monto: 
                                <asp:TextBox ID="add_txbMonto" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" TabIndex="3" />
                                <asp:CompareValidator ID="vadd_txbMonto" runat="server" ControlToValidate="add_txbMonto" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                            </td>
                        </tr>
                        <tr>
                            <td>Comentarios: 
                                <asp:TextBox ID="add_txbComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" TabIndex="4" />
                            </td>
                        </tr>

                    </table>
                </div>
                <div class="modal-footer">
                    <button class="btn" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();">Cerrar</button>
                    <a id="aIngresarPago" class="btn btn-primary" onclick="IngresarPago();">Guardar</a>

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
                    <table class="table">
                        <tr>
                            <td>Fecha de pago: 
                            <asp:TextBox ID="edit_txbFecha" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control datepicker" MaxLength="30" DataFormatString="{0:dd-MM-yyyy}" TabIndex="5"></asp:TextBox>
                                <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="addToday(2)">
                                    <i class="fa fa-calendar-check-o" title="Hoy"></i>
                                </button>
                            </td>
                        </tr>
                        <tr>
                            <td>Forma de pago: 
                            <asp:DropDownList ID="edit_ddlFormas" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="6" />
                                <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('forma_pago')">
                                    <i class="fa fa-plus"></i>
                                </button>
                            </td>
                        </tr>
                        <tr>
                            <td>Monto: 
                                <asp:TextBox ID="edit_txbMonto" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" TabIndex="7" />
                                <asp:CompareValidator ID="vedit_txbMonto" runat="server" ControlToValidate="edit_txbMonto" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                            </td>
                        </tr>
                        <tr>
                            <td>Comentarios: 
                                <asp:TextBox ID="edit_txbComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" TabIndex="8" />
                            </td>
                        </tr>

                    </table>
                </div>
                <div class="modal-footer">
                    <button class="btn" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();">Cerrar</button>
                    <a id="aModificarPago" class="btn btn-primary" onclick="ModificarPago_2();">Guardar</a>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- Modal modificar pago END -->

    <!-- Modal viaje ficticio BEGIN -->
    <div id="addFicticioModal" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true"
        style="display: none; max-width: 500px; overflow: hidden;" class="modal fade dark in">

        <div class="modal-header">
            <h3 id="addFicticioModalLabel">Modificar saldo anterior</h3>
        </div>
        <asp:UpdatePanel ID="upAddFicticio" runat="server">
            <ContentTemplate>
                <%--<asp:Button ID="btnSubmit_upAddFicticio" runat="server" OnClick="btnSubmit_upAddFicticio_Click" Style="display: none" />--%>
                <div class="modal-body">
                    <table class="table">
                        <tr>
                            <td>Saldo anterior (precio de venta): 
                                                <asp:TextBox ID="modalAddFicticio_txbSaldo" runat="server" ClientIDMode="Static" CssClass="form-control with_border" MaxLength="30" TabIndex="1" Text="0"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Comentarios: 
                                                <asp:TextBox ID="modalAddFicticio_txbComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" TabIndex="2" />
                            </td>
                        </tr>
                    </table>
                    <p style="color: orange; margin: 0;">Importante: El Saldo ingresado se sumará a los viajes ya existentes del fletero.</p>

                </div>
                <div class="modal-footer">
                    <button class="btn" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();">Cerrar</button>
                    <a id="aNuevoViajeFicticio" class="btn btn-primary" onclick="ViajeFicticio_2();">Guardar</a>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- Modal Viaje ficticio END -->

    <script type="text/javascript">
        setTimeout(loadInputDDL, 1000);
    </script>

</asp:Content>
