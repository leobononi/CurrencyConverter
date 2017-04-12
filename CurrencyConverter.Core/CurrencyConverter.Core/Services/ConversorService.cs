using CurrencyConverter.Core.Services.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.Services
{
    public class ConversorService : IConversorService
    {
        private CurrentCurrencyObject _currentCurrencyObject;

        public int CurrentQuote { get; set; }
        private const string _URL = "http://www.apilayer.net/api/live?access_key=74dd721e04f15dcd594b7e8fe3bd2a01";

        HttpClient CreateClient()
        {
            return new HttpClient(new ModernHttpClient.NativeMessageHandler());
        }

        public async Task<double> Convert(double value)
        {
            if (_currentCurrencyObject == null)
            {
                var client = CreateClient();
                if (client.DefaultRequestHeaders.CacheControl == null)
                    client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();

                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders.IfModifiedSince = DateTime.UtcNow;
                client.DefaultRequestHeaders.CacheControl.NoStore = true;
                client.Timeout = new TimeSpan(0, 0, 30);

                var response = await client.GetStringAsync(_URL);
                _currentCurrencyObject = JsonConvert.DeserializeObject<CurrentCurrencyObject>(response);
            }
            
            return (double)_currentCurrencyObject.quotes.USDBRL * value;
        }
    }
}
