<%@ Page Title="Add Products" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddProducts.aspx.cs" Inherits="AddProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"  >
    <div class="container" >
        <div class="form-horizontal">
            <h2>Add products</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Name"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbProductsName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductsName" CssClass="text-danger" runat="server" ControlToValidate="tbProductsName" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Price"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbPrice" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" CssClass="text-danger" runat="server" ControlToValidate="tbPrice" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Selling Price"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbSellingPrice" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSellingPrice" CssClass="text-danger" runat="server" ControlToValidate="tbSellingPrice" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Brands"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlBrands" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrands" CssClass="text-danger" runat="server" ControlToValidate="ddlBrands" ErrorMessage="This field is required!" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label5" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Category"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlCategory" OnSelectedIndexChanged ="ddlCategory_SelectedIndexChanged" CssClass="form-control" AutoPostBack ="true" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ControlToValidate="ddlCategory" ErrorMessage="This field is required!" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="form-group">
                <asp:Label ID="Label20" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Gender"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlGender" OnSelectedIndexChanged ="ddlGender_SelectedIndexChanged" CssClass="form-control" AutoPostBack ="true" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="text-danger" runat="server" ControlToValidate="ddlGender" ErrorMessage="This field is required!" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label6" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Sub-Category"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlSub_Category" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ControlToValidate="ddlSub_Category" ErrorMessage="This field is required!" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label7" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Size"></asp:Label>
                <div class="col-md-3">
                    <asp:CheckBoxList ID="cblSizes" CssClass ="form-control" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label8" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Description"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbDescription" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ControlToValidate="tbDescription" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label9" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Products Details"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbProductsDetails" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ControlToValidate="tbProductsDetails" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label10" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Materials and Care"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbMcare" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ControlToValidate="tbMcare" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label11" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="FileUploadImg" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ControlToValidate="FileUploadImg" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label12" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="FileUploadImg2" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="text-danger" runat="server" ControlToValidate="FileUploadImg2" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label13" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="FileUploadImg3" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="text-danger" runat="server" ControlToValidate="FileUploadImg3" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label14" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="FileUploadImg4" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="text-danger" runat="server" ControlToValidate="FileUploadImg4" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label15" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Upload Image"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="FileUploadImg5" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="text-danger" runat="server" ControlToValidate="FileUploadImg5" ErrorMessage="This field is required!"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label16" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="Free Delivery"></asp:Label>
                <div class="col-md-3">
                    <asp:CheckBox ID="cbFreeDelivery" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label17" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="30 Days Return"></asp:Label>
                <div class="col-md-3">
                    <asp:CheckBox ID="cb30Return" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label18" CssClass="col-md-1 col-lg-2 control-label" runat="server" Text="COD"></asp:Label>
                <div class="col-md-3">
                    <asp:CheckBox ID="cbCOD" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-info" Text="LogIn" Font-Bold="True" Font-Size="Medium" OnClick="btnAdd_Click" />

                </div>
            </div>


        </div>
    </div>
</asp:Content>

