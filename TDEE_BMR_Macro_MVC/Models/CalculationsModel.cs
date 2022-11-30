using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json.Linq;
using RestSharp;
using Method = RestSharp.Method;

namespace TDEE_BMR_Macro_MVC.Models
{
    public class CalculationsModel
    {
        const double lbToKg = 2.205; // Divide by
        const double inToCm = 2.54; // Mult by

        public CalculationsModel()
        {

        }

        public void GetApiTDEE(UserModel user)
        {
            var key = File.ReadAllText("appsettings.json");
            var APIKey = JObject.Parse(key).GetValue("X-RapidAPI-Key").ToString();
            var APIHost = JObject.Parse(key).GetValue("X-RapidAPI-Host").ToString();

            //TDEE
            string urlTDEE = ($"https://mega-fitness-calculator1.p.rapidapi.com/tdee?weight={(user.Weight/lbToKg).ToString()}&height={(user.Height*inToCm).ToString()}&activitylevel={user.ActivityLevel}&age={user.Age.ToString()}&gender={user.Gender}");

            var client = new RestClient(urlTDEE);
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-RapidAPI-Key", APIKey);
            request.AddHeader("X-RapidAPI-Host", APIHost);
            IRestResponse response = client.Execute(request);
            user.TDEE = double.Parse(JObject.Parse(response.Content)["info"]["tdee"].ToString());
        }
        public void GetApiBMR(UserModel user)
        {
            var key = File.ReadAllText("appsettings.json");
            var APIKey = JObject.Parse(key).GetValue("X-RapidAPI-Key").ToString();
            var APIHost = JObject.Parse(key).GetValue("X-RapidAPI-Host").ToString();

            //BMR
            string urlBMR = $"https://mega-fitness-calculator1.p.rapidapi.com/bmr?weight={(user.Weight/lbToKg).ToString()}&height={(user.Height*inToCm).ToString()}&age={user.Age}&gender={user.Gender}";
            var client = new RestClient(urlBMR);
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-RapidAPI-Key", APIKey);
            request.AddHeader("X-RapidAPI-Host", APIHost);
            IRestResponse response = client.Execute(request);
            user.BMR = double.Parse(JObject.Parse(response.Content)["info"]["bmr"].ToString());
        }
    }
}
