using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LodestoneApi.Internal.Utils
{
    internal static class StringExtensions
    {
        public static string CleanText(string text)
        {
            return HttpUtility.HtmlDecode(text.Trim());
        }
    }
}
