using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewGame.Positions;

namespace NewGame.Entities
{
    public class Player
    {
        public int posX, posY;
        public int dirX;

        public int IdleOrMovingFrames = 4;
        public int FishingFrames = 1;

        public int timer = 0;
        public int frameTimer = 500;
        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;
        public int numberOfFrame;

        public int sizeX, sizeY;
        public int strengthOfRod = 5;

        public bool isTalking, isFishing, isMoving;
        public int countOfMoney = 0;

        public int countOffishes = 0;

        public Image sprite = Resource1.character2;

        public Player(int posX, int posY, int sizeX, int sizeY, int numberOfFrame, int currentFrame)
        {
            this.countOffishes = 0;
            this.posX = posX;
            this.posY = posY;
            this.isFishing = false;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.numberOfFrame = numberOfFrame;
            currentLimit = IdleOrMovingFrames;
            currentAnimation = 0;
            this.currentFrame = currentFrame;
        }
        public void Move()
        {
            if (posX + dirX <= 900 & posX + dirX >= -20)
                posX += dirX;
        }

        public void PlayAnimation1(Graphics g)
        {
            timer += 50;
            if (timer >= frameTimer)
            {
                if (currentFrame < currentLimit - 1) currentFrame++;
                else currentFrame = 0;
                timer = 0;
            }
            g.DrawImage(sprite, new Rectangle(new Point(posX, posY), new Size(sizeX, sizeY)), sizeX * currentFrame, sizeY * numberOfFrame, sizeX, sizeY, GraphicsUnit.Pixel);
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentLimit = 4;
                    break;
                case 1:
                    currentLimit = 1;
                    break;
            }
        }

        public int PlayerCanInteract(int posX1)
        {
            if ((posX >= posX1 - 20 && posX <= posX1 + 20) && !isTalking)
                return 0;
            else if (posX >= 830 && !isFishing)
                return 1;
            else return 2;
        }

        public void SetConfiguration(int sizeX, bool flag, int dirX, int anim, int numberOfFrame, int frameTimer, bool isMoving)
        {
            this.sizeX = sizeX;
            if (flag)
                isFishing = !isFishing;
            this.dirX = dirX;
            SetAnimationConfiguration(anim);
            this.numberOfFrame = numberOfFrame;
            this.frameTimer = frameTimer;
            this.isMoving = isMoving;
        }
    }
}
