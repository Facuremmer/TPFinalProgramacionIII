using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models.DataTranfers.ProviderController;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("Proveedor")]
    public class ProviderController : ControllerBase
    {
        private readonly ILogger<ProviderController> _logger;

        private IMapper _mapper;

        private IProviderServices _providerServices;

        public ProviderController(ILogger<ProviderController> logger,
                                  IMapper mapper,
                                  IProviderServices providerServices)
        {
            _logger = logger;
            _mapper = mapper;
            _providerServices = providerServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<ProviderDTO> GetALL()
        {
            var provider = _providerServices.GetAll();
            var providerDTO = _mapper.Map<IEnumerable<ProviderDTO>>(provider);
            return providerDTO;
        }

        [HttpGet("{providerId}")]
        public ProviderDTO GetOne(int providerId)
        {
            var provider = _providerServices.GetOne(providerId);
            var providerDTO = _mapper.Map<ProviderDTO>(provider);
            return providerDTO;
        }

        [HttpDelete("{providerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int providerId)
        {
            var provider = _providerServices.GetOne(providerId);
            if (provider == null)
            {
                return NotFound();
            }
            try
            {
                _providerServices.DeleteProvider(provider);
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
        public ActionResult<ProviderDTO> UpdateProvider(ProviderCreateOrUpdate providerData)
        {
            if (providerData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var provider = _providerServices.UpdateProvider(providerData);
                if (provider == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<ProviderDTO>(provider));
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
        public ActionResult<ProviderDTO> CreateProvider(ProviderCreateOrUpdate providerData)
        {
            if (providerData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var provider = _providerServices.CreateProvider(providerData);
                if (provider == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<ProviderDTO>(provider));
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
