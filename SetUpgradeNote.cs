/**
 *   TOCHGO.COM ��Ȩ����
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
    /// ����Ѿ��ϴ�
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

            //����include��ǩ
            foreach (XmlNode xnl in element.GetElementsByTagName("include"))
            {
                if (xnl.Attributes["type"] != null && xnl.Attributes["type"].Value == "list")
                {
                    this._setNote(conf.webpath + "/" + xnl.Attributes["file"].Value);
                }
            }

            //����item��ǩ
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
                    //����ע��
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
        /// ��ǳɹ�����
        /// </summary>
        public int count
        {
            get { return j_count; }
        }
    }
}
