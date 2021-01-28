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

        // Put all the walls (pictureboxes)
        // into a "list" (called a array)
        // part of CS30S

        // NOTE: every time I decide to
        // add a wall with the designer
        // need to change this code!

        const int TOTAL_WALLS = 13;

        PictureBox[] walls = new PictureBox[TOTAL_WALLS];


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Add the wall pictureboxes into the array ("list")

            // NOTE: every time I decide to
            // add a wall with the designer
            // need to change this code!

            walls[0] = pictureBox1;
            walls[1] = pictureBox10;
            walls[2] = pictureBox11;
            walls[3] = pictureBox12;
            walls[4] = pictureBox13;
            walls[5] = pictureBox2;
            walls[6] = pictureBox3;
            walls[7] = pictureBox4;
            walls[8] = pictureBox5;
            walls[9] = pictureBox6;
            walls[10] = pictureBox7;
            walls[11] = pictureBox8;
            walls[12] = pictureBox9;

            // Start the enemy in a random direction
            Random random = new Random();
            enemyDirection = random.Next(1, 5);

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
            // To move the hero
            if      (heroDirection == UP)    picHero.Top  = picHero.Top  - HERO_AMOUNT;
            else if (heroDirection == DOWN)  picHero.Top  = picHero.Top  + HERO_AMOUNT;
            else if (heroDirection == LEFT)  picHero.Left = picHero.Left - HERO_AMOUNT;
            else if (heroDirection == RIGHT) picHero.Left = picHero.Left + HERO_AMOUNT;

            // To move the enemy
            if (enemyDirection == UP) picEnemy.Top = picEnemy.Top - ENEMY_AMOUNT;
            else if (enemyDirection == DOWN) picEnemy.Top = picEnemy.Top + ENEMY_AMOUNT;
            else if (enemyDirection == LEFT) picEnemy.Left = picEnemy.Left - ENEMY_AMOUNT;
            else if (enemyDirection == RIGHT) picEnemy.Left = picEnemy.Left + ENEMY_AMOUNT;


            // check for objective
            if (picHero.Bounds.IntersectsWith(picObjective.Bounds))
            {
                tmrGame.Enabled = false;
                MessageBox.Show("You win!");
            }


            // check for walls
            for (int i = 0; i < TOTAL_WALLS; i++)
            {
                // get a wall out of the array
                PictureBox wall = walls[i];
                // check for collison
                if (picHero.Bounds.IntersectsWith(wall.Bounds))
                {
                    // Check direction and react
                    if (heroDirection == UP)
                    {
                        picHero.Top = wall.Top + wall.Height + 1;
                    }
                    else if (heroDirection == DOWN)
                    {
                        picHero.Top = wall.Top - picHero.Height - 1;
                    }
                    else if (heroDirection == LEFT)
                    {
                        picHero.Left = wall.Left + wall.Width + 1;
                    }
                    else if (heroDirection == RIGHT)
                    {
                        picHero.Left = wall.Left - picHero.Width - 1;
                    }
                }
            }



        }
    }
}
