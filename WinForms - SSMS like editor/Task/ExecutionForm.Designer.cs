namespace Task
{
    partial class ExecutionForm
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
            this.CbDatabases = new System.Windows.Forms.ComboBox();
            this.TbCommand = new System.Windows.Forms.TextBox();
            this.BtnExecute = new System.Windows.Forms.Button();
            this.TcResult = new System.Windows.Forms.TabControl();
            this.TbResult = new System.Windows.Forms.TabPage();
            this.TbMessage = new System.Windows.Forms.TabPage();
            this.TcResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbDatabases
            // 
            this.CbDatabases.FormattingEnabled = true;
            this.CbDatabases.Location = new System.Drawing.Point(12, 12);
            this.CbDatabases.Name = "CbDatabases";
            this.CbDatabases.Size = new System.Drawing.Size(150, 21);
            this.CbDatabases.TabIndex = 0;
            // 
            // TbCommand
            // 
            this.TbCommand.Location = new System.Drawing.Point(12, 54);
            this.TbCommand.Multiline = true;
            this.TbCommand.Name = "TbCommand";
            this.TbCommand.Size = new System.Drawing.Size(776, 160);
            this.TbCommand.TabIndex = 1;
            // 
            // BtnExecute
            // 
            this.BtnExecute.Location = new System.Drawing.Point(628, 242);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(143, 183);
            this.BtnExecute.TabIndex = 2;
            this.BtnExecute.Text = "Execute";
            this.BtnExecute.UseVisualStyleBackColor = true;
            this.BtnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // TcResult
            // 
            this.TcResult.Controls.Add(this.TbResult);
            this.TcResult.Controls.Add(this.TbMessage);
            this.TcResult.Location = new System.Drawing.Point(13, 220);
            this.TcResult.Name = "TcResult";
            this.TcResult.SelectedIndex = 0;
            this.TcResult.Size = new System.Drawing.Size(578, 209);
            this.TcResult.TabIndex = 3;
            // 
            // TbResult
            // 
            this.TbResult.Location = new System.Drawing.Point(4, 22);
            this.TbResult.Name = "TbResult";
            this.TbResult.Padding = new System.Windows.Forms.Padding(3);
            this.TbResult.Size = new System.Drawing.Size(570, 183);
            this.TbResult.TabIndex = 0;
            this.TbResult.Text = "Result";
            this.TbResult.UseVisualStyleBackColor = true;
            // 
            // TbMessage
            // 
            this.TbMessage.Location = new System.Drawing.Point(4, 22);
            this.TbMessage.Name = "TbMessage";
            this.TbMessage.Padding = new System.Windows.Forms.Padding(3);
            this.TbMessage.Size = new System.Drawing.Size(570, 183);
            this.TbMessage.TabIndex = 1;
            this.TbMessage.Text = "Message";
            this.TbMessage.UseVisualStyleBackColor = true;
            // 
            // ExecutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TcResult);
            this.Controls.Add(this.BtnExecute);
            this.Controls.Add(this.TbCommand);
            this.Controls.Add(this.CbDatabases);
            this.Name = "ExecutionForm";
            this.Text = "ExecutionForm";
            this.TcResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbDatabases;
        private System.Windows.Forms.TextBox TbCommand;
        private System.Windows.Forms.Button BtnExecute;
        private System.Windows.Forms.TabControl TcResult;
        private System.Windows.Forms.TabPage TbResult;
        private System.Windows.Forms.TabPage TbMessage;
    }
}