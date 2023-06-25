namespace Win11Tweaker
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.appName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SplashPane = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuPanel = new CustomComponent.RoundPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuSwitch = new CustomComponent.SwitchButton();
            this.webSearchPanel = new CustomComponent.RoundPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.webSearchSwitch = new CustomComponent.SwitchButton();
            this.compactViewPanel = new CustomComponent.RoundPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.compactViewSwitch = new CustomComponent.SwitchButton();
            this.detailsPanePanel = new CustomComponent.RoundPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.previewPaneSwitch = new CustomComponent.SwitchButton();
            this.lockScreenPanel = new CustomComponent.RoundPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.lockScreenSwitch = new CustomComponent.SwitchButton();
            this.label14 = new System.Windows.Forms.Label();
            this.printSCRPanel = new CustomComponent.RoundPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.printScrSwitch = new CustomComponent.SwitchButton();
            this.previewDesc = new System.Windows.Forms.Label();
            this.previewTitle = new System.Windows.Forms.Label();
            this.roundPanel1 = new CustomComponent.RoundPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.preview = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.SplashPane.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuPanel.SuspendLayout();
            this.webSearchPanel.SuspendLayout();
            this.compactViewPanel.SuspendLayout();
            this.detailsPanePanel.SuspendLayout();
            this.lockScreenPanel.SuspendLayout();
            this.printSCRPanel.SuspendLayout();
            this.roundPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            this.SuspendLayout();
            // 
            // appName
            // 
            this.appName.AutoSize = true;
            this.appName.BackColor = System.Drawing.Color.Transparent;
            this.appName.Font = new System.Drawing.Font("Segoe UI Variable Small", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appName.ForeColor = System.Drawing.Color.White;
            this.appName.Location = new System.Drawing.Point(27, 14);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(207, 36);
            this.appName.TabIndex = 1;
            this.appName.Text = "Win11 Tweaker";
            this.appName.Click += new System.EventHandler(this.appName_Click);
            this.appName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.appName.MouseLeave += new System.EventHandler(this.appName_MouseLeave);
            this.appName.MouseHover += new System.EventHandler(this.appName_MouseHover);
            this.appName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.appName_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.SplashPane);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.previewDesc);
            this.panel1.Controls.Add(this.previewTitle);
            this.panel1.Controls.Add(this.roundPanel1);
            this.panel1.Controls.Add(this.appName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 623);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SplashPane
            // 
            this.SplashPane.Controls.Add(this.pictureBox1);
            this.SplashPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplashPane.Location = new System.Drawing.Point(0, 0);
            this.SplashPane.Name = "SplashPane";
            this.SplashPane.Size = new System.Drawing.Size(484, 623);
            this.SplashPane.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.contextMenuPanel);
            this.panel2.Controls.Add(this.webSearchPanel);
            this.panel2.Controls.Add(this.compactViewPanel);
            this.panel2.Controls.Add(this.detailsPanePanel);
            this.panel2.Controls.Add(this.lockScreenPanel);
            this.panel2.Controls.Add(this.printSCRPanel);
            this.panel2.Location = new System.Drawing.Point(3, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 438);
            this.panel2.TabIndex = 19;
            // 
            // contextMenuPanel
            // 
            this.contextMenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contextMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.contextMenuPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.contextMenuPanel.BorderRadius = 10;
            this.contextMenuPanel.BorderRoundSize = 1;
            this.contextMenuPanel.Clickable = true;
            this.contextMenuPanel.Controls.Add(this.label3);
            this.contextMenuPanel.Controls.Add(this.label2);
            this.contextMenuPanel.Controls.Add(this.contextMenuSwitch);
            this.contextMenuPanel.Location = new System.Drawing.Point(27, 9);
            this.contextMenuPanel.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.contextMenuPanel.MouseLeaveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.contextMenuPanel.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.contextMenuPanel.MouseUpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.contextMenuPanel.Name = "contextMenuPanel";
            this.contextMenuPanel.Size = new System.Drawing.Size(427, 70);
            this.contextMenuPanel.TabIndex = 9;
            this.contextMenuPanel.Click += new System.EventHandler(this.contextMenuPanel_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(199)))), ((int)(((byte)(200)))));
            this.label3.Location = new System.Drawing.Point(28, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enable Classic Context Menu ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(27, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Classic Context Menu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.Paint += new System.Windows.Forms.PaintEventHandler(this.onPaint);
            // 
            // contextMenuSwitch
            // 
            this.contextMenuSwitch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.contextMenuSwitch.BackColor = System.Drawing.Color.Transparent;
            this.contextMenuSwitch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.contextMenuSwitch.BorderRoundSize = 1;
            this.contextMenuSwitch.Location = new System.Drawing.Point(349, 25);
            this.contextMenuSwitch.Name = "contextMenuSwitch";
            this.contextMenuSwitch.Padding = new System.Windows.Forms.Padding(6);
            this.contextMenuSwitch.Size = new System.Drawing.Size(55, 29);
            this.contextMenuSwitch.TabIndex = 6;
            this.contextMenuSwitch.Text = "hey";
            this.contextMenuSwitch.UseVisualStyleBackColor = false;
            this.contextMenuSwitch.CheckedChanged += new System.EventHandler(this.contextMenuSwitch_CheckedChanged);
            // 
            // webSearchPanel
            // 
            this.webSearchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webSearchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.webSearchPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.webSearchPanel.BorderRadius = 10;
            this.webSearchPanel.BorderRoundSize = 1;
            this.webSearchPanel.Clickable = true;
            this.webSearchPanel.Controls.Add(this.label4);
            this.webSearchPanel.Controls.Add(this.label5);
            this.webSearchPanel.Controls.Add(this.webSearchSwitch);
            this.webSearchPanel.Location = new System.Drawing.Point(27, 76);
            this.webSearchPanel.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.webSearchPanel.MouseLeaveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.webSearchPanel.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.webSearchPanel.MouseUpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.webSearchPanel.Name = "webSearchPanel";
            this.webSearchPanel.Size = new System.Drawing.Size(427, 70);
            this.webSearchPanel.TabIndex = 10;
            this.webSearchPanel.Click += new System.EventHandler(this.webSearchPanel_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(199)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(28, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Disable Web Search in Start Menu\r\n";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(27, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Web Search";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            this.label5.Paint += new System.Windows.Forms.PaintEventHandler(this.onPaint);
            // 
            // webSearchSwitch
            // 
            this.webSearchSwitch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.webSearchSwitch.BackColor = System.Drawing.Color.Transparent;
            this.webSearchSwitch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.webSearchSwitch.BorderRoundSize = 1;
            this.webSearchSwitch.Location = new System.Drawing.Point(349, 25);
            this.webSearchSwitch.Name = "webSearchSwitch";
            this.webSearchSwitch.Padding = new System.Windows.Forms.Padding(6);
            this.webSearchSwitch.Size = new System.Drawing.Size(55, 29);
            this.webSearchSwitch.TabIndex = 6;
            this.webSearchSwitch.Text = "hey";
            this.webSearchSwitch.UseVisualStyleBackColor = false;
            this.webSearchSwitch.CheckedChanged += new System.EventHandler(this.webSearchSwitch_CheckedChanged);
            // 
            // compactViewPanel
            // 
            this.compactViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.compactViewPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.compactViewPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.compactViewPanel.BorderRadius = 10;
            this.compactViewPanel.BorderRoundSize = 1;
            this.compactViewPanel.Clickable = true;
            this.compactViewPanel.Controls.Add(this.label11);
            this.compactViewPanel.Controls.Add(this.label12);
            this.compactViewPanel.Controls.Add(this.compactViewSwitch);
            this.compactViewPanel.Location = new System.Drawing.Point(27, 210);
            this.compactViewPanel.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.compactViewPanel.MouseLeaveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.compactViewPanel.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.compactViewPanel.MouseUpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.compactViewPanel.Name = "compactViewPanel";
            this.compactViewPanel.Size = new System.Drawing.Size(427, 70);
            this.compactViewPanel.TabIndex = 12;
            this.compactViewPanel.Click += new System.EventHandler(this.compactViewPanel_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Enabled = false;
            this.label11.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(199)))), ((int)(((byte)(200)))));
            this.label11.Location = new System.Drawing.Point(28, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(315, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Enable Compact View in Windows Explorer";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Enabled = false;
            this.label12.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(27, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 19);
            this.label12.TabIndex = 4;
            this.label12.Text = "Compact View";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            this.label12.Paint += new System.Windows.Forms.PaintEventHandler(this.onPaint);
            // 
            // compactViewSwitch
            // 
            this.compactViewSwitch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.compactViewSwitch.BackColor = System.Drawing.Color.Transparent;
            this.compactViewSwitch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.compactViewSwitch.BorderRoundSize = 1;
            this.compactViewSwitch.Location = new System.Drawing.Point(349, 25);
            this.compactViewSwitch.Name = "compactViewSwitch";
            this.compactViewSwitch.Padding = new System.Windows.Forms.Padding(6);
            this.compactViewSwitch.Size = new System.Drawing.Size(55, 29);
            this.compactViewSwitch.TabIndex = 6;
            this.compactViewSwitch.Text = "hey";
            this.compactViewSwitch.UseVisualStyleBackColor = false;
            this.compactViewSwitch.CheckedChanged += new System.EventHandler(this.compactViewSwitch_CheckedChanged);
            // 
            // detailsPanePanel
            // 
            this.detailsPanePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsPanePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.detailsPanePanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.detailsPanePanel.BorderRadius = 10;
            this.detailsPanePanel.BorderRoundSize = 1;
            this.detailsPanePanel.Clickable = true;
            this.detailsPanePanel.Controls.Add(this.label9);
            this.detailsPanePanel.Controls.Add(this.label10);
            this.detailsPanePanel.Controls.Add(this.previewPaneSwitch);
            this.detailsPanePanel.Location = new System.Drawing.Point(27, 277);
            this.detailsPanePanel.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.detailsPanePanel.MouseLeaveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.detailsPanePanel.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.detailsPanePanel.MouseUpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.detailsPanePanel.Name = "detailsPanePanel";
            this.detailsPanePanel.Size = new System.Drawing.Size(427, 70);
            this.detailsPanePanel.TabIndex = 13;
            this.detailsPanePanel.Click += new System.EventHandler(this.detailsPanePanel_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Enabled = false;
            this.label9.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(199)))), ((int)(((byte)(200)))));
            this.label9.Location = new System.Drawing.Point(28, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(315, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Add the Details Pane to the Context Menu";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Enabled = false;
            this.label10.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(27, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 19);
            this.label10.TabIndex = 4;
            this.label10.Text = "Details Pane";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            this.label10.Paint += new System.Windows.Forms.PaintEventHandler(this.onPaint);
            // 
            // previewPaneSwitch
            // 
            this.previewPaneSwitch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.previewPaneSwitch.BackColor = System.Drawing.Color.Transparent;
            this.previewPaneSwitch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.previewPaneSwitch.BorderRoundSize = 1;
            this.previewPaneSwitch.Location = new System.Drawing.Point(349, 25);
            this.previewPaneSwitch.Name = "previewPaneSwitch";
            this.previewPaneSwitch.Padding = new System.Windows.Forms.Padding(6);
            this.previewPaneSwitch.Size = new System.Drawing.Size(55, 29);
            this.previewPaneSwitch.TabIndex = 6;
            this.previewPaneSwitch.Text = "hey";
            this.previewPaneSwitch.UseVisualStyleBackColor = false;
            this.previewPaneSwitch.CheckedChanged += new System.EventHandler(this.previewPaneSwitch_CheckedChanged);
            // 
            // lockScreenPanel
            // 
            this.lockScreenPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lockScreenPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lockScreenPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lockScreenPanel.BorderRadius = 10;
            this.lockScreenPanel.BorderRoundSize = 1;
            this.lockScreenPanel.Clickable = true;
            this.lockScreenPanel.Controls.Add(this.label13);
            this.lockScreenPanel.Controls.Add(this.lockScreenSwitch);
            this.lockScreenPanel.Controls.Add(this.label14);
            this.lockScreenPanel.Location = new System.Drawing.Point(27, 143);
            this.lockScreenPanel.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lockScreenPanel.MouseLeaveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lockScreenPanel.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lockScreenPanel.MouseUpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lockScreenPanel.Name = "lockScreenPanel";
            this.lockScreenPanel.Size = new System.Drawing.Size(427, 70);
            this.lockScreenPanel.TabIndex = 15;
            this.lockScreenPanel.Click += new System.EventHandler(this.lockScreenPanel_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Enabled = false;
            this.label13.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(199)))), ((int)(((byte)(200)))));
            this.label13.Location = new System.Drawing.Point(28, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(315, 16);
            this.label13.TabIndex = 5;
            this.label13.Text = "Disable Windows Lockscreen \r\n";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // lockScreenSwitch
            // 
            this.lockScreenSwitch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lockScreenSwitch.BackColor = System.Drawing.Color.Transparent;
            this.lockScreenSwitch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lockScreenSwitch.BorderRoundSize = 1;
            this.lockScreenSwitch.Location = new System.Drawing.Point(349, 25);
            this.lockScreenSwitch.Name = "lockScreenSwitch";
            this.lockScreenSwitch.Padding = new System.Windows.Forms.Padding(6);
            this.lockScreenSwitch.Size = new System.Drawing.Size(55, 29);
            this.lockScreenSwitch.TabIndex = 6;
            this.lockScreenSwitch.Text = "hey";
            this.lockScreenSwitch.UseVisualStyleBackColor = false;
            this.lockScreenSwitch.CheckedChanged += new System.EventHandler(this.lockScreenSwitch_CheckedChanged);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Enabled = false;
            this.label14.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(27, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 19);
            this.label14.TabIndex = 4;
            this.label14.Text = "Lock Screen";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            this.label14.Paint += new System.Windows.Forms.PaintEventHandler(this.onPaint);
            // 
            // printSCRPanel
            // 
            this.printSCRPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printSCRPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.printSCRPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.printSCRPanel.BorderRadius = 10;
            this.printSCRPanel.BorderRoundSize = 1;
            this.printSCRPanel.Clickable = true;
            this.printSCRPanel.Controls.Add(this.label15);
            this.printSCRPanel.Controls.Add(this.label16);
            this.printSCRPanel.Controls.Add(this.printScrSwitch);
            this.printSCRPanel.Location = new System.Drawing.Point(27, 344);
            this.printSCRPanel.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.printSCRPanel.MouseLeaveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.printSCRPanel.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.printSCRPanel.MouseUpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.printSCRPanel.Name = "printSCRPanel";
            this.printSCRPanel.Size = new System.Drawing.Size(427, 70);
            this.printSCRPanel.TabIndex = 14;
            this.printSCRPanel.Click += new System.EventHandler(this.printSCRPanel_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Enabled = false;
            this.label15.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(199)))), ((int)(((byte)(200)))));
            this.label15.Location = new System.Drawing.Point(28, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(315, 16);
            this.label15.TabIndex = 5;
            this.label15.Text = "Enable Sound when pressing PRTSC key";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Enabled = false;
            this.label16.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(27, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 19);
            this.label16.TabIndex = 4;
            this.label16.Text = "Print Screen Sound";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            this.label16.Paint += new System.Windows.Forms.PaintEventHandler(this.onPaint);
            // 
            // printScrSwitch
            // 
            this.printScrSwitch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.printScrSwitch.BackColor = System.Drawing.Color.Transparent;
            this.printScrSwitch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.printScrSwitch.BorderRoundSize = 1;
            this.printScrSwitch.Location = new System.Drawing.Point(349, 25);
            this.printScrSwitch.Name = "printScrSwitch";
            this.printScrSwitch.Padding = new System.Windows.Forms.Padding(6);
            this.printScrSwitch.Size = new System.Drawing.Size(55, 29);
            this.printScrSwitch.TabIndex = 6;
            this.printScrSwitch.Text = "hey";
            this.printScrSwitch.UseVisualStyleBackColor = false;
            this.printScrSwitch.CheckedChanged += new System.EventHandler(this.printScrSwitch_CheckedChanged);
            // 
            // previewDesc
            // 
            this.previewDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewDesc.BackColor = System.Drawing.Color.Transparent;
            this.previewDesc.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(199)))), ((int)(((byte)(200)))));
            this.previewDesc.Location = new System.Drawing.Point(215, 114);
            this.previewDesc.Name = "previewDesc";
            this.previewDesc.Size = new System.Drawing.Size(219, 45);
            this.previewDesc.TabIndex = 18;
            this.previewDesc.Text = "Powerful Tool for Personalizing and Enhancing Windows 11";
            this.previewDesc.Click += new System.EventHandler(this.previewDesc_Click);
            // 
            // previewTitle
            // 
            this.previewTitle.AutoSize = true;
            this.previewTitle.BackColor = System.Drawing.Color.Transparent;
            this.previewTitle.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewTitle.ForeColor = System.Drawing.Color.White;
            this.previewTitle.Location = new System.Drawing.Point(214, 93);
            this.previewTitle.Name = "previewTitle";
            this.previewTitle.Size = new System.Drawing.Size(54, 21);
            this.previewTitle.TabIndex = 17;
            this.previewTitle.Text = "IanDiv";
            // 
            // roundPanel1
            // 
            this.roundPanel1.AutoSize = true;
            this.roundPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.roundPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.roundPanel1.BorderRadius = 15;
            this.roundPanel1.BorderRoundSize = 1;
            this.roundPanel1.Clickable = false;
            this.roundPanel1.Controls.Add(this.preview);
            this.roundPanel1.Location = new System.Drawing.Point(30, 79);
            this.roundPanel1.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.roundPanel1.MouseLeaveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.roundPanel1.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.roundPanel1.MouseUpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.roundPanel1.Name = "roundPanel1";
            this.roundPanel1.Size = new System.Drawing.Size(169, 92);
            this.roundPanel1.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Win11Tweaker.Properties.Resources.win11tweaker_icon_small;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(484, 623);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // preview
            // 
            this.preview.BackColor = System.Drawing.Color.Transparent;
            this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preview.Image = global::Win11Tweaker.Properties.Resources.win11splash;
            this.preview.Location = new System.Drawing.Point(0, 0);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(169, 92);
            this.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.preview.TabIndex = 0;
            this.preview.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(484, 623);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 423);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Win11 Tweaker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.SplashPane.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuPanel.ResumeLayout(false);
            this.webSearchPanel.ResumeLayout(false);
            this.compactViewPanel.ResumeLayout(false);
            this.detailsPanePanel.ResumeLayout(false);
            this.lockScreenPanel.ResumeLayout(false);
            this.printSCRPanel.ResumeLayout(false);
            this.roundPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.Panel panel1;
        private CustomComponent.SwitchButton contextMenuSwitch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private CustomComponent.RoundPanel contextMenuPanel;
        private CustomComponent.RoundPanel webSearchPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomComponent.SwitchButton webSearchSwitch;
        private System.Windows.Forms.Panel SplashPane;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomComponent.RoundPanel detailsPanePanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private CustomComponent.SwitchButton previewPaneSwitch;
        private CustomComponent.RoundPanel compactViewPanel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private CustomComponent.SwitchButton compactViewSwitch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private CustomComponent.SwitchButton lockScreenSwitch;
        private CustomComponent.RoundPanel printSCRPanel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private CustomComponent.SwitchButton printScrSwitch;
        private CustomComponent.RoundPanel lockScreenPanel;
        private CustomComponent.RoundPanel roundPanel1;
        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.Label previewDesc;
        private System.Windows.Forms.Label previewTitle;
        private System.Windows.Forms.Panel panel2;
    }
}

