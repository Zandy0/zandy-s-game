using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewGame.Entities;
using NewGame.Fishing;
using NewGame.Positions;

namespace NewGame
{
    public partial class Game : Form
    {
        public Bitmap[] sheets = new Bitmap[3] {
            Resource1.palm,
            Resource1.mario,
            Resource1.gameOver
        };
        public Player player;
        public Entity palm1, palm2;
        public InterfaceElement secondHelpE, chars, firstHelpE, gmOver, shop;
        public StartFishing br;

        public Entity nps;

        public Game()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            movingTimer.Interval = 50;
            movingTimer.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);
            Init();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (!player.isFishing)
            {
                player.SetConfiguration(120, false, 0, 0, 4, 500, false);
                player.sizeX = 120;
            }         
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (!player.isFishing & !player.isTalking)
                        player.SetConfiguration(120, false, -15, 0, 2, 100, true);
                    break;
                case Keys.D:
                    if (!player.isFishing & !player.isTalking)
                        player.SetConfiguration(120, false, 15, 0, 1, 100, true);
                    break;
                case Keys.E:
                    if (player.posX >= 830 && player.strengthOfRod > 0)
                    {
                        player.SetConfiguration(170, true, 0, 1, 5, 200, false);
                        br.fill = 0.6;
                    }
                    else if (player.posX >= nps.posX - 20 && player.posX <= nps.posX + 20)
                        player.isTalking = !player.isTalking;
                    break;
                case Keys.H:
                    if (player.isFishing &&
                        (chars.isCathed(br.posX, br.posY, 0)))
                        br.ProgressIsReached(true);
                    else if (player.isFishing) br.ProgressIsReached(false);
                    break;
                case Keys.J:
                    if (player.isFishing && (chars.isCathed(br.posX, br.posY, 1)))
                        br.ProgressIsReached(true);
                    else if (player.isFishing) br.ProgressIsReached(false);
                    break;
                case Keys.K:
                    if (player.isFishing &&
                        (chars.isCathed(br.posX, br.posY, 2)))
                        br.ProgressIsReached(true);
                    else if (player.isFishing) br.ProgressIsReached(false);
                    break;
                case Keys.P:
                    player.countOffishes += 5;
                    break;
                case Keys.Escape:
                    foreach (Form win in Application.OpenForms)
                    {
                        if (win.Name.ToString() == "Menu")
                            win.Show();
                        this.Hide();
                    }
                    break;
            }
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            if ((x >= shop.posX + 40 & x <= shop.posX + 210 & y >= shop.posY + 60 & y <= shop.posY + 90) & (player.countOfMoney - 7 >= 0) & player.isTalking)
            {
                player.strengthOfRod++;
                player.countOfMoney -= 7;
            }
            else if ((x >= shop.posX + 40 & x <= shop.posX + 210 & y >= shop.posY + 110 & y <= shop.posY + 140) & (player.countOfMoney - 15 >= 0 & br.speed > 0.001) & player.isTalking)
            {
                br.speed -= 0.00005;
                player.countOfMoney -= 15;
            }
            else if ((x >= shop.posX + 40 & x <= shop.posX + 210 & y >= shop.posY + 150 & y <= shop.posY + 180) & player.isTalking)
            {
                player.countOffishes = 0;
                player.countOfMoney = int.Parse(fish.Text) * 3 + int.Parse(money.Text);
            }
        }

        public void Update(object sender, EventArgs e)
        {
            if (player.isMoving)
                player.Move();

            if (player.isFishing)
            {
                br.CursorMove();
                br.BarDecrease();
                if (br.fill >= 1)
                {
                    player.countOffishes++;
                    br.fill = 0.6;
                }
                else if (br.fill <= 0)
                {
                    br.fill = 0.6;
                    player.strengthOfRod--;
                    if (player.strengthOfRod == 0)
                        player.isFishing = false;      
                }
            }
            fish.Text = player.countOffishes.ToString();
            strRod.Text = player.strengthOfRod.ToString();
            money.Text = player.countOfMoney.ToString();
            Invalidate();
        }

        public void Init()
        {
            nps = new Entity(240, 590, 6, sheets[1], 120, 120, 0, 0);
            chars = new InterfaceElement(1004, 604, 0);
            br = new StartFishing(0.005, 0.2, -0.3, 10);
            player = new Player(Position.startPosX, Position.startPosY, 120, 120, 4, 0);
            palm1 = new Entity(Position.palmPosX, Position.palmPosY, 6, sheets[0], 480, 480, 0, 0);
            palm2 = new Entity(Position.palmPosX + 350, Position.palmPosY, 6, sheets[0], 480, 480, 0, 3);
            secondHelpE = new InterfaceElement(Position.dialogPosX + 500, Position.dialogPosY, 3);
            firstHelpE = new InterfaceElement(Position.dialogPosX, Position.dialogPosY, 4);
            gmOver = new InterfaceElement(600, 70, 5);
            shop = new InterfaceElement(100, 90, 6);
            movingTimer.Start();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            if (player.countOfMoney + player.countOffishes * 3 < 7 && player.strengthOfRod == 0)
                gmOver.DrawChar(g);


            palm1.PlayAnimation1(g);
            palm2.PlayAnimation1(g);
            nps.PlayAnimation1(g);
            player.PlayAnimation1(g);

            if (player.isTalking)
                shop.DrawChar(g);
            if (player.PlayerCanInteract(nps.posX) == 0)
                firstHelpE.DrawChar(g);

            if (player.PlayerCanInteract(0) == 1)
                secondHelpE.DrawChar(g);
            else if (player.isFishing)
            {
                chars.DrawChar(g);
                br.PlayAnimation1(g);
            }
            
        }
    }
}
