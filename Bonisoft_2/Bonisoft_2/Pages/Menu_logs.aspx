<%@ Page Title="Logs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu_logs.aspx.cs" Inherits="Bonisoft_2.Pages.Menu_logs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="/assets/dist/css/jquery.modal.css" />

    <!-- PAGE CSS -->
    <link rel="stylesheet" href="/assets/dist/css/pages/Logs.css" />
    <link rel="stylesheet" href="/assets/dist/css/pages/Modal_styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->
    <script type="text/javascript" src="/assets/dist/js/jquery.quicksearch.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.modal.js"></script>
    <script type="text/javascript" src="/assets/dist/js/jquery.tablesorter.js"></script>

    <!-- PAGE JS -->
    <script type="text/javascript" src="/assets/dist/js/AuxiliarFunctions.js"></script>
    <script type="text/javascript" src="/assets/dist/js/pages/Logs.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box box-default">
        <div class="box-header with-border" style="padding-bottom: 0;">

            <div class="row">
                <div class="col-md-9">
                    <h1 style="font-size: 24px;">Menú de Logs</h1>
                </div>
            </div>

            <div class="row panel panel-default" style="margin-top: 10px; padding-top: 10px;">

                <div class="row" style="padding: 20px; padding-top: 3px">
                    <div class="input-group pull-right">
                        <input type="text" id="txbFiltro1" class="form-control datepicker" placeholder="Desde" runat="server">
                        <span class="input-group-btn"></span>

                        <input type="text" id="txbFiltro2" class="form-control datepicker" placeholder="Hasta" runat="server">
                        <span class="input-group-btn"></span>

                        <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btn btnUpdate btn-sm"
                            OnClick="btnSearch_Click" UseSubmitBehavior="false" ClientIDMode="Static" CausesValidation="false" />
                    </div>
                </div>

                <asp:UpdatePanel ID="upgridLogs" runat="server">
                    <ContentTemplate>

                        <asp:Label ID="gridLogs_lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:GridView ID="gridLogs" runat="server" ClientIDMode="Static" HorizontalAlign="Center"
                            AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped"
                            DataKeyNames="Log_ID" PageSize="30"
                            OnPageIndexChanging="grid_PageIndexChanging">

                            <RowStyle Font-Size="Smaller" />

                            <Columns>
                                <asp:BoundField DataField="Log_ID" HeaderText="ID" HtmlEncode="false" ReadOnly="true" ItemStyle-CssClass="hiddencol_real" HeaderStyle-CssClass="hiddencol_real" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy HH:mm:ss}" HtmlEncode="false" ReadOnly="true" />
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" HtmlEncode="false" ReadOnly="true" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HtmlEncode="false" ReadOnly="true" />
                                <asp:BoundField DataField="Dato" HeaderText="ID Objeto" HtmlEncode="false" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

    <div id="dialog" title="Mensaje Bonisoft" style="height: 0 !important;">
        <p style="text-align: left;"></p>
    </div>

</asp:Content>
