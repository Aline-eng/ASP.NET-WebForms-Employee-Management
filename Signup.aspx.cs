using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Description;
using System.Web.UI;
using EmployeeManagementSystem.AppCode;

namespace EmployeeManagementSystem
{
    public partial class Signup : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                SqlParameter[] parameters = {
                new SqlParameter("@Username", txtUsername.Text.Trim()),
                new SqlParameter("@Password", txtPassword.Text), // Note: Hash password in production
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@FullName", txtFullName.Text.Trim()),
                new SqlParameter("@PhoneNumber", txtPhone.Text.Trim()),
                new SqlParameter("@DateOfBirth", DateTime.Parse(txtDOB.Text)),
                new SqlParameter("@EducationLevel", ddlEducation.SelectedValue)
            };

                DataTable result = dbHelper.ExecuteQuery("sp_SignupUser", parameters);

                if (result.Rows[0]["Status"].ToString() == "Success")
                {
                    ShowMessage("Registration successful! Please login.", "success");
                    ClearForm();
                }
                else
                {
                    ShowMessage("Error: " + result.Rows[0]["Status"].ToString(), "error");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error: " + ex.Message, "error");
            }
        }

        private void ShowMessage(string message, string type)
        {
            lblMessage.Text = message;
            lblMessage.CssClass = "message " + type;
            lblMessage.Visible = true;
        }

        private void ClearForm()
        {
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtDOB.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            ddlEducation.SelectedIndex = 0;
        }
    }
}