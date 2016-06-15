
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GameTracker_c.Models;
using System.Web.ModelBinding;



namespace GameTracker_c
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getUser()
        {
            // connect to EF
            using (chandureddyEntities db = new chandureddyEntities())
            {
                //string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();
                string username = inputUserName.Text;
                string password = inputPassword.Text;
                // query the Students Table using EF and LINQ
                var User = (from UserInformation in db.UserInformation
                            where UserInformation.username == username && UserInformation.password == password
                            select UserInformation);

                if (User.Any())
                {
                    Response.Redirect("GameEditPage.aspx");
                }
                else
                    Response.Redirect("HomePage.aspx");





            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            this.getUser();
        }
    }
}