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
            this.levelBox = new System.Windows.Forms.ListBox();
            this.dictionaryBox = new System.Windows.Forms.ListBox();
            this.defProperties = new System.Windows.Forms.PropertyGrid();
            this.objProperties = new System.Windows.Forms.PropertyGrid();
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snapToGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertSegmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showWhitespacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPlane = new System.Windows.Forms.TabPage();
            this.tabCodeLevel = new System.Windows.Forms.TabPage();
            this.scintillaCodeLevel = new ScintillaNET.Scintilla();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.tabCodeDef = new System.Windows.Forms.TabPage();
            this.scintillaCodeDefObj = new ScintillaNET.Scintilla();
            this.scintillaCodeDef = new ScintillaNET.Scintilla();
            this.buttonReinsertObjCode = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabCodeObj = new System.Windows.Forms.TabPage();
            this.scintillaCodeObj = new ScintillaNET.Scintilla();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.buttonDeleteObj = new System.Windows.Forms.Button();
            this.buttonDeleteDef = new System.Windows.Forms.Button();
            this.buttonMoveDownObj = new System.Windows.Forms.Button();
            this.buttonMoveUpObj = new System.Windows.Forms.Button();
            this.buttonMoveDownDef = new System.Windows.Forms.Button();
            this.buttonMoveUpDef = new System.Windows.Forms.Button();
            this.buttonAddDef = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericGridW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGridH)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPlane.SuspendLayout();
            this.tabCodeLevel.SuspendLayout();
            this.tabCodeDef.SuspendLayout();
            this.tabCodeObj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // levelBox
            // 
            this.levelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.levelBox.FormattingEnabled = true;
            this.levelBox.Location = new System.Drawing.Point(742, 61);
            this.levelBox.Name = "levelBox";
            this.levelBox.Size = new System.Drawing.Size(230, 264);
            this.levelBox.TabIndex = 3;
            this.levelBox.SelectedIndexChanged += new System.EventHandler(this.levelBox_SelectedIndexChanged);
            this.levelBox.MouseLeave += new System.EventHandler(this.levelBox_MouseLeave);
            // 
            // dictionaryBox
            // 
            this.dictionaryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dictionaryBox.FormattingEnabled = true;
            this.dictionaryBox.Location = new System.Drawing.Point(12, 61);
            this.dictionaryBox.Name = "dictionaryBox";
            this.dictionaryBox.Size = new System.Drawing.Size(230, 264);
            this.dictionaryBox.TabIndex = 4;
            this.dictionaryBox.SelectedIndexChanged += new System.EventHandler(this.dictionaryBox_SelectedIndexChanged);
            // 
            // defProperties
            // 
            this.defProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.defProperties.Location = new System.Drawing.Point(12, 331);
            this.defProperties.Name = "defProperties";
            this.defProperties.Size = new System.Drawing.Size(228, 218);
            this.defProperties.TabIndex = 6;
            // 
            // objProperties
            // 
            this.objProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.objProperties.Location = new System.Drawing.Point(742, 331);
            this.objProperties.Name = "objProperties";
            this.objProperties.Size = new System.Drawing.Size(230, 218);
            this.objProperties.TabIndex = 7;
            // 
            // numericGridW
            // 
            this.numericGridW.Location = new System.Drawing.Point(78, 6);
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
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Grid cell size:";
            // 
            // numericGridH
            // 
            this.numericGridH.Location = new System.Drawing.Point(141, 6);
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
            this.checkShowGrid.Location = new System.Drawing.Point(204, 7);
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
            this.checkSnapGrid.Location = new System.Drawing.Point(283, 7);
            this.checkSnapGrid.Name = "checkSnapGrid";
            this.checkSnapGrid.Size = new System.Drawing.Size(83, 17);
            this.checkSnapGrid.TabIndex = 12;
            this.checkSnapGrid.Text = "Snap to grid";
            this.checkSnapGrid.UseVisualStyleBackColor = true;
            this.checkSnapGrid.CheckedChanged += new System.EventHandler(this.checkSnapGrid_CheckedChanged);
            // 
            // labelCoords
            // 
            this.labelCoords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCoords.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelCoords.Location = new System.Drawing.Point(357, 3);
            this.labelCoords.Name = "labelCoords";
            this.labelCoords.Size = new System.Drawing.Size(117, 23);
            this.labelCoords.TabIndex = 13;
            this.labelCoords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.codingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
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
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
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
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showGridToolStripMenuItem,
            this.snapToGridToolStripMenuItem,
            this.resetOffsetToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showGridToolStripMenuItem
            // 
            this.showGridToolStripMenuItem.CheckOnClick = true;
            this.showGridToolStripMenuItem.Name = "showGridToolStripMenuItem";
            this.showGridToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.showGridToolStripMenuItem.Text = "Show grid";
            this.showGridToolStripMenuItem.Click += new System.EventHandler(this.showGridToolStripMenuItem_Click);
            // 
            // snapToGridToolStripMenuItem
            // 
            this.snapToGridToolStripMenuItem.CheckOnClick = true;
            this.snapToGridToolStripMenuItem.Name = "snapToGridToolStripMenuItem";
            this.snapToGridToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.snapToGridToolStripMenuItem.Text = "Snap to grid";
            this.snapToGridToolStripMenuItem.Click += new System.EventHandler(this.snapToGridToolStripMenuItem_Click);
            // 
            // resetOffsetToolStripMenuItem
            // 
            this.resetOffsetToolStripMenuItem.Name = "resetOffsetToolStripMenuItem";
            this.resetOffsetToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.resetOffsetToolStripMenuItem.Text = "Reset offset";
            this.resetOffsetToolStripMenuItem.Click += new System.EventHandler(this.resetOffsetToolStripMenuItem_Click);
            // 
            // codingToolStripMenuItem
            // 
            this.codingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertSegmentToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.toolStripSeparator2,
            this.showWhitespacesToolStripMenuItem});
            this.codingToolStripMenuItem.Name = "codingToolStripMenuItem";
            this.codingToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.codingToolStripMenuItem.Text = "Coding";
            // 
            // insertSegmentToolStripMenuItem
            // 
            this.insertSegmentToolStripMenuItem.Name = "insertSegmentToolStripMenuItem";
            this.insertSegmentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.insertSegmentToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.insertSegmentToolStripMenuItem.Text = "Insert segment";
            this.insertSegmentToolStripMenuItem.Click += new System.EventHandler(this.insertSegmentToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // showWhitespacesToolStripMenuItem
            // 
            this.showWhitespacesToolStripMenuItem.Checked = true;
            this.showWhitespacesToolStripMenuItem.CheckOnClick = true;
            this.showWhitespacesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showWhitespacesToolStripMenuItem.Name = "showWhitespacesToolStripMenuItem";
            this.showWhitespacesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.showWhitespacesToolStripMenuItem.Text = "Show whitespaces";
            this.showWhitespacesToolStripMenuItem.Click += new System.EventHandler(this.showWhitespacesToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPlane);
            this.tabControl1.Controls.Add(this.tabCodeLevel);
            this.tabControl1.Controls.Add(this.tabCodeDef);
            this.tabControl1.Controls.Add(this.tabCodeObj);
            this.tabControl1.Location = new System.Drawing.Point(248, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(488, 533);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPlane
            // 
            this.tabPlane.BackColor = System.Drawing.SystemColors.Control;
            this.tabPlane.Controls.Add(this.label1);
            this.tabPlane.Controls.Add(this.numericGridW);
            this.tabPlane.Controls.Add(this.numericGridH);
            this.tabPlane.Controls.Add(this.checkShowGrid);
            this.tabPlane.Controls.Add(this.checkSnapGrid);
            this.tabPlane.Controls.Add(this.pictureBoxEdit);
            this.tabPlane.Controls.Add(this.labelCoords);
            this.tabPlane.Location = new System.Drawing.Point(4, 25);
            this.tabPlane.Name = "tabPlane";
            this.tabPlane.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlane.Size = new System.Drawing.Size(480, 504);
            this.tabPlane.TabIndex = 0;
            this.tabPlane.Text = "Plane";
            // 
            // tabCodeLevel
            // 
            this.tabCodeLevel.BackColor = System.Drawing.SystemColors.Control;
            this.tabCodeLevel.Controls.Add(this.scintillaCodeLevel);
            this.tabCodeLevel.Controls.Add(this.buttonGenerate);
            this.tabCodeLevel.Location = new System.Drawing.Point(4, 25);
            this.tabCodeLevel.Name = "tabCodeLevel";
            this.tabCodeLevel.Padding = new System.Windows.Forms.Padding(3);
            this.tabCodeLevel.Size = new System.Drawing.Size(480, 504);
            this.tabCodeLevel.TabIndex = 1;
            this.tabCodeLevel.Text = "Level Code";
            // 
            // scintillaCodeLevel
            // 
            this.scintillaCodeLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintillaCodeLevel.Location = new System.Drawing.Point(3, 3);
            this.scintillaCodeLevel.Name = "scintillaCodeLevel";
            this.scintillaCodeLevel.Size = new System.Drawing.Size(540, 464);
            this.scintillaCodeLevel.TabIndex = 7;
            this.scintillaCodeLevel.UseTabs = true;
            this.scintillaCodeLevel.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleOnlyIndent;
            this.scintillaCodeLevel.TextChanged += new System.EventHandler(this.scintillaCodeLevel_TextChanged);
            this.scintillaCodeLevel.Click += new System.EventHandler(this.scintillaCodeLevel_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonGenerate.Location = new System.Drawing.Point(238, 473);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 6;
            this.buttonGenerate.Text = "Generate!";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // tabCodeDef
            // 
            this.tabCodeDef.Controls.Add(this.scintillaCodeDefObj);
            this.tabCodeDef.Controls.Add(this.scintillaCodeDef);
            this.tabCodeDef.Controls.Add(this.buttonReinsertObjCode);
            this.tabCodeDef.Controls.Add(this.label3);
            this.tabCodeDef.Controls.Add(this.label2);
            this.tabCodeDef.Location = new System.Drawing.Point(4, 25);
            this.tabCodeDef.Name = "tabCodeDef";
            this.tabCodeDef.Size = new System.Drawing.Size(480, 504);
            this.tabCodeDef.TabIndex = 2;
            this.tabCodeDef.Text = "Def. Code";
            this.tabCodeDef.UseVisualStyleBackColor = true;
            // 
            // scintillaCodeDefObj
            // 
            this.scintillaCodeDefObj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintillaCodeDefObj.Location = new System.Drawing.Point(6, 348);
            this.scintillaCodeDefObj.Name = "scintillaCodeDefObj";
            this.scintillaCodeDefObj.Size = new System.Drawing.Size(471, 119);
            this.scintillaCodeDefObj.TabIndex = 14;
            this.scintillaCodeDefObj.UseTabs = true;
            this.scintillaCodeDefObj.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleOnlyIndent;
            this.scintillaCodeDefObj.TextChanged += new System.EventHandler(this.scintillaCodeDefObj_TextChanged);
            this.scintillaCodeDefObj.Click += new System.EventHandler(this.scintillaCodeDefObj_Click);
            // 
            // scintillaCodeDef
            // 
            this.scintillaCodeDef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintillaCodeDef.Location = new System.Drawing.Point(4, 20);
            this.scintillaCodeDef.Name = "scintillaCodeDef";
            this.scintillaCodeDef.Size = new System.Drawing.Size(471, 309);
            this.scintillaCodeDef.TabIndex = 13;
            this.scintillaCodeDef.UseTabs = true;
            this.scintillaCodeDef.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleOnlyIndent;
            this.scintillaCodeDef.TextChanged += new System.EventHandler(this.scintillaCodeDef_TextChanged);
            this.scintillaCodeDef.Click += new System.EventHandler(this.scintillaCodeDef_Click);
            // 
            // buttonReinsertObjCode
            // 
            this.buttonReinsertObjCode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonReinsertObjCode.Location = new System.Drawing.Point(187, 473);
            this.buttonReinsertObjCode.Name = "buttonReinsertObjCode";
            this.buttonReinsertObjCode.Size = new System.Drawing.Size(109, 23);
            this.buttonReinsertObjCode.TabIndex = 12;
            this.buttonReinsertObjCode.Text = "Reinsert obj. codes";
            this.buttonReinsertObjCode.UseVisualStyleBackColor = true;
            this.buttonReinsertObjCode.Click += new System.EventHandler(this.buttonReinsertObjCode_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Object auto code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Definition code:";
            // 
            // tabCodeObj
            // 
            this.tabCodeObj.Controls.Add(this.scintillaCodeObj);
            this.tabCodeObj.Location = new System.Drawing.Point(4, 25);
            this.tabCodeObj.Name = "tabCodeObj";
            this.tabCodeObj.Size = new System.Drawing.Size(480, 504);
            this.tabCodeObj.TabIndex = 3;
            this.tabCodeObj.Text = "Obj. Code";
            this.tabCodeObj.UseVisualStyleBackColor = true;
            // 
            // scintillaCodeObj
            // 
            this.scintillaCodeObj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintillaCodeObj.Location = new System.Drawing.Point(3, 3);
            this.scintillaCodeObj.Name = "scintillaCodeObj";
            this.scintillaCodeObj.Size = new System.Drawing.Size(471, 493);
            this.scintillaCodeObj.TabIndex = 8;
            this.scintillaCodeObj.UseTabs = true;
            this.scintillaCodeObj.ViewWhitespace = ScintillaNET.WhitespaceMode.VisibleOnlyIndent;
            this.scintillaCodeObj.TextChanged += new System.EventHandler(this.scintillaCodeObj_TextChanged);
            this.scintillaCodeObj.Click += new System.EventHandler(this.scintillaCodeObj_Click);
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxEdit.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBoxEdit.Location = new System.Drawing.Point(6, 32);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(468, 464);
            this.pictureBoxEdit.TabIndex = 0;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Click += new System.EventHandler(this.pictureBoxEdit_Click);
            this.pictureBoxEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxEdit_Paint);
            this.pictureBoxEdit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEdit_MouseDoubleClick);
            this.pictureBoxEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEdit_MouseDown);
            this.pictureBoxEdit.MouseEnter += new System.EventHandler(this.pictureBoxEdit_MouseEnter);
            this.pictureBoxEdit.MouseLeave += new System.EventHandler(this.pictureBoxEdit_MouseLeave);
            this.pictureBoxEdit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEdit_MouseMove);
            this.pictureBoxEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEdit_MouseUp);
            this.pictureBoxEdit.Resize += new System.EventHandler(this.pictureBoxEdit_Resize);
            // 
            // buttonDeleteObj
            // 
            this.buttonDeleteObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteObj.Enabled = false;
            this.buttonDeleteObj.Image = global::LevelEditor.Properties.Resources.obj_del;
            this.buttonDeleteObj.Location = new System.Drawing.Point(935, 28);
            this.buttonDeleteObj.Name = "buttonDeleteObj";
            this.buttonDeleteObj.Size = new System.Drawing.Size(37, 31);
            this.buttonDeleteObj.TabIndex = 20;
            this.buttonDeleteObj.UseVisualStyleBackColor = true;
            this.buttonDeleteObj.Click += new System.EventHandler(this.buttonDeleteInst_Click);
            // 
            // buttonDeleteDef
            // 
            this.buttonDeleteDef.Enabled = false;
            this.buttonDeleteDef.Image = global::LevelEditor.Properties.Resources.def_del;
            this.buttonDeleteDef.Location = new System.Drawing.Point(141, 28);
            this.buttonDeleteDef.Name = "buttonDeleteDef";
            this.buttonDeleteDef.Size = new System.Drawing.Size(37, 31);
            this.buttonDeleteDef.TabIndex = 19;
            this.buttonDeleteDef.UseVisualStyleBackColor = true;
            this.buttonDeleteDef.Click += new System.EventHandler(this.buttonDeleteDef_Click);
            // 
            // buttonMoveDownObj
            // 
            this.buttonMoveDownObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveDownObj.Enabled = false;
            this.buttonMoveDownObj.Image = global::LevelEditor.Properties.Resources.down_arrow;
            this.buttonMoveDownObj.Location = new System.Drawing.Point(892, 28);
            this.buttonMoveDownObj.Name = "buttonMoveDownObj";
            this.buttonMoveDownObj.Size = new System.Drawing.Size(37, 31);
            this.buttonMoveDownObj.TabIndex = 18;
            this.buttonMoveDownObj.UseVisualStyleBackColor = true;
            this.buttonMoveDownObj.Click += new System.EventHandler(this.buttonMoveDownInst_Click);
            // 
            // buttonMoveUpObj
            // 
            this.buttonMoveUpObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveUpObj.Enabled = false;
            this.buttonMoveUpObj.Image = global::LevelEditor.Properties.Resources.up_arrow;
            this.buttonMoveUpObj.Location = new System.Drawing.Point(849, 28);
            this.buttonMoveUpObj.Name = "buttonMoveUpObj";
            this.buttonMoveUpObj.Size = new System.Drawing.Size(37, 31);
            this.buttonMoveUpObj.TabIndex = 17;
            this.buttonMoveUpObj.UseVisualStyleBackColor = true;
            this.buttonMoveUpObj.Click += new System.EventHandler(this.buttonMoveUpInst_Click);
            // 
            // buttonMoveDownDef
            // 
            this.buttonMoveDownDef.Enabled = false;
            this.buttonMoveDownDef.Image = global::LevelEditor.Properties.Resources.down_arrow;
            this.buttonMoveDownDef.Location = new System.Drawing.Point(98, 28);
            this.buttonMoveDownDef.Name = "buttonMoveDownDef";
            this.buttonMoveDownDef.Size = new System.Drawing.Size(37, 31);
            this.buttonMoveDownDef.TabIndex = 16;
            this.buttonMoveDownDef.UseVisualStyleBackColor = true;
            this.buttonMoveDownDef.Click += new System.EventHandler(this.buttonMoveDownDef_Click);
            // 
            // buttonMoveUpDef
            // 
            this.buttonMoveUpDef.Enabled = false;
            this.buttonMoveUpDef.Image = global::LevelEditor.Properties.Resources.up_arrow;
            this.buttonMoveUpDef.Location = new System.Drawing.Point(55, 28);
            this.buttonMoveUpDef.Name = "buttonMoveUpDef";
            this.buttonMoveUpDef.Size = new System.Drawing.Size(37, 31);
            this.buttonMoveUpDef.TabIndex = 15;
            this.buttonMoveUpDef.UseVisualStyleBackColor = true;
            this.buttonMoveUpDef.Click += new System.EventHandler(this.buttonMoveUpDef_Click);
            // 
            // buttonAddDef
            // 
            this.buttonAddDef.Image = global::LevelEditor.Properties.Resources.def_add;
            this.buttonAddDef.Location = new System.Drawing.Point(12, 28);
            this.buttonAddDef.Name = "buttonAddDef";
            this.buttonAddDef.Size = new System.Drawing.Size(37, 31);
            this.buttonAddDef.TabIndex = 5;
            this.buttonAddDef.UseVisualStyleBackColor = true;
            this.buttonAddDef.Click += new System.EventHandler(this.buttonAddDef_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonDeleteObj);
            this.Controls.Add(this.buttonDeleteDef);
            this.Controls.Add(this.buttonMoveDownObj);
            this.Controls.Add(this.buttonMoveUpObj);
            this.Controls.Add(this.buttonMoveDownDef);
            this.Controls.Add(this.buttonMoveUpDef);
            this.Controls.Add(this.objProperties);
            this.Controls.Add(this.defProperties);
            this.Controls.Add(this.buttonAddDef);
            this.Controls.Add(this.dictionaryBox);
            this.Controls.Add(this.levelBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PlaneSmith";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericGridW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGridH)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPlane.ResumeLayout(false);
            this.tabPlane.PerformLayout();
            this.tabCodeLevel.ResumeLayout(false);
            this.tabCodeDef.ResumeLayout(false);
            this.tabCodeDef.PerformLayout();
            this.tabCodeObj.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.ListBox levelBox;
        private System.Windows.Forms.ListBox dictionaryBox;
        private System.Windows.Forms.Button buttonAddDef;
        private System.Windows.Forms.PropertyGrid defProperties;
        private System.Windows.Forms.PropertyGrid objProperties;
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
        private System.Windows.Forms.Button buttonMoveUpDef;
        private System.Windows.Forms.Button buttonMoveDownDef;
        private System.Windows.Forms.Button buttonMoveUpObj;
        private System.Windows.Forms.Button buttonMoveDownObj;
        private System.Windows.Forms.Button buttonDeleteDef;
        private System.Windows.Forms.Button buttonDeleteObj;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPlane;
        private System.Windows.Forms.TabPage tabCodeLevel;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TabPage tabCodeDef;
        private System.Windows.Forms.TabPage tabCodeObj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonReinsertObjCode;
        private ScintillaNET.Scintilla scintillaCodeLevel;
        private ScintillaNET.Scintilla scintillaCodeDef;
        private ScintillaNET.Scintilla scintillaCodeDefObj;
        private ScintillaNET.Scintilla scintillaCodeObj;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem snapToGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertSegmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showWhitespacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

