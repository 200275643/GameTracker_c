using GameTracker_c.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/**
 @author: Vandit Kothari/Jose Mathew
    @date: June 8,2016 
    @updated : June 15,2016
    @Website Name : gametrackingsystem@azurewebsites.net
    @This is a HomePage.
    @version = 2.0
*/
namespace GameTracker_c
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (chandureddyEntities db = new chandureddyEntities())
            {
                var gameEdit = (from allgames in db.Games
                                select allgames);


                GameGridView.DataSource = gameEdit.AsQueryable().ToList();
                GameGridView.DataBind();


            }
        }
    }
}