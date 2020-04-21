<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sign In.aspx.cs" Inherits="Sign_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Sign In</title>

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
            <div class ="navbar navbar-default navbar-fixed-top" style="background-color:cornflowerblue" role ="navigation">
                <div class ="container">
                    <div class="navber-header">
                       <button type ="button" class ="navbar-toggle"style="background-color:white" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle Navigation</span>
                           <span class="icon-bar"></span>
                           <span class="icon-bar"></span>
                           <span class="icon-bar"></span>
                       </button>
                        <a class="navbar-brand" href="Default.aspx"><span style="font-family:'Harlow Solid';color:black;font-weight:700;font-size:xx-large"><img  src="Images/fashion.jpg" alt="logo" height="35"/>e-Boutique</span></a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class ="nav navbar-nav navbar-right">
                            <li><a href="Default.aspx" style="font-weight:700;color:black">Home</a></li>
                            <li><a href="about-us.aspx" style="font-weight:700;color:black;">About Us</a></li>
                            <li><a href="Contacts.aspx" style="font-weight:700;color:black;">Contact</a></li>
                            <li class="dropdown" style="font-weight:700">
                          <a href="#" class="dropdown-toggle" data-toggle="dropdown" style="color:black">Products<b class="caret"></b></a>
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
                            <li class ="active"><a style="font-weight:700;color:black" href="Sign In.aspx">Sign In</a></li>
                         </ul>
                    </div>
                </div>
            </div>
        <!----Sign In Start here---->
              <br />
              <br />
            
              <div class=" container" style ="background-color:cadetblue">
                  <div class="form-horizontal">
                      <h2>Login</h2>
                      <hr />
                      <div class="form-group">
                          <asp:Label ID="Label1" runat="server" CssClass=" col-md-2 control-label" Text="UserName:"></asp:Label>
                          <div class=" col-md-3">
                              <asp:TextBox ID="Username" CssClass="form-control" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="The field Username is required !" ControlToValidate="Username"></asp:RequiredFieldValidator>
                          </div>
                      </div>
                      <div class="form-group">
                          <asp:Label ID="Label2" runat="server" CssClass=" col-md-2 control-label" Text="Password:"></asp:Label>
                          <div class=" col-md-3">
                              <asp:TextBox ID="password" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" CssClass="text-danger" runat="server" ErrorMessage="The field Password is required !" ControlToValidate="Password"></asp:RequiredFieldValidator>

                          </div>
                      </div>
                      <div class="form-group">
                          <div class=" col-md-2"></div>
                          <div class=" col-md-6">
                              <asp:Label ID="Label3" runat="server" Text="Remember me ?"></asp:Label>
                              <asp:CheckBox ID="CheckBox1" runat="server" />
                          </div>
                      </div>
                      <div class="form-group">
                          <div class="col-md-2"></div>
                          <div class="col-md-6">
                              <asp:Label ID="Label4" runat="server" CssClass=" col-md-2 control-label"></asp:Label>
                              <asp:Button ID="btnLogIn" runat="server" CssClass="btn btn-info" Text="LogIn" Font-Bold="True" Font-Size="Medium" OnClick="btnLogIn_Click" />
                              <asp:LinkButton ID="LinkButton1" runat="server" Style="color: black" PostBackUrl="~/Sign Up.aspx">SignUp</asp:LinkButton>
                          </div>
                      </div>
                      <div class="form-group">
                          <div class="col-md-2"></div>
                          <div class="col-md-6">
                              <asp:LinkButton ID="lbForgotPassword" runat="server" ForeColor="Red" CausesValidation="False" PostBackUrl="~/ForgotPassword.aspx">Forgot password</asp:LinkButton>
                          </div>
                      </div>

                      <div class="form-group">
                          <div class="col-md-2"></div>
                          <div class="col-md-6">
                              <asp:Label ID="lblErrorMsg" runat="server" class="text-danger"></asp:Label>
                          </div>

                      </div>
                  </div>
              </div>
                
        <!----Sign In Ends here--->
          </div>
        <!----Footer--->
        <br />
        <footer class ="footer-pos">
        <div class ="container">
            <p class ="pull-right"><a href ="#">Back to Top</a></p>
            <p>&copy;2020 e-Boutique &middot; <a href ="Default.aspx">Home</a> &middot; <a href ="#">About</a> &middot; <a href ="#">Contact</a> &middot <a href ="#">Products</a></p>
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
