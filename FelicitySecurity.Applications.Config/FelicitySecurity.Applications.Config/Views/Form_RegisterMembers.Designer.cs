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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterMembers_Form));
            this.GeneralControls_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegisterMembersBackground_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MembersFacialCameraFeed_GroupBox = new System.Windows.Forms.GroupBox();
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NewMemberCredentials_GroupBox = new System.Windows.Forms.GroupBox();
            this.CameraOperations_GroupBox = new System.Windows.Forms.GroupBox();
            this.MemberRegistrationControls_GroupBox = new System.Windows.Forms.GroupBox();
            this.MoreMemberCredentials_GroupBox = new System.Windows.Forms.GroupBox();
            this.ExistingMembers_GroupBox = new System.Windows.Forms.GroupBox();
            this.ExistingMembersListboxSorting_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MembersListSortingControls_GroupBox = new System.Windows.Forms.GroupBox();
            this.ExistingMembers_ListBox = new System.Windows.Forms.ListBox();
            this.FacialDetectionFeedbackGroupBox = new System.Windows.Forms.GroupBox();
            this.FacialDetectionFeedBackImages_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.UsersFace = new Emgu.CV.UI.ImageBox();
            this.CroppedFace_GroupBox = new System.Windows.Forms.GroupBox();
            this.RecognisedMember_GroupBox = new System.Windows.Forms.GroupBox();
            this.CroppedDetectedFace_EmguImageBox = new Emgu.CV.UI.ImageBox();
            this.RecognisedMember_EmguImageBox = new Emgu.CV.UI.ImageBox();
            this.GeneralControls_MenuStrip.SuspendLayout();
            this.RegisterMembersBackground_TableLayoutPanel.SuspendLayout();
            this.MembersFacialCameraFeed_GroupBox.SuspendLayout();
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.SuspendLayout();
            this.ExistingMembers_GroupBox.SuspendLayout();
            this.ExistingMembersListboxSorting_TableLayoutPanel.SuspendLayout();
            this.FacialDetectionFeedbackGroupBox.SuspendLayout();
            this.FacialDetectionFeedBackImages_TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersFace)).BeginInit();
            this.CroppedFace_GroupBox.SuspendLayout();
            this.RecognisedMember_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CroppedDetectedFace_EmguImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecognisedMember_EmguImageBox)).BeginInit();
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
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // RegisterMembersBackground_TableLayoutPanel
            // 
            this.RegisterMembersBackground_TableLayoutPanel.ColumnCount = 2;
            this.RegisterMembersBackground_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.RegisterMembersBackground_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.RegisterMembersBackground_TableLayoutPanel.Controls.Add(this.MembersFacialCameraFeed_GroupBox, 0, 0);
            this.RegisterMembersBackground_TableLayoutPanel.Controls.Add(this.NewMemberCredentialsAndCameraControls_TableLayoutPanel, 0, 1);
            this.RegisterMembersBackground_TableLayoutPanel.Controls.Add(this.ExistingMembers_GroupBox, 1, 1);
            this.RegisterMembersBackground_TableLayoutPanel.Controls.Add(this.FacialDetectionFeedbackGroupBox, 1, 0);
            this.RegisterMembersBackground_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegisterMembersBackground_TableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.RegisterMembersBackground_TableLayoutPanel.Name = "RegisterMembersBackground_TableLayoutPanel";
            this.RegisterMembersBackground_TableLayoutPanel.RowCount = 2;
            this.RegisterMembersBackground_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.RegisterMembersBackground_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.RegisterMembersBackground_TableLayoutPanel.Size = new System.Drawing.Size(1009, 545);
            this.RegisterMembersBackground_TableLayoutPanel.TabIndex = 1;
            // 
            // MembersFacialCameraFeed_GroupBox
            // 
            this.MembersFacialCameraFeed_GroupBox.Controls.Add(this.UsersFace);
            this.MembersFacialCameraFeed_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MembersFacialCameraFeed_GroupBox.Location = new System.Drawing.Point(3, 3);
            this.MembersFacialCameraFeed_GroupBox.Name = "MembersFacialCameraFeed_GroupBox";
            this.MembersFacialCameraFeed_GroupBox.Size = new System.Drawing.Size(750, 321);
            this.MembersFacialCameraFeed_GroupBox.TabIndex = 0;
            this.MembersFacialCameraFeed_GroupBox.TabStop = false;
            this.MembersFacialCameraFeed_GroupBox.Text = "New Member Images";
            // 
            // NewMemberCredentialsAndCameraControls_TableLayoutPanel
            // 
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.ColumnCount = 4;
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.Controls.Add(this.NewMemberCredentials_GroupBox, 0, 0);
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.Controls.Add(this.CameraOperations_GroupBox, 2, 0);
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.Controls.Add(this.MemberRegistrationControls_GroupBox, 3, 0);
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.Controls.Add(this.MoreMemberCredentials_GroupBox, 1, 0);
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.Location = new System.Drawing.Point(3, 330);
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.Name = "NewMemberCredentialsAndCameraControls_TableLayoutPanel";
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.RowCount = 1;
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.Size = new System.Drawing.Size(750, 212);
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.TabIndex = 1;
            // 
            // NewMemberCredentials_GroupBox
            // 
            this.NewMemberCredentials_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewMemberCredentials_GroupBox.Location = new System.Drawing.Point(3, 3);
            this.NewMemberCredentials_GroupBox.Name = "NewMemberCredentials_GroupBox";
            this.NewMemberCredentials_GroupBox.Size = new System.Drawing.Size(181, 206);
            this.NewMemberCredentials_GroupBox.TabIndex = 0;
            this.NewMemberCredentials_GroupBox.TabStop = false;
            this.NewMemberCredentials_GroupBox.Text = "Credentials";
            // 
            // CameraOperations_GroupBox
            // 
            this.CameraOperations_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraOperations_GroupBox.Location = new System.Drawing.Point(377, 3);
            this.CameraOperations_GroupBox.Name = "CameraOperations_GroupBox";
            this.CameraOperations_GroupBox.Size = new System.Drawing.Size(181, 206);
            this.CameraOperations_GroupBox.TabIndex = 1;
            this.CameraOperations_GroupBox.TabStop = false;
            this.CameraOperations_GroupBox.Text = "Camera Operations";
            // 
            // MemberRegistrationControls_GroupBox
            // 
            this.MemberRegistrationControls_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberRegistrationControls_GroupBox.Location = new System.Drawing.Point(564, 3);
            this.MemberRegistrationControls_GroupBox.Name = "MemberRegistrationControls_GroupBox";
            this.MemberRegistrationControls_GroupBox.Size = new System.Drawing.Size(183, 206);
            this.MemberRegistrationControls_GroupBox.TabIndex = 2;
            this.MemberRegistrationControls_GroupBox.TabStop = false;
            this.MemberRegistrationControls_GroupBox.Text = "Registration Controls";
            // 
            // MoreMemberCredentials_GroupBox
            // 
            this.MoreMemberCredentials_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoreMemberCredentials_GroupBox.Location = new System.Drawing.Point(190, 3);
            this.MoreMemberCredentials_GroupBox.Name = "MoreMemberCredentials_GroupBox";
            this.MoreMemberCredentials_GroupBox.Size = new System.Drawing.Size(181, 206);
            this.MoreMemberCredentials_GroupBox.TabIndex = 3;
            this.MoreMemberCredentials_GroupBox.TabStop = false;
            // 
            // ExistingMembers_GroupBox
            // 
            this.ExistingMembers_GroupBox.Controls.Add(this.ExistingMembersListboxSorting_TableLayoutPanel);
            this.ExistingMembers_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExistingMembers_GroupBox.Location = new System.Drawing.Point(759, 330);
            this.ExistingMembers_GroupBox.Name = "ExistingMembers_GroupBox";
            this.ExistingMembers_GroupBox.Size = new System.Drawing.Size(247, 212);
            this.ExistingMembers_GroupBox.TabIndex = 2;
            this.ExistingMembers_GroupBox.TabStop = false;
            this.ExistingMembers_GroupBox.Text = "Existing Members ";
            // 
            // ExistingMembersListboxSorting_TableLayoutPanel
            // 
            this.ExistingMembersListboxSorting_TableLayoutPanel.ColumnCount = 1;
            this.ExistingMembersListboxSorting_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExistingMembersListboxSorting_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ExistingMembersListboxSorting_TableLayoutPanel.Controls.Add(this.MembersListSortingControls_GroupBox, 0, 0);
            this.ExistingMembersListboxSorting_TableLayoutPanel.Controls.Add(this.ExistingMembers_ListBox, 0, 1);
            this.ExistingMembersListboxSorting_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExistingMembersListboxSorting_TableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.ExistingMembersListboxSorting_TableLayoutPanel.Name = "ExistingMembersListboxSorting_TableLayoutPanel";
            this.ExistingMembersListboxSorting_TableLayoutPanel.RowCount = 2;
            this.ExistingMembersListboxSorting_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ExistingMembersListboxSorting_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.ExistingMembersListboxSorting_TableLayoutPanel.Size = new System.Drawing.Size(241, 193);
            this.ExistingMembersListboxSorting_TableLayoutPanel.TabIndex = 0;
            // 
            // MembersListSortingControls_GroupBox
            // 
            this.MembersListSortingControls_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MembersListSortingControls_GroupBox.Location = new System.Drawing.Point(3, 3);
            this.MembersListSortingControls_GroupBox.Name = "MembersListSortingControls_GroupBox";
            this.MembersListSortingControls_GroupBox.Size = new System.Drawing.Size(235, 32);
            this.MembersListSortingControls_GroupBox.TabIndex = 0;
            this.MembersListSortingControls_GroupBox.TabStop = false;
            // 
            // ExistingMembers_ListBox
            // 
            this.ExistingMembers_ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExistingMembers_ListBox.FormattingEnabled = true;
            this.ExistingMembers_ListBox.Location = new System.Drawing.Point(3, 41);
            this.ExistingMembers_ListBox.Name = "ExistingMembers_ListBox";
            this.ExistingMembers_ListBox.Size = new System.Drawing.Size(235, 149);
            this.ExistingMembers_ListBox.TabIndex = 1;
            // 
            // FacialDetectionFeedbackGroupBox
            // 
            this.FacialDetectionFeedbackGroupBox.Controls.Add(this.FacialDetectionFeedBackImages_TableLayoutPanel);
            this.FacialDetectionFeedbackGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacialDetectionFeedbackGroupBox.Location = new System.Drawing.Point(759, 3);
            this.FacialDetectionFeedbackGroupBox.Name = "FacialDetectionFeedbackGroupBox";
            this.FacialDetectionFeedbackGroupBox.Size = new System.Drawing.Size(247, 321);
            this.FacialDetectionFeedbackGroupBox.TabIndex = 3;
            this.FacialDetectionFeedbackGroupBox.TabStop = false;
            this.FacialDetectionFeedbackGroupBox.Text = "Facial Detection Feedback ";
            // 
            // FacialDetectionFeedBackImages_TableLayoutPanel
            // 
            this.FacialDetectionFeedBackImages_TableLayoutPanel.ColumnCount = 1;
            this.FacialDetectionFeedBackImages_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FacialDetectionFeedBackImages_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FacialDetectionFeedBackImages_TableLayoutPanel.Controls.Add(this.CroppedFace_GroupBox, 0, 0);
            this.FacialDetectionFeedBackImages_TableLayoutPanel.Controls.Add(this.RecognisedMember_GroupBox, 0, 1);
            this.FacialDetectionFeedBackImages_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacialDetectionFeedBackImages_TableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.FacialDetectionFeedBackImages_TableLayoutPanel.Name = "FacialDetectionFeedBackImages_TableLayoutPanel";
            this.FacialDetectionFeedBackImages_TableLayoutPanel.RowCount = 2;
            this.FacialDetectionFeedBackImages_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FacialDetectionFeedBackImages_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FacialDetectionFeedBackImages_TableLayoutPanel.Size = new System.Drawing.Size(241, 302);
            this.FacialDetectionFeedBackImages_TableLayoutPanel.TabIndex = 0;
            // 
            // UsersFace
            // 
            this.UsersFace.BackColor = System.Drawing.Color.Transparent;
            this.UsersFace.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UsersFace.BackgroundImage")));
            this.UsersFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsersFace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersFace.Location = new System.Drawing.Point(3, 16);
            this.UsersFace.Margin = new System.Windows.Forms.Padding(2);
            this.UsersFace.Name = "UsersFace";
            this.UsersFace.Size = new System.Drawing.Size(744, 302);
            this.UsersFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UsersFace.TabIndex = 5;
            this.UsersFace.TabStop = false;
            // 
            // CroppedFace_GroupBox
            // 
            this.CroppedFace_GroupBox.Controls.Add(this.CroppedDetectedFace_EmguImageBox);
            this.CroppedFace_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CroppedFace_GroupBox.Location = new System.Drawing.Point(3, 3);
            this.CroppedFace_GroupBox.Name = "CroppedFace_GroupBox";
            this.CroppedFace_GroupBox.Size = new System.Drawing.Size(235, 145);
            this.CroppedFace_GroupBox.TabIndex = 0;
            this.CroppedFace_GroupBox.TabStop = false;
            this.CroppedFace_GroupBox.Text = "Cropped Image (Live)";
            // 
            // RecognisedMember_GroupBox
            // 
            this.RecognisedMember_GroupBox.Controls.Add(this.RecognisedMember_EmguImageBox);
            this.RecognisedMember_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecognisedMember_GroupBox.Location = new System.Drawing.Point(3, 154);
            this.RecognisedMember_GroupBox.Name = "RecognisedMember_GroupBox";
            this.RecognisedMember_GroupBox.Size = new System.Drawing.Size(235, 145);
            this.RecognisedMember_GroupBox.TabIndex = 1;
            this.RecognisedMember_GroupBox.TabStop = false;
            this.RecognisedMember_GroupBox.Text = "Recognised Member";
            // 
            // CroppedDetectedFace_EmguImageBox
            // 
            this.CroppedDetectedFace_EmguImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CroppedDetectedFace_EmguImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CroppedDetectedFace_EmguImageBox.Location = new System.Drawing.Point(3, 16);
            this.CroppedDetectedFace_EmguImageBox.Margin = new System.Windows.Forms.Padding(2);
            this.CroppedDetectedFace_EmguImageBox.Name = "CroppedDetectedFace_EmguImageBox";
            this.CroppedDetectedFace_EmguImageBox.Size = new System.Drawing.Size(229, 126);
            this.CroppedDetectedFace_EmguImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CroppedDetectedFace_EmguImageBox.TabIndex = 6;
            this.CroppedDetectedFace_EmguImageBox.TabStop = false;
            // 
            // RecognisedMember_EmguImageBox
            // 
            this.RecognisedMember_EmguImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecognisedMember_EmguImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecognisedMember_EmguImageBox.Location = new System.Drawing.Point(3, 16);
            this.RecognisedMember_EmguImageBox.Margin = new System.Windows.Forms.Padding(2);
            this.RecognisedMember_EmguImageBox.Name = "RecognisedMember_EmguImageBox";
            this.RecognisedMember_EmguImageBox.Size = new System.Drawing.Size(229, 126);
            this.RecognisedMember_EmguImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RecognisedMember_EmguImageBox.TabIndex = 7;
            this.RecognisedMember_EmguImageBox.TabStop = false;
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
            this.RegisterMembersBackground_TableLayoutPanel.ResumeLayout(false);
            this.MembersFacialCameraFeed_GroupBox.ResumeLayout(false);
            this.NewMemberCredentialsAndCameraControls_TableLayoutPanel.ResumeLayout(false);
            this.ExistingMembers_GroupBox.ResumeLayout(false);
            this.ExistingMembersListboxSorting_TableLayoutPanel.ResumeLayout(false);
            this.FacialDetectionFeedbackGroupBox.ResumeLayout(false);
            this.FacialDetectionFeedBackImages_TableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UsersFace)).EndInit();
            this.CroppedFace_GroupBox.ResumeLayout(false);
            this.RecognisedMember_GroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CroppedDetectedFace_EmguImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecognisedMember_EmguImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip GeneralControls_MenuStrip;
        private System.Windows.Forms.TableLayoutPanel RegisterMembersBackground_TableLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.GroupBox MembersFacialCameraFeed_GroupBox;
        private System.Windows.Forms.TableLayoutPanel NewMemberCredentialsAndCameraControls_TableLayoutPanel;
        private System.Windows.Forms.GroupBox NewMemberCredentials_GroupBox;
        private System.Windows.Forms.GroupBox CameraOperations_GroupBox;
        private System.Windows.Forms.GroupBox MemberRegistrationControls_GroupBox;
        private System.Windows.Forms.GroupBox MoreMemberCredentials_GroupBox;
        private System.Windows.Forms.GroupBox ExistingMembers_GroupBox;
        private System.Windows.Forms.GroupBox FacialDetectionFeedbackGroupBox;
        private System.Windows.Forms.TableLayoutPanel FacialDetectionFeedBackImages_TableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel ExistingMembersListboxSorting_TableLayoutPanel;
        private System.Windows.Forms.GroupBox MembersListSortingControls_GroupBox;
        public System.Windows.Forms.ListBox ExistingMembers_ListBox;
        public Emgu.CV.UI.ImageBox UsersFace;
        private System.Windows.Forms.GroupBox CroppedFace_GroupBox;
        private System.Windows.Forms.GroupBox RecognisedMember_GroupBox;
        public Emgu.CV.UI.ImageBox CroppedDetectedFace_EmguImageBox;
        public Emgu.CV.UI.ImageBox RecognisedMember_EmguImageBox;
    }
}