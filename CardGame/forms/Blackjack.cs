
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
        private BlackjackController controller;

        public Blackjack(int numPlayers)
        {
            controller = new();
            controller.CreatePlayers(numPlayers);
            controller.CreateDeck();
        }

        public void InitializeComponent()
        {
            this.DealButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DealButton
            // 
            this.DealButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DealButton.Location = new System.Drawing.Point(505, 26);
            this.DealButton.Name = "DealButton";
            this.DealButton.Size = new System.Drawing.Size(75, 30);
            this.DealButton.TabIndex = 0;
            this.DealButton.Text = "Deal";
            this.DealButton.UseVisualStyleBackColor = true;
            // 
            // Blackjack
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(92)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1085, 583);
            this.Controls.Add(this.DealButton);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Blackjack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "BlackJack";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }
        //int cardCount = 0;
        /* private void DealButton_Click(object sender, EventArgs e)
        {
            Card card = deck.Pop();
            String cardfileName = "cards\\"+card.getPngDisplay()+".png";
            PictureBox cardBox = new PictureBox();
            cardBox.Image = Image.FromFile(cardfileName);
            cardBox.Location = new Point(350 + cardCount * 50, 50);
            cardBox.Size = new Size(100, 100);
            cardBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(cardBox);
            cardCount += 1;
        } */
    }
}
