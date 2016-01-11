namespace Ambilight
{
    partial class Ambilight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ambilight));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelFramerate = new System.Windows.Forms.Label();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.labelTopOffset = new System.Windows.Forms.Label();
            this.labelCaptureHeight = new System.Windows.Forms.Label();
            this.labelCaptureX = new System.Windows.Forms.Label();
            this.buttonOffsetPlus = new System.Windows.Forms.Button();
            this.buttonOffsetMinus = new System.Windows.Forms.Button();
            this.buttonHeightMinus = new System.Windows.Forms.Button();
            this.buttonHeightPlus = new System.Windows.Forms.Button();
            this.buttonCaptureXMinus = new System.Windows.Forms.Button();
            this.buttonCaptureXPlus = new System.Windows.Forms.Button();
            this.buttonCaptureYMinus = new System.Windows.Forms.Button();
            this.buttonCaptureYPlus = new System.Windows.Forms.Button();
            this.labelCaptureY = new System.Windows.Forms.Label();
            this.buttonShowCaptureArea = new System.Windows.Forms.Button();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.buttonAutoOffset = new System.Windows.Forms.Button();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.buttonBrightnessPlus = new System.Windows.Forms.Button();
            this.buttonBrightnessMinus = new System.Windows.Forms.Button();
            this.notifyIconAmbilight = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // labelFramerate
            // 
            this.labelFramerate.Location = new System.Drawing.Point(0, 0);
            this.labelFramerate.Name = "labelFramerate";
            this.labelFramerate.Size = new System.Drawing.Size(282, 30);
            this.labelFramerate.TabIndex = 2;
            this.labelFramerate.Text = "Framerate: 0";
            this.labelFramerate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.BackColor = System.Drawing.Color.Beige;
            this.buttonStartStop.Location = new System.Drawing.Point(1, 220);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(140, 40);
            this.buttonStartStop.TabIndex = 3;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = false;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // labelTopOffset
            // 
            this.labelTopOffset.BackColor = System.Drawing.Color.Transparent;
            this.labelTopOffset.Location = new System.Drawing.Point(0, 30);
            this.labelTopOffset.Name = "labelTopOffset";
            this.labelTopOffset.Size = new System.Drawing.Size(282, 30);
            this.labelTopOffset.TabIndex = 4;
            this.labelTopOffset.Text = "Offset: 0px";
            // 
            // labelCaptureHeight
            // 
            this.labelCaptureHeight.BackColor = System.Drawing.Color.Transparent;
            this.labelCaptureHeight.Location = new System.Drawing.Point(0, 60);
            this.labelCaptureHeight.Name = "labelCaptureHeight";
            this.labelCaptureHeight.Size = new System.Drawing.Size(282, 30);
            this.labelCaptureHeight.TabIndex = 5;
            this.labelCaptureHeight.Text = "Height: 1/5";
            // 
            // labelCaptureX
            // 
            this.labelCaptureX.BackColor = System.Drawing.Color.Transparent;
            this.labelCaptureX.Location = new System.Drawing.Point(0, 90);
            this.labelCaptureX.Name = "labelCaptureX";
            this.labelCaptureX.Size = new System.Drawing.Size(282, 30);
            this.labelCaptureX.TabIndex = 6;
            this.labelCaptureX.Text = "Capture X: 10";
            // 
            // buttonOffsetPlus
            // 
            this.buttonOffsetPlus.BackColor = System.Drawing.Color.Beige;
            this.buttonOffsetPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOffsetPlus.Location = new System.Drawing.Point(221, 30);
            this.buttonOffsetPlus.Name = "buttonOffsetPlus";
            this.buttonOffsetPlus.Size = new System.Drawing.Size(30, 30);
            this.buttonOffsetPlus.TabIndex = 7;
            this.buttonOffsetPlus.Text = "+";
            this.buttonOffsetPlus.UseVisualStyleBackColor = false;
            this.buttonOffsetPlus.Click += new System.EventHandler(this.buttonOffsetPlus_Click);
            // 
            // buttonOffsetMinus
            // 
            this.buttonOffsetMinus.BackColor = System.Drawing.Color.Beige;
            this.buttonOffsetMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOffsetMinus.Location = new System.Drawing.Point(252, 30);
            this.buttonOffsetMinus.Name = "buttonOffsetMinus";
            this.buttonOffsetMinus.Size = new System.Drawing.Size(30, 30);
            this.buttonOffsetMinus.TabIndex = 8;
            this.buttonOffsetMinus.Text = "-";
            this.buttonOffsetMinus.UseVisualStyleBackColor = false;
            this.buttonOffsetMinus.Click += new System.EventHandler(this.buttonOffsetMinus_Click);
            // 
            // buttonHeightMinus
            // 
            this.buttonHeightMinus.BackColor = System.Drawing.Color.Beige;
            this.buttonHeightMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHeightMinus.Location = new System.Drawing.Point(252, 60);
            this.buttonHeightMinus.Name = "buttonHeightMinus";
            this.buttonHeightMinus.Size = new System.Drawing.Size(30, 30);
            this.buttonHeightMinus.TabIndex = 10;
            this.buttonHeightMinus.Text = "-";
            this.buttonHeightMinus.UseVisualStyleBackColor = false;
            this.buttonHeightMinus.Click += new System.EventHandler(this.buttonHeightMinus_Click);
            // 
            // buttonHeightPlus
            // 
            this.buttonHeightPlus.BackColor = System.Drawing.Color.Beige;
            this.buttonHeightPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHeightPlus.Location = new System.Drawing.Point(221, 60);
            this.buttonHeightPlus.Name = "buttonHeightPlus";
            this.buttonHeightPlus.Size = new System.Drawing.Size(30, 30);
            this.buttonHeightPlus.TabIndex = 9;
            this.buttonHeightPlus.Text = "+";
            this.buttonHeightPlus.UseVisualStyleBackColor = false;
            this.buttonHeightPlus.Click += new System.EventHandler(this.buttonHeightPlus_Click);
            // 
            // buttonCaptureXMinus
            // 
            this.buttonCaptureXMinus.BackColor = System.Drawing.Color.Beige;
            this.buttonCaptureXMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCaptureXMinus.Location = new System.Drawing.Point(252, 90);
            this.buttonCaptureXMinus.Name = "buttonCaptureXMinus";
            this.buttonCaptureXMinus.Size = new System.Drawing.Size(30, 30);
            this.buttonCaptureXMinus.TabIndex = 12;
            this.buttonCaptureXMinus.Text = "-";
            this.buttonCaptureXMinus.UseVisualStyleBackColor = false;
            this.buttonCaptureXMinus.Click += new System.EventHandler(this.buttonCaptureXMinus_Click);
            // 
            // buttonCaptureXPlus
            // 
            this.buttonCaptureXPlus.BackColor = System.Drawing.Color.Beige;
            this.buttonCaptureXPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCaptureXPlus.Location = new System.Drawing.Point(221, 90);
            this.buttonCaptureXPlus.Name = "buttonCaptureXPlus";
            this.buttonCaptureXPlus.Size = new System.Drawing.Size(30, 30);
            this.buttonCaptureXPlus.TabIndex = 11;
            this.buttonCaptureXPlus.Text = "+";
            this.buttonCaptureXPlus.UseVisualStyleBackColor = false;
            this.buttonCaptureXPlus.Click += new System.EventHandler(this.buttonCaptureXPlus_Click);
            // 
            // buttonCaptureYMinus
            // 
            this.buttonCaptureYMinus.BackColor = System.Drawing.Color.Beige;
            this.buttonCaptureYMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCaptureYMinus.Location = new System.Drawing.Point(252, 120);
            this.buttonCaptureYMinus.Name = "buttonCaptureYMinus";
            this.buttonCaptureYMinus.Size = new System.Drawing.Size(30, 30);
            this.buttonCaptureYMinus.TabIndex = 15;
            this.buttonCaptureYMinus.Text = "-";
            this.buttonCaptureYMinus.UseVisualStyleBackColor = false;
            this.buttonCaptureYMinus.Click += new System.EventHandler(this.buttonCaptureYMinus_Click);
            // 
            // buttonCaptureYPlus
            // 
            this.buttonCaptureYPlus.BackColor = System.Drawing.Color.Beige;
            this.buttonCaptureYPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCaptureYPlus.Location = new System.Drawing.Point(221, 120);
            this.buttonCaptureYPlus.Name = "buttonCaptureYPlus";
            this.buttonCaptureYPlus.Size = new System.Drawing.Size(30, 30);
            this.buttonCaptureYPlus.TabIndex = 14;
            this.buttonCaptureYPlus.Text = "+";
            this.buttonCaptureYPlus.UseVisualStyleBackColor = false;
            this.buttonCaptureYPlus.Click += new System.EventHandler(this.buttonCaptureYPlus_Click);
            // 
            // labelCaptureY
            // 
            this.labelCaptureY.BackColor = System.Drawing.Color.Transparent;
            this.labelCaptureY.Location = new System.Drawing.Point(0, 120);
            this.labelCaptureY.Name = "labelCaptureY";
            this.labelCaptureY.Size = new System.Drawing.Size(282, 30);
            this.labelCaptureY.TabIndex = 13;
            this.labelCaptureY.Text = "Capture Y: 10";
            // 
            // buttonShowCaptureArea
            // 
            this.buttonShowCaptureArea.BackColor = System.Drawing.Color.Beige;
            this.buttonShowCaptureArea.Location = new System.Drawing.Point(143, 220);
            this.buttonShowCaptureArea.Name = "buttonShowCaptureArea";
            this.buttonShowCaptureArea.Size = new System.Drawing.Size(140, 40);
            this.buttonShowCaptureArea.TabIndex = 16;
            this.buttonShowCaptureArea.Text = "C-Area";
            this.buttonShowCaptureArea.UseVisualStyleBackColor = false;
            this.buttonShowCaptureArea.Click += new System.EventHandler(this.buttonShowCaptureArea_Click);
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOffset.Location = new System.Drawing.Point(90, 30);
            this.textBoxOffset.MaxLength = 4;
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(100, 30);
            this.textBoxOffset.TabIndex = 17;
            this.textBoxOffset.Text = "0";
            this.textBoxOffset.TextChanged += new System.EventHandler(this.textBoxOffset_TextChanged);
            // 
            // buttonAutoOffset
            // 
            this.buttonAutoOffset.BackColor = System.Drawing.Color.Beige;
            this.buttonAutoOffset.Location = new System.Drawing.Point(1, 180);
            this.buttonAutoOffset.Name = "buttonAutoOffset";
            this.buttonAutoOffset.Size = new System.Drawing.Size(281, 40);
            this.buttonAutoOffset.TabIndex = 18;
            this.buttonAutoOffset.Text = "Auto Offset";
            this.buttonAutoOffset.UseVisualStyleBackColor = false;
            this.buttonAutoOffset.Click += new System.EventHandler(this.buttonAutoOffset_Click);
            // 
            // labelBrightness
            // 
            this.labelBrightness.BackColor = System.Drawing.Color.Transparent;
            this.labelBrightness.Location = new System.Drawing.Point(0, 150);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(282, 30);
            this.labelBrightness.TabIndex = 19;
            this.labelBrightness.Text = "Brightness: 100";
            // 
            // buttonBrightnessPlus
            // 
            this.buttonBrightnessPlus.BackColor = System.Drawing.Color.Beige;
            this.buttonBrightnessPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrightnessPlus.Location = new System.Drawing.Point(221, 150);
            this.buttonBrightnessPlus.Name = "buttonBrightnessPlus";
            this.buttonBrightnessPlus.Size = new System.Drawing.Size(30, 30);
            this.buttonBrightnessPlus.TabIndex = 20;
            this.buttonBrightnessPlus.Text = "+";
            this.buttonBrightnessPlus.UseVisualStyleBackColor = false;
            this.buttonBrightnessPlus.Click += new System.EventHandler(this.buttonBrightnessPlus_Click);
            // 
            // buttonBrightnessMinus
            // 
            this.buttonBrightnessMinus.BackColor = System.Drawing.Color.Beige;
            this.buttonBrightnessMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrightnessMinus.Location = new System.Drawing.Point(252, 150);
            this.buttonBrightnessMinus.Name = "buttonBrightnessMinus";
            this.buttonBrightnessMinus.Size = new System.Drawing.Size(30, 30);
            this.buttonBrightnessMinus.TabIndex = 21;
            this.buttonBrightnessMinus.Text = "-";
            this.buttonBrightnessMinus.UseVisualStyleBackColor = false;
            this.buttonBrightnessMinus.Click += new System.EventHandler(this.buttonBrightnessMinus_Click);
            // 
            // notifyIconAmbilight
            // 
            this.notifyIconAmbilight.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIconAmbilight.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconAmbilight.Icon")));
            this.notifyIconAmbilight.Text = "Ambilight";
            this.notifyIconAmbilight.Visible = true;
            this.notifyIconAmbilight.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Ambilight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonBrightnessMinus);
            this.Controls.Add(this.buttonBrightnessPlus);
            this.Controls.Add(this.labelBrightness);
            this.Controls.Add(this.buttonAutoOffset);
            this.Controls.Add(this.textBoxOffset);
            this.Controls.Add(this.buttonShowCaptureArea);
            this.Controls.Add(this.buttonCaptureYMinus);
            this.Controls.Add(this.buttonCaptureYPlus);
            this.Controls.Add(this.labelCaptureY);
            this.Controls.Add(this.buttonCaptureXMinus);
            this.Controls.Add(this.buttonCaptureXPlus);
            this.Controls.Add(this.buttonHeightMinus);
            this.Controls.Add(this.buttonHeightPlus);
            this.Controls.Add(this.buttonOffsetMinus);
            this.Controls.Add(this.buttonOffsetPlus);
            this.Controls.Add(this.labelCaptureX);
            this.Controls.Add(this.labelCaptureHeight);
            this.Controls.Add(this.labelTopOffset);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.labelFramerate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeBox = false;
            this.Name = "Ambilight";
            this.Text = "Ambilight";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelFramerate;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Label labelTopOffset;
        private System.Windows.Forms.Label labelCaptureHeight;
        private System.Windows.Forms.Label labelCaptureX;
        private System.Windows.Forms.Button buttonOffsetPlus;
        private System.Windows.Forms.Button buttonOffsetMinus;
        private System.Windows.Forms.Button buttonHeightMinus;
        private System.Windows.Forms.Button buttonHeightPlus;
        private System.Windows.Forms.Button buttonCaptureXMinus;
        private System.Windows.Forms.Button buttonCaptureXPlus;
        private System.Windows.Forms.Button buttonCaptureYMinus;
        private System.Windows.Forms.Button buttonCaptureYPlus;
        private System.Windows.Forms.Label labelCaptureY;
        private System.Windows.Forms.Button buttonShowCaptureArea;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.Button buttonAutoOffset;
        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.Button buttonBrightnessPlus;
        private System.Windows.Forms.Button buttonBrightnessMinus;
        private System.Windows.Forms.NotifyIcon notifyIconAmbilight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

    }
}

