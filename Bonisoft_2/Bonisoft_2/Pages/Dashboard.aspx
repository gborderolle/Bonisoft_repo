<%@ Page Title="Base de datos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Bonisoft_2.Pages.Dashboard" %>
<%@ Register Src="~/User_Controls/Clientes.ascx" TagPrefix="uc1" TagName="Clientes" %>
<%@ Register Src="~/User_Controls/Proveedores.ascx" TagPrefix="uc1" TagName="Proveedores" %>
<%@ Register Src="~/User_Controls/Cuadrillas.ascx" TagPrefix="uc1" TagName="Cuadrillas" %>
<%@ Register Src="~/User_Controls/Camiones.ascx" TagPrefix="uc1" TagName="Camiones" %>
<%@ Register Src="~/User_Controls/Choferes2.ascx" TagPrefix="uc1" TagName="Choferes2" %>
<%@ Register Src="~/User_Controls/Internos.ascx" TagPrefix="uc1" TagName="Internos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- STYLES EXTENSION -->

<!-- Theme style -->
<link rel="stylesheet" href="/Bonisoft_2/assets/dist/css/Datos.min.css">
<link rel="stylesheet" href="/Bonisoft_2/assets/dist/css/Datos_2.css">

<!-- AdminLTE Skins. Choose a skin from the css/skins
     folder instead of downloading all of them to reduce the load. -->
<link rel="stylesheet" href="/Bonisoft_2/assets/dist/css/skins/_all-skins.min.css">
<!-- iCheck -->
<link rel="stylesheet" href="/Bonisoft_2/assets/plugins/iCheck/flat/blue.css">
<!-- Morris chart -->
<link rel="stylesheet" href="/Bonisoft_2/assets/plugins/morris/morris.css">
<!-- jvectormap -->
<link rel="stylesheet" href="/Bonisoft_2/assets/plugins/jvectormap/jquery-jvectormap-1.2.2.css">
<!-- Date Picker -->
<link rel="stylesheet" href="/Bonisoft_2/assets/plugins/datepicker/datepicker3.css">
<!-- Daterange picker -->
<link rel="stylesheet" href="/Bonisoft_2/assets/plugins/daterangepicker/daterangepicker.css">
<!-- bootstrap wysihtml5 - text editor -->
<link rel="stylesheet" href="/Bonisoft_2/assets/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">


<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
<script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
<![endif]-->

    
  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper1">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Base de Datos
        <small>Tablas</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <li class="active">Base de Datos</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">

      <div class="row">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red"><i class="fa fa-users"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Clientes</span>
              <span class="info-box-number">1,410</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-light-blue"><i class="fa fa-suitcase"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Proveedores</span>
              <span class="info-box-number">410</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon"><i class="fa fa-thumbs-o-up"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Cuadrillas</span>
              <span class="info-box-number">13,648</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-purple"><i class="fa fa-truck"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Camiones</span>
              <span class="info-box-number">93,139</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->

          <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="fa fa-cog"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Choferes</span>
              <span class="info-box-number">93,139</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>

          <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-green"><i class="fa fa-black-tie"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Internos</span>
              <span class="info-box-number">93,139</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>

        </div>


      <!-- =========================================================== -->


                <div class="box box-default">
                    <div class="box-header with-border" style="padding-bottom:0;">

                        <div class="row">
                            <div class="col-md-9">
                                <h3 class="box-title"><label id="lblTableActive" style="font-weight: normal;"></label></h3>
                            </div>

                            <div class="col-md-2 pull-right" style="margin-right: 10px;">
                                <form action="#" method="get" class="sidebar-form" style="display: block !important; width: 100%;">
                                    <div class="input-group ">
                                        <input type="text" id="txbSearchTable" name="q" class="form-control" placeholder="Buscar...">
                                        <span class="input-group-btn">
                                            <button type="submit" name="search" id="search-btn" class="btn btn-flat">
                                                <i class="fa fa-search"></i>
                                            </button>
                                        </span>
                                    </div>
                                </form>
                            </div>
                        </div>


                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div id="divContent">

                                    <div class="divTables" id="divClientes" style="display:block;">
                                         <uc1:Clientes runat="server" ID="Clientes" />
                                    </div>
                                        <div class="divTables" id="divProveedores" style="display:none;">
                                         <uc1:Proveedores runat="server" ID="Proveedores" />
                                    </div>
                                        <div class="divTables" id="divCuadrillas" style="display:none;">
                                         <uc1:Cuadrillas runat="server" ID="Cuadrillas" />
                                    </div>
                                        <div class="divTables" id="divCamiones" style="display:none;">
                                         <uc1:Camiones runat="server" ID="Camiones" />
                                    </div>
                                    <div class="divTables" id="divChoferes" style="display:none;">
                                         <uc1:Choferes2 runat="server" id="Choferes2" />
                                    </div>
                                    <div class="divTables"  id="divInternos" style="display:none;">
                                         <uc1:Internos runat="server" ID="Internos" />
                                    </div>

                                    </div>
                                </div>

                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->
                </div>



      <!-- =========================================================== -->
    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->



    
    <!-- SCRIPTS -->
    <!-- Morris.js charts -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="/Bonisoft_2/assets/plugins/morris/morris.min.js"></script>
    <!-- Sparkline -->
    <script src="/Bonisoft_2/assets/plugins/sparkline/jquery.sparkline.min.js"></script>
    <!-- jvectormap -->
    <script src="/Bonisoft_2/assets/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="/Bonisoft_2/assets/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <!-- jQuery Knob Chart -->
    <script src="/Bonisoft_2/assets/plugins/knob/jquery.knob.js"></script>
    <!-- daterangepicker -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
    <script src="/Bonisoft_2/assets/plugins/daterangepicker/daterangepicker.js"></script>
    <!-- datepicker -->
    <script src="/Bonisoft_2/assets/plugins/datepicker/bootstrap-datepicker.js"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="/Bonisoft_2/assets/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
    <!-- Slimscroll -->
    <script src="/Bonisoft_2/assets/plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="/Bonisoft_2/assets/plugins/fastclick/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="/Bonisoft_2/assets/dist/js/app.min.js"></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="/Bonisoft_2/assets/dist/js/pages/Dashboard.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="/Bonisoft_2/assets/dist/js/demo.js"></script>


    <!-- Datos JS -->
    <script src="/Bonisoft_2/assets/dist/js/pages/Datos.js"></script>


</asp:Content>
