/**
 *   TOCHGO.COM 版权所有
 *   http://www.tochgo.com/tool/tcgupgrade/
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;

namespace TcgUpgrade
{
    public class LoadConf
    {
        private List<ItemInfo> j_item;
        private string disbakext;
        public LoadConf(Config conf)
        {
            disbakext = conf.get("disbakext");
            this._LoadConf(conf.webpath);
        }

        /// <summary>
        /// 初始化加载配置
        /// </summary>
        /// <param name="path"></param>
        private void _LoadConf(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path + "/"+new Config().gradename);

            XmlElement element = doc.DocumentElement;

            j_item = new List<ItemInfo>();
            foreach (XmlNode xnl in element.GetElementsByTagName("item"))
            {
                ItemInfo info = new ItemInfo();
                if (xnl.Attributes["type"] != null)
                    info.type = xnl.Attributes["type"].Value;

                info.ToString = xnl.OuterXml;
                string jpath = xnl.InnerText;
                string filename = Regex.Match(jpath, "[^/\\\\]+$").Value;

                this._bak(xnl, filename, ref info);

                if (!Regex.IsMatch(filename, @"\*"))
                {
                    info.path = jpath.Trim();
                    j_item.Add(info);
                }
                else
                {
                    string filepath = jpath.Replace(filename, "");
                    DirectoryInfo TheFolder = new DirectoryInfo(path + "/" + filepath + "/");
                    foreach (FileInfo f in TheFolder.GetFiles(filename))
                    {
                        ItemInfo info1 = new ItemInfo();
                        info1.type = info.type;
                        info1.bak = info.bak;
                        info1.path = filepath + f.Name;
                        j_item.Add(info1);
                    }
                }
            }

            //加载include标签
            foreach (XmlNode xnl in element.GetElementsByTagName("include"))
            {
                if (xnl.Attributes["type"] != null && xnl.Attributes["type"].Value == "list")
                {
                    ItemInfo tplinfo = new ItemInfo();
                    if (xnl.Attributes["bak"] != null)
                        tplinfo.bak = xnl.Attributes["bak"].Value;

                    if (xnl.Attributes["defpath"] != null)
                        tplinfo.defpath = xnl.Attributes["defpath"].Value.Trim();

                    this._load_ini_file(path + "/" + xnl.Attributes["file"].Value, tplinfo);
                }
            }

            //泛加载
            List<ItemInfo> j_del_item = new List<ItemInfo>();
            for (int i = 0; i < j_item.Count;i++)
            {
                ItemInfo info = j_item[i];
                if (Regex.IsMatch(info.path, @"\*"))
                {
                    string filename = this.get_file_name(info.path);
                    string filepath = this.get_file_path(info.path);
                    DirectoryInfo TheFolder = new DirectoryInfo(path + "/" + filepath);

                    foreach (FileInfo f in TheFolder.GetFiles(filename))
                    {
                        ItemInfo info1 = new ItemInfo();
                        info1.type = info.type;
                        info1.bak = info.bak;
                        info1.path = filepath + f.Name;
                        j_item.Add(info1);
                    }

                    j_del_item.Add(info);
                }
            }

            for (int i = 0; i < j_del_item.Count; i++)
            {
                j_item.Remove(j_del_item[i]);
            }

            //*强制文件类型*
            this.setFileType();
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string get_file_path(string p)
        {
            int index = p.LastIndexOf("/");
            if (index > 0)
                return p.Substring(0, index+1);
            else
                return "";
        }

        /// <summary>
        /// 读取文件名
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string get_file_name(string p)
        {
            int index = p.LastIndexOf("/");
            return p.Substring(index+1);
        }

        private void _load_ini_file(string path,ItemInfo tplinfo)
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string data = sr.ReadToEnd();
                sr.Dispose();

                string[] str = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in str)
                {
                    //跳过注释
                    if (Regex.IsMatch(item.Trim(), @"^\S?[#;']"))
                    {
                        continue;
                    }
                    ItemInfo info = new ItemInfo();
                    if (tplinfo.defpath != null)
                        info.path = tplinfo.defpath + "/";

                    info.path += item.Trim();
                    info.bak = tplinfo.bak;
                    j_item.Add(info);
                }
            }
        }

        private void _bak(XmlNode xnl, string filename, ref ItemInfo info)
        {
            if (xnl.Attributes["bak"] != null)
                info.bak = xnl.Attributes["bak"].Value;
            else
            {
                ///强制不备份
                if (Regex.IsMatch(filename, @"\.(" + disbakext + ")", RegexOptions.IgnoreCase))
                    info.bak = "false";
                else
                    info.bak = "true";
            }
        }

        /// <summary>
        /// 强制设置文件类型
        /// </summary>
        public void setFileType()
        {
            for (int i = 0; i < j_item.Count; i++)
            {
                if (string.IsNullOrEmpty(j_item[i].type))
                {
                    j_item[i].type = this._setType(j_item[i].path);
                }
            }
        }

        private string _setType(string path)
        {
            System.Collections.Hashtable dict = new System.Collections.Hashtable();
            dict.Add("css", "css");
            dict.Add("js", "js");

            string ext = path.Substring(path.LastIndexOf(".")+1);

            if (dict.ContainsKey(ext))
                return dict[ext].ToString();
            else
                return "";
        }

        public void add(ItemInfo info)
        {
            j_item.Add(info);
        }

        public List<ItemInfo> item
        {
            get { return j_item; }
        }
    }
}
