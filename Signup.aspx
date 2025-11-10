<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="EmployeeManagementSystem.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title mb-0">Employee Signup</h4>
                </div>
                <div class="card-body">
                    <asp:Label ID="lblMessage" runat="server" CssClass="message" Visible="false"></asp:Label>
                    
                    <div class="mb-3">
                        <label class="form-label">Full Name</label>
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Phone Number</label>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Date of Birth</label>
                        <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Education Level</label>
                        <asp:DropDownList ID="ddlEducation" runat="server" CssClass="form-control" required="true">
                            <asp:ListItem Value="">Select Education</asp:ListItem>
                            <asp:ListItem Value="High School">High School</asp:ListItem>
                            <asp:ListItem Value="Bachelor">Bachelor</asp:ListItem>
                            <asp:ListItem Value="Master">Master</asp:ListItem>
                            <asp:ListItem Value="PhD">PhD</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Username</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="d-grid gap-2">
                        <asp:Button ID="btnSignup" runat="server" Text="Sign Up" CssClass="btn btn-primary" OnClick="btnSignup_Click" />
                        <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx" CssClass="btn btn-link">Already have an account? Login</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
