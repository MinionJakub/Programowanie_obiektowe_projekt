using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class Immovable
    {
        protected int Damage;
        protected int XPos;
        protected int YPos;
        protected Room terrain;

        public int GetXPos() { return XPos; }
        public int GetYPos() { return YPos; }

        public void DealDamage()
        {

        }
    }
    public class Abyss : Immovable
    {
        public Abyss(int x, int y, Room room)
        {
            this.Damage = 2;
            this.XPos = x;
            this.YPos = y;   
            this.terrain = room;
        }
    }

    public class Pillar : Immovable
    {
        public Pillar (int x, int y, Room room)
        {
            this.Damage = 0;
            this.XPos = x;
            this.YPos = y;
            this.terrain = room;
        }
    }

    public class Corpse : Immovable
    {
        public Corpse (int x, int y, Room room)
        {
            this.Damage = 0;
            this.XPos = x;
            this.YPos = y;
            this.terrain = room;
        }
    }
}
