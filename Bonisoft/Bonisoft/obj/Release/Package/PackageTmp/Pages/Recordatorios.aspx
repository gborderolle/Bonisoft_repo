<%@ Page Title="Recordatorios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recordatorios.aspx.cs" Inherits="Bonisoft.Pages.Recordatorios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link rel="stylesheet" href="/assets/dist/css/popbox.css">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <script type="text/javascript" src="/assets/dist/js/popbox.js"></script>

     <style type='text/css' media='screen'>
    body {
      text-align:center;
      background:#f7f7f7;
      font-family:georgia;
      font-size:22px;
      text-shadow:1px 1px 1px #FFF;
      margin:200px;
    }

    a { color:#999; text-decoration:none; }
    label { display: block; }
    form { margin: 25px; text-align:left }
    form input[type=text] { padding:5px; width:90%; border:solid 1px #CCC;}
    form textarea { padding:5px; width:90%; border:solid 1px #CCC; height:100px;}

    .msg-box { width:350px; }

     footer {
       font-size:12px;
     }
     form a, footer a { color:#40738d; }
  </style>
  <script type='text/javascript' charset='utf-8'>
    $(document).ready(function(){
      $('.popbox').popbox();
    });
  </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Menú de Recodatorios</h2>
    <h3>[ en construcción ]</h3>


    
                                  <div class='popbox'>
    <a class='msg-open' href='#'>
      <img src='images/plus.png' style='width:14px;position:relative;'> Click Here!
    </a>

    <div class='collapse' style="display:block;">
      <div class='msg-box'>
        <div class='arrow'></div>
        <div class='arrow-border'></div>

        <form action="http://gristmill.createsend.com/t/j/s/zlldr/" method="post" id="subForm">
          <p><small>Please complete the form to sign up for the <a href="http://gristmill.io" target="_blank">Gristmill</a> mailing list!</small></p>
          <div class="input">
            <input type="text" name="cm-name" id="name" placeholder="Name" />
          </div>
          <div class="input">
            <input type="text" name="cm-zlldr-zlldr" id="zlldr-zlldr" placeholder="Email" />
          </div>
          <input type="submit" value="Sign Up" /> <a href="#" class="close">Cancel</a>
        </form>

      </div>
    </div>
  </div>


</asp:Content>
