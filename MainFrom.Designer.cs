namespace TcgUpgrade
{
    partial class MainFrom
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.button1 = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.viewlist = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cont_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.is_upload_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.res_state = new System.Windows.Forms.Label();
            this.res_nav_text = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open_file_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notepad_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.note_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.js_Compress_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.header_StripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MerGerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.post_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.load2_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drop_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.had_upload_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hebin_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about_TcgUpgradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(458, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "推 送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // load
            // 
            this.load.Font = new System.Drawing.Font("宋体", 12F);
            this.load.Location = new System.Drawing.Point(14, 38);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(94, 34);
            this.load.TabIndex = 1;
            this.load.Text = "载入";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.button2_Click);
            // 
            // viewlist
            // 
            this.viewlist.AllowDrop = true;
            this.viewlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.viewlist.ContextMenuStrip = this.contextMenuStrip1;
            this.viewlist.FormattingEnabled = true;
            this.viewlist.ItemHeight = 12;
            this.viewlist.Location = new System.Drawing.Point(12, 97);
            this.viewlist.Name = "viewlist";
            this.viewlist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.viewlist.Size = new System.Drawing.Size(547, 208);
            this.viewlist.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cont_ToolStripMenuItem,
            this.is_upload_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // cont_ToolStripMenuItem
            // 
            this.cont_ToolStripMenuItem.Name = "cont_ToolStripMenuItem";
            this.cont_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cont_ToolStripMenuItem.Text = "删除";
            this.cont_ToolStripMenuItem.Click += new System.EventHandler(this.aaToolStripMenuItem_Click);
            // 
            // is_upload_ToolStripMenuItem
            // 
            this.is_upload_ToolStripMenuItem.Name = "is_upload_ToolStripMenuItem";
            this.is_upload_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.is_upload_ToolStripMenuItem.Text = "标记已传";
            this.is_upload_ToolStripMenuItem.Click += new System.EventHandler(this.is_upload_ToolStripMenuItem_Click);
            // 
            // res_state
            // 
            this.res_state.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.res_state.AutoSize = true;
            this.res_state.Location = new System.Drawing.Point(12, 312);
            this.res_state.Name = "res_state";
            this.res_state.Size = new System.Drawing.Size(11, 12);
            this.res_state.TabIndex = 3;
            this.res_state.Text = "-";
            // 
            // res_nav_text
            // 
            this.res_nav_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.res_nav_text.AutoSize = true;
            this.res_nav_text.Location = new System.Drawing.Point(252, 312);
            this.res_nav_text.Name = "res_nav_text";
            this.res_nav_text.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.res_nav_text.Size = new System.Drawing.Size(11, 12);
            this.res_nav_text.TabIndex = 4;
            this.res_nav_text.Text = "-";
            this.res_nav_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.文件ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(172, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit_ToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(41, 20);
            this.toolStripMenuItem1.Text = "文件";
            // 
            // exit_ToolStripMenuItem1
            // 
            this.exit_ToolStripMenuItem1.Name = "exit_ToolStripMenuItem1";
            this.exit_ToolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.exit_ToolStripMenuItem1.Text = "退出";
            this.exit_ToolStripMenuItem1.Click += new System.EventHandler(this.exit_ToolStripMenuItem1_Click);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_file_ToolStripMenuItem,
            this.notepad_ToolStripMenuItem,
            this.note_ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.文件ToolStripMenuItem.Text = "编辑";
            // 
            // open_file_ToolStripMenuItem
            // 
            this.open_file_ToolStripMenuItem.Name = "open_file_ToolStripMenuItem";
            this.open_file_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.open_file_ToolStripMenuItem.Text = "打开列表文件夹";
            this.open_file_ToolStripMenuItem.Click += new System.EventHandler(this.open_file_ToolStripMenuItem_Click);
            // 
            // notepad_ToolStripMenuItem
            // 
            this.notepad_ToolStripMenuItem.Name = "notepad_ToolStripMenuItem";
            this.notepad_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.notepad_ToolStripMenuItem.Text = "Notepad++打开";
            this.notepad_ToolStripMenuItem.Click += new System.EventHandler(this.notepad_ToolStripMenuItem_Click);
            // 
            // note_ToolStripMenuItem
            // 
            this.note_ToolStripMenuItem.Name = "note_ToolStripMenuItem";
            this.note_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.note_ToolStripMenuItem.Text = "记事本打开";
            this.note_ToolStripMenuItem.Click += new System.EventHandler(this.note_ToolStripMenuItem_Click);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.js_Compress_ToolStripMenuItem,
            this.header_StripMenuItem,
            this.MerGerToolStripMenuItem,
            this.post_ToolStripMenuItem,
            this.load2_toolStripMenuItem,
            this.drop_ToolStripMenuItem,
            this.had_upload_ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // js_Compress_ToolStripMenuItem
            // 
            this.js_Compress_ToolStripMenuItem.Name = "js_Compress_ToolStripMenuItem";
            this.js_Compress_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.js_Compress_ToolStripMenuItem.Text = "js压缩";
            this.js_Compress_ToolStripMenuItem.Click += new System.EventHandler(this.js_Compress_ToolStripMenuItem_Click);
            // 
            // header_StripMenuItem
            // 
            this.header_StripMenuItem.Name = "header_StripMenuItem";
            this.header_StripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.header_StripMenuItem.Text = "通用头部同步";
            this.header_StripMenuItem.Click += new System.EventHandler(this.header_StripMenuItem_Click);
            // 
            // MerGerToolStripMenuItem
            // 
            this.MerGerToolStripMenuItem.Name = "MerGerToolStripMenuItem";
            this.MerGerToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.MerGerToolStripMenuItem.Text = "合并";
            this.MerGerToolStripMenuItem.Click += new System.EventHandler(this.MerGerToolStripMenuItem_Click);
            // 
            // post_ToolStripMenuItem
            // 
            this.post_ToolStripMenuItem.Name = "post_ToolStripMenuItem";
            this.post_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.post_ToolStripMenuItem.Text = "推送";
            this.post_ToolStripMenuItem.Click += new System.EventHandler(this.post_ToolStripMenuItem_Click);
            // 
            // load2_toolStripMenuItem
            // 
            this.load2_toolStripMenuItem.Name = "load2_toolStripMenuItem";
            this.load2_toolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.load2_toolStripMenuItem.Text = "载入";
            this.load2_toolStripMenuItem.Click += new System.EventHandler(this.load2_toolStripMenuItem_Click);
            // 
            // drop_ToolStripMenuItem
            // 
            this.drop_ToolStripMenuItem.Name = "drop_ToolStripMenuItem";
            this.drop_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.drop_ToolStripMenuItem.Text = "删除";
            this.drop_ToolStripMenuItem.Click += new System.EventHandler(this.drop_ToolStripMenuItem_Click);
            // 
            // had_upload_ToolStripMenuItem
            // 
            this.had_upload_ToolStripMenuItem.Name = "had_upload_ToolStripMenuItem";
            this.had_upload_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.had_upload_ToolStripMenuItem.Text = "标记已上传";
            this.had_upload_ToolStripMenuItem.Click += new System.EventHandler(this.had_upload_ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hebin_ToolStripMenuItem,
            this.about_TcgUpgradeToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // hebin_ToolStripMenuItem
            // 
            this.hebin_ToolStripMenuItem.Name = "hebin_ToolStripMenuItem";
            this.hebin_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.hebin_ToolStripMenuItem.Text = "合并说明";
            this.hebin_ToolStripMenuItem.Click += new System.EventHandler(this.hebin_ToolStripMenuItem_Click);
            // 
            // about_TcgUpgradeToolStripMenuItem
            // 
            this.about_TcgUpgradeToolStripMenuItem.Name = "about_TcgUpgradeToolStripMenuItem";
            this.about_TcgUpgradeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.about_TcgUpgradeToolStripMenuItem.Text = "关于TcgUpgrade";
            this.about_TcgUpgradeToolStripMenuItem.Click += new System.EventHandler(this.about_TcgUpgradeToolStripMenuItem_Click);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 326);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.res_nav_text);
            this.Controls.Add(this.res_state);
            this.Controls.Add(this.viewlist);
            this.Controls.Add(this.load);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TcgUpgrade";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.ListBox viewlist;
        private System.Windows.Forms.Label res_state;
        private System.Windows.Forms.Label res_nav_text;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exit_ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem js_Compress_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MerGerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem post_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem open_file_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem header_StripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notepad_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem note_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hebin_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem about_TcgUpgradeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cont_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem load2_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drop_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem had_upload_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem is_upload_ToolStripMenuItem;
    }
}

