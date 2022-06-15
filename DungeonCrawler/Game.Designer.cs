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
            this.button1 = new System.Windows.Forms.Button();
            this.lblHealthValue = new System.Windows.Forms.Label();
            this.lblSpeedValue = new System.Windows.Forms.Label();
            this.lblActionValue = new System.Windows.Forms.Label();
            this.lblRoomValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHealth.Location = new System.Drawing.Point(8, 6);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(62, 21);
            this.lblHealth.TabIndex = 0;
            this.lblHealth.Text = "Health :";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSpeed.Location = new System.Drawing.Point(8, 27);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(64, 21);
            this.lblSpeed.TabIndex = 1;
            this.lblSpeed.Text = "Speed : ";
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblActions.Location = new System.Drawing.Point(8, 48);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(68, 21);
            this.lblActions.TabIndex = 2;
            this.lblActions.Text = "Actions :";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoom.Location = new System.Drawing.Point(8, 69);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(63, 21);
            this.lblRoom.TabIndex = 3;
            this.lblRoom.Text = "Room : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(358, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHealthValue
            // 
            this.lblHealthValue.AutoSize = true;
            this.lblHealthValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHealthValue.Location = new System.Drawing.Point(76, 6);
            this.lblHealthValue.Name = "lblHealthValue";
            this.lblHealthValue.Size = new System.Drawing.Size(19, 21);
            this.lblHealthValue.TabIndex = 5;
            this.lblHealthValue.Text = "1";
            // 
            // lblSpeedValue
            // 
            this.lblSpeedValue.AutoSize = true;
            this.lblSpeedValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSpeedValue.Location = new System.Drawing.Point(76, 27);
            this.lblSpeedValue.Name = "lblSpeedValue";
            this.lblSpeedValue.Size = new System.Drawing.Size(19, 21);
            this.lblSpeedValue.TabIndex = 6;
            this.lblSpeedValue.Text = "2";
            // 
            // lblActionValue
            // 
            this.lblActionValue.AutoSize = true;
            this.lblActionValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblActionValue.Location = new System.Drawing.Point(76, 48);
            this.lblActionValue.Name = "lblActionValue";
            this.lblActionValue.Size = new System.Drawing.Size(19, 21);
            this.lblActionValue.TabIndex = 7;
            this.lblActionValue.Text = "4";
            // 
            // lblRoomValue
            // 
            this.lblRoomValue.AutoSize = true;
            this.lblRoomValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoomValue.Location = new System.Drawing.Point(76, 69);
            this.lblRoomValue.Name = "lblRoomValue";
            this.lblRoomValue.Size = new System.Drawing.Size(19, 21);
            this.lblRoomValue.TabIndex = 8;
            this.lblRoomValue.Text = "5";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.lblRoomValue);
            this.Controls.Add(this.lblActionValue);
            this.Controls.Add(this.lblSpeedValue);
            this.Controls.Add(this.lblHealthValue);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblActions);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblHealth);
            this.Name = "Game";
            this.Text = "DungeonCrawler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblHealth;
        private Label lblSpeed;
        private Label lblActions;
        private Label lblRoom;
        private Button button1;
        private Label lblHealthValue;
        private Label lblSpeedValue;
        private Label lblActionValue;
        private Label lblRoomValue;
    }
}