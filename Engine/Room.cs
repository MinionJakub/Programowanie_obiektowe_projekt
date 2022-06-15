using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Room
    {
        private List<Monster> monsters;
        private List<Immovable> immovables;
        private List<Entries> entries;
        private Maze labyrinth;
        private int[,] map;
        private int MaxX; //size of room
        private int MaxY; //size of room
        private List<(int x, int y)> possible_placement; //possible location to place sth on map
        private int roomX; //placemnet in dungeon
        private int roomY; //placement in dungeon
        private int type;

        public (int x, int y) GetRoomXY() { return (roomX, roomY); }
        public Maze GetMaze() { return labyrinth; }

        private void MakeSize(int value)
        {
            switch(value)
            {
                case 0: this.MaxX = 11; this.MaxY = 11; type = 0; break;
                case 1: this.MaxX = 21; this.MaxY = 13; type = 1; break;
                case 2: this.MaxX = 9; this.MaxY = 31; type = 2;  break;
                default: this.MaxX = 15; this.MaxY = 25; type = 3; break;
            }
        }

        private void FillMonsters(int how_many_monsters, System.Random rand)
        {
            int length = possible_placement.Count;
            for (int i = 0; i < how_many_monsters ; i++)
            {
                var placement = possible_placement.ElementAt(rand.Next(0, length));
                possible_placement.Remove(placement);
                length--;
                switch (rand.Next(2))
                {
                    case 0: monsters.Add(new Warrior(this, placement.x, placement.y)); break;
                    case 1: monsters.Add(new Archer(this, placement.x,placement.y)); break;
                }
            }
        }

        private void FillEntries(List<int> neighbors, bool portal)
        {
            int y = (int)Math.Ceiling((double)MaxY / 2);
            int x = (int)Math.Ceiling((double)MaxX / 2);
            while (neighbors.Count > 0)
            {
                switch (neighbors[0])
                {
                    case 0:
                        this.entries.Add(new Entries(0, y, false));
                        possible_placement.Remove((0, y));
                        this.entries.Add(new Entries(0, y - 1, false));
                        possible_placement.Remove((0, y - 1));
                        this.entries.Add(new Entries(0, y + 1, false));
                        possible_placement.Remove((0, y + 1));
                        break;
                    case 1:
                        this.entries.Add(new Entries(MaxX - 1, y, false));
                        possible_placement.Remove((MaxX - 1, y));
                        this.entries.Add(new Entries(MaxX - 1, y - 1, false));
                        possible_placement.Remove((MaxX - 1, y - 1));
                        this.entries.Add(new Entries(MaxX - 1, y + 1, false));
                        possible_placement.Remove((MaxX - 1, y + 1));
                        break;
                    case 2:
                        this.entries.Add(new Entries(x, 0, false));
                        possible_placement.Remove((x, 0));
                        this.entries.Add(new Entries(x - 1, 0, false));
                        possible_placement.Remove((x - 1, 0));
                        this.entries.Add(new Entries(x + 1, 0, false));
                        possible_placement.Remove((x + 1, 0));
                        break;
                    case 3:
                        this.entries.Add(new Entries(x, MaxY - 1, false));
                        possible_placement.Remove((x, MaxY - 1));
                        this.entries.Add(new Entries(x - 1, MaxY - 1, false));
                        possible_placement.Remove((x - 1, MaxY - 1));
                        this.entries.Add(new Entries(x + 1, MaxY - 1, false));
                        possible_placement.Remove((x + 1, MaxY - 1));
                        break;
                }
                neighbors.RemoveAt(0);
            }
            if (portal)
            {
                for (int i = y - 1; i <= y + 1; i++)
                {
                    for (int j = x - 1; j <= x + 1; j++)
                    {
                        this.entries.Add(new Entries(j, i, true));
                        possible_placement.Remove((j, i));
                    }
                }
            }
        }

        private void FillImmovables(int how_many, System.Random rand)
        {
            int length = possible_placement.Count;
            for (int i = 0; i < how_many; i++)
            {
                (int x, int y) placement = possible_placement.ElementAt(rand.Next(length));
                switch (rand.Next(2))
                {
                    case 0:
                        immovables.Add(new Abyss(placement.x, placement.y,this));
                        break;
                    case 1:
                        immovables.Add(new Pillar(placement.x, placement.y,this));
                        possible_placement.Remove(placement);
                        break;
                }
            }
        }

        public Room(Maze maze, int X, int Y)
        {
            this.roomX = X;
            this.roomY = Y;
            this.labyrinth = maze;
            var rand = new Random();

            int value_for_size = rand.Next(4);
            this.MakeSize(value_for_size);
            possible_placement = new List<(int x, int y)>();
            this.map = new int[MaxY, MaxX];
            for(int y = 0; y < MaxY; y++)
            {
                for (int x = 0; x < MaxX; x++)
                {
                    map[y, x] = 0;
                    possible_placement.Add((x, y));
                } 
            }
            this.monsters = new List<Monster>();
            this.immovables = new List<Immovable>();
            this.entries = new List<Entries>();

            List<int> neighbors = maze.NeighborRooms();
            FillEntries(neighbors,maze.HasRoomPortal(roomX,roomY));

            int how_many_monsters = rand.Next(2, 7);
            FillMonsters(how_many_monsters, rand);

            switch (type)
            {
                case 0:
                    FillImmovables(rand.Next(8, 16),rand);
                    break;
                case 1:
                    FillImmovables(rand.Next(20, 26), rand);
                    break;
                case 2:
                    FillImmovables(rand.Next(15, 26), rand);
                    break;
                default:
                    FillImmovables(rand.Next(40, 51), rand);
                    break;
            }

            foreach(var entry in entries) { possible_placement.Add(entry.GetEntrieXY()); }
            FillMap();
        }

        private int findMonster(int x, int y) { 
            for(int i = 0; true; i++)
            {
                Monster possible = monsters.ElementAt(i);
                if (possible.GetXPos() == x && possible.GetYPos() == y) return i;
            }
        }
        public void RemoveMonster (int x, int y)
        {
            int index = findMonster(x, y);
            monsters.RemoveAt(index);
            immovables.Add(new Corpse(x, y,this));
        }

        public void FillMap()
        {
            for (int i = 0; i < MaxY; i++)
                for (int j = 0; j < MaxX; j++)
                    map[i, j] = 0;


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

            foreach (var entry in entries)
            {
                if (entry.IsPortal()) map[entry.GetEntrieXY().y, entry.GetEntrieXY().x] = 1;
                else map[entry.GetEntrieXY().y, entry.GetEntrieXY().x] = 2;
            }
            map[this.GetMaze().GetPlayer().GetPlayerYPos(), this.GetMaze().GetPlayer().GetPlayerXPos()] = 3;
            foreach (var immovable in immovables)
            {
                if (immovable is Pillar) map[immovable.GetYPos(), immovable.GetXPos()] = 5;
                else if (immovable is Abyss) map[immovable.GetYPos(), immovable.GetXPos()] = 4;
                else map[immovable.GetYPos(), immovable.GetXPos()] = 6;
            }
            foreach(var monster in monsters)
            {
                if(monster is Warrior) map[monster.GetYPos(), monster.GetXPos()] = 7;
                else map[monster.GetYPos(), monster.GetXPos()] = 8;
            }
        }

        public List<Immovable> GetImmovables() { return immovables; }
        public int[,] GetMap () { return map; } 
        public int GetSizeX() { return MaxX; }
        public int GetSizeY() { return MaxY; }
        public void ChangePlace(int XPos1, int YPos1, int XPos2, int YPos2)
        {
            int value = map[XPos1, YPos1];
            map[XPos1, YPos1] = 0;
            map[XPos2, YPos2] = value;
        }
    }
}
