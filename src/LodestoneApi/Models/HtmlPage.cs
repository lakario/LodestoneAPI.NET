using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodestoneApi.Models
{
    internal class HtmlPage
    {
        protected string SourceUrl { get; private set; }
        protected string SourceHtml { get; private set; }

        public HtmlPage(string sourceUrl, string sourceHtml)
        {
            SourceUrl = sourceUrl;
            SourceHtml = sourceHtml;
        }

        public HtmlPage()
        { }
    }
}
