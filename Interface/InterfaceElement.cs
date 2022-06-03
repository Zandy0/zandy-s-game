using NewGame.Positions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGame.Fishing
{
    public class InterfaceElement
    {
        public int posX, posY;
        public Bitmap[] Char = new Bitmap[7] { Resource1.CharH,
                       Resource1.CharJ,
                       Resource1.CharK,
                       Resource1.secondHelpE,
                       Resource1.firstHelpE,
                       Resource1.gameOver,
                       Resource1.shopinterface
        };

        public int charNumber;
        public bool isCatch;
        public InterfaceElement(int posX, int posY, int charNumber)
        {
            this.posX = posX;
            this.posY = posY;
            this.charNumber = charNumber;
        }

        public bool isCathed(int X, int Y, int keyValue)
        {
            if (posX + 32 >= X && posX <= X && keyValue == this.charNumber)
            {
                GetRandomPosAndChar();
                return true;
            }
            return false;
        }

        public void GetRandomPosAndChar()
        {
            Random rnd = new Random();
            posX = rnd.Next(Position.posX + 4, Position.posX + StartFishing.frameSizeX - 32);
            charNumber = rnd.Next(0, 3);
        }

        public void DrawChar(Graphics g)
        {
            g.DrawImage(Char[charNumber], posX, posY);
        }
    }
}
