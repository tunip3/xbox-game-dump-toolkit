namespace Materialform
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IP = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.vspaircode = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.gamename = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // IP
            // 
            this.IP.Depth = 0;
            this.IP.Hint = "";
            this.IP.Location = new System.Drawing.Point(16, 91);
            this.IP.MaxLength = 32767;
            this.IP.MouseState = MaterialSkin.MouseState.HOVER;
            this.IP.Name = "IP";
            this.IP.PasswordChar = '\0';
            this.IP.SelectedText = "";
            this.IP.SelectionLength = 0;
            this.IP.SelectionStart = 0;
            this.IP.Size = new System.Drawing.Size(356, 23);
            this.IP.TabIndex = 0;
            this.IP.TabStop = false;
            this.IP.Text = "IP";
            this.IP.UseSystemPasswordChar = false;
            this.IP.Click += new System.EventHandler(this.IP_Click);
            // 
            // vspaircode
            // 
            this.vspaircode.Depth = 0;
            this.vspaircode.Hint = "";
            this.vspaircode.Location = new System.Drawing.Point(16, 139);
            this.vspaircode.MaxLength = 32767;
            this.vspaircode.MouseState = MaterialSkin.MouseState.HOVER;
            this.vspaircode.Name = "vspaircode";
            this.vspaircode.PasswordChar = '\0';
            this.vspaircode.SelectedText = "";
            this.vspaircode.SelectionLength = 0;
            this.vspaircode.SelectionStart = 0;
            this.vspaircode.Size = new System.Drawing.Size(356, 23);
            this.vspaircode.TabIndex = 1;
            this.vspaircode.TabStop = false;
            this.vspaircode.Text = "vspaircode";
            this.vspaircode.UseSystemPasswordChar = false;
            this.vspaircode.Click += new System.EventHandler(this.materialSingleLineTextField2_Click);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(16, 219);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(152, 36);
            this.materialFlatButton1.TabIndex = 2;
            this.materialFlatButton1.Text = "Dump game to usb";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(16, 69);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(356, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Please enter your Xbox hostname or IP                      ";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(16, 117);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(355, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Please enter your visual studio pairing pin                 ";
            this.materialLabel2.Click += new System.EventHandler(this.materialLabel2_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(16, 165);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(356, 19);
            this.materialLabel3.TabIndex = 5;
            this.materialLabel3.Text = "Please enter the name of the game you are dumping";
            // 
            // gamename
            // 
            this.gamename.Depth = 0;
            this.gamename.Hint = "";
            this.gamename.Location = new System.Drawing.Point(16, 187);
            this.gamename.MaxLength = 32767;
            this.gamename.MouseState = MaterialSkin.MouseState.HOVER;
            this.gamename.Name = "gamename";
            this.gamename.PasswordChar = '\0';
            this.gamename.SelectedText = "";
            this.gamename.SelectionLength = 0;
            this.gamename.SelectionStart = 0;
            this.gamename.Size = new System.Drawing.Size(356, 23);
            this.gamename.TabIndex = 6;
            this.gamename.TabStop = false;
            this.gamename.Text = "gamename";
            this.gamename.UseSystemPasswordChar = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 270);
            this.Controls.Add(this.gamename);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.vspaircode);
            this.Controls.Add(this.IP);
            this.Name = "Form1";
            this.Text = "Game Dumper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField IP;
        private MaterialSkin.Controls.MaterialSingleLineTextField vspaircode;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField gamename;
    }
}

