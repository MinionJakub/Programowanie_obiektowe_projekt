using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class Monster
    {
        protected int Health;
        protected int Speed;
        protected int Reach;
        protected int MaxHealth;
        protected int MaxSpeed;
        protected int Damage;
        protected int XPos;
        protected int YPos;
        protected bool escaping;
        protected Room terrain;

        public Room Room
        {
            get => default;
            set
            {
            }
        }

        public int GetXPos() { return XPos; }
        public int GetYPos() { return YPos; }
        public void SetXPos(int x) { XPos = x; }
        public void SetYPos(int y) { YPos = y; }
        public int GetHealth() { return Health; }
        public void SetHealth(int health) { Health = health; this.Death(); }
        public int GetSpeed() { return Speed; }
        public void SetSpeed(int speed) { Speed = speed; }
        protected void Attack()
        {
            Player gracz = this.terrain.GetMaze().GetPlayer();
            gracz.SetHealth(gracz.GetHealth() - Damage);
        }
        /*protected List<(int x, int y)> PathFinding()
        {
            List<(int x, int y)> pathFinding = new List<(int x,int y)> ();
        }*/
        protected bool CanYouGoThere(int x, int y, int[,] map)
        {
           /*
           * 0 - empty space
           * 1 - portal
           * 2 - door
           * 3 - player
           * 4 - abyss
           * 5 - pillar
           * 6 - corpse
           * 7 - warrior
           * 8 - archer
           */
            switch (map[y, x])
            {
                case 0: case 1: case 2: case 6: return true;
                default: return false;
            }
        }
        protected void Move()
        {
            Player gracz = this.terrain.GetMaze().GetPlayer();
            int player_x = gracz.GetPlayerXPos();
            int player_y = gracz.GetPlayerYPos();
            int[,] map = terrain.GetMap();

            /*
             *2.    |     1.
             *      |  
             *      |
             *      |
             *      |
             *------+------> 
             *      |
             *      |
             *      |
             *      |
             *      |
             *3.    v     4.
             */


            List<(int x, int y)> list_of_moves = new List<(int x, int y)>();
            int x_diff = player_x - XPos;
            int y_diff = player_y - YPos;
            if (escaping)
            {
                if (x_diff >= 0 && y_diff >= 0)
                {
                    for (int i = XPos - Speed; i <= XPos + Speed; i++)
                        if (i >= 0 && i < terrain.GetSizeX())
                        {
                            for (int j = YPos - Speed; j <= YPos + Speed; j++)
                            {
                                if (j >= 0 && j < terrain.GetSizeY())
                                {
                                    if (i - XPos < 0 || j - YPos < 0)
                                    {
                                        if (CanYouGoThere(i, j, map)) list_of_moves.Add((i, j));
                                    }
                                }
                            }
                        }
                } //Znalezienie wszystkich mozliwych ruchow oddalajacych od gracza jesli jest w 4.
                else if (x_diff <= 0 && y_diff >= 0)
                {
                    for (int i = XPos - Speed; i <= XPos + Speed; i++)
                    {
                        if (i >= 0 && i < terrain.GetSizeX())
                        {
                            for (int j = YPos - Speed; j <= YPos + Speed; j++)
                            {
                                if (j >= 0 && j < terrain.GetSizeY())
                                {
                                    if (i - XPos > 0 || j - YPos < 0)
                                    {
                                        if (CanYouGoThere(i, j, map)) list_of_moves.Add((i, j));
                                    }
                                }
                            }
                        }
                    }
                } //Znalezienie wszystkich mozliwych ruchow oddalajacych od gracza jesli jest w 3.
                else if (x_diff <= 0 && y_diff <= 0)
                {
                    for (int i = XPos - Speed; i <= XPos + Speed; i++)
                    {
                        if (i >= 0 && i < terrain.GetSizeX())
                        {
                            for (int j = YPos - Speed; j <= YPos + Speed; j++)
                            {
                                if (j >= 0 && j < terrain.GetSizeY())
                                {
                                    if (i - XPos > 0 || j - YPos > 0)
                                    { 
                                        if (CanYouGoThere(i, j, map)) list_of_moves.Add((i, j)); 
                                    }
                                }
                            }
                        }
                    }
                } //Znalezienie wszystkich mozliwych ruchow oddalajacych od gracza jesli jest w 2.
                else if (x_diff >= 0 && y_diff <= 0)
                {
                    for(int i = XPos - Speed; i <= XPos + Speed; i++)
                    { 
                        if (i >= 0 && i < terrain.GetSizeX())
                        {
                            for (int j = YPos - Speed; j <= YPos + Speed; j++)
                            {
                                if (j >= 0 && j < terrain.GetSizeY())
                                {
                                    if (i - XPos < 0 || j - YPos > 0)
                                    {
                                        if (CanYouGoThere(i, j, map)) list_of_moves.Add((i, j));
                                    }
                                }
                            }
                        }
                    }
                }//Znalezienie wszystkich mozliwych ruchow oddalajacych od gracza jesli jest w 1.
            }
            else
            {
                if (x_diff >= 0 && y_diff >= 0)
                {
                    for (int i = XPos - Speed; i <= XPos + Speed; i++)
                        if (i >= 0 && i < terrain.GetSizeX())
                        {
                            for (int j = YPos - Speed; j <= YPos + Speed; j++)
                            {
                                if (j >= 0 && j < terrain.GetSizeY())
                                {
                                    if (i - XPos >= 0 && j - YPos >= 0)
                                    {
                                        if (CanYouGoThere(i, j, map)) list_of_moves.Add((i, j));
                                    }
                                }
                            }
                        }
                } //Znalezienie wszystkich mozliwych ruchow oddalajacych od gracza jesli jest w 4.
                else if (x_diff <= 0 && y_diff >= 0)
                {
                    for (int i = XPos - Speed; i <= XPos + Speed; i++)
                    {
                        if (i >= 0 && i < terrain.GetSizeX())
                        {
                            for (int j = YPos - Speed; j <= YPos + Speed; j++)
                            {
                                if (j >= 0 && j <= terrain.GetSizeY())
                                {
                                    if (i - XPos <= 0 && j - YPos >= 0)
                                    {
                                        if (CanYouGoThere(i, j, map)) list_of_moves.Add((i, j));
                                    }
                                }
                            }
                        }
                    }
                } //Znalezienie wszystkich mozliwych ruchow oddalajacych od gracza jesli jest w 3.
                else if (x_diff <= 0 && y_diff <= 0)
                {
                    for (int i = XPos - Speed; i <= XPos + Speed; i++)
                    {
                        if (i >= 0 && i < terrain.GetSizeX())
                        {
                            for (int j = YPos - Speed; j <= YPos + Speed; j++)
                            {
                                if (j >= 0 && j <= terrain.GetSizeY())
                                {
                                    if (i - XPos <= 0 && j - YPos <= 0)
                                    {
                                        if (CanYouGoThere(i, j, map)) list_of_moves.Add((i, j));
                                    }
                                }
                            }
                        }
                    }
                } //Znalezienie wszystkich mozliwych ruchow oddalajacych od gracza jesli jest w 2.
                else if (x_diff >= 0 && y_diff <= 0)
                {
                    for (int i = XPos - Speed; i <= XPos + Speed; i++)
                    {
                        if (i >= 0 && i < terrain.GetSizeX())
                        {
                            for (int j = YPos - Speed; j <= YPos + Speed; j++)
                            {
                                if (j >= 0 && j <= terrain.GetSizeY())
                                {
                                    if (i - XPos >= 0 && j - YPos <= 0)
                                    {
                                        if (CanYouGoThere(i, j, map)) list_of_moves.Add((i, j));
                                    }
                                }
                            }
                        }
                    }
                }//Znalezienie wszystkich mozliwych ruchow oddalajacych od gracza jesli jest w 1.
            }
            var rand = new Random();
            (int x, int y) pos = (-1,-1);
            if (list_of_moves.Count != 0)pos = list_of_moves[rand.Next(list_of_moves.Count)];
            while(list_of_moves.Count != 0 && !(terrain.OnPossible_placement(pos.x, pos.y))){
                list_of_moves.Remove(pos);
                pos = list_of_moves[rand.Next(list_of_moves.Count)];
            }
            if(list_of_moves.Count != 0)
            {
                terrain.ChangePlace(XPos, YPos, pos.x, pos.y);
                XPos = pos.x;
                YPos = pos.y;
            }
        }
        protected abstract bool CanAttack();
        public abstract void MakeTurn();
        public void Death()
        {
            if(Health <= 0) this.terrain.RemoveMonster(XPos, YPos);
        }


    }
}
