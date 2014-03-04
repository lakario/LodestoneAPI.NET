namespace LodestoneApi.Models
{
    internal class HtmlPage
    {
        public HtmlPage(string sourceUrl, string sourceHtml)
        {
            SourceUrl = sourceUrl;
            SourceHtml = sourceHtml;
        }

        public HtmlPage()
        {
        }

        protected string SourceUrl { get; private set; }
        protected string SourceHtml { get; private set; }
    }
}