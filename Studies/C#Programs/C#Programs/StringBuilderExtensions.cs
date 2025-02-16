using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Programs
{

    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendLineChainable(this StringBuilder sb, string value)
        {
            return sb.AppendLine(value);
        }

        public static StringBuilder AppendFormatted(this StringBuilder sb, string format, params object[] args)
        {
            return sb.AppendFormat(format, args);
        }
    }
}
