namespace FelicitySecurity.Applications.Config.Views
{
    partial class RegisterMembers_Form
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
            this.GeneralControls_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.RegisterMembersBackground_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeneralControls_MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneralControls_MenuStrip
            // 
            this.GeneralControls_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.GeneralControls_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.GeneralControls_MenuStrip.Name = "GeneralControls_MenuStrip";
            this.GeneralControls_MenuStrip.Size = new System.Drawing.Size(1009, 24);
            this.GeneralControls_MenuStrip.TabIndex = 0;
            // 
            // RegisterMembersBackground_TableLayoutPanel
            // 
            this.RegisterMembersBackground_TableLayoutPanel.ColumnCount = 2;
            this.RegisterMembersBackground_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.RegisterMembersBackground_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RegisterMembersBackground_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegisterMembersBackground_TableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.RegisterMembersBackground_TableLayoutPanel.Name = "RegisterMembersBackground_TableLayoutPanel";
            this.RegisterMembersBackground_TableLayoutPanel.RowCount = 2;
            this.RegisterMembersBackground_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.RegisterMembersBackground_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.RegisterMembersBackground_TableLayoutPanel.Size = new System.Drawing.Size(1009, 545);
            this.RegisterMembersBackground_TableLayoutPanel.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // RegisterMembers_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 569);
            this.Controls.Add(this.RegisterMembersBackground_TableLayoutPanel);
            this.Controls.Add(this.GeneralControls_MenuStrip);
            this.MainMenuStrip = this.GeneralControls_MenuStrip;
            this.MinimumSize = new System.Drawing.Size(1025, 608);
            this.Name = "RegisterMembers_Form";
            this.Text = "Register Members";
            this.GeneralControls_MenuStrip.ResumeLayout(false);
            this.GeneralControls_MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip GeneralControls_MenuStrip;
        private System.Windows.Forms.TableLayoutPanel RegisterMembersBackground_TableLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}