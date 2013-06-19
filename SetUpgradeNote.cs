/**
 *   TOCHGO.COM 版权所有
 *   http://www.tochgo.com/tool/tcgupgrade/
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace TcgUpgrade
{
    /// <summary>
    /// 标记已经上传
    /// </summary>
    class SetUpgradeNote
    {
        private int j_count;
        public SetUpgradeNote(Config conf)
        {
            j_count = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(conf.webpath + "/" + conf.gradename);

            XmlElement element = doc.DocumentElement;

            //加载include标签
            foreach (XmlNode xnl in element.GetElementsByTagName("include"))
            {
                if (xnl.Attributes["type"] != null && xnl.Attributes["type"].Value == "list")
                {
                    this._setNote(conf.webpath + "/" + xnl.Attributes["file"].Value);
                }
            }

            //加载item标签
            foreach (XmlNode xnl in element.GetElementsByTagName("item"))
            {
                xnl.InnerXml = "<!--"+xnl.InnerText.Trim()+"-->";
                j_count++;
            }
            doc.Save(conf.webpath + "/" + conf.gradename);
        }

        private void _setNote(string path)
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string data = sr.ReadToEnd();
                sr.Dispose();

                string[] str = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string bakdata = "";
                foreach (string item in str)
                {
                    //跳过注释
                    if (!Regex.IsMatch(item.Trim(), @"^\S?[#;]"))
                    {
                        bakdata += "; "+item;
                        j_count++;
                    }
                    else
                    {
                        bakdata += item;
                    }

                    bakdata += "\r\n";
                }

                StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
                sw.Write(bakdata);
                sw.Dispose();
            }
        }

        /// <summary>
        /// 标记成功条数
        /// </summary>
        public int count
        {
            get { return j_count; }
        }
    }
}
