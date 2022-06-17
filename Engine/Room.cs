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

        public (int x, int y) GetRoomXY() { return (roomX, roomY); } //gives coordination of this room in the maze
        public List<(int x, int y)> GetPossiblePlacement () { return possible_placement; } //gives list of all possible placements
        public List<Entries> GetEntries() { return entries; }  
        public List <Monster> GetMonsters { get { return monsters; } }
        public List<Immovable> GetImmovables() { return immovables; } 
        public int[,] GetMap() { return map; }
        public int GetSizeX() { return MaxX; }
        public int GetSizeY() { return MaxY; }
        public bool OnPossible_placement(int x, int y)
        {
            foreach(var placement in possible_placement)
            {
                if (placement.x == x && placement.y == y) return true;
            }
            return false;
        } //check if given coordinates are in possible placement
        public Maze GetMaze() { return labyrinth; }

        private void MakeSize(int value)
        {
            switch(value)
            {
                case 0: this.MaxX = 11; this.MaxY = 11; type = 0; break;
                case 1: this.MaxX = 21; this.MaxY = 13; type = 1; break;
                case 2: this.MaxX = 13; this.MaxY = 23; type = 2;  break;
                default: this.MaxX = 20; this.MaxY = 25; type = 3; break;
            }
        } //function to define sizes of the room

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
        } // it fills the room with the monsters

        private void FillEntries(List<int> neighbors, bool portal)
        {
            int y = (int)Math.Ceiling((double)MaxY / 2);
            int x = (int)Math.Ceiling((double)MaxX / 2);
            while (neighbors.Count > 0)
            {
                switch (neighbors[0])
                {
                    case 0:
                        this.entries.Add(new Entries(0, y, false,this));
                        possible_placement.Remove((0, y));
                        this.entries.Add(new Entries(0, y - 1, false,this));
                        possible_placement.Remove((0, y - 1));
                        this.entries.Add(new Entries(0, y + 1, false,this));
                        possible_placement.Remove((0, y + 1));
                        break;
                    case 1:
                        this.entries.Add(new Entries(MaxX - 1, y, false,this));
                        possible_placement.Remove((MaxX - 1, y));
                        this.entries.Add(new Entries(MaxX - 1, y - 1, false,this));
                        possible_placement.Remove((MaxX - 1, y - 1));
                        this.entries.Add(new Entries(MaxX - 1, y + 1, false,this));
                        possible_placement.Remove((MaxX - 1, y + 1));
                        break;
                    case 2:
                        this.entries.Add(new Entries(x, 0, false, this));
                        possible_placement.Remove((x, 0));
                        this.entries.Add(new Entries(x - 1, 0, false, this));
                        possible_placement.Remove((x - 1, 0));
                        this.entries.Add(new Entries(x + 1, 0, false,this));
                        possible_placement.Remove((x + 1, 0));
                        break;
                    case 3:
                        this.entries.Add(new Entries(x, MaxY - 1, false,this));
                        possible_placement.Remove((x, MaxY - 1));
                        this.entries.Add(new Entries(x - 1, MaxY - 1, false,this));
                        possible_placement.Remove((x - 1, MaxY - 1));
                        this.entries.Add(new Entries(x + 1, MaxY - 1, false,this));
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
                        this.entries.Add(new Entries(j, i, true,this));
                        possible_placement.Remove((j, i));
                    }
                }
            }
        } //fills the room with entries

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
                        possible_placement.Remove(placement);
                        break;
                    case 1:
                        immovables.Add(new Pillar(placement.x, placement.y,this));
                        possible_placement.Remove(placement);
                        break;
                }
                length--;
            }
            if (this.GetMaze().HasRoomKey(roomX,roomY))
            {
                (int x, int y) placement = possible_placement.ElementAt(rand.Next(length));
                immovables.Add(new Pedestal(placement.x, placement.y, this));
                possible_placement.Remove(placement);
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

            List<int> neighbors = maze.NeighborRooms(X,Y);
            FillEntries(neighbors,maze.HasRoomPortal(roomX,roomY));
            

            switch (type)
            {
                case 0:
                    FillMonsters(rand.Next(2, 7), rand);
                    FillImmovables(rand.Next(8, 16),rand);
                    break;
                case 1:
                    FillMonsters(rand.Next(5, 11), rand);
                    FillImmovables(rand.Next(20, 26), rand);
                    break;
                case 2:
                    FillMonsters(rand.Next(10, 13), rand);
                    FillImmovables(rand.Next(15, 26), rand);
                    break;
                case 3:
                    FillMonsters(rand.Next(12, 17), rand);
                    FillImmovables(rand.Next(30, 41), rand);
                    break;
            }

            foreach(var entry in entries) { possible_placement.Add(entry.GetEntrieXY()); }
            foreach (var immovable in immovables) 
            { 
                if (!(immovable is Pillar)) possible_placement.Add((immovable.GetXPos(), immovable.GetYPos())); 
            }
            FillMap();
        }

        public int findMonster(int x, int y) { 
            for(int i = 0; i < monsters.Count; i++)
            {
                Monster possible = monsters.ElementAt(i);
                if (possible.GetXPos() == x && possible.GetYPos() == y) return i;
            }
            return -1;
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
             * 9 - pedestal
             */

            foreach (var entry in entries)
            {
                if (entry.IsPortal()) map[entry.GetEntrieXY().y, entry.GetEntrieXY().x] = 1;
                else map[entry.GetEntrieXY().y, entry.GetEntrieXY().x] = 2;
            }
            
            foreach (var immovable in immovables)
            {
                if (immovable is Pillar) map[immovable.GetYPos(), immovable.GetXPos()] = 5;
                else if (immovable is Abyss) map[immovable.GetYPos(), immovable.GetXPos()] = 4;
                else if (immovable is Pedestal) map[immovable.GetYPos(), immovable.GetXPos()] = 9;
                else map[immovable.GetYPos(), immovable.GetXPos()] = 6;
            }
            foreach(var monster in monsters)
            {
                if(monster is Warrior) map[monster.GetYPos(), monster.GetXPos()] = 7;
                else map[monster.GetYPos(), monster.GetXPos()] = 8;
            }
            map[this.GetMaze().GetPlayer().GetPlayerYPos(), this.GetMaze().GetPlayer().GetPlayerXPos()] = 3;
        }


        public void ChangePlace(int XPosFrom, int YPosFrom, int XPosTo, int YPosTo)
        {
            int value = map[YPosFrom, XPosFrom];
            map[YPosFrom, XPosFrom] = 0;
            map[YPosTo, XPosTo] = value;
            possible_placement.Remove((XPosTo, YPosTo));
            possible_placement.Add((XPosFrom, YPosFrom));
        }

        public bool MonsterTurn()
        {
            foreach(var monster in monsters)
            {
                monster.MakeTurn();
                if (labyrinth.GetPlayer().GetHealth() <= 0) return true;
            }
            foreach(var immovable in immovables)
            {
                immovable.DealDamage();
                if (labyrinth.GetPlayer().GetHealth() <= 0) return true;
            }
            return false;
        }
        public bool HasMonster()
        {
            return (monsters.Count != 0);
        }

        public Monster Monster
        {
            get => default;
            set
            {
            }
        }

        public Immovable Immovable
        {
            get => default;
            set
            {
            }
        }

        public Entries Entries
        {
            get => default;
            set
            {
            }
        }

        public Maze Maze
        {
            get => default;
            set
            {
            }
        }
    }
}
