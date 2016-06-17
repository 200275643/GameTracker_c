﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameTracker_c.Models;

namespace GameTracker_c
{
    public partial class GameStats : System.Web.UI.Page
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
                var CricketGames = (from allCricketGames in db.Games
                                   where allCricketGames.gamename == "cricket"
                                   select allCricketGames);
                CricketGamesGridView.DataSource = CricketGames.AsQueryable().ToList();
                CricketGamesGridView.DataBind();
            }

        }

        protected void SoccerGamesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void SoccerGamesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CricketGamesGridView.PageIndex = e.NewPageIndex;
            this.getSoccerGame();
        }
    }
}