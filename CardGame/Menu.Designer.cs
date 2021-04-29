
namespace CardGame
{
    partial class Menu
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
            this.blackjack_starter = new System.Windows.Forms.Button();
            this.solitaire_game = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.subtitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // blackjack_starter
            // 
            this.blackjack_starter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blackjack_starter.Location = new System.Drawing.Point(516, 392);
            this.blackjack_starter.Margin = new System.Windows.Forms.Padding(2);
            this.blackjack_starter.Name = "blackjack_starter";
            this.blackjack_starter.Size = new System.Drawing.Size(199, 54);
            this.blackjack_starter.TabIndex = 0;
            this.blackjack_starter.Text = "BlackJack";
            this.blackjack_starter.UseVisualStyleBackColor = true;
            this.blackjack_starter.Click += new System.EventHandler(this.blackjack_starter_Click);
            // 
            // solitaire_game
            // 
            this.solitaire_game.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.solitaire_game.Font = new System.Drawing.Font("Unispace", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.solitaire_game.Location = new System.Drawing.Point(516, 266);
            this.solitaire_game.Margin = new System.Windows.Forms.Padding(2);
            this.solitaire_game.Name = "solitaire_game";
            this.solitaire_game.Size = new System.Drawing.Size(199, 54);
            this.solitaire_game.TabIndex = 1;
            this.solitaire_game.Text = "Solitaire";
            this.solitaire_game.UseVisualStyleBackColor = true;
            this.solitaire_game.Click += new System.EventHandler(this.solitaire_game_Click);
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.title.AutoSize = true;
            this.title.Enabled = false;
            this.title.Font = new System.Drawing.Font("Sitka Heading", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.title.Location = new System.Drawing.Point(442, 24);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(366, 101);
            this.title.TabIndex = 2;
            this.title.Text = "Card Game";
            // 
            // subtitle
            // 
            this.subtitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtitle.AutoSize = true;
            this.subtitle.Font = new System.Drawing.Font("Sitka Heading", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subtitle.ForeColor = System.Drawing.Color.White;
            this.subtitle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.subtitle.Location = new System.Drawing.Point(452, 125);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(338, 53);
            this.subtitle.TabIndex = 3;
            this.subtitle.Text = "Group 7 Spring 2021";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1223, 587);
            this.Controls.Add(this.subtitle);
            this.Controls.Add(this.title);
            this.Controls.Add(this.solitaire_game);
            this.Controls.Add(this.blackjack_starter);
            this.Font = new System.Drawing.Font("Unispace", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HelpButton = true;
            this.Name = "Menu";
            this.Text = "CardGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button blackjack_starter;
        private System.Windows.Forms.Button solitaire_game;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label subtitle;
    }
}

