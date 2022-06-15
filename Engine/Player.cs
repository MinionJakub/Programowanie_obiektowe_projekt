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

        public int GetHealth() { return Health; }
        public int GetSpeed() { return Speed; }
        public void SetHealth (int value) { if(value < MaxHealth) Health = value; }
        public void SetSpeed (int value) { if(value < MaxSpeed) Speed = value; }
        public bool GetHasKey() { return hasKey; }
        public void SetHasKey (bool value) { hasKey = value; }

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
        }
    }
}
