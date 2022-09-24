using Mango.UI.Web.Models.Dtos;
using Mango.UI.Web.Models.Requests;

namespace Mango.UI.Web.Services.Interfaces;

public interface IServiceBase : IDisposable
{
    public ResponseDto Response { get; set; }
    Task<T> SendAsync<T>(ApiRequest apiRequest);
}