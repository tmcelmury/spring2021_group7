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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void solitaire_game_Click(object sender, EventArgs e)
        {
            Solitaire solitaire = new();
            solitaire.InitializeComponent();
            solitaire.Show();
            Hide(); 
        }

        private void blackjack_starter_Click(object sender, EventArgs e)
        {
            BlackjackStart blackjackStart = new();
            blackjackStart.InitializeComponent();
            blackjackStart.Show();
            Hide();
        }
        
    }
}
