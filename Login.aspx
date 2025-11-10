<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmployeeManagementSystem.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-4">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title mb-0">Login</h4>
                </div>
                <div class="card-body">
                    <asp:Label ID="lblMessage" runat="server" CssClass="message" Visible="false"></asp:Label>
                    
                    <div class="mb-3">
                        <label class="form-label">Username</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="d-grid gap-2">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                        <asp:HyperLink ID="lnkSignup" runat="server" NavigateUrl="~/Signup.aspx" CssClass="btn btn-link">Don't have an account? Sign up</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
