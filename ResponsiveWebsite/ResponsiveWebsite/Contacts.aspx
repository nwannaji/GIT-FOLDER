<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contacts.aspx.cs" Inherits="Contacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>e-Boutique</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/customCSS.css" rel="stylesheet"/>

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
             <div class ="navbar navbar-default navbar-fixed-top" style="background-color:darkgreen" role ="navigation">
                <div class ="container">
                    <div class="navber-header">
                       <button type ="button" class ="navbar-toggle"style="background-color:white" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle Navigation</span>
                           <span class="icon-bar"></span>
                           <span class="icon-bar"></span>
                           <span class="icon-bar"></span>
                       </button>
                        <a class="navbar-brand" href="Contacts.aspx"><span style="font-family:'Harlow Solid';color:red;font-weight:700;font-size:x-large"><img  src="Images/unisex.jpg" alt="logo" height="35"/>e-Boutique</span></a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class ="nav navbar-nav navbar-right">
                            <li><a href="Default.aspx" style="font-weight:700;color:red">Home</a></li>
                            <li><a href="about-us.aspx" style="font-weight:700; color:red">About Us</a></li>
                            <li><a href="Contacts.aspx" style="font-weight:700; color:red">Contact</a></li>
                            <li class="dropdown" style="font-weight:700">
                          <a href="#" style="color:red" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li style="background-color:black;color:white"class="dropdown-header">Gents</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="Gents.aspx" style="font-weight:700;color:deeppink">Shirts</a></li>
                                    <li><a href="Gents.aspx" style="font-weight:700;color:deeppink">Trousser</a></li>
                                    <li><a href="Gents.aspx" style="font-weight:700;color:deeppink">Senegalese outfit</a></li>
                                    <li><a href="Gents.aspx" style="font-weight:700;color:deeppink">Boxers</a></li>
                                    <li><a href="Gents.aspx" style="font-weight:700;color:deeppink">Senators</a></li>
                                    <li><a href="Gents.aspx" style="font-weight:700;color:deeppink">Singlets</a></li>
                                    <li><a href="Gents.aspx" style="font-weight:700;color:deeppink">Shoes</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li style="background-color:black;color:white" class="dropdown-header">Ladies</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="Ladies.aspx" style="font-weight:700;color:deeppink">Tops</a></li>
                                    <li><a href="Ladies.aspx" style="font-weight:700;color:deeppink">Skirts</a></li>
                                    <li><a href="Ladies.aspx" style="font-weight:700;color:deeppink">Weavons</a></li>
                                    <li><a href="Ladies.aspx" style="font-weight:700;color:deeppink">Traditional wears</a></li>
                                    <li><a href="Ladies.aspx" style="font-weight:700;color:deeppink">Marry Kay</a></li>
                                    <li><a href="Ladies.aspx" style="font-weight:700;color:deeppink">Under wears</a></li>
                                    <li><a href="Ladies.aspx" style="font-weight:700;color:deeppink">Leggings</a></li>
                                    <li><a href="Ladies.aspx" style="font-weight:700;color:deeppink">Shoes</a></li>
                                    <li><a href="*" style="font-weight:700;color:deeppink">e.t.c</a></li>
                                </ul>
                            </li>
                            <li style ="font-weight:700"><a style="color:red" href="Sign Up.aspx">Sign Up</a></li>
                         </ul>
                    </div>
                </div>
            </div>
             
        </div>
       
        <!----Footer--->
        <hr />
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
