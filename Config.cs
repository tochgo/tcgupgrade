/**
 *   TOCHGO.COM 版权所有
 *   http://www.tochgo.com/tool/tcgupgrade/
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace TcgUpgrade
{
    public class Config
    {
        private Hashtable j_data;
        private string j_gradename = "upgrade.config";//列表文件名
        private string j_Connectors = "-";

        public Config()
        {
            this._init(System.Windows.Forms.Application.StartupPath + "/config.ini");
        }

        public Config(string path)
        { 
            this._init(path);
        }

        public void _init(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            j_data = new Hashtable();
            while(sr.Peek()>=0)
            {
                string str = sr.ReadLine();
                if(str.IndexOf("=")>0)
                {
                    string[] d = str.Split('=');
                    if(d.Length==2)
                    j_data.Add(d[0], d[1]);
                }
            }
            sr.Dispose();

            if (this.get("gradename") != null && this.get("gradename") != "")
                j_gradename = this.get("gradename");
        }

        public string gradename
        {
            get { return j_gradename; }
        }

        public string Connectors
        {
            get { return j_Connectors; }
        }

        public string get(string q)
        {
            if (j_data.ContainsKey(q))
                return j_data[q].ToString();
            else
                return "";
        }

        public string webpath
        {
            get { return j_data["webpath"].ToString(); }
        }

        public string ip
        {
            get { return j_data["ip"].ToString(); }
        }

        public string user
        {
            get { return j_data["user"].ToString(); }
        }

        public string pass
        {
            get { return j_data["pass"].ToString(); }
        }

        public int port
        {
            get { return int.Parse(j_data["port"].ToString()); }
        }

        public string remotepath
        {
            get { return j_data["remotepath"].ToString(); }
        }
    }
}
