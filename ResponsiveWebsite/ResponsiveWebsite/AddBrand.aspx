<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddBrand.aspx.cs" Inherits="AddBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class ="container">
        <div class ="form-horizontal" >
            <h2> Add Brand</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text=" Brand Name" Font-Names ="San francasco" ></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbAddBrandName" PlaceHolder ="Add Brand Name" CssClass="form-control"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductsBrandname" CssClass="text-danger" runat="server" ControlToValidate="tbAddBrandName" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class ="form-group">
                <div class ="col-md-2"></div>
                    <div class ="col-md-1 col-md-6">
                        <asp:Label ID ="lblButtonAdd" CssClass ="col-md-2 control-label" runat="server" />
                    <asp:Button ID="btnAddBrandName" runat="server" CssClass="btn btn-info" Text="Add Brand" Font-Bold="True" Font-Size="Medium" OnClick ="btnAddBrandName_Click" />
                   <asp:Label ID="lblmsg" CssClass="text-success" runat="server"></asp:Label>
                      
                    </div>
                   </div>
                  </div>
        
        <!--Brand Table-->

        <h1>Brands</h1>
        <hr />
        <div class="table-responsive">
            <div class ="panel panel-default">
            <div class ="panel-heading">All Brands</div>
          <asp:Repeater ID="BrandRepeater" runat="server">
            <HeaderTemplate>
                <table class="table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Brands</th>
                        <th>Edit</th>
                    </tr>
                </thead>
                <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("BrandID")%></td>
                    <td><%# Eval("BrandName")%></td>
                    <td><a href="#">Edit</a></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </table>
            </FooterTemplate>
              
        </asp:Repeater>
                </div>
                </div>
        </div>
     
                  
</asp:Content>

