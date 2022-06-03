using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewGame.Entities;
using NewGame.Positions;

namespace NewGame.Fishing
{
    public class StartFishing
    {
        ///
        /// ProgressBar
        ///
        public double fill = 0.6;
        public int barSize = 248;
        public int posXbr, posYbr;
        public double speed;
        public double positiveExp, negativeExp;
        public Bitmap[] bar = new Bitmap[2] { Resource1.MainFrame, Resource1.ProgressBar };
        ///
        /// FrameWithCursor
        ///
        public Bitmap[] cursor = new Bitmap[2] { Resource1.MainFrame, Resource1.Cursor };
        public int dirX;
        public int posX, posY;
        public int direction;
        public int cursorSizeX, cursorSizeY;
        public static int frameSizeX = 256, frameSizeY = 40;

        public StartFishing(double speed, double positiveExp, double negativeExp, int dirX)
        {
            ///
            /// ProgressBar
            ///
            this.positiveExp = positiveExp;
            this.negativeExp = negativeExp;
            posXbr = Position.posX;
            posYbr = Position.posY + 50;
            this.speed = speed;
            ///
            /// FrameWithCursor
            ///
            posX = Position.posX;
            posY = Position.posY;
            this.dirX = dirX;
            direction = 1;
        }

        public void ProgressIsReached(bool reach)
        {
            if (reach) fill += positiveExp;
            else if (fill + negativeExp <= 0) fill = 0;
            else fill += negativeExp;
        }

        public void CursorMove()
        {
            if (OnBorder())
                direction *= -1;
            posX += (dirX * direction);
        }

        public void BarDecrease()
        {
            fill -= speed;
        }

        public bool OnBorder()
        {
            if (posX + dirX * direction <= Position.posX || posX + dirX * direction >= Position.posX + frameSizeX - 6)
                return true;
            else return false;
        }

        public void PlayAnimation1(Graphics g)
        {
            ///
            /// ProgressBar
            ///
            g.DrawImage(bar[0], posXbr, posYbr);
            g.DrawImage(bar[1], posXbr + 4, posYbr + 4, (float)(barSize * Math.Round(fill, 5)), 32);
            ///
            /// FrameWithCursor
            ///
            g.DrawImage(cursor[0], Position.posX, Position.posY);
            g.DrawImage(cursor[1], posX + 4, posY + 4);
        }
    }
}
