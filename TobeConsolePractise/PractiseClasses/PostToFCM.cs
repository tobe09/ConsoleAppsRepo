using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace TobeConsolePractise
{
    class PostToFCM
    {
        public const string API_KEY = "AIzaSyCOS1_LmnhfEQBN2Ss9q1bi9hTCuGaOuu4";
        public string TOPIC_KEY = "news";
        public const string APP_ID = "1:1002771037612:android:4f145aa1e985c877";
        public const string PROJECT_ID = "androidpractisefcm";
        public const string fcmUrl = "https://fcm.googleapis.com/v1/projects/" + PROJECT_ID + "/messages:send HTTP/1.1";
        public const string fcmUrlLegacy = "https://fcm.googleapis.com/fcm/send";

        public object Post(string DEVICE_KEY)
        {
            object status = false;

            //old GCM style
            object messageLegacy = new
            {
                to = DEVICE_KEY,
                data = new { message = "Hello xamarin android practise" }
            };

            //new FCM style 
            object message = new
            {
                message = new
                {
                    token = DEVICE_KEY,         //for single device
                                                //topic: "rats"                  //for single topic
                                                //"condition": "'rats' in topics && ('dogs' in topics || 'cats' in topics)"  //for combination of topics (ie, 'rats' and 'dogs' or 'rats' and 'cats'
                    notification = new { body = "Hello xamarin from device itself", title = "Device send" }
                }
            };

            //legacy style
            JObject jData = new JObject();
            JObject jLegacyData = new JObject();
            jData.Add("message", "hello xamarin android practise, sent from android");
            jLegacyData.Add("data", jData);
            jLegacyData.Add("to", DEVICE_KEY);

            //new style
            JObject jsonData = new JObject();
            JObject jNotification = new JObject();
            jNotification.Add("title", "Device Send");
            jNotification.Add("body", "Hello xamarin from device itself");
            jsonData.Add("token", DEVICE_KEY);
            jsonData.Add("notification", jNotification);
            JObject jValues = new JObject();
            jValues.Add("message", jsonData);

            JObject jSentValues = JObject.FromObject(message);

            var url = new Uri(fcmUrl);
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    ////legacy style
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + API_KEY);

                    //current style
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + API_KEY);

                    //client.DefaultRequestHeaders.Add("Authorization", "key=" + API_KEY);        //legacy
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + API_KEY);     //current

                    client.PostAsync(url,
                        new StringContent(jSentValues.ToString(), Encoding.Default, "application/json"))
                            .ContinueWith(response =>
                            {
                                try
                                {
                                    var result = response.Result;
                                    JObject val = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                                    string name = val["name"].ToString();
                                    status = val;
                                    Console.WriteLine("Success");
                                    Console.Error.WriteLine("No Error");
                                }
                                catch (Exception ex)
                                {
                                    string msg = ex.Message;
                                }
                            });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to send FCM message:");
                Console.Error.WriteLine(e.StackTrace);
                status = false;
            }

            return status;
        }

        public static void Run(string clientId)
        {
            new PostToFCM().Post(clientId);
        }
    }
}
