<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Gender.aspx.cs" Inherits="Gender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class ="container">
        <div class =" form-horizontal">
            <h2>Add Gender</h2>
            <hr />
            <div class ="form-group">
                <asp:Label ID ="label" CssClass ="col-md-2 control-label" Text="Gender" runat="server" />
                <div class ="col-md-3">
                 <asp:TextBox ID="tbGender" CssClass ="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" CssClass="text-danger" runat="server" ControlToValidate="tbGender" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                   </div>
                 </div>
                <div class ="form-group">
                <div class ="col-md-2"></div>
                <div class ="col-md-6">
                    <asp:Button ID="btnAddGender" runat="server" CssClass="btn btn-info" Text="Add Gender" Font-Bold="True" Font-Size="Medium" OnClick ="btnAddGender_Click"/>
                   <asp:Label ID="lblGender" CssClass="text-success" runat="server"></asp:Label>
                </div>
            </div>

        </div>
         <!--Gender Table-->

        <h1>Gender</h1>
        <hr />
        <div class="table-responsive">
            <div class ="panel panel-default">
            <div class ="panel-heading">Unisex</div>
          <asp:Repeater ID="GenderRepeater" runat="server">
            <HeaderTemplate>
                <table class="table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Geneder</th>
                        <th>Edit</th>
                    </tr>
                </thead>
                <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("GenderID")%></td>
                    <td><%# Eval("GenderName")%></td>

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

