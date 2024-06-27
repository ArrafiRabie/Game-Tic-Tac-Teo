using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Teo_Game_AR.Properties;

namespace Tic_Tac_Teo_Game_AR
{
    public partial class Form1 : Form
    {
        struct stMyGame
        {
            public byte Player_One;
            public byte Player_Tow;
            public byte Turn;
            public byte Number_Turn;
            public byte Number_of_winning_games_X;
            public byte Number_of_winning_games_O;
            public bool Check;
        }

        stMyGame ST;

        public Form1()
        {
            InitializeComponent();
        }

        void Draw_Game(byte Number_Turn)
        {
            if (Number_Turn == 9)
            {
                LB_Winner.Text = "Draw";
                if (MessageBox.Show("The match ended in a draw", "Confirme",MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    BT_Restart_Game_Click(BT_Restart_Game, EventArgs.Empty);
                }
            }
        }

        void Check_Turn_Player(Button btn)
        {
             if (ST.Turn == ST.Player_One)
             {
                btn.BackgroundImage = Resources.icons8_x_cute_48;
                btn.Tag = "X";
                ST.Turn = ST.Player_Tow;
                ST.Number_Turn++;
                LB_Player.Text = "Player 2";
                Check_Turn_To_Desebel_Button();
                return;
             }

             if (ST.Turn == ST.Player_Tow)
             {
                btn.BackgroundImage = Resources.icons8_o_64__3_;
                btn.Tag = "O";
                ST.Turn = ST.Player_One;
                ST.Number_Turn++;
                LB_Player.Text = "Player 1";
                //Draw_Game(ST.Number_Turn);
                //Continuous_Boxes();
                Check_Turn_To_Desebel_Button();
                return;
             } 
        }

        public bool Continuous_Boxes()
        {
            if (BT_Number_One.Tag.ToString() != "?" && BT_Number_One.Tag.ToString() == BT_Number_Two.Tag.ToString() &&
                BT_Number_One.Tag.ToString() == BT_Number_Three.Tag.ToString())
                return true;

            else if (BT_Number_Four.Tag.ToString() != "?" && BT_Number_Four.Tag.ToString() == BT_Number_Five.Tag.ToString() &&
                BT_Number_Four.Tag.ToString() == BT_Number_Sixe.Tag.ToString())
                return true;

            else if (BT_Number_Seven.Tag.ToString() != "?" && BT_Number_Seven.Tag.ToString() == BT_Number_Eight.Tag.ToString() &&
                BT_Number_Seven.Tag.ToString() == BT_Number_Nine.Tag.ToString())
                return true;

            else if (BT_Number_One.Tag.ToString() != "?" && BT_Number_One.Tag.ToString() == BT_Number_Four.Tag.ToString() &&
                   BT_Number_One.Tag.ToString() == BT_Number_Seven.Tag.ToString())
                return true;

            else if (BT_Number_Two.Tag.ToString() != "?" && BT_Number_Two.Tag.ToString() == BT_Number_Five.Tag.ToString() &&
                BT_Number_Two.Tag.ToString() == BT_Number_Eight.Tag.ToString())
                return true;

            else if (BT_Number_Three.Tag.ToString() != "?" && BT_Number_Three.Tag.ToString() == BT_Number_Sixe.Tag.ToString() &&
                BT_Number_Three.Tag.ToString() == BT_Number_Nine.Tag.ToString())
                return true;

            else if (BT_Number_One.Tag.ToString() != "?" && BT_Number_One.Tag.ToString() == BT_Number_Five.Tag.ToString() &&
                BT_Number_One.Tag.ToString() == BT_Number_Nine.Tag.ToString())
                return true;

            if (BT_Number_Three.Tag.ToString() != "?" && BT_Number_Three.Tag.ToString() == BT_Number_Five.Tag.ToString() &&
                  BT_Number_Three.Tag.ToString() == BT_Number_Seven.Tag.ToString())
                return true;

            return false;

        }

        public void Check_Turn_To_Desebel_Button()
        {
            if (Continuous_Boxes())
            {
                BT_Number_One.Enabled = false; BT_Number_Two.Enabled = false; BT_Number_Three.Enabled = false;
                BT_Number_Four.Enabled = false; BT_Number_Five.Enabled = false; BT_Number_Sixe.Enabled = false;
                BT_Number_Seven.Enabled = false; BT_Number_Eight.Enabled = false; BT_Number_Nine.Enabled = false;
                ST.Check = true;
            }

            else if (!Continuous_Boxes())
            {
                Draw_Game(ST.Number_Turn);
                ST.Check = false;
            }

            Who_Is_The_Winner();
        }

        public void Who_Is_The_Winner()
        {
            if (ST.Turn == ST.Player_Tow && ST.Check == true)
            {
                LB_Winner.Text = "Player 1";
                ST.Number_of_winning_games_X++;
                Player_Number_One.Text = ST.Number_of_winning_games_X + "       :-)";
            }

            else if (ST.Turn == ST.Player_One && ST.Check == true)
            {
                LB_Winner.Text = "Player 2";
                ST.Number_of_winning_games_O++;
                Player_Number_Tow.Text = ST.Number_of_winning_games_O + "       :-)";
            }


        }

        private void BT_Number_One_Click(object sender, EventArgs e)
        {
            Button btn = (Button)BT_Number_One;
            Check_Turn_Player(btn);
        }

        private void BT_Number_Two_Click(object sender, EventArgs e)
        {
            Button btn = (Button)BT_Number_Two;
            Check_Turn_Player(btn);
        }

        private void BT_Number_Three_Click(object sender, EventArgs e)
        {
            Button btn = (Button)BT_Number_Three;
            Check_Turn_Player(btn);
        }

        private void BT_Number_Four_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Check_Turn_Player(btn);
        }

        private void BT_Number_Five_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Check_Turn_Player(btn);
        }

        private void BT_Number_Sixe_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Check_Turn_Player(btn);
        }

        private void BT_Number_Seven_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Check_Turn_Player(btn);
        }

        private void BT_Number_Eight_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Check_Turn_Player(btn);
        }

        private void BT_Number_Nine_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Check_Turn_Player(btn);
        }

        void Defult_BackImaage_Button_And_Defult_Tag()
        {
            BT_Number_One.Tag   = "?"; BT_Number_Two.Tag   = "?"; BT_Number_Three.Tag = "?";
            BT_Number_Four.Tag  = "?"; BT_Number_Five.Tag  = "?"; BT_Number_Sixe.Tag  = "?";
            BT_Number_Seven.Tag = "?"; BT_Number_Eight.Tag = "?"; BT_Number_Nine.Tag  = "?";

            BT_Number_One.BackgroundImage   = Resources.R__6_; BT_Number_Two.BackgroundImage   = Resources.R__6_; 
            BT_Number_Three.BackgroundImage = Resources.R__6_; BT_Number_Four.BackgroundImage  = Resources.R__6_;
            BT_Number_Five.BackgroundImage  = Resources.R__6_; BT_Number_Sixe.BackgroundImage  = Resources.R__6_;
            BT_Number_Seven.BackgroundImage = Resources.R__6_; BT_Number_Eight.BackgroundImage = Resources.R__6_;
            BT_Number_Nine.BackgroundImage  = Resources.R__6_;
        }

        private void BT_Restart_Game_Click(object sender, EventArgs e)
        {
            BT_Number_One.Enabled   = true; BT_Number_Two.Enabled   = true; BT_Number_Three.Enabled = true;
            BT_Number_Four.Enabled  = true; BT_Number_Five.Enabled  = true; BT_Number_Sixe.Enabled  = true;
            BT_Number_Seven.Enabled = true; BT_Number_Eight.Enabled = true; BT_Number_Nine.Enabled  = true;

            LB_Player.Text = "Player 1";
            LB_Winner.Text = "In Progress";
            ST.Number_Turn = 0;
            ST.Turn = ST.Player_One;
            Defult_BackImaage_Button_And_Defult_Tag();
            ST.Check = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ST.Number_Turn = 0;
            ST.Player_One = 1;
            ST.Player_Tow = 2;
            ST.Turn = ST.Player_One;
            ST.Number_of_winning_games_X = 0;
            ST.Number_of_winning_games_O = 0;
        }
    }
}