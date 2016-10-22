﻿<%@ Page Title="Viajes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Viajes.aspx.cs" Inherits="Bonisoft_2.Pages.Viajes" EnableEventValidation="false" %>

<%@ Register Src="~/User_Controls/Dinamicos/Mercaderias.ascx" TagPrefix="uc1" TagName="Mercaderias" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="/assets/dist/css/jquery.modal.css">
    <link rel="stylesheet" href="/assets/dist/css/popbox.css">

    <!-- PAGE CSS -->
    <link rel="stylesheet" href="/assets/dist/css/pages/Viajes.css">
    <link rel="stylesheet" href="/assets/dist/css/pages/Modal_styles.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->
    <script type="text/javascript" src="/assets/dist/js/jquery.quicksearch.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.modal.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.tablesorter.js"></script>
    <script type="text/javascript" src="/assets/dist/js/popbox.js"></script>

    <!-- PAGE JS -->
    <script type="text/javascript" src="/assets/dist/js/AuxiliarFunctions.js"></script>
    <script type="text/javascript" src="/assets/dist/js/pages/Viajes.js"></script>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box box-default">
        <div class="box-header with-border" style="padding-bottom: 0;">

            <div class="row">
                <div class="col-md-9">
                    <h1 style="font-size: 24px;">Menú de Viajes</h1>
                </div>
            </div>

            <div id="tabsViajes">
                <ul>
                    <li><a href="#tabsViajes_1" class="tabViajes">Viajes en Curso</a></li>
                    <li><a href="#tabsViajes_2" class="tabViajes">Histórico</a></li>
                </ul>

                <!-- Tab Viajes En Curso BEGIN -->
                <div id="tabsViajes_1">

                    <div style="text-align: center">

                        <asp:UpdatePanel ID="upGridViajesEnCurso" runat="server">
                            <ContentTemplate>

                                <asp:HiddenField ID="hdn_notificaciones_viajeID" runat="server" ClientIDMode="Static" />
                                <asp:HiddenField ID="hdn_editViaje_viajeID" runat="server" ClientIDMode="Static" />
                                <asp:HiddenField ID="hdn_notificacionesPesadaOrigenID" runat="server" ClientIDMode="Static" />
                                <asp:HiddenField ID="hdn_notificacionesPesadaDestinoID" runat="server" ClientIDMode="Static" />

                                <div class="row" style="margin-bottom: 10px;">
                                    <div class="col-md-2 pull-left">
                                        <a href="#addModal" rel="modal:open" class="btn btn-success pull-left">Iniciar viaje</a>
                                    </div>

                                    <div class="col-md-3 pull-right">
                                        <form action="#" method="get" class="sidebar-form" style="display: block !important; width: 100%;">
                                            <div class="input-group ">
                                                <input type="text" id="txbSearchViajesEnCurso" name="q" class="form-control" placeholder="Buscar...">
                                                <span class="input-group-btn">
                                                    <button type="button" name="search" id="search-btn1" class="btn btn-flat">
                                                        <i class="fa fa-search"></i>
                                                    </button>
                                                </span>

                                                <asp:UpdatePanel ID="upUpdateViajesEnCurso" runat="server">
                                                    <ContentTemplate>

                                                        <asp:Button ID="btnUpdateViajesEnCurso" runat="server" Text="Actualizar" CssClass="btn btnUpdate"
                                                            OnClick="btnUpdateViajesEnCurso_Click" UseSubmitBehavior="false" ClientIDMode="Static" CausesValidation="false" />

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </form>
                                    </div>
                                </div>

                                <asp:Label ID="gridViajesEnCurso_lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="gridViajesEnCurso" runat="server" ClientIDMode="Static" HorizontalAlign="Center"
                                    AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped" PageSize="30"
                                    DataKeyNames="Viaje_ID"
                                    OnRowDataBound="gridViajesEnCurso_RowDataBound"
                                    OnRowCommand="gridViajesEnCurso_RowCommand"
                                    OnPageIndexChanging="grid2_PageIndexChanging">

                                    <Columns>
                                        <asp:BoundField DataField="Viaje_ID" HeaderText="ID" HtmlEncode="false" ReadOnly="true" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Fecha_partida" HeaderText="Fecha partida" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                        <asp:TemplateField HeaderText="Proveedor">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblProveedor" runat="server" CommandName="View" Text='<%# Eval("Proveedor_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fletero">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblFletero" runat="server" CommandName="View" Text='<%# Eval("Fletero_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cliente">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblCliente" runat="server" CommandName="View" Text='<%# Eval("Cliente_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Precio_compra" HeaderText="Precio compra" DataFormatString="{0:C0}" HtmlEncode="False" />
                                        <asp:BoundField DataField="Precio_venta" HeaderText="Precio venta" DataFormatString="{0:C0}" HtmlEncode="False" />
                                        <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />

                                        <asp:ButtonField CommandName="notificar" ControlStyle-CssClass="btn btn-info btn-xs" ButtonType="Link" Text="" HeaderText="Notificar">
                                            <ControlStyle CssClass="btn btn-warning btn-xs fa fa-bullhorn"></ControlStyle>
                                        </asp:ButtonField>

                                        <asp:TemplateField HeaderText="Acciones" ControlStyle-CssClass="btn btn-info btn-xs">
                                            <ItemTemplate>
                                                <a id="btnModificar" role="button" onclick='<%# "ModificarViaje_1(" +Eval("Viaje_ID") + ");" %>' class="btn btn-info btn-xs glyphicon glyphicon-pencil"></a>
                                                <a id="btnBorrar" role="button" onclick='<%# "BorrarViajeEnCurso(" +Eval("Viaje_ID") + ");" %>' class="btn btn-danger btn-xs glyphicon glyphicon-remove"></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblGridViajesEnCursoCount" runat="server" ClientIDMode="Static" Text="# 0" CssClass="lblResultados label label-info"></asp:Label>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <!-- Modal Iniciar viaje BEGIN -->
                        <div id="addModal" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true"
                            style="display: none; max-width: 800px; overflow: hidden;" class="modal fade dark in">

                            <div class="modal-header">
                                <h3 id="addModalLabel">Iniciar viaje</h3>
                            </div>
                            <asp:UpdatePanel ID="upAdd" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnSubmit_upAdd" runat="server" OnClick="btnSubmit_upAdd_Click" Style="display: none" />
                                    <div class="modal-body">
                                        <table class="table table-hover">
                                            <tr>
                                                <td>Fecha de inicio: 
                                                <asp:TextBox ID="modalAdd_txbFecha1" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td>Fecha de llegada (tentativa): 
                                                <asp:TextBox ID="modalAdd_txbFecha2" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30" TabIndex="2"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Proveedor: 
                                                <asp:DropDownList ID="modalAdd_ddlProveedores" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="3" />
                                                </td>
                                                <td>Cliente: 
                                                <asp:DropDownList ID="modalAdd_ddlClientes" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="4" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Cargadores: 
                                                <asp:DropDownList ID="modalAdd_ddlCargadores" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="5" />
                                                </td>
                                                <td>Lugar de carga: 
                                                <asp:TextBox ID="modalAdd_txbLugarCarga" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="6" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Fletero: 
                                                <asp:DropDownList ID="modalAdd_ddlFleteros" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="7" />
                                                </td>
                                                <td>Camión: 
                                                <asp:DropDownList ID="modalAdd_ddlCamiones" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="8" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Chofer: 
                                                <asp:DropDownList ID="modalAdd_ddlChoferes" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="9" />
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>Comentarios: 
                                                <asp:TextBox ID="modalAdd_txbComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" TabIndex="10" />
                                                </td>
                                                <td></td>
                                            </tr>

                                        </table>
                                    </div>
                                    <div class="modal-footer">
                                        <button class="btn" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();">Cerrar</button>
                                        <a id="aNuevoViaje" class="btn btn-primary" onclick="NuevoViaje();">Agregar</a>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- Modal Iniciar viaje END -->

                        <!-- Modal Editar BEGIN -->
                        <div id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true" style="display: none; max-width: 800px; overflow: hidden;" class="modal fade dark in">

                            <div class="modal-header">
                                <h3 id="editModalLabel">Modificar viaje</h3>
                            </div>
                            <asp:UpdatePanel ID="upEdit" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <table class="table table-hover">
                                            <tr>
                                                <td>Fecha de inicio: 
                                                <asp:TextBox ID="modalEdit_txbFecha1" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30" TabIndex="11"></asp:TextBox>
                                                </td>
                                                <td>Fecha de llegada (tentativa): 
                                                <asp:TextBox ID="modalEdit_txbFecha2" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30" TabIndex="12"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Proveedor: 
                                                <asp:DropDownList ID="modalEdit_ddlProveedores" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="13" />
                                                </td>
                                                <td>Cliente: 
                                                <asp:DropDownList ID="modalEdit_ddlClientes" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="14" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Cargadores: 
                                                <asp:DropDownList ID="modalEdit_ddlCargadores" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="15" />
                                                </td>
                                                <td>Lugar de carga: 
                                                <asp:TextBox ID="modalEdit_txbLugarCarga" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="16" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Fletero: 
                                                <asp:DropDownList ID="modalEdit_ddlFleteros" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="17" />
                                                </td>
                                                <td>Camión: 
                                                <asp:DropDownList ID="modalEdit_ddlCamiones" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="18" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Chofer: 
                                                <asp:DropDownList ID="modalEdit_ddlChoferes" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="19" />
                                                </td>
                                                <td>Comentarios:
                                                    <asp:TextBox ID="modalEdit_txbComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" TabIndex="20" />
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                    <div class="modal-footer">
                                        <button class="btn" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();">Cancelar</button>
                                        <a id="aModificarViaje" class="btn btn-primary" onclick="ModificarViaje_2();">Guardar</a>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- Modal Editar END -->

                        <!-- Modal Notificaciones BEGIN -->
                        <div id="notificacionesModal" tabindex="-1" role="dialog" aria-labelledby="notificacionesModalLabel" aria-hidden="true" style="display: none; max-width: 1000px; overflow: hidden;" class="modal fade dark in">
                            <asp:UpdatePanel ID="upNotificaciones" runat="server">
                                <ContentTemplate>

                                    <div class="modal-header">
                                        <div class="row">
                                            <div class="col-md-10 pull-left">
                                                <h3 id="notificacionesModalLabel">Notificaciones</h3>
                                            </div>

                                            <div class="col-md-2 pull-right" style="padding-top: 10px;">
                                                <a id="lnkViajeDestino" class="btn btn-warning" onclick="FinDelViaje();">FIN del Viaje</a>
                                            </div>
                                        </div>

                                    </div>

                                    <div id="tabsNotificaciones">
                                        <ul>
                                            <li><a href="#tabsNotificaciones_1" class="tabViajes">#1 Mercaderías</a></li>
                                            <li><a href="#tabsNotificaciones_2" class="tabViajes">#2 Pesadas</a></li>
                                            <li><a href="#tabsNotificaciones_3" class="tabViajes">#3 Venta</a></li>
                                        </ul>

                                        <div id="tabsNotificaciones_1">

                                            <h4>Asignar mercaderías</h4>

                                            <div class="divTables" id="divMercaderias" style="display: block;">
                                                <asp:UpdatePanel ID="upMercaderias" runat="server" OnLoad="upMercaderias_Load">
                                                    <ContentTemplate>
                                                        <uc1:Mercaderias runat="server" ID="Mercaderias" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>

                                        </div>

                                        <div id="tabsNotificaciones_2">

                                            <div style="z-index: 10001;">
                                                <div class="row">
                                                    <div class="col-md-8 pull-left">
                                                        <h4 style="width: 80%; float: left;">Pesada origen</h4>
                                                    </div>
                                                    <div class="col-md-3 pull-right">
                                                        <div class="row" style="float: right; cursor: pointer;">
                                                            <a id="aOrigenCopiar" style="margin-right: 5px; color: black;" onclick="copiarPesadas(1);" class="btn btn-sm btn-default">Copiar de destino</a>
                                                            <%--<a id="aOrigenGuardar" style="float: right;" onclick="guardarPesadas(1);" class="btn btn-sm btn-primary">Guardar</a>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-body panel panel-default" style="padding-bottom: 0; padding-top: 0; position: inherit; background: #e9e9e9; color: #333333;">
                                                <table class="table">
                                                    <tr>
                                                        <td>Lugar: 
                                                        <asp:TextBox ID="txb_pesada1Lugar" runat="server" ClientIDMode="Static" CssClass="form-control with_border" MaxLength="30" TabIndex="21"></asp:TextBox>
                                                        </td>
                                                        <td>Fecha: 
                                                        <asp:TextBox ID="txb_pesada1Fecha" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30" DataFormatString="{dd-mm-yyyy}" TabIndex="22"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Peso bruto: 
                                                        <asp:TextBox ID="txb_pesada1Peso_bruto" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" DataFormatString="{dd-mm-yyyy}" TabIndex="23"></asp:TextBox>
                                                        </td>
                                                        <td>Peso neto: 
                                                        <asp:TextBox ID="txb_pesada1Peso_neto" runat="server" ClientIDMode="Static" CssClass="form-control with_border" MaxLength="30" TabIndex="24"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Nombre balanza: 
                                                        <asp:TextBox ID="txb_pesada1Nombre" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" TabIndex="25"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>

                                            <div style="z-index: 10001;">
                                                <div class="row">
                                                    <div class="col-md-8 pull-left">
                                                        <h4 style="width: 80%; float: left;">Pesada destino</h4>
                                                    </div>
                                                    <div class="col-md-3 pull-right">
                                                        <div class="row" style="float: right; cursor: pointer;">
                                                            <a id="aDestinoCopiar" style="margin-right: 5px; color: black;" onclick="copiarPesadas(2);" class="btn btn-sm btn-default">Copiar de origen</a>
                                                            <%--<a id="aDestinoGuardar" style="float: right;" onclick="guardarPesadas(2);" class="btn btn-sm btn-primary">Guardar</a>--%>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="modal-body panel panel-default" style="padding-bottom: 0; padding-top: 0; position: inherit; background: #e9e9e9; color: #333333;">
                                                <table class="table">
                                                    <tr>
                                                        <td>Lugar: 
                                                      <asp:TextBox ID="txb_pesada2Lugar" runat="server" ClientIDMode="Static" CssClass="form-control with_border" MaxLength="30" TabIndex="26"></asp:TextBox>
                                                        </td>
                                                        <td>Fecha: 
                                                        <asp:TextBox ID="txb_pesada2Fecha" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30" DataFormatString="{0:d-MM-yyyy}" TabIndex="27"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Peso bruto: 
                                                         <asp:TextBox ID="txb_pesada2Peso_bruto" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" TabIndex="28"></asp:TextBox>
                                                        </td>
                                                        <td>Peso neto: 
                                                       <asp:TextBox ID="txb_pesada2Peso_neto" runat="server" ClientIDMode="Static" CssClass="form-control with_border" MaxLength="30" TabIndex="29"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Nombre balanza: 
                                                        <asp:TextBox ID="txb_pesada2Nombre" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" TabIndex="30"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>

                                                </table>

                                            </div>

                                            <div class="modal-body panel panel-default row" style="padding-bottom: 0; padding-top: 0; position: inherit; background: #e9e9e9; color: #333333; margin: 0;">
                                                    <div class="col-md-10 pull-left" style="padding: 10px;">
                                                        Comentarios:
                                                           <asp:TextBox ID="txb_pesadaComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                    </div>

                                                    <div class="col-md-2 pull-right" style="padding: 2% 0;">
                                                        <a id="aGuardarPesadas" style="float: right;" onclick="guardarAmbasPesadas();" class="btn btn-primary">Guardar</a>
                                                    </div>
                                                </div>

                                        </div>

                                        <div id="tabsNotificaciones_3">

                                            <h4>Precio de venta</h4>

                                            <div class="modal-body panel panel-default" style="padding: 0; position: inherit; background: #e9e9e9; color: #333333;">
                                                <table class="table" style="margin-bottom: 0;">
                                                    <tr>
                                                        <td>Precio de compra: 
                                                                <h2><label id="notif_lblPrecioCompra" runat="server" class="label label-danger">0</label></h2>
                                                        </td>
                                                        <td>Precio de flete: 
                                                        <asp:TextBox ID="notif_txbPrecioFlete" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0" TabIndex="31"></asp:TextBox>
                                                            <asp:CompareValidator ForeColor="Red" ID="vnotif_txbPrecioFlete" runat="server" ControlToValidate="notif_txbPrecioFlete" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Currency" />
                                                        </td>
                                                        <td>Precio de descarga: 
                                                        <asp:TextBox ID="notif_txbPrecioDescarga" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0" TabIndex="32"></asp:TextBox>
                                                            <asp:CompareValidator ForeColor="Red" ID="vnotif_txbPrecioDescarga" runat="server" ControlToValidate="notif_txbPrecioDescarga" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Currency" />
                                                        </td>
                                                        <td>Ganancia por TON: 
                                                        <asp:TextBox ID="notif_txbGananciaXTon" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0" TabIndex="33"></asp:TextBox>
                                                            <asp:CompareValidator ForeColor="Red" ID="vnotif_txbGananciaXTon" runat="server" ControlToValidate="notif_txbGananciaXTon" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Currency" />
                                                        </td>
                                                        <td>% IVA (0 = no aplica): 
                                                        <asp:TextBox ID="notif_txbIVA" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0" TabIndex="34"></asp:TextBox>
                                                            <asp:CompareValidator ForeColor="Red" ID="vnotif_txbIVA" runat="server" ControlToValidate="notif_txbIVA" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Currency" />
                                                        </td>
                                                        <td>
                                                            <a class="btn btn-default" style="color: black;" onclick="calcularPrecioVenta();">Calcular</a>
                                                        </td>
                                                        <td>Precio de venta: 
                                                            <h2>
                                                                <label id="notif_lblPrecioVenta" class="label label-success">0</label>
                                                            </h2>
                                                        </td>

                                                    </tr>
                                                </table>

                                                <hr style="margin-top: 5px; margin-bottom: 5px;" />
                                                <div class="row" style="margin: 0;">
                                                    <div class="col-md-10 pull-left" style="padding: 10px;">
                                                        <p class="text-info">1) Precio de compra = Peso neto destino * Precio por tonelada de todas las mercaderías.</p>
                                                        <p class="text-info">2) Precio de venta = Precio de compra + Flete + Descarga + Ganancia + % IVA.</p>
                                                </div>

                                                    <div class="col-md-2 pull-right" style="padding: 10px;">
                                                        <a id="lnkGuardarPrecioVenta" class="btn btn-primary" onclick="GuardarPrecioVenta()">Guardar</a>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>

                                    </div>

                                </ContentTemplate>

                            </asp:UpdatePanel>
                        </div>
                        <!-- Modal Notificaciones END -->

                    </div>

                </div>
                <!-- Tab Viajes En Curso END -->

                <!-- Tab Viajes Histórico BEGIN -->
                <div id="tabsViajes_2">

                    <div class="row">



                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-2 pull-right" style="margin-right: 10px; margin-bottom: 10px;">
                                    <form action="#" method="get" class="sidebar-form" style="display: block !important; width: 100%;">
                                        <div class="input-group ">
                                            <input type="text" id="txbSearchViajes" name="q" class="form-control" placeholder="Buscar...">
                                            <span class="input-group-btn">
                                                <button type="button" name="search" id="search-btn" class="btn btn-flat">
                                                    <i class="fa fa-search"></i>
                                                </button>
                                            </span>
                                        </div>
                                    </form>
                                </div>
                            </div>

                            <div class="row">
                                <div id="divContent" style="overflow: auto;">

                                    <div style="text-align: center">

                                        <asp:UpdatePanel ID="upGridViajes" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>

                                                <asp:Label ID="gridViajes_lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                <asp:GridView ID="gridViajes" runat="server" ClientIDMode="Static" HorizontalAlign="Center" AutoGenerateColumns="False"
                                                    ShowFooter="False" CssClass="table table-hover table-striped" PageSize="30" AllowPaging="true"
                                                    DataKeyNames="Viaje_ID"
                                                    OnRowCommand="gridViajes_RowCommand"
                                                    OnRowCancelingEdit="gridViajes_RowCancelingEdit"
                                                    OnRowEditing="gridViajes_RowEditing"
                                                    OnRowUpdating="gridViajes_RowUpdating"
                                                    OnRowDeleting="gridViajes_RowDeleting"
                                                    OnRowDataBound="gridViajes_RowDataBound"
                                                    OnPageIndexChanging="grid_PageIndexChanging">

                                                    <RowStyle Font-Size="Smaller" />
                                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                    <EmptyDataTemplate>
                                                        ¡No hay clientes con los parámetros seleccionados!  
                                                    </EmptyDataTemplate>

                                                    <Columns>
                                                        <asp:BoundField DataField="Viaje_ID" HeaderText="ID" HtmlEncode="false" ReadOnly="true" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                        <asp:TemplateField HeaderText="Fecha partida">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txb11" runat="server" Text='<%# Bind("Fecha_partida", "{0:dd-MM-yyyy}") %>' CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl11" runat="server" Text='<%# Bind("Fecha_partida", "{0:dd-MM-yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txbNew11" runat="server" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Fecha llegada">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txb12" runat="server" Text='<%# Bind("Fecha_llegada", "{0:dd-MM-yyyy}") %>' CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl12" runat="server" Text='<%# Bind("Fecha_llegada", "{0:dd-MM-yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txbNew12" runat="server" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Proveedor">
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlProveedores1" runat="server" CssClass="form-control" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbl17" runat="server" CommandName="View" Text='<%# Bind("Proveedor_ID") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlProveedores2" runat="server" CssClass="form-control" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cliente">
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlClientes1" runat="server" CssClass="form-control" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbl18" runat="server" CommandName="View" Text='<%# Bind("Cliente_ID") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlClientes2" runat="server" CssClass="form-control" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Precio compra">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txb2" runat="server" Text='<%# Bind("Precio_compra") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                                <asp:CompareValidator ForeColor="Red" ID="vtxb2" runat="server" ControlToValidate="txb2" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Currency" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2" runat="server" Text='<%# Bind("Precio_compra", "{0:C0}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txbNew2" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                                <asp:CompareValidator ForeColor="Red" ID="vtxbNew2" runat="server" ControlToValidate="txbNew2" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Currency" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Precio venta">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txb3" runat="server" Text='<%# Bind("Precio_venta") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                                <asp:CompareValidator ForeColor="Red" ID="vtxb3" runat="server" ControlToValidate="txb3" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Currency" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Precio_venta", "{0:C0}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txbNew3" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                                <asp:CompareValidator ForeColor="Red" ID="vtxbNew3" runat="server" ControlToValidate="txbNew3" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Currency" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Pesada origen/Neto">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="ddlPesadaOrigen1" runat="server" Text='<%# Bind("Carga") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl8" runat="server" Text='<%# Bind("Pesada_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="ddlPesadaOrigen2" runat="server" Text='<%# Bind("Carga") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Pesada destino/Neto">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="ddlPesadaDestino1" runat="server" Text='<%# Bind("Carga") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl9" runat="server" Text='<%# Bind("Pesada_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="ddlPesadaDestino2" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cargadores">
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlCargadores1" runat="server" CssClass="form-control" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbl10" runat="server" CommandName="View" Text='<%# Bind("Empresa_de_carga_ID") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlCargadores2" runat="server" CssClass="form-control" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Lugar carga">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txb6" runat="server" Text='<%# Bind("Carga") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl6" runat="server" Text='<%# Bind("Carga") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txbNew6" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Fletero">
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlFleteros1" runat="server" CssClass="form-control" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbl16" runat="server" CommandName="View" Text='<%# Bind("Fletero_ID") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlFleteros2" runat="server" CssClass="form-control" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Camión">
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlCamiones1" runat="server" CssClass="form-control" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbl13" runat="server" CommandName="View" Text='<%# Bind("Camion_ID") %>'></asp:LinkButton>
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
                                                                <asp:LinkButton ID="lbl14" runat="server" CommandName="View" Text='<%# Bind("Chofer_ID") %>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:DropDownList ID="ddlChoferes2" runat="server" CssClass="form-control" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comentarios">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txb15" runat="server" Text='<%# Bind("Comentarios") %>' CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl15" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txbNew15" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ClientIDMode="AutoID"
                                                                    CommandArgument='' CssClass="btn btn-info btn-xs btn-command" CausesValidation="false"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" ClientIDMode="AutoID"
                                                                    OnClientClick='return confirm("Está seguro que desea borrar este registro?");'
                                                                    CommandArgument='' CssClass="btn btn-danger btn-xs btn-command"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="Update" CausesValidation="false" ClientIDMode="AutoID"
                                                                    CommandArgument='' CssClass="btn btn-success btn-xs btn-command"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" CausesValidation="false" ClientIDMode="AutoID"
                                                                    CommandArgument='' CssClass="btn btn-warning btn-xs btn-command"><span aria-hidden="true" class="glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="newGrp" CommandName="InsertNew" ClientIDMode="AutoID"
                                                                    CommandArgument='' CssClass="btn btn-info btn-xs btn-command"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" ClientIDMode="AutoID"
                                                                    CommandArgument='' CssClass="btn btn-warning btn-xs btn-command"><span aria-hidden="true" class="glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>
                                                <asp:Label ID="lblGridViajesCount" runat="server" ClientIDMode="Static" Text="# 0" CssClass="lblResultados label label-info"></asp:Label>

                                                <asp:HiddenField ClientIDMode="Static" ID="hdnViajesCount" runat="server" />

                                            </ContentTemplate>
                                            <Triggers>
                                                <%--<asp:AsyncPostBackTrigger ControlID="lnkEdit" />--%>
                                            </Triggers>
                                        </asp:UpdatePanel>

                                    </div>
                                </div>
                            </div>

                        </div>


                    </div>

                </div>
                <!-- Tab Viajes Histórico END -->

            </div>
        </div>
    </div>

    <div id="dialog" title="Mensaje Bonisoft" style="height: 0 !important;">
        <p style="text-align: left;"></p>
    </div>


    <div id="dialog_borrarViaje" title="Mensaje Bonisoft" style="height: 0 !important;">
        <p style="text-align: left;"></p>

        <div class="form-group">
            <div class="row row-short" style="padding: 10px;">

                <input type="password" id="txbClave" class="form-control" style="width: 90%; display: none;" placeholder="Ingrese su contraseña"
                    name="login-username" />
                <!--  -->
            </div>
        </div>

    </div>

    <!-- popbox: Remove element -->
    <div class='popbox' style="margin-top: 15px; margin-right: 6px; display: none;"></div>
    <div class='msg-box popbox' id="divPopbox" style="width: 300px; height: 240px; margin-top: 10px; right: 10%;">
        <div class='arrow' style="left: 250px;"></div>
        <div class='arrow-border' style="left: 250px;"></div>
        <div class="row row-short" style="padding: 10px;">
            <label class="label" style="font-size: 100%; color: rgba(68, 89, 156, 1); font-size: 16px;">Borrar elemento seleccionado</label>
        </div>
        <div class="form-group">
            <div class="row row-short" style="padding: 10px;">

                <div id="divRemoveElementMessage" class="alert alert-warning" role="alert">
                    <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
                    <span class="sr-only">Info:</span> Está a punto de borrar el elemento, confirme su contraseña para continuar
                </div>
                <input type="password" class="form-control" id="txbConfirmRemoveElement" placeholder="Contraseña" name="login-username" />
                <!--  -->
            </div>
            <div id="popbox_footer" class="row row-short pull-right" style="margin-right: 15px; margin-top: -7px;">
                <button id="btnConfirmRemoveElement" type="button" class="btn btn-default" title="Confirmar borrar elemento" runat="server">
                    <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                </button>
            </div>
        </div>
    </div>

    <!-- Add Hdn Fields -->
    <asp:HiddenField ID="hdn_modalAdd_txbFecha1" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalAdd_txbFecha2" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalAdd_ddlProveedores" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalAdd_ddlClientes" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalAdd_ddlCargadores" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalAdd_txbLugarCarga" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalAdd_ddlFleteros" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalAdd_ddlCamiones" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalAdd_ddlChoferes" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalAdd_txbComentarios" runat="server" ClientIDMode="Static" />

    <!-- Edit Hdn Fields -->
    <asp:HiddenField ID="hdn_modalEdit_txbFecha1" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalEdit_txbFecha2" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalEdit_ddlProveedores" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalEdit_ddlClientes" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalEdit_ddlCargadores" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalEdit_txbLugarCarga" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalEdit_ddlFleteros" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalEdit_ddlCamiones" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalEdit_ddlChoferes" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalEdit_txbComentarios" runat="server" ClientIDMode="Static" />

    <!-- Notificaciones Hdn Fields - Pesada origen -->
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas1_txbLugar" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas1_txbFecha" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas1_txbPesoBruto" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas1_txbPesoNeto" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas1_txbNombre" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas1_txbComentarios" runat="server" ClientIDMode="Static" />

    <!-- Notificaciones Hdn Fields - Pesada destino -->
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas2_txbLugar" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas2_txbFecha" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas2_txbPesoBruto" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas2_txbPesoNeto" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas2_txbNombre" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalNotificaciones_pesadas2_txbComentarios" runat="server" ClientIDMode="Static" />

    <!-- Mercaderia Hdn Fields - Add -->
    <asp:HiddenField ID="hdn_modalMercaderia_txbNew4" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txbNew5" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txbNew7" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_ddlVariedad2" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_ddlProcesador2" runat="server" ClientIDMode="Static" />

    <!-- Mercaderia Hdn Fields - Edit -->
    <asp:HiddenField ID="hdn_modalMercaderia_txb4" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txb5" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txb7" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_ddlVariedad1" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_ddlProcesador1" runat="server" ClientIDMode="Static" />

</asp:Content>
