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
        Level level;
        Bitmap plane, contentImg;

        Rectangle redrawRect;
        Instance addition = null;
        bool drawCurr = false;

        string fileDictionary = null, fileLevel = null;

        public Form1()
        {
            InitializeComponent();

            dict = new Dictionary(this);
            level = new Level(this);
            plane = new Bitmap(pictureBoxEdit.Width, pictureBoxEdit.Height);
            contentImg = new Bitmap(pictureBoxEdit.Width, pictureBoxEdit.Height);

            RedrawPlane(true);
        }

        private void buttonAddDef_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Bitmap files(*.bmp,*.gif,*.jpg,*.jpeg,*.png,*.ico)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Definition def = new Definition(dict, "New Definition");

                    // This way the image file is unlocked after loading
                    using (Image temp = new Bitmap(dlg.FileName))
                    {
                        def.setImage(new Bitmap(temp), dlg.FileName);
                    }

                    dict.Add(def);
                    RenewDictionaryBox();
                }
            }
        }

        public void RedrawPlane(bool levelChanged)
        {
            Graphics G = Graphics.FromImage(plane);

            if (levelChanged)
            {
                Graphics C = Graphics.FromImage(contentImg);
                C.Clear(pictureBoxEdit.BackColor);
                level.Draw(C);

                G.DrawImage(contentImg, 0, 0);
            }
            else
            {
                if (redrawRect != null)
                {
                    G.SetClip(redrawRect);
                    G.DrawImage(contentImg, 0, 0);
                }
                else
                {
                    G.DrawImage(contentImg, 0, 0);
                }
            }

            if (addition != null && drawCurr) addition.Draw(G);

            if (checkShowGrid.Checked &&
                numericGridW.Value > 0 && numericGridH.Value > 0)
            {
                Pen pen = new Pen(Color.DarkGray);

                for (int i = 0; i < plane.Width; i += (int)numericGridW.Value)
                    G.DrawLine(pen, i, 0, i, plane.Height);

                for (int i = 0; i < plane.Height; i += (int)numericGridH.Value)
                    G.DrawLine(pen, 0, i, plane.Width, i);
            }

            pictureBoxEdit.Image = plane;
        }

        public void RenewDictionaryBox()
        {
            dictionaryBox.Items.Clear();

            for (int i = 0; i < dict.Count; ++i)
                dictionaryBox.Items.Add(dict[i].ToString());
        }

        public void RenewLevelBox()
        {
            levelBox.Items.Clear();

            for (int i = 0; i < level.Count; ++i)
                levelBox.Items.Add(level[i].ToString());
        }

        public void RenewBoxes()
        {
            RenewDictionaryBox();
            RenewLevelBox();
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

            if (addition != null && addition.GetDefinition() != null)
            {
                redrawRect = new Rectangle(addition.Location, addition.GetDefinition().Image.Size);
                addition.setLocation(loc);

                drawCurr = true;
                RedrawPlane(false);
            }
        }

        private void pictureBoxEdit_MouseLeave(object sender, EventArgs e)
        {
            drawCurr = false;
            if (addition != null) RedrawPlane(false);
        }

        private void pictureBoxEdit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (addition != null)
                {
                    level.Add(addition);
                    levelBox.Items.Add(addition.ToString());

                    Instance tmp = new Instance(level, addition.GetDefinition());
                    tmp.setLocation(addition.Location);
                    addition = tmp;

                    RedrawPlane(true);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                addition = null;
                dictionaryBox.ClearSelected();
                RedrawPlane(false);
            }
        }

        private void dictionaryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = dictionaryBox.SelectedIndex;
            if (index >= 0)
            {
                addition = new Instance(level, dict[index]);
                defProperties.SelectedObject = dict[index];
            }
        }

        private void levelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = levelBox.SelectedIndex;
            if (index >= 0)
            {
                addition = null;
                instProperties.SelectedObject = level[index];
            }
        }

        private void numericGridW_ValueChanged(object sender, EventArgs e)
        {
            if (checkShowGrid.Checked) RedrawPlane(true);
        }

        private void numericGridH_ValueChanged(object sender, EventArgs e)
        {
            if (checkShowGrid.Checked) RedrawPlane(true);
        }

        private void checkShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            RedrawPlane(true);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ask about saving

            addition = null;
            drawCurr = false;

            dict = new Dictionary(this);
            level = new Level(this);

            RedrawPlane(true);
            RenewBoxes();
            defProperties.SelectedObject = null;
            fileDictionary = null;
            instProperties.SelectedObject = null;
            fileLevel = null;
        }

        private void newLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ask about saving

            addition = null;
            drawCurr = false;

            level = new Level(this);

            RedrawPlane(true);
            RenewLevelBox();
            instProperties.SelectedObject = null;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // will user lose all unsaved data?

            addition = null;
            drawCurr = false;

            defProperties.SelectedObject = null;
            instProperties.SelectedObject = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PSM Files|*.psm;*.txt";
            openFileDialog.Title = "Load From File(s)";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName != "")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);
                string type = file.ReadLine();
                bool loadingDict = string.Equals(type, Dictionary.TypeToken);

                if (loadingDict)
                {
                    fileDictionary = openFileDialog.FileName;
                }
                else
                {
                    fileLevel = openFileDialog.FileName;
                    fileDictionary = file.ReadLine();
                }

                file.Close();

                dict = new Dictionary(this);
                using (System.IO.StreamReader F = new System.IO.StreamReader(fileDictionary))
                {
                    dict.load(F);
                    RenewDictionaryBox();
                }

                if (!loadingDict)
                {
                    level = new Level(this);
                    using (System.IO.StreamReader F = new System.IO.StreamReader(fileLevel))
                    {
                        level.load(F, dict);
                        RenewLevelBox();
                        RedrawPlane(true);
                    }
                }
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fileDictionary != null)
            {
                using (System.IO.StreamWriter fs =
                    new System.IO.StreamWriter(fileDictionary))
                {
                    dict.save(fs);
                }
            }
            else
            {
                MessageBox.Show("You will now save the dictionary.", "Save Dictionary");
                saveDictionaryAsToolStripMenuItem_Click(null, null);

                if (fileDictionary == null) return;
            }

            if (fileLevel != null)
            {
                using (System.IO.StreamWriter fs =
                    new System.IO.StreamWriter(fileLevel))
                {
                    level.save(fs, fileDictionary);
                }
            }
            else
            {
                MessageBox.Show("You will now save the level.", "Save Level");
                saveLevelAsToolStripMenuItem_Click(null, null);
            }
        }

        private void saveDictionaryAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PSM Dictionary File|*.psm;*.txt";
            saveFileDialog.Title = "Save Dictionary";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                fileDictionary = saveFileDialog.FileName;

                using (System.IO.StreamWriter fs =
                    new System.IO.StreamWriter(fileDictionary))
                {
                    dict.save(fs);
                }
            }
        }

        private void saveLevelAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileDictionary == null)
            {
                MessageBox.Show("You have to save the dictionary before saving levels.", "Save Dictionary First");
                saveDictionaryAsToolStripMenuItem_Click(null, null);

                if (fileDictionary == null) return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PSM Level File|*.psm;*.txt";
            saveFileDialog.Title = "Save Level";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                fileLevel = saveFileDialog.FileName;

                using (System.IO.StreamWriter fs =
                    new System.IO.StreamWriter(fileLevel))
                {
                    level.save(fs, fileDictionary);
                }
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // ask about saving

            Application.Exit();
        }

        private void levelBox_MouseLeave(object sender, EventArgs e)
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
