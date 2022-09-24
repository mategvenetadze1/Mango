using Mango.UI.Web.Models.Enums;

namespace Mango.UI.Web.Models.Requests;

public class ApiRequest
{
    public ApiType ApiType { get; set; }
    public string Url { get; set; }
    public object Data { get; set; } 
}
