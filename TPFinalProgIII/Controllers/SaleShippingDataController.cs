using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models.DataTranfers.SaleShippingData;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("DatosEnviosVentas")]
    public class SaleShippingDataController : ControllerBase
    {
        private readonly ILogger<SaleShippingDataController> _logger;

        private IMapper _mapper;

        private ISaleShippingDataServices _saleShippingDataServices;

        public SaleShippingDataController(ILogger<SaleShippingDataController> logger,
                                  IMapper mapper,
                                  ISaleShippingDataServices saleShippingDataServices)
        {
            _logger = logger;
            _mapper = mapper;
            _saleShippingDataServices = saleShippingDataServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<SaleShippingDataDTO> GetALL()
        {
            var saleShippingData = _saleShippingDataServices.GetAll();
            var saleShippingDataDTO = _mapper.Map<IEnumerable<SaleShippingDataDTO>>(saleShippingData);
            return saleShippingDataDTO;
        }

        [HttpGet("{saleShippingDataId}")]
        public SaleShippingDataDTO GetOne(int saleShippingDataId)
        {
            var saleShippingData = _saleShippingDataServices.GetOne(saleShippingDataId);
            var saleShippingDataDTO = _mapper.Map<SaleShippingDataDTO>(saleShippingData);
            return saleShippingDataDTO;
        }

        [HttpDelete("{saleShippingDataId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int saleShippingDataId)
        {
            var saleShippingData = _saleShippingDataServices.GetOne(saleShippingDataId);
            if (saleShippingData == null)
            {
                return NotFound();
            }
            try
            {
                _saleShippingDataServices.DeleteSaleShippingData(saleShippingData);
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
        public ActionResult<SaleShippingDataDTO> UpdateSaleShippingData(SaleShippingDataCreateOrUpdate saleShippingDataData)
        {
            if (saleShippingDataData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var saleShippingData = _saleShippingDataServices.UpdateSaleShippingData(saleShippingDataData);
                if (saleShippingData == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<SaleShippingDataDTO>(saleShippingData));
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
        public ActionResult<SaleShippingDataDTO> CreateSaleShippingData(SaleShippingDataCreateOrUpdate saleShippingDataData)
        {
            if (saleShippingDataData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var saleShippingData = _saleShippingDataServices.CreateSaleShippingData(saleShippingDataData);
                if (saleShippingData == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<SaleShippingDataDTO>(saleShippingData));
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
