using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.single
{
    public class MySingle
    {
        public string reStr {
            set { value = "初始化"; }
            get { return "asd"; }
        }
        public void SetStr(string Str)
        {
            this.reStr = Str;
        }


    }
}
