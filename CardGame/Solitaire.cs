using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Solitaire : Form
    {
        public Solitaire()
        {
            InitializeComponent();
        }
        class card
        {
            public int index;
            public bool show_face;
            public int pile;
            public int index_of_pile;
            public Point left_up_point;
        }
        static int H = 30;
        static int W = 30;
        private Point point_mousedown_on_panel_title;
        Point point_mousedown_on_panel_operate;
        Point[] point_14_pile_initial_pozition = new Point[14];
        ImageList imagelist;
        Bitmap bmp_draw;
        Bitmap bmp_show;
        card[] card_pack = new card[52];
        Timer timer_draw;
        Timer timer_time;
        bool is_ready_draw;
        int selected_index;
        int old_pile;
        ArrayList[] arylist_14_pile = new ArrayList[14];
      

        void shuffle()
        {
            ArrayList arraylist = new ArrayList();
            for (int i = 0; i < 52; i++)
            {
                arraylist.Add(i);
            }
            Random rd = new Random();
            int n;
            for (int i = 0; i < 52; i++)
            {
                card_pack[i] = new card();
                n = rd.Next(0, arraylist.Count);
                card_pack[i].index = (int)arraylist[n];
                arraylist.RemoveAt(n);
            }
        }


        private void Solitaire_Load(object sender, EventArgs e)        
        {
            panel_title.MouseDown += panel_title_MouseDown;
            panel_title.MouseMove += panel_title_MouseMove;
            button_min.Click += button_min_Click;
            button_close.Click += button_close_Click;
            button_newgame.Click += button_newgame_Click;
            
            panel_operate.MouseDown += panel_operate_MouseDown;
            panel_operate.MouseMove += panel_operate_MouseMove;
            panel_operate.MouseUp += panel_operate_MouseUp;
            panel_operate.MouseDoubleClick += panel_operate_MouseDoubleClick;
            is_ready_draw = false;
            timer_draw = new Timer();
            timer_draw.Interval = 10;
            timer_draw.Tick += timer_draw_Tick;
            timer_time = new Timer();
            timer_time.Interval = 1000;
            timer_time.Tick += timer_time_Tick;
            ini_point_14_pile_initial_pozition();
            if (ini_imagelist())
            {
                selected_index = -1;
                shuffle();
                dealCards();
                sort_arylist_14_pile();
                draw();
            }
            else
            {
                MessageBox.Show("Can not find card images!");
                this.Close();
            }
            is_ready_draw = true;
            timer_draw.Enabled = true;
        }


        private void draw()
        {
            if (is_ready_draw == false)
            {
                return;
            }
            bmp_draw = new Bitmap(panel_operate.Width, panel_operate.Height);
            Graphics g = Graphics.FromImage(bmp_draw);
            Brush brush = new SolidBrush(Color.Gray);
            g.FillRectangle(brush, new Rectangle(0, 0, panel_operate.Width, panel_operate.Height));
            if (arylist_14_pile[0].Count != 0)
            {
                g.DrawImage(imagelist.Images[52], point_14_pile_initial_pozition[0]);
            }
            if (arylist_14_pile[1].Count != 0)
            {
                ArrayList ary_temp_back = new ArrayList();
                ArrayList ary_temp_face = new ArrayList();
                for (int i = 0; i < arylist_14_pile[1].Count; i++)
                {
                    card card_temp = (card)arylist_14_pile[1][i];
                    if (card_temp.show_face == true)
                    {
                        _ = ary_temp_face.Add(card_temp);
                    }
                    else
                    {
                        ary_temp_back.Add(card_temp);
                    }
                }
                if (ary_temp_back.Count > 0)
                {
                    g.DrawImage(imagelist.Images[52], point_14_pile_initial_pozition[1]);
                }
                for (int i = 0; i < ary_temp_face.Count; i++)
                {
                    card card_temp = (card)ary_temp_face[i];
                    g.DrawImage(imagelist.Images[card_temp.index], new Point(point_14_pile_initial_pozition[1].X + i * W, point_14_pile_initial_pozition[1].Y));
                }
            }
            for (int i = 2; i <= 5; i++)
            {
                if (arylist_14_pile[i].Count != 0)
                {
                    card card_temp = (card)arylist_14_pile[i][arylist_14_pile[i].Count - 1];
                    g.DrawImage(imagelist.Images[card_temp.index], point_14_pile_initial_pozition[i]);
                }
            }
            for (int i = 6; i <= 13; i++)
            {
                if (arylist_14_pile[i].Count != 0)
                {
                    for (int j = 0; j < arylist_14_pile[i].Count; j++)
                    {
                        card card_temp = (card)arylist_14_pile[i][j];
                        if (card_temp.show_face == true)
                        {
                            g.DrawImage(imagelist.Images[card_temp.index], new Point(point_14_pile_initial_pozition[i].X, point_14_pile_initial_pozition[i].Y + H * j));
                        }
                        else if (card_temp.show_face == false)
                        {
                            g.DrawImage(imagelist.Images[52], new Point(point_14_pile_initial_pozition[i].X, point_14_pile_initial_pozition[i].Y + H * j));
                        }
                    }
                }
            }
            bmp_show = bmp_draw;
            Graphics g_panel_operate = panel_operate.CreateGraphics();
            g_panel_operate.DrawImage(bmp_show, 0, 0);
            bmp_draw.Dispose();
            brush.Dispose();
            g.Dispose();
            g_panel_operate.Dispose();
            GC.Collect();
        }

        private void sort_arylist_14_pile()
        {
            for (int i = 0; i < 14; i++)
            {
                int index_temp = 0;
                arylist_14_pile[i] = new ArrayList();
                ArrayList arylist_temp = new ArrayList();
                for (int j = 0; j < 52; j++)
                {
                    if (card_pack[j].pile == i)
                    {
                        arylist_14_pile[i].Add(card_pack[j]);
                    }
                }
                while (arylist_temp.Count < arylist_14_pile[i].Count)//sort
                {
                    for (int j = 0; j < arylist_14_pile[i].Count; j++)
                    {
                        card card_temp = (card)arylist_14_pile[i][j];
                        if (card_temp.index_of_pile == index_temp)
                        {
                            arylist_temp.Add(card_temp);
                            index_temp++;
                            break;
                        }
                    }
                }
                arylist_14_pile[i] = arylist_temp;
            }
            for (int i = 0; i < 14; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < arylist_14_pile[i].Count; j++)
                    {
                        card card_temp = (card)arylist_14_pile[i][j];
                        for (int k = 0; k < 52; k++)
                        {
                            if (card_pack[k].index == card_temp.index)
                            {
                                card_pack[k].left_up_point = point_14_pile_initial_pozition[i];
                                break;
                            }
                        }
                    }
                }
                else if (i == 1)
                {
                    if (arylist_14_pile[i].Count > 0)
                    {
                        int flag = 0;
                        for (int j = 0; j < arylist_14_pile[i].Count; j++)
                        {
                            card card_temp = (card)arylist_14_pile[i][j];
                            for (int k = 0; k < 52; k++)
                            {
                                if (card_pack[k].index == card_temp.index)
                                {
                                    if (card_temp.show_face == false)
                                    {
                                        card_pack[k].left_up_point = point_14_pile_initial_pozition[i];
                                    }
                                    else if (card_temp.show_face == true)
                                    {
                                        card_pack[k].left_up_point = new Point(point_14_pile_initial_pozition[i].X + flag * W, point_14_pile_initial_pozition[i].Y);
                                        flag++;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (i >= 2 && i <= 5)
                {
                    for (int j = 0; j < arylist_14_pile[i].Count; j++)
                    {
                        card card_temp = (card)arylist_14_pile[i][j];
                        for (int k = 0; k < 52; k++)
                        {
                            if (card_pack[k].index == card_temp.index)
                            {
                                card_pack[k].left_up_point = point_14_pile_initial_pozition[i];
                                break;
                            }
                        }
                    }
                }
                else if (i >= 6 && i <= 12)
                {
                    for (int j = 0; j < arylist_14_pile[i].Count; j++)
                    {
                        card card_temp = (card)arylist_14_pile[i][j];
                        for (int k = 0; k < 52; k++)
                        {
                            if (card_pack[k].index == card_temp.index)
                            {
                                card_pack[k].left_up_point = new Point(point_14_pile_initial_pozition[i].X, point_14_pile_initial_pozition[i].Y + j * H);
                                break;
                            }
                        }
                    }
                }
                else if (i == 13)
                {
                    for (int j = 0; j < arylist_14_pile[i].Count; j++)
                    {
                        card card_temp = (card)arylist_14_pile[i][j];
                        for (int k = 0; k < 52; k++)
                        {
                            if (card_pack[k].index == card_temp.index)
                            {
                                card_pack[k].left_up_point = new Point(point_14_pile_initial_pozition[i].X, point_14_pile_initial_pozition[i].Y + j * H);
                                break;
                            }
                        }
                    }
                }
            }
        }


        private void dealCards()
        {
            for (int i = 0; i < 52; i++)
            {
                card_pack[i].show_face = false;
            }
            for (int i = 0; i < 7; i++)
            {
                card_pack[51 - i].pile = 12;
                card_pack[51 - i].index_of_pile = i;
            }
            card_pack[45].show_face = true;
            for (int i = 0; i < 6; i++)
            {
                card_pack[44 - i].pile = 11;
                card_pack[44 - i].index_of_pile = i;
            }
            card_pack[39].show_face = true;
            for (int i = 0; i < 5; i++)
            {
                card_pack[38 - i].pile = 10;
                card_pack[38 - i].index_of_pile = i;
            }
            card_pack[34].show_face = true;
            for (int i = 0; i < 4; i++)
            {
                card_pack[33 - i].pile = 9;
                card_pack[33 - i].index_of_pile = i;
            }
            card_pack[30].show_face = true;
            for (int i = 0; i < 3; i++)
            {
                card_pack[29 - i].pile = 8;
                card_pack[29 - i].index_of_pile = i;
            }
            card_pack[27].show_face = true;
            for (int i = 0; i < 2; i++)
            {
                card_pack[26 - i].pile = 7;
                card_pack[26 - i].index_of_pile = i;
            }
            card_pack[25].show_face = true;
            card_pack[24].pile = 6;
            card_pack[24].index_of_pile = 0;
            card_pack[24].show_face = true;
            for (int i = 0; i < 24; i++)
            {
                card_pack[i].pile = 0;
                card_pack[i].index_of_pile = i;
            }
        }

        private bool ini_imagelist()
        {
            bool bl = true;
            imagelist = new ImageList();
            imagelist.ImageSize = new Size(120, 160);
            imagelist.Images.Clear();
            if (!add_cards_in_suit("cardDiamonds", "cardDiamonds"))
            { return false; }
            if (!add_cards_in_suit("cardClubs", "cardClubs"))
            { return false; }
            if (!add_cards_in_suit("cardHearts", "cardHearts"))
            { return false; }
            if (!add_cards_in_suit("cardSpades", "cardSpades"))
            { return false; }
            if (!File.Exists(@"cardImages\\back.png"))
            { return false; }
            
            imagelist.Images.Add(Image.FromFile(@"cardImages\\back.png"));
            return bl;
        }

        private bool add_cards_in_suit(string s1, string s2)
        {
            bool bl = true;
            if (!File.Exists(@"cardImages\\" + s2 + "\\" + s1 + "A.png"))
            {
                imagelist.Images.Clear();
                return false;
            }
            imagelist.Images.Add(Image.FromFile(@"cardImages\\" + s2 + "\\" + s1 + "A.png"));
            for (int i = 2; i < 11; i++)
            {
                if (!File.Exists(@"cardImages\\" + s2 + "\\" + s1 + i.ToString() + ".png"))
                {
                    imagelist.Images.Clear();
                    return false;
                }
                imagelist.Images.Add(Image.FromFile(@"cardImages\\" + s2 + "\\" + s1 + i.ToString() + ".png"));
            }
            if (!File.Exists(@"cardImages\\" + s2 + "\\" + s1 + "J.png"))
            {
                imagelist.Images.Clear();
                return false;
            }
            imagelist.Images.Add(Image.FromFile(@"cardImages\\" + s2 + "\\" + s1 + "J.png"));
            if (!File.Exists(@"cardImages\\" + s2 + "\\" + s1 + "Q.png"))
            {
                imagelist.Images.Clear();
                return false;
            }
            imagelist.Images.Add(Image.FromFile(@"cardImages\\" + s2 + "\\" + s1 + "Q.png"));
            if (!File.Exists(@"cardImages\\" + s2 + "\\" + s1 + "K.png"))
            {
                imagelist.Images.Clear();
                return false;
            }
            imagelist.Images.Add(Image.FromFile(@"cardImages\\" + s2 + "\\" + s1 + "K.png"));
            return bl;
        }

        private void ini_point_14_pile_initial_pozition()
        {
            for (int i = 0; i < 7; i++)
            {
                point_14_pile_initial_pozition[i + 6] = new Point(130 * i, 170);
            }
            for (int i = 0; i < 2; i++)
            {
                point_14_pile_initial_pozition[i] = new Point(point_14_pile_initial_pozition[i + 6].X, 0);
            }
            for (int i = 0; i < 4; i++)
            {
                point_14_pile_initial_pozition[2 + i] = new Point(point_14_pile_initial_pozition[9 + i].X, 0);
            }
            point_14_pile_initial_pozition[13] = point_14_pile_initial_pozition[0];
        }

        private void timer_time_Tick(object sender, EventArgs e)
        {
            //
        }

        private void timer_draw_Tick(object sender, EventArgs e)
        {
            draw();
        }
        bool is_completed()
        {
            bool bl = true;
            for (int i = 0; i < 52; i++)
            {
                if (card_pack[i].show_face == false != arylist_14_pile[1].Count > 0)
                {
                    bl = false;
                    break;
                }
            }
            return bl;
        }

        private void panel_operate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (arylist_14_pile[13].Count == 0)
            {
                return;
            }
            is_ready_draw = false;
            bool is_add = false;
            card card_temp = (card)arylist_14_pile[13][0];
            for (int i = 0; i < 52; i++)
            {
                if (card_pack[i].index == card_temp.index)
                {
                    for (int j = 0; j <= 12; j++)
                    {
                        if (j >= 2 && j <= 5 && j != old_pile && arylist_14_pile[13].Count == 1)
                        {
                            if (arylist_14_pile[j].Count == 0)
                            {
                                if (card_pack[i].index % 13 == 0)
                                {
                                    is_add = true;
                                    card_pack[i].pile = j;
                                    card_pack[i].index_of_pile = 0;
                                    break;
                                }
                            }
                            else if (arylist_14_pile[j].Count > 0)
                            {
                                card card_temp_temp = (card)arylist_14_pile[j][arylist_14_pile[j].Count - 1];
                                if (card_pack[i].index % 13 - card_temp_temp.index % 13 == 1 && card_pack[i].index / 13 == card_temp_temp.index / 13)
                                {
                                    is_add = true;
                                    card_pack[i].pile = j;
                                    card_pack[i].index_of_pile = arylist_14_pile[j].Count;
                                    break;
                                }
                            }
                        }
                        if (j >= 6 && j <= 12 && j != old_pile)
                        {
                            if (arylist_14_pile[j].Count == 0)
                            {
                                if (card_pack[i].index % 13 == 12)
                                {
                                    is_add = true;
                                    for (int k = 0; k < arylist_14_pile[13].Count; k++)
                                    {
                                        card card_temp_temp = (card)arylist_14_pile[13][k];
                                        for (int l = 0; l < 52; l++)
                                        {
                                            if (card_pack[l].index == card_temp_temp.index)
                                            {
                                                card_pack[l].pile = j;
                                                card_pack[l].index_of_pile = k;
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            if (arylist_14_pile[j].Count > 0)
                            {
                                card card_temp_temp = (card)arylist_14_pile[j][arylist_14_pile[j].Count - 1];
                                if (card_temp_temp.index % 13 - card_pack[i].index % 13 == 1 && Math.Abs(card_pack[i].index / 13 - card_temp_temp.index / 13) % 2 == 1)
                                {
                                    is_add = true;
                                    for (int k = 0; k < arylist_14_pile[13].Count; k++)
                                    {
                                        card card_temp_temp_temp = (card)arylist_14_pile[13][k];
                                        for (int l = 0; l < 52; l++)
                                        {
                                            if (card_pack[l].index == card_temp_temp_temp.index)
                                            {
                                                card_pack[l].pile = j;
                                                card_pack[l].index_of_pile = arylist_14_pile[j].Count + k;
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                }
            }
            if (is_add)
            {
                sort_arylist_14_pile();
                if (arylist_14_pile[old_pile].Count > 0 && old_pile != 1)
                {
                    card card_temp_temp_temp = (card)arylist_14_pile[old_pile][arylist_14_pile[old_pile].Count - 1];
                    for (int i__ = 0; i__ < 52; i__++)
                    {
                        if (card_pack[i__].index == card_temp_temp_temp.index)
                        {
                            card_pack[i__].show_face = true;
                        }
                    }
                    sort_arylist_14_pile();
                }
                is_ready_draw = true;
                if (is_completed())
                {
                    MessageBox.Show("Congratulations! You Win!");
                    panel_operate.Refresh();
                    timer_draw.Enabled = false;
                }
            }
            is_ready_draw = true;
        }

        private void panel_operate_MouseUp(object sender, MouseEventArgs e)
        {
            if (arylist_14_pile[13].Count == 0)
            {
                return;
            }
            is_ready_draw = false;
            int mouse_up_index = detect_selected_index(e.X, e.Y);
            bool is_add = false;
            if (mouse_up_index == -1)
            {
                card card_temp_temp = (card)arylist_14_pile[13][0];
                for (int _i = 2; _i <= 12; _i++)
                {
                    if (_i >= 2 && _i <= 5)
                    {
                        if (card_temp_temp.index % 13 == 0 && arylist_14_pile[_i].Count == 0 && e.X - point_14_pile_initial_pozition[_i].X > 0 && e.X - point_14_pile_initial_pozition[_i].X < 120 && e.Y - point_14_pile_initial_pozition[_i].Y > 0 && e.Y - point_14_pile_initial_pozition[_i].Y < 160)
                        {
                            is_add = true;
                            for (int i = 0; i < arylist_14_pile[13].Count; i++)
                            {
                                card card_temp = (card)arylist_14_pile[13][i];
                                for (int j = 0; j < 52; j++)
                                {
                                    if (card_pack[j].index == card_temp.index)
                                    {
                                        card_pack[j].pile = _i;
                                        card_pack[j].index_of_pile = arylist_14_pile[_i].Count + i;
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                    if (_i >= 6 && _i <= 12)
                    {
                        if (card_temp_temp.index % 13 == 12 && arylist_14_pile[_i].Count == 0 && e.X - point_14_pile_initial_pozition[_i].X > 0 && e.X - point_14_pile_initial_pozition[_i].X < 120 && e.Y - point_14_pile_initial_pozition[_i].Y > 0 && e.Y - point_14_pile_initial_pozition[_i].Y < 160)
                        {
                            is_add = true;
                            for (int i = 0; i < arylist_14_pile[13].Count; i++)
                            {
                                card card_temp = (card)arylist_14_pile[13][i];
                                for (int j = 0; j < 52; j++)
                                {
                                    if (card_pack[j].index == card_temp.index)
                                    {
                                        card_pack[j].pile = _i;
                                        card_pack[j].index_of_pile = arylist_14_pile[_i].Count + i;
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
            else if (mouse_up_index != -1)
            {
                for (int i = 0; i < 52; i++)
                {
                    if (card_pack[i].index == mouse_up_index)
                    {
                        if (card_pack[i].index_of_pile == arylist_14_pile[card_pack[i].pile].Count - 1)
                        {
                            if (card_pack[i].pile != 1)
                            {
                                card card_temp = (card)arylist_14_pile[13][0];
                                for (int j = 2; j <= 12; j++)
                                {
                                    if (card_pack[i].pile == j)
                                    {
                                        if (j >= 2 && j <= 5 && arylist_14_pile[13].Count == 1)
                                        {
                                            if (card_temp.index - card_pack[i].index == 1 && card_temp.index / 13 == card_pack[i].index / 13)
                                            {
                                                is_add = true;
                                                for (int k = 0; k < 52; k++)
                                                {
                                                    if (card_pack[k].index == card_temp.index)
                                                    {
                                                        card_pack[k].pile = card_pack[i].pile;
                                                        card_pack[k].index_of_pile = arylist_14_pile[card_pack[i].pile].Count;
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        else if (j >= 6 && j <= 12)
                                        {
                                            if (card_pack[i].index % 13 - card_temp.index % 13 == 1 && Math.Abs(card_pack[i].index / 13 - card_temp.index / 13) % 2 == 1)
                                            {
                                                is_add = true;
                                                for (int k = 0; k < arylist_14_pile[13].Count; k++)
                                                {
                                                    card card_temp_temp = (card)arylist_14_pile[13][k];
                                                    for (int l = 0; l < 52; l++)
                                                    {
                                                        if (card_pack[l].index == card_temp_temp.index)
                                                        {
                                                            card_pack[l].pile = card_pack[i].pile;
                                                            card_pack[l].index_of_pile = arylist_14_pile[card_pack[i].pile].Count + k;
                                                            break;
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
            if (!is_add)
            {
                for (int i = 0; i < arylist_14_pile[13].Count; i++)
                {
                    card card_temp = (card)arylist_14_pile[13][i];
                    for (int j = 0; j < 52; j++)
                    {
                        if (card_pack[j].index == card_temp.index)
                        {
                            card_pack[j].pile = old_pile;
                            card_pack[j].index_of_pile = arylist_14_pile[old_pile].Count + i;
                            break;
                        }
                    }
                }
            }
            sort_arylist_14_pile();
            if (arylist_14_pile[old_pile].Count > 0 && old_pile != 1)
            {
                card card_temp_temp_temp = (card)arylist_14_pile[old_pile][arylist_14_pile[old_pile].Count - 1];
                for (int i__ = 0; i__ < 52; i__++)
                {
                    if (card_pack[i__].index == card_temp_temp_temp.index)
                    {
                        card_pack[i__].show_face = true;
                    }
                }
                sort_arylist_14_pile();
            }
            is_ready_draw = true;
            if (is_completed())
            {
                MessageBox.Show("You Win!");
                panel_operate.Refresh();
                timer_draw.Enabled = false;
            }
        }

        private int detect_selected_index(int x, int y)
        {

            int selected_index_temp = -1;
            ArrayList arylist_temp = new ArrayList();
            for (int i = 0; i < 52; i++)
            {
                if (card_pack[i].show_face == true && card_pack[i].pile != 0 && card_pack[i].pile != 13)
                {
                    arylist_temp.Add(card_pack[i]);
                }
            }
            ArrayList arylist_temp_temp = new ArrayList();
            for (int i = 0; i < arylist_temp.Count; i++)
            {
                card card_temp = (card)arylist_temp[i];
                if (x - card_temp.left_up_point.X > 0 && x - card_temp.left_up_point.X < 120 && y - card_temp.left_up_point.Y > 0 && y - card_temp.left_up_point.Y < 160)
                {
                    arylist_temp_temp.Add(card_temp);
                }
            }
            int flag = 0;
            for (int i = 0; i < arylist_temp_temp.Count; i++)
            {
                card card_temp = (card)arylist_temp_temp[i];
                if (card_temp.index_of_pile >= flag)
                {
                    flag = card_temp.index_of_pile;
                    selected_index_temp = card_temp.index;
                }
                for (int i_ = 0; i_ < 52; i_++)
                {
                    if (card_pack[i_].index == selected_index_temp)
                    {
                        if (card_pack[i_].pile == 1 && card_pack[i_].index_of_pile != arylist_14_pile[card_pack[i_].pile].Count - 1)
                        {
                            selected_index_temp = -1;
                        }
                    }
                }
            }
            return selected_index_temp;
        }


        private void panel_operate_MouseMove(object sender, MouseEventArgs e)
        {
            if (arylist_14_pile[13].Count == 0)
            {
                return;
            }
            is_ready_draw = false;
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < 52; i++)
                {
                    if (card_pack[i].index == selected_index)
                    {
                        point_14_pile_initial_pozition[13] = new Point(card_pack[i].left_up_point.X + e.X - point_mousedown_on_panel_operate.X, card_pack[i].left_up_point.Y + e.Y - point_mousedown_on_panel_operate.Y);
                    }
                }
            }
            is_ready_draw = true;
        }

        private void panel_operate_MouseDown(object sender, MouseEventArgs e)
        {
            is_ready_draw = false;
            point_mousedown_on_panel_operate = new Point(e.X, e.Y);
            if (e.X - point_14_pile_initial_pozition[0].X > 0 && e.X - point_14_pile_initial_pozition[0].X < 120 && e.Y - point_14_pile_initial_pozition[0].Y > 0 && e.Y - point_14_pile_initial_pozition[0].Y < 160 && arylist_14_pile[0].Count > 0)
            {
                for (int _i = 0; _i < arylist_14_pile[1].Count; _i++)
                {
                    card card_temp = (card)arylist_14_pile[1][_i];
                    for (int j = 0; j < 52; j++)
                    {
                        if (card_pack[j].index == card_temp.index)
                        {
                            card_pack[j].show_face = false;
                        }
                    }
                }
                if (arylist_14_pile[0].Count < 3)
                {
                    for (int i = 0; i < arylist_14_pile[0].Count; i++)
                    {
                        card card_temp = (card)arylist_14_pile[0][arylist_14_pile[0].Count - 1 - i];
                        for (int j = 0; j < 52; j++)
                        {
                            if (card_pack[j].index == card_temp.index)
                            {
                                card_pack[j].pile = 1;
                                card_pack[j].index_of_pile = arylist_14_pile[1].Count + i;
                                card_pack[j].show_face = true;
                            }
                        }
                    }
                }
                else if (arylist_14_pile[0].Count > 2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        card card_temp = (card)arylist_14_pile[0][arylist_14_pile[0].Count - 1 - i];
                        for (int j = 0; j < 52; j++)
                        {
                            if (card_pack[j].index == card_temp.index)
                            {
                                card_pack[j].pile = 1;
                                card_pack[j].index_of_pile = arylist_14_pile[1].Count + i;
                                card_pack[j].show_face = true;
                            }
                        }
                    }
                }
            }
            else if (e.X - point_14_pile_initial_pozition[0].X > 0 && e.X - point_14_pile_initial_pozition[0].X < 120 && e.Y - point_14_pile_initial_pozition[0].Y > 0 && e.Y - point_14_pile_initial_pozition[0].Y < 160 && arylist_14_pile[0].Count == 0 && arylist_14_pile[1].Count > 0)
            {
                for (int i = 0; i < arylist_14_pile[1].Count; i++)
                {
                    card card_temp = (card)arylist_14_pile[1][arylist_14_pile[1].Count - 1 - i];
                    for (int j = 0; j < 52; j++)
                    {
                        if (card_pack[j].index == card_temp.index)
                        {
                            card_pack[j].pile = 0;
                            card_pack[j].index_of_pile = arylist_14_pile[0].Count + i;
                            card_pack[j].show_face = false;
                        }
                    }
                }
            }
            else
            {
                selected_index = detect_selected_index(e.X, e.Y);
                if (selected_index != -1)
                {
                    for (int i = 0; i < 52; i++)
                    {
                        if (card_pack[i].index == selected_index)
                        {
                            old_pile = card_pack[i].pile;
                            point_14_pile_initial_pozition[13] = card_pack[i].left_up_point;
                            int flag = 0;
                            for (int j = 0; j < arylist_14_pile[old_pile].Count; j++)
                            {
                                card card_temp = (card)arylist_14_pile[old_pile][j];
                                if (card_temp.index_of_pile >= card_pack[i].index_of_pile)
                                {
                                    for (int k = 0; k < 52; k++)
                                    {
                                        if (card_pack[k].index == card_temp.index)
                                        {
                                            card_pack[k].pile = 13;
                                            card_pack[k].index_of_pile = arylist_14_pile[13].Count + flag;
                                            flag++;
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
            sort_arylist_14_pile();
            is_ready_draw = true;
        }


        private void button_newgame_Click(object sender, EventArgs e)
        {
            GC.Collect();
            timer_draw.Enabled = true;
            if (ini_imagelist())
            {
                selected_index = -1;
                shuffle();
                dealCards();
                sort_arylist_14_pile();
                draw();
            }
            else
            {
                MessageBox.Show("Can not find image files!");
                this.Close();
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = this.PointToScreen(new Point(e.X - point_mousedown_on_panel_title.X, e.Y - point_mousedown_on_panel_title.Y));
            }
        }

        private void panel_title_MouseDown(object sender, MouseEventArgs e)
        {
            point_mousedown_on_panel_title = new Point(e.X, e.Y);
        }


    }
}
