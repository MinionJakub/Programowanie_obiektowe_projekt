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
        private Room room;

        public Entries(int x, int y, bool portal, Room room)
        {
            this.posX = x;
            this.posY = y;
            this.portal = portal;
            this.room = room;

        }

        public (int x, int y) GetEntrieXY() { return (posX, posY); }
        public bool IsPortal() { return portal; }
        public void PlayerWantToPassThrought()
        {
            Player gracz = room.GetMaze().GetPlayer();
            if (portal)
            {
                
                if (gracz.GetHasKey() && !room.HasMonster())
                {
                    Maze maze = new Maze(gracz);
                    gracz.SetCurrentGameLevel(maze);
                    gracz.SetHasKey(false);
                    gracz.SetActions(gracz.GetMaxActions());
                    gracz.SetHealth(gracz.GetMaxHealth());
                }
            }
            else
            {
                if (!(room.HasMonster()))
                {
                    (int x, int y) coordinate = room.GetRoomXY();
                    if (posX == 0)
                    {
                        room.GetMaze().PlayerChangedRoom((coordinate.x - 1, coordinate.y));
                        gracz.SetActions(gracz.GetMaxActions());
                        int xpos = room.GetMaze().GetCurrentRoom().GetSizeX();
                        int ypos = room.GetMaze().GetCurrentRoom().GetSizeY();
                        gracz.SetPlayerXPos(xpos - 1);
                        gracz.SetPlayerYPos((int)Math.Ceiling((double)ypos / 2));
                        gracz.SetHealth(gracz.GetHealth() + 1);
                        room.GetMaze().GetCurrentRoom().FillMap();
                    }
                    else if (posX == room.GetSizeX() - 1)
                    {
                        room.GetMaze().PlayerChangedRoom((coordinate.x + 1, coordinate.y));
                        gracz.SetActions(gracz.GetMaxActions());
                        int ypos = room.GetMaze().GetCurrentRoom().GetSizeY();
                        gracz.SetPlayerXPos(0);
                        gracz.SetPlayerYPos((int)Math.Ceiling((double)ypos / 2));
                        gracz.SetHealth(gracz.GetHealth() + 1);
                        room.GetMaze().GetCurrentRoom().FillMap();
                    }
                    else if (posY == 0)
                    {
                        room.GetMaze().PlayerChangedRoom((coordinate.x, coordinate.y - 1));
                        gracz.SetActions(gracz.GetMaxActions());
                        int xpos = room.GetMaze().GetCurrentRoom().GetSizeX();
                        int ypos = room.GetMaze().GetCurrentRoom().GetSizeY();
                        gracz.SetPlayerXPos((int)Math.Ceiling((double)xpos / 2));
                        gracz.SetPlayerYPos(ypos - 1);
                        gracz.SetHealth(gracz.GetHealth() + 1);
                        room.GetMaze().GetCurrentRoom().FillMap();
                    }
                    else if(posY == room.GetSizeY() - 1)
                    {
                        room.GetMaze().PlayerChangedRoom((coordinate.x,coordinate.y + 1));
                        gracz.SetActions(gracz.GetMaxActions());
                        int xpos = room.GetMaze().GetCurrentRoom().GetSizeX();
                        gracz.SetPlayerXPos((int)Math.Ceiling((double) xpos / 2));
                        gracz.SetPlayerYPos(0);
                        gracz.SetHealth(gracz.GetHealth() + 1);
                        room.GetMaze().GetCurrentRoom().FillMap();
                    }
                }
            }
        }
    }
}
