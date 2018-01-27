namespace PictureDownloader
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.url = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cookie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.end = new System.Windows.Forms.NumericUpDown();
            this.length = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.direct = new System.Windows.Forms.CheckBox();
            this.threads = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.logger = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.end)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threads)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // url
            // 
            this.url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.url.Location = new System.Drawing.Point(37, 5);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(335, 21);
            this.url.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "使用 * 替代URL中递增的部分";
            // 
            // cookie
            // 
            this.cookie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cookie.Enabled = false;
            this.cookie.Location = new System.Drawing.Point(55, 59);
            this.cookie.Name = "cookie";
            this.cookie.Size = new System.Drawing.Size(317, 21);
            this.cookie.TabIndex = 4;
            this.cookie.Text = "假装自己打算做";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cookie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "仅当需要登入才能查看时使用";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "递增范围";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(62, 114);
            this.start.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.start.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(50, 21);
            this.start.TabIndex = 7;
            this.start.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.start.ValueChanged += new System.EventHandler(this.start_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "~";
            // 
            // end
            // 
            this.end.Location = new System.Drawing.Point(125, 114);
            this.end.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.end.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(50, 21);
            this.end.TabIndex = 9;
            this.end.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.end.ValueChanged += new System.EventHandler(this.end_ValueChanged);
            // 
            // length
            // 
            this.length.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.length.Location = new System.Drawing.Point(322, 114);
            this.length.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(50, 21);
            this.length.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "最短替换长度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(275, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "最短替换长度指 * 替换为数字时，数字长度最小值\r\n如数字长度不够则在前面补0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "输出文件夹";
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(79, 179);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(264, 21);
            this.output.TabIndex = 14;
            this.output.KeyDown += new System.Windows.Forms.KeyEventHandler(this.output_KeyDown);
            this.output.Leave += new System.EventHandler(this.output_Leave);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(349, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "…";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(88, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "线程数";
            // 
            // direct
            // 
            this.direct.AutoSize = true;
            this.direct.Location = new System.Drawing.Point(10, 208);
            this.direct.Name = "direct";
            this.direct.Size = new System.Drawing.Size(72, 16);
            this.direct.TabIndex = 16;
            this.direct.Text = "直接下载";
            this.direct.UseVisualStyleBackColor = true;
            // 
            // threads
            // 
            this.threads.Location = new System.Drawing.Point(135, 207);
            this.threads.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.threads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threads.Name = "threads";
            this.threads.Size = new System.Drawing.Size(50, 21);
            this.threads.TabIndex = 18;
            this.threads.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(222, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 46);
            this.button2.TabIndex = 19;
            this.button2.Text = "开始下载";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(10, 234);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(206, 19);
            this.progress.TabIndex = 20;
            // 
            // logger
            // 
            this.logger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logger.Location = new System.Drawing.Point(10, 259);
            this.logger.Multiline = true;
            this.logger.Name = "logger";
            this.logger.ReadOnly = true;
            this.logger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logger.Size = new System.Drawing.Size(362, 91);
            this.logger.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.logger);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.threads);
            this.Controls.Add(this.direct);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.length);
            this.Controls.Add(this.end);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cookie);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.url);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Form1";
            this.Text = "图片下载器";
            ((System.ComponentModel.ISupportInitialize)(this.start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.end)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cookie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown end;
        private System.Windows.Forms.NumericUpDown length;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox direct;
        private System.Windows.Forms.NumericUpDown threads;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.TextBox logger;
    }
}

