using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectExperience
{
    public partial class Form1 : Form
    {

        const int MOVE_LEFT  = 1;
        const int MOVE_RIGHT = 2;
        const int MOVE_UP    = 3;
        const int MOVE_DOWN  = 4;
        const int STOP       = 0;

        const int HERO_AMOUNT   = 1;
        const int HERO_INTERVAL = 1;

        int heroDirection = 0;
        int enemyDirection = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrGame.Interval = HERO_INTERVAL;
            tmrGame.Enabled = true;
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            if      (heroDirection == MOVE_UP)    picHero.Top  = picHero.Top  - HERO_AMOUNT;
            else if (heroDirection == MOVE_DOWN)  picHero.Top  = picHero.Top  + HERO_AMOUNT;
            else if (heroDirection == MOVE_LEFT)  picHero.Left = picHero.Left - HERO_AMOUNT;
            else if (heroDirection == MOVE_RIGHT) picHero.Left = picHero.Left + HERO_AMOUNT;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if      (e.KeyCode == Keys.Up)    heroDirection = MOVE_UP;
            else if (e.KeyCode == Keys.Down)  heroDirection = MOVE_DOWN;
            else if (e.KeyCode == Keys.Left)  heroDirection = MOVE_LEFT;
            else if (e.KeyCode == Keys.Right) heroDirection = MOVE_RIGHT;
            else                              heroDirection = STOP;
        }

        
    }
}
