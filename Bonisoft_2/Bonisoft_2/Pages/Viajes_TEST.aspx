<%@ Page Title="Viajes_TEST" Language="C#" AutoEventWireup="true" CodeBehind="Viajes_TEST.aspx.cs" Inherits="Bonisoft_2.Pages.Viajes_TEST" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD in GridView using Bootstrap Modal Popup</title>
    <link href="../assets/bootstrap.css" rel="stylesheet" />
    <script src="../assets/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="../assets/bootstrap/js/bootstrap.js"></script>

</head>
<body>

    <form id="form1" runat="server">
            <asp:ScriptManager runat="server" ID="ScriptManager1" />


    <div class="box box-default">
        <div class="box-header with-border" style="padding-bottom: 0;">

            <div class="row">
                <div class="col-md-9">
                    <h2>Menú de Viajes</h2>
                </div>
            </div>
            <div class="row">

                <div class="col-md-9">
                    <div class="row">
                        <h3>Viajes en Curso</h3>
                    </div>
                </div>
            </div>
            <div class="row">

                    <!--  -->

                                <br>

                    <div style="text-align: center">
                        <!-- Placing GridView in UpdatePanel-->
                        <asp:UpdatePanel ID="upCrudGrid" runat="server">
                            <ContentTemplate>
                                    <div class="row" style="margin-bottom: 10px;">
                                        <div class="col-md-2 pull-left" >
                                            <asp:Button ID="btnAdd" runat="server" Text="Iniciar viaje" CssClass="btn btn-info pull-left" OnClick="btnAdd_Click" />
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
                                 <asp:GridView ID="gridViajesEnCurso" runat="server" ClientIDMode="Static" HorizontalAlign="Center"
                                    OnRowCommand="gridViajesEnCurso_RowCommand" AutoGenerateColumns="false" AllowPaging="true"
                                    DataKeyNames="Viaje_ID" CssClass="table table-hover table-striped"
                                    OnRowDataBound="gridViajesEnCurso_RowDataBound">
                                    <Columns>

                                        <asp:BoundField DataField="Fecha_partida" HeaderText="Fecha partida" DataFormatString="{0:MMMM d, yyyy}" HtmlEncode="false" />
                                        <asp:BoundField DataField="Precio_valor_total" HeaderText="Precio valor total" DataFormatString="{0:C0}" HtmlEncode="False" />
                                        <asp:BoundField DataField="Importe_viaje" HeaderText="Importe viaje" DataFormatString="{0:C0}" HtmlEncode="False" />
                                        <asp:BoundField DataField="Saldo" HeaderText="Saldo" DataFormatString="{0:C0}" HtmlEncode="False" />
                                        <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />

                                        <asp:ButtonField CommandName="detail" ControlStyle-CssClass="btn btn-info"
                                            ButtonType="Link" Text="" HeaderText="Notificar">
                                            <ControlStyle CssClass="btn btn-info btn-xs fa fa-bullhorn"></ControlStyle>
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="detail" ControlStyle-CssClass="btn btn-info"
                                            ButtonType="Link" Text="" HeaderText="Inspeccionar">
                                            <ControlStyle CssClass="btn btn-info btn-xs glyphicon glyphicon-search"></ControlStyle>
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="editRecord" ControlStyle-CssClass="btn btn-info"
                                            ButtonType="Link" Text="" HeaderText="Modificar">
                                            <ControlStyle CssClass="btn btn-info btn-xs glyphicon glyphicon-pencil"></ControlStyle>
                                        </asp:ButtonField>
                                        <asp:ButtonField CommandName="deleteRecord" ControlStyle-CssClass="btn btn-info"
                                            ButtonType="Link" Text="" HeaderText="Borrar">
                                            <ControlStyle CssClass="btn btn-info btn-xs glyphicon glyphicon-remove"></ControlStyle>
                                        </asp:ButtonField>
                                        <%--<asp:TemplateField HeaderText="Acciones" ControlStyle-CssClass="btn btn-info btn-xs">
                                            <ItemTemplate>
                                                <%--<asp:LinkButton ID="btnInspeccionar" runat="server" CommandName="detail" Text="" ToolTip="Inspeccionar"><span aria-hidden="true" class="glyphicon glyphicon-search"></asp:LinkButton>--%>
                                                <%--<asp:LinkButton ID="btnModificar" runat="server" CommandName="editRecord" Text="" ToolTip="Modificar"><span aria-hidden="true" class="glyphicon glyphicon-pencil"></asp:LinkButton>--%>
                                                <%--<asp:LinkButton ID="btnBorrar" runat="server" CommandName="deleteRecord" Text="" ToolTip="Borrar"><span aria-hidden="true" class="glyphicon glyphicon-remove"></asp:LinkButton>--%>
                                            <%--</ItemTemplate>--%>
                                        <%--</asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                        <!-- Detail Modal Starts here-->
                        <div id="detailModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h3 id="myModalLabel">Detailed View</h3>
                            </div>
                            <div class="modal-body">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DetailsView ID="DetailsView1" runat="server" CssClass="table table-bordered table-hover" BackColor="White" ForeColor="Black" FieldHeaderStyle-Wrap="false" FieldHeaderStyle-Font-Bold="true" FieldHeaderStyle-BackColor="LavenderBlush" FieldHeaderStyle-ForeColor="Black" BorderStyle="Groove" AutoGenerateRows="False">
                                            <Fields>
                                                <asp:BoundField DataField="Viaje_ID" HeaderText="Viaje_ID" />
                                                <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
                                            </Fields>
                                        </asp:DetailsView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="gridViajesEnCurso" EventName="RowCommand" />
                                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <div class="modal-footer">
                                    <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                                </div>
                            </div>
                        </div>
                        <!-- Detail Modal Ends here -->
                        <!-- Edit Modal Starts here -->
                        <div id="editModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h3 id="editModalLabel">Edit Record</h3>
                            </div>
                            <asp:UpdatePanel ID="upEdit" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <table class="table">
                                            <tr>
                                                <td>Viaje_ID : 
                           
                                                    <asp:Label ID="lblCountryCode" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Comentarios : 
                           
                                                    <asp:TextBox ID="txtPopulation" runat="server"></asp:TextBox>
                                                    <asp:Label runat="server" Text="Type Integer Value!" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                                        <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="btn btn-info" OnClick="btnSave_Click_2" />
                                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gridViajesEnCurso" EventName="RowCommand" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <!-- Edit Modal Ends here -->
                        <!-- Add Record Modal Starts here-->
                        <div id="addModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h3 id="addModalLabel">Add New Record</h3>
                            </div>
                            <asp:UpdatePanel ID="upAdd" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <table class="table table-bordered table-hover">
                                            <tr>
                                                <td>Viaje_ID : 
                               
                                                    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Comentarios : 
                               
                                                    <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnAddRecord" runat="server" Text="Add" CssClass="btn btn-info" OnClick="btnAddRecord_Click" />
                                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAddRecord" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <!--Add Record Modal Ends here-->
                        <!-- Delete Record Modal Starts here-->
                        <div id="deleteModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="delModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h3 id="delModalLabel">Delete Record</h3>
                            </div>
                            <asp:UpdatePanel ID="upDel" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        Are you sure you want to delete the record?
                           
                                        <asp:HiddenField ID="hfCode" runat="server" />
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-info" OnClick="btnDelete_Click" />
                                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <!--Delete Record Modal Ends here -->
                    </div>

            </div>

                    <!--  -->




            <div class="row">


                <div class="col-md-9">
                    <div class="row">
                        <h3>Histórico de Viajes</h3>
                    </div>
                </div>
            </div>

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


                </div>

            </div>

        </div>
    </div>

</form>
</body>
</html>
<%--</asp:Content>--%>
