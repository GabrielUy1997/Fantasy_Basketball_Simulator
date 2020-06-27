﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantasyBasketball
{
    public partial class ShowTeamRoster : Form
    {
        Game __game;
        LeaugeTeam __player1;
        ShowGame _showGame;
        public ShowTeamRoster(Game g, LeaugeTeam p1, ShowGame sg)
        {
            InitializeComponent();
            __player1 = p1;
            __game = g;
            _showGame = sg;
            foreach (int player in __player1.team)
            {
                TeamList.Items.Add((__player1.team.IndexOf(player) + 1 )+ ". "  + __game.GetPlayerName(player));
            }
           
        }

        private void BackFromTeamRoster_Click(object sender, EventArgs e)
        {
            Hide();
            _showGame.Show();
        }

        private void TeamList_Click(object sender, EventArgs e)
        {
            HistoricalStatsBox.Items.Clear();
            LoadHistoricalStats();
        }

        private void LoadHistoricalStats()
        {
            string Name;
            string Pos;
            string Age;
            string Team;
            string GamesPlayed;
            string GamesStarted;
            string FG;
            string FGA;
            string ThreePointers;
            string TwoPointers;
            string FT;
            string FTA;
            string ORB;
            string DRB;
            string AST;
            string STL;
            string BLK;
            string TOV;
            string PF;
            string PTS;
            string SeasonPath = @"C:\Users\Gabe\source\repos\ConsoleApp1\Seasons\";
            int ActiveSeasons = 1;
            bool IsInSeason = false;
            int HistoricalSeason;
            string IndexSeason;
            string[] seasons;
            string[] name;
            seasons = _showGame.__season.Split('-');
            HistoricalSeason = Int32.Parse(seasons[0]);
            IndexSeason = (HistoricalSeason - ActiveSeasons).ToString() + "-" + HistoricalSeason.ToString();
            HistoricalStatsBox.Items.Add("Season" + " POS" + " Age" + " Team" + " GP" + " GS" + " FG" + " FGA" + " 3PT" + " 2PT" + " FT" + " FTA" + " ORB" + " DRB" + " AST" + " STL" + " BLK" + " TOV" + " PF" + " PTS");
            do
            {
                IsInSeason = false;

                StreamReader reader = new StreamReader(File.OpenRead(SeasonPath + IndexSeason + ".csv"));
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string[] values = line.Split(',');
                        name = values[1].Split('\\');
                        if (values.Length >= 4 && name[0] == __game._PlayerName[__player1.team[TeamList.SelectedIndex]])
                        {
                            Name = name[0];
                            Pos = values[2];
                            Age = values[3];
                            Team = values[4];
                            GamesPlayed = values[5];
                            GamesStarted = values[6];
                            FG = values[8];
                            FGA = values[9];
                            ThreePointers = values[11];
                            TwoPointers = values[14];
                            FT = values[18];
                            FTA = values[19];
                            ORB = values[21];
                            DRB = values[22];
                            AST = values[24];
                            STL = values[25];
                            BLK = values[26];
                            TOV = values[27];
                            PF = values[28];
                            PTS = values[29];
                            IsInSeason = true;
                            HistoricalStatsBox.Items.Add(IndexSeason + ":" + Pos + " " + Age + " " + Team + " " + GamesPlayed + " " + GamesStarted + " " + FG + " " + FGA + " " + ThreePointers + " " + TwoPointers + " " + FT + " " + FTA 
                                + " " + ORB + " " + DRB + " " + AST + " " + STL + " " + BLK + " " + TOV + " " + PF + " " + PTS);
                            break;
                        }
                    }
                   
                }
                ActiveSeasons++;
                IndexSeason = (HistoricalSeason - ActiveSeasons).ToString() + "-" + (HistoricalSeason - (ActiveSeasons - 1)).ToString();
                if(!File.Exists(SeasonPath + IndexSeason + ".csv"))
                {
                    break;
                }
            } while (IsInSeason == true);
        }
    }
}
