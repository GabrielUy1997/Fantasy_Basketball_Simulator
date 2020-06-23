﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantasyBasketball
{
    public partial class SeasonSelect : Form
    {
        Game game = new Game();
        public static string UserInput = "";
        public SeasonSelect()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            UserInput = SeasonEntry.Text;
            ShowDrafting showDrafting = new ShowDrafting(UserInput);
            if(game.LoadSeasonStats(game, UserInput) == true)
            {
                Hide();
                showDrafting.StartGame(game, UserInput);
                showDrafting.Show();
                showDrafting.PlayerSelect();
            }
            
        }
    }
}