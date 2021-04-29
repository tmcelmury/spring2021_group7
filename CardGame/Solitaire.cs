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
    public partial class Solitaire : Form
    {
        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Solitaire
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(92)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(963, 548);
            this.Name = "Solitaire";
            this.ResumeLayout(false);

        }
    }
}
