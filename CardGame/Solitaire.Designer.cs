using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
  
    partial class Solitaire
    {

        private System.ComponentModel.IContainer components = null;

 
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel_title = new System.Windows.Forms.Panel();
            this.button_close = new System.Windows.Forms.Button();
            this.button_newgame = new System.Windows.Forms.Button();
            this.button_min = new System.Windows.Forms.Button();
            this.label_time = new System.Windows.Forms.Label();
            this.label_scores = new System.Windows.Forms.Label();
            this.panel_operate = new System.Windows.Forms.Panel();
            this.panel_title.SuspendLayout();
            this.SuspendLayout();

            // 
            // panel_title
            // 
            this.panel_title.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel_title.Controls.Add(this.button_close);
            this.panel_title.Controls.Add(this.button_newgame);
            this.panel_title.Controls.Add(this.button_min);
            this.panel_title.Controls.Add(this.label_time);
            this.panel_title.Controls.Add(this.label_scores);
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(1200, 32);
            this.panel_title.TabIndex = 0;
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(1100, 0);
            this.button_close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(100, 32);
            this.button_close.TabIndex = 0;
            this.button_close.TabStop = false;
            this.button_close.Text = "Exit";
            this.button_close.UseVisualStyleBackColor = true;
            // 
            // button_newgame
            // 
            this.button_newgame.Location = new System.Drawing.Point(895, 0);
            this.button_newgame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_newgame.Name = "button_newgame";
            this.button_newgame.Size = new System.Drawing.Size(100, 32);
            this.button_newgame.TabIndex = 0;
            this.button_newgame.TabStop = false;
            this.button_newgame.Text = "New Game";
            this.button_newgame.UseVisualStyleBackColor = true;
            // 
            // button_min
            // 
            this.button_min.Location = new System.Drawing.Point(997, 0);
            this.button_min.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_min.Name = "button_min";
            this.button_min.Padding = new System.Windows.Forms.Padding(1);
            this.button_min.Size = new System.Drawing.Size(100, 32);
            this.button_min.TabIndex = 0;
            this.button_min.TabStop = false;
            this.button_min.Text = "Minimize";
            this.button_min.UseVisualStyleBackColor = true;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(206, 8);
            this.label_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(66, 20);
            this.label_time.TabIndex = 1;
            this.label_time.Text = "Time：0";
            // 
            // label_scores
            // 
            this.label_scores.AutoSize = true;
            this.label_scores.Location = new System.Drawing.Point(88, 8);
            this.label_scores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_scores.Name = "label_scores";
            this.label_scores.Size = new System.Drawing.Size(70, 20);
            this.label_scores.TabIndex = 0;
            this.label_scores.Text = "Score：0";
            // 
            // panel_operate
            // 
            this.panel_operate.BackColor = System.Drawing.Color.Green;
            this.panel_operate.Location = new System.Drawing.Point(0, 32);
            this.panel_operate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel_operate.Name = "panel_operate";
            this.panel_operate.Size = new System.Drawing.Size(1200, 980);
            this.panel_operate.TabIndex = 1;
            // 
            // Solitaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 1102);
            this.Controls.Add(this.panel_operate);
            this.Controls.Add(this.panel_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Solitaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solitaire";
            this.Load += new System.EventHandler(this.Solitaire_Load);
            this.panel_title.ResumeLayout(false);
            this.panel_title.PerformLayout();
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Panel panel_title;
        private System.Windows.Forms.Panel panel_operate;
        private System.Windows.Forms.Label label_scores;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_min;
        private System.Windows.Forms.Button button_newgame;
       
    }
}


