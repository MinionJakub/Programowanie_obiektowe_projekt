namespace DungeonCrawler
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblActions = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblHealthValue = new System.Windows.Forms.Label();
            this.lblSpeedValue = new System.Windows.Forms.Label();
            this.lblActionValue = new System.Windows.Forms.Label();
            this.lblRoomValue = new System.Windows.Forms.Label();
            this.X_Move = new System.Windows.Forms.NumericUpDown();
            this.lblX_Move = new System.Windows.Forms.Label();
            this.lblY_Move = new System.Windows.Forms.Label();
            this.MoveButton = new System.Windows.Forms.Button();
            this.MapText = new System.Windows.Forms.RichTextBox();
            this.lblX_Attack = new System.Windows.Forms.Label();
            this.lblY_attack = new System.Windows.Forms.Label();
            this.X_Attack = new System.Windows.Forms.NumericUpDown();
            this.Y_Move = new System.Windows.Forms.NumericUpDown();
            this.Y_Attack = new System.Windows.Forms.NumericUpDown();
            this.Attack_Button = new System.Windows.Forms.Button();
            this.lblPlayerX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlayerY = new System.Windows.Forms.Label();
            this.YPlayerLabel = new System.Windows.Forms.Label();
            this.lblMazeValue = new System.Windows.Forms.Label();
            this.lblMaze = new System.Windows.Forms.Label();
            this.PushButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.EndOfTurnButton = new System.Windows.Forms.Button();
            this.HasKeyValue = new System.Windows.Forms.Label();
            this.HasKeyLabel = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.lblReachValue = new System.Windows.Forms.Label();
            this.ReachLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.X_Move)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_Attack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_Move)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_Attack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHealth.Location = new System.Drawing.Point(9, 8);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(78, 28);
            this.lblHealth.TabIndex = 0;
            this.lblHealth.Text = "Health :";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSpeed.Location = new System.Drawing.Point(9, 36);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(81, 28);
            this.lblSpeed.TabIndex = 1;
            this.lblSpeed.Text = "Speed : ";
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblActions.Location = new System.Drawing.Point(9, 64);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(86, 28);
            this.lblActions.TabIndex = 2;
            this.lblActions.Text = "Actions :";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoom.Location = new System.Drawing.Point(9, 92);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(78, 28);
            this.lblRoom.TabIndex = 3;
            this.lblRoom.Text = "Room : ";
            // 
            // lblHealthValue
            // 
            this.lblHealthValue.AutoSize = true;
            this.lblHealthValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHealthValue.Location = new System.Drawing.Point(87, 8);
            this.lblHealthValue.Name = "lblHealthValue";
            this.lblHealthValue.Size = new System.Drawing.Size(23, 28);
            this.lblHealthValue.TabIndex = 5;
            this.lblHealthValue.Text = "1";
            // 
            // lblSpeedValue
            // 
            this.lblSpeedValue.AutoSize = true;
            this.lblSpeedValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSpeedValue.Location = new System.Drawing.Point(87, 36);
            this.lblSpeedValue.Name = "lblSpeedValue";
            this.lblSpeedValue.Size = new System.Drawing.Size(23, 28);
            this.lblSpeedValue.TabIndex = 6;
            this.lblSpeedValue.Text = "2";
            // 
            // lblActionValue
            // 
            this.lblActionValue.AutoSize = true;
            this.lblActionValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblActionValue.Location = new System.Drawing.Point(87, 64);
            this.lblActionValue.Name = "lblActionValue";
            this.lblActionValue.Size = new System.Drawing.Size(23, 28);
            this.lblActionValue.TabIndex = 7;
            this.lblActionValue.Text = "4";
            // 
            // lblRoomValue
            // 
            this.lblRoomValue.AutoSize = true;
            this.lblRoomValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoomValue.Location = new System.Drawing.Point(87, 92);
            this.lblRoomValue.Name = "lblRoomValue";
            this.lblRoomValue.Size = new System.Drawing.Size(23, 28);
            this.lblRoomValue.TabIndex = 8;
            this.lblRoomValue.Text = "5";
            // 
            // X_Move
            // 
            this.X_Move.Location = new System.Drawing.Point(9, 155);
            this.X_Move.Name = "X_Move";
            this.X_Move.Size = new System.Drawing.Size(39, 27);
            this.X_Move.TabIndex = 9;
            // 
            // lblX_Move
            // 
            this.lblX_Move.AutoSize = true;
            this.lblX_Move.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblX_Move.Location = new System.Drawing.Point(12, 124);
            this.lblX_Move.Name = "lblX_Move";
            this.lblX_Move.Size = new System.Drawing.Size(24, 28);
            this.lblX_Move.TabIndex = 10;
            this.lblX_Move.Text = "X";
            // 
            // lblY_Move
            // 
            this.lblY_Move.AutoSize = true;
            this.lblY_Move.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblY_Move.Location = new System.Drawing.Point(57, 124);
            this.lblY_Move.Name = "lblY_Move";
            this.lblY_Move.Size = new System.Drawing.Size(23, 28);
            this.lblY_Move.TabIndex = 11;
            this.lblY_Move.Text = "Y";
            // 
            // MoveButton
            // 
            this.MoveButton.Location = new System.Drawing.Point(102, 155);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(94, 29);
            this.MoveButton.TabIndex = 13;
            this.MoveButton.Text = "Move";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // MapText
            // 
            this.MapText.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MapText.Location = new System.Drawing.Point(751, 12);
            this.MapText.Name = "MapText";
            this.MapText.Size = new System.Drawing.Size(590, 1019);
            this.MapText.TabIndex = 15;
            this.MapText.Text = "";
            // 
            // lblX_Attack
            // 
            this.lblX_Attack.AutoSize = true;
            this.lblX_Attack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblX_Attack.Location = new System.Drawing.Point(9, 185);
            this.lblX_Attack.Name = "lblX_Attack";
            this.lblX_Attack.Size = new System.Drawing.Size(24, 28);
            this.lblX_Attack.TabIndex = 16;
            this.lblX_Attack.Text = "X";
            // 
            // lblY_attack
            // 
            this.lblY_attack.AutoSize = true;
            this.lblY_attack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblY_attack.Location = new System.Drawing.Point(57, 185);
            this.lblY_attack.Name = "lblY_attack";
            this.lblY_attack.Size = new System.Drawing.Size(23, 28);
            this.lblY_attack.TabIndex = 17;
            this.lblY_attack.Text = "Y";
            // 
            // X_Attack
            // 
            this.X_Attack.Location = new System.Drawing.Point(9, 216);
            this.X_Attack.Name = "X_Attack";
            this.X_Attack.Size = new System.Drawing.Size(39, 27);
            this.X_Attack.TabIndex = 18;
            // 
            // Y_Move
            // 
            this.Y_Move.Location = new System.Drawing.Point(57, 155);
            this.Y_Move.Name = "Y_Move";
            this.Y_Move.Size = new System.Drawing.Size(39, 27);
            this.Y_Move.TabIndex = 12;
            // 
            // Y_Attack
            // 
            this.Y_Attack.Location = new System.Drawing.Point(57, 216);
            this.Y_Attack.Name = "Y_Attack";
            this.Y_Attack.Size = new System.Drawing.Size(39, 27);
            this.Y_Attack.TabIndex = 19;
            // 
            // Attack_Button
            // 
            this.Attack_Button.Location = new System.Drawing.Point(103, 218);
            this.Attack_Button.Name = "Attack_Button";
            this.Attack_Button.Size = new System.Drawing.Size(94, 29);
            this.Attack_Button.TabIndex = 20;
            this.Attack_Button.Text = "Attack";
            this.Attack_Button.UseVisualStyleBackColor = true;
            this.Attack_Button.Click += new System.EventHandler(this.Attack_Button_Click);
            // 
            // lblPlayerX
            // 
            this.lblPlayerX.AutoSize = true;
            this.lblPlayerX.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerX.Location = new System.Drawing.Point(180, 9);
            this.lblPlayerX.Name = "lblPlayerX";
            this.lblPlayerX.Size = new System.Drawing.Size(23, 28);
            this.lblPlayerX.TabIndex = 22;
            this.lblPlayerX.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(141, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 28);
            this.label2.TabIndex = 21;
            this.label2.Text = "X :";
            // 
            // lblPlayerY
            // 
            this.lblPlayerY.AutoSize = true;
            this.lblPlayerY.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerY.Location = new System.Drawing.Point(180, 37);
            this.lblPlayerY.Name = "lblPlayerY";
            this.lblPlayerY.Size = new System.Drawing.Size(23, 28);
            this.lblPlayerY.TabIndex = 24;
            this.lblPlayerY.Text = "1";
            // 
            // YPlayerLabel
            // 
            this.YPlayerLabel.AutoSize = true;
            this.YPlayerLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YPlayerLabel.Location = new System.Drawing.Point(141, 36);
            this.YPlayerLabel.Name = "YPlayerLabel";
            this.YPlayerLabel.Size = new System.Drawing.Size(32, 28);
            this.YPlayerLabel.TabIndex = 23;
            this.YPlayerLabel.Text = "Y :";
            // 
            // lblMazeValue
            // 
            this.lblMazeValue.AutoSize = true;
            this.lblMazeValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMazeValue.Location = new System.Drawing.Point(185, 92);
            this.lblMazeValue.Name = "lblMazeValue";
            this.lblMazeValue.Size = new System.Drawing.Size(23, 28);
            this.lblMazeValue.TabIndex = 26;
            this.lblMazeValue.Text = "2";
            // 
            // lblMaze
            // 
            this.lblMaze.AutoSize = true;
            this.lblMaze.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMaze.Location = new System.Drawing.Point(121, 92);
            this.lblMaze.Name = "lblMaze";
            this.lblMaze.Size = new System.Drawing.Size(73, 28);
            this.lblMaze.TabIndex = 25;
            this.lblMaze.Text = "Maze : ";
            // 
            // PushButton
            // 
            this.PushButton.Location = new System.Drawing.Point(203, 218);
            this.PushButton.Name = "PushButton";
            this.PushButton.Size = new System.Drawing.Size(94, 29);
            this.PushButton.TabIndex = 27;
            this.PushButton.Text = "Push";
            this.PushButton.UseVisualStyleBackColor = true;
            this.PushButton.Click += new System.EventHandler(this.PushButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(9, 258);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(94, 29);
            this.SearchButton.TabIndex = 28;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(103, 258);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(94, 29);
            this.OpenButton.TabIndex = 29;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // EndOfTurnButton
            // 
            this.EndOfTurnButton.Location = new System.Drawing.Point(203, 258);
            this.EndOfTurnButton.Name = "EndOfTurnButton";
            this.EndOfTurnButton.Size = new System.Drawing.Size(94, 29);
            this.EndOfTurnButton.TabIndex = 30;
            this.EndOfTurnButton.Text = "End Turn";
            this.EndOfTurnButton.UseVisualStyleBackColor = true;
            this.EndOfTurnButton.Click += new System.EventHandler(this.EndOfTurnButton_Click);
            // 
            // HasKeyValue
            // 
            this.HasKeyValue.AutoSize = true;
            this.HasKeyValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HasKeyValue.Location = new System.Drawing.Point(180, 65);
            this.HasKeyValue.Name = "HasKeyValue";
            this.HasKeyValue.Size = new System.Drawing.Size(23, 28);
            this.HasKeyValue.TabIndex = 32;
            this.HasKeyValue.Text = "1";
            // 
            // HasKeyLabel
            // 
            this.HasKeyLabel.AutoSize = true;
            this.HasKeyLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HasKeyLabel.Location = new System.Drawing.Point(121, 64);
            this.HasKeyLabel.Name = "HasKeyLabel";
            this.HasKeyLabel.Size = new System.Drawing.Size(53, 28);
            this.HasKeyLabel.TabIndex = 31;
            this.HasKeyLabel.Text = "Key :";
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(203, 153);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(94, 29);
            this.NewGameButton.TabIndex = 33;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // lblReachValue
            // 
            this.lblReachValue.AutoSize = true;
            this.lblReachValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblReachValue.Location = new System.Drawing.Point(281, 12);
            this.lblReachValue.Name = "lblReachValue";
            this.lblReachValue.Size = new System.Drawing.Size(23, 28);
            this.lblReachValue.TabIndex = 35;
            this.lblReachValue.Text = "1";
            // 
            // ReachLabel
            // 
            this.ReachLabel.AutoSize = true;
            this.ReachLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReachLabel.Location = new System.Drawing.Point(203, 12);
            this.ReachLabel.Name = "ReachLabel";
            this.ReachLabel.Size = new System.Drawing.Size(72, 28);
            this.ReachLabel.TabIndex = 34;
            this.ReachLabel.Text = "Reach :";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 1055);
            this.Controls.Add(this.lblReachValue);
            this.Controls.Add(this.ReachLabel);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.HasKeyValue);
            this.Controls.Add(this.HasKeyLabel);
            this.Controls.Add(this.EndOfTurnButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.PushButton);
            this.Controls.Add(this.lblMazeValue);
            this.Controls.Add(this.lblMaze);
            this.Controls.Add(this.lblPlayerY);
            this.Controls.Add(this.YPlayerLabel);
            this.Controls.Add(this.lblPlayerX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Attack_Button);
            this.Controls.Add(this.Y_Attack);
            this.Controls.Add(this.X_Attack);
            this.Controls.Add(this.lblY_attack);
            this.Controls.Add(this.lblX_Attack);
            this.Controls.Add(this.MapText);
            this.Controls.Add(this.MoveButton);
            this.Controls.Add(this.Y_Move);
            this.Controls.Add(this.lblY_Move);
            this.Controls.Add(this.lblX_Move);
            this.Controls.Add(this.X_Move);
            this.Controls.Add(this.lblRoomValue);
            this.Controls.Add(this.lblActionValue);
            this.Controls.Add(this.lblSpeedValue);
            this.Controls.Add(this.lblHealthValue);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblActions);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblHealth);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Game";
            this.Text = "DungeonCrawler";
            ((System.ComponentModel.ISupportInitialize)(this.X_Move)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_Attack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_Move)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_Attack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblHealth;
        private Label lblSpeed;
        private Label lblActions;
        private Label lblRoom;
        private Label lblHealthValue;
        private Label lblSpeedValue;
        private Label lblActionValue;
        private Label lblRoomValue;
        private NumericUpDown X_Move;
        private Label lblX_Move;
        private Label lblY_Move;
        private Button MoveButton;
        private RichTextBox MapText;
        private Label lblX_Attack;
        private Label lblY_attack;
        private NumericUpDown X_Attack;
        private NumericUpDown Y_Move;
        private NumericUpDown Y_Attack;
        private Button Attack_Button;
        private Label lblPlayerX;
        private Label label2;
        private Label lblPlayerY;
        private Label YPlayerLabel;
        private Label lblMazeValue;
        private Label lblMaze;
        private Button PushButton;
        private Button SearchButton;
        private Button OpenButton;
        private Button EndOfTurnButton;
        private Label HasKeyValue;
        private Label HasKeyLabel;
        private Button NewGameButton;
        private Label lblReachValue;
        private Label ReachLabel;
    }
}