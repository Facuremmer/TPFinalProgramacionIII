using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models.DataTranfers.ShippingSale;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("EnvioVenta")]
    public class ShippingSaleController : ControllerBase
    {
        private readonly ILogger<ShippingSaleController> _logger;

        private IMapper _mapper;

        private IShippingSaleServices _shippingSaleServices;

        public ShippingSaleController(ILogger<ShippingSaleController> logger,
                                  IMapper mapper,
                                  IShippingSaleServices shippingSaleServices)
        {
            _logger = logger;
            _mapper = mapper;
            _shippingSaleServices = shippingSaleServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<ShippingSaleDTO> GetALL()
        {
            var shippingSale = _shippingSaleServices.GetAll();
            var shippingSaleDTO = _mapper.Map<IEnumerable<ShippingSaleDTO>>(shippingSale);
            return shippingSaleDTO;
        }

        [HttpGet("{shippingSaleId}")]
        public ShippingSaleDTO GetOne(int shippingSaleId)
        {
            var shippingSale = _shippingSaleServices.GetOne(shippingSaleId);
            var shippingSaleDTO = _mapper.Map<ShippingSaleDTO>(shippingSale);
            return shippingSaleDTO;
        }

        [HttpDelete("{shippingSaleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int shippingSaleId)
        {
            var shippingSale = _shippingSaleServices.GetOne(shippingSaleId);
            if (shippingSale == null)
            {
                return NotFound();
            }
            try
            {
                _shippingSaleServices.DeleteShippingSale(shippingSale);
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
        public ActionResult<ShippingSaleDTO> UpdateShippingSale(ShippingSaleCreateOrUpdate shippingSaleData)
        {
            if (shippingSaleData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var shippingSale = _shippingSaleServices.UpdateShippingSale(shippingSaleData);
                if (shippingSale == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<ShippingSaleDTO>(shippingSale));
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
        public ActionResult<ShippingSaleDTO> CreateShippingSale(ShippingSaleCreateOrUpdate shippingSaleData)
        {
            if (shippingSaleData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var shippingSale = _shippingSaleServices.CreateShippingSale(shippingSaleData);
                if (shippingSale == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<ShippingSaleDTO>(shippingSale));
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
