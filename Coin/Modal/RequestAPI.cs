using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Coin
{
    public class RequestAPI
    {
        public RequestAPI()
        {
        }

        public async Task<List<Coin>> GetAllCoint(string url)
        {
            try
            {
                HttpClient http = new HttpClient();
                var res = await http.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<List<Coin>>(res);
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return default(List<Coin>);
        }

    }
}
