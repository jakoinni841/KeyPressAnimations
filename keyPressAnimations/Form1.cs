using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.Media;

/* Created by Jakob Innis and Blake Bos
 * December, 24, 2016
 * Game animation for Programming class
 * "The Mansion"
 * done
 */

namespace keyPressAnimations
{
    public partial class Form1 : Form
    {

        #region Sounds

        SoundPlayer startMusic = new SoundPlayer(keyPressAnimations.Properties.Resources.creepyFirst);
        SoundPlayer startButtonPress = new SoundPlayer(keyPressAnimations.Properties.Resources.creepySecond);
        SoundPlayer carDoor = new SoundPlayer(keyPressAnimations.Properties.Resources.carDoorSlam);

        #endregion

        #region Rectangles(Hit Boxes)

        Rectangle heroRec, villainRec, door0Rec, door1Rec, door2Rec, door3Rec, carRec1, carRec2, carRec3, chairTableRec;
        Rectangle storageRoomDoor, lockedDoor1, chestRoom3, chestRoom5, doorFinalRoom, doorFinalBack, mansionDoor;
        #endregion

        #region Characters and Objects
        //starting values for Hero character
        int xHero = -100;
        int yHero = -100;
        int speedHero = 2;
        int widthHero = 40;
        int heightHero = 60;

        //starting values for villain character
        int heightVillain = 45;
        int widthVillain = 40;
        int speedVillain = 1;
        int xVillain = -100;
        int yVillain = -100;

        //Variables
        int position = 0;
        int room = 0;

        //Images
        Image characterImage = Properties.Resources.Character_Back;
        Image closedChest = Properties.Resources.Closed_Chest;
        Image closedChest2 = Properties.Resources.Closed_Chest;
        Image mainkey = Properties.Resources.mainKey;
        Image mansionkey = Properties.Resources.mainKey;
        Image villainImage = Properties.Resources.boi_krampus;
        Image gascan = Properties.Resources.gascan;

        //keys
        int mainKey = 0;
        int mansionKey = 0;
        int gasCan = 0;

        #endregion

        #region Booleans and Graphics
        //determines whether a key is being pressed or not
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;
        Boolean Gameover, Endgame;
        //create graphic objects
        SolidBrush drawWhite = new SolidBrush(Color.White);
        //Fonts
        Font textFont = new Font("Poplar Std", 16);

        #endregion

        private void restartButton_Click(object sender, EventArgs e)
        {
            //Reset everything
            #region Characters and Objects
            //starting values for Hero character
            xHero = 27;
            yHero = 279;
            speedHero = 2;
            widthHero = 40;
            heightHero = 60;

            //starting values for villain character
            heightVillain = 45;
            widthVillain = 40;
            speedVillain = 1;
            xVillain = -100;
            yVillain = -100;

            //Variables
            position = 0;
            room = 0;

            //Images
            characterImage = Properties.Resources.Character_Back;
            closedChest = Properties.Resources.Closed_Chest;
            closedChest2 = Properties.Resources.Closed_Chest;
            mainkey = Properties.Resources.mainKey;
            villainImage = Properties.Resources.boi_krampus;

            //keys
            mainKey = 0;
            mansionKey = 0;

            #endregion

            startButton.Visible = true;
            restartButton.Visible = false;
            title1.Visible = true;
            title2.Visible = true;
            this.BackgroundImage = Properties.Resources.mansionTitleScreen;

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //Music stop and start
            startMusic.Stop();
            startButtonPress.Play();
            //Create Graphics for text
            Graphics fg;
            fg = this.CreateGraphics();

            //Labels Visibility
            title1.Visible = false;
            title2.Visible = false;
            startButton.Visible = false;
            quitButton.Visible = false;

            //Make background black
            this.BackgroundImage = null;
            Refresh();

            //Run start text
            #region Start Text
            fg.DrawString("Your", textFont, drawWhite, 10, 10);
            Thread.Sleep(300);
            fg.DrawString("car", textFont, drawWhite, 65, 10);
            Thread.Sleep(300);
            fg.DrawString("runs", textFont, drawWhite, 110, 10);
            Thread.Sleep(300);
            fg.DrawString("out", textFont, drawWhite, 170, 10);
            Thread.Sleep(500);
            fg.DrawString("of", textFont, drawWhite, 215, 10);
            Thread.Sleep(300);
            fg.DrawString("gas", textFont, drawWhite, 250, 10);
            Thread.Sleep(300);
            fg.DrawString("beside", textFont, drawWhite, 295, 10);
            Thread.Sleep(300);
            fg.DrawString("a", textFont, drawWhite, 370, 10);
            Thread.Sleep(300);
            fg.DrawString("huge", textFont, drawWhite, 390, 10);
            Thread.Sleep(300);
            fg.DrawString("mansion.", textFont, drawWhite, 10, 30);
            Thread.Sleep(300);
            fg.DrawString("You", textFont, drawWhite, 110, 30);
            Thread.Sleep(300);
            fg.DrawString("decide", textFont, drawWhite, 165, 30);
            Thread.Sleep(300);
            fg.DrawString("to", textFont, drawWhite, 245, 30);
            Thread.Sleep(300);
            fg.DrawString("go", textFont, drawWhite, 270, 30);
            Thread.Sleep(300);
            fg.DrawString("looking", textFont, drawWhite, 300, 30);
            Thread.Sleep(300);
            fg.DrawString("for", textFont, drawWhite, 380, 30);
            Thread.Sleep(300);
            fg.DrawString("help", textFont, drawWhite, 10, 50);
            Thread.Sleep(300);
            fg.DrawString("in ", textFont, drawWhite, 65, 50);
            Thread.Sleep(300);
            fg.DrawString("the", textFont, drawWhite, 90, 50);
            Thread.Sleep(300);
            fg.DrawString("old", textFont, drawWhite, 130, 50);
            Thread.Sleep(300);
            fg.DrawString("building...", textFont, drawWhite, 165, 50);
            Thread.Sleep(300);
            #endregion

            //Sleep and set heroes coordinates + set background
            carDoor.Play();
            Thread.Sleep(3000);
            xHero = 35;
            yHero = 240;
            this.BackgroundImage = Properties.Resources.First_Scene;

            //Start Timer
            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //Exits game
            Application.Exit();
        }

        public Form1()
        {
            InitializeComponent();
            startMusic.Play();
            restartButton.Visible = false;
            if(room == 4)
            {
                xVillain = 198;
                yVillain = 102;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Movement with keys (Keys Down)
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Movement with keys(Keys Up)
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Basic functions of the game

            #region Main Character Movement
            //hero movement
            if (leftArrowDown == true)
            {
                xHero = xHero - speedHero; 
            }

            if (downArrowDown == true)
            {
                yHero = yHero + speedHero;
            }

            if (rightArrowDown == true)
            {
                xHero = xHero + speedHero;
            }

            if (upArrowDown == true)
            {
                yHero = yHero - speedHero;
            }
         
            //Hero Positions
            if (leftArrowDown == true)
            {
                position = 1;
            }

            if (rightArrowDown == true)
            {
                position = 2;
            }

            if (upArrowDown == true)
            {
                position = 3;
            }

            if (downArrowDown == true)
            {
                position = 4;
            }
            //Change hero picture
            if(position == 1)
            {
                characterImage = Properties.Resources.Character_Left;
            }
            if (position == 2)
            {
                characterImage = Properties.Resources.Character_Right;
            }
            if (position == 3)
            {
                characterImage = Properties.Resources.Character_Back;
            }
            if (position == 4)
            {
                characterImage = Properties.Resources.Character_Front;
            }

            //Villain movement
            if (room == 4)
            {
                if (xVillain < xHero)
                {
                    xVillain = xVillain + speedVillain;
                }

                if (yVillain < yHero)
                {
                    yVillain = yVillain + speedVillain;
                }

                if (xVillain > xHero)
                {
                    xVillain = xVillain - speedVillain;
                }

                if (yVillain > yHero)
                {
                    yVillain = yVillain - speedVillain;
                }
            }

            #endregion

            //Room 0(Outfront of mansion)

            #region Car
            carRec1 = new Rectangle(10, 315, 40, 15);
            carRec2 = new Rectangle(50, 300, 70, 30);
            carRec3 = new Rectangle(120, 315, 35, 15);
            if (heroRec.IntersectsWith(carRec1) && room == 0)
            {
                yHero = yHero - speedHero;
                if (xHero > 10)
                {
                    xHero = xHero - speedHero;
                }
            }

            if (heroRec.IntersectsWith(carRec2) && room == 0)
            {
                yHero = yHero - speedHero;
            }

            if (heroRec.IntersectsWith(carRec3) && room == 0)
            {
                yHero = yHero - speedHero;
                if(xHero < 155)
                {
                    xHero = xHero + speedHero;
                }
            }
            #endregion

            #region Walls-Room 0
            if (room == 0)
            {
                if (xHero < -10)
                {
                    xHero = xHero + speedHero;
                }

                if (xHero > 420)
                {
                    xHero = xHero - speedHero;
                }

                if (yHero > 320)
                {
                    yHero = yHero - speedHero;
                }

                if (yHero < -30)
                {
                    yHero = yHero + speedHero;
                }
            }
            #endregion

            #region Door-Room 0

            Graphics fg;
            fg = this.CreateGraphics();
            door0Rec = new Rectangle(200, -15, 50, 5);
            heroRec = new Rectangle(xHero, yHero, widthHero, heightHero);

            if (room == 0)
            {
                if (heroRec.IntersectsWith(door0Rec))
                {
                    //Set room
                    room = 1;
                    //Change character and room backgrounds
                    characterImage = Properties.Resources.Character_Back;
                    this.BackgroundImage = Properties.Resources.Second_Scene;
                    //Set heroes place
                    yHero = 265;
                    xHero = 206;
                    Thread.Sleep(500);
                    Refresh();
                }

                if (heroRec.IntersectsWith(door0Rec))
                {
                    fg.DrawString("The door locks behind you", textFont, drawWhite, 50, 200);
                    Thread.Sleep(3000);
                }

            }
            #endregion

            //Room 1(Main Part of mansion)

            #region Walls-Room 1
            if (room == 1)
            {
                if (xHero < 17)
                {
                    xHero = xHero + speedHero;
                }

                if (xHero > 390)
                {
                    xHero = xHero - speedHero;
                }

                if (yHero > 268)
                {
                    yHero = yHero - speedHero;
                }

                if (yHero < 17)
                {
                    yHero = yHero + speedHero;
                }
            }
            #endregion

            #region Door-Room 1

            fg = this.CreateGraphics();
            door1Rec = new Rectangle(428, 155, 1, 27);
            heroRec = new Rectangle(xHero, yHero, widthHero, heightHero);
            lockedDoor1 = new Rectangle(224, 26, 4, 4);
            mansionDoor = new Rectangle(224, 323, 1, 1);

            //Going to right side of mansion
            if (room == 1)
            {
                if (heroRec.IntersectsWith(door1Rec))
                {
                    //Set room
                    room = 2;
                    //Change character and room backgrounds
                    characterImage = Properties.Resources.Character_Right;
                    this.BackgroundImage = Properties.Resources.Third_Scene;
                    //Set heroes place
                    yHero = 146;
                    xHero = 31;
                }

                if (mansionKey == 1)
                {
                    if (heroRec.IntersectsWith(mansionDoor))
                    {
                        room = 6;
                        characterImage = Properties.Resources.Character_Front;
                        this.BackgroundImage = Properties.Resources.Room_6;
                        yHero = 20;
                        xHero = 200;
                    }
                }
            }

            //To get to left side of mansion
            /*door3Rec = new Rectangle(25, 169, 1, 2);
            heroRec = new Rectangle(xHero, yHero, widthHero, heightHero);
            if(room == 1)
            {
                if(heroRec.IntersectsWith(door3Rec))
                {
                    room = 8;
                    BackgroundImage = null;
                    characterImage = Properties.Resources.Character_Left;
                    xHero = 350;
                    yHero = 100;

                }
            }
            */

            //Going to top of mansion(locked door)
            if (heroRec.IntersectsWith(lockedDoor1) && mainKey == 0 && room == 1)
            {
                fg.DrawString("The door is locked", textFont, drawWhite, 200, 50);
                Thread.Sleep(1500);
                Refresh();
                yHero = 30;
            }
            if (room == 1 && mainKey == 1)
            {
                if (heroRec.IntersectsWith(lockedDoor1))
                {
                    //Set room
                    room = 4;
                    //Change character and room backgrounds
                    characterImage = Properties.Resources.Character_Back;
                    this.BackgroundImage = Properties.Resources.Fifth_Scene;
                    //Set heroes place
                    yHero = 245;
                    xHero = 205;
                    xVillain = 1000;
                    yVillain = 1000;
                    speedVillain = 1;
                }
            }

            #endregion

            //Room 2(Right side of mansion)

            #region Table And Chairs
            #endregion

            #region Walls-Room 2
            if (room == 2)
            {
                if (xHero < 17)
                {
                    xHero = xHero + speedHero;
                }

                if (xHero > 390)
                {
                    xHero = xHero - speedHero;
                }

                if (yHero > 268)
                {
                    yHero = yHero - speedHero;
                }

                if (yHero < 17)
                {
                    yHero = yHero + speedHero;
                }
            }
            #endregion

            #region Door-Room 2

            //Getting back to last room
            if (room == 2)
            {
                door1Rec = new Rectangle(25, 155, 1, 27);
                storageRoomDoor = new Rectangle(216, 20, 20, 3);
                if (heroRec.IntersectsWith(door1Rec))
                {
                    //Set room
                    room = 1;
                    //Change character and room backgrounds
                    characterImage = Properties.Resources.Character_Left;
                    this.BackgroundImage = Properties.Resources.Second_Scene;
                    //Set heroes place
                    yHero = 146;
                    xHero = 388;
                }
                //Getting to storage room 
                if (heroRec.IntersectsWith(storageRoomDoor))
                {
                    //Set room
                    room = 3;
                    //Change character and backgrounds
                    characterImage = Properties.Resources.Character_Back;
                    this.BackgroundImage = Properties.Resources.Fourth_Scene;
                    //set heroes place
                    yHero = 250;
                    xHero = 98;
                }
            }
            #endregion

            //Room 3(Storage Room)

            #region Walls-Room 3
            if (room == 3)
            {
                if (xHero < 17)
                {
                    xHero = xHero + speedHero;
                }

                if (xHero > 390)
                {
                    xHero = xHero - speedHero;
                }

                if (yHero > 268)
                {
                    yHero = yHero - speedHero;
                }

                if (yHero < 17)
                {
                    yHero = yHero + speedHero;
                }
            }
            #endregion

            #region Door-Room 3
            storageRoomDoor = new Rectangle(124, 324, 1, 1);
            if (room == 3)
            {
                if (heroRec.IntersectsWith(storageRoomDoor))
                {
                    //Set room
                    room = 2;
                    //Change character and backgrounds
                    characterImage = Properties.Resources.Character_Front;
                    this.BackgroundImage = Properties.Resources.Third_Scene;
                    //set heroes place
                    yHero = 21;
                    xHero = 205;
                }
            }
            #endregion

            #region Chest

            Rectangle chestRoom3 = new Rectangle(300, 80, 30, 30);
            if (room == 3)
            {
                if (heroRec.IntersectsWith(chestRoom3))
                {
                    mainKey = 1;
                    closedChest = Properties.Resources.Open_Chest;
                }
            }
            #endregion

            //Room 4(Bad Guy Room)

            #region Walls-Room 4
            if (room == 4)
            {
                if (xHero < 17)
                {
                    xHero = xHero + speedHero;
                }

                if (xHero > 390)
                {
                    xHero = xHero - speedHero;
                }

                if (yHero > 268)
                {
                    yHero = yHero - speedHero;
                }

                if (yHero < 17)
                {
                    yHero = yHero + speedHero;
                }
            }
            #endregion

            #region Door-Room 4
            door2Rec = new Rectangle(228, 321, 1, 1);
            doorFinalRoom = new Rectangle(226, 26, 1, 1);
            villainRec = new Rectangle(xVillain, yVillain, widthVillain, heightVillain);

            if (room == 4)
            {
                if (heroRec.IntersectsWith(door2Rec))
                {
                    //set room
                    room = 1;
                    characterImage = Properties.Resources.Character_Front;
                    this.BackgroundImage = Properties.Resources.Second_Scene;
                    //Set heroes place
                    yHero = 40;
                    xHero = 205;

                    speedVillain = 0;

                }
            }

            if (room == 4)
            {
                if (heroRec.IntersectsWith(doorFinalRoom))
                {
                    room = 5;
                    characterImage = Properties.Resources.Character_Back;
                    this.BackgroundImage = Properties.Resources.Last_Room;
                    yHero = 240;
                    xHero = 125;
                }
            }
            if(heroRec.IntersectsWith(villainRec))
            {
                Gameover = true;
            }

            #endregion

            //Final Room

            #region Walls-Final Room
            if (room == 5)
            {
                if (xHero < 99)
                {
                    xHero = xHero + speedHero;
                }
                if (xHero > 353 - widthHero)
                {
                    xHero = xHero - speedHero;
                }
                if (yHero < 87 - heightHero)
                {
                    yHero = yHero + speedHero;
                }
                if (yHero > 328 - heightHero)
                {
                    yHero = yHero - speedHero;
                }
            }
            #endregion

            #region Door-Final Room
            doorFinalBack = new Rectangle(143, 315, 2, 2);
            if (room == 5)
            {
                if (heroRec.IntersectsWith(doorFinalBack))
                {
                    //set room
                    room = 4;
                    characterImage = Properties.Resources.Character_Front;
                    this.BackgroundImage = Properties.Resources.Fifth_Scene;
                    //Set heroes place
                    yHero = 35;
                    xHero = 215;

                }
            }
            #endregion

            #region Chest
            chestRoom3 = new Rectangle(220, 98, 30, 30);
            if (room == 5)
            {
                if (heroRec.IntersectsWith(chestRoom3))
                {
                    gasCan = 1;
                    mansionKey = 1;
                    closedChest2 = Properties.Resources.Open_Chest;
                }
            }
            #endregion

            //Room 6

            #region Walls-Room 6
            if (room == 6)
            {
                if (xHero < -10)
                {
                    xHero = xHero + speedHero;
                }

                if (xHero > 420)
                {
                    xHero = xHero - speedHero;
                }

                if (yHero > 320)
                {
                    yHero = yHero - speedHero;
                }

                if (yHero < -30)
                {
                    yHero = yHero + speedHero;
                }
            }
            #endregion

            #region Escape
            if (room == 6)
            {
                if (heroRec.IntersectsWith(carRec2))
                    if (gasCan == 1)
                    {
                        {
                            Endgame = true;
                        }
                    }
            }
            #endregion

            //Refresh to run Paint method
            Refresh();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw characters to screen
            e.Graphics.DrawImage(characterImage, xHero, yHero, widthHero, heightHero);

            if(gasCan == 1)
            {
                e.Graphics.DrawImage(gascan, 240, 320, 40, 35);
            }

            if(mansionKey == 1)
            {
                e.Graphics.DrawImage(mansionkey, 300, 320, 40, 35);
            }

            if(mainKey == 1)
            {
                e.Graphics.DrawImage(mainkey, 360, 320, 40, 35);
            }

            if (room == 3)
            {
                e.Graphics.DrawImage(closedChest, 300, 80, 40, 40);
            }

            if (room == 5)
            {
                e.Graphics.DrawImage(closedChest2, 220, 98, 40, 40);
            }

            if (room == 4)
            {
                e.Graphics.DrawImage(villainImage, xVillain, yVillain, widthVillain, heightVillain);
            }

            if (Gameover == true)
            {
                restartButton.Visible = true;
                quitButton.Visible = true;
            }

            if (Endgame == true)
            {
                this.BackgroundImage = null;
                #region End Text
                e.Graphics.DrawString("You", textFont, drawWhite, 10, 10);
                Thread.Sleep(300);
                e.Graphics.DrawString("Escaped!!", textFont, drawWhite, 65, 10);
                Thread.Sleep(300);
                #endregion
                quitButton.Visible = true;
            }

        }
    }
}
