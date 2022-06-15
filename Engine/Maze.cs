using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Maze
    {
        private List<Room> rooms;
        private int[,] where_are_rooms;
        private List<(int x, int y)> list_of_rooms;
        private Player player;
        private Room current_room;
        private (int x, int y) KeyRoom;
        private (int x, int y) PortalRoom;

        public Player GetPlayer() { return player; }
        private void RandWalk(int how_many_roooms)
        {
            int how_many_left = how_many_roooms;
            var rand = new Random();
            (int x, int y) walker = (5,5);
            while(how_many_left > 0)
            {
                if(where_are_rooms[walker.y,walker.x] == 0)
                {
                    how_many_left--;
                    where_are_rooms[walker.y, walker.x] = 1;
                    list_of_rooms.Add(walker);
                }
                int value = rand.Next(4);
                switch (value)
                {
                    case 0:
                        if(walker.x - 1 >= 0) walker.x--;
                        break;
                    case 1:
                        if(walker.y - 1 >= 0) walker.y--;
                        break;
                    case 2:
                        if(walker.x + 1 <= 9) walker.x++;
                        break;
                    case 3:
                        if(walker.y + 1 <= 9) walker.y++;
                        break;
                }
            }
        }
        public void ChangeRoom((int x, int y) pos)
        {
            int index = 0;
            Room actual_room = rooms.ElementAt(index);
            while(actual_room.GetRoomXY() != pos)
            {
                index++;
                actual_room = rooms.ElementAt(index);
            }
            this.current_room = actual_room;
        }
        public void PlayerChangedRoom((int x, int y) pos)
        {
            if(where_are_rooms[pos.y,pos.x] == 1) { rooms.Add(new Room(this,pos.x,pos.y)); }
            ChangeRoom(pos);
        }
        public Maze() 
        {
            player = new Player(this);
            where_are_rooms = new int[10, 10];
            for(int i = 0; i < 10; i++)
                for(int j = 0;j < 10; j++) where_are_rooms[i,j] = 0;
            RandWalk(15);
            var rand = new Random();
            int keyRoom_index = rand.Next(15);
            int portalRoom_index = rand.Next(15);
            int starting_room_index = rand.Next(15);
            if(portalRoom_index == keyRoom_index) portalRoom_index--;
            portalRoom_index += (portalRoom_index < 0) ? 15 : 0;
            while(starting_room_index == portalRoom_index || starting_room_index == keyRoom_index)
            {
                if (starting_room_index == portalRoom_index) starting_room_index++;
                if (starting_room_index == keyRoom_index) starting_room_index++;
                starting_room_index -= (starting_room_index > 14) ? 15 : 0;
            }
            KeyRoom = list_of_rooms.ElementAt(keyRoom_index);
            PortalRoom = list_of_rooms.ElementAt(portalRoom_index);
            current_room = new Room(this, list_of_rooms.ElementAt(starting_room_index).x, list_of_rooms.ElementAt(starting_room_index).y);
            rooms.Add(current_room);
            where_are_rooms[list_of_rooms.ElementAt(starting_room_index).y, list_of_rooms.ElementAt(starting_room_index).x] = 2;
        }
        public Maze(Player player)
        {
            this.player = player;
            where_are_rooms = new int[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++) where_are_rooms[i, j] = 0;
            RandWalk(15);
            var rand = new Random();
            int keyRoom_index = rand.Next(15);
            int portalRoom_index = rand.Next(15);
            int starting_room_index = rand.Next(15);
            if (portalRoom_index == keyRoom_index) portalRoom_index--;
            portalRoom_index += (portalRoom_index < 0) ? 15 : 0;
            while (starting_room_index == portalRoom_index || starting_room_index == keyRoom_index)
            {
                if (starting_room_index == portalRoom_index) starting_room_index++;
                if (starting_room_index == keyRoom_index) starting_room_index++;
                starting_room_index -= (starting_room_index > 14) ? 15 : 0;
            }
            KeyRoom = list_of_rooms.ElementAt(keyRoom_index);
            PortalRoom = list_of_rooms.ElementAt(portalRoom_index);
            current_room = new Room(this, list_of_rooms.ElementAt(starting_room_index).x, list_of_rooms.ElementAt(starting_room_index).y);
            rooms.Add(current_room);
            where_are_rooms[list_of_rooms.ElementAt(starting_room_index).y, list_of_rooms.ElementAt(starting_room_index).x] = 2;
        }
        public bool HasRoomKey() { return (KeyRoom.x == current_room.GetRoomXY().x && KeyRoom.y == current_room.GetRoomXY().y); }
        public bool HasRoomPortal(int x, int y) { return (PortalRoom.x == x && PortalRoom.y == y); }
        public List<int> NeighborRooms() 
        { 
            List<int> list_of_directions = new List<int>();

            (int x, int y) x_y = current_room.GetRoomXY();
            if (x_y.x > 0 && where_are_rooms[x_y.y, x_y.x - 1] != 0) list_of_directions.Add(0);
            if (x_y.x < 10 && where_are_rooms[x_y.y, x_y.x + 1] != 0) list_of_directions.Add(1);
            if (x_y.y > 0 && where_are_rooms[x_y.y - 1, x_y.x] != 0) list_of_directions.Add(2);
            if (x_y.y < 10 && where_are_rooms[x_y.y + 1, x_y.x] != 0) list_of_directions.Add(3);
            return list_of_directions;
        }
    }
}
