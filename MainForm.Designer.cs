namespace MathematicalSetViewer
{
    partial class MainForm
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
            this.ControlsMenuTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ControlsPause = new System.Windows.Forms.ToolStripMenuItem();
            this.ControlsInput = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ControlsZoomSpeedMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomSpeedNone = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomSpeedCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.ControlsPanSpeed = new System.Windows.Forms.ToolStripMenuItem();
            this.ControlsSmoothAcceleration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ControlsColorSettingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorSettingsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorSettings8Bit = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorSettingsCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.MathematicalSetMenuTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MathematicalSetMandelbrot = new System.Windows.Forms.ToolStripMenuItem();
            this.MathematicalSetInverseMandelbrot = new System.Windows.Forms.ToolStripMenuItem();
            this.MathematicalSetJuliaSet = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewHideMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewResume = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewHideMenuAndResume = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewPauseWhenMinimized = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.MainFormMainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlsMenuTSMI
            // 
            this.ControlsMenuTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ControlsPause,
            this.ControlsInput,
            this.toolStripSeparator1,
            this.ControlsZoomSpeedMenu,
            this.ControlsPanSpeed,
            this.ControlsSmoothAcceleration,
            this.toolStripSeparator2,
            this.ControlsColorSettingsMenu});
            this.ControlsMenuTSMI.Name = "ControlsMenuTSMI";
            this.ControlsMenuTSMI.Size = new System.Drawing.Size(64, 20);
            this.ControlsMenuTSMI.Text = "Controls";
            // 
            // ControlsPause
            // 
            this.ControlsPause.CheckOnClick = true;
            this.ControlsInput.Checked = true;
            this.ControlsInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ControlsPause.Name = "ControlsPause";
            this.ControlsPause.Size = new System.Drawing.Size(183, 22);
            this.ControlsPause.Text = "Pause";
            this.ControlsPause.ToolTipText = "Pauses the screen";
            this.ControlsPause.CheckedChanged += ControlsPause_CheckedChanged;
            // 
            // ControlsInput
            // 
            this.ControlsInput.CheckOnClick = true;
            this.ControlsInput.Checked = true;
            this.ControlsInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ControlsInput.Name = "ControlsInput";
            this.ControlsInput.Size = new System.Drawing.Size(183, 22);
            this.ControlsInput.Text = "Input";
            this.ControlsInput.ToolTipText = "Enables/Disables input from keyboard";
            this.ControlsInput.CheckedChanged += ControlsInput_CheckedChanged;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // ControlsZoomSpeedMenu
            // 
            this.ControlsZoomSpeedMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomSpeedNone,
            this.ZoomSpeedCustom});
            this.ControlsZoomSpeedMenu.Name = "ControlsZoomSpeedMenu";
            this.ControlsZoomSpeedMenu.Size = new System.Drawing.Size(183, 22);
            this.ControlsZoomSpeedMenu.Text = "Zoom Speed";
            // 
            // ZoomSpeedNone
            // 
            this.ZoomSpeedNone.Name = "ZoomSpeedNone";
            this.ZoomSpeedNone.Size = new System.Drawing.Size(116, 22);
            this.ZoomSpeedNone.Text = "None";
            this.ZoomSpeedNone.Click += new System.EventHandler(this.ZoomSpeedNone_Click);
            // 
            // ZoomSpeedCustom
            // 
            this.ZoomSpeedCustom.Name = "ZoomSpeedCustom";
            this.ZoomSpeedCustom.Size = new System.Drawing.Size(116, 22);
            this.ZoomSpeedCustom.Text = "Custom";
            this.ZoomSpeedCustom.Click += new System.EventHandler(this.ZoomSpeedCustom_Click);
            // 
            // ControlsPanSpeed
            // 
            this.ControlsPanSpeed.Name = "ControlsPanSpeed";
            this.ControlsPanSpeed.Size = new System.Drawing.Size(183, 22);
            this.ControlsPanSpeed.Text = "Pan speed";
            // 
            // ControlsSmoothAcceleration
            // 
            this.ControlsSmoothAcceleration.CheckOnClick = true;
            this.ControlsSmoothAcceleration.Name = "ControlsSmoothAcceleration";
            this.ControlsSmoothAcceleration.Size = new System.Drawing.Size(183, 22);
            this.ControlsSmoothAcceleration.Text = "Smooth acceleration";
            this.ControlsSmoothAcceleration.ToolTipText = "Accelerate smoothly or iteratively";
            this.ControlsSmoothAcceleration.CheckedChanged += this.ControlsSmoothAcceleration_CheckedChanged;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // ControlsColorSettingsMenu
            // 
            this.ControlsColorSettingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorSettingsAll,
            this.ColorSettings8Bit,
            this.ColorSettingsCustom});
            this.ControlsColorSettingsMenu.Name = "ControlsColorSettingsMenu";
            this.ControlsColorSettingsMenu.Size = new System.Drawing.Size(183, 22);
            this.ControlsColorSettingsMenu.Text = "Color settings";
            // 
            // ColorSettingsAll
            // 
            this.ColorSettingsAll.CheckOnClick = true;
            this.ColorSettingsAll.Checked = true;
            this.ColorSettingsAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ColorSettingsAll.Name = "ColorSettingsAll";
            this.ColorSettingsAll.Size = new System.Drawing.Size(139, 22);
            this.ColorSettingsAll.Text = "Full rainbow";
            this.ColorSettingsAll.CheckedChanged += this.ColorSettings_CheckedChanged;
            // 
            // ColorSettings8Bit
            // 
            this.ColorSettings8Bit.Name = "ColorSettings8Bit";
            this.ColorSettings8Bit.Size = new System.Drawing.Size(139, 22);
            this.ColorSettings8Bit.Text = "8-bit";
            this.ColorSettings8Bit.CheckedChanged += this.ColorSettings_CheckedChanged;
            // 
            // ColorSettingsCustom
            // 
            this.ColorSettingsCustom.Name = "ColorSettingsCustom";
            this.ColorSettingsCustom.Size = new System.Drawing.Size(139, 22);
            this.ColorSettingsCustom.Text = "Custom";
            this.ColorSettingsCustom.CheckedChanged += this.ColorSettings_CheckedChanged;
            // 
            // MathematicalSetMenuTSMI
            // 
            this.MathematicalSetMenuTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MathematicalSetMandelbrot,
            this.MathematicalSetInverseMandelbrot,
            this.MathematicalSetJuliaSet});
            this.MathematicalSetMenuTSMI.Name = "MathematicalSetMenuTSMI";
            this.MathematicalSetMenuTSMI.Size = new System.Drawing.Size(111, 20);
            this.MathematicalSetMenuTSMI.Text = "Mathematical Set";
            // 
            // MathematicalSetMandelbrot
            // 
            this.MathematicalSetMandelbrot.CheckOnClick = true;
            this.MathematicalSetMandelbrot.Checked = true;
            this.MathematicalSetMandelbrot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MathematicalSetMandelbrot.Name = "MathematicalSetMandelbrot";
            this.MathematicalSetMandelbrot.Size = new System.Drawing.Size(176, 22);
            this.MathematicalSetMandelbrot.Text = "Mandelbrot";
            this.MathematicalSetMandelbrot.CheckedChanged += MathematicalSet_UpdateSet;
            // 
            // MathematicalSetInverseMandelbrot
            // 
            this.MathematicalSetInverseMandelbrot.CheckOnClick = true;
            this.MathematicalSetInverseMandelbrot.Name = "MathematicalSetInverseMandelbrot";
            this.MathematicalSetInverseMandelbrot.Size = new System.Drawing.Size(176, 22);
            this.MathematicalSetInverseMandelbrot.Text = "Inverse Mandelbrot";
            this.MathematicalSetInverseMandelbrot.CheckedChanged += MathematicalSet_UpdateSet;

            // 
            // MathematicalSetJuliaSet
            // 
            this.MathematicalSetJuliaSet.CheckOnClick = true;
            this.MathematicalSetJuliaSet.Name = "MathematicalSetJuliaSet";
            this.MathematicalSetJuliaSet.Size = new System.Drawing.Size(176, 22);
            this.MathematicalSetJuliaSet.Text = "Julia Set";
            this.MathematicalSetJuliaSet.CheckedChanged += MathematicalSet_UpdateSet;

            // 
            // ViewMenuTSMI
            // 
            this.ViewMenuTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewHideMenu,
            this.ViewResume,
            this.ViewHideMenuAndResume,
            this.ViewPauseWhenMinimized,
            this.toolStripSeparator3,
            this.ViewExit});
            this.ViewMenuTSMI.Name = "ViewMenuTSMI";
            this.ViewMenuTSMI.Size = new System.Drawing.Size(44, 20);
            this.ViewMenuTSMI.Text = "View";
            // 
            // ViewHideMenu
            // 
            this.ViewHideMenu.Name = "ViewHideMenu";
            this.ViewHideMenu.Size = new System.Drawing.Size(198, 22);
            this.ViewHideMenu.Text = "Hide menu";
            // 
            // ViewResume
            // 
            this.ViewResume.Name = "ViewResume";
            this.ViewResume.Size = new System.Drawing.Size(198, 22);
            this.ViewResume.Text = "Resume";
            // 
            // ViewHideMenuAndResume
            // 
            this.ViewHideMenuAndResume.Name = "ViewHideMenuAndResume";
            this.ViewHideMenuAndResume.Size = new System.Drawing.Size(198, 22);
            this.ViewHideMenuAndResume.Text = "Hide Menu and resume";
            // 
            // ViewPauseWhenMinimized
            // 
            this.ViewPauseWhenMinimized.CheckOnClick = true;
            this.ViewPauseWhenMinimized.Checked = true;
            this.ViewPauseWhenMinimized.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewPauseWhenMinimized.Name = "ViewPauseWhenMinimized";
            this.ViewPauseWhenMinimized.Size = new System.Drawing.Size(198, 22);
            this.ViewPauseWhenMinimized.Text = "Pause when minimized";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            // 
            // ViewExit
            // 
            this.ViewExit.Name = "ViewExit";
            this.ViewExit.Size = new System.Drawing.Size(198, 22);
            this.ViewExit.Text = "Exit";
            this.ViewExit.Click += new System.EventHandler(this.ViewExit_Click);
            // 
            // MainFormMainMenuStrip
            // 
            this.MainFormMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ControlsMenuTSMI,
            this.MathematicalSetMenuTSMI,
            this.ViewMenuTSMI});
            this.MainFormMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMainMenuStrip.Name = "MainFormMainMenuStrip";
            this.MainFormMainMenuStrip.Size = new System.Drawing.Size(727, 24);
            this.MainFormMainMenuStrip.TabIndex = 0;
            this.MainFormMainMenuStrip.Text = "MainFormMainMenuStrip";
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.AutoSize = true;
            this.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitButton.BackColor = System.Drawing.Color.Red;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExitButton.ForeColor = System.Drawing.Color.Black;
            this.ExitButton.Location = new System.Drawing.Point(699, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(27, 22);
            this.ExitButton.TabIndex = 9999;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "×";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.AutoSize = true;
            this.MinimizeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MinimizeButton.BackColor = System.Drawing.Color.Red;
            this.MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MinimizeButton.ForeColor = System.Drawing.Color.Black;
            this.MinimizeButton.Location = new System.Drawing.Point(671, 0);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(27, 22);
            this.MinimizeButton.TabIndex = 9998;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.Text = "—";
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(727, 526);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MainFormMainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Mathematical Set Viewer";
            // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.MouseWheel += this.MainForm_MouseWheel;
            this.MainFormMainMenuStrip.ResumeLayout(false);
            this.MainFormMainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.ToolStripMenuItem ControlsMenuTSMI;
        private System.Windows.Forms.ToolStripMenuItem ControlsInput;
        private System.Windows.Forms.ToolStripMenuItem ControlsZoomSpeedMenu;
        private System.Windows.Forms.ToolStripMenuItem ZoomSpeedNone;
        private System.Windows.Forms.ToolStripMenuItem ControlsPanSpeed;
        private System.Windows.Forms.ToolStripMenuItem ControlsSmoothAcceleration;
        private System.Windows.Forms.ToolStripMenuItem ControlsColorSettingsMenu;
        private System.Windows.Forms.ToolStripMenuItem ColorSettingsAll;
        private System.Windows.Forms.ToolStripMenuItem ColorSettings8Bit;
        private System.Windows.Forms.ToolStripMenuItem ColorSettingsCustom;
        private System.Windows.Forms.ToolStripMenuItem MathematicalSetMenuTSMI;
        private System.Windows.Forms.ToolStripMenuItem MathematicalSetMandelbrot;
        private System.Windows.Forms.ToolStripMenuItem MathematicalSetInverseMandelbrot;
        private System.Windows.Forms.ToolStripMenuItem MathematicalSetJuliaSet;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuTSMI;
        private System.Windows.Forms.ToolStripMenuItem ViewHideMenu;
        private System.Windows.Forms.ToolStripMenuItem ViewResume;
        private System.Windows.Forms.ToolStripMenuItem ViewHideMenuAndResume;
        private System.Windows.Forms.MenuStrip MainFormMainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ControlsPause;
        private System.Windows.Forms.ToolStripMenuItem ZoomSpeedCustom;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem ViewExit;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ViewPauseWhenMinimized;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

