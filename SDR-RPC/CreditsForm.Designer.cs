namespace EnderIce2.SDRSharpPlugin
{
    partial class CreditsForm
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            lacheeLic = new System.Windows.Forms.LinkLabel();
            lacheeSrc = new System.Windows.Forms.LinkLabel();
            groupBox2 = new System.Windows.Forms.GroupBox();
            jamesLic = new System.Windows.Forms.LinkLabel();
            jamesSrc = new System.Windows.Forms.LinkLabel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lacheeLic);
            groupBox1.Controls.Add(lacheeSrc);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(171, 47);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lachee/discord-rpc-csharp";
            // 
            // lacheeLic
            // 
            lacheeLic.ActiveLinkColor = System.Drawing.Color.White;
            lacheeLic.AutoSize = true;
            lacheeLic.DisabledLinkColor = System.Drawing.Color.Silver;
            lacheeLic.LinkColor = System.Drawing.Color.White;
            lacheeLic.Location = new System.Drawing.Point(6, 19);
            lacheeLic.Name = "lacheeLic";
            lacheeLic.Size = new System.Drawing.Size(71, 15);
            lacheeLic.TabIndex = 1;
            lacheeLic.TabStop = true;
            lacheeLic.Text = "View license";
            lacheeLic.VisitedLinkColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lacheeLic.LinkClicked += lacheeLic_LinkClicked;
            // 
            // lacheeSrc
            // 
            lacheeSrc.ActiveLinkColor = System.Drawing.Color.White;
            lacheeSrc.AutoSize = true;
            lacheeSrc.DisabledLinkColor = System.Drawing.Color.Silver;
            lacheeSrc.LinkColor = System.Drawing.Color.White;
            lacheeSrc.Location = new System.Drawing.Point(83, 19);
            lacheeSrc.Name = "lacheeSrc";
            lacheeSrc.Size = new System.Drawing.Size(70, 15);
            lacheeSrc.TabIndex = 0;
            lacheeSrc.TabStop = true;
            lacheeSrc.Text = "View source";
            lacheeSrc.VisitedLinkColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lacheeSrc.LinkClicked += lacheeSrc_LinkClicked;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(jamesLic);
            groupBox2.Controls.Add(jamesSrc);
            groupBox2.ForeColor = System.Drawing.Color.White;
            groupBox2.Location = new System.Drawing.Point(12, 65);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(171, 47);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "JamesNK/Newtonsoft.Json";
            // 
            // jamesLic
            // 
            jamesLic.ActiveLinkColor = System.Drawing.Color.White;
            jamesLic.AutoSize = true;
            jamesLic.DisabledLinkColor = System.Drawing.Color.Silver;
            jamesLic.LinkColor = System.Drawing.Color.White;
            jamesLic.Location = new System.Drawing.Point(6, 19);
            jamesLic.Name = "jamesLic";
            jamesLic.Size = new System.Drawing.Size(71, 15);
            jamesLic.TabIndex = 3;
            jamesLic.TabStop = true;
            jamesLic.Text = "View license";
            jamesLic.VisitedLinkColor = System.Drawing.Color.FromArgb(224, 224, 224);
            jamesLic.LinkClicked += jamesLic_LinkClicked;
            // 
            // jamesSrc
            // 
            jamesSrc.ActiveLinkColor = System.Drawing.Color.White;
            jamesSrc.AutoSize = true;
            jamesSrc.DisabledLinkColor = System.Drawing.Color.Silver;
            jamesSrc.LinkColor = System.Drawing.Color.White;
            jamesSrc.Location = new System.Drawing.Point(83, 19);
            jamesSrc.Name = "jamesSrc";
            jamesSrc.Size = new System.Drawing.Size(70, 15);
            jamesSrc.TabIndex = 2;
            jamesSrc.TabStop = true;
            jamesSrc.Text = "View source";
            jamesSrc.VisitedLinkColor = System.Drawing.Color.FromArgb(224, 224, 224);
            jamesSrc.LinkClicked += jamesSrc_LinkClicked;
            // 
            // CreditsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            ClientSize = new System.Drawing.Size(196, 123);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreditsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Credits";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel lacheeLic;
        private System.Windows.Forms.LinkLabel lacheeSrc;
        private System.Windows.Forms.LinkLabel jamesLic;
        private System.Windows.Forms.LinkLabel jamesSrc;
    }
}