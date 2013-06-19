/**
 *   TOCHGO.COM 版权所有
 *   http://www.tochgo.com/tool/tcgupgrade/
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace TcgUpgrade
{
    public class JsCompiler : Compiler
    {
        private string j_path;
        public JsCompiler(string path)
        {
            j_path = path;
            

            //this.delegateFunction = new DelegateFunction(js);
            //base.compiler(path);

            jscompiler();
        }

        private void jscompiler()
        {
            string jscompiler_level = new Config().get("jscompiler_level");
            if (jscompiler_level != null && jscompiler_level != "")
            {
                string javastr = @"java -jar compiler.jar --js {0} --js_output_file {1} --{2} SIMPLE_OPTIMIZATIONS --charset gb2312";
                javastr = string.Format(javastr, j_path, j_temppath, new Config().get("jscompiler_level"));

                // 调用代码
                string[] cmd = new string[] { javastr };

                DoCmd.Cmd(cmd);

                DoCmd.CloseProcess("cmd.exe");
            }
        }

        public void js(string str)
        {

            //代码块注释
            j_tempstr = Regex.Replace(j_tempstr, @"/\*(.|\r\n)*?\*\/", "");//去注释

            //行注释
            j_tempstr = Regex.Replace(j_tempstr, @"[^:';""/]\/\/[\S\s].+?\r\n", "\r\n");

            //j_tempstr = Regex.Replace(j_tempstr, @"}\r\n", "};");

            //去空行
            j_tempstr = Regex.Replace(j_tempstr, @";\s+(\r\n)*", ";");

            j_tempstr = Regex.Replace(j_tempstr, @"(\r\n)*", "");

            //去符号前后空格
            j_tempstr = Regex.Replace(j_tempstr, @"(?<=[\=;<>&\|\{\}])\s+", "");
            j_tempstr = Regex.Replace(j_tempstr, @"\s+(?=[\=;<>&\|\{\}])", "");


            //去tab键
            j_tempstr = Regex.Replace(j_tempstr, @"		", "");

            //去多余的;号
            j_tempstr = Regex.Replace(j_tempstr, @";}", "}");

            

        }
    }
}
