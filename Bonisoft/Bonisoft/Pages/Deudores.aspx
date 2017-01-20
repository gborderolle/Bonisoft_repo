<%@ Page Title="Resumen de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deudores.aspx.cs" Inherits="Bonisoft.Pages.Deudores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="/assets/dist/css/jquery.modal.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->
    <script type="text/javascript" src="/assets/dist/js/jquery.quicksearch.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.modal.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.tablesorter.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">



    <div class="box box-default">
        <div class="box-header with-border" style="padding-bottom: 0;">

            <div class="row">
                <div class="col-md-9">
                    <h1 style="font-size: 24px;">Resumen de Clientes</h1>
                </div>
            </div>


            <div class="row">
                <div class="col-md-5">

                    <div style="text-align: center">

                        <asp:UpdatePanel ID="upClientes" runat="server">
                        <ContentTemplate>

                            <div class="row" style="margin-bottom: 10px;">
                                <div class="col-md-2 pull-left">
                                    <a href="#addModal" rel="modal:open" class="btn btn-success pull-left">Iniciar viaje</a>
                                </div>

                                <div class="col-md-3 pull-right">
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
                            <asp:GridView ID="gridClientes" runat="server" ClientIDMode="Static" HorizontalAlign="Center"
                                AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped"
                                DataKeyNames="Cliente_ID"
                                OnRowDataBound="gridClientes_RowDataBound"
                                OnRowCommand="gridClientes_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Fecha partida" DataFormatString="{0:d MMMM, yyyy}" HtmlEncode="false" />
                                    <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="lblGridClientesCount" runat="server" ClientIDMode="Static" Text="Resultados: 0" CssClass="lblResultados"></asp:Label>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    </div>                

                </div>

                <div class="col-md-7">

                    <div id="tabsClientes">
                    <ul>
                        <li><a href="#tabsClientes_1" class="tabsClientes">Viajes</a></li>
                        <li><a href="#tabsClientes_2" class="tabsClientes">Pagos</a></li>
                    </ul>

                    <!-- Tab Viajes En Curso BEGIN -->
                    <div id="tabsClientes_1">

                    </div>

                    <div id="tabsClientes_2">

                    </div>
                </div>

                </div>

            </div>

        </div>
    </div>


    <div id="dialog" title="Mensaje Bonisoft" style="height: 0 !important;">
        <p style="text-align: left;"></p>
    </div>




</asp:Content>
