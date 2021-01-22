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
    public partial class Form2 : Form
    {

        const int UP    = 1;
        const int DOWN  = 2;
        const int LEFT  = 3;
        const int RIGHT = 4;
        const int STOP  = 0;

        const int HERO_AMOUNT  = 2;
        const int ENEMY_AMOUNT = 1;

        int heroDirection = STOP;
        int enemyDirection = STOP;



        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Let's begin!");
            tmrGame.Interval = 10;
            tmrGame.Enabled = true;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if      (e.KeyCode == Keys.Up)    heroDirection = UP;
            else if (e.KeyCode == Keys.Down)  heroDirection = DOWN;
            else if (e.KeyCode == Keys.Left)  heroDirection = LEFT;
            else if (e.KeyCode == Keys.Right) heroDirection = RIGHT;
            else                              heroDirection = STOP;
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            if      (heroDirection == UP)    picHero.Top  = picHero.Top  - HERO_AMOUNT;
            else if (heroDirection == DOWN)  picHero.Top  = picHero.Top  + HERO_AMOUNT;
            else if (heroDirection == LEFT)  picHero.Left = picHero.Left - HERO_AMOUNT;
            else if (heroDirection == RIGHT) picHero.Left = picHero.Left + HERO_AMOUNT;
        }
    }
}
