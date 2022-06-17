using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player
    {
        private int Health;
        private int Speed;
        private int MaxHealth;
        private int MaxSpeed;
        private int Damage;
        private int Reach;
        private int Actions;
        private int MaxActions;
        private int XPos;
        private int YPos;
        private Maze currentGameLevel;
        private bool hasKey;
        private bool isAlive;

        public int GetReach() { return this.Reach; }
        public int GetHealth() { return Health; }
        public int GetSpeed() { return Speed; }
        public void SetHealth (int value) { if(value <= MaxHealth) Health = value; this.Death(); }
        public void SetSpeed (int value) { if(value <= MaxSpeed) Speed = value; }
        public bool GetHasKey() { return hasKey; }
        public void SetHasKey (bool value) { hasKey = value; }

        public int GetActions() { return Actions; }
        public int GetMaxActions() { return MaxActions; }
        public void SetActions(int value) 
        { 
            if(value <= MaxActions) Actions = value;
        }

        public int GetMaxHealth() { return MaxHealth; }
        public int GetPlayerXPos() { return XPos; }
        public int GetPlayerYPos() { return YPos; }

        public void SetPlayerXPos(int x) { XPos = x; }
        public void SetPlayerYPos(int y) { YPos = y; }
        public Maze GetCurrentGameLevel() { return currentGameLevel; }

        public void SetCurrentGameLevel(Maze new_maze) { currentGameLevel = new_maze; }
        public Player(Maze currentGameLevel) 
        { 
            this.currentGameLevel = currentGameLevel; 
            Health = 5;
            MaxHealth = 5;
            Speed = 3;
            MaxSpeed = 3;
            Damage = 2;
            Reach = 2;
            Actions = 3;
            MaxActions = 3;
            XPos = 0;
            YPos = 0;
            hasKey = false;
            isAlive = true;
        }
        public Player()
        {
            Health = 5;
            MaxHealth = 5;
            Speed = 3;
            MaxSpeed = 3;
            Damage = 2;
            Reach = 2;
            Actions = 3;
            MaxActions = 3;
            XPos = 0;
            YPos = 0;
            hasKey = false;
            isAlive = true;
            this.currentGameLevel = new Maze(this);
        }

        public void EndTurn()
        {
            if (isAlive)
            {
                this.Actions = MaxActions;
                this.currentGameLevel.GetCurrentRoom().MonsterTurn();
            }
        }

        private bool CanIAttack(int X, int Y)
        {
            int diff_x = Math.Abs(X - XPos);
            int diff_y = Math.Abs(Y - YPos);
            if (diff_x <= Reach && diff_y <= Reach) return true;
            return false;
        }

        public void AttackAction(int X, int Y)
        {
            if (Actions != 0 && isAlive)
            {
                if (CanIAttack(X, Y))
                {
                    Room room = currentGameLevel.GetCurrentRoom();
                    int index = room.findMonster(X, Y);
                    if (index != -1)
                    {
                        Monster monster = room.GetMonsters.ElementAt(index);
                        monster.SetHealth(monster.GetHealth() - Damage);
                        Actions = Actions - 1;
                    }
                }
            }
        }
        public void Move(int X, int Y)
        {
            if (Actions != 0 && isAlive) 
            {
                int diff_x = Math.Abs(X - XPos);
                int diff_y = Math.Abs(Y - YPos);
                if(diff_x <= Speed && diff_y <= Speed)
                {
                    Room room = currentGameLevel.GetCurrentRoom();
                    List<(int x, int y)> possible_placement = room.GetPossiblePlacement();
                    bool check = false;
                    foreach(var placement in possible_placement)
                    {
                        if(placement == (X, Y))
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check)
                    {
                        room.ChangePlace(XPos, YPos, X, Y);
                        Actions = Actions - 1;
                        XPos = X;
                        YPos = Y;
                    }
                }
            }
        }
        public void Death()
        {
            if(Health <= 0) isAlive = false;
        }
        public void Push(int X, int Y)
        { 
            if(Actions != 0 && isAlive)
            {
                if (this.CanIAttack(X,Y))
                {
                    Room room = currentGameLevel.GetCurrentRoom();
                    int index = room.findMonster(X, Y);
                    if (index != -1)
                    {
                        Monster monster = room.GetMonsters.ElementAt(index);
                        int monster_x = monster.GetXPos();
                        int monster_y = monster.GetYPos();
                        if(monster_x - XPos == 0 && monster_y - YPos != 0)
                        { 
                            if(monster_y - YPos == 1)
                            {
                                int value = (monster_y + 2 != room.GetSizeY()) ? 2 : (monster_y + 1 != room.GetSizeY()) ? 1 : 0;
                                if (monster_y - YPos < 0) value *= -1;
                                monster.SetYPos(monster_y + value);
                                Actions = Actions - 1;
                            }
                            else if(monster_y - YPos == 2)
                            {
                                int value = (monster_y + 1 != room.GetSizeY()) ? 1 : 0;
                                if (monster_y - YPos < 0) value *= -1;
                                monster.SetYPos(monster_y + value);
                                Actions -= 1;
                            }
                        }
                        if(monster_x -XPos != 0 && monster_y - YPos == 0)
                        {
                            if (monster_x - XPos == 1)
                            {
                                int value = (monster_x + 2 != room.GetSizeX()) ? 2 : (monster_x + 1 != room.GetSizeX()) ? 1 : 0;
                                if (monster_x - XPos < 0) value *= -1;
                                monster.SetXPos(monster_x + value);
                                Actions = Actions - 1;
                            }
                            else if (monster_x - XPos == 2)
                            {
                                int value = (monster_x + 1 != room.GetSizeX()) ? 1 : 0;
                                if (monster_x - XPos < 0) value *= -1;
                                monster.SetXPos(monster_x + value);
                                Actions -= 1;
                            }
                        }
                    }
                }
            }
        }
        public void SearchForKey()
        {
            Room room = this.GetCurrentGameLevel().GetCurrentRoom();
            if (!room.HasMonster())
            {
                List<Immovable> immovables = room.GetImmovables();
                foreach (Immovable immovable in immovables)
                {
                    if(immovable is Pedestal)
                    {
                        if(immovable.GetXPos() == XPos && immovable.GetYPos() == YPos)
                        {
                            this.hasKey = true;
                        }
                    }
                }
            }
        }
        public void OpenTheEntry()
        {
            Room room = this.GetCurrentGameLevel().GetCurrentRoom();
            if (!room.HasMonster() && isAlive)
            {
                List<Entries> entries = room.GetEntries();
                foreach(Entries entry in entries)
                {
                    if(entry.GetEntrieXY() == (XPos, YPos))
                    {
                        entry.PlayerWantToPassThrought();
                    }
                }
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
