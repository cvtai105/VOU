using Application.DTOs;
using Application.Helpers;
using Domain.Entities;
using Domain.Specifications.BrandSpec;

namespace Application.Services.BrandServices
{
    public interface IBrandServices
    {
        Task<Brand?> GetBrandByIDAsync(Guid brandId);
        Task<BrandResponseDTO?> GetBrandByUserIdAsync(Guid userId);
        Task<Pagination<BrandResponseDTO>> GetBrandsAsync(BrandSpecParams brandSpecParams);
        Task<bool> CreateBrandAsync(Brand newBrand);
        Task<bool> UpdateBrandAsync(Brand updatedBrand);
    }
}