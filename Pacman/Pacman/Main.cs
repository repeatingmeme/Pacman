using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Timers;

namespace Pacman
{
    public partial class Main : Form
    {
        // TODO: Code opschonen, LoseLife
        Graphics paper;
        SolidBrush color = new SolidBrush(Color.Black);
        int blokSize = 25;
        int score = 0;
        int lives = 3;
        int started = 0;
        int level = 1;
        int time = 10;
        bool Blue = false;
        Random rndAngle;
        Splash splash;
        Walls walls;
        Pacman pacman;
        Monster redGhost;
        Monster greenGhost;
        Monster yellowGhost;
        SoundPlayer sp;

        public Main()
        {
            InitializeComponent();
            paper = pctPlayField.CreateGraphics();
            walls = new Walls();
            rndAngle = new Random();
            splash = new Splash();
            #region initialize pacman & ghosts
            //pacman
            pacman = new Pacman();
            pacman.X = 10;
            pacman.Y = 12;
            pacman.Angle = 0;
            pacman.Wall = 0;
            pacman.PrevX = 10;
            pacman.PrevY = 12;
            pacman.Sprites = pacman.pacmanUp;

            //red ghost
            redGhost = new Monster();
            redGhost.X = 10;
            redGhost.Y = 10;
            redGhost.Angle = 3;
            redGhost.Wall = 0;
            redGhost.PrevX = 10;
            redGhost.PrevY = 10;
            redGhost.PrevAngle = 0;
            redGhost.Sprites = Image.FromFile("../../images/ghostRed.png");

            //green ghost
            greenGhost = new Monster();
            greenGhost.X = 11;
            greenGhost.Y = 10;
            greenGhost.Angle = 3;
            greenGhost.Wall = 0;
            greenGhost.PrevX = 11;
            greenGhost.PrevY = 10;
            greenGhost.PrevAngle = 0;
            greenGhost.Sprites = Image.FromFile("../../images/ghostGreen.png");

            //yellow ghost
            yellowGhost = new Monster();
            yellowGhost.X = 9;
            yellowGhost.Y = 10;
            yellowGhost.Angle = 3;
            yellowGhost.Wall = 0;
            yellowGhost.PrevX = 9;
            yellowGhost.PrevY = 10;
            yellowGhost.PrevAngle = 0;
            yellowGhost.Sprites = Image.FromFile("../../images/ghostYellow.png");
            #endregion
        }

        //Fix for Leftover Ghosts!
        public void drawField(int x, int y, int size, SolidBrush kleur, int img)
        {
            if (img == 1)
            {
                Image dot = Image.FromFile("../../images/dot.jpg");
                paper.DrawImage(dot, x, y, size, size);
            }

            else if (img == 2)
            {
                Image wall = Image.FromFile("../../images/wall.png");
                paper.DrawImage(wall, x, y, size, size);
            }

            else if (img == 3)
            {
                Image power = Image.FromFile("..//..//images//PowerDot.jpg");
                paper.DrawImage(power, x, y, size, size);
            }

            else
            { paper.FillRectangle(color, x, y, size, size); }

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (started == 1)
            {
                if (e.KeyData == Keys.Left)
                {
                    pacman.Angle = 1;
                    pacman.Sprites = pacman.pacmanLeft;
                    tmrStep.Enabled = true;
                }

                if (e.KeyData == Keys.Right)
                {
                    pacman.Angle = 2;
                    pacman.Sprites = pacman.pacmanRight;
                    tmrStep.Enabled = true;
                }

                if (e.KeyData == Keys.Up)
                {
                    pacman.Angle = 3;
                    pacman.Sprites = pacman.pacmanUp;
                    tmrStep.Enabled = true;
                }
                if (e.KeyData == Keys.Down)
                {
                    pacman.Angle = 4;
                    pacman.Sprites = pacman.pacmanDown;
                    tmrStep.Enabled = true;
                }

                if (e.KeyData == Keys.P)
                {
                    if (tmrStep.Enabled == true)
                    {
                        tmrStep.Enabled = false;

                        lblPause.Visible = true;
                    }
                    else
                    {
                        lblPause.Visible = false;
                        tmrStep.Enabled = true;
                        drawGrid();

                    }
                }
            }
        }

        private void tmrStep_Tick(object sender, EventArgs e)
        {
            getOldSteps();

            //keep current angle
            redGhost.PrevAngle = redGhost.Angle;
            greenGhost.PrevAngle = greenGhost.Angle;
            yellowGhost.PrevAngle = yellowGhost.Angle;

            //check for walls
            wallDetect(pacman.Angle, pacman.X, pacman.Y, ref pacman.Wall);
            wallDetect(greenGhost.Angle, greenGhost.X, greenGhost.Y, ref greenGhost.Wall);
            wallDetect(redGhost.Angle, redGhost.X, redGhost.Y, ref redGhost.Wall);
            wallDetect(yellowGhost.Angle, yellowGhost.X, yellowGhost.Y, ref yellowGhost.Wall);

            // wall test pacman
            if (pacman.Wall == 1)
            { label1.Text = "Wall " + pacman.X + " " + pacman.Y + " " + pacman.Angle; }
            else
            { moveSprite(pacman.Angle, ref pacman.X, ref  pacman.Y); }

            loseLife();
            //wall test ghosts
            while (redGhost.Wall == 1)
            {
                redGhost.Angle = rndAngle.Next(1, 5);
                wallDetect(redGhost.Angle, redGhost.X, redGhost.Y, ref redGhost.Wall);
            }

            while (greenGhost.Wall == 1)
            {
                greenGhost.Angle = rndAngle.Next(1, 5);
                wallDetect(greenGhost.Angle, greenGhost.X, greenGhost.Y, ref greenGhost.Wall);
            }

            while (yellowGhost.Wall == 1)
            {
                yellowGhost.Angle = rndAngle.Next(1, 5);
                wallDetect(yellowGhost.Angle, yellowGhost.X, yellowGhost.Y, ref yellowGhost.Wall);
            }
            
            if (Blue != true)
            {
                redGhost.Sprites = Image.FromFile("../../images/ghostRed.png");
                greenGhost.Sprites = Image.FromFile("../../images/ghostGreen.png");
                yellowGhost.Sprites = Image.FromFile("../../images/ghostYellow.png");

                moveSprite(redGhost.Angle, ref redGhost.X, ref redGhost.Y);
                moveSprite(greenGhost.Angle, ref greenGhost.X, ref greenGhost.Y);
                moveSprite(yellowGhost.Angle, ref yellowGhost.X, ref yellowGhost.Y);
            }
            else {
                time -= 1;
                switch (time) { 
                    case 2:
                        redGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                greenGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                yellowGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                break;
                    case 4:
                        redGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                greenGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                yellowGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                break;
                    case 6:
                        redGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                greenGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                yellowGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                break;
                    case 8:
                        redGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                greenGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                yellowGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                break;
                    case 10:
                        redGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                greenGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                yellowGhost.Sprites = Image.FromFile("../../images/ghostBlue.png");
                break;
                    default:
                        redGhost.Sprites = Image.FromFile("../../images/ghostWhite.png");
                greenGhost.Sprites = Image.FromFile("../../images/ghostWhite.png");
                yellowGhost.Sprites = Image.FromFile("../../images/ghostWhite.png");
                break;
                        
                }
                
                if (time == 0) {
                    Blue = false;
                    time = 10;
                }
            }
            eraseSteps(greenGhost.PrevX, greenGhost.PrevY);
            eraseSteps(redGhost.PrevX, redGhost.PrevY);
            eraseSteps(yellowGhost.PrevX, yellowGhost.PrevY);
            eraseSteps(pacman.PrevX, pacman.PrevY);

            drawSprites(pacman.X, pacman.Y, redGhost.X, redGhost.Y, greenGhost.X, greenGhost.Y, yellowGhost.X, yellowGhost.Y);
            loseLife();
            scoreCount();
            countDots();
        }
        private void moveSprite(int angle, ref int x, ref int y)
        {
            switch (angle)
            {

                case 1: //Left 
                    x -= 1;
                    break;
                case 2: //right
                    x += 1;
                    break;
                case 3: //up 
                    y -= 1;
                    break;
                case 4: //Down
                    y += 1;
                    break;
                default:
                    break;
            }

            if ((x == 19) && (y == 10))
            { x = 0; }
            else
            {
                if ((x == 0) && (y == 10))
                { x = 19; }
            }
        }

        private void drawGrid()
        {
            int xPos = 0;
            int yPos = 0;
            int row = 0;
            int col = 0;
            for (int i = 0; i < walls.Grid.Length; i++)
            {
                if (i % 20 == 0 && i != 0) // the row for more than 20 new row ...
                {
                    row += 1;
                    col = 0;
                }
                xPos = col * blokSize;
                yPos = row * blokSize;

                if (walls.Grid[row, col] == 0)
                {
                    color.Color = Color.White;
                    drawField(xPos, yPos, blokSize, color, 1);
                }
                else
                {
                    if (walls.Grid[row, col] == 1)
                    {
                        color.Color = Color.Blue;
                        drawField(xPos, yPos, blokSize, color, 2);
                    }
                    //TEST
                    else if (walls.Grid[row, col] == 3)
                    {
                        color.Color = Color.Blue;
                        drawField(xPos, yPos, blokSize, color, 3);
                    }

                    else
                    {
                        color.Color = Color.Black;
                        drawField(xPos, yPos, blokSize, color, 0);
                    }
                }
                col += 1;
            }
        }
        private void drawSprites(int pX, int pY, int grX, int grY, int ggX, int ggY, int gyX, int gyY)
        {
            pX = pX * blokSize;
            pY = pY * blokSize;
            grX = grX * blokSize;
            grY = grY * blokSize;
            ggX = ggX * blokSize;
            ggY = ggY * blokSize;
            gyX = gyX * blokSize;
            gyY = gyY * blokSize;
            //drawGrid();
            paper.DrawImage(pacman.Sprites, pX, pY, blokSize, blokSize);
            paper.DrawImage(redGhost.Sprites, grX, grY, blokSize, blokSize);
            paper.DrawImage(greenGhost.Sprites, ggX, ggY, blokSize, blokSize);
            paper.DrawImage(yellowGhost.Sprites, gyX, gyY, blokSize, blokSize);
        }

        private void wallDetect(int angle, int x, int y, ref int wall) // making a simulation of future step
        {
            switch (angle)
            {
                case 1: //Left
                    x -= 1;
                    break;
                case 2: //right
                    x += 1;
                    break;
                case 3: //up
                    y -= 1;
                    break;
                case 4: //Down
                    y += 1;
                    break;
                default:
                    break;
            }
            try
            {
                if (walls.Grid[y, x] == 1)
                { wall = 1; }
                else
                { wall = 0; }
            }
            catch (IndexOutOfRangeException ex)
            { }
        }

               private void scoreCount() // Addition and replace the value in the grid (score)
        {

            try
            {
                if (walls.Grid[pacman.Y, pacman.X] == 0)
                {
                    sp = new SoundPlayer("..//..//Sounds//pacman_chomp.wav");
                    //Old Score
                    //score += 5;
                    //New Score
                    score += 10;
                    lblScore.Text = Convert.ToString(score);
                    walls.Grid[pacman.Y, pacman.X] = 2;
                    sp.Play();
                }
                else if (walls.Grid[pacman.Y, pacman.X] == 3)
                {
                    sp = new SoundPlayer("..//..//Sounds//pacman_eatfruit.wav");
                    score += 1000004555;
                    lblScore.Text = Convert.ToString(score);
                    walls.Grid[pacman.Y, pacman.X] = 2;
                    sp.Play();
                   // blueGhosts();
                    Blue = true;
                }
            }
            catch (IndexOutOfRangeException ex)
            { }
        }

        //Death Sound!!!
        private void loseLife() // check if pacman is drawn in the same position as a spirit, if so, life lost
        {
            //Initialize Death Sound
            sp = new SoundPlayer("..//..//Sounds//pacman_death.wav");

            if ((pacman.X == redGhost.X) && (pacman.Y == redGhost.Y) || (pacman.X == greenGhost.X) && (pacman.Y == greenGhost.Y)
                || (pacman.X == yellowGhost.X) && (pacman.Y == yellowGhost.Y))
            {
                lives -= 1;
                sp.Play();
                Thread.Sleep(2000);
                //walls.Grid[pacman.Y, pacman.X] = 2;

                resetPlacement();
                //paper.Clear(Color.Black);
                //resetField();
                //Fixed Draw Grid, It will 
                

            }
            if (lives == 0)
            {
                level = 1;
                tmrStep.Enabled = false;
                MessageBox.Show("Your score is: " + score, "Game Over...");
                resetProgress();
                paper.Clear(Color.Black);
                resetField();
                //pacman.Sprites = pacman.pacmanLeft;
                //drawSprites(pacman.X, pacman.Y, redGhost.X, redGhost.Y, greenGhost.X, greenGhost.Y, yellowGhost.X, yellowGhost.Y);
            }
            lblLivesCount.Text = Convert.ToString(lives);
        }


        private void countDots() // counts the remaining dots for the game is played
        {
            int countDot = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (walls.Grid[i, j] == 0)
                    { countDot += 1; }
                }
            }
            if (countDot == 0)
            {
                tmrStep.Enabled = false;
                level += 1;
                resetField();
            }
        }

        private void resetProgress()
        {
            lives = 3;
            score = 0;
            lblLivesCount.Text = Convert.ToString(lives);
            lblScore.Text = Convert.ToString(score);

        }

        //resets the frield, but not the dots
        private void resetPlacement()
        {
            //setGrid();
            pacman.Angle = 1;
            pacman.X = 10;
            pacman.Y = 12;
            redGhost.X = 10;
            redGhost.Y = 10;
            redGhost.Angle = 3;
            greenGhost.Angle = 3;
            yellowGhost.Angle = 3;
            greenGhost.X = 11;
            greenGhost.Y = 10;
            yellowGhost.X = 9;
            yellowGhost.Y = 10;
            
            pacman.Sprites = pacman.pacmanLeft;
            drawSprites(pacman.X, pacman.Y, redGhost.X, redGhost.Y, greenGhost.X, greenGhost.Y, yellowGhost.X, yellowGhost.Y);
            drawGrid();
        }


        private void resetField()
        {
            setGrid();
            pacman.Angle = 1;
            pacman.X = 10;
            pacman.Y = 12;
            redGhost.X = 10;
            redGhost.Y = 10;
            redGhost.Angle = 3;
            greenGhost.Angle = 3;
            yellowGhost.Angle = 3;
            greenGhost.X = 11;
            greenGhost.Y = 10;
            yellowGhost.X = 9;
            yellowGhost.Y = 10;
            
            pacman.Sprites = pacman.pacmanLeft;

            drawSprites(pacman.X, pacman.Y, redGhost.X, redGhost.Y, greenGhost.X, greenGhost.Y, yellowGhost.X, yellowGhost.Y);
            drawGrid();
        }

        private void getOldSteps() // Replacing old with new position
        {
            pacman.PrevX = pacman.X;
            pacman.PrevY = pacman.Y;
            greenGhost.PrevX = greenGhost.X;
            greenGhost.PrevY = greenGhost.Y;
            redGhost.PrevX = redGhost.X;
            redGhost.PrevY = redGhost.Y;
            yellowGhost.PrevX = yellowGhost.X;
            yellowGhost.PrevY = yellowGhost.Y;
        }

        private void eraseSteps(int x, int y)
        {
            int z = x * blokSize;
            int q = y * blokSize;
            switch (walls.Grid[y, x])
            {
                case 0:
                    Image dot = Image.FromFile("../../images/dot.jpg");
                    paper.DrawImage(dot, z, q, blokSize, blokSize);
                    break;
                case 1:
                    Image wall = Image.FromFile("../../images/wall.png");
                    paper.DrawImage(wall, z, q, blokSize, blokSize);
                    break;

                case 2:
                    color = new SolidBrush(Color.Black);
                    paper.FillRectangle(color, z, q, blokSize, blokSize);
                    break;
                case 3:
                    Image powerdot = Image.FromFile("../../images/PowerDot.jpg");
                    paper.DrawImage(powerdot, z, q, blokSize, blokSize);
                    break;
                default:
                    break;
            }
        } // Last box is drawn back

        private void lblHelp_Click(object sender, EventArgs e)
        {
            Help frm = new Help();
            frm.ShowDialog();
        }  // End Help




        private void Main_Shown(object sender, EventArgs e) // Splash Screen will appear, Main is gehide
        {
            this.Hide();
            tmrSplash.Start();
            tmrSplash.Enabled = true;
            splash.Show();
        }

        private void tmrSplash_Tick_1(object sender, EventArgs e) // Splash Screen is gehide and Main emerges
        {
            splash.Close();
            this.Show();
            tmrSplash.Stop();
        }

        private void Main_Load(object sender, EventArgs e)
        { setGrid(); }

        private void lblStart_Click_1(object sender, EventArgs e) // Marking out the grid and objects
        {
            //start sound
            sp = new SoundPlayer("..//..//sounds//pacman_beginning.wav");
            //setGrid();
            //tmrStep.Enabled = true;

            tmrStep.Enabled = false;
            // drawGrid();
            resetField();
            resetProgress();
            pacman.Sprites = pacman.pacmanLeft;
            drawSprites(pacman.X, pacman.Y, redGhost.X, redGhost.Y, greenGhost.X, greenGhost.Y, yellowGhost.X, yellowGhost.Y);
            sp.Play();
            Thread.Sleep(4750);
            started = 1;



        }

        private void setGrid()
        {
            if (level % 2 == 0)
            {
                for (int x = 0; x < 20; x++)
                {
                    for (int y = 0; y < 20; y++)
                    { walls.Grid[x, y] = walls.Grid2[x, y]; }
                }
            }
            else
            {
                for (int x = 0; x < 20; x++)
                {
                    for (int y = 0; y < 20; y++)
                    { walls.Grid[x, y] = walls.Grid1[x, y]; }
                }
            }
        }




    }
}
