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
        protected bool hasKey;

        public Room Room
        {
            get => default;
            set
            {
            }
        }

        public int GetXPos() { return XPos; }
        public int GetYPos() { return YPos; }

        public void DealDamage()
        {
            if(Damage != 0)
            {
                Player player = terrain.GetMaze().GetPlayer();
                if ((XPos, YPos) == (player.GetPlayerXPos(), player.GetPlayerYPos())) player.SetHealth(player.GetHealth() - Damage);
                else
                {
                    List<Monster> monsters = terrain.GetMonsters;
                    int index = terrain.findMonster(XPos, YPos);
                    if (index != -1) monsters.ElementAt(index).SetHealth(monsters.ElementAt(index).GetHealth() - Damage);
                }
            }
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
            this.hasKey = false;
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
            this.hasKey = false;
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
            this.hasKey = false;
        }
    }
    public class Pedestal : Immovable
    {
        public Pedestal (int x, int y, Room room)
        {
            Damage = 0;
            XPos = x;
            YPos = y;
            terrain = room;
            hasKey = true;
        }
    }
}
