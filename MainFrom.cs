/**
 *   TOCHGO.COM 版权所有
 *   http://www.tochgo.com/tool/tcgupgrade/
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace TcgUpgrade
{
    public partial class MainFrom : Form
    {
        private Config conf;
        private LoadConf lconf;
        private bool isLoaded = false;
        public MainFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.post_ToolStripMenuItem_Click(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.load_ini();
        }

        /// <summary>
        /// 载入
        /// </summary>
        private void load_ini()
        {
            viewlist.Items.Clear();
            conf = new Config();

            lconf = new LoadConf(conf);

            this._setMenu();

            foreach (ItemInfo info in lconf.item)
            {
                viewlist.Items.Add(info.path);
            }


            isLoaded = true;
        }

        /// <summary>
        /// 设置状态栏
        /// </summary>
        private void _setMenu()
        { 
            res_state.Text = string.Format("0/{0}",lconf.item.Count);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this._merger_file();
        }

        /// <summary>
        /// 压缩
        /// </summary>
        private void _merger_file()
        {
            this.load_ini();

            foreach (ItemInfo info in lconf.item)
            {
                string newpath = "";
                string fpath = "";
                if (info.type == "css")
                    newpath = new CssCompiler(conf.webpath + "/" + info.path).tmppath();
                else if (info.type == "js")
                {
                    newpath = new JsCompiler(conf.webpath + "/" + info.path).tmppath();

                    System.IO.StreamReader sr = new System.IO.StreamReader(newpath, Encoding.Default);
                    string str = sr.ReadToEnd();
                    sr.Dispose();

                    fpath = conf.webpath + "/" + info.path.Substring(0, info.path.LastIndexOf(".")) + ".min.js";
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fpath, false, Encoding.Default);
                    sw.Write(str);
                    sw.Dispose();

                    new Compiler().clear();
                }

                viewlist.Items.Add(info.path + " " + fpath.Substring(fpath.LastIndexOf("/") + 1));
            }
        }

        private void merger_Click(object sender, EventArgs e)
        {
            this.merger_more_files();
        }

        private void MerGerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.merger_more_files();
        }

        /// <summary>
        /// 文件合并
        /// </summary>
        private void merger_more_files()
        {
            if (!isLoaded)
                this.load_ini();

            string str = "";
            string filename = "";
                
            int do_flag_i = 0;
            foreach (ItemInfo info in lconf.item)
            {

                if (do_flag_i > 0)
                {
                    str += "\r\n";
                }

                str += "/*"+info.path+" */\r\n";
                System.IO.StreamReader sr = new System.IO.StreamReader(conf.webpath+"/"+info.path, Encoding.Default);
                str += sr.ReadToEnd();
                sr.Dispose();

                if (do_flag_i > 0)
                {
                    filename += conf.Connectors + info.path.Substring(info.path.LastIndexOf("/") + 1);
                }
                else
                { 
                    filename = lconf.item[0].path;
                }
                
                do_flag_i++;
            }
            if (!System.IO.File.Exists(conf.webpath + "/" + filename))
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(conf.webpath + "/" + filename, false, Encoding.Default);
                sw.Write(str);
                sw.Dispose();
                res_nav_text.Text = "合并成功";
                viewlist.Items.Add(filename);

                ItemInfo info = new ItemInfo();
                info.type = lconf.item[0].type;
                info.path = filename;
                info.bak = lconf.item[0].bak;
                lconf.add(info);

                res_state.Text = string.Format("0/{0}", lconf.item.Count);
            }
            else
            {
                res_nav_text.Text = "文件已经存在 " + filename;
            }
        }

        private void js_Compress_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._merger_file();
        }


        /// <summary>
        /// 推送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void post_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLoaded)
                this.load_ini();

            res_nav_text.Text = "请稍候...";
            Application.DoEvents();
            Upload up = new Upload(conf.webpath, conf.ip, conf.port, conf.user, conf.pass, conf.remotepath);
            int num = 0;
            res_nav_text.Text = "正在准备上传";
            this.Text = "上传中..." + this.Text.Replace("上传完成...","");
            bool isErr = false;
            int i = 0;
            foreach (ItemInfo info in lconf.item)
            {
                if (info.bak == "true")
                {
                    res_nav_text.Text = "正在备份...";
                    Application.DoEvents();
                    if (up.rename(info) == 1)
                    {
                        res_nav_text.Text = "备份成功";
                        Application.DoEvents();
                    }
                    else
                    {
                        res_nav_text.Text = up.msg;
                        Application.DoEvents();
                    }
                }

                if (up.upload(info) == 1)
                {
                    num++;
                    viewlist.Items.Remove(info.path);
                    res_state.Text = string.Format("{0}/{1}", num, lconf.item.Count);
                    res_nav_text.Text = "上传中...";
                    Application.DoEvents();
                }
                else
                {
                    //res_nav_text.Text = up.msg;
                    viewlist.Items[i] += " " + up.msg;
                    Application.DoEvents();
                    isErr = true;
                }

                up.recordLog(info.ToString, conf.webpath + "/" + conf.get("logfile"));
                i++;
            }



            if (!isErr)
            {
                res_nav_text.Text = string.Format("成功{0}条", num);
                this.Text = "上传完成..." + this.Text.Replace("上传中...","");
            }
            else
                res_nav_text.Text = "失败";
        }

        private void exit_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void open_file_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conf = new Config();

            //打开并定位文件
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + conf.webpath + "\\" + conf.gradename;
            System.Diagnostics.Process.Start(psi);
        }

        private void header_StripMenuItem_Click(object sender, EventArgs e)
        {
            res_nav_text.Text = "待开发";
        }

        private void notepad_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conf = new Config();

            System.Diagnostics.Process.Start(@"C:\Program Files\Notepad++\notepad++.exe", conf.webpath + "\\" + conf.gradename);
        }

        private void note_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conf = new Config();

            System.Diagnostics.Process.Start(@"notepad.exe", conf.webpath + "\\" + conf.gradename);
        }

        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._drop_view_list();
        }

        private void about_TcgUpgradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().Show();
        }

        private void load2_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.load_ini();
        }

        private void drop_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._drop_view_list();
        }

        private void _drop_view_list()
        { 
            if (viewlist.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择");
                return;
            }

            ArrayList remove_list = new ArrayList();

            for (int i = 0; i < viewlist.SelectedItems.Count; i++)
            {
                for (int j = 0; j < lconf.item.Count; j++)
                {
                    if (viewlist.SelectedItems[i].ToString() == lconf.item[j].path)
                    {
                        lconf.item.Remove(lconf.item[j]);
                        remove_list.Add(viewlist.SelectedItems[i]);
                    }
                }
            }

            foreach (object k in remove_list)
            {
                viewlist.Items.Remove(k);
            }
            
            this._setMenu();
        }

        private void had_upload_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                SetUpgradeNote su = new SetUpgradeNote(conf);
                res_nav_text.Text = "已经标记" + su.count + "处";
            }
            else {
                MessageBox.Show("还没有载入配置文件.");
            }
        }

        private void is_upload_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                SetUpgradeNote su = new SetUpgradeNote(conf);
                res_nav_text.Text = "已经标记" + su.count + "处";
            }
            else
            {
                MessageBox.Show("还没有载入配置文件.");
            }
        }

        private void hebin_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Hebin().Show();
        }

    }
}