using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Entries
    {
        private int posX;
        private int posY;
        private bool portal;

        public Entries(int x, int y, bool portal)
        {
            this.posX = x;
            this.posY = y;
            this.portal = portal;
        }

        public (int x, int y) GetEntrieXY() { return (posX, posY); }
        public bool IsPortal() { return portal; }
    }
}
