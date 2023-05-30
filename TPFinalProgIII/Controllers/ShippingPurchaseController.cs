using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TPFinalProgIII.Models.DataTranfers.ShippingPurchase;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("EnvioCompra")]
    public class ShippingPurchaseController : ControllerBase
    {
        private readonly ILogger<ShippingPurchaseController> _logger;

        private IMapper _mapper;

        private IShippingPurchaseServices _shippingPurchaseServices;

        public ShippingPurchaseController(ILogger<ShippingPurchaseController> logger,
                                  IMapper mapper,
                                  IShippingPurchaseServices shippingPurchaseServices)
        {
            _logger = logger;
            _mapper = mapper;
            _shippingPurchaseServices = shippingPurchaseServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<ShippingPurchaseDTO> GetALL()
        {
            var shippingPurchase = _shippingPurchaseServices.GetAll();
            var shippingPurchaseDTO = _mapper.Map<IEnumerable<ShippingPurchaseDTO>>(shippingPurchase);
            return shippingPurchaseDTO;
        }

        [HttpGet("{shippingPurchaseId}")]
        public ShippingPurchaseDTO GetOne(int shippingPurchaseId)
        {
            var shippingPurchase = _shippingPurchaseServices.GetOne(shippingPurchaseId);
            var shippingPurchaseDTO = _mapper.Map<ShippingPurchaseDTO>(shippingPurchase);
            return shippingPurchaseDTO;
        }

        [HttpDelete("{shippingPurchaseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int shippingPurchaseId)
        {
            var shippingPurchase = _shippingPurchaseServices.GetOne(shippingPurchaseId);
            if (shippingPurchase == null)
            {
                return NotFound();
            }
            try
            {
                _shippingPurchaseServices.DeleteShippingPurchase(shippingPurchase);
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
        public ActionResult<ShippingPurchaseDTO> UpdateShippingPurchase(ShippingPurchaseCreateOrUpdate shippingPurchaseData)
        {
            if (shippingPurchaseData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var shippingPurchase = _shippingPurchaseServices.UpdateShippingPurchase(shippingPurchaseData);
                if (shippingPurchase == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<ShippingPurchaseDTO>(shippingPurchase));
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
        public ActionResult<ShippingPurchaseDTO> CreateShippingPurchase(ShippingPurchaseCreateOrUpdate shippingPurchaseData)
        {
            if (shippingPurchaseData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var shippingPurchase = _shippingPurchaseServices.CreateShippingPurchase(shippingPurchaseData);
                if (shippingPurchase == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<ShippingPurchaseDTO>(shippingPurchase));
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
