
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
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
            <div class="navbar navbar-default navbar-fixed-top" style="background-color:blue" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Default.aspx"><span><img alt="Logo" src="Images/boutique-logo.jpg"height="30" /></span>Henrismartech.com</a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li class="active"><a href="Default.aspx">Home</a></li>
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
                        </ul>
                    </div>
                </div>
            </div>
            <!----Carousel------->
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img src="Images/men_shirt.jpg" alt="..." />
                        <div class="carousel-caption">
                            <h3>Men shirt</h3>
                            <p>Body fitted Men Shirt</p>
                            <p><a class="btn btn-lg btn-primary" href="SignUp.aspx" role="button">Join us Today</a></p>
                        </div>
                </div>
                <div class="item ">
                    <img src="Images/Trousser.jpg" alt="..." />
                        <div class="carousel-caption">
                            <h3>Men Troussers</h3>
                            <p>Trousser Pant</p>
                            <p><a class="btn btn-lg btn-primary" href="SignUp.aspx" role="button">Join Us Today</a></p>
                        </div>
                </div>
                <div class="item ">
                    <img src="Images/Ankra.jpg" alt="..." />
                    <div class="carousel-caption">
                        <h3>African Fashion Outfit</h3>
                        <p>Nigerian Ankra</p>
                        <p><a class="btn btn-lg btn-primary" href="SignUp.aspx" role="button">Join Us Today</a></p>
                    </div>
                </div>
                <div class="item">
                    <img src="Images/Bra&Pant.jpg" alt="...">
                    <div class="carousel-caption">
                        ...<h2>Bra and Pant</h2>
                        <p>Designer push-up pant and bra</p>
                        <p><a class="btn btn-lg btn-primary" href="SignUp.aspx" role="button">Join Us Today</a></p>
                    </div>
                </div>

            </div>




            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
              
        <!---Carousel---->

        <!---Middle Contents---->
        <div class="container">
            <div class="row">
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/Boxers.jpg" alt="Boxers" width="140" height="140">
                    <h2>Men Boxer</h2>
                    <p>
                        Men Boxers allow men to fell relaxed wnenever and also allows for ventilation
                        to the private part. It can be worn at homes and and arround your vicinity. It comes in different colours and sizes
                    </p>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/Boxers1.jpg" alt="Boxers" width="140" height="140">
                    <h2>Men Boxer</h2>
                    <p>
                        Men Boxers allow men to fell relaxed wnenever and also allows for ventilation
                        to the private part. It can be worn at homes and and arround your vicinity. It comes in different colours and sizes
                    </p>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/Boxers2.jpg" alt="Boxers" width="140" height="140">
                    <h2>Men Boxer</h2>
                    <p>
                        Men Boxers allow men to feel relaxed wnenever and also allows for ventilation
                        to the private part. It can be worn at homes and and arround your vicinity. It comes in different colours and sizes
                    </p>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/shoe.jpg" alt="shoes" width="140" height="140">
                    <h2>Men Shoe</h2>
                    <h3>Size 42</h3>
                    <p>
                       Italian Men swade shoes made from  animal skin that stand out of crowd. It can be worn with any trousser materials, be it Jeans, Chinos or even plain english or african wears. 
                    </p>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/shoe1.jpg" alt="shoes" width="140" height="140">
                    <h2>Men Shoe</h2>
                    <h3>Size 43</h3>
                    <p>
                        Men shoes made from Italian ledder that stand out of crowd. It can be worn on any trousser materials, be it Jeans, Chinos or even plain english or african wears. 
                    </p>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/shoes.jpg" alt="shoes" width="140" height="140">
                    <h2>Men Shoe</h2>
                    <h3>Size 44</h3>
                    <p>
                        Men shoes made from Italian ledder that stand out of crowd. It can be worn with any trousser materials, be it Jeans, Chinos or even plain english or african wears. 
                    </p>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/men_shirt1.jpg" alt="shirt" width="135" height="140">
                    <h2>Men cotton body Fitted shirt</h2>
                    <h3>Size medium</h3>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/men_shirt2.jpg" alt="shirt" width="135" height="140">
                    <h2>Men cotton body Fitted shirt</h2>
                    <h3>Size medium</h3>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/men_shirt.jpg" alt="shirt" width="135" height="140">
                    <h2>Men cotton body Fitted shirt</h2>
                    <h3>Size medium</h3>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/Bra&Pant.jpg" alt="undies" width="140" height="140">
                    <h2>Ladies undies</h2>
                    <h3>Size 27</h3>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/Ankra1.jpg" alt="Ankra" width="140" height="140">
                    <h2>Designer Ankra</h2>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                 <div class="col-lg-4">
                    <img class="img-circle" src="Images/unisex.jpg" alt="Unisex" width="140" height="140">
                    <h2>Designer Unisex wear</h2>
                    <p><a class="btn btn-default" href="*" role="button">View</a></p>
                </div>
                
            </div>
        </div>
        <!--Middle Contents----->

        <!----Footer----->
        <hr />
        <footer>
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
