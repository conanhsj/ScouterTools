namespace ScouterTool.Forms
{
    partial class frmLogReader
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
            this.ckblLogs = new System.Windows.Forms.CheckedListBox();
            this.btnReader = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ckblLogs
            // 
            this.ckblLogs.FormattingEnabled = true;
            this.ckblLogs.Location = new System.Drawing.Point(12, 50);
            this.ckblLogs.Name = "ckblLogs";
            this.ckblLogs.Size = new System.Drawing.Size(155, 88);
            this.ckblLogs.TabIndex = 0;
            // 
            // btnReader
            // 
            this.btnReader.Location = new System.Drawing.Point(13, 13);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(75, 23);
            this.btnReader.TabIndex = 1;
            this.btnReader.Text = "btnReader";
            this.btnReader.UseVisualStyleBackColor = true;
            this.btnReader.Click += new System.EventHandler(this.btnReader_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(260, 13);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "确定或查找";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmLogReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 154);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnReader);
            this.Controls.Add(this.ckblLogs);
            this.Name = "frmLogReader";
            this.Text = "frmLogReader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ckblLogs;
        private System.Windows.Forms.Button btnReader;
        private System.Windows.Forms.Button btnSelect;
    }
}