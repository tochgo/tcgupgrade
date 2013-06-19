/**
 *   TOCHGO.COM ∞Ê»®À˘”–
 *   http://www.tochgo.com/tool/tcgupgrade/
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TcgUpgrade
{
    public class ItemInfo
    {
        private string j_path;
        private string j_type;
        private string j_bak;
        private string j_str;
        private string j_defpath;

        public string path
        {
            get { return j_path; }
            set { j_path = value; }
        }

        public string defpath
        {
            get { return j_defpath; }
            set { j_defpath = value; }
        }

        public string type
        {
            get { return j_type; }
            set { j_type = value; }
        }

        public string bak
        {
            get { return j_bak; }
            set { j_bak = value; }
        }

        public string filename() {
            return Regex.Match(j_path, "[^/\\\\]+$").Value;
        }

        public new string ToString
        {
            get { return j_str; }
            set { j_str = value; }
        }
    }
}
