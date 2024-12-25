using System.Security.Claims;
using Api.Commons;
using Application.DTOs;
using Application.Services.BrandServices;
using Application.Services.ImageServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.BrandAPI
{
    [ApiController]
    [Route("api/brand/[controller]")]
    [Authorize(Roles = "brand")]
    public class BrandController : ControllerBase
    {
        #region vars
        private readonly ILogger<BrandController> _logger;
        private readonly IBrandServices _brandServices;
        private readonly IImageServices _imageServices;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public BrandController(ILogger<BrandController> logger, IBrandServices brandServices, IImageServices imageServices, IMapper mapper)
        {
            _logger = logger;
            _brandServices = brandServices;
            _imageServices = imageServices;
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
        public async Task<IActionResult> GetBrandByUserId()
        {
            var userIdValue = User.FindFirstValue("User Id");
            if (userIdValue == null)
            {
                return Unauthorized();
            }
            Console.WriteLine($"User ID value: {userIdValue}");
            Guid userId = Guid.Parse(userIdValue);
            var brand = await _brandServices.GetBrandByUserIdAsync(userId);
            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromForm] BrandRequestDTO newBrand)
        {
            if (newBrand == null)
            {
                return BadRequest(new ApiResponse(400, "Bad Request. Brand data is required."));
            }

            var newBrandEntity = new Domain.Entities.Brand()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse(User.FindFirstValue("User Id")),
            };

            var result = await _brandServices.CreateBrandAsync(newBrandEntity);
            if (!result)
            {
                return BadRequest(new ApiResponse(400, "Failed to create brand"));
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromForm] BrandRequestDTO updatedBrand)
        {
            if (updatedBrand == null)
            {
                return BadRequest(new ApiResponse(400, "Bad Request. Brand data is required."));
            }

            if (updatedBrand.Id == null)
            {
                return BadRequest(new ApiResponse(400, "Bad Request. Brand ID is required."));
            }

            var brandEntity = await _brandServices.GetBrandByIDAsync((Guid)updatedBrand.Id);
            if (brandEntity == null)
            {
                return NotFound(new ApiResponse(404, "Brand not found"));
            }

            brandEntity.Name = updatedBrand.Name;
            brandEntity.Phone = updatedBrand.Phone;
            brandEntity.Email = updatedBrand.Email;
            brandEntity.Field = updatedBrand.Field;
            brandEntity.Latitude = updatedBrand.Latitude;
            brandEntity.Longitude = updatedBrand.Longitude;

            if (updatedBrand.BrandImage != null)
            {
                string fileName = brandEntity.Id + "_" + Guid.NewGuid().ToString();
                string folderName = "brands";
                string imageUrl = await _imageServices.UploadImageAsync(updatedBrand.BrandImage, fileName, folderName);
                brandEntity.ImageUrl = imageUrl;
            }

            var result = await _brandServices.UpdateBrandAsync(brandEntity);
            if (!result)
            {
                return BadRequest(new ApiResponse(400, "Failed to update brand"));
            }

            var updatedBrandEntity = await _brandServices.GetBrandByIDAsync(brandEntity.Id);

            return Ok(updatedBrandEntity);
        }
    }
}