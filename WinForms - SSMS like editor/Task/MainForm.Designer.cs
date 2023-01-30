namespace Task
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
            this.label1 = new System.Windows.Forms.Label();
            this.CbDatabases = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LbTables = new System.Windows.Forms.ListBox();
            this.LbTableColumns = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LbViews = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LbViewColumns = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LbProcParams = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LbProcedures = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TbProcDefinition = new System.Windows.Forms.TextBox();
            this.BtnXMLTables = new System.Windows.Forms.Button();
            this.BtnSelectTables = new System.Windows.Forms.Button();
            this.BtnSelectViews = new System.Windows.Forms.Button();
            this.BtnXMLViews = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Databases";
            // 
            // CbDatabases
            // 
            this.CbDatabases.FormattingEnabled = true;
            this.CbDatabases.Location = new System.Drawing.Point(113, 29);
            this.CbDatabases.Name = "CbDatabases";
            this.CbDatabases.Size = new System.Drawing.Size(192, 21);
            this.CbDatabases.TabIndex = 1;
            this.CbDatabases.SelectedIndexChanged += new System.EventHandler(this.CbDatabases_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tables";
            // 
            // LbTables
            // 
            this.LbTables.FormattingEnabled = true;
            this.LbTables.Location = new System.Drawing.Point(113, 82);
            this.LbTables.Name = "LbTables";
            this.LbTables.Size = new System.Drawing.Size(192, 199);
            this.LbTables.TabIndex = 3;
            this.LbTables.SelectedIndexChanged += new System.EventHandler(this.LbTables_SelectedIndexChanged);
            // 
            // LbTableColumns
            // 
            this.LbTableColumns.FormattingEnabled = true;
            this.LbTableColumns.Location = new System.Drawing.Point(411, 82);
            this.LbTableColumns.Name = "LbTableColumns";
            this.LbTableColumns.Size = new System.Drawing.Size(192, 199);
            this.LbTableColumns.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Table columns";
            // 
            // LbViews
            // 
            this.LbViews.FormattingEnabled = true;
            this.LbViews.Location = new System.Drawing.Point(714, 82);
            this.LbViews.Name = "LbViews";
            this.LbViews.Size = new System.Drawing.Size(192, 199);
            this.LbViews.TabIndex = 7;
            this.LbViews.SelectedIndexChanged += new System.EventHandler(this.LbViews_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(647, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Views";
            // 
            // LbViewColumns
            // 
            this.LbViewColumns.FormattingEnabled = true;
            this.LbViewColumns.Location = new System.Drawing.Point(1005, 82);
            this.LbViewColumns.Name = "LbViewColumns";
            this.LbViewColumns.Size = new System.Drawing.Size(192, 199);
            this.LbViewColumns.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(927, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "View columns";
            // 
            // LbProcParams
            // 
            this.LbProcParams.FormattingEnabled = true;
            this.LbProcParams.Location = new System.Drawing.Point(1005, 368);
            this.LbProcParams.Name = "LbProcParams";
            this.LbProcParams.Size = new System.Drawing.Size(192, 199);
            this.LbProcParams.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(930, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Proc. params";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(328, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Proc. definition";
            // 
            // LbProcedures
            // 
            this.LbProcedures.FormattingEnabled = true;
            this.LbProcedures.Location = new System.Drawing.Point(113, 368);
            this.LbProcedures.Name = "LbProcedures";
            this.LbProcedures.Size = new System.Drawing.Size(192, 199);
            this.LbProcedures.TabIndex = 11;
            this.LbProcedures.SelectedIndexChanged += new System.EventHandler(this.LbProcedures_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Procedures";
            // 
            // TbProcDefinition
            // 
            this.TbProcDefinition.Location = new System.Drawing.Point(411, 360);
            this.TbProcDefinition.Multiline = true;
            this.TbProcDefinition.Name = "TbProcDefinition";
            this.TbProcDefinition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbProcDefinition.Size = new System.Drawing.Size(495, 207);
            this.TbProcDefinition.TabIndex = 18;
            // 
            // BtnXMLTables
            // 
            this.BtnXMLTables.Location = new System.Drawing.Point(312, 207);
            this.BtnXMLTables.Name = "BtnXMLTables";
            this.BtnXMLTables.Size = new System.Drawing.Size(75, 33);
            this.BtnXMLTables.TabIndex = 19;
            this.BtnXMLTables.Text = "XML";
            this.BtnXMLTables.UseVisualStyleBackColor = true;
            // 
            // BtnSelectTables
            // 
            this.BtnSelectTables.Location = new System.Drawing.Point(311, 246);
            this.BtnSelectTables.Name = "BtnSelectTables";
            this.BtnSelectTables.Size = new System.Drawing.Size(75, 33);
            this.BtnSelectTables.TabIndex = 20;
            this.BtnSelectTables.Text = "Select";
            this.BtnSelectTables.UseVisualStyleBackColor = true;
            // 
            // BtnSelectViews
            // 
            this.BtnSelectViews.Location = new System.Drawing.Point(911, 246);
            this.BtnSelectViews.Name = "BtnSelectViews";
            this.BtnSelectViews.Size = new System.Drawing.Size(75, 33);
            this.BtnSelectViews.TabIndex = 22;
            this.BtnSelectViews.Text = "Select";
            this.BtnSelectViews.UseVisualStyleBackColor = true;
            // 
            // BtnXMLViews
            // 
            this.BtnXMLViews.Location = new System.Drawing.Point(912, 207);
            this.BtnXMLViews.Name = "BtnXMLViews";
            this.BtnXMLViews.Size = new System.Drawing.Size(75, 33);
            this.BtnXMLViews.TabIndex = 21;
            this.BtnXMLViews.Text = "XML";
            this.BtnXMLViews.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1226, 611);
            this.Controls.Add(this.BtnSelectViews);
            this.Controls.Add(this.BtnXMLViews);
            this.Controls.Add(this.BtnSelectTables);
            this.Controls.Add(this.BtnXMLTables);
            this.Controls.Add(this.TbProcDefinition);
            this.Controls.Add(this.LbProcParams);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LbProcedures);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LbViewColumns);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LbViews);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LbTableColumns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LbTables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbDatabases);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAIN FORM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbDatabases;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LbTables;
        private System.Windows.Forms.ListBox LbTableColumns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox LbViews;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox LbViewColumns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox LbProcParams;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox LbProcedures;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TbProcDefinition;
        private System.Windows.Forms.Button BtnXMLTables;
        private System.Windows.Forms.Button BtnSelectTables;
        private System.Windows.Forms.Button BtnSelectViews;
        private System.Windows.Forms.Button BtnXMLViews;
    }
}

