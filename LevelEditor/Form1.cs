using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        Dictionary dict;
        Content content;
        Instance curr = null;
        bool drawCurr;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();

            dict = new Dictionary();
            content = new Content();
            bmp = new Bitmap(pictureBoxEdit.Width, pictureBoxEdit.Height);

            dict.Add(new Definition("White", this));
            dict.Add(new Definition("Red", this));
            dict[1].Color = Color.Red;
            dict.Add(new Definition("Green", this));
            dict[2].Color = Color.Green;
            dict.Add(new Definition("Blue", this));
            dict[3].Color = Color.Blue;

            renewDictionaryBox();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            curr = new Instance(dict[1], this);
        }

        public void redrawEdit()
        {
            Graphics G = Graphics.FromImage(bmp);
            G.Clear(pictureBoxEdit.BackColor);

            content.Draw(G);
            if (curr != null && drawCurr) curr.DrawTransp(G);

            pictureBoxEdit.Image = bmp;
        }

        public void renewDictionaryBox()
        {
            dictionaryBox.Items.Clear();

            for (int i = 0; i < dict.Count; ++i)
                dictionaryBox.Items.Add(dict[i].ToString());
        }

        public void renewContentBox()
        {
            contentBox.Items.Clear();

            for (int i = 0; i < content.Count; ++i)
                contentBox.Items.Add(content[i].ToString());
        }

        public void renewBoxes()
        {
            renewDictionaryBox();
            renewContentBox();
        }

        private void pictureBoxEdit_MouseMove(object sender, MouseEventArgs e)
        {
            if (curr != null)
            {
                curr.setLoc(e.X, e.Y);

                drawCurr = true;
                redrawEdit();
            }
        }

        private void pictureBoxEdit_MouseLeave(object sender, EventArgs e)
        {
            drawCurr = false;
            redrawEdit();
        }

        private void pictureBoxEdit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (curr != null)
                {
                    content.Add(curr);
                    contentBox.Items.Add(curr.ToString());

                    Instance tmp = new Instance(curr.GetDefinition(), this);
                    tmp.X = curr.X;
                    tmp.Y = curr.Y;
                    curr = tmp;

                    redrawEdit();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                curr = null;
                dictionaryBox.ClearSelected();
                redrawEdit();
            }
        }

        private void dictionaryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = dictionaryBox.SelectedIndex;
            if (index >= 0)
            {
                curr = new Instance(dict[index], this);
                defProperties.SelectedObject = dict[index];
            }
        }

        private void contentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = contentBox.SelectedIndex;
            if (index >= 0)
            {
                curr = null;
                instProperties.SelectedObject = content[index];
            }
        }

        private void contentBox_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pictureBoxEdit_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
