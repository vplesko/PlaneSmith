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
        Bitmap bmp;

        Instance curr = null;
        bool drawCurr;

        public Form1()
        {
            InitializeComponent();

            dict = new Dictionary();
            content = new Content();
            bmp = new Bitmap(pictureBoxEdit.Width, pictureBoxEdit.Height);

            redrawEdit();
        }

        private void buttonAddDef_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Bitmap files(*.bmp,*.gif,*.jpg,*.jpeg,*.png,*.ico)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Definition def = new Definition("New Definition", this);

                    // This way the image file is unlocked after loading
                    using (Image temp = new Bitmap(dlg.FileName))
                    {
                        def.setImage(new Bitmap(temp), dlg.FileName);
                    }

                    dict.Add(def);
                    renewDictionaryBox();
                }
            }
        }

        public void redrawEdit()
        {
            Graphics G = Graphics.FromImage(bmp);
            G.Clear(pictureBoxEdit.BackColor);

            content.Draw(G);
            if (curr != null && drawCurr) curr.Draw(G);

            if (checkShowGrid.Checked &&
                numericGridW.Value > 0 && numericGridH.Value > 0)
            {
                Pen pen = new Pen(Color.DarkGray);

                for (int i = 0; i < bmp.Width; i += (int)numericGridW.Value)
                    G.DrawLine(pen, i, 0, i, bmp.Height);

                for (int i = 0; i < bmp.Height; i += (int)numericGridH.Value)
                    G.DrawLine(pen, 0, i, bmp.Width, i);
            }

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
            Point loc = new Point(e.X, e.Y);

            if (checkSnapGrid.Checked)
            {
                int gridW = (int)numericGridW.Value;
                int gridH = (int)numericGridH.Value;

                loc.X = (loc.X / gridW) * gridW;
                loc.Y = (loc.Y / gridH) * gridH;
            }

            labelCoords.Text = loc.ToString();

            if (curr != null)
            {
                curr.setLocation(loc);

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
                    tmp.setLocation(curr.Location);
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

        private void numericGridW_ValueChanged(object sender, EventArgs e)
        {
            if (checkShowGrid.Checked) redrawEdit();
        }

        private void numericGridH_ValueChanged(object sender, EventArgs e)
        {
            if (checkShowGrid.Checked) redrawEdit();
        }

        private void checkShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            redrawEdit();
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
