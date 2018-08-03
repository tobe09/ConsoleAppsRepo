using System;
using TobeConsolePractise.IntegrationService;

namespace TobeConsolePractise.WebServices
{
    class IntegrationJavaSoap
    {
        public static void Run()
        {
            TestJavaSoapWebService();
        }

        private static async void TestJavaSoapWebService()
        {
            IntegrationSoap port = new IntegrationSoapClient();
            var request = new fundTransferAdviceCreditRequest();
            var response = await port.fundTransferAdviceDcSubmitAsync(request);
            Console.WriteLine(response.responseCode);
        }
    }
}
