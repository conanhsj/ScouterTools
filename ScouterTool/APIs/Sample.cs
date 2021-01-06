using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScouterTool.APIs
{
    class Sample
    {
        private T PostDataViaHttpWebRequest<T>(string baseUrl,
                IReadOnlyDictionary<string, string> headers,
                IReadOnlyDictionary<string, string> urlParas,
                string requestBody = null)
        {
            var resuleJson = string.Empty;
            try
            {
                var apiUrl = baseUrl;

                //if (urlParas != null)
                //    urlParas.ForEach(p =>
                //    {
                //        if (apiUrl.IndexOf("{" + p.Key + "}") > -1)
                //        {
                //            apiUrl = apiUrl.Replace("{" + p.Key + "}", p.Value);
                //        }
                //        else
                //        {
                //            apiUrl += string.Format("{0}{1}={2}", apiUrl.Contains("?") ? "&" : "?", p.Key, p.Value);
                //        }
                //    }
                //);

                var req = (HttpWebRequest)WebRequest.Create(apiUrl);
                req.Method = "POST";
                req.ContentType = "application/json"; //Defalt

                //if (!requestBody.IsNullOrEmpty())
                //{
                //    using (var postStream = new StreamWriter(req.GetRequestStream()))
                //    {
                //        postStream.Write(requestBody);
                //    }
                //}

                if (headers != null)
                {
                    if (headers.Keys.Any(p => p.ToLower() == "content-type"))
                        req.ContentType = headers.SingleOrDefault(p => p.Key.ToLower() == "content-type").Value;
                    if (headers.Keys.Any(p => p.ToLower() == "accept"))
                        req.Accept = headers.SingleOrDefault(p => p.Key.ToLower() == "accept").Value;
                }

                var response = (HttpWebResponse)req.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                    {
                        resuleJson = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(resuleJson);
        }
    }
}
