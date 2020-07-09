using RestSharp;

namespace BusBoard.ConsoleApp {
    public class PostcodeApi {
        RestClient Client = new RestClient("http://api.postcodes.io");

        public Coords getCoords(string postcode) {
            var request = new RestRequest("postcodes/{postcode}", Method.GET);
            request.AddUrlSegment("postcode", postcode);
            var result = Client.Execute<PostcodeResults>(request).Data;
            
            return result.Result;
        }
    }
}