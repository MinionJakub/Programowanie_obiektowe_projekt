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
        public Room GetCurrentRoom() { return current_room; }
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
            list_of_rooms = new List<(int x, int y)>();
            rooms = new List<Room>();
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
            List<(int x, int y)> list_of_placements = current_room.GetPossiblePlacement();
            (int x, int y) random_placement = list_of_placements.ElementAt(rand.Next(list_of_placements.Count));
            player.SetPlayerXPos(random_placement.x);
            player.SetPlayerYPos(random_placement.y);
            current_room.FillMap();
        }
        public Maze(Player player)
        {
            list_of_rooms = new List<(int x, int y)>();
            rooms = new List<Room>();
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
            List<(int x, int y)> list_of_placements = current_room.GetPossiblePlacement();
            (int x, int y) random_placement = list_of_placements.ElementAt(rand.Next(list_of_placements.Count));
            player.SetPlayerXPos(random_placement.x);
            player.SetPlayerYPos(random_placement.y);
            current_room.FillMap();
        }
        public bool HasRoomKey(int X , int Y) { return (KeyRoom.x == X && KeyRoom.y == Y); }
        public bool HasRoomPortal(int x, int y) { return (PortalRoom.x == x && PortalRoom.y == y); }
        public List<int> NeighborRooms(int x, int y) 
        { 
            List<int> list_of_directions = new List<int>();

            (int x, int y) x_y = (x,y);
            if (x_y.x > 0 && where_are_rooms[x_y.y, x_y.x - 1] != 0) list_of_directions.Add(0);
            if (x_y.x < 9 && where_are_rooms[x_y.y, x_y.x + 1] != 0) list_of_directions.Add(1);
            if (x_y.y > 0 && where_are_rooms[x_y.y - 1, x_y.x] != 0) list_of_directions.Add(2);
            if (x_y.y < 9 && where_are_rooms[x_y.y + 1, x_y.x] != 0) list_of_directions.Add(3);
            return list_of_directions;
        }

        public char[,] GetMap()
        {
            int size_x = current_room.GetSizeX();
            int size_y = current_room.GetSizeY();
            char[,] map = new char[size_y + 2, size_x + 2];
            current_room.FillMap();
            int[,] value_map = current_room.GetMap();
            for (int y = 0; y < size_y + 2; y++)
            {
                for(int x = 0; x < size_x + 2; x++)
                {
                    if (y == 0 || y == size_y + 1) map[y, x] = '-';
                    if (x == 0 || x == size_x + 1) map[y, x] = '|';
                    if ((y == 0 && x == 0) ||
                        (y == 0 && x == size_x + 1) ||
                        (y == size_y + 1 && x == 0) ||
                        (y == size_y + 1 && x == size_x + 1)) map[y, x] = '+';
                    if(y > 0 && x > 0 && x < size_x + 1 && y < size_y + 1)
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
             * 9 - pedestal
             */
                        switch (value_map[y-1, x-1])
                        {
                            default:
                            case 0:
                                map[y, x] = ' '; //Puste Pole
                                break;
                            case 1:
                                map[y, x] = 'P'; // Portal
                                break;
                            case 2:
                                map[y, x] = 'D'; // Drzwi
                                break;
                            case 3:
                                map[y, x] = '@'; // Gracz
                                break;
                            case 4:
                                map[y, x] = 'O'; // Otchłań
                                break;
                            case 5:
                                map[y, x] = 'C'; // Pilar
                                break;
                            case 6:
                                map[y, x] = 'Z'; // Zwłoki
                                break;
                            case 7:
                                map[y, x] = 'W'; // Wojownik
                                break;
                            case 8:
                                map[y, x] = 'S'; // Łucznik
                                break;
                            case 9:
                                map[y, x] = 'K'; // Klucz
                                break;
                        }
                    }
                }
            }
            return map;
        }

        public int RoomNumber()
        {
            int i = 0;
            foreach(Room room in rooms)
            {
                if (room.GetRoomXY() == current_room.GetRoomXY()) return i;
                i++;
            }
            return -1;
        }
    }
}
