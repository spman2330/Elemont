using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Elemont.Gui.Game;
using Elemont.Dao;
using Elemont.Dto;
namespace Elemont.Gui.Game
{
    public partial class fMap : Form
    {
        public fMap()
        {
            InitializeComponent();

        }
        private void fMap_Load(object sender, EventArgs e)
        {
            pictureBox1.AllowDrop = true;
            numericUpDown3.Value = pictureBox1.Width;
            numericUpDown4.Value = pictureBox1.Height;
            loadmap();
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }
        private void loadmap()
        {
            bool child = true;
            while (child)
            {
                foreach (Control c1 in Map1.Controls)
                {
                    Map1.Controls.Remove(c1);
                }
                child = Map1.HasChildren;
            }
            foreach (Map m in MapDao.Instance.GetMaps())
            {
                GroupBox gb = new GroupBox();
                gb.Size = new Size(150, 120);
                PictureBox pb = new PictureBox();
                pb.Size = new Size(150, 105);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = m.MapId;
                pb.Image = Image.FromFile("..\\..\\..\\" + m.Background);
                pb.Click += new System.EventHandler(this.pictureBox1_Click);
                pb.Location = new Point(0, 20);
                gb.Controls.Add(pb);
                gb.Text = m.Name;
                gb.Tag = m.MapId;
                gb.BackColor = Color.White;
                Map1.Controls.Add(gb);
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            x = (int)numericUpDown1.Value;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            y = (int)numericUpDown2.Value;
        }
        int x;
        int y;
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control c1 in flowLayoutPanel1.Controls)
            {
                pictureBox1.Controls.Add(c1);
                c1.Location = new Point(x, y);
                ControlExtension.Draggable(c1, true);
                c1.BringToFront();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            {
                if (pb.Parent.BackColor == Color.Blue)
                {
                    pb.Parent.BackColor = Color.White;
                }
                else
                {
                    foreach (Control c1 in Map1.Controls)
                    {
                        c1.BackColor = Color.White;
                    }
                    pb.Parent.BackColor = Color.Blue;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown5.Value * numericUpDown6.Value != 0 && comboBox1.SelectedItem != null)
            {
                foreach (Control c1 in flowLayoutPanel1.Controls)
                {
                    pictureBox1.Controls.Add(c1);
                    ControlExtension.Draggable(c1, true);

                }
                PictureBox pb = new PictureBox();
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Water":
                        pb.BackColor = Color.Blue;
                        break;
                    case "Wall":
                        pb.BackColor = Color.Brown;
                        break;
                    case "Nest":
                        pb.BackColor = Color.Green;
                        break;
                    default:
                        pb.BackColor = Color.Black;
                        break;
                }

                flowLayoutPanel1.Controls.Add(pb);
                pb.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
                pb.Click += new System.EventHandler(this.pictureBox_Click);
                pb.Size = new Size((int)numericUpDown5.Value, (int)numericUpDown6.Value);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = comboBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please check all properties", "", MessageBoxButtons.OK);
            }
        }
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (!flowLayoutPanel1.HasChildren)
            {
                PictureBox pb = sender as PictureBox;
                numericUpDown1.Value = pb.Location.X;
                numericUpDown2.Value = pb.Location.Y;
                numericUpDown5.Value = pb.Width;
                numericUpDown6.Value = pb.Height;
                flowLayoutPanel1.Controls.Add(pb);
                pictureBox1.Controls.Remove(pb);
            }
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb.Parent.Equals(pictureBox1)&& !flowLayoutPanel1.HasChildren)
            {
                numericUpDown1.Value = pb.Location.X;
                numericUpDown2.Value = pb.Location.Y;
                numericUpDown5.Value = pb.Width;
                numericUpDown6.Value = pb.Height;
                pb.BringToFront();
                label3.Text = pb.Tag.ToString();
            }

        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = numericUpDown3.Value;
            pictureBox1.Width = (int)numericUpDown3.Value;
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = numericUpDown4.Value;
            pictureBox1.Height = (int)numericUpDown4.Value;
        }
        public PictureBox Clone(PictureBox pb)
        {
            PictureBox clone = new PictureBox();
            clone.Size = pb.Size;
            clone.Tag = pb.Tag;
            clone.Image = pb.Image;
            clone.BackColor = pb.BackColor;
            return clone;
        }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control c1 in flowLayoutPanel1.Controls)
            {
                c1.Width = (int)numericUpDown5.Value;
            }
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control c1 in flowLayoutPanel1.Controls)
            {
                c1.Height = (int)numericUpDown6.Value;
            }
        }
        private void bimg_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox3.Image = new Bitmap(open.FileName);
                    pictureBox1.Image = new Bitmap(open.FileName);
                    textBox1.Text = System.IO.Path.GetFileName(open.FileName);
                }
            }
            catch
            {

            }
        }
        private void bSave_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null && textBox1.Text != "")
            {
                Map map = new Map();
                map.Width = (int)numericUpDown3.Value;
                map.Height = (int)numericUpDown4.Value;
                map.Name = this.comboBox3.Text;
                map.Background = textBox1.Text;
                if (!MapDao.Instance.AddMap(map))
                { }
                loadmap();
            }
        }
        private void button3_Click(object sender, EventArgs e) 
        {
            if (comboBox3.SelectedItem != null)
            {
                Map map = MapDao.Instance.GetMapById((int)pictureBox1.Tag);
                map.Width = pictureBox1.Width;
                map.Height = pictureBox1.Height;
                map.Name = this.comboBox3.Text;
                map.Background = textBox1.Text;
                List<Cell> termsList = new List<Cell>();
                foreach (Control c1 in pictureBox1.Controls)
                {
                    Cell cell = new Cell(c1.Width, c1.Height);
                    cell.LocationX = c1.Left;
                    cell.LocationY = c1.Top;
                    cell.MapId = (int)pictureBox1.Tag;
                    cell.Type = c1.Tag.ToString();
                    termsList.Add(cell);
                    int id;
                    bool isold = int.TryParse(c1.Tag.ToString(), out id);
                    if (isold)
                    {
                        Cell c = CellDao.Instance.GetCellById(id);
                        c.LocationX = cell.LocationX;
                        c.LocationY = cell.LocationY;
                        c.MapId = cell.MapId;
                        c.Width = cell.Width;
                        c.Height = cell.Height;
                        if (!CellDao.Instance.ChangeCell(c))
                        { }

                    }
                    else
                        if (!CellDao.Instance.AddCell(cell))
                    { }
                }
                map.Cells = termsList.ToArray();
                if (!MapDao.Instance.ChangeMap(map))
                { }
                MessageBox.Show("Map Created and Saved ", "", MessageBoxButtons.OK);
            }
        }
        private void button5_Click(object sender, EventArgs e) 
        {
            foreach (Control c1 in Map1.Controls)
            {
                if (c1.BackColor == Color.Blue)
                {
                    bool child = true;
                    while (child)
                    {
                        foreach (Control c2 in pictureBox1.Controls)
                        { pictureBox1.Controls.Remove(c2); }
                        child = pictureBox1.HasChildren;
                    }

                    Map map = MapDao.Instance.GetMapById((int)c1.Tag);
                    pictureBox1.Tag = map.MapId;
                    pictureBox1.Image = Image.FromFile("..\\..\\..\\" + map.Background);
                    numericUpDown3.Value = pictureBox1.Width = map.Width;
                    numericUpDown4.Value = pictureBox1.Height = map.Height;
                    comboBox3.Text = map.Name;
                    textBox1.Text = map.Background;
                    groupBox2.Enabled = true;
                    foreach (Cell c in map.Cells)
                    {
                        PictureBox pb = new PictureBox();
                        pb.Size = new Size(c.Width, c.Height);
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Tag = c.CellId;
                        switch (c.Type)
                        {
                            case "Water":
                                pb.BackColor = Color.Blue;
                                break;
                            case "Wall":
                                pb.BackColor = Color.Brown;
                                break;
                            case "Nest":
                                pb.BackColor = Color.Green;
                                break;
                            default:
                                pb.BackColor = Color.Black;
                                break;
                        }
                        pb.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
                        pb.Click += new System.EventHandler(this.pictureBox_Click);
                        ControlExtension.Draggable(pb, true);
                        pictureBox1.Controls.Add(pb);
                        pb.Location = new Point(c.LocationX, c.LocationY);
                        pb.BringToFront();
                    }
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Control c1 in flowLayoutPanel1.Controls)
            {
                int i;
                bool isold = int.TryParse(c1.Tag.ToString(), out i);
                if (isold)
                {
                    if (!CellDao.Instance.DeleteCell(CellDao.Instance.GetCellById(i)))
                    { }
                }
                flowLayoutPanel1.Controls.Remove(c1);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            bSave.Enabled = true;
            textBox1.Text = "Resources" + "\\" + "\\" + comboBox3.Text + ".png";
            pictureBox1.Image = Image.FromFile("..\\..\\..\\" + textBox1.Text);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            foreach (Control c1 in Map1.Controls)
            {
                if (c1.BackColor == Color.Blue)
                {
                    MapDao.Instance.DeleteMap(MapDao.Instance.GetMapById((int)c1.Tag));
                    Map1.Controls.Remove(c1);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control c1 in flowLayoutPanel1.Controls)
            {
                int id;
                bool isold = int.TryParse(c1.Tag.ToString(), out id);
                if (isold)
                {
                    Cell c = CellDao.Instance.GetCellById(id);
                    c.Type = comboBox1.Text;
                    if (!CellDao.Instance.ChangeCell(c))
                    { }

                }
                else
                { c1.Tag = comboBox1.Text; }
                switch (comboBox1.Text)
                {
                    case "Water":
                        c1.BackColor = Color.Blue;
                        break;
                    case "Wall":
                        c1.BackColor = Color.Brown;
                        break;
                    case "Nest":
                        c1.BackColor = Color.Green;
                        break;
                    default:
                        c1.BackColor = Color.Black;
                        break;
                }
            }
        }
    }
}

