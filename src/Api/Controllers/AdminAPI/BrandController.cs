using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.BrandServices;
using AutoMapper;
using Domain.Specifications.BrandSpec;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AdminAPI
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "admin")]
    public class BrandController : ControllerBase
    {
        #region vars
        private readonly ILogger<BrandController> _logger;
        private readonly IBrandServices _brandServices;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public BrandController(ILogger<BrandController> logger, IBrandServices brandServices, IMapper mapper)
        {
            _logger = logger;
            _brandServices = brandServices;
            _mapper = mapper;
        }
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(Guid id)
        {
            var brandEntity = await _brandServices.GetBrandByIDAsync(id);
            if (brandEntity == null)
            {
                return NotFound();
            }

            var brandDto = _mapper.Map<BrandResponseDTO>(brandEntity);
            
            return Ok(brandDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands([FromQuery] BrandSpecParams brandSpecParams)
        {
            var brands = await _brandServices.GetBrandsAsync(brandSpecParams);
            return Ok(brands);
        }


    }
}