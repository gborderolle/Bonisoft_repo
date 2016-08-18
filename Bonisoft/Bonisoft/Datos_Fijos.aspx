﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Datos_Fijos.aspx.cs" Inherits="Bonisoft.Datos_Fijos" %>

<!-- STYLES EXTENSION -->

<!-- Theme style -->
<link rel="stylesheet" href="assets/dist/css/Datos.min.css">
<link rel="stylesheet" href="assets/dist/css/Datos_2.css">

<!-- AdminLTE Skins. Choose a skin from the css/skins
     folder instead of downloading all of them to reduce the load. -->
<link rel="stylesheet" href="assets/dist/css/skins/_all-skins.min.css">
<!-- iCheck -->
<link rel="stylesheet" href="assets/plugins/iCheck/flat/blue.css">
<!-- Morris chart -->
<link rel="stylesheet" href="assets/plugins/morris/morris.css">
<!-- jvectormap -->
<link rel="stylesheet" href="assets/plugins/jvectormap/jquery-jvectormap-1.2.2.css">
<!-- Date Picker -->
<link rel="stylesheet" href="assets/plugins/datepicker/datepicker3.css">
<!-- Daterange picker -->
<link rel="stylesheet" href="assets/plugins/daterangepicker/daterangepicker.css">
<!-- bootstrap wysihtml5 - text editor -->
<link rel="stylesheet" href="assets/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">


<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
<script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
<![endif]-->



<body class="hold-transition skin-blue sidebar-mini" style="padding-top: 40px; padding-bottom: 0;">
    <div class="wrapper" style="min-height: 600px;">

        <header class="main-header">
            <!-- Header Navbar: style can be found in header.less -->
            <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button" onclick="sidebar_action();">
                <span class="sr-only">Toggle navigation</span>
            </a>

        </header>
        <!-- Left side column. contains the logo and sidebar -->
        <aside class="main-sidebar">
            <!-- sidebar: style can be found in sidebar.less -->
            <section class="sidebar">
                <!-- search form -->
                <form action="#" method="get" class="sidebar-form">
                    <div class="input-group">
                        <input type="text" name="q" class="form-control" placeholder="Buscar...">
                        <span class="input-group-btn">
                            <button type="submit" name="search" id="search-btn" class="btn btn-flat">
                                <i class="fa fa-search"></i>
                            </button>
                        </span>
                    </div>
                </form>
                <!-- /.search form -->
                <!-- sidebar menu: : style can be found in sidebar.less -->
                <ul class="sidebar-menu">
                    <li class="header">Secciones</li>
                    <li class="treeview">
                        <a href=""><i class="fa fa-tachometer"></i> <span>Datos Dinámicos</span></a>
                    </li>
                    <li class="active treeview">
                        <a href=""><i class="fa fa-pie-chart"></i> <span>Datos Fijos</span></a>
                    </li>
                    <li class="treeview">
                        <a href=""><i class="fa fa-calendar"></i> <span>Recordatorios</span></a>
                    </li>

                    <li class="treeview">
                        <a href=""><i class="fa fa-calculator"></i> <span>Contabilidad</span></a>
                    </li>

                    <li class="treeview">
                        <a href=""><i class="fa fa-book"></i> <span>Registros de log</span></a>
                    </li>

                    <li class="treeview">
                        <a href=""><i class="fa fa-cogs"></i> <span>Ajustes</span></a>
                    </li>
                </ul>
            </section>

            <!-- /.sidebar -->
        </aside>

        <!-- Content Wrapper. Contains page content -->
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>
                    Menú de Datos
                    <small>Control panel</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                    <li class="active">Datos</li>
                </ol>
            </section>

            <!-- Main content -->
            <section class="content">



                <!-- COMIENZA ********************* -->

                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Tablas</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body" style="padding-top: 0; padding-bottom: 0;">
                        <div class="row" style="padding: 10px;">


                            <!-- Info boxes 1 -->
                            <div class="row">
                                <div class="col-md-2 col-sm-6 col-xs-12" style="padding-right:0;">
                                        <text>
                                            <div id="box-1" onclick="setTabActive(this.id)" class="info-box tables box-active">
                                                <span class="info-box-icon bg-light-blue"><i class="fa fa-suitcase"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Proveedores</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>
                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-2 col-sm-6 col-xs-12" style="padding-right:0;">
                                        <text>
                                            <div id="box-2" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon bg-red"><i class="fa fa-users"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Clientes</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>
                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->

                                <!-- fix for small devices only -->
                                <div class="clearfix visible-sm-block"></div>

                                <div class="col-md-2 col-sm-6 col-xs-12" style="padding-right:0;">
                                        <text>
                                            <div id="box-3" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon bg-black"><i class="fa fa-road"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Viajes</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>

                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-2 col-sm-6 col-xs-12" style="padding-right:0;">
                                        <text>
                                            <div id="box-4" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon bg-yellow"><i class="fa fa-cog"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Choferes</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>
                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-2 col-sm-6 col-xs-12" style="padding-right:0;">
                                        <text>
                                            <div id="box-5" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon"><i class="fa fa-thumbs-o-up"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Cuadrillas</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>

                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-2 col-sm-6 col-xs-12">
                                        <text>
                                            <div id="box-6" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon bg-green"><i class="fa fa-black-tie"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Internos</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>

                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->

                            <hr />

                            <!-- Info boxes 2 -->
                            <div class="row">
                                <div class="col-md-2 col-sm-6 col-xs-12" style="padding-right:0;">
                                        <text>
                                            <div id="box-7" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon bg-olive"><i class="fa fa-balance-scale"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Pesadas</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>

                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-2 col-sm-6 col-xs-12" style="padding-right:0;">
                                        <text>
                                            <div id="box-8" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon bg-purple"><i class="fa fa-truck"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Camiones</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>

                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                                <!-- fix for small devices only -->
                                <div class="clearfix visible-sm-block"></div>

                                <div class="col-md-2 col-sm-6 col-xs-12" style="padding-right:0;">
                                        <text>
                                            <div id="box-9" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon bg-teal"><i class="fa fa-user"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Personas</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>

                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-2 col-sm-6 col-xs-12" style="padding-right:0;">
                                        <text>
                                            <div id="box-10" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon bg-lime"><i class="fa fa-phone"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Medios de contacto</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>

                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-2 col-sm-6 col-xs-12" style="padding-right:0;">
                                        <text>
                                            <div id="box-11" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon bg-aqua"><i class="fa fa-briefcase"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Empresas</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>

                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                                <div class="col-md-2 col-sm-6 col-xs-12">
                                        <text>
                                            <div id="box-12" onclick="setTabActive(this.id)" class="info-box tables">
                                                <span class="info-box-icon bg-navy"><i class="fa fa-money"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text">Bancos</span>
                                                    <span class="info-box-number"></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>
                                        </text>

                                    <!-- /.info-box -->
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->
                            <!-- /.col -->
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer" style="padding-top: 0; padding-bottom: 0;">
                        Se encontraron <label id="lblResultados" style="font-weight:normal;">0</label> registros.
                    </div>
                </div>

                <div class="box box-default">
                    <div class="box-header with-border" style="padding-bottom:0;">

                        <div class="row">
                            <div class="col-md-9">
                                <h3 class="box-title"><label id="lblTableActive" style="font-weight: normal;">Proveedores</label></h3>
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

                <!-- TERMINA ********************* -->




            </section>

            <!-- /.content -->
        </div>


        <!-- Control Sidebar -->
        <aside class="control-sidebar control-sidebar-dark">
            <!-- Create the tabs -->
            <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
                <li><a href="#control-sidebar-home-tab" data-toggle="tab"><i class="fa fa-home"></i></a></li>
                <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i class="fa fa-gears"></i></a></li>
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
                <!-- Home tab content -->
                <div class="tab-pane" id="control-sidebar-home-tab">
                    <h3 class="control-sidebar-heading">Recent Activity</h3>
                    <ul class="control-sidebar-menu">
                        <li>
                            <a href="javascript:void(0)">
                                <i class="menu-icon fa fa-birthday-cake bg-red"></i>

                                <div class="menu-info">
                                    <h4 class="control-sidebar-subheading">Langdon's Birthday</h4>

                                    <p>Will be 23 on April 24th</p>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="javascript:void(0)">
                                <i class="menu-icon fa fa-user bg-yellow"></i>

                                <div class="menu-info">
                                    <h4 class="control-sidebar-subheading">Frodo Updated His Profile</h4>

                                    <p>New phone +1(800)555-1234</p>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="javascript:void(0)">
                                <i class="menu-icon fa fa-envelope-o bg-light-blue"></i>

                                <div class="menu-info">
                                    <h4 class="control-sidebar-subheading">Nora Joined Mailing List</h4>

                                    <p>nora@example.com</p>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="javascript:void(0)">
                                <i class="menu-icon fa fa-file-code-o bg-green"></i>

                                <div class="menu-info">
                                    <h4 class="control-sidebar-subheading">Cron Job 254 Executed</h4>

                                    <p>Execution time 5 seconds</p>
                                </div>
                            </a>
                        </li>
                    </ul>
                    <!-- /.control-sidebar-menu -->

                    <h3 class="control-sidebar-heading">Tasks Progress</h3>
                    <ul class="control-sidebar-menu">
                        <li>
                            <a href="javascript:void(0)">
                                <h4 class="control-sidebar-subheading">
                                    Custom Template Design
                                    <span class="label label-danger pull-right">70%</span>
                                </h4>

                                <div class="progress progress-xxs">
                                    <div class="progress-bar progress-bar-danger" style="width: 70%"></div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="javascript:void(0)">
                                <h4 class="control-sidebar-subheading">
                                    Update Resume
                                    <span class="label label-success pull-right">95%</span>
                                </h4>

                                <div class="progress progress-xxs">
                                    <div class="progress-bar progress-bar-success" style="width: 95%"></div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="javascript:void(0)">
                                <h4 class="control-sidebar-subheading">
                                    Laravel Integration
                                    <span class="label label-warning pull-right">50%</span>
                                </h4>

                                <div class="progress progress-xxs">
                                    <div class="progress-bar progress-bar-warning" style="width: 50%"></div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="javascript:void(0)">
                                <h4 class="control-sidebar-subheading">
                                    Back End Framework
                                    <span class="label label-primary pull-right">68%</span>
                                </h4>

                                <div class="progress progress-xxs">
                                    <div class="progress-bar progress-bar-primary" style="width: 68%"></div>
                                </div>
                            </a>
                        </li>
                    </ul>
                    <!-- /.control-sidebar-menu -->

                </div>
                <!-- /.tab-pane -->
                <!-- Stats tab content -->
                <div class="tab-pane" id="control-sidebar-stats-tab">Stats Tab Content</div>
                <!-- /.tab-pane -->
                <!-- Settings tab content -->
                <div class="tab-pane" id="control-sidebar-settings-tab">
                    <form method="post">
                        <h3 class="control-sidebar-heading">General Settings</h3>

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Report panel usage
                                <input type="checkbox" class="pull-right" checked>
                            </label>

                            <p>
                                Some information about this general settings option
                            </p>
                        </div>
                        <!-- /.form-group -->

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Allow mail redirect
                                <input type="checkbox" class="pull-right" checked>
                            </label>

                            <p>
                                Other sets of options are available
                            </p>
                        </div>
                        <!-- /.form-group -->

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Expose author name in posts
                                <input type="checkbox" class="pull-right" checked>
                            </label>

                            <p>
                                Allow the user to show his name in blog posts
                            </p>
                        </div>
                        <!-- /.form-group -->

                        <h3 class="control-sidebar-heading">Chat Settings</h3>

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Show me as online
                                <input type="checkbox" class="pull-right" checked>
                            </label>
                        </div>
                        <!-- /.form-group -->

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Turn off notifications
                                <input type="checkbox" class="pull-right">
                            </label>
                        </div>
                        <!-- /.form-group -->

                        <div class="form-group">
                            <label class="control-sidebar-subheading">
                                Delete chat history
                                <a href="javascript:void(0)" class="text-red pull-right"><i class="fa fa-trash-o"></i></a>
                            </label>
                        </div>
                        <!-- /.form-group -->
                    </form>
                </div>
                <!-- /.tab-pane -->
            </div>
        </aside>
        <!-- /.control-sidebar -->
        <!-- Add the sidebar's background. This div must be placed
             immediately after the control sidebar -->
        <div class="control-sidebar-bg"></div>
    </div>
    <!-- ./wrapper -->

    <script>
        $.widget.bridge('uibutton', $.ui.button);
    </script>

    <!-- SCRIPTS -->
    <script src="assets/js/jquery-1.12.0.js"></script>
    <script src="assets/js/bootstrap.js"></script>

    <!-- Morris.js charts -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="assets/plugins/morris/morris.min.js"></script>
    <!-- Sparkline -->
    <script src="assets/plugins/sparkline/jquery.sparkline.min.js"></script>
    <!-- jvectormap -->
    <script src="assets/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="assets/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <!-- jQuery Knob Chart -->
    <script src="assets/plugins/knob/jquery.knob.js"></script>
    <!-- daterangepicker -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
    <script src="assets/plugins/daterangepicker/daterangepicker.js"></script>
    <!-- datepicker -->
    <script src="assets/plugins/datepicker/bootstrap-datepicker.js"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="assets/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
    <!-- Slimscroll -->
    <script src="assets/plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="assets/plugins/fastclick/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="assets/dist/js/app.min.js"></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="assets/dist/js/pages/Dashboard.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="assets/dist/js/demo.js"></script>


    <!-- Datos JS -->
    <script src="assets/dist/js/pages/Datos.js"></script>

</body>
