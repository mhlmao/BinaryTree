using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BinaryTree
{
    public class ServiceConector
    {
        private const string BaseURL = "http://localhost:60959/";
        private const string Method = "api/Tree";
        private WebRequest request = WebRequest.Create(BaseURL + Method);

        public void Request()
        {
            
            request.Method = "GET";

            HttpWebResponse response = null;
            response = (HttpWebResponse) request.GetResponse();

            string data = null;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                data = sr.ReadToEnd();
                sr.Close();
            }

        }

        public void Post(string data)
        {
            request.Method = "POST";
            request.ContentType = "application/json";


            using (var stramWriter = new StreamWriter(request.GetRequestStream()))
            {
                stramWriter.Write(data);
                stramWriter.Flush();
                stramWriter.Close();

                var httpResponse = (HttpWebResponse)request.GetResponse();
            }
        }

    }
}
