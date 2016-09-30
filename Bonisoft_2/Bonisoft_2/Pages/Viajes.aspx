﻿<%@ Page Title="Viajes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Viajes.aspx.cs" Inherits="Bonisoft_2.Pages.Viajes" EnableEventValidation="false" %>

<%@ Register Src="~/User_Controls/Dinamicos/Mercaderias.ascx" TagPrefix="uc1" TagName="Mercaderias" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="/assets/dist/css/jquery.modal.css">

    <!-- Page CSS -->
    <link rel="stylesheet" href="/assets/dist/css/pages/Viajes.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->
    <script type="text/javascript" src="/assets/dist/js/jquery.quicksearch.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.modal.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.tablesorter.js"></script>

    <!-- Page JS -->
    <script src="/assets/dist/js/pages/Viajes.js"></script>

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

                        <asp:UpdatePanel ID="upCrudGrid" runat="server">
                            <ContentTemplate>

                                <asp:HiddenField ID="hdn_notificaciones_viajeID" runat="server" ClientIDMode="Static" />
                                <asp:HiddenField ID="hdn_editViaje_viajeID" runat="server" ClientIDMode="Static" />
                                <asp:HiddenField ID="hdn_notificacionesPesadaOrigenID" runat="server" ClientIDMode="Static" />
                                <asp:HiddenField ID="hdn_notificacionesPesadaDestinoID" runat="server" ClientIDMode="Static" />

                                <div class="row" style="margin-bottom: 10px;">
                                    <div class="col-md-2 pull-left">
                                        <a href="#addModal" rel="modal:open" class="btn btn-info pull-left">Iniciar viaje</a>
                                    </div>

                                    <div class="col-md-2 pull-right">
                                        <form action="#" method="get" class="sidebar-form" style="display: block !important; width: 100%;">
                                            <div class="input-group ">
                                                <input type="text" id="txbSearchViajesEnCurso" name="q" class="form-control" placeholder="Buscar...">
                                                <span class="input-group-btn">
                                                    <button type="button" name="search" id="search-btn1" class="btn btn-flat">
                                                        <i class="fa fa-search"></i>
                                                    </button>
                                                </span>
                                            </div>
                                        </form>
                                    </div>
                                </div>

                                <asp:Label ID="gridViajesEnCurso_lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="gridViajesEnCurso" runat="server" ClientIDMode="Static" HorizontalAlign="Center"
                                    AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped"
                                    DataKeyNames="Viaje_ID" 
                                    OnRowDataBound="gridViajesEnCurso_RowDataBound"
                                    OnRowCommand="gridViajesEnCurso_RowCommand" >
                                    <Columns>

                                        <asp:BoundField DataField="Fecha_partida" HeaderText="Fecha partida" DataFormatString="{0:d MMMM, yyyy}" HtmlEncode="false" />
                                        <asp:TemplateField HeaderText = "Proveedor">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblProveedor" runat="server" CommandName="View" Text='<%# Eval("Proveedor_ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText = "Fletero">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblFletero" runat="server" CommandName="View" Text='<%# Eval("Fletero_ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText = "Cliente">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblCliente" runat="server" CommandName="View" Text='<%# Eval("Cliente_ID") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Precio_compra" HeaderText="Precio compra" DataFormatString="{0:C0}" HtmlEncode="False" />
                                        <asp:BoundField DataField="Precio_venta" HeaderText="Precio venta" DataFormatString="{0:C0}" HtmlEncode="False" />
                                        <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />

                                        <asp:ButtonField CommandName="notificar" ControlStyle-CssClass="btn btn-info" ButtonType="Link" Text="" HeaderText="Notificar">
                                            <ControlStyle CssClass="btn btn-info btn-xs fa fa-bullhorn"></ControlStyle>
                                        </asp:ButtonField>

                                        <asp:TemplateField HeaderText="Acciones" ControlStyle-CssClass="btn btn-info btn-xs">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnModificar" runat="server" CommandName="editViajeEnCurso">
                                                    <span aria-hidden="true" class="glyphicon glyphicon-pencil"></asp:LinkButton>
                                                <asp:LinkButton ID="btnBorrar" runat="server" CommandName="deleteViajeEnCurso" 
                                                    OnClientClick="return confirm('¿Está seguro que desea borrar este registro?');">
                                                    <span aria-hidden="true" class="glyphicon glyphicon-remove"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblGridViajesEnCursoCount" runat="server" ClientIDMode="Static" Text="Resultados: 0" CssClass="lblResultados"></asp:Label>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <!-- Modal Iniciar viaje BEGIN -->
                        <div id="addModal" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true" style="display: none; max-width: 800px; overflow: hidden;">

                            <div class="modal-header">
                                <h3 id="addModalLabel">Iniciar viaje</h3>
                            </div>
                            <asp:UpdatePanel ID="upAdd" runat="server">
                                <ContentTemplate>
                                     <asp:Button ID="btnSubmit_upAdd" runat="server" OnClick="btnSubmit_upAdd_Click" style = "display:none" />
                                    <div class="modal-body">
                                        <table class="table table-bordered table-hover">
                                            <tr>
                                                <td>Fecha de inicio: 
                                                <asp:TextBox ID="modalAdd_txbFecha1" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                </td>
                                                <td>Fecha de llegada (tentativa): 
                                                <asp:TextBox ID="modalAdd_txbFecha2" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Proveedor: 
                                                <asp:DropDownList ID="modalAdd_ddlProveedores" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                                <td>Cliente: 
                                                <asp:DropDownList ID="modalAdd_ddlClientes" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Cargadores: 
                                                <asp:DropDownList ID="modalAdd_ddlCargadores" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                                <td>Lugar de carga: 
                                                <asp:TextBox ID="modalAdd_txbLugarCarga" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Fletero: 
                                                <asp:DropDownList ID="modalAdd_ddlFleteros" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                                <td>Camión: 
                                                <asp:DropDownList ID="modalAdd_ddlCamiones" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Chofer: 
                                                <asp:DropDownList ID="modalAdd_ddlChoferes" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>Comentarios: 
                                                <asp:TextBox ID="modalAdd_txbComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" />
                                                </td>
                                                <td>

                                <%--<a onclick="showItems();" style="cursor:pointer; text-decoration:underline; float:right; padding: 20px;">Actualizar</a>--%>
                                <%--<a onclick="openNewWindows();" style="cursor:pointer; text-decoration:underline; float:right; padding: 20px;">Ir a Base de datos</a>--%>


                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                    <div class="modal-footer">

                                        <asp:Button ID="btnAdd" runat="server" Text="Agregar" CssClass="btn btn-info" OnClientClick="Javascript:DoCustomPost();" OnClick="btnAddRecord1_Click" UseSubmitBehavior="false" />
                                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();">Cerrar</button>

                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <!-- Modal Iniciar viaje END -->

                        <!-- Modal Editar BEGIN -->
                        <div id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true" style="display: none; max-width: 800px; overflow: hidden;">

                            <div class="modal-header">
                                <h3 id="editModalLabel">Modificar viaje</h3>
                            </div>
                            <asp:UpdatePanel ID="upEdit" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <table class="table table-bordered table-hover">
                                            <tr>
                                                <td>Fecha de inicio: 
                                                <asp:TextBox ID="modalEdit_txbFecha1" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                </td>
                                                <td>Fecha de llegada (tentativa): 
                                                <asp:TextBox ID="modalEdit_txbFecha2" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Proveedor: 
                                                <asp:DropDownList ID="modalEdit_ddlProveedores" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                                <td>Cliente: 
                                                <asp:DropDownList ID="modalEdit_ddlClientes" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Cargadores: 
                                                <asp:DropDownList ID="modalEdit_ddlCargadores" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                                <td>Lugar de carga: 
                                                <asp:TextBox ID="modalEdit_txbLugarCarga" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Fletero: 
                                                <asp:DropDownList ID="modalEdit_ddlFleteros" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                                <td>Camión: 
                                                <asp:DropDownList ID="modalEdit_ddlCamiones" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Chofer: 
                                                <asp:DropDownList ID="modalEdit_ddlChoferes" runat="server" ClientIDMode="Static" CssClass="form-control" />
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>Comentarios: 
                                                <asp:TextBox ID="modalEdit_txbComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" EnableViewState="true" />
                                                </td>
                                                <td></td>
                                            </tr>

                                        </table>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnEdit" runat="server" Text="Modificar" CssClass="btn btn-info" OnClientClick="Javascript:DoCustomPost();" OnClick="btnEdit_Click" UseSubmitBehavior="false" />
                                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();">Cancelar</button>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnEdit" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <!-- Modal Editar END -->

                        <!-- Modal Inspeccionar BEGIN -->
                        <div id="inspectModal" tabindex="-1" role="dialog" aria-labelledby="inspectModalLabel" aria-hidden="true" style="display: none; max-width: 800px; overflow: hidden;">

                            <div class="modal-header">
                                <h3 id="inspectModalLabel">Inspeccionar viaje</h3>
                            </div>
                            <asp:UpdatePanel ID="upInspect" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <table class="table table-bordered table-hover">
                                            <tr>
                                                <td>Fecha de inicio: 
                                                <asp:Label ID="modalInspect_lblFecha1" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>Fecha de llegada (tentativa): 
                                                <asp:Label ID="modalInspect_lblFecha2" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Proveedor: 
                                                <asp:Label ID="modalInspect_lblProveedor" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>Cliente: 
                                                <asp:Label ID="modalInspect_lblCliente" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Cargadores: 
                                                <asp:Label ID="modalInspect_lblCargadores" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>Lugar de carga: 
                                                <asp:Label ID="modalInspect_lblLugarCarga" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Fletero: 
                                                <asp:Label ID="modalInspect_lblFletero" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>Camión: 
                                                <asp:Label ID="modalInspect_lblCamion" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Chofer: 
                                                <asp:Label ID="modalInspect_lblChofer" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>Comentarios: 
                                                <asp:Label ID="modalInspect_lblComentarios" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td></td>
                                            </tr>

                                        </table>
                                    </div>
                                    <div class="modal-footer">
                                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();">Cerrar</button>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- Modal Inspeccionar END -->

                        <!-- Modal Notificaciones BEGIN -->
                        <div id="notificacionesModal" tabindex="-1" role="dialog" aria-labelledby="notificacionesModalLabel"
                            aria-hidden="true" style="display: none; max-width: 1000px; overflow: hidden;">
                            <asp:UpdatePanel ID="upNotificaciones" runat="server">
                                <ContentTemplate>

                                    <div class="modal-header">
                                        <div class="row">
                                            <div class="col-md-10 pull-left">
                                                <h3 id="notificacionesModalLabel">Notificaciones</h3>
                                            </div>

                                            <div class="col-md-2 pull-right" style="padding-top: 10px;">
                                                <asp:LinkButton ID="lnkViajeDestino" runat="server" CssClass="btn btn-info" OnClick="lnkViajeDestino_Click">FIN del Viaje</asp:LinkButton>
                                                <%--<asp:LinkButton ID="lnkViajeDestino" runat="server" CssClass="btn btn-info" OnClientClick="Javascript:return finalizarViaje();">FIN del Viaje</asp:LinkButton>--%>
                                                    <%--<asp:Button ID="lnkViajeDestinoCandidate" runat="server" ClientIDMode="Static" Style="display: none;" OnClick="lnkViajeDestino_Click" />--%>
                                            </div>
                                        </div>

                                    </div>



                                    <div id="tabsNotificaciones">
                <ul>
                    <li><a href="#tabsNotificaciones_1" class="tabViajes">Mercaderías</a></li>
                    <li><a href="#tabsNotificaciones_2" class="tabViajes">Pesadas</a></li>
                    <li><a href="#tabsNotificaciones_3" class="tabViajes">Venta</a></li>
                </ul>

                                        <div id="tabsNotificaciones_1">

                                            <h4>Asignar mercaderías</h4>

                                    <div class="divTables" id="divMercaderias" style="display: block;">
                                        <asp:UpdatePanel ID="upMercaderias" runat="server">
                                            <ContentTemplate>
                                                <uc1:Mercaderias runat="server" ID="Mercaderias" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>


                                        </div>



                                        <div id="tabsNotificaciones_2">




                                                <div style="z-index:10001;">
                                                    <h4 style="width: 80%; float: left;">Pesada origen</h4> 
                                                    <a id="aCopiarDestino" style="float:right; cursor:pointer;" onclick="copiarPesadas(1);">Copiar destino</a>
                                                </div>
                                                    <div class="modal-body" style="padding-bottom: 0; padding-top: 0; position:inherit;">
                                                    <table class="table table-bordered table-hover">
                                                        <tr>
                                                            <td>Lugar: 
                                                        <asp:TextBox ID="txb_pesada1Lugar" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                            <td>Fecha: 
                                                        <asp:TextBox ID="txb_pesada1Fecha" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Peso bruto: 
                                                        <asp:TextBox ID="txb_pesada1Peso_bruto" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                            <td>Peso neto: 
                                                        <asp:TextBox ID="txb_pesada1Peso_neto" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Nombre balanza: 
                                                        <asp:TextBox ID="txb_pesada1Nombre" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                            <td>Comentarios: 
                                                        <asp:TextBox ID="txb_pesada1Comentarios" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>

                                                 <div style="z-index:10001;">
                                                    <h4 style="width: 80%; float: left;">Pesada destino</h4> 
                                                    <a id="aCopiarOrigen" style="float:right; cursor:pointer;" onclick="copiarPesadas(2);">Copiar origen</a>
                                                </div>
                                                <div class="modal-body" style="padding-bottom: 0; padding-top: 0; position:inherit;">
                                                    <table class="table table-bordered table-hover">
                                                        <tr>
                                                            <td>Lugar: 
                                                      <asp:TextBox ID="txb_pesada2Lugar" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                            <td>Fecha: 
                                                        <asp:TextBox ID="txb_pesada2Fecha" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Peso bruto: 
                                                         <asp:TextBox ID="txb_pesada2Peso_bruto" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                            <td>Peso neto: 
                                                       <asp:TextBox ID="txb_pesada2Peso_neto" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Nombre balanza: 
                                                        <asp:TextBox ID="txb_pesada2Nombre" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                            <td>Comentarios: 
                                                       <asp:TextBox ID="txb_pesada2Comentarios" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <div class="col-md-2 pull-right" style="padding: 10px;">
                                                    <asp:LinkButton ID="lnk_pesada1Guardar" runat="server"
                                                        CssClass="btn btn-info" OnClick="lnk_pesadasGuardar_Click" OnClientClick="Javascript:DoPost_Pesadas();">Guardar</asp:LinkButton>
                                                </div>
                                                </div>

                                                










                                        </div>



                                        <div id="tabsNotificaciones_3">

                                            <h4>Precio de venta</h4>


                                            <div class="modal-body" style="padding: 0; position:inherit;">
                                                    <table class="table table-bordered table-hover" style="margin-bottom:0;">
                                                        <tr>
                                                            <td>Precio de compra: 
                                                                <h2><label id="notif_lblPrecioCompra" runat="server" class="label label-danger">0</label></h2>
                                                            </td>
                                                            <td>Precio de flete: 
                                                        <asp:TextBox ID="notif_txbPrecioFlete" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0"></asp:TextBox>
                                                        <asp:CompareValidator ID="vnotif_txbPrecioFlete" runat="server" ControlToValidate="notif_txbPrecioFlete" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                                            </td>
                                                            <td>Precio de descarga: 
                                                        <asp:TextBox ID="notif_txbPrecioDescarga" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0"></asp:TextBox>
                                                        <asp:CompareValidator ID="vnotif_txbPrecioDescarga" runat="server" ControlToValidate="notif_txbPrecioDescarga" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                                            </td>
                                                            <td>Ganancia por TON: 
                                                        <asp:TextBox ID="notif_txbGananciaXTon" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0"></asp:TextBox>
                                                        <asp:CompareValidator ID="vnotif_txbGananciaXTon" runat="server" ControlToValidate="notif_txbGananciaXTon" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                                            </td>
                                                            <td>% IVA: 
                                                        <asp:TextBox ID="notif_txbIVA" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0"></asp:TextBox>
                                                        <asp:CompareValidator ID="vnotif_txbIVA" runat="server" ControlToValidate="notif_txbIVA" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                                            </td>
                                                            <td> 
                                                                <a class="btn btn-info" onClick="calcularPrecioVenta();">Calcular</a>                                                        
                                                            </td>
                                                            <td>Precio de venta: 
                                                                <h2><label id="notif_lblPrecioVenta" class="label label-success">0</label></h2>
                                                            </td>

                                                        </tr>
                                                    </table>

                                                <hr style="margin-top: 5px; margin-bottom: 5px;" />
                                                <div class="row">
                                                    <div class="col-md-2 pull-right" style="padding: 10px;">
                                                        <a ID="lnkGuardarPrecioVenta" class="btn btn-info" OnClick="GuardarPrecioVenta()">Guardar</a>
                                                    </div>
                                                </div>

                                                </div>



                                        </div>



                                        </div>













                                    
                                </ContentTemplate>

                                <%--<Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lnkViajeDestino" />
                                </Triggers>--%>
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

                                        <asp:Label ID="gridViajes_lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        <asp:GridView ID="gridViajes" runat="server" ClientIDMode="Static" HorizontalAlign="Center" AutoGenerateColumns="False" ShowFooter="False" CssClass="table table-hover table-striped"
                                            DataKeyNames="Viaje_ID"
                                            OnRowCommand="gridViajes_RowCommand"
                                            OnRowCancelingEdit="gridViajes_RowCancelingEdit"
                                            OnRowEditing="gridViajes_RowEditing"
                                            OnRowUpdating="gridViajes_RowUpdating"
                                            OnRowDeleting="gridViajes_RowDeleting"
                                            OnRowDataBound="gridViajes_RowDataBound">

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
                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" 
                                                            CommandArgument='' CssClass="btn btn-info btn-xs"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                        
                                                        
                                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete"
                                                            OnClientClick='return confirm("Está seguro que desea borrar este registro?");' 
                                                            CommandArgument='' CssClass="btn btn-info btn-xs"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span></asp:LinkButton>

                                    <%--<a id="lnkElementDownload" class="btn btn-default" type="button" style="margin-right: 4px;" href="#" onclick="javascript: $('#dialog p').text(hashMessages['SeleccioneElemento']); $('#dialog').dialog({ buttons: {'Confirmar': function () { $(this).dialog('close'); }} });">


                                                    --%></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="lnkInsert" runat="server" Text="" CommandName="Update" 
                                                            CommandArgument='' CssClass="btn btn-info btn-xs"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" 
                                                            CommandArgument='' CssClass="btn btn-info btn-xs"><span aria-hidden="true" class="glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="newGrp" CommandName="InsertNew" 
                                                            CommandArgument='' CssClass="btn btn-info btn-xs"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="CancelNew" 
                                                            CommandArgument='' CssClass="btn btn-info btn-xs"><span aria-hidden="true" class="glyphicon glyphicon-ban-circle"></span></asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fecha partida">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txb11" runat="server" Text='<%# Bind("Fecha_partida", "{0:MMMM d, yyyy}") %>' CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl11" runat="server" Text='<%# Bind("Fecha_partida", "{0:MMMM d, yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txbNew11" runat="server" CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fecha llegada">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txb12" runat="server" Text='<%# Bind("Fecha_llegada", "{0:MMMM d, yyyy}") %>' CssClass="form-control datepicker" MaxLength="30"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl12" runat="server" Text='<%# Bind("Fecha_llegada", "{0:MMMM d, yyyy}") %>'></asp:Label>
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
                                                        <asp:CompareValidator ID="vtxb2" runat="server" ControlToValidate="txb2" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl2" runat="server" Text='<%# Bind("Precio_compra", "{0:C0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txbNew2" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                        <asp:CompareValidator ID="vtxbNew2" runat="server" ControlToValidate="txbNew2" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Precio venta">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txb3" runat="server" Text='<%# Bind("Precio_venta") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                        <asp:CompareValidator ID="vtxb3" runat="server" ControlToValidate="txb3" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Precio_venta", "{0:C0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txbNew3" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                        <asp:CompareValidator ID="vtxbNew3" runat="server" ControlToValidate="txbNew3" Display="Dynamic" SetFocusOnError="true" Text="" ErrorMessage="Se admiten sólo números" Operator="DataTypeCheck" Type="Integer" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Forma de pago">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlFormas1" runat="server" CssClass="form-control" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbl5" runat="server" CommandName="View" Text='<%# Bind("Forma_de_pago_ID") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlFormas2" runat="server" CssClass="form-control" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pesada origen">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlPesadaOrigen1" runat="server" CssClass="form-control" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl8" runat="server" Text='<%# Bind("Pesada_origen_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlPesadaOrigen2" runat="server" CssClass="form-control" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pesada destino">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlPesadaDestino1" runat="server" CssClass="form-control" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl9" runat="server" Text='<%# Bind("Pesada_destino_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlPesadaDestino2" runat="server" CssClass="form-control" />
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
                                                <asp:TemplateField HeaderText="Lugar de carga">
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
                                                <asp:TemplateField HeaderText="Lugar de descarga">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txb7" runat="server" Text='<%# Bind("Descarga") %>' CssClass="form-control" MaxLength="30"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl7" runat="server" Text='<%# Bind("Descarga") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txbNew7" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
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

                                            </Columns>

                                        </asp:GridView>
                                        <asp:Label ID="lblGridViajesCount" runat="server" ClientIDMode="Static" Text="Resultados: 0" CssClass="lblResultados"></asp:Label>

                                        <asp:HiddenField ClientIDMode="Static" ID="hdnViajesCount" runat="server" />

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

    <div id="dialog" title="Mensaje Bonisoft">
        <p style="text-align: left;"></p>
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
    <asp:HiddenField ID="hdn_modalMercaderia_txbNew6" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txbNew7" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_ddlVariedad2" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_ddlProcesador2" runat="server" ClientIDMode="Static" />

    <!-- Mercaderia Hdn Fields - Edit -->
    <asp:HiddenField ID="hdn_modalMercaderia_txb4" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txb5" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txb6" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txb7" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_ddlVariedad1" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_ddlProcesador1" runat="server" ClientIDMode="Static" />

</asp:Content>
