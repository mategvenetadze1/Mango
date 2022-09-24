using Mango.UI.Web.Models.Dtos;
using Mango.UI.Web.Models.Enums;
using Mango.UI.Web.Models.Requests;
using Mango.UI.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Mango.UI.Web.Services.Implementations;

public class ServiceBase : IServiceBase
{
    public ResponseDto Response { get; set; }
    protected IHttpClientFactory HttpClientFactory { get; set; }

    public ServiceBase(IHttpClientFactory httpClientFactory)
    {
        Response = new ResponseDto();
        HttpClientFactory = httpClientFactory;
    }

    public async Task<T> SendAsync<T>(ApiRequest apiRequest)
    {
        try
        {
            var httpClient = HttpClientFactory.CreateClient("Mongo");
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Headers.Add("Accept", "application/json");
            httpRequestMessage.RequestUri = new Uri(apiRequest.Url);

            if (apiRequest.Data is not null)
            {
                var stringData = JsonConvert.SerializeObject(apiRequest.Data);
                var stringContent = new StringContent(stringData, Encoding.UTF8, "application/json");
                httpRequestMessage.Content = stringContent;
            }

            switch (apiRequest.ApiType)
            {
                case ApiType.GET: httpRequestMessage.Method = HttpMethod.Get; break;
                case ApiType.POST: httpRequestMessage.Method = HttpMethod.Post; break;
                case ApiType.PUT: httpRequestMessage.Method = HttpMethod.Put; break;
                case ApiType.DELETE: httpRequestMessage.Method = HttpMethod.Delete; break;
            }

            var apiResponse = await httpClient.SendAsync(httpRequestMessage);
            var stringResponse = await apiResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }
        catch (Exception ex)
        {
            var response = new ResponseDto()
            {
                ErrorMessages = new List<string>() { ex.ToString() },
                IsSuccess = false
            };

            var stringResponse = JsonConvert.SerializeObject(response);
            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }
    }

    public void Dispose() => GC.SuppressFinalize(this);
}
