<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="C_Shop.Admin.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class ="col-sm-12 col-md-4">
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title">Category</h4>
                    <hr />
                    <div class="form-group">
                        <label for="txtCategory">Category</label>
                        <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class ="col-sm-12 col-md-8">
    <div class="card">
        <div class="card-body">
            <h4 class="card-title">Category</h4>
            <hr />
        </div>
    </div>
</div>
    </div>

</asp:Content>
