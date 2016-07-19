using System;
using System.Security.Cryptography.X509Certificates;

namespace AzureClassicVMIntegration
{
    public class CertificateStore
    {
        public static X509Certificate GetManagementCertificateFromStore(string certificateThumbprint)
        {
            X509Store certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            certStore.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certCollection =
                certStore.Certificates.Find(X509FindType.FindByThumbprint, certificateThumbprint, false);

            certStore.Close();

            if (certCollection.Count == 0)
            {
                throw new InvalidOperationException("The certificate with thumbprint {0} was not found in the My store of the current user");
            }

            return certCollection[0];
        }
    }
}
