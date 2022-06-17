using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Warrior : Monster
    {
        public Warrior(Room terrain, int XPos, int YPos)
        {
            this.Health = 1;
            this.MaxHealth = 1;
            this.Reach = 1;
            this.MaxSpeed = 2;
            this.Speed = 2;
            this.Damage = 1;
            this.terrain = terrain;
            this.escaping = false;
            this.XPos = XPos;
            this.YPos = YPos;
        }

        protected override bool CanAttack()
        {
            Player gracz = terrain.GetMaze().GetPlayer();

           
            int player_x = gracz.GetPlayerXPos();
            int player_y = gracz.GetPlayerYPos();
            int absolute_diff_x = Math.Abs(player_x - XPos);
            int absolute_diff_y = Math.Abs(player_y - YPos);
            if (absolute_diff_x <= Reach && absolute_diff_y <= Reach ) return true;
            return false;
        }

        public override void MakeTurn()
        {
            if (CanAttack()) 
            {
                this.Attack();
                this.Attack();
            }
            else
            {
                this.Move();
                this.Move();
            }
        }
    }
}
