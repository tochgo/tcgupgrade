/**
 *   TOCHGO.COM 版权所有
 *   http://www.tochgo.com/tool/tcgupgrade/
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TcgUpgrade
{
    public class Compiler
    {
        /// <summary>
        /// 定义数据结构
        /// </summary>
        /// <param name="str"></param>
        public delegate void DelegateFunction(string strFuncName);

        private DelegateFunction j_delegateFunction = null;

        /// <summary>
        /// 定义属性
        /// </summary>
        public DelegateFunction delegateFunction
        {
            get { return j_delegateFunction; }
            set { j_delegateFunction = value;}
        }


        protected string j_temppath = System.Windows.Forms.Application.StartupPath + "/compiler.tmp";
        
        /// <summary>
        /// 临时编译后数据
        /// </summary>
        protected string j_tempstr;

        /// <summary>
        /// 存储
        /// </summary>
        public string tempstr
        {
            get { return j_tempstr; }
            set { j_tempstr = value; }
        }

        public Compiler()
        { 
        
        }

        public void compiler(string path)
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                string str = sr.ReadToEnd();
                sr.Dispose();
                this.tempstr = str;

                this.doCompiler("test");

                StreamWriter sw = new StreamWriter(j_temppath, false, Encoding.Default);
                sw.Write(this.tempstr);
                sw.Dispose();
            }
        }

        public void doCompiler(string funcName)
        {
            if (delegateFunction != null)
            {
                object[] args = { funcName };
                delegateFunction.DynamicInvoke(args);
            }
        }


        public string tmppath()
        {
            return j_temppath;
        }

        /// <summary>
        /// 删除临时文件
        /// </summary>
        public void clear()
        {
            if (j_temppath != null)
            {
                FileInfo file = new FileInfo(j_temppath);
                if (file.Exists)
                    file.Delete();
            }
        }
    }
}
