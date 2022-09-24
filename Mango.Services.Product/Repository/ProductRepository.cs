using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models.Dtos;
using Mango.Services.ProductAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<Product> _products;
    private readonly IMapper _mapper;

    public ProductRepository(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _products = dbContext.Products;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var product = await _products.FindAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateUpdateAsync(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);

        if (product.Id > 0)
        {
            _products.Update(product);
        }
        else
        {
            _products.Add(product);
        }

        await _dbContext.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var product = _products.Find(id);

            if (product is null)
                return false;

            _products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch 
        {

            return false;
        }
    }
}
