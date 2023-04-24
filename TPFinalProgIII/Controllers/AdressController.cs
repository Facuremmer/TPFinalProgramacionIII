using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPFinalProgIII.Models.DataTranfers.Adress;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII.Controllers
{
    [ApiController]
    [Route("Dirección")]
    public class AdressController : ControllerBase
    {

        private readonly ILogger<AdressController> _logger;

        private IMapper _mapper;

        private IAdressServices _adressServices;

        public AdressController(ILogger<AdressController> logger,
                                  IMapper mapper,
                                  IAdressServices adressServices)
        {
            _logger = logger;
            _mapper = mapper;
            _adressServices = adressServices;
        }

        [Route("All")]
        [HttpGet]
        public IEnumerable<AdressDTO> GetALL()
        {
            var adress = _adressServices.GetAll();
            var adressDTO = _mapper.Map<IEnumerable<AdressDTO>>(adress);
            return adressDTO;
        }

        [HttpGet("{adressId}")]
        public AdressDTO GetOne(int adressId)
        {
            var adress = _adressServices.GetOne(adressId);
            var adressDTO = _mapper.Map<AdressDTO>(adress);
            return adressDTO;
        }

        [HttpDelete("{adressId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int adressId)
        {
            var adress = _adressServices.GetOne(adressId);
            if (adress == null)
            {
                return NotFound();
            }
            try
            {
                _adressServices.DeleteAdress(adress);
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
        public ActionResult<AdressDTO> UpdateAdress(AdressCreateOrUpdate adressData)
        {
            if (adressData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var adress = _adressServices.UpdateAdress(adressData);
                if (adress == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<AdressDTO>(adress));
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
        public ActionResult<AdressDTO> CreateAdress(AdressCreateOrUpdate adressData)
        {
            if (adressData == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "La información no puede ser nula");
            }
            try
            {
                var adress = _adressServices.CreateAdress(adressData);
                if (adress == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se puede crear");
                }
                else
                {
                    return Ok(_mapper.Map<AdressDTO>(adress));
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
