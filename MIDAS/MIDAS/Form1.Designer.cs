﻿namespace MIDAS
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Class", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Line", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Class"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Control, null);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "Interface"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Control, null);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "Line"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Control, null);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParentWindow = new System.Windows.Forms.SplitContainer();
            this.LeftWindow = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveBeginSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveEndSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenRecentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParentWindow)).BeginInit();
            this.ParentWindow.Panel1.SuspendLayout();
            this.ParentWindow.Panel2.SuspendLayout();
            this.ParentWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftWindow)).BeginInit();
            this.LeftWindow.Panel2.SuspendLayout();
            this.LeftWindow.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(688, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.OpenRecentMenuItem,
            this.SaveBeginSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.SaveAllMenuItem,
            this.SaveEndSeparator,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.CloseSeparator,
            this.CloseMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportItem_Click);
            // 
            // ParentWindow
            // 
            this.ParentWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ParentWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParentWindow.Location = new System.Drawing.Point(0, 24);
            this.ParentWindow.Name = "ParentWindow";
            // 
            // ParentWindow.Panel1
            // 
            this.ParentWindow.Panel1.Controls.Add(this.LeftWindow);
            // 
            // ParentWindow.Panel2
            // 
            this.ParentWindow.Panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ParentWindow.Panel2.Controls.Add(this.RightPanel);
            this.ParentWindow.Size = new System.Drawing.Size(688, 288);
            this.ParentWindow.SplitterDistance = 228;
            this.ParentWindow.TabIndex = 2;
            // 
            // LeftWindow
            // 
            this.LeftWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftWindow.Location = new System.Drawing.Point(0, 0);
            this.LeftWindow.Name = "LeftWindow";
            this.LeftWindow.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LeftWindow.Panel1
            // 
            this.LeftWindow.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            // 
            // LeftWindow.Panel2
            // 
            this.LeftWindow.Panel2.Controls.Add(this.listView1);
            this.LeftWindow.Size = new System.Drawing.Size(228, 288);
            this.LeftWindow.SplitterDistance = 82;
            this.LeftWindow.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup5.Header = "Class";
            listViewGroup5.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup5.Name = "ClassGroup";
            listViewGroup6.Header = "Line";
            listViewGroup6.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup6.Name = "LineGroup";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6});
            this.listView1.HoverSelection = true;
            listViewItem7.Group = listViewGroup5;
            listViewItem7.StateImageIndex = 0;
            listViewItem8.Group = listViewGroup5;
            listViewItem8.StateImageIndex = 0;
            listViewItem9.Group = listViewGroup6;
            listViewItem9.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.Size = new System.Drawing.Size(226, 200);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.button1);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(0, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(454, 286);
            this.RightPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(314, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveBeginSeparator
            // 
            this.SaveBeginSeparator.Name = "SaveBeginSeparator";
            this.SaveBeginSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // SaveEndSeparator
            // 
            this.SaveEndSeparator.Name = "SaveEndSeparator";
            this.SaveEndSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // SaveAllMenuItem
            // 
            this.SaveAllMenuItem.Name = "SaveAllMenuItem";
            this.SaveAllMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SaveAllMenuItem.Text = "Save All";
            // 
            // OpenRecentMenuItem
            // 
            this.OpenRecentMenuItem.Name = "OpenRecentMenuItem";
            this.OpenRecentMenuItem.Size = new System.Drawing.Size(152, 22);
            this.OpenRecentMenuItem.Text = "Open Recent";
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.CloseMenuItem.Size = new System.Drawing.Size(190, 22);
            this.CloseMenuItem.Text = "Close";
            this.CloseMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // CloseSeparator
            // 
            this.CloseSeparator.Name = "CloseSeparator";
            this.CloseSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 312);
            this.Controls.Add(this.ParentWindow);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ParentWindow.Panel1.ResumeLayout(false);
            this.ParentWindow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ParentWindow)).EndInit();
            this.ParentWindow.ResumeLayout(false);
            this.LeftWindow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftWindow)).EndInit();
            this.LeftWindow.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.SplitContainer ParentWindow;
        private System.Windows.Forms.SplitContainer LeftWindow;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem OpenRecentMenuItem;
        private System.Windows.Forms.ToolStripSeparator SaveBeginSeparator;
        private System.Windows.Forms.ToolStripMenuItem SaveAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator SaveEndSeparator;
        private System.Windows.Forms.ToolStripSeparator CloseSeparator;
        private System.Windows.Forms.ToolStripMenuItem CloseMenuItem;
    }
}

