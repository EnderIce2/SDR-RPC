namespace EnderIce2.SDRSharpPlugin
{
    partial class ControlPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            helpBtn = new System.Windows.Forms.Button();
            creditsBtn = new System.Windows.Forms.Button();
            dbgCheckBox = new System.Windows.Forms.CheckBox();
            IDtxtBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            statusLbl = new System.Windows.Forms.Label();
            versionLbl = new System.Windows.Forms.Label();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 0);
            tableLayoutPanel1.Controls.Add(versionLbl, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.MinimumSize = new System.Drawing.Size(200, 200);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            tableLayoutPanel1.Size = new System.Drawing.Size(200, 200);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(helpBtn);
            groupBox1.Controls.Add(creditsBtn);
            groupBox1.Controls.Add(dbgCheckBox);
            groupBox1.Controls.Add(IDtxtBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(3, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(194, 126);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings";
            // 
            // helpBtn
            // 
            helpBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            helpBtn.Location = new System.Drawing.Point(6, 71);
            helpBtn.Name = "helpBtn";
            helpBtn.Size = new System.Drawing.Size(67, 23);
            helpBtn.TabIndex = 2;
            helpBtn.Text = "Help";
            helpBtn.UseVisualStyleBackColor = true;
            helpBtn.Click += helpBtn_Click;
            // 
            // creditsBtn
            // 
            creditsBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            creditsBtn.Location = new System.Drawing.Point(79, 71);
            creditsBtn.Name = "creditsBtn";
            creditsBtn.Size = new System.Drawing.Size(67, 23);
            creditsBtn.TabIndex = 3;
            creditsBtn.Text = "Credits";
            creditsBtn.UseVisualStyleBackColor = true;
            creditsBtn.Click += creditsBtn_Click;
            // 
            // dbgCheckBox
            // 
            dbgCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            dbgCheckBox.AutoSize = true;
            dbgCheckBox.Location = new System.Drawing.Point(6, 100);
            dbgCheckBox.Name = "dbgCheckBox";
            dbgCheckBox.Size = new System.Drawing.Size(150, 19);
            dbgCheckBox.TabIndex = 4;
            dbgCheckBox.Text = "Enable logging (debug)";
            dbgCheckBox.UseVisualStyleBackColor = true;
            dbgCheckBox.CheckedChanged += dbgCheckBox_CheckedChanged;
            // 
            // IDtxtBox
            // 
            IDtxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            IDtxtBox.Location = new System.Drawing.Point(6, 37);
            IDtxtBox.MaxLength = 18;
            IDtxtBox.Name = "IDtxtBox";
            IDtxtBox.PlaceholderText = "765213507321856078";
            IDtxtBox.Size = new System.Drawing.Size(117, 16);
            IDtxtBox.TabIndex = 1;
            IDtxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            IDtxtBox.KeyDown += IDtxtBox_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 19);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(97, 15);
            label2.TabIndex = 0;
            label2.Text = "Custom Client ID";
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(statusLbl);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Location = new System.Drawing.Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(194, 44);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Status";
            // 
            // statusLbl
            // 
            statusLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            statusLbl.Location = new System.Drawing.Point(3, 19);
            statusLbl.Name = "statusLbl";
            statusLbl.Size = new System.Drawing.Size(188, 22);
            statusLbl.TabIndex = 1;
            statusLbl.Text = "Status Label";
            statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLbl
            // 
            versionLbl.AutoSize = true;
            versionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            versionLbl.Location = new System.Drawing.Point(3, 182);
            versionLbl.Name = "versionLbl";
            versionLbl.Size = new System.Drawing.Size(194, 18);
            versionLbl.TabIndex = 4;
            versionLbl.Text = "v0.0.0.0";
            versionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            versionLbl.DoubleClick += versionLbl_DoubleClick;
            // 
            // ControlPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new System.Drawing.Size(200, 200);
            Controls.Add(tableLayoutPanel1);
            Name = "ControlPanel";
            Size = new System.Drawing.Size(200, 200);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox IDtxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox dbgCheckBox;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Button creditsBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label versionLbl;
    }
}
