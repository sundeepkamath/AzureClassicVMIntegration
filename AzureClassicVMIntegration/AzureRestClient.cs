using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace AzureClassicVMIntegration
{
    public class AzureRestClient
    {
        public static string executeRequest(string url, string apiVersion, X509Certificate clientCertificate)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.Headers.Add("x-ms-version", apiVersion);
            request.ContentType = "application/xml";
            request.ClientCertificates.Add(clientCertificate);

            WebResponse response = request.GetResponse();
            string responseContent = string.Empty;

            using (Stream responseStream = response.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream))
                {
                    responseContent = sr.ReadToEnd();
                }

            return responseContent;
        }
    }
}
