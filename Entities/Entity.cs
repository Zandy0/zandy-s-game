using System.Drawing;
using System.Windows.Forms;

namespace NewGame.Entities
{
    public class Entity
    {
        public int posX, posY;
        public int dirX;

        public int IdleOrMovingFrames;

        public int timer = 0;
        public int frameTimer = 200;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;
        public int numberOfFrame;

        public int sizeX, sizeY;
        public int strengthOfRod;
        public bool isFishing;
        public bool isMoving;

        public Image sprites;

        public static int countOffishes;

        public Entity(int posX, int posY, int IdleOrMovingFrames, Image sprites, int sizeX, int sizeY, int numberOfFrame, int currentFrame)
        {
            this.posX = posX;
            this.posY = posY;
            this.isFishing = false;
            this.IdleOrMovingFrames = IdleOrMovingFrames;
            this.sprites = sprites;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.numberOfFrame = numberOfFrame;
            currentLimit = IdleOrMovingFrames;  
            currentAnimation = 0;
            this.currentFrame = currentFrame;
        }

        public void PlayAnimation1(Graphics g)
        {
            timer += 10;
            if (timer >= frameTimer)
            {
                if (currentFrame < currentLimit - 1) currentFrame++;
                else currentFrame = 0;
                timer = 0;
            }
            g.DrawImage(sprites, new Rectangle(new Point(posX, posY), new Size(sizeX, sizeY)), sizeX * currentFrame,  0, sizeX, sizeY, GraphicsUnit.Pixel);
        }             
    }
}
