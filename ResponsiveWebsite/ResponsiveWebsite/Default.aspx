<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>e-Boutique</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>
    <body>
    <form id="form1" runat="server">
        <div style="background-color:white">
            <div class ="navbar navbar-default navbar-fixed-top" style="background-color:green" role ="navigation">
                <div class ="container">
                    <div class="navber-header">
                       <button type ="button" class ="navbar-toggle"style="background-color:white" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle Navigation</span>
                           <span class="icon-bar"></span>
                           <span class="icon-bar"></span>
                           <span class="icon-bar"></span>
                       </button>
                        <a class="navbar-brand" href="Default.aspx"><span style="font-family:'Harlow Solid';color:red;font-weight:700;font-size:x-large"><img  src="Images/unisex.jpg" alt="logo" height="35"/>e-Boutique</span></a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class ="nav navbar-nav navbar-right">
                            <li><a href="Default.aspx" style="font-weight:700;color:red">Home</a></li>
                            <li><a href="about-us.aspx" style="font-weight:700;color:red;">About Us</a></li>
                            <li><a href="Contacts.aspx" style="font-weight:700;color:red;">Contact</a></li>
                            <li class="dropdown" style="font-weight:700">
                          <a href="#" class="dropdown-toggle" data-toggle="dropdown" style="color:red">Products<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li style="background-color:black;color:white"class="dropdown-header">Gents</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Gents.aspx">Shirts</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Gents.aspx">Trousser</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Gents.aspx">Senegalese outfit</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Gents.aspx">Boxers</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Gents.aspx">Senators</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Gents.aspx">Singlets</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Gents.aspx">Shoes</a></li>
                                    <li role="separator" class="divider"></li>
                                    <li style="background-color:black;color:white" class="dropdown-header">Ladies</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Ladies.aspx">Tops</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Ladies.aspx">Skirts</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Ladies.aspx">Weavons</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Ladies.aspx">Traditional wears</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Ladies.aspx">Marry Kay</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Ladies.aspx">Under wears</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Ladies.aspx">Leggings</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="Ladies.aspx">Shoes</a></li>
                                    <li><a style="font-weight:700;color:deeppink" href="*">e.t.c</a></li>
                                </ul>
                            </li>
                            <li><a style="font-weight:700;color:red" href="Sign Up.aspx">Sign Up</a></li>
                         </ul>
                    </div>
                </div>
            </div>
            
                               <!--Carousel Start--->
        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>
   <br />
  <br />
  <br />
  <br />
  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
      <div class="item active">
        <div class ="row">
            <div class="col-lg-4">
       <img src="Images/African-Traditional.jpg" alt="Dress"/>
       <h3 style="color:black">Traditional African Dress</h3>
          <p style="color:black">African traditional printed ankara dress.<br />Nigerian clothing customized vintage ball<br /> gown three quarter sleeve</p>
          
      </div>
       <div class="col-lg-4">
      <img src="Images/Autumn-African.jpg" alt=""/>
        <h3 style="color:black">Proudly Nigerian</h3>
          <p style="color:black">: Autumn african dresses customized for African women.<br />Dashiki skirt set head scarf 3-Pieces.</p>
          <p><a class ="btn btn-lg btn-primary" href="#" role ="button">Visit Us</a></p>
      </div>
      <div class="col-lg-4">
       <img src="Images/African-Dresses-for-Women.jpg" alt=""/>
        <h3 style="color:black">African Dress for women</h3>
          <p style="color:black">African dress for continental women printed draped straight long dress.<br />Vestidos Bazin riche African ankara dress.</p>
          
     </div>
    </div>
   </div>
       <div class="item">
        <div class="row">
       <div class="col-lg-4">
      <img src="Images/Dashiki-Bandage.jpg" alt=""/>
        <h3 style="color:black">Dashiki Bandage</h3>
          <p style="color:black">African Bazin rich ankara dress.Elegant fashion.</p>
        
                </div>
            <div class="col-lg-4">            
      <img src="Images/africana8.jpg" alt=""/>
        <h3 style="color:black">African Atire</h3>
          <p style="color:black">Newest fashion</p>
          <p><a class ="btn btn-lg btn-primary" href="#" role ="button">Visit Us</a></p>
                </div>
              <div class="col-lg-4">            
      <img src="Images/Opslea-African.jpg" alt=""/>
        <h3 style="color:black">Opslea African Ankra</h3>
          <p style="color:black">Opslea African Women ankara dress.<br />Dashiki ethnic printed elastic skirt fashion.One shoulder set robe.</p>
          
                </div>
          </div>
          </div>
            <div class="item">
          <div class="row">
            <div class="col-lg-4">
      <img src="Images/African-Dresses.jpg" alt=""/>
        <h3 style="color:black">African Ankara</h3>
          <p style="color:black">African dress for women printed draped straight.<br />Long dress vestidos bazin riche African Ankara dress.</p>
          
                </div>
            <div class="col-lg-4">            
      <img src="Images/Dashiki-One-Sleeve.jpg" alt=""/>
        <h4 style="color:black">African One Sleve Dashiki</h4>
          <p style="color:black">:African One-Sleeve dashiki bazin,riche African ankara fashion robe.</p>
          <p><a class ="btn btn-lg btn-primary" href="#" role ="button">Visit Us</a></p>
                </div>
              <div class="col-lg-4">            
      <img src="Images/Hitarget-African-Dresses.png" alt=""/>
        <h3 style="color:black">Hitarget African Dress</h3>
          <p style="color:black">The Newest fashion</p>
          
                </div>
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
</div>

  <!--Carousel end-->
 
        <br />
        <br />
        <!--Mddle content-->
        <div class ="container center">
               <div class ="row">
            <div class="col-lg-3">
          <img class ="img-circle" src="Images/africana4.jpg" alt ="africa" width="140" height="140" />
                <h4>Beautiful Short Gawn</h4>
                <p></p>
                <p><a class ="btn btn-default" style ="background-color:lightpink" href ="#" role="button">View &raquo;</a></p>
            </div>
              <div class="col-lg-3">
          <img class ="img-circle" src="Images/Fadzeco-African.jpg" alt ="africa1" width="140" height="140" />
                <h4>African Women Basin Riche</h4>
                <p></p>
                <p><a class ="btn btn-default" style ="background-color:lightpink" href ="#" role="button">View &raquo;</a></p>
            </div>
              <div class="col-lg-3">
              <img class ="img-circle" src="Images/Autumn-African.jpg" alt ="africa2" width="140" height="140" />
                <h4>African Ankara style</h4>
                <p></p>
                <p><a class ="btn btn-default" style ="background-color:lightpink" href ="#" role="button">View &raquo;</a></p>
            </div>
            <div class="col-lg-3">
              <img class ="img-circle" src="Men Wears/Short-sleve-shirts.jpg" alt ="africa3" width="140" height="140" />
                <h4>Variety sizes and color of men short sleeve</h4>
                <p></p>
                <p><a class ="btn btn-default" style ="background-color:lightpink" href ="#" role="button">View &raquo;</a></p>
            </div>
            <div class="col-lg-3">
              <img class ="img-circle" src="Men Wears/Men-Boxers-Sexy.jpg" alt ="africa4" width="140" height="140" />
                <h4>Boxers for men</h4>
                <p></p>
                <p><a class ="btn btn-default" style ="background-color:lightpink" href ="#" role="button">View &raquo;</a></p>
            </div>
            <div class="col-lg-3">
              <img class ="img-circle" src="Men Wears/Loafers-Mens-Moccasins.jpg" alt ="africa5" width="140" height="140" />
                <h4>Men Moccasins loafer foot wear</h4>
                <p></p>
                <p><a class ="btn btn-default" style ="background-color:lightpink" href ="#" role="button">View &raquo;</a></p>
            </div>
                             <div class="col-lg-3">
              <img class ="img-circle" src ="Men Wears/Men-s-Casual.jpg" alt ="africa4" width="140" height="140" />
                <h4>Men casual street wears</h4>
                <p></p>
                <p><a class ="btn btn-default" style ="background-color:lightpink" href ="#" role="button">View &raquo;</a></p>
            </div>
            <div class="col-lg-3">
              <img class ="img-circle" src ="Men Wears/Hot-sell-2019.jpg" alt ="africa5" width="140" height="140" />
                <h4>Hot selling men wears</h4>
                <p></p>
                <p><a class ="btn btn-default" style ="background-color:lightpink" href ="#" role="button">View &raquo;</a></p>
            </div>
            </div>
        </div>
        <!---End middle content---->
         <hr />
        <!----Footer--->
        <br />
        <footer>
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
