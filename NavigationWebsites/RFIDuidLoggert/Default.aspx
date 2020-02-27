<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Radio Frequency Identification Data Log</title>

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
            <div class="navbar navbar-default navbar-fixed-top" style="background-color:dodgerblue" role="navigation">
                <div class="container">
                    <div class="navbar-header">

                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Default.aspx"><span style="font-family:Algerian">
                            <img alt="Logo" src="Images/td4pai.jpg" height="30" />TD4PAI HUB</span></a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li class="active"><a href="Default.aspx">Home</a></li>
                            <li><a href="*">About</a></li>
                            <li><a href="*">Contact</a></li>

                        </ul>

                    </div>
                     <h3 style="font-family:Britannic">RIFD User details...</h3>
                    <hr />

                </div>


            </div>
            <!---Middle contents------>

            <!Middle contents>
            <!--Sign up------>
            <div class="center-page">
                <label class="col-xs-12">Firstname</label>
                <div class="col-lg-12">
                    <asp:TextBox ID="tbFirstname" runat="server" CssClass="form-control" placeholder="Firstname:"></asp:TextBox>
                </div>
                <label class="col-xs-12">Middlename</label>
                <div class="col-xs-12">
                    <asp:TextBox ID="tbMiddlename" runat="server" CssClass="form-control" placeholder="Middlename:"></asp:TextBox>
                </div>
                <label class="col-xs-12">Lastname</label>
                <div class="col-xs-12">
                    <asp:TextBox ID="tbLastname" runat="server" CssClass="form-control" placeholder="Lastname:"></asp:TextBox>
                </div>
                <label class="col-xs-12">Sex</label>
                <div class="col-xs-12">
                    <asp:DropDownList ID="DropDownListSex" CssClass="form-control" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
               <label class="col-xs-12">Tag UID</label>
                <div class="col-xs-12">
                    <asp:TextBox ID="tbRFIDTag" runat="server" CssClass="form-control" placeholder="Tag UID:"></asp:TextBox>
                </div>
                  <div class="col-xs-12 space-vert">
                    <asp:Button ID="btnWriteTag" CssClass="btn-success" runat="server" Text="WriteTag" OnClick="btnWriteTag_Click" />
                    <asp:Button ID="btnReadTag" CssClass="btn-success" runat="server" Text="ReadTag" OnClick="btnReadTag_Click" />
                    <asp:Button ID="btnClearForm" CssClass="btn-success" runat="server" Text="ClearForm" OnClick="btnClearForm_Click" />

                </div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>

             
            <!--Sign up------>



        </div>
        <!----Footer----->
        <hr />
        <footer class="footer-pos">
            <div class="container">
                <p class="pull-right"><a href="*">Back to Top</a></p>
                <p>&copy; 2019 TD4PAI.ORG.NG &middot; <a href="Default.aspx">Home</a> &middot;<a href="*">About</a> &middot; <a href="*">Contact</a> &middot; <a href="*">Products</a> &middot;</p>
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
