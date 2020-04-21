<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddCategories.aspx.cs" Inherits="AddCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class ="container">
        <div class="form-horizontal">
            <h2>Add Categories</h2>
            <hr />
            <div class ="form-group">
                <asp:label id="Label1" cssclass="col-md-1 col-lg-2 control-label" runat="server" text=" Categories" font-names="San francasco"></asp:label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbAddCategories" PlaceHolder="Add Category" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:requiredfieldvalidator id="RequiredFieldValidatorCategories" cssclass="text-danger" runat="server" controltovalidate="tbAddCategories" errormessage="This field is required!"></asp:requiredfieldvalidator>
                </div>
            </div>
            <div class ="form-group">
                <div class ="col-md-2"></div>
                <div class ="col-md-1 col-md-6">
                    <asp:Button ID="btnAddCategories" runat="server" CssClass="btn btn-info" Text="Add Category" Font-Bold="True" Font-Size="Medium" OnClick="btnAddCategories_Click" />
                   <asp:Label ID="lblmsg" CssClass="text-success" runat="server"></asp:Label>
                      
                    </div>

            </div>

        </div>

         <!--Category Table-->

        <h1>Categories</h1>
        <hr />
        <div class="table-responsive">
            <div class ="panel panel-default">
            <div class ="panel-heading">All Categories</div>
          <asp:Repeater ID="CategoryRepeater" runat="server">
            <HeaderTemplate>
                <table class="table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Category</th>
                        <th>Edit</th>
                    </tr>
                </thead>
                <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("CategoryID")%></td>
                    <td><%# Eval("CategoryName")%></td>
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

