using Engine;

namespace DungeonCrawler
{
    public partial class Game : Form
    {
        private Player _player;
        private long Level; 
        public Game()
        {
            InitializeComponent();
            _player = new Player();
            Level = 0;
            lblHealthValue.Text = _player.GetHealth().ToString();
            lblSpeedValue.Text = _player.GetSpeed().ToString();
            lblActionValue.Text = _player.GetActions().ToString();
            lblPlayerX.Text = _player.GetPlayerXPos().ToString();
            lblPlayerY.Text = _player.GetPlayerYPos().ToString();
            lblMazeValue.Text = Level.ToString();
            lblReachValue.Text = _player.GetReach().ToString();
            HasKeyValue.Text = _player.GetHasKey().ToString();
            lblRoomValue.Text = _player.GetCurrentGameLevel().RoomNumber().ToString();
            X_Move.Minimum = 0;
            X_Move.Maximum = _player.GetCurrentGameLevel().GetCurrentRoom().GetSizeX();
            Y_Move.Minimum = 0;
            Y_Move.Maximum = _player.GetCurrentGameLevel().GetCurrentRoom().GetSizeY();
            UpdateMap();
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            int X = (int)X_Move.Value;
            int Y = (int)Y_Move.Value;
            _player.Move(X, Y);
            X_Move.Value = 0;
            Y_Move.Value = 0;
            lblActionValue.Text = _player.GetActions().ToString();
            UpdateMap();
        }

        private void UpdateMap()
        {
            Room room = _player.GetCurrentGameLevel().GetCurrentRoom();
            room.FillMap();
            char[,] map = _player.GetCurrentGameLevel().GetMap();
            string Tekst = "  X";
            for (int j = 0; j < room.GetSizeX(); j++) Tekst += j/10;
            Tekst += "\n  X";
            for (int j = 0; j < room.GetSizeX(); j++) Tekst += j % 10;
            Tekst += "\n";
            for (int i = 0; i < room.GetSizeY() + 2; i++)
            {
                if (i != 0 && i != room.GetSizeY() + 1)
                {
                    Tekst += (i-1) / 10;
                    Tekst += (i-1) % 10;
                }
                else if (i == 0) Tekst += "YY";
                else Tekst += "  ";
                for (int j = 0; j < room.GetSizeX() + 2;j++)
                {
                    Tekst += map[i,j].ToString();
                }
                Tekst += "\n";
            }
            MapText.Text = Tekst;
        }

        private void Attack_Button_Click(object sender, EventArgs e)
        {
            int X = (int)X_Attack.Value;
            int Y = (int)Y_Attack.Value;
            _player.AttackAction(X, Y);
            X_Attack.Value = 0;
            Y_Attack.Value = 0;
            lblActionValue.Text = _player.GetActions().ToString();
            UpdateMap();
        }

        private void PushButton_Click(object sender, EventArgs e)
        {
            int X = (int)X_Attack.Value;
            int Y = (int)Y_Attack.Value;
            _player.Push(X, Y);
            X_Attack.Value = 0;
            Y_Attack.Value = 0;
            lblActionValue.Text = _player.GetActions().ToString();
            UpdateMap();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _player.SearchForKey();
            HasKeyValue.Text = _player.GetHasKey().ToString();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            Maze maze = _player.GetCurrentGameLevel();
            _player.OpenTheEntry();
            if(maze != _player.GetCurrentGameLevel())
            {
                Level += 1;
                lblMazeValue.Text = Level.ToString();
            }
            UpdateMap();
            lblHealthValue.Text = _player.GetHealth().ToString();
            lblSpeedValue.Text = _player.GetSpeed().ToString();
            lblActionValue.Text = _player.GetActions().ToString();
            lblPlayerX.Text = _player.GetPlayerXPos().ToString();
            lblPlayerY.Text = _player.GetPlayerYPos().ToString();
            lblMazeValue.Text = Level.ToString();
            HasKeyValue.Text = _player.GetHasKey().ToString();
            lblRoomValue.Text = _player.GetCurrentGameLevel().RoomNumber().ToString();
        }

        private void EndOfTurnButton_Click(object sender, EventArgs e)
        {
            _player.EndTurn();
            UpdateMap();
            lblHealthValue.Text = _player.GetHealth().ToString();
            lblSpeedValue.Text = _player.GetSpeed().ToString();
            lblActionValue.Text = _player.GetActions().ToString();
            lblPlayerX.Text = _player.GetPlayerXPos().ToString();
            lblPlayerY.Text = _player.GetPlayerYPos().ToString();
            lblMazeValue.Text = Level.ToString();
            HasKeyValue.Text = _player.GetHasKey().ToString();
            lblRoomValue.Text = _player.GetCurrentGameLevel().RoomNumber().ToString();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _player = new Player();
            Level = 0;
            lblHealthValue.Text = _player.GetHealth().ToString();
            lblSpeedValue.Text = _player.GetSpeed().ToString();
            lblActionValue.Text = _player.GetActions().ToString();
            lblPlayerX.Text = _player.GetPlayerXPos().ToString();
            lblPlayerY.Text = _player.GetPlayerYPos().ToString();
            lblMazeValue.Text = Level.ToString();
            HasKeyValue.Text = _player.GetHasKey().ToString();
            lblRoomValue.Text = _player.GetCurrentGameLevel().RoomNumber().ToString();
            X_Move.Minimum = 0;
            X_Move.Maximum = _player.GetCurrentGameLevel().GetCurrentRoom().GetSizeX();
            Y_Move.Minimum = 0;
            Y_Move.Maximum = _player.GetCurrentGameLevel().GetCurrentRoom().GetSizeY();
            UpdateMap();
        }
    }
}