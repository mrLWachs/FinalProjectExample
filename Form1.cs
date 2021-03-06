﻿using System;
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

        // global variables

        const int UP = 1;
        const int DOWN = 2;
        const int LEFT = 3;
        const int RIGHT = 4;
        const int STOP = 0;
        const int HERO_AMOUNT = 3;
        const int ENEMY_AMOUNT = 1;
        const int GAME_DELAY = 1;

        int heroDirection = STOP;
        int enemyDirection = STOP;

        // Put all the walls into a "list" 
        // called an array

        // NOTE: every time I add a wall with the designer,
        // change this number!
        const int TOTAL_WALLS = 11;

        PictureBox[] walls = new PictureBox[TOTAL_WALLS];

        Random random = new Random();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // the code that runs when the form first appears

            // NOTE: if you add a wall with the 
            // designer, change the code below:

            walls[0] = pictureBox1;
            walls[1] = pictureBox2;
            walls[2] = pictureBox3;
            walls[3] = pictureBox4;
            walls[4] = pictureBox5;
            walls[5] = pictureBox11;
            walls[6] = pictureBox7;
            walls[7] = pictureBox8;
            walls[8] = pictureBox9;
            walls[9] = pictureBox10;
            walls[10] = pictureBox6;


            // Start the enemy in a random direction
            enemyDirection = random.Next(1, 5);

            // now show the form
            MessageBox.Show("Let's begin!");
            tmrGame.Interval = GAME_DELAY;
            tmrGame.Enabled = true;
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            // Move the hero.................................................
            // the code that runs every 100 miliseconds
            // 1 tenth of a second like a loop (over and over)
            if (heroDirection == UP) picHero.Top = picHero.Top - HERO_AMOUNT;
            else if (heroDirection == DOWN) picHero.Top = picHero.Top + HERO_AMOUNT;
            else if (heroDirection == LEFT) picHero.Left = picHero.Left - HERO_AMOUNT;
            else if (heroDirection == RIGHT) picHero.Left = picHero.Left + HERO_AMOUNT;

            // Move the enemy.................................................
            if (enemyDirection == UP) picEnemy.Top = picEnemy.Top - ENEMY_AMOUNT;
            else if (enemyDirection == DOWN) picEnemy.Top = picEnemy.Top + ENEMY_AMOUNT;
            else if (enemyDirection == LEFT) picEnemy.Left = picEnemy.Left - ENEMY_AMOUNT;
            else if (enemyDirection == RIGHT) picEnemy.Left = picEnemy.Left + ENEMY_AMOUNT;


            // check if I won...................................................
            if (picHero.Bounds.IntersectsWith(picObjective.Bounds))
            {
                tmrGame.Enabled = false;
                MessageBox.Show("You win!");
            }

            // check if I lose........................................
            if (picHero.Bounds.IntersectsWith(picEnemy.Bounds))
            {
                tmrGame.Enabled = false;
                MessageBox.Show("You lose!");
            }



            // check for walls...............................................
            for (int i = 0; i < TOTAL_WALLS; i++)
            {
                // get a wall from the array
                PictureBox wall = walls[i];

                // check hero for collision
                if (picHero.Bounds.IntersectsWith(wall.Bounds))
                {
                    // the hero just hit a wall, stop                    
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

                // check for enemy collision
                if (picEnemy.Bounds.IntersectsWith(wall.Bounds))
                {
                    // the enemy just hit a wall, stop
                    if (enemyDirection == UP)
                    {
                        picEnemy.Top = wall.Top + wall.Height + 1;
                    }
                    else if (enemyDirection == DOWN)
                    {
                        picEnemy.Top = wall.Top - picEnemy.Height - 1;
                    }
                    else if (enemyDirection == LEFT)
                    {
                        picEnemy.Left = wall.Left + wall.Width + 1;
                    }
                    else if (enemyDirection == RIGHT)
                    {
                        picEnemy.Left = wall.Left - picEnemy.Width - 1;
                    }
                    // now send the enemy a random direction
                    enemyDirection = random.Next(1, 5);
                }

            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // the code that runs when when the user press a key
            if (e.KeyCode == Keys.Up) heroDirection = UP;
            else if (e.KeyCode == Keys.Down) heroDirection = DOWN;
            else if (e.KeyCode == Keys.Left) heroDirection = LEFT;
            else if (e.KeyCode == Keys.Right) heroDirection = RIGHT;
            else heroDirection = STOP;
        }
    }
}
