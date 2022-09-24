using Mango.UI.Web.Models.Dtos;

namespace Mango.UI.Web.Services.Interfaces;

public interface IProductService : IServiceBase
{
    Task<T> GetAllAsync<T>();
    Task<T> GetByIdAsync<T>(int id);
    Task<T> CreateAsync<T>(ProductDto productDto);
    Task<T> UpdateAsync<T>(ProductDto productDto);
    Task<T> DeleteAsync<T>(int id);
}
