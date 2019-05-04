﻿namespace Materialform
{
    partial class Form2
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.input = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.output = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialFlatButton3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
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
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Please enter the location of your dump                      ";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(340, 94);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(32, 36);
            this.materialFlatButton1.TabIndex = 5;
            this.materialFlatButton1.Text = "...";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // input
            // 
            this.input.Depth = 0;
            this.input.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.input.Hint = "";
            this.input.Location = new System.Drawing.Point(20, 94);
            this.input.MaxLength = 32767;
            this.input.MouseState = MaterialSkin.MouseState.HOVER;
            this.input.Name = "input";
            this.input.PasswordChar = '\0';
            this.input.SelectedText = "";
            this.input.SelectionLength = 0;
            this.input.SelectionStart = 0;
            this.input.Size = new System.Drawing.Size(314, 23);
            this.input.TabIndex = 6;
            this.input.TabStop = false;
            this.input.Text = "c:\\location\\of\\dump";
            this.input.UseSystemPasswordChar = false;
            this.input.Click += new System.EventHandler(this.input_Click);
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.Location = new System.Drawing.Point(341, 161);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(32, 36);
            this.materialFlatButton2.TabIndex = 7;
            this.materialFlatButton2.Text = "...";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
            // 
            // output
            // 
            this.output.Depth = 0;
            this.output.Hint = "";
            this.output.Location = new System.Drawing.Point(20, 161);
            this.output.MaxLength = 32767;
            this.output.MouseState = MaterialSkin.MouseState.HOVER;
            this.output.Name = "output";
            this.output.PasswordChar = '\0';
            this.output.SelectedText = "";
            this.output.SelectionLength = 0;
            this.output.SelectionStart = 0;
            this.output.Size = new System.Drawing.Size(314, 23);
            this.output.TabIndex = 8;
            this.output.TabStop = false;
            this.output.Text = "c:\\output\\location.iso";
            this.output.UseSystemPasswordChar = false;
            this.output.Click += new System.EventHandler(this.output_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(16, 136);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(351, 19);
            this.materialLabel2.TabIndex = 9;
            this.materialLabel2.Text = "Please enter where you want the iso to be stored    ";
            // 
            // materialFlatButton3
            // 
            this.materialFlatButton3.AutoSize = true;
            this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton3.Depth = 0;
            this.materialFlatButton3.Icon = null;
            this.materialFlatButton3.Location = new System.Drawing.Point(20, 209);
            this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton3.Name = "materialFlatButton3";
            this.materialFlatButton3.Primary = false;
            this.materialFlatButton3.Size = new System.Drawing.Size(171, 36);
            this.materialFlatButton3.TabIndex = 10;
            this.materialFlatButton3.Text = "Convert dump to iso";
            this.materialFlatButton3.UseVisualStyleBackColor = true;
            this.materialFlatButton3.Click += new System.EventHandler(this.materialFlatButton3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 270);
            this.Controls.Add(this.materialFlatButton3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.output);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.input);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.materialLabel1);
            this.Name = "Form2";
            this.Text = "Dump To Iso";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialSingleLineTextField input;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialSingleLineTextField output;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton3;
    }
}