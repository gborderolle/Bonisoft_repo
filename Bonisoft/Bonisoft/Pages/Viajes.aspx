<%@ Page Title="Viajes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Viajes.aspx.cs" Inherits="Bonisoft.Pages.Viajes" EnableEventValidation="false" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="/assets/dist/css/jquery.modal.css" />
    <link rel="stylesheet" href="/assets/dist/css/popbox.css" />
    <link rel="stylesheet" href="/assets/dist/css/chosen.css" />

    <!-- PAGE CSS -->
    <link rel="stylesheet" href="/assets/dist/css/pages/Viajes.css" />
    <link rel="stylesheet" href="/assets/dist/css/pages/Modal_styles.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->
    <script type="text/javascript" src="/assets/dist/js/jquery.quicksearch.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.modal.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.tablesorter.js"></script>
    <script type="text/javascript" src="/assets/dist/js/popbox.js"></script>
    <script type="text/javascript" src="/assets/dist/js/chosen.jquery.js"></script>

    <!-- PAGE JS -->
    <script type="text/javascript" src="/assets/dist/js/AuxiliarFunctions.js"></script>
    <script type="text/javascript" src="/assets/dist/js/pages/Viajes.js"></script>

    <script type="text/javascript">

        function addToday(tipo) {
            var date = moment(new Date()).format("DD-MM-YYYY");
            //var date = $.datepicker.formatDate('dd/mm/yy', new Date());
            switch (tipo) {
                case 1: {
                    $("#modalAdd_txbFecha1").val(date);
                    break;
                }
                case 2: {
                    $("#modalAdd_txbFecha2").val(date);
                    break;
                }
                case 3: {
                    $("#txb_pesada1Fecha").val(date);
                    break;
                }
                case 4: {
                    $("#txb_pesada2Fecha").val(date);
                    break;
                }
            }
        }

        function newOpcionDDL(tipo) {
            var valor = prompt("Ingrese el valor a agregar", "");
            if (valor !== null && valor !== "") {

                // Ajax call parameters
                console.log("Ajax call: Viajes.aspx/AgregarOpcionDDL. Params:");
                console.log("tipo, type: " + type(tipo) + ", value: " + tipo);
                console.log("cliente, type: " + type(valor) + ", value: " + valor);

                // Check existen mercaderías
                $.ajax({
                    type: "POST",
                    url: "Viajes.aspx/AgregarOpcionDDL",
                    data: '{tipo: "' + tipo + '",valor: "' + valor + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var resultado = response.d;

                        if (resultado !== null && resultado !== "0") {
                            // Add option
                            var newOption = "<option value='" + resultado + "'>" + valor + " </option>";
                            switch (tipo) {
                                case "proveedor": {
                                    $("#modalAdd_ddlProveedores").append(newOption);
                                    $("#modalEdit_ddlProveedores").append(newOption);
                                    break;
                                }
                                case "cliente": {
                                    $("#modalAdd_ddlClientes").append(newOption);
                                    $("#modalEdit_ddlClientes").append(newOption);
                                    break;
                                }
                                case "cargador": {
                                    $("#modalAdd_ddlCargadores").append(newOption);
                                    $("#modalEdit_ddlCargadores").append(newOption);
                                    break;
                                }
                                case "fletero": {
                                    $("#modalAdd_ddlFleteros").append(newOption);
                                    $("#modalEdit_ddlFleteros").append(newOption);
                                    break;
                                }
                                case "camion": {
                                    $("#modalAdd_ddlCamiones").append(newOption);
                                    $("#modalEdit_ddlCamiones").append(newOption);
                                    break;
                                }
                                case "chofer": {
                                    $("#modalAdd_ddlChoferes").append(newOption);
                                    $("#modalEdit_ddlChoferes").append(newOption);
                                    break;
                                }
                                case "tipo_lena": {
                                    $("#ddlTipoLena").append(newOption);
                                    break;
                                }
                            }
                            $(".chzn-select").trigger("liszt:updated");

                        }

                    }, // end success
                    failure: function (response) {
                    }
                }); // Ajax
            }
        }

    </script>

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
                    <li><a href="#tabsViajes_1" id="aTabsViajes_1" class="tabViajes">Viajes en Curso</a></li>
                    <li><a href="#tabsViajes_2" id="aTabsViajes_2" class="tabViajes">Histórico de Viajes</a></li>
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
                                        <a href="#addModal" rel="modal:open" class="btn btn-success pull-left">Nuevo viaje</a>
                                    </div>

                                    <div class="col-md-5 pull-right">

                                        <div style="float: left; margin-right: 5px;">
                                            <asp:Button ID="btnUpdateViajesEnCurso" runat="server" Text="Actualizar" CssClass="btn btnUpdate btn-sm"
                                                OnClick="btnUpdateViajesEnCurso_Click" UseSubmitBehavior="false" ClientIDMode="Static" CausesValidation="false" />
                                        </div>

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

                                <div style="overflow: auto;">
                                    <asp:GridView ID="gridViajesEnCurso" runat="server" ClientIDMode="Static" HorizontalAlign="Center"
                                        AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped" PageSize="30"
                                        DataKeyNames="Viaje_ID"
                                        OnRowDataBound="gridViajesEnCurso_RowDataBound"
                                        OnRowCommand="gridViajesEnCurso_RowCommand"
                                        OnPageIndexChanging="grid2_PageIndexChanging">

                                        <Columns>
                                            <asp:BoundField DataField="Viaje_ID" HeaderText="ID" HtmlEncode="false" ReadOnly="true" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                            <asp:BoundField DataField="remito" HeaderText="Remito" HtmlEncode="false" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="Fecha partida">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaPartida" runat="server" CommandName="View" Text='<%# Eval("Fecha_partida", "{0:dd-MM-yyyy}") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Proveedor">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblProveedor" runat="server" CommandName="View" Text='<%# Eval("Proveedor_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Carga" HeaderText="Lugar de carga" HtmlEncode="False" />
                                            <asp:BoundField DataField="Pesada_Origen_peso_neto" HeaderText="Kilos neto origen" HtmlEncode="False" />

                                            <asp:TemplateField HeaderText="Fletero">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblFletero" runat="server" CommandName="View" Text='<%# Eval("Fletero_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Chofer">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblChofer" runat="server" CommandName="View" Text='<%# Eval("Chofer_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Cliente">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblCliente" runat="server" CommandName="View" Text='<%# Eval("Cliente_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Pesada_Destino_peso_neto" HeaderText="Kilos neto destino" HtmlEncode="False" />

                                            <asp:BoundField DataField="Precio_compra" HeaderText="Precio compra" DataFormatString="{0:C2}" HtmlEncode="False" />
                                            <asp:BoundField DataField="precio_flete_total" HeaderText="Precio flete total" DataFormatString="{0:C2}" HtmlEncode="False" />
                                            <asp:BoundField DataField="IVA" HeaderText="IVA" HtmlEncode="False" />
                                            <asp:BoundField DataField="Precio_descarga" HeaderText="Descarga" ReadOnly="true" DataFormatString="{0:C2}" HtmlEncode="False" />
                                            <asp:BoundField DataField="Precio_venta" HeaderText="Total viaje" DataFormatString="{0:C2}" HtmlEncode="False" />

                                            <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />

                                            <asp:ButtonField CommandName="notificar" ControlStyle-CssClass="btn btn-info btn-xs" ButtonType="Link" Text="" HeaderText="Detalles">
                                                <ControlStyle CssClass="btn btn-warning btn-xs glyphicon glyphicon-wrench"></ControlStyle>
                                            </asp:ButtonField>

                                            <asp:TemplateField HeaderText="Acciones" ControlStyle-CssClass="btn btn-info btn-xs">
                                                <ItemTemplate>
                                                    <a id="btnModificar" role="button" onclick='<%# "ModificarViaje_1(" +Eval("Viaje_ID") + ");" %>' class="btn btn-info btn-xs glyphicon glyphicon-pencil"></a>
                                                    <a id="btnBorrar" role="button" onclick='<%# "BorrarViajeEnCurso(" +Eval("Viaje_ID") + ");" %>' class="btn btn-danger btn-xs glyphicon glyphicon-remove"></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                                <asp:Label ID="lblGridViajesEnCursoCount" runat="server" ClientIDMode="Static" Text="# 0" CssClass="lblResultados label label-info"></asp:Label>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnUpdateViajesEnCurso" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <!-- Modal Iniciar viaje BEGIN -->
                        <div id="addModal" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true"
                            style="display: none; max-width: 800px; overflow: hidden;" class="modal fade dark in">

                            <div class="modal-header">
                                <h3 id="addModalLabel">Nuevo viaje</h3>
                            </div>
                            <asp:UpdatePanel ID="upAdd" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnSubmit_upAdd" runat="server" OnClick="btnSubmit_upAdd_Click" Style="display: none" />
                                    <div class="modal-body">
                                        <table class="table">
                                            <tr>
                                                <td>Fecha de inicio: 
                                                <asp:TextBox ID="modalAdd_txbFecha1" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control datepicker with_border" MaxLength="30" TabIndex="1"></asp:TextBox>
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="addToday(1)">
                                                        <i class="fa fa-calendar-check-o" title="Hoy"></i>
                                                    </button>
                                                </td>
                                                <td>Fecha de llegada (tentativa): 
                                                <asp:TextBox ID="modalAdd_txbFecha2" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control datepicker" MaxLength="30" TabIndex="2"></asp:TextBox>
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="addToday(2)">
                                                        <i class="fa fa-calendar-check-o" title="Hoy"></i>
                                                    </button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Proveedor: 
                                                    <asp:DropDownList ID="modalAdd_ddlProveedores" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="3" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('proveedor')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
                                                </td>
                                                <td>Cliente: 
                                                <asp:DropDownList ID="modalAdd_ddlClientes" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control with_border pull-left chzn-select" TabIndex="4" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('cliente')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Cargadores: 
                                                <asp:DropDownList ID="modalAdd_ddlCargadores" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="5" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('cargador')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
                                                </td>
                                                <td>Lugar de carga: 
                                                <asp:TextBox ID="modalAdd_txbLugarCarga" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="6" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Fletero: 
                                                <asp:DropDownList ID="modalAdd_ddlFleteros" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="7" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('fletero')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
                                                </td>
                                                <td>Camión: 
                                                <asp:DropDownList ID="modalAdd_ddlCamiones" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="8" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('camion')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Chofer: 
                                                <asp:DropDownList ID="modalAdd_ddlChoferes" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="9" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('chofer')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
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
                                        <%--<button class="btn pull-left" data-dismiss="modal" aria-hidden="true" onclick="__doPostBack('<%=upAdd.UniqueID %>', '');">Actualizar listados</button>--%>
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
                                        <table class="table">
                                            <tr>
                                                <td>Fecha de inicio: 
                                                <asp:TextBox ID="modalEdit_txbFecha1" DataFormatString="{dd-mm-yyyy}" runat="server" ClientIDMode="Static" CssClass="form-control datepicker with_border" MaxLength="30" TabIndex="11"></asp:TextBox>
                                                </td>
                                                <td>Fecha de llegada (tentativa): 
                                                <asp:TextBox ID="modalEdit_txbFecha2" DataFormatString="{dd-mm-yyyy}" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30" TabIndex="12"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Proveedor: 
                                                <asp:DropDownList ID="modalEdit_ddlProveedores" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="13" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('proveedor')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>

                                                </td>
                                                <td>Cliente: 
                                                <asp:DropDownList ID="modalEdit_ddlClientes" runat="server" ClientIDMode="Static" CssClass="form-control with_border chzn-select" TabIndex="14" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('cliente')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Cargadores: 
                                                <asp:DropDownList ID="modalEdit_ddlCargadores" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="15" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('cargador')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
                                                </td>
                                                <td>Lugar de carga: 
                                                <asp:TextBox ID="modalEdit_txbLugarCarga" runat="server" ClientIDMode="Static" CssClass="form-control" TabIndex="16" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Fletero: 
                                                <asp:DropDownList ID="modalEdit_ddlFleteros" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="17" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('fletero')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
                                                </td>
                                                <td>Camión: 
                                                <asp:DropDownList ID="modalEdit_ddlCamiones" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="18" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('camion')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Chofer: 
                                                <asp:DropDownList ID="modalEdit_ddlChoferes" runat="server" ClientIDMode="Static" CssClass="modal-ddl form-control chzn-select" TabIndex="19" />
                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('chofer')">
                                                        <i class="fa fa-plus"></i>
                                                    </button>
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
                        <div id="notificacionesModal" tabindex="-1" role="dialog" aria-labelledby="notificacionesModalLabel" aria-hidden="true" style="display: none; max-width: 1000px; overflow: hidden; margin-top: 40px; overflow: auto;" class="modal fade dark in">
                            <asp:UpdatePanel ID="upNotificaciones" runat="server">
                                <ContentTemplate>

                                    <div class="modal-header">
                                        <div class="row">
                                            <div class="col-md-10 pull-left">
                                                <h3 id="notificacionesModalLabel">Notificaciones</h3>
                                                <%--<p style="color: orange; margin: 0;">IMPORTANTE: #1- Expresar todas las unidades de peso en TONELADAS. #2- Usar "puntos", no "comas".</p>--%>
                                            </div>

                                            <div class="col-md-2 pull-right" style="padding-top: 10px;">
                                                <a id="lnkViajeDestino" class="btn btn-warning" onclick="FinDelViaje();">FIN del Viaje</a>
                                            </div>
                                        </div>

                                    </div>

                                    <div id="tabsNotificaciones">

                                        <div id="tabsNotificaciones_2">

                                            <h4 style="padding-left: 30px;">Mercadería</h4>

                                            <div class="modal-body panel panel-default" style="padding-bottom: 0; padding-top: 0; margin-bottom: 5px; position: inherit; background: #e9e9e9; color: #333333; position: initial;">
                                                <table class="table">
                                                    <tr>
                                                        <td>Precio compra por tonelada: 
                                                        <asp:TextBox ID="txbMercaderiaPrecioCompra" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" TabIndex="21"></asp:TextBox>
                                                        </td>
                                                        <td>Tipo de leña: 
                                                                <asp:DropDownList ID="ddlTipoLena" ClientIDMode="Static" runat="server" CssClass="modal-ddl form-control chzn-select" TabIndex="22" />
                                                            <button type="button" name="search" id="mercaderia-plus-btn" class="btn btn-xs btn-default pull-right" onclick="newOpcionDDL('tipo_lena')">
                                                                <i class="fa fa-plus"></i>
                                                            </button>
                                                        </td>
                                                    </tr>
                                                </table>

                                                <div class="col-md-10 pull-left" style="padding: 10px;">
                                                    Comentarios de la mercadería:
                                                           <asp:TextBox ID="txbMercaderiaComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="100" TabIndex="23"></asp:TextBox>
                                                </div>

                                            </div>
                                            <div class="modal-body panel panel-default row" style="padding-bottom: 0; padding-top: 0; position: inherit; background: #e9e9e9; color: #333333; margin: 0;">
                                            </div>

                                            <hr />

                                            <h4 style="padding-left: 30px;">Pesadas</h4>
                                            <div class="row">
                                                <div class="col-md-6">

                                                    <h4 class="pull-left" style="padding-left: 5px; width: 60%">Origen</h4>
                                                    <a id="aOrigenCopiar" style="margin: 5px; color: black;" onclick="copiarPesadas(1);" class="btn btn-xs btn-default pull-right">Copiar de destino</a>
                                                    <div class="modal-body panel panel-default" style="padding-bottom: 0; padding-top: 0; margin-bottom: 5px; position: inherit; background: #e9e9e9; color: #333333; position: initial;">
                                                        <table class="table">
                                                            <tr>
                                                                <td>Lugar: 
                                                        <asp:TextBox ID="txb_pesada1Lugar" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" TabIndex="24"></asp:TextBox>
                                                                </td>
                                                                <td>Fecha: 
                                                        <asp:TextBox ID="txb_pesada1Fecha" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="30" DataFormatString="{dd-mm-yyyy}" TabIndex="25"></asp:TextBox>
                                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="addToday(3)">
                                                                        <i class="fa fa-calendar-check-o" title="Hoy"></i>
                                                                    </button>
                                                                </td>
                                                            </tr>
                                                            <tr>

                                                                <td>Peso bruto: 
                                                         <asp:TextBox ID="txb_pesada1Peso_bruto" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" TabIndex="26" onkeydown="return isNumberKey(this);"></asp:TextBox>
                                                                </td>
                                                                <td>Peso neto: 
                                                       <asp:TextBox ID="txb_pesada1Peso_neto" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" TabIndex="27" onkeydown="return isNumberKey(this);"></asp:TextBox>
                                                                </td>

                                                            </tr>
                                                        </table>
                                                    </div>

                                                </div>

                                                <div class="col-md-6">

                                                    <h4 class="pull-left" style="width: 60%">Destino</h4>
                                                    <a id="aDestinoCopiar" style="margin: 5px; color: black;" onclick="copiarPesadas(2);" class="btn btn-xs btn-default pull-right">Copiar de origen</a>
                                                    <div class="modal-body panel panel-default" style="padding-bottom: 0; padding-top: 0; margin-bottom: 5px; position: inherit; background: #e9e9e9; color: #333333; position: initial;">
                                                        <table class="table">
                                                            <tr>
                                                                <td>Lugar: 
                                                      <asp:TextBox ID="txb_pesada2Lugar" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" TabIndex="28"></asp:TextBox>
                                                                </td>
                                                                <td>Fecha: 
                                                        <asp:TextBox ID="txb_pesada2Fecha" runat="server" ClientIDMode="Static" CssClass="form-control datepicker" MaxLength="29" DataFormatString="{0:d-MM-yyyy}" TabIndex="27"></asp:TextBox>
                                                                    <button type="button" name="search" class="btn btn-xs btn-default pull-right" onclick="addToday(4)">
                                                                        <i class="fa fa-calendar-check-o" title="Hoy"></i>
                                                                    </button>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Peso bruto: 
                                                         <asp:TextBox ID="txb_pesada2Peso_bruto" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" TabIndex="30" onkeydown="return isNumberKey(this);"></asp:TextBox>
                                                                </td>
                                                                <td>Peso neto: 
                                                       <asp:TextBox ID="txb_pesada2Peso_neto" runat="server" ClientIDMode="Static" CssClass="form-control with_border" MaxLength="30" TabIndex="31" onkeydown="return isNumberKey(this);"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </div>

                                                </div>

                                                <div class="modal-body panel panel-default row" style="padding-bottom: 0; padding-top: 0; position: inherit; background: #e9e9e9; color: #333333; margin: 0;">
                                                    <div class="col-md-10 pull-left" style="padding: 10px;">
                                                        Comentarios de las pesadas:
                                                           <asp:TextBox ID="txb_pesadaComentarios" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                    </div>

                                                    <%--  <div class="col-md-2 pull-right" style="padding: 2% 0;">
                                                    <a id="aGuardarPesadas" style="float: right;" onclick="guardarAmbasPesadas();" class="btn btn-primary">Guardar</a>
                                                </div>--%>
                                                </div>

                                            </div>

                                            <hr />
                                            <h4 class="pull-left" style="padding-left: 30px; width: 85%">Cálculo de Venta</h4>

                                            <a class="btn btn-success pull-right" style="margin: 6px; margin-right: 20px;" onclick="calcularPrecioVenta();">Calcular</a>

                                            <div class="modal-body panel panel-default" style="padding: 0; position: inherit; background: #e9e9e9; color: #333333;">
                                                <table class="table" style="margin-bottom: 0;">

                                                    <%-- 1) Cálculo Precio Mercadería ****************************************** --%>
                                                    <tr class="tr_border">
                                                        <td>
                                                            <h4>1) Cálculo Precio Mercadería</h4>
                                                        </td>
                                                        <td>Peso neto: 
                                                            <h3 style="margin: 0;">
                                                                <label runat="server" clientidmode="Static" id="notif_Mercaderia1" class="notif_lblPesoNeto label label-default">0</label></h3>
                                                        </td>
                                                        <td><i class="glyphicon glyphicon-asterisk"></i>Precio Mercadería: 
                                                            <h3 style="margin: 0;">
                                                                <label id="notif_Mercaderia2" class="label label-default">0</label></h3>
                                                        </td>
                                                        <td></td>
                                                        <td><i class="glyphicon glyphicon-chevron-right"></i></td>
                                                        <td>
                                                            <h3>
                                                                <label id="notif_Mercaderia3" class="label label-warning">0</label></h3>
                                                        </td>
                                                    </tr>

                                                    <%-- 2) Cálculo Precio Flete ****************************************** --%>
                                                    <tr class="tr_border">
                                                        <td>
                                                            <h4>2) Cálculo Precio Flete</h4>
                                                        </td>
                                                        <td>Peso neto: 
                                                            <h3 style="margin: 0;">
                                                                <label runat="server" clientidmode="Static" id="notif_Flete1" class="notif_lblPesoNeto label label-default">0</label></h3>
                                                        </td>
                                                        <td><i class="glyphicon glyphicon-asterisk"></i>Precio Flete x Ton: 
                                                             <asp:TextBox ID="notif_Flete2" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0" TabIndex="32" Width="100"></asp:TextBox>
                                                        </td>
                                                        <td><i class="glyphicon glyphicon-plus"></i>% IVA (0 = no aplica): 
                                                                <asp:TextBox ID="notif_Flete3" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0" TabIndex="33" Width="100"></asp:TextBox>
                                                        </td>
                                                        <td><i class="glyphicon glyphicon-chevron-right"></i>
                                                        </td>
                                                        <td>
                                                            <h3>
                                                                <label id="notif_Flete4" class="label label-warning">0</label></h3>
                                                        </td>
                                                    </tr>

                                                    <%-- 13) Cálculo Precio de Venta ****************************************** --%>
                                                    <tr class="tr_border">
                                                        <td>
                                                            <h4>3) Cálculo Precio de Venta</h4>
                                                        </td>
                                                        <td>Mercadería <i class="glyphicon glyphicon-plus"></i>Flete: 
                                                            <h3 style="margin: 0;">
                                                                <label id="notif_Venta1" class="label label-default">0</label></h3>
                                                        </td>
                                                        <td><i class="glyphicon glyphicon-plus"></i>Precio de descarga: 
                                                        <asp:TextBox ID="notif_Venta2" runat="server" ClientIDMode="Static" CssClass="form-control" MaxLength="30" Text="0" TabIndex="34" Width="100"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td><i class="glyphicon glyphicon-chevron-right"></i>
                                                        </td>
                                                        <td>
                                                            <h3>
                                                                <label id="notif_Venta3" class="label label-success">0</label>
                                                            </h3>
                                                        </td>

                                                    </tr>
                                                </table>

                                                <hr style="margin-top: 5px; margin-bottom: 5px;" />

                                                <div class="col-md-3 pull-right" style="padding: 10px;">
                                                    <button class="btn" data-dismiss="modal" aria-hidden="true" onclick="Javascript:$.modal.close();" style="color: #353434;">Cancelar</button>
                                                    <a id="lnkGuardarPrecioVenta" class="btn btn-primary" style="margin-left: 30px;" onclick="GuardarPrecioVenta()">Guardar</a>
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


                                <div class="col-md-5 pull-right" style="margin-right: 10px; margin-bottom: 10px;">

                                    <div style="float: left; margin-right: 5px;">
                                        <asp:Button ID="btnUpdateViajes" runat="server" Text="Actualizar" CssClass="btn btnUpdate btn-sm"
                                            OnClick="btnUpdateViajes_Click" UseSubmitBehavior="false" ClientIDMode="Static" CausesValidation="false" />
                                    </div>

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
                                                <div style="overflow: auto;">
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
                                                            <asp:BoundField DataField="remito" HeaderText="Remito" HtmlEncode="false" ReadOnly="true" />
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

                                                            <asp:BoundField DataField="Precio_compra" HeaderText="Precio compra mercadería" ReadOnly="true" DataFormatString="{0:C2}" HtmlEncode="False" />
                                                            <asp:BoundField DataField="precio_flete_total" HeaderText="Flete" ReadOnly="true" DataFormatString="{0:C2}" HtmlEncode="False" />
                                                            <asp:BoundField DataField="Precio_descarga" HeaderText="Descarga" ReadOnly="true" DataFormatString="{0:C2}" HtmlEncode="False" />
                                                            <asp:BoundField DataField="Precio_venta" HeaderText="Total viaje" ReadOnly="true" DataFormatString="{0:C2}" HtmlEncode="False" />

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
                                                            <asp:TemplateField HeaderText="Volver a En Curso">
                                                                <HeaderStyle Width="100" />
                                                                <ItemTemplate>
                                                                    <a id="btnVolverAEnCurso" role="button" onclick='<%# "volverAEnCurso(" +Eval("Viaje_ID") + ");" %>' class="btn btn-warning btn-xs fa fa-plane"></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>

                                                    </asp:GridView>
                                                </div>
                                                <asp:Label ID="lblGridViajesCount" runat="server" ClientIDMode="Static" Text="# 0" CssClass="lblResultados label label-info"></asp:Label>

                                                <hr style="margin-top: 5px; margin-bottom: 5px;" />
                                                <div class="row" style="margin: 0;">
                                                    <div class="col-md-9 pull-left" style="padding: 10px;">
                                                        <p class="text-info" style="text-align: left;">Importante: El filtro de fechas toma en cuenta únicamente la Fecha de partida de los viajes. </p>
                                                    </div>
                                                </div>

                                                <asp:HiddenField ClientIDMode="Static" ID="hdnViajesCount" runat="server" />

                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                                                <asp:AsyncPostBackTrigger ControlID="btnUpdateViajes" />
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
    <%--<asp:HiddenField ID="hdn_modalMercaderia_txbNew4" runat="server" ClientIDMode="Static" />--%>
    <asp:HiddenField ID="hdn_modalMercaderia_txbNew5" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txbNew7" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_ddlProcesador2" runat="server" ClientIDMode="Static" />

    <!-- Mercaderia Hdn Fields - Edit -->
    <asp:HiddenField ID="hdn_modalMercaderia_txb4" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txb5" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_txb7" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_modalMercaderia_ddlProcesador1" runat="server" ClientIDMode="Static" />

    <script type="text/javascript">
        setTimeout(loadInputDDL, 1000);
    </script>

</asp:Content>
