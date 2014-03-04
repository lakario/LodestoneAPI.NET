using System.IO;
using System.Net;

namespace LodestoneApi.Internal.Utils
{
    internal static class HttpUtilities
    {
        public static string GetUrl(string url)
        {
            var req = WebRequest.Create(url) as HttpWebRequest;
            req.AllowAutoRedirect = false;
            req.Method = WebRequestMethods.Http.Get;

            WebResponse rsp;
            try
            {
                rsp = req.GetResponse();
                Stream rst = rsp.GetResponseStream();
                var rdr = new StreamReader(rst);
                string str = rdr.ReadToEnd();
                rdr.Close();
                rst.Close();
                return str;
            }
            catch (WebException e)
            {
                throw e;
            }
        }
    }
}