using System;
using System.Configuration;

namespace AzureClassicVMIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            //This would get the client certificate from the certificate store of current user.
            var clientCertificate = CertificateStore.GetManagementCertificateFromStore(
                    ConfigurationManager.AppSettings[Constants.CertificateThumbprint]);

            //This prepares the url for getting the deployment details of classic VM
            string url = string.Format(ConfigurationManager.AppSettings[Constants.ClassicDeploymentDetailsUrl],
                                        ConfigurationManager.AppSettings[Constants.SubscriptionId],
                                        ConfigurationManager.AppSettings[Constants.CloudServiceName]);
            
            //We pass the url along with the API version and the client certificate to get the deployment details.
            //Client certificate is used to authenticate the request.
            string response = AzureRestClient.executeRequest(url,
                                ConfigurationManager.AppSettings[Constants.ApiVersion],
                                clientCertificate);

            Console.WriteLine(response);
        }
    }
}
