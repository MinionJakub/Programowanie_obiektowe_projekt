using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Archer : Monster
    {
        public Archer(Room terrain, int XPos, int YPos)
        {
            this.Health = 1;
            this.MaxHealth = 1;
            this.Reach = 4;
            this.MaxSpeed = 2;
            this.Speed = 2;
            this.Damage = 1;
            this.terrain = terrain;
            this.XPos = XPos;
            this.YPos = YPos;
            this.escaping = false;
        }
        protected override bool CanAttack()
        {
            Player gracz = terrain.GetMaze().GetPlayer();
            
            List<(int x, int y)> list_of_blocks_x_pos = new List<(int x, int y)>();
            List<(int x, int y)> list_of_blocks_x_neg = new List<(int x, int y)>();
            List<(int x, int y)> list_of_blocks_y_pos = new List<(int x, int y)>();
            List<(int x, int y)> list_of_blocks_y_neg = new List<(int x, int y)>();
            List<Immovable> lista = terrain.GetImmovables();

            for (int i = 0; i < lista.Count; i++)
            {
                Immovable obj = lista[i];
                if (obj is Pillar)
                {
                    if (obj.GetXPos() == XPos && 
                        obj.GetYPos() - YPos <= Reach && 
                        obj.GetYPos() - YPos > 0) list_of_blocks_y_pos.Add((obj.GetXPos(), obj.GetYPos()));
                    else if (obj.GetXPos() == XPos && 
                        YPos - obj.GetYPos() <= Reach && 
                        YPos - obj.GetYPos() > 0) list_of_blocks_y_neg.Add((obj.GetXPos(), obj.GetYPos()));
                    else if(obj.GetYPos() == YPos && 
                        obj.GetXPos() - XPos <= Reach && 
                        obj.GetXPos() - XPos > 0) list_of_blocks_x_pos.Add((obj.GetXPos(),obj.GetYPos()));
                    else if (obj.GetYPos() == YPos && 
                        XPos - obj.GetXPos() <= Reach && 
                        XPos - obj.GetXPos() > 0) list_of_blocks_x_neg.Add((obj.GetXPos(), obj.GetYPos()));
                }
            }
            int player_x = gracz.GetPlayerXPos();
            int player_y = gracz.GetPlayerYPos();
            if (player_x == XPos && 
                player_y - YPos <= Reach && 
                player_y - YPos > 1 && 
                list_of_blocks_y_pos.Count == 0) return true;
            else if (player_x == XPos && 
                YPos - player_y <= Reach && 
                YPos - player_y > 1 && 
                list_of_blocks_y_neg.Count == 0) return true;
            else if (player_y == YPos && 
                player_x - XPos <= Reach && 
                player_x - XPos > 1 && 
                list_of_blocks_x_pos.Count == 0) return true;
            else if (player_y == YPos && 
                XPos - player_x <= Reach && 
                XPos - player_x > 1 && 
                list_of_blocks_y_pos.Count == 0) return true;
            return false;
        }

        public override void MakeTurn()
        {
            if (CanAttack()) { this.Attack(); }
            else
            {
                Player gracz = this.terrain.GetMaze().GetPlayer();
                int player_x = gracz.GetPlayerXPos();
                int player_y = gracz.GetPlayerYPos();
                if (Math.Abs(player_x - XPos) <= 1 && Math.Abs(player_y - YPos) <= 1) escaping = true;
                this.Move();
                this.Move();
                escaping = false;
            }    
        }
    }
}
