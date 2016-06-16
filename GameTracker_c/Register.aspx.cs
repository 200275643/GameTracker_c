﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameTracker_c.Models;

namespace GameTracker_c
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            using (chandureddyEntities db = new chandureddyEntities())
            {
                string userName = UserNameTextBox.Text;
                string password = PasswordTextBox.Text;
                string confPass = ConfirmPasswordTextBox.Text;

                //check user name exists in db

                var userNameCheck = (from UserInformation in db.User_Information
                                     where UserInformation.username == userName
                                     select UserInformation);

                if (userNameCheck.Any())
                {
                    ClientScript.RegisterStartupScript(GetType(), "validate", "alert('UserName already EXISTS.');", true);
                }
                else
                {
                    if (password == confPass)
                    {
                        if (password.Length > 5)
                        {
                            User_Information newUser = new User_Information();

                            newUser.username = userName;
                            newUser.password = password;
                            db.User_Information.Add(newUser);
                            db.SaveChanges();
                            Response.Redirect("GameEditPage.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "validate", "alert('Password must be atleast 6 char long.');", true);
                            PasswordTextBox.Text = "";
                            PasswordTextBox.Focus();
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "validate", "alert('Passwords dont match.');", true);
                        ConfirmPasswordTextBox.Text = "";
                        ConfirmPasswordTextBox.Focus();
                    }
                }
            }
        }
    }
}