using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models.DataTranfers.ProductType;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("TipoProducto")]
    public class ProductTypeController : ControllerBase
    {
        private readonly ILogger<ProductTypeController> _logger;

        private IMapper _mapper;

        private IProductTypeServices _productTypeServices;

        public ProductTypeController(ILogger<ProductTypeController> logger,
                                  IMapper mapper,
                                  IProductTypeServices productTypeServices)
        {
            _logger = logger;
            _mapper = mapper;
            _productTypeServices = productTypeServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<ProductTypeDTO> GetALL()
        {
            var productType = _productTypeServices.GetAll();
            var productTypeDTO = _mapper.Map<IEnumerable<ProductTypeDTO>>(productType);
            return productTypeDTO;
        }

        [HttpGet("{productTypeId}")]
        public ProductTypeDTO GetOne(int productTypeId)
        {
            var productType = _productTypeServices.GetOne(productTypeId);
            var productTypeDTO = _mapper.Map<ProductTypeDTO>(productType);
            return productTypeDTO;
        }

        [HttpDelete("{productTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int productTypeId)
        {
            var productType = _productTypeServices.GetOne(productTypeId);
            if (productType == null)
            {
                return NotFound();
            }
            try
            {
                _productTypeServices.DeleteProductType(productType);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error borrando la información ");
            }
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductTypeDTO> UpdateProductType(ProductTypeCreateOrUpdate productTypeData)
        {
            if (productTypeData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var productType = _productTypeServices.UpdateProductType(productTypeData);
                if (productType == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<ProductTypeDTO>(productType));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro actualizando la información");
            }
        }

        [Route("create")]
        [HttpPut]
        public ActionResult<ProductTypeDTO> CreateProductType(ProductTypeCreateOrUpdate productTypeData)
        {
            if (productTypeData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var productType = _productTypeServices.CreateProductType(productTypeData);
                if (productType == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<ProductTypeDTO>(productType));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear");
            }
        }
    }
}
