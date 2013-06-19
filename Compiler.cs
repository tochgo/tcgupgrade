/**
 *   TOCHGO.COM ��Ȩ����
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
        /// �������ݽṹ
        /// </summary>
        /// <param name="str"></param>
        public delegate void DelegateFunction(string strFuncName);

        private DelegateFunction j_delegateFunction = null;

        /// <summary>
        /// ��������
        /// </summary>
        public DelegateFunction delegateFunction
        {
            get { return j_delegateFunction; }
            set { j_delegateFunction = value;}
        }


        protected string j_temppath = System.Windows.Forms.Application.StartupPath + "/compiler.tmp";
        
        /// <summary>
        /// ��ʱ���������
        /// </summary>
        protected string j_tempstr;

        /// <summary>
        /// �洢
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
        /// ɾ����ʱ�ļ�
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
