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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userName"] != null)
            {

            }

            if (!IsPostBack)
            {
                this.getSoccerGame();
            }
        }

        /*<summary>
         *This Method gets the games data and puts it into the proper gridView 
         * </summary>
         * 
         * @methods getGame
         * @return {void}
         */
        protected void getSoccerGame()
        {
            using (chandureddyEntities db = new chandureddyEntities())
            {
                var SoccerGames = (from allSoccerGames in db.Games
                                   where allSoccerGames.gamename == "Soccer" && allSoccerGames.dateplayed >= DateTime.Now
                                   orderby allSoccerGames.dateplayed
                                   select allSoccerGames);
                SoccerGamesGridView.DataSource = SoccerGames.AsQueryable().ToList();
                SoccerGamesGridView.DataBind();
            }

        }

        protected void SoccerGamesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void SoccerGamesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SoccerGamesGridView.PageIndex = e.NewPageIndex;
            this.getSoccerGame();
        }
    }
}