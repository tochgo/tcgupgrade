/**
 *   TOCHGO.COM 版权所有
 *   http://www.tochgo.com/tool/tcgupgrade/
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TcgUpgrade
{
    public class CssCompiler : Compiler
    {
        public CssCompiler(string path)
        {
            this.delegateFunction = new DelegateFunction(css);
            base.compiler(path);
        }

        public void css(string str)
        {
            j_tempstr = Regex.Replace(j_tempstr, @"/\*(.|\r\n)*?\*\/", "");//去注释
            //j_tempstr = Regex.Replace(j_tempstr,"background-image", "background");
            j_tempstr = Regex.Replace(j_tempstr, @"\s*([\{\}\:\;\,])\s*", "$1");

            j_tempstr = Regex.Replace(j_tempstr,@"\,[\s\.\#\d]*\{","{"); //容错处理
            j_tempstr = Regex.Replace(j_tempstr,@";\s*;",";"); //清除连续分号

            //j_tempstr = Regex.Replace(j_tempstr, "\r\n", "");
            //j_tempstr = Regex.Replace(j_tempstr, ";( )+", ";");
            //j_tempstr = Regex.Replace(j_tempstr, "{( )+", "{");
            //j_tempstr = Regex.Replace(j_tempstr, "( )+}", "}");

            ///添加更多规则
            ///
            j_tempstr = j_tempstr.Trim();

            

        }


    }
}
