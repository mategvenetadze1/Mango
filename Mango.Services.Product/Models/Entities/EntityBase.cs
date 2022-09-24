using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Models.Entities;

public class EntityBase
{
    [Key]
    public int Id { get; set; }
}
