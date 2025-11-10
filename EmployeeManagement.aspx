<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeManagement.aspx.cs" Inherits="EmployeeManagementSystem.EmployeeManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Employee Management</h2>
    
    <!-- Add/Edit Employee Form -->
    <div class="card mb-4">
        <div class="card-header">
            <h5 id="formTitle" runat="server" class="mb-0">Add New Employee</h5>
        </div>
        <div class="card-body">
            <asp:HiddenField ID="hdnEmployeeID" runat="server" />
            
            <div class="row">
                <div class="col-md-6">
                    <div class="mb-3">
                        <label class="form-label">Full Name</label>
                        <asp:TextBox ID="txtEmpFullName" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Email</label>
                        <asp:TextBox ID="txtEmpEmail" runat="server" TextMode="Email" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Phone Number</label>
                        <asp:TextBox ID="txtEmpPhone" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Date of Birth</label>
                        <asp:TextBox ID="txtEmpDOB" runat="server" TextMode="Date" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                </div>
                
                <div class="col-md-6">
                    <div class="mb-3">
                        <label class="form-label">Education Level</label>
                        <asp:DropDownList ID="ddlEmpEducation" runat="server" CssClass="form-control" required="true">
                            <asp:ListItem Value="">Select Education</asp:ListItem>
                            <asp:ListItem Value="High School">High School</asp:ListItem>
                            <asp:ListItem Value="Bachelor">Bachelor</asp:ListItem>
                            <asp:ListItem Value="Master">Master</asp:ListItem>
                            <asp:ListItem Value="PhD">PhD</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Department</label>
                        <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Position</label>
                        <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <label class="form-label">Salary</label>
                        <asp:TextBox ID="txtSalary" runat="server" TextMode="Number" step="0.01" CssClass="form-control" required="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            
            <div class="d-flex gap-2">
                <asp:Button ID="btnSave" runat="server" Text="Save Employee" CssClass="btn btn-success" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
    
    <!-- Employees Grid -->
    <div class="card">
        <div class="card-header">
            <h5 class="mb-0">Employee List</h5>
        </div>
        <div class="card-body">
            <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
                OnRowEditing="gvEmployees_RowEditing" OnRowDeleting="gvEmployees_RowDeleting" DataKeyNames="EmployeeID"
                EmptyDataText="No employees found.">
                <Columns>
                    <asp:BoundField DataField="EmployeeID" HeaderText="ID" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Position" HeaderText="Position" />
                    <asp:BoundField DataField="Salary" HeaderText="Salary" DataFormatString="{0:C}" />
                    <asp:CommandField ShowEditButton="true" ButtonType="Button" EditText="Edit" ControlStyle-CssClass="btn btn-warning btn-sm" />
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" DeleteText="Delete" ControlStyle-CssClass="btn btn-danger btn-sm" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
