using Mango.UI.Web.Models.Configs;
using Mango.UI.Web.Models.Dtos;
using Mango.UI.Web.Models.Enums;
using Mango.UI.Web.Models.Requests;
using Mango.UI.Web.Services.Interfaces;

namespace Mango.UI.Web.Services.Implementations;

public class ProductService : ServiceBase, IProductService
{
    public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

    public async Task<T> GetAllAsync<T>()
    {
        var request = new ApiRequest()
        {
            ApiType = ApiType.GET,
            Url = string.Concat(ServiceUrls.ProductUrl, "/api/products")
        };

        return await SendAsync<T>(request);
    }

    public async Task<T> GetByIdAsync<T>(int id)
    {
        var request = new ApiRequest()
        {
            ApiType = ApiType.GET,
            Url = string.Concat(ServiceUrls.ProductUrl, "/api/products/", id)
        };

        return await SendAsync<T>(request);
    }

    public async Task<T> CreateAsync<T>(ProductDto productDto)
    {
        var request = new ApiRequest() 
        { 
            ApiType = ApiType.POST,
            Data = productDto,
            Url = string.Concat(ServiceUrls.ProductUrl, "/api/products")
        };

        return await SendAsync<T>(request);
    }

    public async Task<T> UpdateAsync<T>(ProductDto productDto)
    {
        var request = new ApiRequest()
        {
            ApiType = ApiType.PUT,
            Data = productDto,
            Url = string.Concat(ServiceUrls.ProductUrl, "/api/products")
        };

        return await SendAsync<T>(request);
    }

    public async Task<T> DeleteAsync<T>(int id)
    {
        var request = new ApiRequest()
        {
            ApiType = ApiType.DELETE,
            Url = string.Concat(ServiceUrls.ProductUrl, "/api/products/", id)
        };

        return await SendAsync<T>(request);
    }
}
