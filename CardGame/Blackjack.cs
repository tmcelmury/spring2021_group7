
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
        BlackjackController controller = new BlackjackController();
        Stack<Card> deck;
        public void InitializeComponent()
        {
            deck = controller.getDeck().getDeck();
            this.DealButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DealButton
            // 
            this.DealButton.Location = new System.Drawing.Point(461, 13);
            this.DealButton.Name = "DealButton";
            this.DealButton.Size = new System.Drawing.Size(75, 23);
            this.DealButton.TabIndex = 0;
            this.DealButton.Text = "Deal";
            this.DealButton.UseVisualStyleBackColor = true;
            this.DealButton.Click += new System.EventHandler(this.DealButton_Click);
            // 
            // Blackjack
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(92)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(997, 557);
            this.Controls.Add(this.DealButton);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Blackjack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "BlackJack";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }
        int cardCount = 0;
        private void DealButton_Click(object sender, EventArgs e)
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
        }
    }
}
