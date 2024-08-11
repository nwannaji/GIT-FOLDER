<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="SubCategories.aspx.cs" Inherits="SubCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class ="container">
        <div class ="form-horizontal">
            <h2>Add Sub-Categories</h2>
            <hr />
             <div class="form-group">
              <asp:Label ID="Label2" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text=" Main Category" Font-Names ="San francasco" ></asp:Label>
                 <div class ="col-md-3">
                 <asp:DropDownList ID="ddlCategory" CssClass ="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ControlToValidate="ddlCategory" ErrorMessage="This field is required!" InitialValue ="0"></asp:RequiredFieldValidator>
                     </div>
             </div>
            <div class="form-group">
              <asp:Label ID="Label1" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Sub-Categories" Font-Names ="San francasco" ></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbSubCategories" PlaceHolder="Sub-Categories" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategories" CssClass="text-danger" runat="server" ControlToValidate="tbSubCategories" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
             </div>
            <div class ="form-group">
                <div class ="col-md-2"></div>
                <div class ="col-md-6">
                    <asp:Button ID="btnSubCategories" runat="server" CssClass="btn btn-info" Text="Sub-Category" Font-Bold="True" Font-Size="Medium" OnClick ="btnSubCategories_Click" />
                   <asp:Label ID="lblmsg" CssClass="text-success" runat="server"></asp:Label>
                </div>
            </div>


        </div>

    <!--SubCategory Table-->

        <h1>SubCategories</h1>
        <hr />
        <div class="table-responsive">
            <div class ="panel panel-default">
            <div class ="panel-heading">All Sub-Categories</div>
          <asp:Repeater ID="SubCategoryRepeater" runat="server">
            <HeaderTemplate>
                <table class="table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Sub-Category</th>
                        <th>Edit</th>
                    </tr>
                </thead>
                <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("SubCategoryID")%></td>
                    <td><%# Eval("SubCategoryName")%></td>
                    <td><%# Eval("CategoryName")%></td>

                    <td>Edit</td>
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

