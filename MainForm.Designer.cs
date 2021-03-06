﻿using System.Collections.Generic;

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
            this.ColorSettingOptions = new System.Windows.Forms.ToolStripComboBox();
            this.ColorSettingsCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.MathematicalSetMenuTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MathematicalSetMandelbrot = new System.Windows.Forms.ToolStripMenuItem();
            this.MathematicalSetInverseMandelbrot = new System.Windows.Forms.ToolStripMenuItem();
            this.MathematicalSetJuliaSet = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewHideMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ControlsPause.Name = "ControlsPause";
            this.ControlsPause.Size = new System.Drawing.Size(198, 22);
            this.ControlsPause.Text = "Pause";
            this.ControlsPause.ToolTipText = "Pauses the screen";
            this.ControlsPause.Click += new System.EventHandler(this.PauseResume_CheckedChanged);
            // 
            // ControlsInput
            // 
            this.ControlsInput.Checked = true;
            this.ControlsInput.CheckOnClick = true;
            this.ControlsInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ControlsInput.Name = "ControlsInput";
            this.ControlsInput.Size = new System.Drawing.Size(183, 22);
            this.ControlsInput.Text = "Input";
            this.ControlsInput.ToolTipText = "Enables/Disables input from keyboard";
            this.ControlsInput.Click += new System.EventHandler(this.ControlsInput_CheckedChanged);
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
            this.ControlsPanSpeed.Click += new System.EventHandler(this.TODO);
            // 
            // ControlsSmoothAcceleration
            // 
            this.ControlsSmoothAcceleration.CheckOnClick = true;
            this.ControlsSmoothAcceleration.Name = "ControlsSmoothAcceleration";
            this.ControlsSmoothAcceleration.Size = new System.Drawing.Size(183, 22);
            this.ControlsSmoothAcceleration.Text = "Smooth acceleration";
            this.ControlsSmoothAcceleration.ToolTipText = "Accelerate smoothly or iteratively";
            this.ControlsSmoothAcceleration.Click += new System.EventHandler(this.ControlsSmoothAcceleration_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // ControlsColorSettingsMenu
            // 
            this.ControlsColorSettingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorSettingOptions,
            this.ColorSettingsCustom});
            this.ControlsColorSettingsMenu.Name = "ControlsColorSettingsMenu";
            this.ControlsColorSettingsMenu.Size = new System.Drawing.Size(183, 22);
            this.ControlsColorSettingsMenu.Text = "Color settings";
            // 
            // ColorSettingOptions
            // 
            this.ColorSettingOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorSettingOptions.Items.AddRange(new object[] {
            "Full Color",
            "8-bit",
            "todo:custom"});
            this.ColorSettingOptions.Name = "ColorSettingOptions";
            this.ColorSettingOptions.Size = new System.Drawing.Size(121, 23);
            this.ColorSettingOptions.TextChanged += new System.EventHandler(this.MathematicalSet_UpdateSet);
            // 
            // ColorSettingsCustom
            // 
            this.ColorSettingsCustom.Name = "ColorSettingsCustom";
            this.ColorSettingsCustom.Size = new System.Drawing.Size(181, 22);
            this.ColorSettingsCustom.Text = "Custom";
            this.ColorSettingsCustom.Click += new System.EventHandler(this.TODO);
            // 
            // MathematicalSetMenuTSMI
            // 
            this.MathematicalSetMenuTSMI.Name = "MathematicalSetMenuTSMI";
            this.MathematicalSetMenuTSMI.Size = new System.Drawing.Size(111, 20);
            this.MathematicalSetMenuTSMI.Text = "Mathematical Set";
            // 
            // ViewMenuTSMI
            // 
            this.ViewMenuTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewHideMenu,
            this.ControlsPause,
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
            this.ViewHideMenu.Click += new System.EventHandler(this.ViewHideMenu_Click);
            // 
            // ViewHideMenuAndResume
            // 
            this.ViewHideMenuAndResume.Name = "ViewHideMenuAndResume";
            this.ViewHideMenuAndResume.Size = new System.Drawing.Size(198, 22);
            this.ViewHideMenuAndResume.Text = "Hide Menu and resume";
            this.ViewHideMenuAndResume.Click += new System.EventHandler(this.ViewHideMenuAndResume_Click);
            // 
            // ViewPauseWhenMinimized
            // 
            this.ViewPauseWhenMinimized.Checked = true;
            this.ViewPauseWhenMinimized.CheckOnClick = true;
            this.ViewPauseWhenMinimized.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ViewPauseWhenMinimized.Name = "ViewPauseWhenMinimized";
            this.ViewPauseWhenMinimized.Size = new System.Drawing.Size(198, 22);
            this.ViewPauseWhenMinimized.Text = "Pause when minimized";
            this.ViewPauseWhenMinimized.Click += new System.EventHandler(this.TODO);
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
            this.MainFormMainMenuStrip.Size = new System.Drawing.Size(800, 24);
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
            this.ExitButton.Location = new System.Drawing.Point(772, 0);
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
            this.MinimizeButton.AutoSize = true;
            this.MinimizeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MinimizeButton.BackColor = System.Drawing.Color.Red;
            this.MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MinimizeButton.ForeColor = System.Drawing.Color.Black;
            this.MinimizeButton.Location = new System.Drawing.Point(746, 0);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(27, 22);
            this.MinimizeButton.TabIndex = 9998;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.Text = "—";
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.TODO);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MainFormMainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Mathematical Set Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseWheel);
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
        private System.Windows.Forms.ToolStripMenuItem ZoomSpeedCustom;
        private System.Windows.Forms.ToolStripMenuItem ControlsPanSpeed;
        private System.Windows.Forms.ToolStripMenuItem ControlsSmoothAcceleration;
        private System.Windows.Forms.ToolStripMenuItem ControlsColorSettingsMenu;
        private System.Windows.Forms.ToolStripMenuItem ColorSettingsCustom;
        private System.Windows.Forms.ToolStripMenuItem[] MathematicalSetMenuItems = new System.Windows.Forms.ToolStripMenuItem[MSVData.MathematicalSets.Count];
        private System.Windows.Forms.ToolStripMenuItem MathematicalSetMenuTSMI;
        private System.Windows.Forms.ToolStripMenuItem MathematicalSetMandelbrot;
        private System.Windows.Forms.ToolStripMenuItem MathematicalSetInverseMandelbrot;
        private System.Windows.Forms.ToolStripMenuItem MathematicalSetJuliaSet;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuTSMI;
        private System.Windows.Forms.ToolStripMenuItem ViewHideMenu;
        private System.Windows.Forms.ToolStripMenuItem ViewHideMenuAndResume;
        private System.Windows.Forms.MenuStrip MainFormMainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ControlsPause;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem ViewExit;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ViewPauseWhenMinimized;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox ColorSettingOptions;
    }
}

