using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementSystem.AppCode;

namespace EmployeeManagementSystem
{
    public partial class EmployeeManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if user is logged in
                if (Session["Username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                // Update welcome message in master page
                Label lblWelcome = (Label)Master.FindControl("lblWelcome");
                Button btnLogout = (Button)Master.FindControl("btnLogout");

                if (lblWelcome != null)
                {
                    lblWelcome.Text = "Welcome, " + Session["FullName"] + "!";
                }
                if (btnLogout != null)
                {
                    btnLogout.Visible = true;
                }

                BindEmployees();
            }
        }
        private void BindEmployees()
        {
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                DataTable dt = dbHelper.ExecuteQuery("sp_GetAllEmployees");
                gvEmployees.DataSource = dt;
                gvEmployees.DataBind();
            }
            catch (Exception ex)
            {
                // Handle error
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                SqlParameter[] parameters;

                if (string.IsNullOrEmpty(hdnEmployeeID.Value))
                {
                    // Insert new employee
                    parameters = new SqlParameter[] {
                    new SqlParameter("@FullName", txtEmpFullName.Text),
                    new SqlParameter("@Email", txtEmpEmail.Text),
                    new SqlParameter("@PhoneNumber", txtEmpPhone.Text),
                    new SqlParameter("@DateOfBirth", DateTime.Parse(txtEmpDOB.Text)),
                    new SqlParameter("@EducationLevel", ddlEmpEducation.SelectedValue),
                    new SqlParameter("@Department", txtDepartment.Text),
                    new SqlParameter("@Position", txtPosition.Text),
                    new SqlParameter("@Salary", decimal.Parse(txtSalary.Text))
                };
                    dbHelper.ExecuteNonQuery("sp_InsertEmployee", parameters);
                }
                else
                {
                    // Update existing employee
                    parameters = new SqlParameter[] {
                    new SqlParameter("@EmployeeID", int.Parse(hdnEmployeeID.Value)),
                    new SqlParameter("@FullName", txtEmpFullName.Text),
                    new SqlParameter("@Email", txtEmpEmail.Text),
                    new SqlParameter("@PhoneNumber", txtEmpPhone.Text),
                    new SqlParameter("@DateOfBirth", DateTime.Parse(txtEmpDOB.Text)),
                    new SqlParameter("@EducationLevel", ddlEmpEducation.SelectedValue),
                    new SqlParameter("@Department", txtDepartment.Text),
                    new SqlParameter("@Position", txtPosition.Text),
                    new SqlParameter("@Salary", decimal.Parse(txtSalary.Text))
                };
                    dbHelper.ExecuteNonQuery("sp_UpdateEmployee", parameters);
                }

                ClearForm();
                BindEmployees();
            }
            catch (Exception ex)
            {
                // Handle error
            }
        }
        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int employeeID = Convert.ToInt32(gvEmployees.DataKeys[e.NewEditIndex].Value);
            LoadEmployeeForEdit(employeeID);
            e.Cancel = true; // Cancel the default edit mode
        }
        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int employeeID = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);

            DatabaseHelper dbHelper = new DatabaseHelper();
            SqlParameter[] parameters = { new SqlParameter("@EmployeeID", employeeID) };
            dbHelper.ExecuteNonQuery("sp_DeleteEmployee", parameters);

            BindEmployees();
        }

        private void LoadEmployeeForEdit(int employeeID)
        {
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                SqlParameter[] parameters = { new SqlParameter("@EmployeeID", employeeID) };
                DataTable dt = dbHelper.ExecuteQuery("sp_GetEmployeeByID", parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    hdnEmployeeID.Value = employeeID.ToString();
                    txtEmpFullName.Text = row["FullName"].ToString();
                    txtEmpEmail.Text = row["Email"].ToString();
                    txtEmpPhone.Text = row["PhoneNumber"].ToString();
                    txtEmpDOB.Text = Convert.ToDateTime(row["DateOfBirth"]).ToString("yyyy-MM-dd");
                    ddlEmpEducation.SelectedValue = row["EducationLevel"].ToString();
                    txtDepartment.Text = row["Department"].ToString();
                    txtPosition.Text = row["Position"].ToString();
                    txtSalary.Text = row["Salary"].ToString();

                    formTitle.InnerText = "Edit Employee";
                }
            }
            catch (Exception ex)
            {
                // Handle error
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            hdnEmployeeID.Value = "";
            txtEmpFullName.Text = "";
            txtEmpEmail.Text = "";
            txtEmpPhone.Text = "";
            txtEmpDOB.Text = "";
            ddlEmpEducation.SelectedIndex = 0;
            txtDepartment.Text = "";
            txtPosition.Text = "";
            txtSalary.Text = "";
            formTitle.InnerText = "Add New Employee";
        }
    }
}