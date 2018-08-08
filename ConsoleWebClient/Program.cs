using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleWebClient
{
    public class DataObject
    {
        public string Name { get; set; }
    }
    class Program
    {
        private const string URL = "http://smsp.myoperator.co/api/postsms.php";
        private const string URL1 = "http://sms.quarkstech.com/api/postsms.php";
        private const string xmlString = "";
        static  void Main(string[] args)
        {
            string filename = "SMSFile.xml";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            string xmlString = File.ReadAllText(filePath);
            
            var data = postXMLData(URL1, xmlString);
            var str = data;
        }

        private static string postXMLData(string destinationUrl, string requestXml)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes;
            bytes = Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;
        }
        
    }
}
