using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Utils
{
    public class HttpUtil
    {
        /// <summary>
        /// 请求一个url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HttpWebResponse GetResponseByUrl(string url)
        {

            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ProtocolVersion = new Version(1, 1);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return response;
        }
    }
}
