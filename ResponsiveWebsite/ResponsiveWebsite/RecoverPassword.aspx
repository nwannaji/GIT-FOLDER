<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Reset Password</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/customCSS.css" rel="stylesheet" />

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
            <!--Navbar Start-->
            <div class="navbar navbar-default navbar-fixed-top" style="background-color: cornflowerblue" role="navigation">
                <div class="container">
                    <div class="navber-header">
                        <button type="button" class="navbar-toggle" style="background-color: white" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle Navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Default.aspx"><span style="font-family: 'Harlow Solid'; color: black; font-weight: 700; font-size: xx-large">
                         <img src="Images/unisex.jpg" alt="logo" height="35" />e-Boutique</span></a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="Default.aspx" style="font-weight: 700; color: black">Home</a></li>
                            <li><a href="about-us.aspx" style="font-weight: 700; color: black;">About Us</a></li>
                            <li class="dropdown" style="font-weight: 700">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" style="color: black">Products<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li style="background-color: black; color: white" class="dropdown-header">Gents</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a style="font-weight: 700; color: black" href="Gents.aspx">Shirts</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Gents.aspx">Trousser</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Gents.aspx">Senegalese outfit</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Gents.aspx">Boxers</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Gents.aspx">Senators</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Gents.aspx">Singlets</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Gents.aspx">Shoes</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li style="background-color: black; color: white" class="dropdown-header">Ladies</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a style="font-weight: 700; color: black" href="Ladies.aspx">Tops</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Ladies.aspx">Skirts</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Ladies.aspx">Weavons</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Ladies.aspx">Traditional wears</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Ladies.aspx">Marry Kay</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Ladies.aspx">Under wears</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Ladies.aspx">Leggings</a></li>
                                    <li><a style="font-weight: 700; color: black" href="Ladies.aspx">Shoes</a></li>
                                    <li><a style="font-weight: 700; color: black" href="*">e.t.c</a></li>
                                </ul>
                            </li>
                            <li><a style="font-weight: 700; color: black" href="Sign In.aspx">Sign In</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--Navbar Ends-->
            <br />
             <br />
        </div>
        <div class ="container" style ="background-color:cadetblue">
            <div class ="form-horizontal">
                <br />
                  <h2>Reset Password</h2>
                    <hr />
                <div class="form-group">
                    <asp:Label ID="lblMsg" CssClass="col-md-2 control-label" Font-Size="XX-Large" runat="server" Font-Bold="True"></asp:Label>
                    </div>
                <div class="form-group">
                    <asp:Label ID="lblResetpassword" CssClass="col-md-2 control-label" runat="server" Text="Enter new password" Visible="False"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="tbResetPassword" CssClass="form-control" runat="server" TextMode="Password" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorResetPassword" CssClass="text-danger" runat="server" ErrorMessage="Please enter a new password." ControlToValidate="tbResetPassword"></asp:RequiredFieldValidator>
                     </div>
                   </div>

                <div class="form-group">
                    <asp:Label ID="lblConfirmPassword" CssClass="col-md-2 control-label" runat="server" Text="Confirm  Password" Visible="False"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="tbConfirmPassword" CssClass="form-control" runat="server" TextMode="Password" Visible="False"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidatorPass" runat="server"  CssClass="text-danger" ErrorMessage="Both Password must be same!" ControlToCompare="tbConfirmPassword" ControlToValidate="tbResetPassword"></asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnRecPass" class="btn btn-default btn-info" runat="server" Text="Reset" Visible="False" OnClick="btnRecPass_Click"/>
                        <asp:Label ID="lblResetMsg" runat="server" Font-Bold="true"></asp:Label>
                    </div>
                </div>
             </div>
              </div>
             </form>
  <!----Footer--->
        <br />
        <footer>
        <div class ="container">
            <p class ="pull-right"><a href ="#">Back to Top</a></p>
            <p>&copy;2020 e-Boutique &middot; <a href ="Default.aspx">Home</a> &middot; <a href ="#">About</a> &middot; <a href ="#">Contact</a> &middot <a href ="#">Products</a></p>
        </div>
        </footer>
        <!---footer---->
    <!---JavaScriptFiles--->
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <!---Ende of JavaScript files--->
</body>
</html>
