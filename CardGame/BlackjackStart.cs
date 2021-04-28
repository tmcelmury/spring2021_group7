using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class BlackjackStart : Form
    {
        public void InitializeComponent()
        {
            this.playerCount = new System.Windows.Forms.ComboBox();
            this.playerQuestion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playerCount
            // 
            this.playerCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerCount.FormattingEnabled = true;
            this.playerCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.playerCount.Location = new System.Drawing.Point(397, 231);
            this.playerCount.Name = "playerCount";
            this.playerCount.Size = new System.Drawing.Size(151, 28);
            this.playerCount.TabIndex = 0;
            // 
            // playerQuestion
            // 
            this.playerQuestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerQuestion.AutoSize = true;
            this.playerQuestion.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playerQuestion.ForeColor = System.Drawing.Color.White;
            this.playerQuestion.Location = new System.Drawing.Point(319, 164);
            this.playerQuestion.Name = "playerQuestion";
            this.playerQuestion.Size = new System.Drawing.Size(308, 31);
            this.playerQuestion.TabIndex = 1;
            this.playerQuestion.Text = "How many players are there?";
            // 
            // BlackjackStart
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(934, 545);
            this.Controls.Add(this.playerQuestion);
            this.Controls.Add(this.playerCount);
            this.Name = "BlackjackStart";
            this.Text = "Number of Players";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
