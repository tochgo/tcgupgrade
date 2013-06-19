/**
 *   TOCHGO.COM ��Ȩ����
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
            j_tempstr = Regex.Replace(j_tempstr, @"/\*(.|\r\n)*?\*\/", "");//ȥע��
            //j_tempstr = Regex.Replace(j_tempstr,"background-image", "background");
            j_tempstr = Regex.Replace(j_tempstr, @"\s*([\{\}\:\;\,])\s*", "$1");

            j_tempstr = Regex.Replace(j_tempstr,@"\,[\s\.\#\d]*\{","{"); //�ݴ���
            j_tempstr = Regex.Replace(j_tempstr,@";\s*;",";"); //��������ֺ�

            //j_tempstr = Regex.Replace(j_tempstr, "\r\n", "");
            //j_tempstr = Regex.Replace(j_tempstr, ";( )+", ";");
            //j_tempstr = Regex.Replace(j_tempstr, "{( )+", "{");
            //j_tempstr = Regex.Replace(j_tempstr, "( )+}", "}");

            ///��Ӹ������
            ///
            j_tempstr = j_tempstr.Trim();

            

        }


    }
}
