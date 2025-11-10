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
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                SqlParameter[] parameters = {
                new SqlParameter("@Username", txtUsername.Text.Trim()),
                new SqlParameter("@Password", txtPassword.Text)
            };

                DataTable result = dbHelper.ExecuteQuery("sp_ValidateLogin", parameters);

                if (result.Rows.Count > 0)
                {
                    Session["UserID"] = result.Rows[0]["UserID"];
                    Session["Username"] = result.Rows[0]["Username"];
                    Session["FullName"] = result.Rows[0]["FullName"];
                    Session["Role"] = result.Rows[0]["Role"];

                    Response.Redirect("EmployeeManagement.aspx");
                }
                else
                {
                    ShowMessage("Invalid username or password!", "error");
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
    }
}