<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sign Up.aspx.cs" Inherits="Sign_Up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>e-Boutique</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/customCSS.css" rel="stylesheet" />


    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>

<body style="background-color:cadetblue">
    <form id="form1" runat="server">
        <div>
            <div class="navbar navbar-default navbar-fixed-top" style="background-color:cornflowerblue"
                role="navigation">
                <div class="container">
                    <div class="navber-header">
                        <button type="button" class="navbar-toggle" style="background-color:white"
                            data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle Navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Default.aspx"><span
                                style="font-family:'Harlow Solid';font-weight:700;font-size:xx-large;color:black"><img
                                    src="Images/fashion.jpg" alt="logo" height="35" />e-Boutique</span></a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="Default.aspx" style="font-weight:700;color:black">Home</a></li>
                            <li><a href="about-us.aspx" style="font-weight:700;color:black">About Us</a></li>
                            <li class="active" style="font-weight:700"><a style="font-weight:700;color:black"
                                href="Sign Up.aspx">Sign Up</a></li> 
                            <li style="font-weight:700"><a style="font-weight:700;color:black"
                                href="Sign In.aspx">Sign In</a></li>
                        </ul>
                    </div>
                </div>

            </div>
        </div>
        <!----Sign up--->
        <div class="center-page">
            <label class="col-xs-11">Username</label>
            <div class="col-xs-11">
                <asp:TextBox ID="tbUsername" runat="server" Class="form-control" placeHolder="Username"></asp:TextBox>
            </div>
            <label class="col-xs-11">Password</label>
            <div class="col-xs-11">
                <asp:TextBox ID="tbpassword" runat="server" Class="form-control" placeHolder="Password"
                    TextMode="Password"></asp:TextBox>
            </div>
            <label class="col-xs-11">Confirm Password</label>
            <div class="col-xs-11">
                <asp:TextBox ID="tbcPassword" runat="server" Class="form-control" placeHolder="Confirm Password"
                    TextMode="Password"></asp:TextBox>
            </div>
            <label class="col-xs-11">Name</label>
            <div class="col-xs-11">
                <asp:TextBox ID="tbName" runat="server" Class="form-control" placeHolder="Name"></asp:TextBox>
            </div>
            <label class="col-xs-11">E-Mail</label>
            <div class="col-xs-11">
                <asp:TextBox ID="tb_eMail" runat="server" Class="form-control" placeHolder="E-Mail" TextMode="Email">
                </asp:TextBox>
            </div>
        

            <div class="col-xs-11 space-vert">
                <asp:Button ID="btnSignUp" runat="server" Class=" btn btn-default btn-info" Text="Sign-Up"
                    OnClick="btnSignUp_Click" />
                <asp:CheckBox ID="CheckBoxAdmin" runat="server" />
                <asp:Label runat="server" ForeColor="Red" Font-Bold ="true" Text="Super User"></asp:Label>
                <br />
                <asp:Label ID="Label" runat="server"></asp:Label>
            </div>




        </div>
        <!---Sign up --->

        <!----Footer--->

        <footer class="footer-pos" style="background-color:white">
            <div class="container">
                <p class="pull-right"><a href="#">Back to Top</a></p>
                <p>&copy;2020 e-Boutique &middot; <a href="Default.aspx">Home</a> &middot; <a href="#">About</a>
                    &middot; <a href="#">Contact</a> &middot <a href="#">Products</a></p>
            </div>
        </footer>
        <!---footer---->

    </form>
    <!---JavaScriptFiles--->
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <!---Ende of JavaScript files--->
</body>

</html>