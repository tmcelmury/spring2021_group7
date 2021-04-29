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
    public partial class Blackjack : Form
    {
        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Blackjack
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(92)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(997, 557);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Blackjack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "BlackJack";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

    }
}
