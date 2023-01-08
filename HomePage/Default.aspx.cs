using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginTryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signUpButton_Click(object sender, EventArgs e)
        {
            LoginService.Service1Client loginClient = new LoginService.Service1Client();  //creating login service proxy
            
            string username = signUpUsernameTextBox.Text;  //pulling input from user
            string password = signUpPasswordTextBox.Text;
            int x = loginClient.signUp(username, password);  //0 on success, -1 if a user already exists with username

            if(x == -1)  //-1 means a user with username already exists
            {
                signUpStatusLabel.Text = "A user with this username already exists, please try a different one.";  //updating status label
            }
            else
            {
                signUpStatusLabel.Text = "Account created successfully";  //updating status label
                signUpUsernameTextBox.Text = "";
                signUpPasswordTextBox.Text = "";
                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if(loginUsernameTextBox.Text == "Admin" && loginPasswordTextBox.Text == "Password")
            {
                Response.Redirect("StaffPage.aspx");
            }
            else
            {
                LoginService.Service1Client loginClient = new LoginService.Service1Client();  //creating login service proxy

                string username = loginUsernameTextBox.Text;  //pulling input from user
                string password = loginPasswordTextBox.Text;
                int x = loginClient.signIn(username, password);  //0 on success, -1 if a user already exists with username

                if (x != -1)
                {
                    loginStatusLabel.Text = "Account information incorrect";
                }

                if (x == 0)
                {
                    Response.Redirect("MemberPage.aspx");
                }
            }
        }
    }
}