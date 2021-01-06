namespace ScouterTool
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogReader = new System.Windows.Forms.Button();
            this.tvWayPoint = new System.Windows.Forms.TreeView();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogReader
            // 
            this.btnLogReader.Location = new System.Drawing.Point(13, 13);
            this.btnLogReader.Name = "btnLogReader";
            this.btnLogReader.Size = new System.Drawing.Size(75, 23);
            this.btnLogReader.TabIndex = 0;
            this.btnLogReader.Text = "本地Log";
            this.btnLogReader.UseVisualStyleBackColor = true;
            this.btnLogReader.Click += new System.EventHandler(this.btnLogReader_Click);
            // 
            // tvWayPoint
            // 
            this.tvWayPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvWayPoint.Location = new System.Drawing.Point(12, 52);
            this.tvWayPoint.Name = "tvWayPoint";
            this.tvWayPoint.Size = new System.Drawing.Size(359, 225);
            this.tvWayPoint.TabIndex = 1;
            this.tvWayPoint.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvWayPoint_NodeMouseDoubleClick);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(296, 13);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "再算一遍";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 287);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.tvWayPoint);
            this.Controls.Add(this.btnLogReader);
            this.Name = "frmMain";
            this.Text = "路径工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogReader;
        private System.Windows.Forms.TreeView tvWayPoint;
        private System.Windows.Forms.Button btnTest;
    }
}

