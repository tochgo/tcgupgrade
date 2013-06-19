/**
 *   TOCHGO.COM 版权所有
 *   http://www.tochgo.com/tool/tcgupgrade/
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace TcgUpgrade
{
    public class Upload
    {
        private string j_webpath, j_ip, j_user, j_pass, j_remotepath,j_msg;
        private int j_port;
        private FtpWebRequest ftprequest;
        private string uploadurl;
        public Upload(string webpath, string ip, int port, string user, string pass, string remotepath)
        {
            j_webpath = webpath;
            j_ip = ip;
            j_user = user;
            j_pass = pass;
            j_port = port;
            j_remotepath = remotepath;

            string uri = "ftp://{0}:{1}/{2}/";

            uploadurl = string.Format(uri, j_ip, j_port, j_remotepath);
            
        }

        /// <summary>
        /// 外网备份重命名
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int rename(ItemInfo info) 
        {
            FtpWebRequest ftprequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(uploadurl+info.path));
            ftprequest.Credentials = new NetworkCredential(j_user, j_pass);
            ftprequest.KeepAlive = false;
            ftprequest.Method = WebRequestMethods.Ftp.Rename;
            ftprequest.RenameTo = info.filename()+"."+DateTime.Now.ToString("yyyyMMdd")+".bak";
            ftprequest.UseBinary = true;
            ftprequest.UsePassive = false;
            try
            {
                FtpWebResponse response = (FtpWebResponse)ftprequest.GetResponse();
                Stream strm = response.GetResponseStream();
                strm.Close();
                response.Close();

                return 1;
            }
            catch (Exception ex)
            {
                j_msg = ex.Message;
            }
            return 0;
        }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg
        {
            get { return j_msg; }
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int upload(ItemInfo info)
        {
            ftprequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(uploadurl+info.path));
            ftprequest.Credentials = new NetworkCredential(j_user, j_pass);
            ftprequest.KeepAlive = false;
            ftprequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftprequest.UseBinary = true;
            ftprequest.UsePassive = false;


            FileInfo file = new FileInfo(j_webpath+"/"+info.path);
            if (info.type == "css" || info.type == "js")
            {
                string newpath = "";
                if (info.type == "css")
                    newpath = new CssCompiler(j_webpath + "/" + info.path).tmppath();
                else if (info.type == "js")
                    newpath = new JsCompiler(j_webpath + "/" + info.path).tmppath();

                file = new FileInfo(newpath);
            }

            if (!file.Exists)
            {
                j_msg = "没有找到文件";
                return 0;
            }

            FileStream fs = file.OpenRead();
            ftprequest.ContentLength = file.Length;
            
            int contentLen;
            try
            {
                Stream strm = ftprequest.GetRequestStream();

                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                
                strm.Close();
                fs.Close();

                WebResponse res = ftprequest.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream());
                j_msg = sr.ReadToEnd();

                new Compiler().clear();
                return 1;
                
            }
            catch (Exception ex)
            {
                new Compiler().clear();
                j_msg = ex.Message;
            }


            return 0;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="str"></param>
        /// <param name="logpath"></param>
        public void recordLog(string str,string logpath)
        {
            logpath += "/"+DateTime.Now.ToString("yyyMMdd") + ".log";
            StreamWriter sw = new StreamWriter(logpath,true,Encoding.Default);
            sw.WriteLine(str+"      "+DateTime.Now.ToString()+" "+j_msg);
            sw.Dispose();

        }


        ~Upload()
        { 
            
        }
    }
}
