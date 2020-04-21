<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddSize.aspx.cs" Inherits="AddSize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class ="container">
        <div class =" form-horizontal">
            <h2>Add Sizes</h2>
            <hr />
            <div class ="form-group">
             <asp:Label ID="Label1" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Size Name" Font-Names ="San francasco" ></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbSizeName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSize" CssClass="text-danger" runat="server" ControlToValidate="tbSizeName" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
                <div class ="form-group">
             <asp:Label ID="Label2" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Brand" Font-Names ="San francasco" ></asp:Label>
                <div class="col-md-3">
                      <asp:DropDownList ID="ddlBrand" CssClass ="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrand" CssClass="text-danger" runat="server" ControlToValidate="ddlBrand" ErrorMessage="This field is required!" InitialValue ="0"></asp:RequiredFieldValidator>
                </div>
            </div>
                  <div class ="form-group">
             <asp:Label ID="Label3" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Category" Font-Names ="San francasco" ></asp:Label>
                <div class="col-md-3">
                        <asp:DropDownList ID="ddlCategory" CssClass ="form-control" OnSelectedIndexChanged ="ddlCategory_SelectedIndexChanged" AutoPostBack ="true" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" CssClass="text-danger" runat="server" ControlToValidate="ddlCategory" ErrorMessage="This field is required!" InitialValue ="0"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Sub-Category" Font-Names="San francasco"></asp:Label>
                <div class="col-md-3">
                       <asp:DropDownList ID="ddlSubCat" CssClass ="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCat" CssClass="text-danger" runat="server" ControlToValidate="ddlSubCat" ErrorMessage="This field is required!" InitialValue ="0"></asp:RequiredFieldValidator>
                </div>
            </div>
                 <div class="form-group">
                <asp:Label ID="Label5" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Gender" Font-Names="San francasco"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlGender" CssClass ="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" CssClass="text-danger" runat="server" ControlToValidate="ddlGender" ErrorMessage="This field is required!" InitialValue ="0"></asp:RequiredFieldValidator>
                </div>
            </div>
          
            <div class ="form-group">
                <div class ="col-md-2"></div>
                <div class ="col-md-6">
                   <asp:Button ID="btnAddSizes" runat="server" CssClass="btn btn-info" Text="Add Size" Font-Bold="True" Font-Size="Medium" OnClick ="btnAddSizes_Click"/>
                   <asp:Label ID="lblAddSizes" CssClass="text-success" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!--AddSize Table-->

        <h1>Added Sizes</h1>
        <hr />
        <div class="table-responsive">
            <div class ="panel panel-default">
            <div class ="panel-heading">Sizes</div>
          <asp:Repeater ID="AddSizesRepeater" runat="server">
            <HeaderTemplate>
                <table class="table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Size</th>
                        <th> <a href="#">Edit</a></th>
                    </tr>
                </thead>
                <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("SizeID")%></td>
                    <td><%# Eval("SizeName")%></td>

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

