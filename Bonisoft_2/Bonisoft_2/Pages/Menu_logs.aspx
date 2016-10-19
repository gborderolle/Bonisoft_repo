<%@ Page Title="Logs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu_logs.aspx.cs" Inherits="Bonisoft_2.Pages.Menu_logs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="/assets/dist/css/jquery.modal.css">

    <!-- PAGE CSS -->
    <link rel="stylesheet" href="/assets/dist/css/pages/Logs.css">
    <link rel="stylesheet" href="/assets/dist/css/pages/Modal_styles.css">
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

                <asp:Label ID="gridLogs_lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                <asp:GridView ID="gridLogs" runat="server" ClientIDMode="Static" HorizontalAlign="Center"
                    AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped"
                    DataKeyNames="Log_ID">

                    <%-- Paginador --%>
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
                        <asp:BoundField DataField="Log_ID" HeaderText="ID" HtmlEncode="false" ReadOnly="true" ItemStyle-CssClass="hiddencol_real" HeaderStyle-CssClass="hiddencol_real" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy 00:00:00}" HtmlEncode="false" ReadOnly="true" />
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" HtmlEncode="false" ReadOnly="true" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HtmlEncode="false" ReadOnly="true" />
                        <asp:BoundField DataField="Dato" HeaderText="ID Objeto" HtmlEncode="false" ReadOnly="true" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>

    <div id="dialog" title="Mensaje Bonisoft" style="height: 0 !important;">
        <p style="text-align: left;"></p>
    </div>

</asp:Content>
