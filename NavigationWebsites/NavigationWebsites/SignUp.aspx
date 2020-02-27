<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Henrismartech Online Bootique</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/Custom.css" rel="stylesheet">
    

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Default.aspx"><span>
                            <img alt="Logo" src="Images/boutique-logo.jpg" height="30" /></span>Henrismartech.com</a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="Default.aspx">Home</a></li>
                            <li><a href="*">About</a></li>
                            <li><a href="*">Contact</a></li>
                            <li class="dropdown">
                                <a href="*" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li class="dropdown-header">Men</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="*">Shirts</a></li>
                                    <li><a href="*">Trousser</a></li>
                                    <li><a href="*">Boxers</a></li>
                                    <li><a href="*">Singlets</a></li>
                                    <li><a href="*">Shoes</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li class="dropdown-header">Women</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="*">Tops</a></li>
                                    <li><a href="*">Skirts</a></li>
                                    <li><a href="*">Weavons</a></li>
                                    <li><a href="*">Marry Kay</a></li>
                                    <li><a href="*">Under wears</a></li>
                                    <li><a href="*">Leggings</a></li>
                                    <li><a href="*">Shoes</a></li>
                                    <li><a href="*">e.t.c</a></li>
                                </ul>
                            </li>
                            <li><a href="SignUp.aspx">Sign Up</a></li>
                            <li><a href="SignIn.aspx">SignIn</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!----Sign up----->
        <div class="center-page">

            <label class="col-xs-11">Username</label>
            <div class="col-xs-11">
            <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
            </div>

            <label class="col-xs-11">Password</label>
            <div class="col-xs-11">
            <asp:TextBox ID="tbPassword" runat="server" Class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
            </div>
            <label class="col-xs-11">Confirm Password</label>
            <div class="col-xs-11">
            <asp:TextBox ID="tbConfirmPassword" runat="server" Class="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
            </div>
            <label class="col-xs-11">Name</label>
            <div class="col-xs-11">
            <asp:TextBox ID="tbName" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
            </div>
            <label class="col-xs-11">E-mail</label>
            <div class="col-xs-11">
            <asp:TextBox ID="tbEmail" runat="server" Class="form-control" placeholder="E-mail" TextMode="Email"></asp:TextBox>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="col-xs-11 space-vert">
            <asp:Button ID="btnsignUp" runat="server" Class="btn btn-success" Text="Sign up" OnClick="btnsignUp_Click" />
          </div>



        </div>

        <!-----sign up-------->
         <!----Footer----->
        <hr />
        <footer class="footer-pos">
            <div class="container">
                <p class="pull-right"><a href="*">Back to Top</a></p>
                <p>&copy; 2019 Henrismartech.com &middot; <a href="Default.aspx">Home</a> &middot;<a href="*">About</a> &middot; <a href="*">Contact</a> &middot; <a href="*">Products</a> &middot;</p>
            </div>
        </footer>
        <!----Footer------>


    </form>
     <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
