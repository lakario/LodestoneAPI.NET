using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LodestoneApi.Internal.Utils
{
    internal static class HttpUtilities
    {
        public static string GetUrl(string url)
        {
            var req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.AllowAutoRedirect = false;
            req.Method = WebRequestMethods.Http.Get;

            WebResponse rsp;
            try
            {
                rsp = req.GetResponse();
                var rst = rsp.GetResponseStream();
                var rdr = new StreamReader(rst);
                var str = rdr.ReadToEnd();
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
