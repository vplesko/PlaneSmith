﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ScintillaNET;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        Foundation foundation;

        public Form1()
        {
            InitializeComponent();

            foundation = new Foundation(this);

            foundation.Plane.RedrawWhole();
            pictureBoxEdit.Image = foundation.Plane.Image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showGridToolStripMenuItem.Checked = checkShowGrid.Checked;
            snapToGridToolStripMenuItem.Checked = checkSnapGrid.Checked;

            ToolTip toolTip = new ToolTip();

            toolTip.SetToolTip(this.buttonAddDef, "Add new definition");
            toolTip.SetToolTip(this.buttonMoveUpDef, "Shift definition up");
            toolTip.SetToolTip(this.buttonMoveDownDef, "Shift definition down");
            toolTip.SetToolTip(this.buttonDeleteDef, "Delete definition");
            toolTip.SetToolTip(this.dictionaryBox, "Click to select definition");

            toolTip.SetToolTip(this.buttonMoveUpObj, "Shift object up");
            toolTip.SetToolTip(this.buttonMoveDownObj, "Shift object down");
            toolTip.SetToolTip(this.buttonDeleteObj, "Delete object");
            toolTip.SetToolTip(this.levelBox, "Click to select object");

            toolTip.SetToolTip(this.checkShowGrid, "Show/hide grid");
            toolTip.SetToolTip(this.checkSnapGrid, "Align new objects to grid-cells");

            toolTip.SetToolTip(this.scintillaCodeLevel, "Starting point for code generation");
            toolTip.SetToolTip(this.scintillaCodeDef, "Definition specific code");
            toolTip.SetToolTip(this.scintillaCodeDefObj, "Code assigned to new objects of this definition");
            toolTip.SetToolTip(this.scintillaCodeObj, "Object specific code");

            toolTip.SetToolTip(this.buttonGenerate, "Generate output into a file");

            foreach (Scintilla S in 
                new Scintilla[] { scintillaCodeLevel, scintillaCodeDef, scintillaCodeDefObj, scintillaCodeObj })
            {
                S.Styles[Style.Default].Font = "Consolas";
                S.Styles[Style.Default].Size = 14;
                S.SetWhitespaceForeColor(true, Color.SteelBlue);
                S.Margins[0].Width = 24;
            }
        }

        internal Color PlaneBackColor
        {
            get { return pictureBoxEdit.BackColor; }
        }

        internal Size PlaneSize
        {
            get { return pictureBoxEdit.Size; }
        }

        internal Size GridCellSize
        {
            get
            {
                return new Size((int)numericGridW.Value, (int)numericGridH.Value);
            }
        }

        internal bool ShouldShowGrid
        {
            get { return checkShowGrid.Checked; }
        }

        internal bool ShouldSnapGrid
        {
            get { return checkSnapGrid.Checked; }
        }

        private void renewDictionaryBox()
        {
            dictionaryBox.Items.Clear();

            for (int i = 0; i < foundation.Dictionary.Count; ++i)
                dictionaryBox.Items.Add(foundation.Dictionary[i].ToString());
        }

        private void renewLevelBox()
        {
            levelBox.Items.Clear();

            for (int i = 0; i < foundation.Level.Count; ++i)
                levelBox.Items.Add(foundation.Level[i].ToString());
        }

        private void renewBoxes()
        {
            renewDictionaryBox();
            renewLevelBox();
        }

        internal void onDictionaryChanged(int SelectedIndex)
        {
            if (SelectedIndex < 0) SelectedIndex = dictionaryBox.SelectedIndex;

            renewDictionaryBox();

            if (SelectedIndex >= 0 && SelectedIndex < dictionaryBox.Items.Count)
            {
                dictionaryBox.SelectedIndex = SelectedIndex;
                defProperties.SelectedObject = foundation.Dictionary[SelectedIndex];
            }
            else
            {
                defProperties.SelectedObject = null;
            }
        }

        internal void onLevelChanged(int SelectedIndex)
        {
            if (SelectedIndex < 0) SelectedIndex = levelBox.SelectedIndex;

            renewLevelBox();
            
            if (SelectedIndex >= 0 && SelectedIndex < levelBox.Items.Count)
            {
                levelBox.SelectedIndex = SelectedIndex;
                objProperties.SelectedObject = foundation.Level[SelectedIndex];
            }
            else
            {
                objProperties.SelectedObject = null;
            }

            onPlaneChanged(true);
        }

        internal void onDictAndLevelChanged()
        {
            onDictionaryChanged(-1);
            onLevelChanged(-1);
        }

        internal void onDefinitionChanged()
        {
            renewDictionaryBox();
            onPlaneChanged(true);
        }

        internal void onPlaneChanged(bool RedrawWhole)
        {
            if (RedrawWhole) foundation.Plane.RedrawWhole();
            else foundation.Plane.RedrawIncrm();

            pictureBoxEdit.Image = foundation.Plane.Image;
            numericGridW.Value = foundation.Plane.GridCellSize.Width;
            numericGridH.Value = foundation.Plane.GridCellSize.Height;
            checkShowGrid.Checked = foundation.Plane.IsDrawGrid;
            checkSnapGrid.Checked = foundation.Plane.IsSnapGrid;
        }

        internal void onObjPositionChanged(Object I)
        {
            if (I == foundation.Plane.ObjTemporas)
            {
                foundation.Plane.RedrawIncrm();
                pictureBoxEdit.Image = foundation.Plane.Image;
            }
            else
            {
                renewLevelBox();
                foundation.Plane.RedrawWhole();
                pictureBoxEdit.Image = foundation.Plane.Image;
            }
        }

        private void buttonAddDef_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Definition name", "Name", "New Definition", 
                this.Left + 100, this.Top + 100
                );

            if (name != null && name.Length > 0)
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Title = "Open Image";
                    dialog.Filter = "Bitmap files(*.bmp,*.gif,*.jpg,*.jpeg,*.png,*.ico)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        foundation.AddDefinition(name, dialog.FileName);
                    }
                }
            }
        }

        private void buttonMoveUpDef_Click(object sender, EventArgs e)
        {
            int index = dictionaryBox.SelectedIndex;

            selectedDefValid = false;

            if (index >= 0) foundation.MoveDefUp(index);
        }

        private void buttonMoveDownDef_Click(object sender, EventArgs e)
        {
            int index = dictionaryBox.SelectedIndex;

            selectedDefValid = false;

            if (index >= 0) foundation.MoveDefDown(index);
        }

        private void buttonDeleteDef_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this definition and all objects associated with it?", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            int index = dictionaryBox.SelectedIndex;

            selectedDefValid = false;

            if (index >= 0)
            {
                foundation.DeleteDefinition(index);

                if (foundation.Dictionary.Count == 0)
                {
                    buttonMoveUpDef.Enabled = false;
                    buttonMoveDownDef.Enabled = false;
                    buttonDeleteDef.Enabled = false;
                }

                if (foundation.Level.Count == 0)
                {
                    buttonMoveUpObj.Enabled = false;
                    buttonMoveDownObj.Enabled = false;
                    buttonDeleteObj.Enabled = false;
                }
            }
        }

        private void buttonMoveUpInst_Click(object sender, EventArgs e)
        {
            int index = levelBox.SelectedIndex;

            selectedObjValid = false;

            if (index >= 0) foundation.MoveObjUp(index);
        }

        private void buttonMoveDownInst_Click(object sender, EventArgs e)
        {
            int index = levelBox.SelectedIndex;

            selectedObjValid = false;

            if (index >= 0) foundation.MoveObjDown(index);
        }

        private void buttonDeleteInst_Click(object sender, EventArgs e)
        {
            int index = levelBox.SelectedIndex;

            selectedObjValid = false;

            if (index >= 0)
            {
                foundation.DeleteObject(index);

                if (foundation.Level.Count == 0)
                {
                    buttonMoveUpObj.Enabled = false;
                    buttonMoveDownObj.Enabled = false;
                    buttonDeleteObj.Enabled = false;
                }
            }
        }

        Point? mouseMiddleHoldStart = null;

        private void pictureBoxEdit_MouseEnter(object sender, EventArgs e)
        {
            foundation.Plane.SetShowObjTemporas(true);
        }

        private void shiftAddTemporas()
        {
            if (foundation.Plane.ObjTemporas == null) return;

            Point curr = foundation.Plane.ObjTemporas.Position;
            curr = foundation.Plane.SnapToGrid(curr.X, curr.Y, false);

            bool put = true;

            for (int i = 0; i < foundation.Level.Count; ++i)
            {
                if (foundation.Level[i].Position.Equals(curr) &&
                    foundation.Level[i].GetDefinition() == foundation.Plane.ObjTemporas.GetDefinition())
                {
                    put = false;
                    break;
                }
            }

            if (put)
            {
                putSelectedDefCode();
                foundation.AddObjTemporasToLevel();
            }
        }

        private void pictureBoxEdit_MouseMove(object sender, MouseEventArgs e)
        {
            labelCoords.Text = foundation.Plane.GetCoordsOnPlane(e.X, e.Y).ToString();

            if (foundation.Plane.ObjTemporas == null) return;

            foundation.MoveObjTemporas(e.X, e.Y);

            if (foundation.Plane.IsSnapGrid &&
                (Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left &&
                (Control.ModifierKeys & Keys.Shift) != 0)
            {
                shiftAddTemporas();
            }
        }

        private void pictureBoxEdit_MouseLeave(object sender, EventArgs e)
        {
            mouseMiddleHoldStart = null;
            foundation.Plane.SetShowObjTemporas(false);
            onPlaneChanged(false);
        }

        private void pictureBoxEdit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                putSelectedDefCode();

                if (foundation.Plane.IsSnapGrid &&
                    (Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left &&
                    (Control.ModifierKeys & Keys.Shift) != 0)
                {
                    shiftAddTemporas();
                }
                else
                {
                    foundation.AddObjTemporasToLevel();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (foundation.Plane.ObjTemporas != null)
                {
                    dictionaryBox.ClearSelected();
                    foundation.ForgetObjTemporas();
                }
                else
                {
                    foundation.DeleteObjectAt(e.Location);

                    if (foundation.Level.Count == 0)
                    {
                        buttonMoveUpObj.Enabled = false;
                        buttonMoveDownObj.Enabled = false;
                        buttonDeleteObj.Enabled = false;
                    }
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                mouseMiddleHoldStart = new Point(e.X, e.Y);
            }
        }

        private void pictureBoxEdit_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (mouseMiddleHoldStart != null)
                {
                    Point trans = foundation.Plane.Translation;
                    trans.X += e.X - mouseMiddleHoldStart.Value.X;
                    trans.Y += e.Y - mouseMiddleHoldStart.Value.Y;
                    foundation.Plane.SetTranslation(trans.X, trans.Y);

                    mouseMiddleHoldStart = null;
                    onPlaneChanged(true);
                }
            }
        }

        private void pictureBoxEdit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                foundation.Plane.SetTranslation(0, 0);
                mouseMiddleHoldStart = null;
                onPlaneChanged(true);
            }
        }

        private void putBaseCode()
        {
            foundation.Level.GetCode().CopySplitLines(scintillaCodeLevel.Text);
        }

        private void takeBaseCode()
        {
            string[] code = foundation.Level.GetCode().LinesAsArray;
            if (code != null)
            {
                scintillaCodeLevel.ClearAll();

                for (int i = 0; i < code.Length; ++i)
                {
                    //if (i > 0) richTextCodeBase.AppendText("\r\n");
                    scintillaCodeLevel.AppendText(code[i]);
                }
            }
            else
            {
                scintillaCodeLevel.ClearAll();
            }
        }

        int selectedDefIndex;
        bool selectedDefValid = false;

        private void putSelectedDefCode()
        {
            if (selectedDefValid && selectedDefIndex >= 0)
            {
                foundation.Dictionary[selectedDefIndex].GetCode().CopySplitLines(scintillaCodeDef.Text);
                foundation.Dictionary[selectedDefIndex].GetCodeObjAuto().CopySplitLines(scintillaCodeDefObj.Text);

                if (foundation.Plane.ObjTemporas != null)
                {
                    foundation.Plane.ObjTemporas.GetCode().CopyFrom(foundation.Dictionary[selectedDefIndex].GetCodeObjAuto());
                }
            }
        }

        private void takeSelectedDefCode()
        {
            if (!selectedDefValid)
            {
                scintillaCodeDef.ClearAll();
                return;
            }

            string[] code = foundation.Dictionary[selectedDefIndex].GetCode().LinesAsArray;
            if (code != null)
            {
                scintillaCodeDef.ClearAll();

                for (int i = 0; i < code.Length; ++i)
                {
                    //if (i > 0) richTextCodeBase.AppendText("\r\n");
                    scintillaCodeDef.AppendText(code[i]);
                }
            }
            else
            {
                scintillaCodeDef.ClearAll();
            }

            code = foundation.Dictionary[selectedDefIndex].GetCodeObjAuto().LinesAsArray;
            if (code != null)
            {
                scintillaCodeDefObj.ClearAll();

                for (int i = 0; i < code.Length; ++i)
                {
                    //if (i > 0) richTextCodeBase.AppendText("\r\n");
                    scintillaCodeDefObj.AppendText(code[i]);
                }
            }
            else
            {
                scintillaCodeDefObj.ClearAll();
            }
        }

        private void dictionaryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            putSelectedDefCode();

            selectedDefIndex = dictionaryBox.SelectedIndex;
            if (selectedDefIndex >= 0)
            {
                selectedDefValid = true;

                foundation.MakeObjTemporas(foundation.Dictionary[selectedDefIndex]);
                defProperties.SelectedObject = foundation.Dictionary[selectedDefIndex];

                buttonMoveUpDef.Enabled = true;
                buttonMoveDownDef.Enabled = true;
                buttonDeleteDef.Enabled = true;

                scintillaCodeDef.Enabled = true;
                scintillaCodeDefObj.Enabled = true;

                takeSelectedDefCode();
            }
            else
            {
                selectedDefValid = false;

                buttonMoveUpDef.Enabled = false;
                buttonMoveDownDef.Enabled = false;
                buttonDeleteDef.Enabled = false;

                scintillaCodeDef.Enabled = false;
                scintillaCodeDef.ClearAll();
                scintillaCodeDefObj.Enabled = false;
                scintillaCodeDefObj.ClearAll();
            }
        }

        int selectedObjIndex = -1;
        bool selectedObjValid = false;

        private void putSelectedObjCode()
        {
            if (selectedObjValid && selectedObjIndex >= 0)
            {
                foundation.Level[selectedObjIndex].GetCode().CopySplitLines(scintillaCodeObj.Text);
            }
        }

        private void takeSelectedObjCode()
        {
            if (!selectedObjValid)
            {
                scintillaCodeObj.ClearAll();
                return;
            }

            string[] code = foundation.Level[selectedObjIndex].GetCode().LinesAsArray;
            if (code != null)
            {
                scintillaCodeObj.ClearAll();

                for (int i = 0; i < code.Length; ++i)
                {
                    //if (i > 0) richTextCodeBase.AppendText("\r\n");
                    scintillaCodeObj.AppendText(code[i]);
                }
            }
            else
            {
                scintillaCodeObj.ClearAll();
            }
        }

        private void levelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            putSelectedObjCode();

            selectedObjIndex = levelBox.SelectedIndex;
            if (selectedObjIndex >= 0)
            {
                selectedObjValid = true;

                /*foundation.ForgetObjTemporas();*/
                objProperties.SelectedObject = foundation.Level[selectedObjIndex];

                buttonMoveUpObj.Enabled = true;
                buttonMoveDownObj.Enabled = true;
                buttonDeleteObj.Enabled = true;

                scintillaCodeObj.Enabled = true;

                takeSelectedObjCode();
            }
            else
            {
                selectedObjValid = false;

                buttonMoveUpObj.Enabled = false;
                buttonMoveDownObj.Enabled = false;
                buttonDeleteObj.Enabled = false;

                scintillaCodeObj.Enabled = false;
                scintillaCodeObj.ClearAll();
            }
        }

        private void numericGridW_ValueChanged(object sender, EventArgs e)
        {
            Size size = new Size();
            size.Width = (int)numericGridW.Value;
            size.Height = foundation.Plane.GridCellSize.Height;
            foundation.Plane.GridCellSize = size;
            onPlaneChanged(true);
        }

        private void numericGridH_ValueChanged(object sender, EventArgs e)
        {
            Size size = new Size();
            size.Width = foundation.Plane.GridCellSize.Width;
            size.Height = (int)numericGridH.Value;
            foundation.Plane.GridCellSize = size;
            onPlaneChanged(true);
        }

        private void checkShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            showGridToolStripMenuItem.Checked = checkShowGrid.Checked;
            foundation.Plane.IsDrawGrid = checkShowGrid.Checked;
            onPlaneChanged(true);
        }

        private void checkSnapGrid_CheckedChanged(object sender, EventArgs e)
        {
            snapToGridToolStripMenuItem.Checked = checkSnapGrid.Checked;
            foundation.Plane.IsSnapGrid = checkSnapGrid.Checked;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            foundation.Plane.SetSize(pictureBoxEdit.Size);
            onPlaneChanged(true);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (askAboutSavingAndSave() == DialogResult.Cancel) return;

            foundation.Reset();

            selectedDefValid = false;
            selectedObjValid = false;

            takeBaseCode();
            takeSelectedDefCode();
            takeSelectedObjCode();
        }

        private void newLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (askAboutSavingAndSave() == DialogResult.Cancel) return;

            foundation.ResetLevel();

            selectedObjValid = false;

            takeBaseCode();
            takeSelectedDefCode();
            takeSelectedObjCode();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (askAboutSavingAndSave() == DialogResult.Cancel) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PSM Files|*.psm;*.txt";
            openFileDialog.Title = "Load From File(s)";

            if (openFileDialog.ShowDialog() != DialogResult.OK ||
                openFileDialog.FileName == null ||
                openFileDialog.FileName.Length == 0)
                return;

            string dictFilePath = foundation.ExtractDictionaryPathFromLevelFile(openFileDialog.FileName);

            if (dictFilePath != null)
            {
                if (foundation.Dictionary.Load(dictFilePath))
                {
                    if (foundation.Level.Load(openFileDialog.FileName))
                        takeBaseCode();
                }
            }
            else
            {
                foundation.Dictionary.Load(openFileDialog.FileName);
            }

            onDictAndLevelChanged();
        }

        private bool saveDictionaryAskPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PSM Dictionary File|*.psm;*.txt";
            saveFileDialog.Title = "Save Dictionary";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != null && 
                saveFileDialog.FileName.Length != 0)
            {
                return foundation.Dictionary.Save(saveFileDialog.FileName);
            }
            else
            {
                return false;
            }
        }

        private bool saveDictionary(bool AskPathRegardless)
        {
            putBaseCode();
            putSelectedDefCode();
            putSelectedObjCode();

            if (!AskPathRegardless &&
                foundation.Dictionary.GetFilePath() != null &&
                foundation.Dictionary.GetFilePath().Length != 0)
            {
                return foundation.Dictionary.Save();
            }
            else
            {
                MessageBox.Show("You will now save the dictionary.", "Save Dictionary");
                return saveDictionaryAskPath();
            }
        }

        private bool saveLevelAskPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PSM Level File|*.psm;*.txt";
            saveFileDialog.Title = "Save Level";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != null &&
                saveFileDialog.FileName.Length != 0)
            {
                return foundation.Level.Save(saveFileDialog.FileName);
            }
            else
            {
                return false;
            }
        }

        private bool saveLevel(bool AskPathRegardless)
        {
            putBaseCode();
            putSelectedObjCode();

            if (!AskPathRegardless &&
                foundation.Level.GetFilePath() != null &&
                foundation.Level.GetFilePath().Length != 0)
            {
                return foundation.Level.Save();
            }
            else
            {
                MessageBox.Show("You will now save the level.", "Save Level");
                return saveLevelAskPath();
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveDictionary(false);
            saveLevel(false);
        }

        private void saveDictionaryAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDictionary(true);
        }

        private void saveLevelAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveLevel(true);
        }

        private DialogResult askAboutSavingAndSave()
        {
            DialogResult res = MessageBox.Show("Would you like to save before continuing?", "Save First", MessageBoxButtons.YesNoCancel);

            if (res == DialogResult.Yes)
            {
                saveDictionary(false);
                saveLevel(false);
            }

            return res;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            putBaseCode();
            putSelectedDefCode();
            putSelectedObjCode();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.*";
            saveFileDialog.Title = "Generate Code Into";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != null &&
                saveFileDialog.FileName.Length != 0)
            {
                string error = foundation.Generator.Generate(saveFileDialog.FileName);
                if (error == null) MessageBox.Show("Code has been successfully generated.", "Generated");
                else MessageBox.Show(error, "Error");
            }
        }

        private void buttonReinsertObjCode_Click(object sender, EventArgs e)
        {
            if (selectedDefValid && selectedDefIndex >= 0)
            {
                putSelectedDefCode();

                Definition def = foundation.Dictionary[selectedDefIndex];
                Code code = def.GetCodeObjAuto();

                for (int i = 0; i < foundation.Level.Count; ++i)
                {
                    if (foundation.Level[i].GetDefinition() == def)
                    {
                        foundation.Level[i].GetCode().CopyFrom(code);
                    }
                }

                takeSelectedObjCode();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkShowGrid.Checked = showGridToolStripMenuItem.Checked;
            foundation.Plane.IsDrawGrid = checkShowGrid.Checked;
            onPlaneChanged(true);
        }

        private void snapToGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkSnapGrid.Checked = snapToGridToolStripMenuItem.Checked;
            foundation.Plane.IsSnapGrid = checkSnapGrid.Checked;
        }

        private void resetOffsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foundation.Plane.SetTranslation(0, 0);
            mouseMiddleHoldStart = null;
            onPlaneChanged(true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (askAboutSavingAndSave() == DialogResult.Cancel) e.Cancel = true;
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

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void textCodeInst_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBoxEdit_Resize(object sender, EventArgs e)
        {
        }
    }
}
