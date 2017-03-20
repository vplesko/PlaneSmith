namespace LevelEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.levelBox = new System.Windows.Forms.ListBox();
            this.dictionaryBox = new System.Windows.Forms.ListBox();
            this.buttonAddDef = new System.Windows.Forms.Button();
            this.defProperties = new System.Windows.Forms.PropertyGrid();
            this.instProperties = new System.Windows.Forms.PropertyGrid();
            this.numericGridW = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericGridH = new System.Windows.Forms.NumericUpDown();
            this.checkShowGrid = new System.Windows.Forms.CheckBox();
            this.checkSnapGrid = new System.Windows.Forms.CheckBox();
            this.labelCoords = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDictionaryAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLevelAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGridW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGridH)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBoxEdit.Location = new System.Drawing.Point(212, 55);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(557, 494);
            this.pictureBoxEdit.TabIndex = 0;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxEdit_Paint);
            this.pictureBoxEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEdit_MouseDown);
            this.pictureBoxEdit.MouseEnter += new System.EventHandler(this.pictureBoxEdit_MouseEnter);
            this.pictureBoxEdit.MouseLeave += new System.EventHandler(this.pictureBoxEdit_MouseLeave);
            this.pictureBoxEdit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEdit_MouseMove);
            // 
            // levelBox
            // 
            this.levelBox.FormattingEnabled = true;
            this.levelBox.Location = new System.Drawing.Point(775, 35);
            this.levelBox.Name = "levelBox";
            this.levelBox.Size = new System.Drawing.Size(197, 316);
            this.levelBox.TabIndex = 3;
            this.levelBox.SelectedIndexChanged += new System.EventHandler(this.levelBox_SelectedIndexChanged);
            this.levelBox.MouseLeave += new System.EventHandler(this.levelBox_MouseLeave);
            // 
            // dictionaryBox
            // 
            this.dictionaryBox.FormattingEnabled = true;
            this.dictionaryBox.Location = new System.Drawing.Point(12, 30);
            this.dictionaryBox.Name = "dictionaryBox";
            this.dictionaryBox.Size = new System.Drawing.Size(194, 277);
            this.dictionaryBox.TabIndex = 4;
            this.dictionaryBox.SelectedIndexChanged += new System.EventHandler(this.dictionaryBox_SelectedIndexChanged);
            // 
            // buttonAddDef
            // 
            this.buttonAddDef.Location = new System.Drawing.Point(12, 320);
            this.buttonAddDef.Name = "buttonAddDef";
            this.buttonAddDef.Size = new System.Drawing.Size(194, 31);
            this.buttonAddDef.TabIndex = 5;
            this.buttonAddDef.Text = "Add";
            this.buttonAddDef.UseVisualStyleBackColor = true;
            this.buttonAddDef.Click += new System.EventHandler(this.buttonAddDef_Click);
            // 
            // defProperties
            // 
            this.defProperties.Location = new System.Drawing.Point(12, 357);
            this.defProperties.Name = "defProperties";
            this.defProperties.Size = new System.Drawing.Size(194, 192);
            this.defProperties.TabIndex = 6;
            // 
            // instProperties
            // 
            this.instProperties.Location = new System.Drawing.Point(775, 357);
            this.instProperties.Name = "instProperties";
            this.instProperties.Size = new System.Drawing.Size(197, 192);
            this.instProperties.TabIndex = 7;
            // 
            // numericGridW
            // 
            this.numericGridW.Location = new System.Drawing.Point(287, 31);
            this.numericGridW.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericGridW.Name = "numericGridW";
            this.numericGridW.Size = new System.Drawing.Size(57, 20);
            this.numericGridW.TabIndex = 8;
            this.numericGridW.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericGridW.ValueChanged += new System.EventHandler(this.numericGridW_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Grid cell size:";
            // 
            // numericGridH
            // 
            this.numericGridH.Location = new System.Drawing.Point(350, 31);
            this.numericGridH.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericGridH.Name = "numericGridH";
            this.numericGridH.Size = new System.Drawing.Size(57, 20);
            this.numericGridH.TabIndex = 10;
            this.numericGridH.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericGridH.ValueChanged += new System.EventHandler(this.numericGridH_ValueChanged);
            // 
            // checkShowGrid
            // 
            this.checkShowGrid.AutoSize = true;
            this.checkShowGrid.Checked = true;
            this.checkShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowGrid.Location = new System.Drawing.Point(413, 32);
            this.checkShowGrid.Name = "checkShowGrid";
            this.checkShowGrid.Size = new System.Drawing.Size(73, 17);
            this.checkShowGrid.TabIndex = 11;
            this.checkShowGrid.Text = "Show grid";
            this.checkShowGrid.UseVisualStyleBackColor = true;
            this.checkShowGrid.CheckedChanged += new System.EventHandler(this.checkShowGrid_CheckedChanged);
            // 
            // checkSnapGrid
            // 
            this.checkSnapGrid.AutoSize = true;
            this.checkSnapGrid.Location = new System.Drawing.Point(492, 32);
            this.checkSnapGrid.Name = "checkSnapGrid";
            this.checkSnapGrid.Size = new System.Drawing.Size(83, 17);
            this.checkSnapGrid.TabIndex = 12;
            this.checkSnapGrid.Text = "Snap to grid";
            this.checkSnapGrid.UseVisualStyleBackColor = true;
            this.checkSnapGrid.CheckedChanged += new System.EventHandler(this.checkSnapGrid_CheckedChanged);
            // 
            // labelCoords
            // 
            this.labelCoords.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelCoords.Location = new System.Drawing.Point(652, 28);
            this.labelCoords.Name = "labelCoords";
            this.labelCoords.Size = new System.Drawing.Size(117, 23);
            this.labelCoords.TabIndex = 13;
            this.labelCoords.Text = "(0, 0)";
            this.labelCoords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.newLevelToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.saveDictionaryAsToolStripMenuItem,
            this.saveLevelAsToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // newLevelToolStripMenuItem
            // 
            this.newLevelToolStripMenuItem.Name = "newLevelToolStripMenuItem";
            this.newLevelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newLevelToolStripMenuItem.Text = "New Level...";
            this.newLevelToolStripMenuItem.Click += new System.EventHandler(this.newLevelToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // saveDictionaryAsToolStripMenuItem
            // 
            this.saveDictionaryAsToolStripMenuItem.Name = "saveDictionaryAsToolStripMenuItem";
            this.saveDictionaryAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveDictionaryAsToolStripMenuItem.Text = "Save Dictionary As...";
            this.saveDictionaryAsToolStripMenuItem.Click += new System.EventHandler(this.saveDictionaryAsToolStripMenuItem_Click);
            // 
            // saveLevelAsToolStripMenuItem
            // 
            this.saveLevelAsToolStripMenuItem.Name = "saveLevelAsToolStripMenuItem";
            this.saveLevelAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveLevelAsToolStripMenuItem.Text = "Save Level As...";
            this.saveLevelAsToolStripMenuItem.Click += new System.EventHandler(this.saveLevelAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.labelCoords);
            this.Controls.Add(this.checkSnapGrid);
            this.Controls.Add(this.checkShowGrid);
            this.Controls.Add(this.numericGridH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericGridW);
            this.Controls.Add(this.instProperties);
            this.Controls.Add(this.defProperties);
            this.Controls.Add(this.buttonAddDef);
            this.Controls.Add(this.dictionaryBox);
            this.Controls.Add(this.levelBox);
            this.Controls.Add(this.pictureBoxEdit);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PlaneSmith";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGridW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGridH)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.ListBox levelBox;
        private System.Windows.Forms.ListBox dictionaryBox;
        private System.Windows.Forms.Button buttonAddDef;
        private System.Windows.Forms.PropertyGrid defProperties;
        private System.Windows.Forms.PropertyGrid instProperties;
        private System.Windows.Forms.NumericUpDown numericGridW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericGridH;
        private System.Windows.Forms.CheckBox checkShowGrid;
        private System.Windows.Forms.CheckBox checkSnapGrid;
        private System.Windows.Forms.Label labelCoords;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveDictionaryAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLevelAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}

