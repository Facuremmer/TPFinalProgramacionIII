using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models.DataTranfers.Product;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("Productos")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private IMapper _mapper;

        private IProductServices _productServices;

        public ProductController(ILogger<ProductController> logger,
                                  IMapper mapper,
                                  IProductServices productServices)
        {
            _logger = logger;
            _mapper = mapper;
            _productServices = productServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<ProductDTO> GetALL()
        {
            var product = _productServices.GetAll();
            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(product);
            return productDTO;
        } 

        [HttpGet("{productId}")]
        public ProductGetId GetOne(int productId)
        {
            var product = _productServices.GetOne(productId);
            var productDTO = _mapper.Map<ProductGetId>(product);
            return productDTO;
        }

        [Route("byName")]
        [HttpGet]

        public ActionResult<ProductDTO> GetByName(string productName)
        {
            var product = _productServices.GetByName(productName);
            if (product == null)
            {
                return NotFound();
            }

            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(product);
            return Ok(productDTO);
        }
        
        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int productId)
        {
            var product = _productServices.GetOne(productId);
            if (product == null)
            {
                return NotFound();
            }
            try
            {
                _productServices.DeleteProduct(product);
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
        public ActionResult<ProductDTO> UpdateProduct(ProductCreateOrUpdate productData)
        {
            if (productData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información del producto no puede ser nula");
            }
            try
            {
                var product = _productServices.UpdateProduct(productData);
                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<ProductDTO>(product));
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
        public ActionResult<ProductDTO> CreateProduct(ProductCreateOrUpdate productData)
        {
            if (productData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var product = _productServices.CreateProduct(productData);
                if (product == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<ProductDTO>(product));
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
