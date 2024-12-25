using Application.DTOs;
using Application.Helpers;
using Application.Services.BrandServices;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using Domain.Specifications.BrandSpec;

namespace Infrastructure.Services
{
    public class BrandServices : IBrandServices
    {
        #region vars
        private readonly IGenericRepository<Brand> _brandRepo;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public BrandServices(IGenericRepository<Brand> brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }
        #endregion

        public async Task<Brand?> GetBrandByIDAsync(Guid brandId)
        {
            return await _brandRepo.GetByIdAsync(brandId);
        }

        public async Task<BrandResponseDTO?> GetBrandByUserIdAsync(Guid userId)
        {
            var spec = new BrandSpecification(userId);
            var brand = await _brandRepo.GetEntityWithSpec(spec);

            return brand == null ? null : _mapper.Map<Brand, BrandResponseDTO>(brand);
        }

        public async Task<Pagination<BrandResponseDTO>> GetBrandsAsync(BrandSpecParams brandSpecParams)
        {
            var spec = new BrandSpecification(brandSpecParams, include: false);
            var countSpec = new BrandCountSpecification(brandSpecParams);

            List<Brand> brands = await _brandRepo.ListAsync(spec) ?? [];
            int numMatchingBrands = await _brandRepo.CountAsync(countSpec);

            var brandResponses = brands.Count() == 0 ? [] : _mapper.Map<List<Brand>, List<BrandResponseDTO>>(brands);

            return new Pagination<BrandResponseDTO>(
                brandSpecParams.PageIndex,
                brandSpecParams.PageSize,
                numMatchingBrands,
                brandResponses
            );
        }

        public async Task<bool> CreateBrandAsync(Brand newBrand)
        {
            _brandRepo.Add(newBrand);
            return await _brandRepo.SaveAsync() > 0;
        }

        public async Task<bool> UpdateBrandAsync(Brand updatedBrand)
        {
            _brandRepo.Update(updatedBrand);
            return await _brandRepo.SaveAsync() > 0;
        }
    }
}