using Newtonsoft.Json;
using ScouterTool.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ScouterTool.APIs
{
    public static class ESIAPIs
    {
        //取角色名
        public static string SearchCharacter(string strUserName)
        {

            //请求
            string strReqPath = string.Format("https://esi.evepc.163.com/latest/search/?categories=character&datasource=serenity&language=zh&search={0}&strict=true", strUserName);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {

                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                //JsonTextReader jsonReader = new JsonTextReader(sr);

                XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(sr.ReadToEnd());
                XmlNode rootNode = xmlDoc.SelectSingleNode("character");

                return rootNode.InnerText;
            }
        }
        //去星系名
        public static string SearchSystem(string strSolarSystem)
        {

            //请求
            string strReqPath = string.Format("https://esi.evepc.163.com/latest/search/?categories=solar_system&datasource=serenity&language==zh&search={0}&strict=true", strSolarSystem);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {

                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                //JsonTextReader jsonReader = new JsonTextReader(sr);

                XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(sr.ReadToEnd());
                XmlNode rootNode = xmlDoc.SelectSingleNode("character");

                return rootNode.InnerText;
            }
        }
        //批量列表取得ID
        public static clsJsonIDs SearchBulkToIDs(List<string> lstNames)
        {

            //请求
            string strReqPath = string.Format("https://esi.evepc.163.com/latest/universe/ids/?datasource=serenity&language=zh");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strReqPath);
            request.Method = "POST";
            request.ContentType = "application/json";

            string JsonBody = JsonConvert.SerializeObject(lstNames);

            using (var postStream = new StreamWriter(request.GetRequestStream()))
            {
                postStream.Write(JsonBody);
            }

            //request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {

                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                //JsonTextReader jsonReader = new JsonTextReader(sr);
                string strResult = sr.ReadToEnd();
                clsJsonIDs objIDs = JsonConvert.DeserializeObject<clsJsonIDs>(strResult);
            
                return objIDs;
            }
        }


    }
}
