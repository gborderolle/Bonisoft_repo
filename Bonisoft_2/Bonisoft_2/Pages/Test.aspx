<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Bonisoft_2.Pages.Test" %>

<%@ Register Src="~/User_Controls/Dinamicos/Mercaderias.ascx" TagPrefix="uc1" TagName="Mercaderias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script>

        function guardarMercaderias() {

            // Hdn Fields - Pesada origen
            var mercaderias_txbNew4 = $("#mercaderias_txbNew4").val();
            var mercaderias_txbNew5 = $("#mercaderias_txbNew5").val();
            var mercaderias_txbNew7 = $("#mercaderias_txbNew7").val();
            var mercaderias_ddlVariedad2 = $("#mercaderias_ddlVariedad2").val();

            $("#hdn_modalMercaderia_txbNew4").val(mercaderias_txbNew4);
            $("#hdn_modalMercaderia_txbNew5").val(mercaderias_txbNew5);
            $("#hdn_modalMercaderia_txbNew7").val(mercaderias_txbNew7);
            $("#hdn_modalMercaderia_ddlVariedad2").val(mercaderias_ddlVariedad2);

        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="upMercaderias" runat="server">
        <ContentTemplate>
            <uc1:Mercaderias runat="server" ID="Mercaderias" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
