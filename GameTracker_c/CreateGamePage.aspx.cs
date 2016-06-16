﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.ModelBinding;
using GameTracker_c.Models;

namespace GameTracker_c
{
    public partial class CreateGamePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && (Request.QueryString.Count > 0))
            {
                this.GetGame();
            }
        }

        private void GetGame()
        {
            int GameID = Convert.ToInt32(Request.QueryString["GameID"]);

            //connect to DB
            using (chandureddyEntities db = new chandureddyEntities())
            {
                Game updatedGame = (from game in db.Games where game.Id == GameID select game).FirstOrDefault();

                if (updatedGame != null)
                {
                    hometeamTextBox.Text = updatedGame.hometeam;
                    awayteamTextBox.Text = updatedGame.awayteam;
                    hometeampointsTextBox.Text = updatedGame.hometeampoints.ToString();
                    awayteampointsTextBox.Text = updatedGame.awayteampoints.ToString();
                    attendanceTextBox.Text = updatedGame.attendance.ToString();
                    venueTextBox.Text = updatedGame.venue;
                    gamenameTextBox.SelectedValue = updatedGame.gamename;
                    dateplayedTextBox.Text = updatedGame.dateplayed.ToString("yyy-MM-dd");
                }
            }
        }




        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void AddGameButton_Click(object sender, EventArgs e)
        {
            using (chandureddyEntities db = new chandureddyEntities())
            {
                // use the syudent model to save a new record
                Game newGame = new Game();

                int GameID = -1;

                if (Request.QueryString.Count > 0)
                {
                    // get game id from url
                    GameID = Convert.ToInt32(Request.QueryString["GameID"]);
                    // get the current Game from the DB
                    newGame = (from game in db.Games where game.Id == GameID select game).FirstOrDefault();
                }
                // add for data to new student record
                newGame.homeName = homeNameTextBox.Text;
                newGame.awayName = awayNameTextBox.Text;
                newGame.homePoints = Convert.ToInt32(homePointsTextBox.Text);
                newGame.awayPoints = Convert.ToInt32(awayPointsTextBox.Text);
                newGame.attendances = Convert.ToInt32(attendancesTextBox.Text);
                newGame.stadium = stadiumTextBox.Text;
                newGame.sportType = sportTypeTextBox.SelectedValue;
                newGame.datePlayed = Convert.ToDateTime(datePlayedTextBox.Text);

                // add a new game to Games Table Collection
                if (GameID == -1)
                {
                    db.Games.Add(newGame);
                }

                // run insert commands to database
                db.SaveChanges();

                Response.Redirect("~/Default.aspx");
            }

        }
    }
}